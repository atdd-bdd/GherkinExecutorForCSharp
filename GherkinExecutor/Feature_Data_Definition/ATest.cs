namespace gherkinexecutor.Feature_Data_Definition {
using System;
using System.Collections.Generic;
using System.Text;
public class ATest {
    public string anInt = "0";
    public string aString = " ";
    public string aDouble = "4.0";
    public ATest() {}
    public ATest(
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
        ATest _ATest = (ATest) o;
        bool result = true;
        if (
            !this.anInt.Equals("?DNC?")
            && !_ATest.anInt.Equals("?DNC?"))
        if (!_ATest.anInt.Equals(this.anInt)) result = false;
        if (
            !this.aString.Equals("?DNC?")
            && !_ATest.aString.Equals("?DNC?"))
        if (!_ATest.aString.Equals(this.aString)) result = false;
        if (
            !this.aDouble.Equals("?DNC?")
            && !_ATest.aDouble.Equals("?DNC?"))
        if (!_ATest.aDouble.Equals(this.aDouble)) result = false;
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
        private string aString = " ";
        private string aDouble = "4.0";
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
        public ATest Build(){
             return new ATest(
                 anInt
                 ,aString
                 ,aDouble
                );   } 
        } 
public override string ToString()
{
        return "ATest {"+" anInt = " + anInt + " "+" aString = " + aString + " "+" aDouble = " + aDouble + " "+ "} " + "\\n"; }
public string ToJson()
{
    return " {"+"anInt: " + "\"" + anInt + "\""         + ","+"aString: " + "\"" + aString + "\""         + ","+"aDouble: " + "\"" + aDouble + "\""+ "} " ; }             
    public static ATest FromJson(string json)
    {
            ATest instance = new ATest();
        
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
public static string ListToJson(List<ATest> list)
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
public static List<ATest> ListFromJson(string json)
{List <ATest> list = new List<ATest>();
    json = json.Replace("\\s", "");
    json = json.Replace("[","").Replace("]","");
    string[] jsonObjects = json.Split(new[] { "},\\s*{" }, StringSplitOptions.None);
    foreach (string jsonObject in jsonObjects)
    {list.Add(ATest.FromJson(jsonObject));
    }
    return list;
}
public class ATestComparer : IEqualityComparer<ATest>
{
    public bool Equals(ATest? x, ATest? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(ATest obj)
        {
        return obj.GetHashCode(); 
        }
}
    public ATestInternal ToATestInternal() {
        return new ATestInternal(
         int.Parse(anInt)
        , aString
        , Double.Parse(aDouble)
        ); }
    }
}
