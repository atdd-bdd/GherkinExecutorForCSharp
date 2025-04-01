namespace gherkinexecutor.Feature_Simple_Test {
using System;
using System.Collections.Generic;
using System.Text;
public class ATestInternal {
    public Int32 anInt;
    public String aString;
    public Double aDouble;
     
    public static string ToDataTypeString() {
        return "ATestInternal {{"
        +"Int32 " 
        +"String " 
        +"Double " 
        + "} "; }
    public ATest ToATest() {
        return new ATest(
        Convert.ToString(anInt)
        ,aString.ToString()
        ,Convert.ToString(aDouble)
        ); }
    public ATestInternal(
        Int32 anInt
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
            (_ATestInternal.anInt.Equals(this.anInt))
             && (_ATestInternal.aString.Equals(this.aString))
             && (_ATestInternal.aDouble.Equals(this.aDouble))
        ;  }
public override string ToString()
{
        return "ATestInternal {"+" anInt = " + anInt + " "+" aString = " + aString + " "+" aDouble = " + aDouble + " "+ "} " + "\\n"; }
    }
}
