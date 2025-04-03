namespace gherkinexecutor.Feature_Full_Test {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
public class LabelValueInternal {
    public ID iD;
    public Int32 value;
     
    public static string ToDataTypeString() {
        return "LabelValueInternal {{"
        +"ID " 
        +"Int32 " 
        + "} "; }
    public LabelValue ToLabelValue() {
        return new LabelValue(
        iD.ToString()
        ,Convert.ToString(value)
        ); }
    public LabelValueInternal(
        ID iD
        ,Int32 value
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
             && (_LabelValueInternal.value.Equals(this.value))
        ;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
      hashCode ^= iD == null ? 0 : iD.GetHashCode();
    hashCode ^= value == null ? 0 : value.GetHashCode();
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
