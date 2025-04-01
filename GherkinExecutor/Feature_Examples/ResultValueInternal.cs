namespace gherkinexecutor.Feature_Examples {
using System;
using System.Collections.Generic;
using System.Text;
public class ResultValueInternal {
    public Int32 sum;
     
    public static string ToDataTypeString() {
        return "ResultValueInternal {{"
        +"Int32 " 
        + "} "; }
    public ResultValue ToResultValue() {
        return new ResultValue(
        Convert.ToString(sum)
        ); }
    public ResultValueInternal(
        Int32 sum
        ) {
        this.sum = sum;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        ResultValueInternal _ResultValueInternal = (ResultValueInternal) o;
        return 
            (_ResultValueInternal.sum.Equals(this.sum))
        ;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
      hashCode ^= sum == null ? 0 : sum.GetHashCode();
return hashCode;
}
public override string ToString()
{
        return "ResultValueInternal {"+" sum = " + sum + " "+ "} " + "\\n"; }
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
