namespace gherkinexecutor.Feature_Data_Definition {
using System;
using System.Collections.Generic;
    using System.Linq;
    using System.Text;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

public class Feature_Data_Definition_glue {
    const string DNCString = "?DNC?";

       ATest original;
        List<ATest> originalList; 
        bool result; 
        public void Given_table_is(List<ATest> values ) {
        Console.WriteLine("---  " + "Given_table_is");
        foreach (ATest value in values){
             Console.WriteLine(value);
              ATestInternal i = value.ToATestInternal();
              }
        original = values[0];
            originalList = values; 
    }

    public void When_compared_to(List<ATest> values ) {
        Console.WriteLine("---  " + "When_compared_to");
        foreach (ATest value in values){
             Console.WriteLine(value);
             }
        result = originalList.SequenceEqual(values, new ATest.ATestComparer());
        Console.WriteLine("SequenceEqual: " + result);


        }

        public void Then_result_is(List<List<string>> values ) {
        Console.WriteLine("---  " + "Then_result_is");
        foreach (List<string> value in values){
             Console.WriteLine(value);
              }
        bool expected = bool.Parse(values[0][0]); 
        AreEqual(expected, result);
        }

    }
}
