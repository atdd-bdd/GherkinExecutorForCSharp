namespace gherkinexecutor.Feature_Data_Types {
using System;
using System.Collections.Generic;
using System.Text;
public class AllTypes {
    public string anInt = "0";
    public string aDouble = "0.0";
    public string aChar = "x";
    public string achar = "y";
    public AllTypes() {}
    public AllTypes(
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
        AllTypes _AllTypes = (AllTypes) o;
        bool result = true;
        if (
            !this.anInt.Equals("?DNC?")
            && !_AllTypes.anInt.Equals("?DNC?"))
        if (!_AllTypes.anInt.Equals(this.anInt)) result = false;
        if (
            !this.aDouble.Equals("?DNC?")
            && !_AllTypes.aDouble.Equals("?DNC?"))
        if (!_AllTypes.aDouble.Equals(this.aDouble)) result = false;
        if (
            !this.aChar.Equals("?DNC?")
            && !_AllTypes.aChar.Equals("?DNC?"))
        if (!_AllTypes.aChar.Equals(this.aChar)) result = false;
        if (
            !this.achar.Equals("?DNC?")
            && !_AllTypes.achar.Equals("?DNC?"))
        if (!_AllTypes.achar.Equals(this.achar)) result = false;
        return result;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
      hashCode ^= anInt == null ? 0 : anInt.GetHashCode();
    hashCode ^= aDouble == null ? 0 : aDouble.GetHashCode();
    hashCode ^= aChar == null ? 0 : aChar.GetHashCode();
    hashCode ^= achar == null ? 0 : achar.GetHashCode();
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
        public AllTypes Build(){
             return new AllTypes(
                 anInt
                 ,aDouble
                 ,aChar
                 ,achar
                );   } 
        } 
public override string ToString()
{
        return "AllTypes {"+" anInt = " + anInt + " "+" aDouble = " + aDouble + " "+" aChar = " + aChar + " "+" achar = " + achar + " "+ "} " + "\\n"; }
public string ToJson()
{
    return " {"+"anInt: " + "\"" + anInt + "\""         + ","+"aDouble: " + "\"" + aDouble + "\""         + ","+"aChar: " + "\"" + aChar + "\""         + ","+"achar: " + "\"" + achar + "\""+ "} " ; }             
    public static AllTypes FromJson(string json)
    {
            AllTypes instance = new AllTypes();
        
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
public static string ListToJson(List<AllTypes> list)
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
public static List<AllTypes> ListFromJson(string json)
{List <AllTypes> list = new List<AllTypes>();
    json = json.Replace("\\s", "");
    json = json.Replace("[","").Replace("]","");
    string[] jsonObjects = json.Split(new[] { "},\\s*{" }, StringSplitOptions.None);
    foreach (string jsonObject in jsonObjects)
    {list.Add(AllTypes.FromJson(jsonObject));
    }
    return list;
}
public class AllTypesComparer : IEqualityComparer<AllTypes>
{
    public bool Equals(AllTypes? x, AllTypes? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(AllTypes obj)
        {
        return obj.GetHashCode(); 
        }
}
    public AllTypesInternal ToAllTypesInternal() {
        return new AllTypesInternal(
         int.Parse(anInt)
        , Double.Parse(aDouble)
        , ( aChar.Length > 0 ?aChar[0] : ' ')
        , ( achar.Length > 0 ?achar[0] : ' ')
        ); }
    }
}
