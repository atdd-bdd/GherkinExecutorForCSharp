namespace gherkinexecutor.Feature_Import {
using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

public class Feature_Import_glue {
    const string DNCString = "?DNC?";


    public void Given_this_data_should_be_okay(List<ImportData> values ) {
        Console.WriteLine("---  " + "Given_this_data_should_be_okay");
        foreach (ImportData value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              ImportDataInternal i = value.ToImportDataInternal();
              }
    }

    public void Given_this_data_should_fail(List<ImportData> values ) {
        Console.WriteLine("---  " + "Given_this_data_should_fail");
        foreach (ImportData value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              ImportDataInternal i = value.ToImportDataInternal();
              }
        }

    }
}
