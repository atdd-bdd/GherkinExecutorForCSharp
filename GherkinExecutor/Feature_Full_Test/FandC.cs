namespace gherkinexecutor.Feature_Full_Test {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
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
