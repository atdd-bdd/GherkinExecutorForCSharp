namespace gherkinexecutor.Feature_Full_Test {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
public class ATest0 {
    public string anInt = "0";
    public string aString = "^";
    public string aDouble = "1.2";
    public ATest0() {}
    public ATest0(
        string anInt
        ,string aString
        ,string aDouble
        ){
        this.anInt = anInt;
        this.aString = aString;
        this.aDouble = aDouble;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        ATest0 _ATest0 = (ATest0) o;
        bool result = true;
        if (
            !this.anInt.Equals("?DNC?")
            && !_ATest0.anInt.Equals("?DNC?"))
        if (!_ATest0.anInt.Equals(this.anInt)) result = false;
        if (
            !this.aString.Equals("?DNC?")
            && !_ATest0.aString.Equals("?DNC?"))
        if (!_ATest0.aString.Equals(this.aString)) result = false;
        if (
            !this.aDouble.Equals("?DNC?")
            && !_ATest0.aDouble.Equals("?DNC?"))
        if (!_ATest0.aDouble.Equals(this.aDouble)) result = false;
        return result;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
      hashCode ^= anInt == null ? 0 : anInt.GetHashCode();
    hashCode ^= aString == null ? 0 : aString.GetHashCode();
    hashCode ^= aDouble == null ? 0 : aDouble.GetHashCode();
return hashCode;
}
    public class Builder {
        private string anInt = "0";
        private string aString = "^";
        private string aDouble = "1.2";
        public Builder SetAnInt(string anInt) {
            this.anInt = anInt;
            return this;
            }
        public Builder SetAString(string aString) {
            this.aString = aString;
            return this;
            }
        public Builder SetADouble(string aDouble) {
            this.aDouble = aDouble;
            return this;
            }
        public Builder SetCompare() {
            anInt = "?DNC?";
            aString = "?DNC?";
            aDouble = "?DNC?";
            return this;
            }
        public ATest0 Build(){
             return new ATest0(
                 anInt
                 ,aString
                 ,aDouble
                );   } 
        } 
public override string ToString()
{
        return "ATest0 {"+" anInt = " + anInt + " "+" aString = " + aString + " "+" aDouble = " + aDouble + " "+ "} " + Environment.NewLine; }
public string ToJson()
{
    return " {"+"anInt: " + "\"" + anInt + "\""         + ","+"aString: " + "\"" + aString + "\""         + ","+"aDouble: " + "\"" + aDouble + "\""+ "} " ; }             
    public static ATest0 FromJson(string json)
    {
            ATest0 instance = new ATest0();
        
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
        case "aDouble":
             instance.aDouble = value;
             break;
        default:
            Console.Error.WriteLine("Invalid JSON element " + key);
            break; 
        }
    }
    return instance;
}
public static string ListToJson(List<ATest0> list)
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
public static List<ATest0> ListFromJson(string json)
{List <ATest0> list = new List<ATest0>();
json = Regex.Replace(json, @"\s", "");
json = Regex.Replace(json, @"\[", "").Replace("]", "");
string[] jsonObjects = Regex.Split(json, @"(?<=\}),\s*(?=\{)");  
foreach (string jsonObject in jsonObjects)
    {
    list.Add(ATest0.FromJson(jsonObject));
    }
    return list;
}
public class ATest0Comparer : IEqualityComparer<ATest0>
{
    public bool Equals(ATest0? x, ATest0? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(ATest0 obj)
        {
        return obj.GetHashCode(); 
        }
}
    public ATestInternal ToATestInternal() {
        return new ATestInternal(
         Int32.Parse(anInt)
        , aString
        , Double.Parse(aDouble)
        ); }
    }
}
