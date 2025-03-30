namespace gherkinexecutor.Feature_Import {
using System;
using System.Collections.Generic;
using System.Text;
using java.util.regex.Pattern;
using java.math.BigInteger;
public class ImportData {
    public string myPattern = "a.*";
    public string myWeekday = "MONDAY";
    public string myBigInt = "1";
    public ImportData() {}
    public ImportData(
        string myPattern
        ,string myWeekday
        ,string myBigInt
        ){
        this.myPattern = myPattern;
        this.myWeekday = myWeekday;
        this.myBigInt = myBigInt;
        }
    public override bool Equals(object o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        ImportData _ImportData = (ImportData) o;
        bool result = true;
        if (
            !this.myPattern.Equals("?DNC?")
            && !_ImportData.myPattern.Equals("?DNC?"))
        if (!_ImportData.myPattern.Equals(this.myPattern)) result = false;
        if (
            !this.myWeekday.Equals("?DNC?")
            && !_ImportData.myWeekday.Equals("?DNC?"))
        if (!_ImportData.myWeekday.Equals(this.myWeekday)) result = false;
        if (
            !this.myBigInt.Equals("?DNC?")
            && !_ImportData.myBigInt.Equals("?DNC?"))
        if (!_ImportData.myBigInt.Equals(this.myBigInt)) result = false;
        return result;  }
    public class Builder {
        private string myPattern = "a.*";
        private string myWeekday = "MONDAY";
        private string myBigInt = "1";
        public Builder SetMyPattern(string myPattern) {
            this.myPattern = myPattern;
            return this;
            }
        public Builder SetMyWeekday(string myWeekday) {
            this.myWeekday = myWeekday;
            return this;
            }
        public Builder SetMyBigInt(string myBigInt) {
            this.myBigInt = myBigInt;
            return this;
            }
        public Builder SetCompare() {
            myPattern = "?DNC?";
            myWeekday = "?DNC?";
            myBigInt = "?DNC?";
            return this;
            }
        public ImportData Build(){
             return new ImportData(
                 myPattern
                 ,myWeekday
                 ,myBigInt
                );   } 
        } 
public override string ToString()
{
        return "ImportData {"+" myPattern = " + myPattern + " "+" myWeekday = " + myWeekday + " "+" myBigInt = " + myBigInt + " "+ "} " + "\\n"; }
public string ToJson()
{
    return " {"+"myPattern: " + "\"" + myPattern + "\""         + ","+"myWeekday: " + "\"" + myWeekday + "\""         + ","+"myBigInt: " + "\"" + myBigInt + "\""+ "} " ; }             
    public static ImportData FromJson(string json)
    {
            ImportData instance = new ImportData();
        
        json = json.Replace("\\s", "");
        string[] keyValuePairs = json.Replace("{", "").Replace("}", "").Split(',');
        
        foreach (string pair in keyValuePairs)
        {string[] entry = pair.Split(':');
            string key = entry[0].Replace("\"", "").Trim();
            string value = entry[1].Replace("\"", "").Trim();
            
            switch (key)
            {

case "myPattern":
    instance.myPattern = value;
    break;case "myWeekday":
    instance.myWeekday = value;
    break;case "myBigInt":
    instance.myBigInt = value;
    break;        default:
            Console.Error.WriteLine("Invalid JSON element " + key);
            break; 
        }
    }
    return instance;
}
public static string ListToJson(List<ImportData> list)
{StringBuilder jsonBuilder = new StringBuilder();
    jsonBuilder.Append("[");
    
    for (int i = 0; i < list.Count; i++)
    {jsonBuilder.Append(list[i].ToJson());
        if (i < list.Count - 1)
        {
            jsonBuilder.Append(",");
        }
    }
    
    jsonBuilder.Append("]");
    return jsonBuilder.ToString();
}
public static List<ImportData> ListFromJson(string json)
{List <ImportData> list = new List<ImportData>();
    json = json.Replace("\\s", "");
    json = json.Replace("[","").Replace("]","");
    string[] jsonObjects = json.Split(new[] { "},\\s*{" }, StringSplitOptions.None);
    foreach (string jsonObject in jsonObjects)
    {list.Add(ImportData.FromJson(jsonObject));
    }
    return list;
}
    public ImportDataInternal ToImportDataInternal() {
        return new ImportDataInternal(
         Pattern.compile(myPattern)
        , Weekday.valueOf(myWeekday)
        , new BigInteger(myBigInt)
        ); }
    }
}
