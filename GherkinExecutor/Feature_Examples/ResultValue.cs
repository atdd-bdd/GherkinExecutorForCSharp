namespace gherkinexecutor.Feature_Examples {
using System;
using System.Collections.Generic;
using System.Text;
public class ResultValue {
    public string sum = "";
    public ResultValue() {}
    public ResultValue(
        string sum
        ){
        this.sum = sum;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        ResultValue _ResultValue = (ResultValue) o;
        bool result = true;
        if (
            !this.sum.Equals("?DNC?")
            && !_ResultValue.sum.Equals("?DNC?"))
        if (!_ResultValue.sum.Equals(this.sum)) result = false;
        return result;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
      hashCode ^= sum == null ? 0 : sum.GetHashCode();
return hashCode;
}
    public class Builder {
        private string sum = "";
        public Builder SetSum(string sum) {
            this.sum = sum;
            return this;
            }
        public Builder SetCompare() {
            sum = "?DNC?";
            return this;
            }
        public ResultValue Build(){
             return new ResultValue(
                 sum
                );   } 
        } 
public override string ToString()
{
        return "ResultValue {"+" sum = " + sum + " "+ "} " + "\\n"; }
public string ToJson()
{
    return " {"+"sum: " + "\"" + sum + "\""+ "} " ; }             
    public static ResultValue FromJson(string json)
    {
            ResultValue instance = new ResultValue();
        
        json = json.Replace("\\s", "");
        string[] keyValuePairs = json.Replace("{", "").Replace("}", "").Split(',');
        
        foreach (string pair in keyValuePairs)
        {string[] entry = pair.Split(':');
            string key = entry[0].Replace("\"", "").Trim();
            string value = entry[1].Replace("\"", "").Trim();
            
            switch (key)
            {

        case "sum":
             instance.sum = value;
             break;
        default:
            Console.Error.WriteLine("Invalid JSON element " + key);
            break; 
        }
    }
    return instance;
}
public static string ListToJson(List<ResultValue> list)
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
public static List<ResultValue> ListFromJson(string json)
{List <ResultValue> list = new List<ResultValue>();
    json = json.Replace("\\s", "");
    json = json.Replace("[","").Replace("]","");
    string[] jsonObjects = json.Split(new[] { "},\\s*{" }, StringSplitOptions.None);
    foreach (string jsonObject in jsonObjects)
    {list.Add(ResultValue.FromJson(jsonObject));
    }
    return list;
}
public class ResultValueComparer : IEqualityComparer<ResultValue>
{
    public bool Equals(ResultValue? x, ResultValue? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(ResultValue obj)
        {
        return obj.GetHashCode(); 
        }
}
    public ResultValueInternal ToResultValueInternal() {
        return new ResultValueInternal(
         Int32.Parse(sum)
        ); }
    }
}
