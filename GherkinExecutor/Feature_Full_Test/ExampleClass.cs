namespace gherkinexecutor.Feature_Full_Test {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
public class ExampleClass {
    public string fieldA = "y";
    public string fieldB = "x";
    public ExampleClass() {}
    public ExampleClass(
        string fieldA
        ,string fieldB
        ){
        this.fieldA = fieldA;
        this.fieldB = fieldB;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        ExampleClass _ExampleClass = (ExampleClass) o;
        bool result = true;
        if (
            !this.fieldA.Equals("?DNC?")
            && !_ExampleClass.fieldA.Equals("?DNC?"))
        if (!_ExampleClass.fieldA.Equals(this.fieldA)) result = false;
        if (
            !this.fieldB.Equals("?DNC?")
            && !_ExampleClass.fieldB.Equals("?DNC?"))
        if (!_ExampleClass.fieldB.Equals(this.fieldB)) result = false;
        return result;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
      hashCode ^= fieldA == null ? 0 : fieldA.GetHashCode();
    hashCode ^= fieldB == null ? 0 : fieldB.GetHashCode();
return hashCode;
}
    public class Builder {
        private string fieldA = "y";
        private string fieldB = "x";
        public Builder SetFieldA(string fieldA) {
            this.fieldA = fieldA;
            return this;
            }
        public Builder SetFieldB(string fieldB) {
            this.fieldB = fieldB;
            return this;
            }
        public Builder SetCompare() {
            fieldA = "?DNC?";
            fieldB = "?DNC?";
            return this;
            }
        public ExampleClass Build(){
             return new ExampleClass(
                 fieldA
                 ,fieldB
                );   } 
        } 
public override string ToString()
{
        return "ExampleClass {"+" fieldA = " + fieldA + " "+" fieldB = " + fieldB + " "+ "} " + Environment.NewLine; }
public string ToJson()
{
    return " {"+"fieldA: " + "\"" + fieldA + "\""         + ","+"fieldB: " + "\"" + fieldB + "\""+ "} " ; }             
    public static ExampleClass FromJson(string json)
    {
            ExampleClass instance = new ExampleClass();
        
        json = json.Replace("\\s", "");
        string[] keyValuePairs = json.Replace("{", "").Replace("}", "").Split(',');
        
        foreach (string pair in keyValuePairs)
        {string[] entry = pair.Split(':');
            string key = entry[0].Replace("\"", "").Trim();
            string value = entry[1].Replace("\"", "").Trim();
            
            switch (key)
            {

        case "fieldA":
             instance.fieldA = value;
             break;
        case "fieldB":
             instance.fieldB = value;
             break;
        default:
            Console.Error.WriteLine("Invalid JSON element " + key);
            break; 
        }
    }
    return instance;
}
public static string ListToJson(List<ExampleClass> list)
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
public static List<ExampleClass> ListFromJson(string json)
{List <ExampleClass> list = new List<ExampleClass>();
json = Regex.Replace(json, @"\s", "");
json = Regex.Replace(json, @"\[", "").Replace("]", "");
string[] jsonObjects = Regex.Split(json, @"(?<=\}),\s*(?=\{)");  
foreach (string jsonObject in jsonObjects)
    {
    list.Add(ExampleClass.FromJson(jsonObject));
    }
    return list;
}
public class ExampleClassComparer : IEqualityComparer<ExampleClass>
{
    public bool Equals(ExampleClass? x, ExampleClass? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(ExampleClass obj)
        {
        return obj.GetHashCode(); 
        }
}
    }
}
