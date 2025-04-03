namespace gherkinexecutor.Feature_Full_Test {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
public class Move {
    public string row = "0";
    public string column = "0";
    public string mark = "^";
    public Move() {}
    public Move(
        string row
        ,string column
        ,string mark
        ){
        this.row = row;
        this.column = column;
        this.mark = mark;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        Move _Move = (Move) o;
        bool result = true;
        if (
            !this.row.Equals("?DNC?")
            && !_Move.row.Equals("?DNC?"))
        if (!_Move.row.Equals(this.row)) result = false;
        if (
            !this.column.Equals("?DNC?")
            && !_Move.column.Equals("?DNC?"))
        if (!_Move.column.Equals(this.column)) result = false;
        if (
            !this.mark.Equals("?DNC?")
            && !_Move.mark.Equals("?DNC?"))
        if (!_Move.mark.Equals(this.mark)) result = false;
        return result;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
      hashCode ^= row == null ? 0 : row.GetHashCode();
    hashCode ^= column == null ? 0 : column.GetHashCode();
    hashCode ^= mark == null ? 0 : mark.GetHashCode();
return hashCode;
}
    public class Builder {
        private string row = "0";
        private string column = "0";
        private string mark = "^";
        public Builder SetRow(string row) {
            this.row = row;
            return this;
            }
        public Builder SetColumn(string column) {
            this.column = column;
            return this;
            }
        public Builder SetMark(string mark) {
            this.mark = mark;
            return this;
            }
        public Builder SetCompare() {
            row = "?DNC?";
            column = "?DNC?";
            mark = "?DNC?";
            return this;
            }
        public Move Build(){
             return new Move(
                 row
                 ,column
                 ,mark
                );   } 
        } 
public override string ToString()
{
        return "Move {"+" row = " + row + " "+" column = " + column + " "+" mark = " + mark + " "+ "} " + Environment.NewLine; }
public string ToJson()
{
    return " {"+"row: " + "\"" + row + "\""         + ","+"column: " + "\"" + column + "\""         + ","+"mark: " + "\"" + mark + "\""+ "} " ; }             
    public static Move FromJson(string json)
    {
            Move instance = new Move();
        
        json = json.Replace("\\s", "");
        string[] keyValuePairs = json.Replace("{", "").Replace("}", "").Split(',');
        
        foreach (string pair in keyValuePairs)
        {string[] entry = pair.Split(':');
            string key = entry[0].Replace("\"", "").Trim();
            string value = entry[1].Replace("\"", "").Trim();
            
            switch (key)
            {

        case "row":
             instance.row = value;
             break;
        case "column":
             instance.column = value;
             break;
        case "mark":
             instance.mark = value;
             break;
        default:
            Console.Error.WriteLine("Invalid JSON element " + key);
            break; 
        }
    }
    return instance;
}
public static string ListToJson(List<Move> list)
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
public static List<Move> ListFromJson(string json)
{List <Move> list = new List<Move>();
json = Regex.Replace(json, @"\s", "");
json = Regex.Replace(json, @"\[", "").Replace("]", "");
string[] jsonObjects = Regex.Split(json, @"(?<=\}),\s*(?=\{)");  
foreach (string jsonObject in jsonObjects)
    {
    list.Add(Move.FromJson(jsonObject));
    }
    return list;
}
public class MoveComparer : IEqualityComparer<Move>
{
    public bool Equals(Move? x, Move? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(Move obj)
        {
        return obj.GetHashCode(); 
        }
}
    public MoveInternal ToMoveInternal() {
        return new MoveInternal(
         int.Parse(row)
        , int.Parse(column)
        , ( mark.Length > 0 ?mark[0] : ' ')
        ); }
    }
}
