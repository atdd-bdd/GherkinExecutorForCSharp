namespace gherkinexecutor.Feature_Full_Test
{
using System;
using System.Collections.Generic;
using System.Text;
public class Existing {
    public int aValue;
    public String bValue;
    public double cValue;
     
    public static string ToDataTypeString() {
        return "Existing {{"
        +"int " 
        +"String " 
        +"double " 
        + "} "; }
    public TestIn ToTestIn() {
        return new TestIn(
        Convert.ToString(aValue)
        ,bValue.ToString()
        ,Convert.ToString(cValue)
        ); }
    public Existing(
        int aValue
        ,String bValue
        ,double cValue
        ) {
        this.aValue = aValue;
        this.bValue = bValue;
        this.cValue = cValue;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        Existing _Existing = (Existing) o;
        return 
            (_Existing.aValue == (this.aValue))
             && (_Existing.bValue.Equals(this.bValue))
             && (_Existing.cValue == (this.cValue))
        ;  }
public override string ToString()
{
        return "Existing {"+" aValue = " + aValue + " "+" bValue = " + bValue + " "+" cValue = " + cValue + " "+ "} " + "\\n"; }
    }
}
