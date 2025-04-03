namespace gherkinexecutor.Feature_Full_Test {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
public class SomeTypesInternal {
    public int anInt;
    public Double aDouble;
    public char aChar;
    public char achar;
     
    public static string ToDataTypeString() {
        return "SomeTypesInternal {{"
        +"int " 
        +"Double " 
        +"char " 
        +"char " 
        + "} "; }
    public SomeTypes ToSomeTypes() {
        return new SomeTypes(
        Convert.ToString(anInt)
        ,Convert.ToString(aDouble)
        ,Convert.ToString(aChar)
        ,Convert.ToString(achar)
        ); }
    public SomeTypesInternal(
        int anInt
        ,Double aDouble
        ,char aChar
        ,char achar
        ) {
        this.anInt = anInt;
        this.aDouble = aDouble;
        this.aChar = aChar;
        this.achar = achar;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        SomeTypesInternal _SomeTypesInternal = (SomeTypesInternal) o;
        return 
            (_SomeTypesInternal.anInt == (this.anInt))
             && (_SomeTypesInternal.aDouble.Equals(this.aDouble))
             && (_SomeTypesInternal.aChar == (this.aChar))
             && (_SomeTypesInternal.achar == (this.achar))
        ;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
      hashCode ^= anInt == null ? 0 : anInt.GetHashCode();
    hashCode ^= aDouble == null ? 0 : aDouble.GetHashCode();
    hashCode ^= aChar == null ? 0 : aChar.GetHashCode();
    hashCode ^= achar == null ? 0 : achar.GetHashCode();
return hashCode;
}
public override string ToString()
{
        return "SomeTypesInternal {"+" anInt = " + anInt + " "+" aDouble = " + aDouble + " "+" aChar = " + aChar + " "+" achar = " + achar + " "+ "} " + Environment.NewLine; }
public class SomeTypesInternalComparer : IEqualityComparer<SomeTypesInternal>
{
    public bool Equals(SomeTypesInternal? x, SomeTypesInternal? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(SomeTypesInternal obj)
        {
        return obj.GetHashCode(); 
        }
}
    }
}
