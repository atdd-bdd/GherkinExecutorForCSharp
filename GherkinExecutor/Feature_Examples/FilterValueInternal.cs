namespace gherkinexecutor.Feature_Examples {
using System;
using System.Collections.Generic;
using System.Text;
public class FilterValueInternal {
    public ID value;
     
    public static string ToDataTypeString() {
        return "FilterValueInternal {{"
        +"ID " 
        + "} "; }
    public FilterValue ToFilterValue() {
        return new FilterValue(
        value.ToString()
        ); }
    public FilterValueInternal(
        ID value
        ) {
        this.value = value;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        FilterValueInternal _FilterValueInternal = (FilterValueInternal) o;
        return 
            (_FilterValueInternal.value.Equals(this.value))
        ;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
      hashCode ^= value == null ? 0 : value.GetHashCode();
return hashCode;
}
public override string ToString()
{
        return "FilterValueInternal {"+" value = " + value + " "+ "} " + "\\n"; }
public class FilterValueInternalComparer : IEqualityComparer<FilterValueInternal>
{
    public bool Equals(FilterValueInternal? x, FilterValueInternal? y)
        {
        if (x == null) return false; 
        return x.Equals(y);
        }
    public int GetHashCode(FilterValueInternal obj)
        {
        return obj.GetHashCode(); 
        }
}
    }
}
