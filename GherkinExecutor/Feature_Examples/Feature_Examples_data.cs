namespace gherkinexecutor.Feature_Examples {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
public class FandC {
    public string f = "0";
    public string c = "0";
    public string notes = "";
    public FandC() {}
    public FandC(
        string f
        ,string c
        ,string notes
        ){
        this.f = f;
        this.c = c;
        this.notes = notes;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        FandC _FandC = (FandC) o;
        bool result = true;
        if (
            !this.f.Equals("?DNC?")
            && !_FandC.f.Equals("?DNC?"))
        if (!_FandC.f.Equals(this.f)) result = false;
        if (
            !this.c.Equals("?DNC?")
            && !_FandC.c.Equals("?DNC?"))
        if (!_FandC.c.Equals(this.c)) result = false;
        if (
            !this.notes.Equals("?DNC?")
            && !_FandC.notes.Equals("?DNC?"))
        if (!_FandC.notes.Equals(this.notes)) result = false;
        return result;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
       hashCode ^= f.GetHashCode();
     hashCode ^= c.GetHashCode();
    hashCode ^= notes == null ? 0 : notes.GetHashCode();
return hashCode;
}
    public class Builder {
        private string f = "0";
        private string c = "0";
        private string notes = "";
        public Builder SetF(string f) {
            this.f = f;
            return this;
            }
        public Builder SetC(string c) {
            this.c = c;
            return this;
            }
        public Builder SetNotes(string notes) {
            this.notes = notes;
            return this;
            }
        public Builder SetCompare() {
            f = "?DNC?";
            c = "?DNC?";
            notes = "?DNC?";
            return this;
            }
        public FandC Build(){
             return new FandC(
                 f
                 ,c
                 ,notes
                );   } 
        } 
public override string ToString()
{
        return "FandC {"+" f = " + f + " "+" c = " + c + " "+" notes = " + notes + " "+ "} " + Environment.NewLine; }
public string ToJson()
{
    return " {"+"f: " + "\"" + f + "\""         + ","+"c: " + "\"" + c + "\""         + ","+"notes: " + "\"" + notes + "\""+ "} " ; }             
    public static FandC FromJson(string json)
    {
            FandC instance = new FandC();
        
        json = json.Replace("\\s", "");
        string[] keyValuePairs = json.Replace("{", "").Replace("}", "").Split(',');
        
        foreach (string pair in keyValuePairs)
        {string[] entry = pair.Split(':');
            string key = entry[0].Replace("\"", "").Trim();
            string value = entry[1].Replace("\"", "").Trim();
            
            switch (key)
            {

        case "f":
             instance.f = value;
             break;
        case "c":
             instance.c = value;
             break;
        case "notes":
             instance.notes = value;
             break;
        default:
            Console.Error.WriteLine("Invalid JSON element " + key);
            break; 
        }
    }
    return instance;
}
public static string ListToJson(List<FandC> list)
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
public static List<FandC> ListFromJson(string json)
{List <FandC> list = new List<FandC>();
json = Regex.Replace(json, @"\s", "");
json = Regex.Replace(json, @"\[", "").Replace("]", "");
string[] jsonObjects = Regex.Split(json, @"(?<=\}),\s*(?=\{)");  
foreach (string jsonObject in jsonObjects)
    {
    list.Add(FandC.FromJson(jsonObject));
    }
    return list;
}
public class FandCComparer : IEqualityComparer<FandC>
{
    public bool Equals(FandC? x, FandC? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(FandC obj)
        {
        return obj.GetHashCode(); 
        }
}
    public FandCInternal ToFandCInternal() {
        return new FandCInternal(
         int.Parse(f)
        , int.Parse(c)
        , notes
        ); }
    }
}
namespace gherkinexecutor.Feature_Examples {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
public class FandCInternal {
    public int f;
    public int c;
    public String notes;
     
    public static string ToDataTypeString() {
        return "FandCInternal {{"
        +"int " 
        +"int " 
        +"String " 
        + "} "; }
    public FandC ToFandC() {
        return new FandC(
        Convert.ToString(f)
        ,Convert.ToString(c)
        ,notes.ToString()
        ); }
    public FandCInternal(
        int f
        ,int c
        ,String notes
        ) {
        this.f = f;
        this.c = c;
        this.notes = notes;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        FandCInternal _FandCInternal = (FandCInternal) o;
        return 
            (_FandCInternal.f == (this.f))
             && (_FandCInternal.c == (this.c))
             && (_FandCInternal.notes.Equals(this.notes))
        ;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
       hashCode ^= f.GetHashCode();
     hashCode ^= c.GetHashCode();
    hashCode ^= notes == null ? 0 : notes.GetHashCode();
return hashCode;
}
public override string ToString()
{
        return "FandCInternal {"+" f = " + f + " "+" c = " + c + " "+" notes = " + notes + " "+ "} " + Environment.NewLine; }
public class FandCInternalComparer : IEqualityComparer<FandCInternal>
{
    public bool Equals(FandCInternal? x, FandCInternal? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(FandCInternal obj)
        {
        return obj.GetHashCode(); 
        }
}
    }
}
namespace gherkinexecutor.Feature_Examples {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
public class ValueValid {
    public string value = "0";
    public string valid = "false";
    public string notes = "";
    public ValueValid() {}
    public ValueValid(
        string value
        ,string valid
        ,string notes
        ){
        this.value = value;
        this.valid = valid;
        this.notes = notes;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        ValueValid _ValueValid = (ValueValid) o;
        bool result = true;
        if (
            !this.value.Equals("?DNC?")
            && !_ValueValid.value.Equals("?DNC?"))
        if (!_ValueValid.value.Equals(this.value)) result = false;
        if (
            !this.valid.Equals("?DNC?")
            && !_ValueValid.valid.Equals("?DNC?"))
        if (!_ValueValid.valid.Equals(this.valid)) result = false;
        if (
            !this.notes.Equals("?DNC?")
            && !_ValueValid.notes.Equals("?DNC?"))
        if (!_ValueValid.notes.Equals(this.notes)) result = false;
        return result;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
      hashCode ^= value == null ? 0 : value.GetHashCode();
    hashCode ^= valid == null ? 0 : valid.GetHashCode();
    hashCode ^= notes == null ? 0 : notes.GetHashCode();
return hashCode;
}
    public class Builder {
        private string value = "0";
        private string valid = "false";
        private string notes = "";
        public Builder SetValue(string value) {
            this.value = value;
            return this;
            }
        public Builder SetValid(string valid) {
            this.valid = valid;
            return this;
            }
        public Builder SetNotes(string notes) {
            this.notes = notes;
            return this;
            }
        public Builder SetCompare() {
            value = "?DNC?";
            valid = "?DNC?";
            notes = "?DNC?";
            return this;
            }
        public ValueValid Build(){
             return new ValueValid(
                 value
                 ,valid
                 ,notes
                );   } 
        } 
public override string ToString()
{
        return "ValueValid {"+" value = " + value + " "+" valid = " + valid + " "+" notes = " + notes + " "+ "} " + Environment.NewLine; }
public string ToJson()
{
    return " {"+"value: " + "\"" + value + "\""         + ","+"valid: " + "\"" + valid + "\""         + ","+"notes: " + "\"" + notes + "\""+ "} " ; }             
    public static ValueValid FromJson(string json)
    {
            ValueValid instance = new ValueValid();
        
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
        case "valid":
             instance.valid = value;
             break;
        case "notes":
             instance.notes = value;
             break;
        default:
            Console.Error.WriteLine("Invalid JSON element " + key);
            break; 
        }
    }
    return instance;
}
public static string ListToJson(List<ValueValid> list)
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
public static List<ValueValid> ListFromJson(string json)
{List <ValueValid> list = new List<ValueValid>();
json = Regex.Replace(json, @"\s", "");
json = Regex.Replace(json, @"\[", "").Replace("]", "");
string[] jsonObjects = Regex.Split(json, @"(?<=\}),\s*(?=\{)");  
foreach (string jsonObject in jsonObjects)
    {
    list.Add(ValueValid.FromJson(jsonObject));
    }
    return list;
}
public class ValueValidComparer : IEqualityComparer<ValueValid>
{
    public bool Equals(ValueValid? x, ValueValid? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(ValueValid obj)
        {
        return obj.GetHashCode(); 
        }
}
    public ValueValidInternal ToValueValidInternal() {
        return new ValueValidInternal(
         value
        , Boolean.Parse(valid)
        , notes
        ); }
    }
}
namespace gherkinexecutor.Feature_Examples {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
public class ValueValidInternal {
    public String value;
    public Boolean valid;
    public String notes;
     
    public static string ToDataTypeString() {
        return "ValueValidInternal {{"
        +"String " 
        +"Boolean " 
        +"String " 
        + "} "; }
    public ValueValid ToValueValid() {
        return new ValueValid(
        value.ToString()
        ,Convert.ToString(valid)
        ,notes.ToString()
        ); }
    public ValueValidInternal(
        String value
        ,Boolean valid
        ,String notes
        ) {
        this.value = value;
        this.valid = valid;
        this.notes = notes;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        ValueValidInternal _ValueValidInternal = (ValueValidInternal) o;
        return 
            (_ValueValidInternal.value.Equals(this.value))
             && (_ValueValidInternal.valid.Equals(this.valid))
             && (_ValueValidInternal.notes.Equals(this.notes))
        ;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
      hashCode ^= value == null ? 0 : value.GetHashCode();
    hashCode ^= valid == null ? 0 : valid.GetHashCode();
    hashCode ^= notes == null ? 0 : notes.GetHashCode();
return hashCode;
}
public override string ToString()
{
        return "ValueValidInternal {"+" value = " + value + " "+" valid = " + valid + " "+" notes = " + notes + " "+ "} " + Environment.NewLine; }
public class ValueValidInternalComparer : IEqualityComparer<ValueValidInternal>
{
    public bool Equals(ValueValidInternal? x, ValueValidInternal? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(ValueValidInternal obj)
        {
        return obj.GetHashCode(); 
        }
}
    }
}
namespace gherkinexecutor.Feature_Examples {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
namespace gherkinexecutor.Feature_Examples {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
public class FilterValueInternal {
    public ID value;
     
    public static string ToDataTypeString() {
        return "FilterValueInternal {{"
        +"ID " 
        + "} "; }
    public FilterValue ToFilterValue() {
        return new FilterValue(
        value.ToString()
        ); }
    public FilterValueInternal(
        ID value
        ) {
        this.value = value;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        FilterValueInternal _FilterValueInternal = (FilterValueInternal) o;
        return 
            (_FilterValueInternal.value.Equals(this.value))
        ;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
      hashCode ^= value == null ? 0 : value.GetHashCode();
return hashCode;
}
public override string ToString()
{
        return "FilterValueInternal {"+" value = " + value + " "+ "} " + Environment.NewLine; }
public class FilterValueInternalComparer : IEqualityComparer<FilterValueInternal>
{
    public bool Equals(FilterValueInternal? x, FilterValueInternal? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(FilterValueInternal obj)
        {
        return obj.GetHashCode(); 
        }
}
    }
}
namespace gherkinexecutor.Feature_Examples {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
       hashCode ^= sum.GetHashCode();
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
        return "ResultValue {"+" sum = " + sum + " "+ "} " + Environment.NewLine; }
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
json = Regex.Replace(json, @"\s", "");
json = Regex.Replace(json, @"\[", "").Replace("]", "");
string[] jsonObjects = Regex.Split(json, @"(?<=\}),\s*(?=\{)");  
foreach (string jsonObject in jsonObjects)
    {
    list.Add(ResultValue.FromJson(jsonObject));
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
         int.Parse(sum)
        ); }
    }
}
namespace gherkinexecutor.Feature_Examples {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
public class ResultValueInternal {
    public int sum;
     
    public static string ToDataTypeString() {
        return "ResultValueInternal {{"
        +"int " 
        + "} "; }
    public ResultValue ToResultValue() {
        return new ResultValue(
        Convert.ToString(sum)
        ); }
    public ResultValueInternal(
        int sum
        ) {
        this.sum = sum;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        ResultValueInternal _ResultValueInternal = (ResultValueInternal) o;
        return 
            (_ResultValueInternal.sum == (this.sum))
        ;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
       hashCode ^= sum.GetHashCode();
return hashCode;
}
public override string ToString()
{
        return "ResultValueInternal {"+" sum = " + sum + " "+ "} " + Environment.NewLine; }
public class ResultValueInternalComparer : IEqualityComparer<ResultValueInternal>
{
    public bool Equals(ResultValueInternal? x, ResultValueInternal? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(ResultValueInternal obj)
        {
        return obj.GetHashCode(); 
        }
}
    }
}
namespace gherkinexecutor.Feature_Examples {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
public class LabelValue {
    public string iD = "";
    public string value = "0";
    public LabelValue() {}
    public LabelValue(
        string iD
        ,string value
        ){
        this.iD = iD;
        this.value = value;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        LabelValue _LabelValue = (LabelValue) o;
        bool result = true;
        if (
            !this.iD.Equals("?DNC?")
            && !_LabelValue.iD.Equals("?DNC?"))
        if (!_LabelValue.iD.Equals(this.iD)) result = false;
        if (
            !this.value.Equals("?DNC?")
            && !_LabelValue.value.Equals("?DNC?"))
        if (!_LabelValue.value.Equals(this.value)) result = false;
        return result;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
      hashCode ^= iD == null ? 0 : iD.GetHashCode();
     hashCode ^= value.GetHashCode();
return hashCode;
}
    public class Builder {
        private string iD = "";
        private string value = "0";
        public Builder SetID(string iD) {
            this.iD = iD;
            return this;
            }
        public Builder SetValue(string value) {
            this.value = value;
            return this;
            }
        public Builder SetCompare() {
            iD = "?DNC?";
            value = "?DNC?";
            return this;
            }
        public LabelValue Build(){
             return new LabelValue(
                 iD
                 ,value
                );   } 
        } 
public override string ToString()
{
        return "LabelValue {"+" iD = " + iD + " "+" value = " + value + " "+ "} " + Environment.NewLine; }
public string ToJson()
{
    return " {"+"iD: " + "\"" + iD + "\""         + ","+"value: " + "\"" + value + "\""+ "} " ; }             
    public static LabelValue FromJson(string json)
    {
            LabelValue instance = new LabelValue();
        
        json = json.Replace("\\s", "");
        string[] keyValuePairs = json.Replace("{", "").Replace("}", "").Split(',');
        
        foreach (string pair in keyValuePairs)
        {string[] entry = pair.Split(':');
            string key = entry[0].Replace("\"", "").Trim();
            string value = entry[1].Replace("\"", "").Trim();
            
            switch (key)
            {

        case "iD":
             instance.iD = value;
             break;
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
public static string ListToJson(List<LabelValue> list)
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
public static List<LabelValue> ListFromJson(string json)
{List <LabelValue> list = new List<LabelValue>();
json = Regex.Replace(json, @"\s", "");
json = Regex.Replace(json, @"\[", "").Replace("]", "");
string[] jsonObjects = Regex.Split(json, @"(?<=\}),\s*(?=\{)");  
foreach (string jsonObject in jsonObjects)
    {
    list.Add(LabelValue.FromJson(jsonObject));
    }
    return list;
}
public class LabelValueComparer : IEqualityComparer<LabelValue>
{
    public bool Equals(LabelValue? x, LabelValue? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(LabelValue obj)
        {
        return obj.GetHashCode(); 
        }
}
    public LabelValueInternal ToLabelValueInternal() {
        return new LabelValueInternal(
         new ID(iD)
        , int.Parse(value)
        ); }
    }
}
namespace gherkinexecutor.Feature_Examples {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
public class LabelValueInternal {
    public ID iD;
    public int value;
     
    public static string ToDataTypeString() {
        return "LabelValueInternal {{"
        +"ID " 
        +"int " 
        + "} "; }
    public LabelValue ToLabelValue() {
        return new LabelValue(
        iD.ToString()
        ,Convert.ToString(value)
        ); }
    public LabelValueInternal(
        ID iD
        ,int value
        ) {
        this.iD = iD;
        this.value = value;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        LabelValueInternal _LabelValueInternal = (LabelValueInternal) o;
        return 
            (_LabelValueInternal.iD.Equals(this.iD))
             && (_LabelValueInternal.value == (this.value))
        ;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
      hashCode ^= iD == null ? 0 : iD.GetHashCode();
     hashCode ^= value.GetHashCode();
return hashCode;
}
public override string ToString()
{
        return "LabelValueInternal {"+" iD = " + iD + " "+" value = " + value + " "+ "} " + Environment.NewLine; }
public class LabelValueInternalComparer : IEqualityComparer<LabelValueInternal>
{
    public bool Equals(LabelValueInternal? x, LabelValueInternal? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(LabelValueInternal obj)
        {
        return obj.GetHashCode(); 
        }
}
    }
}
