namespace gherkinexecutor.Feature_Json
{
    using System;
    using System.Collections.Generic;
    public class SimpleClassInternal
    {
        public Int32 anInt;
        public String aString;

        public static string ToDataTypeString()
        {
            return "SimpleClassInternal {{"
            + "Int32 "
            + "String "
            + "} ";
        }
        public SimpleClass ToSimpleClass()
        {
            return new SimpleClass(
            Convert.ToString(anInt)
            , aString.ToString()
            );
        }
        public SimpleClassInternal(
            Int32 anInt
            , String aString
            )
        {
            this.anInt = anInt;
            this.aString = aString;
        }
        public override bool Equals(object? o)
        {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            SimpleClassInternal _SimpleClassInternal = (SimpleClassInternal)o;
            return
                (_SimpleClassInternal.anInt.Equals(this.anInt))
                 && (_SimpleClassInternal.aString.Equals(this.aString))
            ;
        }
        public override int GetHashCode()

        {
            int hashCode = 1;
            hashCode ^= anInt == null ? 0 : anInt.GetHashCode();
            hashCode ^= aString == null ? 0 : aString.GetHashCode();
            return hashCode;
        }
        public override string ToString()
        {
            return "SimpleClassInternal {" + " anInt = " + anInt + " " + " aString = " + aString + " " + "} " + "\\n";
        }
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
