namespace gherkinexecutor.Feature_Full_Test {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
public class MoveInternal {
    public int row;
    public int column;
    public Char mark;
     
    public static string ToDataTypeString() {
        return "MoveInternal {{"
        +"int " 
        +"int " 
        +"Char " 
        + "} "; }
    public Move ToMove() {
        return new Move(
        Convert.ToString(row)
        ,Convert.ToString(column)
        ,mark.ToString()
        ); }
    public MoveInternal(
        int row
        ,int column
        ,Char mark
        ) {
        this.row = row;
        this.column = column;
        this.mark = mark;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        MoveInternal _MoveInternal = (MoveInternal) o;
        return 
            (_MoveInternal.row == (this.row))
             && (_MoveInternal.column == (this.column))
             && (_MoveInternal.mark.Equals(this.mark))
        ;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
      hashCode ^= row == null ? 0 : row.GetHashCode();
    hashCode ^= column == null ? 0 : column.GetHashCode();
    hashCode ^= mark == null ? 0 : mark.GetHashCode();
return hashCode;
}
public override string ToString()
{
        return "MoveInternal {"+" row = " + row + " "+" column = " + column + " "+" mark = " + mark + " "+ "} " + Environment.NewLine; }
public class MoveInternalComparer : IEqualityComparer<MoveInternal>
{
    public bool Equals(MoveInternal? x, MoveInternal? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(MoveInternal obj)
        {
        return obj.GetHashCode(); 
        }
}
    }
}
