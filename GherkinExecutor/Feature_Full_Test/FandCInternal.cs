namespace gherkinexecutor.Feature_Full_Test {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
public class FandCInternal {
    public int f;
    public int c;
    public String notes;
     
    public static string ToDataTypeString() {
        return "FandCInternal {{"
        +"int " 
        +"int " 
        +"String " 
        + "} "; }
    public FandC ToFandC() {
        return new FandC(
        Convert.ToString(f)
        ,Convert.ToString(c)
        ,notes.ToString()
        ); }
    public FandCInternal(
        int f
        ,int c
        ,String notes
        ) {
        this.f = f;
        this.c = c;
        this.notes = notes;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        FandCInternal _FandCInternal = (FandCInternal) o;
        return 
            (_FandCInternal.f == (this.f))
             && (_FandCInternal.c == (this.c))
             && (_FandCInternal.notes.Equals(this.notes))
        ;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
       hashCode ^= f.GetHashCode();
     hashCode ^= c.GetHashCode();
    hashCode ^= notes == null ? 0 : notes.GetHashCode();
return hashCode;
}
public override string ToString()
{
        return "FandCInternal {"+" f = " + f + " "+" c = " + c + " "+" notes = " + notes + " "+ "} " + Environment.NewLine; }
public class FandCInternalComparer : IEqualityComparer<FandCInternal>
{
    public bool Equals(FandCInternal? x, FandCInternal? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(FandCInternal obj)
        {
        return obj.GetHashCode(); 
        }
}
    }
}
