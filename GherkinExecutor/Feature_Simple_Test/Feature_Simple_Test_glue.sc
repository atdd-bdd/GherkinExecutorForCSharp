namespace gherkinexecutor.Feature_Simple_Test {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using System.IO;

public class Feature_Simple_Test_glue {
    const string DNCString = "?DNC?";
       void Log(string value)
            {
           try
           {
           Directory.CreateDirectory("GherkinExecutor/Feature_Simple_Test");
	       using (var myLog = new StreamWriter("GherkinExecutor/Feature_Simple_Test/log.txt", true))
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
        foreach (ATest value in values){
                  Log(value.ToString());}
        foreach (ATest value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              ATestInternal i = value.ToATestInternal();
              }
    }

    }
}
