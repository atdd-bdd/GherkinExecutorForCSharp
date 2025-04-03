namespace gherkinexecutor.Feature_Data_Definition_Error {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using System.IO;

public class Feature_Data_Definition_Error_glue {
    const string DNCString = "?DNC?";
       void Log(string value)
            {
           try
           {
           Directory.CreateDirectory("DIRECTORY");
	       using (var myLog = new StreamWriter("DIRECTORY/log.txt", true))
	           {
	           myLog.WriteLine(value);
		        }
		   }
		   catch (IOException e)
		     	{
			    Console.Error.WriteLine("*** Cannot write to log " + e);
		      	}
		    }

    public void Given_table_is(List<ATest> values ) {
        Console.WriteLine("---  " + "Given_table_is");
        Log("---  " + "Given_table_is");
         string output = string.Join(Environment.NewLine, values);
         Log(output);
        foreach (ATest value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              ATestInternal i = value.ToATestInternal();
              }
    }

    public void Given_table_is_bad_initializer(List<ATestBad> values ) {
        Console.WriteLine("---  " + "Given_table_is_bad_initializer");
        Log("---  " + "Given_table_is_bad_initializer");
         string output = string.Join(Environment.NewLine, values);
         Log(output);
        foreach (ATestBad value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              ATestBadInternal i = value.ToATestBadInternal();
              }
    }

    }
}
