namespace gherkinexecutor.Feature_Import {
using System;
using System.Collections.Generic;
using System.Text;
public class ImportDataInternal {
    public Pattern myPattern;
    public Weekday myWeekday;
    public BigInteger myBigInt;
     
    public static string ToDataTypeString() {
        return "ImportDataInternal {{"
        +"Pattern " 
        +"Weekday " 
        +"BigInteger " 
        + "} "; }
    public ImportData ToImportData() {
        return new ImportData(
        myPattern.ToString()
        ,myWeekday.ToString()
        ,myBigInt.ToString()
        ); }
    public ImportDataInternal(
        Pattern myPattern
        ,Weekday myWeekday
        ,BigInteger myBigInt
        ) {
        this.myPattern = myPattern;
        this.myWeekday = myWeekday;
        this.myBigInt = myBigInt;
        }
    public override bool Equals(object o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        ImportDataInternal _ImportDataInternal = (ImportDataInternal) o;
        return 
            (_ImportDataInternal.myPattern.Equals(this.myPattern))
             && (_ImportDataInternal.myWeekday.Equals(this.myWeekday))
             && (_ImportDataInternal.myBigInt.Equals(this.myBigInt))
        ;  }
public override string ToString()
{
        return "ImportDataInternal {"+" myPattern = " + myPattern + " "+" myWeekday = " + myWeekday + " "+" myBigInt = " + myBigInt + " "+ "} " + "\\n"; }
    }
}
