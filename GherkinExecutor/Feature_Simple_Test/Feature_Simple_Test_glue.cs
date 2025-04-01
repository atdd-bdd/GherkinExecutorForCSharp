namespace gherkinexecutor.Feature_Simple_Test {
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

public class Feature_Simple_Test_glue {
    const string DNCString = "?DNC?";


    public void Given_table_is(List<ATest> values ) {
        Console.WriteLine("---  " + "Given_table_is");
        foreach (ATest value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              ATestInternal i = value.ToATestInternal();
              }
        throw new NotImplementedException();
    }

    }
}
