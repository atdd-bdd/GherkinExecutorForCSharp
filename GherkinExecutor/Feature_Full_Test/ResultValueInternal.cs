namespace gherkinexecutor.Feature_Full_Test {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
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
