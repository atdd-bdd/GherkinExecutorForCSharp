namespace gherkinexecutor.Feature_Full_Test {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
public class SomeTypes {
    public string anInt = "0";
    public string aDouble = "0.0";
    public string aChar = "x";
    public string achar = "y";
    public SomeTypes() {}
    public SomeTypes(
        string anInt
        ,string aDouble
        ,string aChar
        ,string achar
        ){
        this.anInt = anInt;
        this.aDouble = aDouble;
        this.aChar = aChar;
        this.achar = achar;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        SomeTypes _SomeTypes = (SomeTypes) o;
        bool result = true;
        if (
            !this.anInt.Equals("?DNC?")
            && !_SomeTypes.anInt.Equals("?DNC?"))
        if (!_SomeTypes.anInt.Equals(this.anInt)) result = false;
        if (
            !this.aDouble.Equals("?DNC?")
            && !_SomeTypes.aDouble.Equals("?DNC?"))
        if (!_SomeTypes.aDouble.Equals(this.aDouble)) result = false;
        if (
            !this.aChar.Equals("?DNC?")
            && !_SomeTypes.aChar.Equals("?DNC?"))
        if (!_SomeTypes.aChar.Equals(this.aChar)) result = false;
        if (
            !this.achar.Equals("?DNC?")
            && !_SomeTypes.achar.Equals("?DNC?"))
        if (!_SomeTypes.achar.Equals(this.achar)) result = false;
        return result;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
       hashCode ^= anInt.GetHashCode();
    hashCode ^= aDouble == null ? 0 : aDouble.GetHashCode();
     hashCode ^= aChar.GetHashCode();
     hashCode ^= achar.GetHashCode();
return hashCode;
}
    public class Builder {
        private string anInt = "0";
        private string aDouble = "0.0";
        private string aChar = "x";
        private string achar = "y";
        public Builder SetAnInt(string anInt) {
            this.anInt = anInt;
            return this;
            }
        public Builder SetADouble(string aDouble) {
            this.aDouble = aDouble;
            return this;
            }
        public Builder SetAChar(string aChar) {
            this.aChar = aChar;
            return this;
            }
        public Builder SetAchar(string achar) {
            this.achar = achar;
            return this;
            }
        public Builder SetCompare() {
            anInt = "?DNC?";
            aDouble = "?DNC?";
            aChar = "?DNC?";
            achar = "?DNC?";
            return this;
            }
        public SomeTypes Build(){
             return new SomeTypes(
                 anInt
                 ,aDouble
                 ,aChar
                 ,achar
                );   } 
        } 
public override string ToString()
{
        return "SomeTypes {"+" anInt = " + anInt + " "+" aDouble = " + aDouble + " "+" aChar = " + aChar + " "+" achar = " + achar + " "+ "} " + Environment.NewLine; }
public string ToJson()
{
    return " {"+"anInt: " + "\"" + anInt + "\""         + ","+"aDouble: " + "\"" + aDouble + "\""         + ","+"aChar: " + "\"" + aChar + "\""         + ","+"achar: " + "\"" + achar + "\""+ "} " ; }             
    public static SomeTypes FromJson(string json)
    {
            SomeTypes instance = new SomeTypes();
        
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
        case "aDouble":
             instance.aDouble = value;
             break;
        case "aChar":
             instance.aChar = value;
             break;
        case "achar":
             instance.achar = value;
             break;
        default:
            Console.Error.WriteLine("Invalid JSON element " + key);
            break; 
        }
    }
    return instance;
}
public static string ListToJson(List<SomeTypes> list)
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
public static List<SomeTypes> ListFromJson(string json)
{List <SomeTypes> list = new List<SomeTypes>();
json = Regex.Replace(json, @"\s", "");
json = Regex.Replace(json, @"\[", "").Replace("]", "");
string[] jsonObjects = Regex.Split(json, @"(?<=\}),\s*(?=\{)");  
foreach (string jsonObject in jsonObjects)
    {
    list.Add(SomeTypes.FromJson(jsonObject));
    }
    return list;
}
public class SomeTypesComparer : IEqualityComparer<SomeTypes>
{
    public bool Equals(SomeTypes? x, SomeTypes? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(SomeTypes obj)
        {
        return obj.GetHashCode(); 
        }
}
    public SomeTypesInternal ToSomeTypesInternal() {
        return new SomeTypesInternal(
         int.Parse(anInt)
        , Double.Parse(aDouble)
        , ( aChar.Length > 0 ?aChar[0] : ' ')
        , ( achar.Length > 0 ?achar[0] : ' ')
        ); }
    }
}
