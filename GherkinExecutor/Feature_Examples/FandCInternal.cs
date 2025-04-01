namespace gherkinexecutor.Feature_Examples {
using System;
using System.Collections.Generic;
using System.Text;
public class FandCInternal {
    public Int32 f;
    public Int32 c;
    public String notes;
     
    public static string ToDataTypeString() {
        return "FandCInternal {{"
        +"Int32 " 
        +"Int32 " 
        +"String " 
        + "} "; }
    public FandC ToFandC() {
        return new FandC(
        Convert.ToString(f)
        ,Convert.ToString(c)
        ,notes.ToString()
        ); }
    public FandCInternal(
        Int32 f
        ,Int32 c
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
            (_FandCInternal.f.Equals(this.f))
             && (_FandCInternal.c.Equals(this.c))
             && (_FandCInternal.notes.Equals(this.notes))
        ;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
      hashCode ^= f == null ? 0 : f.GetHashCode();
    hashCode ^= c == null ? 0 : c.GetHashCode();
    hashCode ^= notes == null ? 0 : notes.GetHashCode();
return hashCode;
}
public override string ToString()
{
        return "FandCInternal {"+" f = " + f + " "+" c = " + c + " "+" notes = " + notes + " "+ "} " + "\\n"; }
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
