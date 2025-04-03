namespace gherkinexecutor.Feature_Full_Test {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
public class FilterValue {
    public string value = "Q0000";
    public FilterValue() {}
    public FilterValue(
        string value
        ){
        this.value = value;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        FilterValue _FilterValue = (FilterValue) o;
        bool result = true;
        if (
            !this.value.Equals("?DNC?")
            && !_FilterValue.value.Equals("?DNC?"))
        if (!_FilterValue.value.Equals(this.value)) result = false;
        return result;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
      hashCode ^= value == null ? 0 : value.GetHashCode();
return hashCode;
}
    public class Builder {
        private string value = "Q0000";
        public Builder SetValue(string value) {
            this.value = value;
            return this;
            }
        public Builder SetCompare() {
            value = "?DNC?";
            return this;
            }
        public FilterValue Build(){
             return new FilterValue(
                 value
                );   } 
        } 
public override string ToString()
{
        return "FilterValue {"+" value = " + value + " "+ "} " + Environment.NewLine; }
public string ToJson()
{
    return " {"+"value: " + "\"" + value + "\""+ "} " ; }             
    public static FilterValue FromJson(string json)
    {
            FilterValue instance = new FilterValue();
        
        json = json.Replace("\\s", "");
        string[] keyValuePairs = json.Replace("{", "").Replace("}", "").Split(',');
        
        foreach (string pair in keyValuePairs)
        {string[] entry = pair.Split(':');
            string key = entry[0].Replace("\"", "").Trim();
            string value = entry[1].Replace("\"", "").Trim();
            
            switch (key)
            {

        case "value":
             instance.value = value;
             break;
        default:
            Console.Error.WriteLine("Invalid JSON element " + key);
            break; 
        }
    }
    return instance;
}
public static string ListToJson(List<FilterValue> list)
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
public static List<FilterValue> ListFromJson(string json)
{List <FilterValue> list = new List<FilterValue>();
json = Regex.Replace(json, @"\s", "");
json = Regex.Replace(json, @"\[", "").Replace("]", "");
string[] jsonObjects = Regex.Split(json, @"(?<=\}),\s*(?=\{)");  
foreach (string jsonObject in jsonObjects)
    {
    list.Add(FilterValue.FromJson(jsonObject));
    }
    return list;
}
public class FilterValueComparer : IEqualityComparer<FilterValue>
{
    public bool Equals(FilterValue? x, FilterValue? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(FilterValue obj)
        {
        return obj.GetHashCode(); 
        }
}
    public FilterValueInternal ToFilterValueInternal() {
        return new FilterValueInternal(
         new ID(value)
        ); }
    }
}
