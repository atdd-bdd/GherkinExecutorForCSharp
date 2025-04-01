namespace gherkinexecutor.Feature_Data_Types {
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

public class Feature_Data_Types_glue {
    const string DNCString = "?DNC?";
        List<AllTypesInternal> original = new List<AllTypesInternal>();
        List<AllTypesInternal> expected = new List<AllTypesInternal>();


        public void Given_type_values_are(List<AllTypes> values ) {
        Console.WriteLine("---  " + "Given_type_values_are");
        foreach (AllTypes value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              AllTypesInternal i = value.ToAllTypesInternal();
              original.Add(i);
            }
    }

    public void Then_this_should_be_equal(List<AllTypes> values ) {
        Console.WriteLine("---  " + "Then_this_should_be_equal");
        foreach (AllTypes value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              AllTypesInternal i = value.ToAllTypesInternal();
              expected.Add(i);
            }
         bool result = original.SequenceEqual(expected, new AllTypesInternal.AllTypesInternalComparer());
        IsTrue(result, "Lists do not match");
        }

    }
}
