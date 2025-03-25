using Microsoft.Testing.Platform.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.DataContracts;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json.Nodes;

namespace GherkinExecutorForCSharp
{

        public class Translate
        {
            private readonly Dictionary<string, string> scenarios = new Dictionary<string, string>(); // used to check if duplicate scenario names
            private readonly Dictionary<string, string> glueFunctions = new Dictionary<string, string>(); // used to make sure only one glue implementation
            private readonly Dictionary<string, string> dataNames = new Dictionary<string, string>(); // used to check for duplicate data
            private readonly Dictionary<string, string> dataNamesInternal = new Dictionary<string, string>(); // used to check for duplicate data
            private readonly Dictionary<string, string> importNames = new Dictionary<string, string>(); // used to hold conversion functions for imports

            private readonly List<string> linesToAddForDataAndGlue = new List<string>();

            private readonly List<string> linesToAddToEndOfGlue = new List<string>();
            private readonly Dictionary<string, string> defineNames = new Dictionary<string, string>();
            private int stepCount = 0; // use to label duplicate scenarios
            private string glueClass = "";  // glue class name
            private string glueObject = "";  // glue object name

            private int stepNumberInScenario = 0;  // use to label variables in scenario
            private InputIterator dataIn;
            private bool firstScenario = true; // If first scenario
            private bool addBackground = false;  // Have seen Background
            private bool addCleanup = false;  // have seen Cleanup

            private bool inCleanup = false; // current scenario is cleanup
            private bool finalCleanup = false; // for the last part of scenario
            private StreamWriter testFile;

            private bool featureActedOn = false; // Have found a feature step
            private string featureName = "";

            private string directoryName = "";

            private string featureDirectory = ""; // if feature file is in a directory

            private string featurePackagePath = "";
            string packagePath = "Not Set";
            private readonly List<string> classDataNames = new List<string>();

            private readonly DataConstruct dataConstruct = new DataConstruct();

            private readonly TemplateConstruct templateConstruct = new TemplateConstruct();

            private readonly StepConstruct stepConstruct = new StepConstruct();

            private readonly ImportConstruct importConstruct = new ImportConstruct();
            private readonly DefineConstruct defineConstruct = new DefineConstruct();

            public Translate() { }

            public void TranslateInTests(string name)
            {
                FindFeatureDirectory(name);

                linesToAddForDataAndGlue.AddRange(Configuration.LinesToAddForDataAndGlue);
                dataIn = new InputIterator(name, featureDirectory);
                AlterFeatureDirectory();
                if (dataIn.IsEmpty())
                    return;

                for (int pass = 1; pass <= 3; pass++)
                {
                    dataIn.Reset();
                    bool eof = false;
                    while (!eof)
                    {
                        string line = dataIn.Next();
                        if (line.Equals(InputIterator.EOF))
                        {
                            eof = true;
                            continue;
                        }
                        ActOnLine(line, pass);
                    }
                }
                EndUp();
            }

            private void AlterFeatureDirectory()
            {
                string searchFor = Configuration.TreeDirectory;
                string alternateSearchFor = searchFor.Replace("/", "\\");
                string directory = featureDirectory.Replace(searchFor, "");
                directory = directory.Replace(alternateSearchFor, "");
                featureDirectory = directory;
                featurePackagePath = featureDirectory.Replace("\\", ".").Replace("/", ".");
            }

            private void FindFeatureDirectory(string name)
            {
                string directory = "";
                int indexForward = name.LastIndexOf('/');
                int indexBack = name.LastIndexOf('\\');
                int index = Math.Max(indexForward, indexBack);
                if (index >= 0)
                    directory = name.Substring(0, index + 1);
                featureDirectory = directory;
                featurePackagePath = featureDirectory.Replace("\\", ".").Replace("/", ".");
            }

            private void ActOnLine(string line, int pass)
            {
                var splitLine = SplitLine(line);
                List<string> words = splitLine.Item1;
                List<string> comment = splitLine.Item2;
                if (words.Count > 0)
                {
                    string keyword = WordWithoutColon(words[0]);
                    if (keyword.Equals("*"))
                    {
                        keyword = "Star";
                    }
                    words[0] = keyword;
                    ActOnKeyword(keyword, words, comment, pass);
                }
            }

            private Tuple<List<string>, List<string>> SplitLine(string line)
            {
                string[] allWords = line.Split(' ');
                List<string> words = new List<string>();
                List<string> comment = new List<string>();
                bool inComment = false;
                foreach (string aWord in allWords)
                {
                    string word = aWord.Trim();
                    if (word.Length == 0) continue;
                    if (word.EndsWith(":"))
                    {
                        word = WordWithoutColon(word);
                    }
                    if (word.Length == 0) continue;
                    if (inComment)
                    {
                        comment.Add(word);
                        continue;
                    }
                    if (word[0] == '#')
                    {
                        inComment = true;
                        word = WordWithoutHash(word);
                        if (word.Length != 0)
                        {
                            comment.Add(word);
                        }
                        continue;
                    }
                    word = FilterWord(word);
                    words.Add(word);
                }
                return Tuple.Create(words, comment);
            }

            public static string FilterWord(string input)
            {
                if (input == null)
                {
                    return "";
                }
                return Regex.Replace(input, "[^0-9a-zA-Z_*]", "");
            }

            private static string WordWithoutColon(string word)
            {
                return Regex.Replace(word, "^:+|:+$", "");
            }

            private static string WordWithoutHash(string word)
            {
                return Regex.Replace(word, "^#+|#+$", "");
            }

            private void ActOnKeyword(string keyword, List<string> words, List<string> comment, int pass)
            {
                string fullName = MakeFullName(words);
                Trace("Act on keyword " + keyword + " " + fullName + " words " + words + " pass " + pass);

                if (keyword.Equals("Star"))
                {
                    switch (words[1])
                    {
                        case "Data":
                            keyword = "Data";
                            words.RemoveAt(0);
                            break;
                        case "Import":
                            keyword = "Import";
                            words.RemoveAt(0);
                            break;
                        case "Define":
                            keyword = "Define";
                            words.RemoveAt(0);
                            break;
                        case "Cleanup":
                            keyword = "Cleanup";
                            words.RemoveAt(0);
                            break;
                        default:
                            break;
                    }
                }
                switch (keyword)
                {
                    case "Feature":
                        if (pass != 2)
                            break;
                        ActOnFeature(fullName);
                        break;
                    case "Scenario":
                        if (pass != 3)
                            break;
                        ActOnScenario(fullName, addBackground, false, addCleanup, inCleanup);
                        inCleanup = false;
                        break;
                    case "Background":
                        if (pass != 3)
                            break;
                        ActOnScenario(fullName, false, true, false, inCleanup);
                        addBackground = true;
                        inCleanup = false;
                        break;
                    case "Cleanup":
                        if (pass != 3)
                            break;
                        ActOnScenario(fullName, false, false, false, inCleanup);
                        addCleanup = true;
                        inCleanup = true;
                        break;
                    case "But":
                    case "Given":
                    case "When":
                    case "Then":
                    case "And":
                    case "Star":
                    case "Arrange":
                    case "Act":
                    case "Assert":
                    case "Rule":
                    case "Calculation":
                        if (pass != 3)
                            break;
                        stepConstruct.ActOnStep(fullName, comment);
                        break;
                    case "Data":
                        if (pass != 2)
                            break;
                        dataConstruct.ActOnData(words);
                        break;
                    case "Import":
                        if (pass != 1)
                            break;
                        importConstruct.ActOnImport(words);
                        break;
                    case "Define":
                        if (pass != 1)
                            break;
                        defineConstruct.ActOnDefine(words);
                        break;
                    default:
                        break;
                }
            }

            private static string MakeFullName(List<string> words)
            {
                string temp = string.Join("_", words);
                return Regex.Replace(temp, "[^A-Za-z0-9_]", "_");
            }

            private void ActOnFeature(string fullName)
            {
                if (ActOnFeatureFirstHalf(fullName)) return;
                TestPrint("package " + packagePath + ";");
                switch (Configuration.TestFramework)
                {
                    case "JUnit4":
                        TestPrint("import org.junit.Test;");
                        break;
                    case "TestNG":
                        TestPrint("import org.testng.annotations.Test;");
                        break;
                    default:
                        TestPrint("import org.junit.jupiter.api.Test;");
                }
                TestPrint("import java.util.List;");
                if (Configuration.LogIt)
                {
                    TestPrint("import java.io.FileWriter;");
                    TestPrint("import java.io.IOException;");
                }
                TestPrint("class " + fullName + "{");
                TestPrint(LogIt());
                TestPrint("");

                templateConstruct.BeginTemplate();
            }

            private bool ActOnFeatureFirstHalf(string fullName)
            {
                if (featureActedOn)
                {
                    Warning("Feature keyword duplicated - it is ignored " + fullName);
                    return true;
                }
                featureName = fullName;
                featureActedOn = true;
                packagePath = Configuration.AddToPackageName + Configuration.PackageName + "." + featurePackagePath + featureName;
                PrintFlow("Package is " + packagePath);
                string testPathname = Configuration.TestSubDirectory + featureDirectory + featureName + "/" + featureName + ".java";
                PrintFlow(" Writing " + testPathname);
                string templateFilename = Configuration.TestSubDirectory + featureDirectory + featureName + "/" + featureName + "_glue.tmpl";
                directoryName = Configuration.TestSubDirectory + featureDirectory + featureName;
                PrintFlow("Directory " + directoryName + " ");
                try
                {
                    bool result = Directory.CreateDirectory(directoryName).Exists;
                    if (!result)
                        Trace("Possible error in creating directory " + directoryName);
                    testFile = new StreamWriter(testPathname, false);
                    templateConstruct.GlueTemplateFile = new StreamWriter(templateFilename, false);
                }
                catch (IOException e)
                {
                    Error("IO Exception in setting up the files");
                    Error(" Writing " + testPathname);
                }
                glueClass = fullName + "_glue";
                glueObject = MakeName(fullName) + "_glue_object";
                WriteInputFeature(Configuration.TestSubDirectory + featureDirectory + featureName + "/");
                return false;
            }

            private string MakeBuildName(string s)
            {
                string temp = MakeName(s);
                temp = char.ToUpper(temp[0]) + temp.Substring(1);
                return "Set" + temp;
            }

            private string MakeName(string input)
            {
                if (input.Length == 0) return "NAME_IS_EMPTY";
                string temp = input.Replace(" ", "_");
                temp = FilterWord(temp);
                return char.ToLower(temp[0]) + temp.Substring(1);
            }

            private void ActOnScenario(string fullName, bool addBackground, bool inBackground, bool addCleanup, bool inCleanup)
            {
                Trace("In background " + inBackground);
                string fullNameToUse = fullName;
                if (scenarios.ContainsKey(fullName))
                {
                    fullNameToUse += stepCount;
                    Error("Scenario name duplicated renamed " + fullNameToUse);
                }
                else
                {
                    scenarios[fullNameToUse] = "";
                }
                stepNumberInScenario = 0;
                if (inCleanup)
                    finalCleanup = false;
                else if (addCleanup)
                    finalCleanup = true;
                if (firstScenario)
                {
                    firstScenario = false;
                }
                else
                {
                    if (addCleanup && !inCleanup)
                    {
                        TestPrint("        Test_Cleanup(" + glueObject + "); // from previous");
                    }
                    TestPrint("        }"); // end previous scenario
                }
                if (!fullNameToUse.StartsWith("Background") && !fullNameToUse.StartsWith("Cleanup"))
                {
                    TestPrint("    [Test]");
                    TestPrint("    public void Test_" + fullNameToUse + "(){");
                    TestPrint("         " + glueClass + " " + glueObject + " = new " + glueClass + "();");
                }
                else
                    TestPrint("    void Test_" + fullNameToUse + "(" + glueClass + " " + glueObject + "){");

                if (Configuration.LogIt)
                {
                    TestPrint("        Log(" + "\"" + fullNameToUse + "\"" + ");");
                }
                if (addBackground)
                {
                    TestPrint("        Test_Background(" + glueObject + ");");
                }
            }

            private string LogIt()
            {
                if (Configuration.LogIt)
                {
                    string filename = directoryName + "/log.txt";
                    return "void Log(string value) {\n" +
                           "    try {\n" +
                           "        using (var myLog = new StreamWriter(\"" + filename + "\", true))\n" +
                           "        {\n" +
                           "            myLog.WriteLine(value);\n" +
                           "        }\n" +
                           "    } catch (IOException e) {\n" +
                           "    Console.Error.WriteLine(\"*** Cannot write to log \");\n" +
                           "    }\n" +
                           "    }\n";
                }
                else
                    return "";
            }

            private void Trace(string value)
            {
                if (Configuration.TraceOn)
                {
                    Console.WriteLine(value);
                }
            }

            private bool errorOccurred = false;

            private void Error(string value)
            {
                Console.Error.WriteLine("[GherkinExecutor] ~ line " +
                        this.dataIn.GetLineNumber() + " in " + "feature.txt " +
                        value + " ");
                errorOccurred = true;
            }

            private void Warning(string value)
            {
                Console.Error.WriteLine("[GherkinExecutor] Warning " +
                        "~ line " + this.dataIn.GetLineNumber() + " in "
                        + "feature.txt " + value);
            }

            private static void PrintFlow(string value)
            {
                Console.WriteLine(value);
            }

            private void TestPrint(string line)
            {
                try
                {
                    testFile.WriteLine(line);
                }
                catch (IOException)
                {
                    Error("IO ERROR ");
                }
            }

            private void WriteInputFeature(string filename)
            {
                string fullFilename = filename + "feature.txt";
                PrintFlow("Logging to " + fullFilename);
                try
                {
                    using (var myLog = new StreamWriter(fullFilename))
                    {
                        myLog.Write(dataIn.ToString());
                    }
                }
                catch (IOException e)
                {
                    Console.Error.WriteLine(e.Message + " Cause " + e.InnerException);
                    Console.Error.WriteLine("**** Cannot write to " + fullFilename);
                }
            }

            private void EndUp()
            {
                if (finalCleanup)
                {
                    TestPrint("        Test_Cleanup(" + glueObject + "); // at the end");
                }
                TestPrint("        }");   // End last scenario
                TestPrint("    }"); // End the class
                TestPrint("");
                try
                {
                    testFile.Close();
                }
                catch (IOException)
                {
                    Error("Error in closing ");
                }

                templateConstruct.EndTemplate();
                if (errorOccurred)
                {
                    Console.Error.WriteLine("*** Error in translation, scan the output");
                    Environment.Exit(-1);
                }
            }

        // Additional nested classes and implementations should be translated similarly...
    }

    // Additional classes like InputIterator, StepConstruct, TemplateConstruct, DataConstruct, ImportConstruct, DefineConstruct, Configuration, etc. should be translated similarly...

    public static void Main(string[] args)
            {
                PrintFlow("Gherkin Executor");
                Configuration.CurrentDirectory = Directory.GetCurrentDirectory();
                ProcessArguments(args);
                if (Configuration.SearchTree && !string.IsNullOrEmpty(Configuration.StartingFeatureDirectory))
                {
                    List<string> filesInTree = FindFeatureFiles(Configuration.StartingFeatureDirectory);
                    PrintFlow("Adding directory tree files");
                    filesInTree.ForEach(Console.WriteLine);
                    Configuration.FeatureFiles.AddRange(filesInTree);
                }
                ReadFeatureList();
                foreach (string name in Configuration.FeatureFiles)
                {
                    Translate translate = new Translate();
                    PrintFlow("Translating " + name);
                    translate.TranslateInTests(name);
                }
            }

            private static void ProcessArguments(string[] args)
            {
                PrintFlow("Optional arguments are logIt inTest searchTree traceOn");
                foreach (string arg in args)
                {
                    PrintFlow("Program argument: " + arg);
                    switch (arg)
                    {
                        case "logIt":
                            Configuration.LogIt = true;
                            PrintFlow("logIt on");
                            break;
                        case "inTest":
                            Configuration.InTest = true;
                            PrintFlow("inTest on");
                            break;
                        case "traceOn":
                            Configuration.TraceOn = true;
                            PrintFlow("traceOn true");
                            break;
                        case "searchTree":
                            Configuration.SearchTree = true;
                            PrintFlow("searchTree on");
                            break;
                        default:
                            Configuration.FeatureFiles.Add(arg);
                            break;
                    }
                }
            }

            public static List<string> FindFeatureFiles(string directory)
            {
                List<string> featureFiles = new List<string>();
                CollectFeatureFiles(new DirectoryInfo(directory), featureFiles);
                return featureFiles;
            }

            public static void ReadFeatureList()
            {
                string filepath = Configuration.FeatureSubDirectory + "features.txt";
                PrintFlow("Path is " + filepath);
                List<string> raw;
                try
                {
                    raw = new List<string>(File.ReadAllLines(filepath));
                }
                catch (Exception)
                {
                    Console.Error.WriteLine(" Unable to read " + filepath);
                    return;
                }
                Configuration.FeatureFiles.AddRange(raw);
            }

            private static void CollectFeatureFiles(DirectoryInfo dir, List<string> featureFiles)
            {
                string remove = Configuration.FeatureSubDirectory;
                remove = remove.Replace("/", "\\");
                if (dir.Exists)
                {
                    foreach (var file in dir.GetFiles())
                    {
                        if (file.Extension == ".feature")
                        {
                            string path = file.FullName;
                            path = path.Replace(remove, "");
                            featureFiles.Add(path);
                        }
                    }
                    foreach (var subdir in dir.GetDirectories())
                    {
                        CollectFeatureFiles(subdir, featureFiles);
                    }
                }
            }

            private static void PrintFlow(string value)
            {
                Console.WriteLine(value);
        }

        public class InputIterator
        {
            private readonly List<string> linesIn = new List<string>();
            private int index = 0;

            public int GetLineNumber()
            {
                return index;
            }

            public override string ToString()
            {
                StringBuilder temp = new StringBuilder();
                foreach (string line in linesIn)
                {
                    temp.Append(line);
                    temp.Append("\n");
                }
                return temp.ToString();
            }

            public static readonly string EOF = "EOF";

            private readonly string featureDirectory;

            public InputIterator(string name, string featureDirectory)
            {
                index = 0;
                this.featureDirectory = featureDirectory;
                if (!string.IsNullOrEmpty(name))
                {
                    ReadFile(name, 0);
                }
            }

            private void ReadFile(string fileName, int includeCount)
            {
                includeCount++;
                if (includeCount > 20)
                {
                    Error("Too many levels of include");
                    return;
                }
                try
                {
                    string filepath = Path.Combine(Configuration.FeatureSubDirectory, fileName);
                    PrintFlow("Path is " + filepath);
                    List<string> raw;
                    try
                    {
                        raw = File.ReadAllLines(filepath).ToList();
                    }
                    catch (Exception e)
                    {
                        Error(" Unable to read " + filepath);
                        return;
                    }
                    foreach (string line in raw)
                    {
                        if (line.StartsWith("Include"))
                        {
                            string[] parts = line.Split('"');
                            Trace("Parts are " + string.Join(", ", parts));
                            bool localFile = true;
                            if (parts.Length < 2)
                            {
                                parts = line.Split('\'');
                                localFile = false;
                                if (parts.Length < 2)
                                {
                                    Error("Error filename not surrounded by quotes: " + line);
                                    continue;
                                }
                            }
                            if (string.IsNullOrEmpty(parts[1]))
                            {
                                Error("Error zero length filename " + line);
                                continue;
                            }
                            string includedFileName = parts[1].Trim();
                            if (localFile)
                                includedFileName = Path.Combine(featureDirectory, includedFileName);
                            Trace("Including " + includedFileName);
                            if (includedFileName.EndsWith(".csv"))
                            {
                                IncludeCSVFile(includedFileName);
                            }
                            else
                            {
                                ReadFile(includedFileName, includeCount);
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(line) && line[0] != '#')
                            {
                                linesIn.Add(line.Trim());
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e);
                }
                includeCount--;
            }

            private void IncludeCSVFile(string includedFileName)
            {
                try
                {
                    List<string> raw = File.ReadAllLines(Path.Combine(Configuration.FeatureSubDirectory, includedFileName)).ToList();
                    foreach (string line in raw)
                    {
                        if (string.IsNullOrEmpty(line)) continue;
                        string contents = ConvertCSVToTable(line);
                        linesIn.Add(contents.Trim());
                    }
                }
                catch (IOException e)
                {
                    Console.Error.WriteLine(e);
                }
            }

            public string ConvertCSVToTable(string csvData)
            {
                string[] lines = csvData.Split('\n');
                List<List<string>> data = new List<List<string>>();
                foreach (string line in lines)
                {
                    data.Add(ParseCsvLine(line));
                }
                List<string> formattedData = new List<string>();
                foreach (List<string> row in data)
                {
                    formattedData.Add("|" + string.Join("|", row) + "|");
                }
                return string.Join("\n", formattedData);
            }

            public List<string> ParseCsvLine(string line)
            {
                List<string> result = new List<string>();
                StringBuilder current = new StringBuilder();
                bool inQuotes = false;

                int length = line.Length;
                for (int i = 0; i < length; i++)
                {
                    char c = line[i];
                    if (c == '"')
                    {
                        if (inQuotes && i + 1 < length && line[i + 1] == '"')
                        {
                            current.Append('"');
                            i++;
                        }
                        else
                        {
                            inQuotes = !inQuotes;
                        }
                    }
                    else if (c == ',' && !inQuotes)
                    {
                        result.Add(current.ToString());
                        current.Clear();
                    }
                    else
                    {
                        current.Append(c);
                    }
                }
                result.Add(current.ToString());
                return result;
            }

            public string Peek()
            {
                if (index < linesIn.Count)
                {
                    return linesIn[index];
                }
                else
                {
                    return EOF;
                }
            }

            public string Next()
            {
                if (index < linesIn.Count)
                {
                    return linesIn[index++];
                }
                else
                {
                    return EOF;
                }
            }

            private void Trace(string value)
            {
                if (Configuration.TraceOn)
                {
                    Console.WriteLine("   " + value);
                }
            }

            private void Error(string value)
            {
                Console.Error.WriteLine("[GherkinExecutor] ~ line " +
                        this.GetLineNumber() + " in " + "feature.txt " +
                        value + " ");
            }

            public bool IsEmpty()
            {
                return !linesIn.Any();
            }

            public void Reset()
            {
                index = 0;
            }
        }
    public record Pair<K, V>(K key, V value)
    {

        public K getFirst()
        {
            return key;
        }

        public V getSecond()
        {
            return value;
        }

        @Override
    public String toString()
        {
            return "Pair{" + "key=" + key + ", value=" + value + '}';
        }
    }


            public class StepConstruct
            {
                private int stepNumberInScenario = 0;
                private string glueObject = "glueObject"; // Placeholder for the glueObject
                private TemplateConstruct templateConstruct = new TemplateConstruct();

                private void ActOnStep(string fullName, List<string> comment)
                {
                    stepNumberInScenario += 1;
                    var follow = LookForFollow();
                    string followType = follow.Item1;
                    List<string> table = follow.Item2;
                    TestPrint("");
                    switch (followType)
                    {
                        case "TABLE":
                            CreateTheTable(comment, table, fullName);
                            break;
                        case "NOTHING":
                            NoParameter(fullName);
                            break;
                        case "STRING":
                            CreateTheStringCode(comment, table, fullName);
                            break;
                        default:
                            Error("Internal Error - Follow type " + followType);
                            break;
                    }
                }

                private void CreateTheStringCode(List<string> comment, List<string> table, string fullName)
                {
                    string option = "String";
                    if (comment.Count > 0 && !string.IsNullOrEmpty(comment[0]))
                        option = comment[0];
                    if (option.Equals("ListOfString"))
                        StringToList(table, fullName);
                    else
                        StringToString(table, fullName);
                }

                private void StringToList(List<string> table, string fullName)
                {
                    string s = stepNumberInScenario.ToString();
                    string dataType = "List<string>";
                    string dataTypeInitializer = "new List<string>";
                    TestPrint($"        List<string> stringList{s} = {dataTypeInitializer}(");
                    string comma = "";
                    foreach (string line in table)
                    {
                        TestPrint($"            {comma}\"{line}\"");
                        comma = ",";
                    }
                    TestPrint("            );");
                    TestPrint($"        {glueObject}.{fullName}(stringList{s});");
                    templateConstruct.MakeFunctionTemplateIsList(dataType, fullName, "String");
                }

                private void StringToString(List<string> table, string fullName)
                {
                    string s = stepNumberInScenario.ToString();
                    TestPrint($"        string string{s} =");
                    TestPrint("            @\"\"\"");
                    foreach (string line in table)
                    {
                        TestPrint($"            {line}");
                    }
                    TestPrint("            \"\"\".Trim();");
                    TestPrint($"        {glueObject}.{fullName}(string{s});");
                    templateConstruct.MakeFunctionTemplate("string", fullName);
                }

                private void TableToListOfListOfObject(List<string> table, string fullName, string className)
                {
                    string s = stepNumberInScenario.ToString();
                    string dataType = "List<List<string>>";
                    string dataTypeInitializer = "new List<List<string>>";

                    TestPrint($"        List<List<string>> stringListList{s} = {dataTypeInitializer}(");
                    string comma = "";
                    foreach (string line in table)
                    {
                        ConvertBarLineToList(line, comma);
                        comma = ",";
                    }
                    TestPrint("            );");
                    TestPrint($"        {glueObject}.{fullName}(stringListList{s});");
                    templateConstruct.MakeFunctionTemplateObject(dataType, fullName, className);
                    CreateConvertTableToListOfListOfObjectMethod(className);
                }

                private void TableToListOfList(List<string> table, string fullName)
                {
                    string s = stepNumberInScenario.ToString();
                    string dataType = "List<List<string>>";
                    string dataTypeInitializer = "new List<List<string>>";

                    TestPrint($"        List<List<string>> stringListList{s} = {dataTypeInitializer}(");
                    string comma = "";
                    foreach (string line in table)
                    {
                        ConvertBarLineToList(line, comma);
                        comma = ",";
                    }
                    TestPrint("            );");
                    TestPrint($"        {glueObject}.{fullName}(stringListList{s});");
                    templateConstruct.MakeFunctionTemplateIsList(dataType, fullName, "List<string>");
                }

                private void CreateTheTable(List<string> comment, List<string> table, string fullName)
                {
                    string option = "ListOfList";
                    string className;
                    if (comment.Count > 0 && !string.IsNullOrEmpty(comment[0]))
                        option = comment[0];
                    switch (option)
                    {
                        case "ListOfList":
                            TableToListOfList(table, fullName);
                            break;
                        case "ListOfListOfObject":
                            if (comment.Count < 2)
                            {
                                Error("No class name specified");
                                return;
                            }
                            className = comment[1];
                            TableToListOfListOfObject(table, fullName, className);
                            break;
                        case "String":
                        case "string":
                            TableToString(table, fullName);
                            break;
                        case "ListOfObject":
                            if (comment.Count < 2)
                            {
                                Error("No class name specified");
                                return;
                            }
                            className = comment[1];
                            bool transpose = false;
                            bool compare = false;
                            if (comment.Count > 2)
                            {
                                string action = comment[2];
                                if (action.Equals("compare", StringComparison.OrdinalIgnoreCase))
                                    compare = true;
                                else if (!action.Equals("transpose", StringComparison.OrdinalIgnoreCase))
                                {
                                    Error("Action not recognized " + action);
                                }
                                else
                                {
                                    transpose = true;
                                }
                            }
                            TableToListOfObject(table, fullName, className, transpose, compare);
                            break;
                        default:
                            Error("Option not found, default to ListOfList " + option);
                            TableToListOfList(table, fullName);
                            break;
                    }
                }

                private void CreateConvertTableToListOfListOfObjectMethod(string toClass)
                {
                    var variable = new DataConstruct.DataValues("s", "s", toClass);
                    string convert = MakeValueFromString(variable, true);

                    string template =
                        $"""
                    public static List<List<{toClass}>> ConvertList(List<List<string>> stringList)
                    {{List < List <{toClass}>> classList = new List<List<{toClass}>>();
                        foreach (List<string> innerList in stringList)
                        {{
                            List<{toClass}> innerClassList = new List<{toClass}>();
                            foreach (string s in innerList)
                            {{
                                innerClassList.Add({convert});
                            }
                            classList.Add(innerClassList);
                        }
                        return classList;
                    }}
                    """;
                    // Add template to the appropriate collection
                }

                private void TableToString(List<string> table, string fullName)
                {
                    string s = stepNumberInScenario.ToString();
                    TestPrint($"        string table{s} =");
                    TestPrint("            @\"\"\"");
                    foreach (string line in table)
                    {
                        TestPrint($"            {line}");
                    }
                    TestPrint("            \"\"\".Trim();");
                    TestPrint($"        {glueObject}.{fullName}(table{s});");
                    // TestPrint("");
                    templateConstruct.MakeFunctionTemplate("string", fullName);
                }

                private void ConvertBarLineToList(string lineIn, string commaIn)
                {
                    string line = lineIn.Split('#')[0].Trim();
                    TestPrint($"           {commaIn}new List<string>(");
                    List<string> elements = ParseLine(line);
                    string comma = "";
                    foreach (string element in elements)
                    {
                        TestPrint($"            {comma}\"{element}\"");
                        comma = ",";
                    }
                    TestPrint("            )");
                }

                private void TableToListOfObject(List<string> table, string fullName, string className, bool transpose, bool compare)
                {
                    Trace("TableToListOfObject classNames " + className);
                    string s = stepNumberInScenario.ToString();
                    string dataType = $"List<{className}>";
                    string dataTypeInitializer = "new List<" + className + ">(";

                    TestPrint($"        List<{className}> objectList{s} = {dataTypeInitializer}");
                    bool inHeaderLine = true;
                    List<List<string>> dataList = ConvertToListList(table, transpose);
                    List<string> headers = new List<string>();
                    string comma = "";
                    foreach (List<string> row in dataList)
                    {
                        if (inHeaderLine)
                        {
                            headers = row;
                            foreach (string dataName in row)
                            {
                                if (!FindDataClassName(className, MakeName(dataName)))
                                {
                                    Error("Data name " + dataName + " not in Data for " + className);
                                }
                            }

                            inHeaderLine = false;
                            continue;
                        }

                        ConvertBarLineToParameter(headers, row, className, comma, compare);
                        comma = ",";
                    }
                    TestPrint("            );");
                    TestPrint($"        {glueObject}.{fullName}(objectList{s});");

                    templateConstruct.MakeFunctionTemplateIsList(dataType, fullName, className);
                }

                private List<List<string>> ConvertToListList(List<string> table, bool transpose)
                {
                    List<List<string>> temporary = new List<List<string>>();
                    foreach (string line in table)
                    {
                        temporary.Add(ParseLine(line));
                    }
                    List<List<string>> result = temporary;
                    if (transpose)
                    {
                        result = Transpose(temporary);
                    }
                    return result;
                }

                private bool FindDataClassName(string className, string dataName)
                {
                    string compare = className + "#" + dataName;
                    foreach (string value in classDataNames)
                    {
                        if (value.Equals(compare))
                            return true;
                    }
                    return false;
                }

                private void ConvertBarLineToParameter(List<string> headers, List<string> values, string className, string comma, bool compare)
                {
                    Trace("Headers " + headers);
                    int size = headers.Count;
                    if (headers.Count > values.Count)
                    {
                        size = values.Count;
                        Error("not sufficient values, using what is there" + values);
                    }
                    TestPrint($"            {comma} new {className}.Builder()");
                    if (compare)
                        TestPrint("             .SetCompare()");
                    for (int i = 0; i < size; i++)
                    {
                        string value = "\"" + values[i].Replace(Configuration.SpaceCharacters, ' ') + "\"";
                        TestPrint($"                .{MakeBuildName(headers[i])}({value})");
                    }
                    TestPrint("                .Build()");
                }

                private void NoParameter(string fullName)
                {
                    TestPrint($"        {glueObject}.{fullName}();");
                    templateConstruct.MakeFunctionTemplateNothing("", fullName);
                }

                public List<List<string>> Transpose(List<List<string>> matrix)
                {
                    List<List<string>> transposed = new List<List<string>>();
                    for (int i = 0; i < matrix[0].Count; i++)
                    {
                        List<string> row = new List<string>();
                        for (int j = 0; j < matrix.Count; j++)
                        {
                            row.Add(matrix[j][i]);
                        }
                        transposed.Add(row);
                    }
                    return transposed;
                }

                private Tuple<string, List<string>> LookForFollow()
                {
                    // Add implementation for LookForFollow method
                    return new Tuple<string, List<string>>("NOTHING", new List<string>());
                }

    }
    
            public class TemplateConstruct
            {
                private StreamWriter glueTemplateFile;

                private void TemplatePrint(string line)
                {
                    try
                    {
                        glueTemplateFile.WriteLine(line);
                    }
                    catch (IOException e)
                    {
                        Error("IO ERROR");
                    }
                }

                private void MakeFunctionTemplateObject(string dataType, string fullName, string listElement)
                {
                    if (CheckForExistingTemplate(dataType, fullName)) return; // already have a prototype
                    glueFunctions[fullName] = dataType;
                    TemplatePrint($"    void {fullName}({dataType} values ) {{");

                    TemplatePrint($"    List<List<{listElement}>> is = ConvertList(values);");
                    TemplatePrint("    Console.WriteLine(is);");

                    if (Configuration.LogIt)
                    {
                        TemplatePrint($"        Log(\"---  \" + \"{fullName}\");");
                    }
                    if (!Configuration.InTest)
                        TemplatePrint("        throw new NotImplementedException();");
                    TemplatePrint("    }");
                    TemplatePrint("");
                }

                private bool CheckForExistingTemplate(string dataType, string fullName)
                {
                    if (glueFunctions.ContainsKey(fullName))
                    {
                        string currentDataType = glueFunctions[fullName];
                        if (!currentDataType.Equals(dataType))
                        {
                            Error($"function {fullName} datatype {currentDataType} not equals {dataType}");
                            return true;
                        }
                        return true;
                    }
                    return false;
                }

                private void MakeFunctionTemplateNothing(string dataType, string fullName)
                {
                    if (CheckForExistingTemplate(dataType, fullName)) return; // already have a prototype
                    glueFunctions[fullName] = dataType;
                    TemplatePrint($"    void {fullName}(){{");
                    TemplatePrint($"        Console.WriteLine(\"---  \" + \"{fullName}\");");
                    if (Configuration.LogIt)
                        TemplatePrint($"        Log(\"---  \" + \"{fullName}\");");
                    if (!Configuration.InTest)
                        TemplatePrint("        throw new NotImplementedException();");
                    TemplatePrint("    }");
                    TemplatePrint("");
                }

                private void MakeFunctionTemplateIsList(string dataType, string fullName, string listElement)
                {
                    if (CheckForExistingTemplate(dataType, fullName)) return; // already have a prototype
                    glueFunctions[fullName] = dataType;
                    TemplatePrint($"    void {fullName}({dataType} values ) {{");
                    TemplatePrint($"        Console.WriteLine(\"---  \" + \"{fullName}\");");
                    if (Configuration.LogIt)
                    {
                        TemplatePrint($"        Log(\"---  \" + \"{fullName}\");");
                        TemplatePrint("        Log(values.ToString());");
                    }
                    string name = listElement + "Internal";
                    TemplatePrint($"        foreach ({listElement} value in values){{");
                    TemplatePrint("             Console.WriteLine(value);");
                    TemplatePrint("             // Add calls to production code and asserts");
                    if (!dataType.Equals("List<List<string>>")
                            && !listElement.Equals("String")
                            && (dataNamesInternal.ContainsKey(name)))
                    {
                        TemplatePrint($"              {name} i = value.To{name}();");
                    }
                    TemplatePrint("              }");

                    if (!Configuration.InTest)
                        TemplatePrint("        throw new NotImplementedException();");
                    TemplatePrint("    }");
                    TemplatePrint("");
                }

                private void MakeFunctionTemplate(string dataType, string fullName)
                {
                    if (CheckForExistingTemplate(dataType, fullName)) return; // already have a prototype
                    glueFunctions[fullName] = dataType;
                    TemplatePrint($"    void {fullName}({dataType} value ) {{");
                    TemplatePrint($"        Console.WriteLine(\"---  \" + \"{fullName}\");");
                    if (Configuration.LogIt)
                    {
                        TemplatePrint($"        Log(\"---  \" + \"{fullName}\");");
                        TemplatePrint("        Log(value.ToString());");
                    }
                    TemplatePrint("        Console.WriteLine(value);");
                    if (!Configuration.InTest)
                        TemplatePrint("        throw new NotImplementedException();");
                    TemplatePrint("    }");
                    TemplatePrint("");
                }

                private void BeginTemplate()
                {
                    TemplatePrint($"namespace {packagePath} {{");
                    foreach (string line in linesToAddForDataAndGlue)
                    {
                        TemplatePrint(line);
                    }
                    switch (Configuration.TestFramework)
                    {
                        case "JUnit4":
                            TemplatePrint("using static NUnit.Framework.Assert;");
                            break;
                        case "TestNG":
                            TemplatePrint("using static TestNG.Assert;");
                            break;
                        default:
                            TemplatePrint("using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;");
                            break;
                    }
                    TemplatePrint("using System.Collections.Generic;");
                    if (Configuration.LogIt)
                    {
                        TemplatePrint("using System.IO;");
                    }
                    TemplatePrint("");
                    TemplatePrint($"public class {glueClass} {{");
                    TemplatePrint($"    const string DNCString = \"{Configuration.DoNotCompare}\";");
                    TemplatePrint(LogIt());

                    TemplatePrint("");
                }

                private void EndTemplate()
                {
                    foreach (string line in linesToAddToEndOfGlue)
                    {
                        TemplatePrint(line);
                    }
                    TemplatePrint("    }");   // End the class
                    try
                    {
                        testFile.Close();
                        glueTemplateFile.Close();
                    }
                    catch (IOException e)
                    {
                        Error("Error in closing ");
                    }
                }

                private void Error(string message)
                {
                    Console.Error.WriteLine($"[GherkinExecutor] {message}");
                }
    }

    public class DataConstruct
    {
        private StreamWriter dataDefinitionFile;
        private const string throwString = "";

        public class DataValues
        {
            public string Name { get; }
            public string DefaultVal { get; }
            public string DataType { get; }
            public string Notes { get; }

            public DataValues(string name, string defaultVal, string dataType, string notes)
            {
                Name = name;
                DefaultVal = defaultVal;
                DataType = dataType;
                Notes = notes;
            }

            public DataValues(string name, string defaultVal, string dataType)
                : this(name, defaultVal, dataType, "") { }

            public DataValues(string name, string defaultVal)
                : this(name, defaultVal, "String", "") { }
        }

        private void ActOnData(List<string> words)
        {
            string internalClassName;
            if (words.Count < 2)
            {
                Error("Need to specify data class name");
            }
            string className = words[1];
            bool providedOtherClassName;
            if (words.Count > 2)
            {
                internalClassName = words[2];
                providedOtherClassName = true;
            }
            else
            {
                providedOtherClassName = false;
                internalClassName = className + "Internal";
            }
            var follow = LookForFollow();
            string followType = follow.Item1;
            List<string> table = follow.Item2;
            if (!followType.Equals("TABLE"))
            {
                Error("Error table does not follow data " + words[0] + " " + words[1]);
                return;
            }
            if (dataNames.ContainsKey(className))
            {
                className += stepCount;
                Warning("Data name is duplicated, has been renamed " + className);
            }
            Trace("Creating class for " + className);
            dataNames[className] = "";
            StartDataFile(className, false);

            DataPrintLn($"namespace {packagePath} {{");
            foreach (string line in linesToAddForDataAndGlue)
            {
                DataPrintLn(line);
            }
            DataPrintLn($"public class {className} {{");
            List<DataValues> variables = new List<DataValues>();
            bool doInternal = CreateVariableList(table, variables);
            foreach (var variable in variables)
            {
                classDataNames.Add(className + "#" + variable.Name);
                DataPrintLn($"    public string {MakeName(variable.Name)} = \"{variable.DefaultVal}\";");
            }
            CreateConstructor(variables, className);
            CreateEqualsMethod(variables, className);
            CreateBuilderMethod(variables, className);
            CreateToStringMethod(variables, className);
            CreateToJSONMethod(variables);
            CreateFromJSONMethod(variables, className);
            CreateTableToJSONMethod(className);
            CreateJSONToTableMethod(className);
            if (doInternal)
            {
                dataNamesInternal[internalClassName] = "";
                CreateConversionMethod(internalClassName, variables);
            }
            DataPrintLn("    }");
            EndDataFile();

            if (doInternal)
            {
                CreateInternalClass(internalClassName, className, variables, providedOtherClassName);
            }
        }

        private void CreateJSONToTableMethod(string className)
        {
            string code =
                $"""
                    public static List<{className}> ListFromJson(string json)
                    {{List <{className}> list = new List<{className}>();
                        json = json.Replace("\\s", "");
                        json = json.Replace("[","").Replace("]","");
                        string[] jsonObjects = json.Split(new[] {{ "}},\\s*{{" }}, StringSplitOptions.None);
                        foreach (string jsonObject in jsonObjects)
                        {{list.Add({className}.FromJson(jsonObject));
                        }}
                        return list;
                    }}
                    """;
            DataPrintLn(code);
        }

        private void CreateTableToJSONMethod(string className)
        {
            string code =
                $"""
                    public static string ListToJson(List<{className}> list)
                    {{StringBuilder jsonBuilder = new StringBuilder();
                        jsonBuilder.Append("[");
                        
                        for (int i = 0; i < list.Count; i++)
                        {{jsonBuilder.Append(list[i].ToJson());
                            if (i < list.Count - 1)
                            {{
                                jsonBuilder.Append(",");
                            }
                        }}
                        
                        jsonBuilder.Append("]");
                        return jsonBuilder.ToString();
                    }}
                    """;
            DataPrintLn(code);
        }

        private void EndDataFile()
        {
            try
            {
                dataDefinitionFile.Close();
            }
            catch (IOException e)
            {
                throw new Exception(e.Message, e);
            }
        }

        private void StartDataFile(string className, bool createTmpl)
        {
            string extension = Configuration.DataDefinitionFileExtension;
            if (createTmpl)
                extension = "tmpl";
            string dataDefinitionPathname = Configuration.TestSubDirectory + featureDirectory +
                    featureName + "/" + className + "." + extension;
            try
            {
                dataDefinitionFile = new StreamWriter(dataDefinitionPathname, false);
            }
            catch (IOException e)
            {
                Error("IO Exception in setting up the files");
                Error(" Writing " + dataDefinitionPathname);
            }
        }

        private void CreateConstructor(List<DataValues> variables, string className)
        {
            DataPrintLn($"    public {className}() {{ }}");
            DataPrintLn($"    public {className}(");
            string comma = "";
            foreach (var variable in variables)
            {
                DataPrintLn($"        {comma}string {MakeName(variable.Name)}");
                comma = ",";
            }
            DataPrintLn("        ){");
            foreach (var variable in variables)
            {
                DataPrintLn($"        this.{MakeName(variable.Name)} = {MakeName(variable.Name)};");
            }
            DataPrintLn("        }");
        }

        private void CreateInternalConstructor(List<DataValues> variables, string className)
        {
            DataPrintLn($"    public {className}(");
            string comma = "";
            foreach (var variable in variables)
            {
                DataPrintLn($"        {comma}{variable.DataType} {MakeName(variable.Name)}");
                comma = ",";
            }
            DataPrintLn("        ) {");
            foreach (var variable in variables)
            {
                DataPrintLn($"        this.{MakeName(variable.Name)} = {variable.Name};");
            }
            DataPrintLn("        }");
        }

        private void CreateToStringMethod(List<DataValues> variables, string className)
        {
            var code = new System.Text.StringBuilder();
            string firstPart =
                $"""
                    public override string ToString()
                    {{
                            return "{className} {{"
                    """;
            code.Append(firstPart);

            foreach (var variable in variables)
            {
                string middlePart =
                    $"""
                        +" {variable.Name} = " + {variable.Name} + " "
                        """;
                code.Append(middlePart);
            }
            string endPart =
                """  
                    + "} " ; }
                    """;
            if (Configuration.AddLineToString)
                endPart =
                    """  
                        + "} " + "\\n"; }
                        """;
            code.Append(endPart);
            DataPrintLn(code.ToString());
        }

        private void CreateFromJSONMethod(List<DataValues> variables, string className)
        {
            string firstPart =
                $"""
                    public static {className} FromJson(string json)
                    {{
                            {className} instance = new {className}();
                        
                        json = json.Replace("\\s", "");
                        string[] keyValuePairs = json.Replace("{{", "").Replace("}}", "").Split(',');
                        
                        foreach (string pair in keyValuePairs)
                        {{string[] entry = pair.Split(':');
                            string key = entry[0].Replace("\"", "").Trim();
                            string value = entry[1].Replace("\"", "").Trim();
                            
                            switch (key)
                            {{


                """;
            var middlePart = new System.Text.StringBuilder();
            foreach (var variable in variables)
            {
                string start =
                    $"""
                        case "{variable.Name}":
                            instance.{variable.Name} = value;
                            break;
                        """;
                middlePart.Append(start);
            }

            string lastPart =
                """
                    default:
                        Console.Error.WriteLine("Invalid JSON element " + key);
                    }
                }
                return instance;
            }
            """;
            DataPrintLn(firstPart + middlePart + lastPart);
        }

        private void CreateToJSONMethod(List<DataValues> variables)
        {
            var code = new System.Text.StringBuilder();
            string firstPart =
                """
                    public string ToJson()
                    {
                        return " {"
                    """;
            code.Append(firstPart);
            string comma = "";
            foreach (var variable in variables)
            {
                string middlePart =
                    $"""
                        {comma}+"{variable.Name}: " + "\"" + {variable.Name} + "\""
                        """;
                code.Append(middlePart);
                comma = "         + \",\"";
            }
            string lastPart =
                """
                    + "} " ; }             
                    """;
            code.Append(lastPart);
            DataPrintLn(code.ToString());
        }

        private void CreateBuilderMethod(List<DataValues> variables, string className)
        {
            DataPrintLn("    public class Builder {");
            foreach (var variable in variables)
            {
                DataPrintLn($"        private string {variable.Name} = {QuoteIt(variable.DefaultVal)};");
            }
            foreach (var variable in variables)
            {
                DataPrintLn($"        public Builder {MakeBuildName(variable.Name)}(string {variable.Name}) {{");
                DataPrintLn($"            this.{variable.Name} = {variable.Name};");
                DataPrintLn("            return this;");
                DataPrintLn("            }");
            }
            DataPrintLn("        public Builder SetCompare() {");
            foreach (var variable in variables)
            {
                DataPrintLn($"            {variable.Name} = {QuoteIt(Configuration.DoNotCompare)};");
            }
            DataPrintLn("            return this;");
            DataPrintLn("            }");

            DataPrintLn($"        public {className} Build(){{");
            DataPrintLn($"             return new {className}(");
            string comma = "";
            foreach (var variable in variables)
            {
                DataPrintLn($"                 {comma}{variable.Name}");
                comma = ",";
            }
            DataPrintLn("                );   } ");
            DataPrintLn("        } ");
        }

        private void CreateEqualsMethod(List<DataValues> variables, string className)
        {
            DataPrintLn("    public override bool Equals(object o) {");
            DataPrintLn("        if (this == o) return true;");
            DataPrintLn("        if (o == null || GetType() != o.GetType()) return false;");

            string variableName = "_" + className;
            DataPrintLn($"        {className} {variableName} = ({className}) o;");
            DataPrintLn("        bool result = true;");
            foreach (var variable in variables)
            {
                DataPrintLn("        if (");
                DataPrintLn($"            !this.{variable.Name}.Equals({QuoteIt(Configuration.DoNotCompare)})");
                DataPrintLn($"            && !{variableName}.{variable.Name}.Equals({QuoteIt(Configuration.DoNotCompare)}))");
                DataPrintLn($"        if (!{variableName}.{variable.Name}.Equals(this.{variable.Name})) result = false;");
            }
            DataPrintLn("        return result;  }");
        }

        private void CreateConversionMethod(string internalClassName, List<DataValues> variables)
        {
            DataPrintLn($"    public {internalClassName} To{internalClassName}() {throwString}{{");
            DataPrintLn($"        return new {internalClassName}(");
            string comma = "";
            foreach (var variable in variables)
            {
                string initializer = MakeValueFromString(variable, true);
                DataPrintLn($"        {comma} {initializer}");
                comma = ",";
            }
            DataPrintLn("        ); }");
        }

        private bool CreateVariableList(List<string> table, List<DataValues> variables)
        {
            bool headerLine = true;
            bool doInternal = false;
            foreach (string line in table)
            {
                if (headerLine)
                {
                    List<string> headers = ParseLine(line);
                    CheckHeaders(headers);
                    headerLine = false;

                    if (headers.Count > 2) doInternal = true;
                    continue;
                }
                List<string> elements = ParseLine(line);
                if (elements.Count < 2)
                {
                    Error(" Data line has less than 2 entries " + line);
                    continue;
                }
                if (elements.Count > 3)
                    variables.Add(new DataValues(MakeName(elements[0]), elements[1], AlterDataType(elements[2]), elements[3]));
                else if (elements.Count > 2)
                    variables.Add(new DataValues(MakeName(elements[0]), elements[1], AlterDataType(elements[2])));
                else
                    variables.Add(new DataValues(MakeName(elements[0]), elements[1]));
            }
            return doInternal;
        }

        private string AlterDataType(string s)
        {
            switch (s)
            {
                case "Int":
                    return "int";
                case "Char":
                    return "char";
                default:
                    return s;
            }
        }

        private void CheckHeaders(List<string> headers)
        {
            List<string> expected = new List<string> { "Name", "Default", "Datatype", "Notes" };
            if (!(headers[0].Equals(expected[0]) && headers[1].Equals(expected[1])))
            {
                Error("Headers should start with " + string.Join(", ", expected));
            }
        }

        private void CreateInternalClass(string className, string otherClassName, List<DataValues> variables, bool providedClassName)
        {
            string classNameInternal = className;
            if (dataNames.ContainsKey(classNameInternal))
            {
                classNameInternal += stepCount;
                Warning("Data name is duplicated, has been renamed " + classNameInternal);
            }
            Trace("Creating internal class for " + classNameInternal);
            dataNames[classNameInternal] = "";
            StartDataFile(className, providedClassName);
            DataPrintLn($"namespace {packagePath} {{");
            foreach (string line in linesToAddForDataAndGlue)
            {
                DataPrintLn(line);
            }
            DataPrintLn($"public class {className} {{");
            foreach (var variable in variables)
            {
                DataPrintLn($"    public {variable.DataType} {MakeName(variable.Name)};");
            }
            DataPrintLn("     ");
            CreateDataTypeToStringObject(className, variables);
            CreateToStringObject(otherClassName, variables);
            CreateInternalConstructor(variables, className);
            CreateInternalEqualsMethod(variables, className);
            CreateToStringMethod(variables, className);

            DataPrintLn("    }");
            EndDataFile();
        }

        private void CreateInternalEqualsMethod(List<DataValues> variables, string className)
        {
            DataPrintLn("    public override bool Equals(object o) {");
            DataPrintLn("        if (this == o) return true;");
            DataPrintLn("        if (o == null || GetType() != o.GetType()) return false;");

            string variableName = "_" + className;
            DataPrintLn($"        {className} {variableName} = ({className}) o;");
            DataPrintLn("        return ");
            string and = "";
            foreach (var variable in variables)
            {
                string comparison = ".Equals";
                if (PrimitiveDataType(variable))
                    comparison = " == ";
                DataPrintLn($"            {and}({variableName}.{variable.Name}{comparison}(this.{variable.Name}))");
                and = " && ";
            }
            DataPrintLn("        ;  }");
        }

        private bool PrimitiveDataType(DataValues variable)
        {
            return variable.DataType == "bool"
                || variable.DataType == "char"
                || variable.DataType == "int"
                || variable.DataType == "float"
                || variable.DataType == "double"
                || variable.DataType == "long"
                || variable.DataType == "byte"
                || variable.DataType == "short";
        }

        private void CreateDataTypeToStringObject(string className, List<DataValues> variables)
        {
            DataPrintLn("    public static string ToDataTypeString() {");
            DataPrintLn($"        return {QuoteIt(className + " {{")}");
            string add = "+";
            string space = " ";
            foreach (var variable in variables)
            {
                DataPrintLn($"        {add}{QuoteIt(variable.DataType + space)} ");
            }
            DataPrintLn($"        + {QuoteIt("}} ")}; }}");
        }

        private void CreateToStringObject(string otherClassName, List<DataValues> variables)
        {
            DataPrintLn($"    public {otherClassName} To{otherClassName}() {{");
            DataPrintLn($"        return new {otherClassName}(");
            string comma = "";
            foreach (var variable in variables)
            {
                string method = MakeValueToString(variable, true);
                DataPrintLn($"        {comma}{method}");
                comma = ",";
            }
            DataPrintLn("        ); }");
        }

        private string MakeValueToString(DataValues variable, bool makeNameValue)
        {
            string value = makeNameValue ? MakeName(variable.Name) : QuoteIt(variable.DefaultVal);
            switch (variable.DataType)
            {
                case "string":
                    return value;
                case "int":
                case "double":
                case "byte":
                case "short":
                case "long":
                case "float":
                case "bool":
                case "char":
                case "Byte":
                case "Short":
                case "Integer":
                case "Long":
                case "Float":
                case "Double":
                case "Boolean":
                case "Character":
                    return $"Convert.ToString({value})";
                default:
                    return $"{value}.ToString()";
            }
        }

        private void DataPrintLn(string line)
        {
            try
            {
                dataDefinitionFile.WriteLine(line);
            }
            catch (IOException e)
            {
                Error("IO ERROR");
            }
        }


    }
             class ImportConstruct
            {
                public class ImportData
                {
                    public string DataType { get; }
                    public string ImportName { get; }
                    public string ConversionMethod { get; }
                    public string Notes { get; }

                    public ImportData(string dataType, string conversionMethod, string importName, string notes)
                    {
                        DataType = dataType;
                        ImportName = importName;
                        ConversionMethod = conversionMethod;
                        Notes = notes;
                    }

                    public ImportData(string dataType, string conversionMethod, string importName)
                        : this(dataType, conversionMethod, importName, "") { }

                    public ImportData(string dataType, string conversionMethod)
                        : this(dataType, conversionMethod, "", "") { }
                }

                private void ActOnImport(List<string> words)
                {
                    var follow = LookForFollow();
                    string followType = follow.Item1;
                    List<string> table = follow.Item2;
                    if (!followType.Equals("TABLE"))
                    {
                        Error("Error table does not follow import " + words[0] + " " + words[1]);
                        return;
                    }
                    List<ImportData> imports = new List<ImportData>();
                    CreateImportList(table, imports);
                    foreach (var im in imports)
                    {
                        if (importNames.ContainsKey(im.DataType))
                        {
                            Error("Data type is duplicated, has been renamed " + im.DataType);
                            continue;
                        }
                        if (!string.IsNullOrWhiteSpace(im.ConversionMethod))
                            importNames[im.DataType] = im.ConversionMethod;
                        else
                        {
                            string methodName = im.DataType + "($)";
                            importNames[im.DataType] = methodName;
                        }
                    }
                    foreach (var im in imports)
                    {
                        if (!string.IsNullOrWhiteSpace(im.ImportName))
                        {
                            string value = "using " + im.ImportName + ";";
                            linesToAddForDataAndGlue.Add(value);
                        }
                    }
                }

                private void CreateImportList(List<string> table, List<ImportData> variables)
                {
                    bool headerLine = true;
                    foreach (string line in table)
                    {
                        if (headerLine)
                        {
                            List<string> headers = ParseLine(line);
                            CheckHeaders(headers);
                            headerLine = false;
                            continue;
                        }
                        List<string> elements = ParseLine(line);
                        if (elements.Count < 2)
                        {
                            Error(" Data line has less than 2 entries " + line);
                            continue;
                        }
                        if (elements.Count > 3)
                            variables.Add(new ImportData(elements[0], elements[1], elements[2], elements[3]));
                        else if (elements.Count > 2)
                            variables.Add(new ImportData(elements[0], elements[1], elements[2]));
                        else
                            variables.Add(new ImportData(elements[0], elements[1]));
                    }
                }

                private void CheckHeaders(List<string> headers)
                {
                    List<string> expected = new List<string> { "Datatype", "ConversionMethod", "Import", "Notes" };
                    if (!(headers[0].Equals(expected[0]) && headers[1].Equals(expected[1])))
                    {
                        Error("Headers should start with " + string.Join(", ", expected));
                    }
                }
    }
            class DefineConstruct
            {
                public class DefineData
                {
                    public string Name { get; }
                    public string Value { get; }

                    public DefineData(string name, string value)
                    {
                        Name = name;
                        Value = value;
                    }

                    public override string ToString()
                    {
                        return $"name = {Name} value = {Value}";
                    }
                }

                private void ActOnDefine(List<string> words)
                {
                    var follow = LookForFollow();
                    string followType = follow.Item1;
                    List<string> table = follow.Item2;
                    if (!followType.Equals("TABLE"))
                    {
                        Error("Error table does not follow define " + words[0] + " " + words[1]);
                        return;
                    }
                    List<DefineData> defines = new List<DefineData>();
                    CreateDefineList(table, defines);
                    foreach (var im in defines)
                    {
                        if (defineNames.ContainsKey(im.Name))
                        {
                            Warning("Define is duplicated will be skipped " + im.Name + " = " + im.Value);
                            continue;
                        }
                        if (string.IsNullOrWhiteSpace(im.Value))
                        {
                            Warning("Empty value for define ");
                        }
                        defineNames[im.Name] = im.Value;
                    }
                }

                private void CreateDefineList(List<string> table, List<DefineData> variables)
                {
                    bool headerLine = true;
                    foreach (string line in table)
                    {
                        if (headerLine)
                        {
                            List<string> headers = ParseLine(line);
                            CheckHeaders(headers);
                            headerLine = false;
                            continue;
                        }
                        List<string> elements = ParseLine(line);
                        if (elements.Count < 2)
                        {
                            Error(" Data line has less than 2 entries " + line);
                        }
                        else
                        {
                            variables.Add(new DefineData(elements[0], elements[1]));
                        }
                    }
                }

                private void CheckHeaders(List<string> headers)
                {
                    List<string> expected = new List<string> { "Name", "Value", "Notes" };
                    if (!(headers[0].Equals(expected[0]) && headers[1].Equals(expected[1])))
                    {
                        Error("Headers should start with " + string.Join(", ", expected));
                    }
                }

    }
        public static class Configuration
        {
            public static bool LogIt { get; set; } = false;
            // Set to true for logging during the tests to log.txt

            public static bool InTest { get; set; } = false;
            // switch to true for development of Translator

            public static bool TraceOn { get; set; } = false;
            // Set to true to see trace

            public static readonly char SpaceCharacters = '~';
            // Will replace this character with space in tables

            public static readonly bool AddLineToString = true;
            // add a \n to the ToString method

            public static readonly string DoNotCompare = "?DNC?";
            // Value used for not comparing an attribute

            public static string CurrentDirectory { get; set; } = "";
            // To keep for testing and or setup issues

            public static readonly string FeatureSubDirectory = "src/test/java/";
            // where features are stored

            public static readonly string TreeDirectory = "features/";

            public static readonly string StartingFeatureDirectory = FeatureSubDirectory + TreeDirectory;
            // where the directory tree of features is to be found.

            public static bool SearchTree { get; set; } = false;
            // search the startingFeatureDirectory for feature files

            public static readonly string PackageName = "gherkinexecutor";
            // high level package in which the tests are placed

            public static readonly string TestSubDirectory = "src/test/java/" + PackageName + "/";
            // used to put the test files in the directory corresponding to the packageName.

            public static readonly string DataDefinitionFileExtension = "java"; // "tmpl";
                                                                                // change to tmpl if you are altering the data classes to avoid overwriting them

            public static readonly string TestFramework = "JUnit5";
            // Could be "JUnit4" or "TestNG"

            public static string AddToPackageName { get; set; } = "";
            // change to "test.java." for Eclipse

            public static readonly List<string> LinesToAddForDataAndGlue = new List<string>
        {
            "import java.util.*;" // as an example
        };

            public static readonly List<string> FeatureFiles = new List<string>
            {
                // "simple_test.feature", // Something to try out after setup
                // "full_test.feature.sav" // used for testing Translate
            };
        }
    }




