namespace gherkinexecutor.Feature_Full_Test {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
public class ATestInternal {
    public int anInt;
    public String aString;
    public Double aDouble;
     
    public static string ToDataTypeString() {
        return "ATestInternal {{"
        +"int " 
        +"String " 
        +"Double " 
        + "} "; }
    public ATest0 ToATest0() {
        return new ATest0(
        Convert.ToString(anInt)
        ,aString.ToString()
        ,Convert.ToString(aDouble)
        ); }
    public ATestInternal(
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
        ATestInternal _ATestInternal = (ATestInternal) o;
        return 
            (_ATestInternal.anInt == (this.anInt))
             && (_ATestInternal.aString.Equals(this.aString))
             && (_ATestInternal.aDouble.Equals(this.aDouble))
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
        return "ATestInternal {"+" anInt = " + anInt + " "+" aString = " + aString + " "+" aDouble = " + aDouble + " "+ "} " + Environment.NewLine; }
public class ATestInternalComparer : IEqualityComparer<ATestInternal>
{
    public bool Equals(ATestInternal? x, ATestInternal? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(ATestInternal obj)
        {
        return obj.GetHashCode(); 
        }
}
    }
}
