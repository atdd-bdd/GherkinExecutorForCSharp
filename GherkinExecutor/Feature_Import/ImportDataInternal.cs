namespace gherkinexecutor.Feature_Import {
using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
public class ImportDataInternal {
    public DayOfWeek myWeekday;
    public BigInteger myBigInt;
     
    public static string ToDataTypeString() {
        return "ImportDataInternal {{"
        +"DayOfWeek " 
        +"BigInteger " 
        + "} "; }
    public ImportData ToImportData() {
        return new ImportData(
        myWeekday.ToString()
        ,myBigInt.ToString()
        ); }
    public ImportDataInternal(
        DayOfWeek myWeekday
        ,BigInteger myBigInt
        ) {
        this.myWeekday = myWeekday;
        this.myBigInt = myBigInt;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        ImportDataInternal _ImportDataInternal = (ImportDataInternal) o;
        return 
            (_ImportDataInternal.myWeekday.Equals(this.myWeekday))
             && (_ImportDataInternal.myBigInt.Equals(this.myBigInt))
        ;  }
public override string ToString()
{
        return "ImportDataInternal {"+" myWeekday = " + myWeekday + " "+" myBigInt = " + myBigInt + " "+ "} " + "\\n"; }
    }
}
