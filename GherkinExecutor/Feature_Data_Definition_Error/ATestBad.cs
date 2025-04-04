namespace gherkinexecutor.Feature_Data_Definition_Error {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
public class ATestBad {
    public string anInt = "a";
    public string aString = " ";
    public string aDouble = "b";
    public ATestBad() {}
    public ATestBad(
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
        ATestBad _ATestBad = (ATestBad) o;
        bool result = true;
        if (
            !this.anInt.Equals("?DNC?")
            && !_ATestBad.anInt.Equals("?DNC?"))
        if (!_ATestBad.anInt.Equals(this.anInt)) result = false;
        if (
            !this.aString.Equals("?DNC?")
            && !_ATestBad.aString.Equals("?DNC?"))
        if (!_ATestBad.aString.Equals(this.aString)) result = false;
        if (
            !this.aDouble.Equals("?DNC?")
            && !_ATestBad.aDouble.Equals("?DNC?"))
        if (!_ATestBad.aDouble.Equals(this.aDouble)) result = false;
        return result;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
       hashCode ^= anInt.GetHashCode();
    hashCode ^= aString == null ? 0 : aString.GetHashCode();
    hashCode ^= aDouble == null ? 0 : aDouble.GetHashCode();
return hashCode;
}
    public class Builder {
        private string anInt = "a";
        private string aString = " ";
        private string aDouble = "b";
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
        public ATestBad Build(){
             return new ATestBad(
                 anInt
                 ,aString
                 ,aDouble
                );   } 
        } 
public override string ToString()
{
        return "ATestBad {"+" anInt = " + anInt + " "+" aString = " + aString + " "+" aDouble = " + aDouble + " "+ "} " + Environment.NewLine; }
public string ToJson()
{
    return " {"+"anInt: " + "\"" + anInt + "\""         + ","+"aString: " + "\"" + aString + "\""         + ","+"aDouble: " + "\"" + aDouble + "\""+ "} " ; }             
    public static ATestBad FromJson(string json)
    {
            ATestBad instance = new ATestBad();
        
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
public static string ListToJson(List<ATestBad> list)
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
public static List<ATestBad> ListFromJson(string json)
{List <ATestBad> list = new List<ATestBad>();
json = Regex.Replace(json, @"\s", "");
json = Regex.Replace(json, @"\[", "").Replace("]", "");
string[] jsonObjects = Regex.Split(json, @"(?<=\}),\s*(?=\{)");  
foreach (string jsonObject in jsonObjects)
    {
    list.Add(ATestBad.FromJson(jsonObject));
    }
    return list;
}
public class ATestBadComparer : IEqualityComparer<ATestBad>
{
    public bool Equals(ATestBad? x, ATestBad? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(ATestBad obj)
        {
        return obj.GetHashCode(); 
        }
}
    public ATestBadInternal ToATestBadInternal() {
        return new ATestBadInternal(
         int.Parse(anInt)
        , aString
        , Double.Parse(aDouble)
        ); }
    }
}
