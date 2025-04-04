namespace gherkinexecutor.Feature_Full_Test {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
public class SimpleClassInternal {
    public int anInt;
    public String aString;
     
    public static string ToDataTypeString() {
        return "SimpleClassInternal {{"
        +"int " 
        +"String " 
        + "} "; }
    public SimpleClass ToSimpleClass() {
        return new SimpleClass(
        Convert.ToString(anInt)
        ,aString.ToString()
        ); }
    public SimpleClassInternal(
        int anInt
        ,String aString
        ) {
        this.anInt = anInt;
        this.aString = aString;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        SimpleClassInternal _SimpleClassInternal = (SimpleClassInternal) o;
        return 
            (_SimpleClassInternal.anInt == (this.anInt))
             && (_SimpleClassInternal.aString.Equals(this.aString))
        ;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
       hashCode ^= anInt.GetHashCode();
    hashCode ^= aString == null ? 0 : aString.GetHashCode();
return hashCode;
}
public override string ToString()
{
        return "SimpleClassInternal {"+" anInt = " + anInt + " "+" aString = " + aString + " "+ "} " + Environment.NewLine; }
public class SimpleClassInternalComparer : IEqualityComparer<SimpleClassInternal>
{
    public bool Equals(SimpleClassInternal? x, SimpleClassInternal? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(SimpleClassInternal obj)
        {
        return obj.GetHashCode(); 
        }
}
    }
}
