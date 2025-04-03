namespace gherkinexecutor.Feature_Data_Types
{
    using System;
    using System.Collections.Generic;
    public class AllTypesInternal
    {
        public int anInt;
        public Double aDouble;
        public char aChar;
        public char achar;

        public static string ToDataTypeString()
        {
            return "AllTypesInternal {{"
            + "int "
            + "Double "
            + "char "
            + "char "
            + "} ";
        }
        public AllTypes ToAllTypes()
        {
            return new AllTypes(
            Convert.ToString(anInt)
            , Convert.ToString(aDouble)
            , Convert.ToString(aChar)
            , Convert.ToString(achar)
            );
        }
        public AllTypesInternal(
            int anInt
            , Double aDouble
            , char aChar
            , char achar
            )
        {
            this.anInt = anInt;
            this.aDouble = aDouble;
            this.aChar = aChar;
            this.achar = achar;
        }
        public override bool Equals(object? o)
        {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            AllTypesInternal _AllTypesInternal = (AllTypesInternal)o;
            return
                (_AllTypesInternal.anInt == (this.anInt))
                 && (_AllTypesInternal.aDouble.Equals(this.aDouble))
                 && (_AllTypesInternal.aChar == (this.aChar))
                 && (_AllTypesInternal.achar == (this.achar))
            ;
        }
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
            return "AllTypesInternal {" + " anInt = " + anInt + " " + " aDouble = " + aDouble + " " + " aChar = " + aChar + " " + " achar = " + achar + " " + "} " + "\\n";
        }
        public class AllTypesInternalComparer : IEqualityComparer<AllTypesInternal>
        {
            public bool Equals(AllTypesInternal? x, AllTypesInternal? y)
            {
                if (x == null) return false;
                return x.Equals(y);
            }
            public int GetHashCode(AllTypesInternal obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
