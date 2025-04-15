namespace gherkinexecutor.Feature_Optional_Tests {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using System.IO;

public class Feature_Optional_Tests_glue {
    const string DNCString = "?DNC?";
       void Log(string value)
            {
           try
           {
           Directory.CreateDirectory("GherkinExecutor/Feature_Optional_Tests");
	       using (var myLog = new StreamWriter("GherkinExecutor/Feature_Optional_Tests/log.txt", true))
	           {
	           myLog.WriteLine(value);
		        }
		   }
		   catch (IOException e)
		     	{
			    Console.Error.WriteLine("*** Cannot write to log " + e);
		      	}
		    }

    public void Given_This_will_always_be_run(){
        Console.WriteLine("---  " + "Given_This_will_always_be_run");
        Log("---  " + "Given_This_will_always_be_run");
    }

    public void Given_This_may_be_run(){
        Console.WriteLine("---  " + "Given_This_may_be_run");
        Log("---  " + "Given_This_may_be_run");
    }

    public void Given_This_will_be_run_if_tag(){
        Console.WriteLine("---  " + "Given_This_will_be_run_if_tag");
        Log("---  " + "Given_This_will_be_run_if_tag");
    }

    }
}
