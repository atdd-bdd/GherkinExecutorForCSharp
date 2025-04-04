namespace gherkinexecutor.Feature_Full_Test {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
public class SimpleClass {
    public string anInt = "0";
    public string aString = "Q";
    public SimpleClass() {}
    public SimpleClass(
        string anInt
        ,string aString
        ){
        this.anInt = anInt;
        this.aString = aString;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        SimpleClass _SimpleClass = (SimpleClass) o;
        bool result = true;
        if (
            !this.anInt.Equals("?DNC?")
            && !_SimpleClass.anInt.Equals("?DNC?"))
        if (!_SimpleClass.anInt.Equals(this.anInt)) result = false;
        if (
            !this.aString.Equals("?DNC?")
            && !_SimpleClass.aString.Equals("?DNC?"))
        if (!_SimpleClass.aString.Equals(this.aString)) result = false;
        return result;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
       hashCode ^= anInt.GetHashCode();
    hashCode ^= aString == null ? 0 : aString.GetHashCode();
return hashCode;
}
    public class Builder {
        private string anInt = "0";
        private string aString = "Q";
        public Builder SetAnInt(string anInt) {
            this.anInt = anInt;
            return this;
            }
        public Builder SetAString(string aString) {
            this.aString = aString;
            return this;
            }
        public Builder SetCompare() {
            anInt = "?DNC?";
            aString = "?DNC?";
            return this;
            }
        public SimpleClass Build(){
             return new SimpleClass(
                 anInt
                 ,aString
                );   } 
        } 
public override string ToString()
{
        return "SimpleClass {"+" anInt = " + anInt + " "+" aString = " + aString + " "+ "} " + Environment.NewLine; }
public string ToJson()
{
    return " {"+"anInt: " + "\"" + anInt + "\""         + ","+"aString: " + "\"" + aString + "\""+ "} " ; }             
    public static SimpleClass FromJson(string json)
    {
            SimpleClass instance = new SimpleClass();
        
        json = json.Replace("\\s", "");
        string[] keyValuePairs = json.Replace("{", "").Replace("}", "").Split(',');
        
        foreach (string pair in keyValuePairs)
        {string[] entry = pair.Split(':');
            string key = entry[0].Replace("\"", "").Trim();
            string value = entry[1].Replace("\"", "").Trim();
            
            switch (key)
            {

        case "anInt":
             instance.anInt = value;
             break;
        case "aString":
             instance.aString = value;
             break;
        default:
            Console.Error.WriteLine("Invalid JSON element " + key);
            break; 
        }
    }
    return instance;
}
public static string ListToJson(List<SimpleClass> list)
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
public static List<SimpleClass> ListFromJson(string json)
{List <SimpleClass> list = new List<SimpleClass>();
json = Regex.Replace(json, @"\s", "");
json = Regex.Replace(json, @"\[", "").Replace("]", "");
string[] jsonObjects = Regex.Split(json, @"(?<=\}),\s*(?=\{)");  
foreach (string jsonObject in jsonObjects)
    {
    list.Add(SimpleClass.FromJson(jsonObject));
    }
    return list;
}
public class SimpleClassComparer : IEqualityComparer<SimpleClass>
{
    public bool Equals(SimpleClass? x, SimpleClass? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(SimpleClass obj)
        {
        return obj.GetHashCode(); 
        }
}
    public SimpleClassInternal ToSimpleClassInternal() {
        return new SimpleClassInternal(
         int.Parse(anInt)
        , aString
        ); }
    }
}
