namespace gherkinexecutor.Feature_Optional_Tests{
using System.IO;
[TestCategory("OnlyThisFeature")]
[TestClass]
public class Feature_Optional_Tests{
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

    [TestMethod]
    public void Test_Scenario_This_may_be_run(){
         Feature_Optional_Tests_glue feature_Optional_Tests_glue_object = new Feature_Optional_Tests_glue();
        Log("Scenario_This_may_be_run");

        feature_Optional_Tests_glue_object.Given_This_may_be_run();
        }
    }
}

