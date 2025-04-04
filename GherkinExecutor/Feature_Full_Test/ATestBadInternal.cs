namespace gherkinexecutor.Feature_Full_Test {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
public class ATestBadInternal {
    public int anInt;
    public String aString;
    public Double aDouble;
     
    public static string ToDataTypeString() {
        return "ATestBadInternal {{"
        +"int " 
        +"String " 
        +"Double " 
        + "} "; }
    public ATestBad ToATestBad() {
        return new ATestBad(
        Convert.ToString(anInt)
        ,aString.ToString()
        ,Convert.ToString(aDouble)
        ); }
    public ATestBadInternal(
        int anInt
        ,String aString
        ,Double aDouble
        ) {
        this.anInt = anInt;
        this.aString = aString;
        this.aDouble = aDouble;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        ATestBadInternal _ATestBadInternal = (ATestBadInternal) o;
        return 
            (_ATestBadInternal.anInt == (this.anInt))
             && (_ATestBadInternal.aString.Equals(this.aString))
             && (_ATestBadInternal.aDouble.Equals(this.aDouble))
        ;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
       hashCode ^= anInt.GetHashCode();
    hashCode ^= aString == null ? 0 : aString.GetHashCode();
    hashCode ^= aDouble == null ? 0 : aDouble.GetHashCode();
return hashCode;
}
public override string ToString()
{
        return "ATestBadInternal {"+" anInt = " + anInt + " "+" aString = " + aString + " "+" aDouble = " + aDouble + " "+ "} " + Environment.NewLine; }
public class ATestBadInternalComparer : IEqualityComparer<ATestBadInternal>
{
    public bool Equals(ATestBadInternal? x, ATestBadInternal? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(ATestBadInternal obj)
        {
        return obj.GetHashCode(); 
        }
}
    }
}
