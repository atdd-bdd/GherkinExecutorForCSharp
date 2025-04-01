namespace gherkinexecutor.Feature_Examples {
using System;
using System.Collections.Generic;
using System.Text;
public class ValueValidInternal {
    public String value;
    public Boolean valid;
    public String notes;
     
    public static string ToDataTypeString() {
        return "ValueValidInternal {{"
        +"String " 
        +"Boolean " 
        +"String " 
        + "} "; }
    public ValueValid ToValueValid() {
        return new ValueValid(
        value.ToString()
        ,Convert.ToString(valid)
        ,notes.ToString()
        ); }
    public ValueValidInternal(
        String value
        ,Boolean valid
        ,String notes
        ) {
        this.value = value;
        this.valid = valid;
        this.notes = notes;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        ValueValidInternal _ValueValidInternal = (ValueValidInternal) o;
        return 
            (_ValueValidInternal.value.Equals(this.value))
             && (_ValueValidInternal.valid.Equals(this.valid))
             && (_ValueValidInternal.notes.Equals(this.notes))
        ;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
      hashCode ^= value == null ? 0 : value.GetHashCode();
    hashCode ^= valid == null ? 0 : valid.GetHashCode();
    hashCode ^= notes == null ? 0 : notes.GetHashCode();
return hashCode;
}
public override string ToString()
{
        return "ValueValidInternal {"+" value = " + value + " "+" valid = " + valid + " "+" notes = " + notes + " "+ "} " + "\\n"; }
public class ValueValidInternalComparer : IEqualityComparer<ValueValidInternal>
{
    public bool Equals(ValueValidInternal? x, ValueValidInternal? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(ValueValidInternal obj)
        {
        return obj.GetHashCode(); 
        }
}
    }
}
