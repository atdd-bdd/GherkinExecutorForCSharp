namespace gherkinexecutor.Feature_Data_Definition {
using System;
using System.Collections.Generic;
using System.Text;
public class AllTypesInternal {
    public int anInt;
    public byte aByte;
    public sbyte aSByte;
    public short aShort;
    public ushort aUshort;
    public uint aUint;
    public long aLong;
    public ulong aUlong;
    public float aFloat;
    public double aDouble;
    public decimal aDecimal;
    public bool aBool;
    public string aString;
    public char aChar;
    public Int32 anIntObject;
    public Byte aByteObject;
    public SByte aSByteObject;
    public Int16 aShortObject;
    public UInt16 aUshortObject;
    public UInt32 aUintObject;
    public Int64 aLongObject;
    public UInt64 aUlongObject;
    public Single aFloatObject;
    public Double aDoubleObject;
    public Decimal aDecimalObject;
    public Boolean aBoolObject;
    public String aStringObjet;
    public Char aCharObject;
     
    public static string ToDataTypeString() {
        return "AllTypesInternal {{"
        +"int " 
        +"byte " 
        +"sbyte " 
        +"short " 
        +"ushort " 
        +"uint " 
        +"long " 
        +"ulong " 
        +"float " 
        +"double " 
        +"decimal " 
        +"bool " 
        +"string " 
        +"char " 
        +"Int32 " 
        +"Byte " 
        +"SByte " 
        +"Int16 " 
        +"UInt16 " 
        +"UInt32 " 
        +"Int64 " 
        +"UInt64 " 
        +"Single " 
        +"Double " 
        +"Decimal " 
        +"Boolean " 
        +"String " 
        +"Char " 
        + "} "; }
    public AllTypes ToAllTypes() {
        return new AllTypes(
        Convert.ToString(anInt)
        ,Convert.ToString(aByte)
        ,Convert.ToString(aSByte)
        ,Convert.ToString(aShort)
        ,Convert.ToString(aUshort)
        ,aUint.ToString()
        ,Convert.ToString(aLong)
        ,Convert.ToString(aUlong)
        ,Convert.ToString(aFloat)
        ,Convert.ToString(aDouble)
        ,aDecimal.ToString()
        ,Convert.ToString(aBool)
        ,aString
        ,Convert.ToString(aChar)
        ,Convert.ToString(anIntObject)
        ,Convert.ToString(aByteObject)
        ,aSByteObject.ToString()
        ,aShortObject.ToString()
        ,aUshortObject.ToString()
        ,aUintObject.ToString()
        ,aLongObject.ToString()
        ,aUlongObject.ToString()
        ,aFloatObject.ToString()
        ,Convert.ToString(aDoubleObject)
        ,aDecimalObject.ToString()
        ,Convert.ToString(aBoolObject)
        ,aStringObjet.ToString()
        ,aCharObject.ToString()
        ); }
    public AllTypesInternal(
        int anInt
        ,byte aByte
        ,sbyte aSByte
        ,short aShort
        ,ushort aUshort
        ,uint aUint
        ,long aLong
        ,ulong aUlong
        ,float aFloat
        ,double aDouble
        ,decimal aDecimal
        ,bool aBool
        ,string aString
        ,char aChar
        ,Int32 anIntObject
        ,Byte aByteObject
        ,SByte aSByteObject
        ,Int16 aShortObject
        ,UInt16 aUshortObject
        ,UInt32 aUintObject
        ,Int64 aLongObject
        ,UInt64 aUlongObject
        ,Single aFloatObject
        ,Double aDoubleObject
        ,Decimal aDecimalObject
        ,Boolean aBoolObject
        ,String aStringObjet
        ,Char aCharObject
        ) {
        this.anInt = anInt;
        this.aByte = aByte;
        this.aSByte = aSByte;
        this.aShort = aShort;
        this.aUshort = aUshort;
        this.aUint = aUint;
        this.aLong = aLong;
        this.aUlong = aUlong;
        this.aFloat = aFloat;
        this.aDouble = aDouble;
        this.aDecimal = aDecimal;
        this.aBool = aBool;
        this.aString = aString;
        this.aChar = aChar;
        this.anIntObject = anIntObject;
        this.aByteObject = aByteObject;
        this.aSByteObject = aSByteObject;
        this.aShortObject = aShortObject;
        this.aUshortObject = aUshortObject;
        this.aUintObject = aUintObject;
        this.aLongObject = aLongObject;
        this.aUlongObject = aUlongObject;
        this.aFloatObject = aFloatObject;
        this.aDoubleObject = aDoubleObject;
        this.aDecimalObject = aDecimalObject;
        this.aBoolObject = aBoolObject;
        this.aStringObjet = aStringObjet;
        this.aCharObject = aCharObject;
        }
    public override bool Equals(object? o) {
        if (this == o) return true;
        if (o == null || GetType() != o.GetType()) return false;
        AllTypesInternal _AllTypesInternal = (AllTypesInternal) o;
        return 
            (_AllTypesInternal.anInt == (this.anInt))
             && (_AllTypesInternal.aByte == (this.aByte))
             && (_AllTypesInternal.aSByte == (this.aSByte))
             && (_AllTypesInternal.aShort == (this.aShort))
             && (_AllTypesInternal.aUshort == (this.aUshort))
             && (_AllTypesInternal.aUint == (this.aUint))
             && (_AllTypesInternal.aLong == (this.aLong))
             && (_AllTypesInternal.aUlong == (this.aUlong))
             && (_AllTypesInternal.aFloat == (this.aFloat))
             && (_AllTypesInternal.aDouble == (this.aDouble))
             && (_AllTypesInternal.aDecimal == (this.aDecimal))
             && (_AllTypesInternal.aBool == (this.aBool))
             && (_AllTypesInternal.aString.Equals(this.aString))
             && (_AllTypesInternal.aChar == (this.aChar))
             && (_AllTypesInternal.anIntObject.Equals(this.anIntObject))
             && (_AllTypesInternal.aByteObject.Equals(this.aByteObject))
             && (_AllTypesInternal.aSByteObject.Equals(this.aSByteObject))
             && (_AllTypesInternal.aShortObject.Equals(this.aShortObject))
             && (_AllTypesInternal.aUshortObject.Equals(this.aUshortObject))
             && (_AllTypesInternal.aUintObject.Equals(this.aUintObject))
             && (_AllTypesInternal.aLongObject.Equals(this.aLongObject))
             && (_AllTypesInternal.aUlongObject.Equals(this.aUlongObject))
             && (_AllTypesInternal.aFloatObject.Equals(this.aFloatObject))
             && (_AllTypesInternal.aDoubleObject.Equals(this.aDoubleObject))
             && (_AllTypesInternal.aDecimalObject.Equals(this.aDecimalObject))
             && (_AllTypesInternal.aBoolObject.Equals(this.aBoolObject))
             && (_AllTypesInternal.aStringObjet.Equals(this.aStringObjet))
             && (_AllTypesInternal.aCharObject.Equals(this.aCharObject))
        ;  }
    public override int GetHashCode()

   {
   int hashCode = 1; 
      hashCode ^= anInt == null ? 0 : anInt.GetHashCode();
    hashCode ^= aByte == null ? 0 : aByte.GetHashCode();
    hashCode ^= aSByte == null ? 0 : aSByte.GetHashCode();
    hashCode ^= aShort == null ? 0 : aShort.GetHashCode();
    hashCode ^= aUshort == null ? 0 : aUshort.GetHashCode();
    hashCode ^= aUint == null ? 0 : aUint.GetHashCode();
    hashCode ^= aLong == null ? 0 : aLong.GetHashCode();
    hashCode ^= aUlong == null ? 0 : aUlong.GetHashCode();
    hashCode ^= aFloat == null ? 0 : aFloat.GetHashCode();
    hashCode ^= aDouble == null ? 0 : aDouble.GetHashCode();
    hashCode ^= aDecimal == null ? 0 : aDecimal.GetHashCode();
    hashCode ^= aBool == null ? 0 : aBool.GetHashCode();
    hashCode ^= aString == null ? 0 : aString.GetHashCode();
    hashCode ^= aChar == null ? 0 : aChar.GetHashCode();
    hashCode ^= anIntObject == null ? 0 : anIntObject.GetHashCode();
    hashCode ^= aByteObject == null ? 0 : aByteObject.GetHashCode();
    hashCode ^= aSByteObject == null ? 0 : aSByteObject.GetHashCode();
    hashCode ^= aShortObject == null ? 0 : aShortObject.GetHashCode();
    hashCode ^= aUshortObject == null ? 0 : aUshortObject.GetHashCode();
    hashCode ^= aUintObject == null ? 0 : aUintObject.GetHashCode();
    hashCode ^= aLongObject == null ? 0 : aLongObject.GetHashCode();
    hashCode ^= aUlongObject == null ? 0 : aUlongObject.GetHashCode();
    hashCode ^= aFloatObject == null ? 0 : aFloatObject.GetHashCode();
    hashCode ^= aDoubleObject == null ? 0 : aDoubleObject.GetHashCode();
    hashCode ^= aDecimalObject == null ? 0 : aDecimalObject.GetHashCode();
    hashCode ^= aBoolObject == null ? 0 : aBoolObject.GetHashCode();
    hashCode ^= aStringObjet == null ? 0 : aStringObjet.GetHashCode();
    hashCode ^= aCharObject == null ? 0 : aCharObject.GetHashCode();
return hashCode;
}
public override string ToString()
{
        return "AllTypesInternal {"+" anInt = " + anInt + " "+" aByte = " + aByte + " "+" aSByte = " + aSByte + " "+" aShort = " + aShort + " "+" aUshort = " + aUshort + " "+" aUint = " + aUint + " "+" aLong = " + aLong + " "+" aUlong = " + aUlong + " "+" aFloat = " + aFloat + " "+" aDouble = " + aDouble + " "+" aDecimal = " + aDecimal + " "+" aBool = " + aBool + " "+" aString = " + aString + " "+" aChar = " + aChar + " "+" anIntObject = " + anIntObject + " "+" aByteObject = " + aByteObject + " "+" aSByteObject = " + aSByteObject + " "+" aShortObject = " + aShortObject + " "+" aUshortObject = " + aUshortObject + " "+" aUintObject = " + aUintObject + " "+" aLongObject = " + aLongObject + " "+" aUlongObject = " + aUlongObject + " "+" aFloatObject = " + aFloatObject + " "+" aDoubleObject = " + aDoubleObject + " "+" aDecimalObject = " + aDecimalObject + " "+" aBoolObject = " + aBoolObject + " "+" aStringObjet = " + aStringObjet + " "+" aCharObject = " + aCharObject + " "+ "} " + "\\n"; }
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
