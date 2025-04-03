namespace gherkinexecutor.Feature_Simple_Test{
using System.IO;
[TestClass]
public class Feature_Simple_Test{
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

    [TestMethod]
    public void Test_Scenario_Simple(){
         Feature_Simple_Test_glue feature_Simple_Test_glue_object = new Feature_Simple_Test_glue();
        Log("Scenario_Simple");

         List<ATest> objectList1 = new List<ATest>{
             new ATest.Builder()
                .SetAnInt("1")
                .SetAString("something")
                .SetADouble("1.2")
                .Build()
            };
        feature_Simple_Test_glue_object.Given_table_is(objectList1);
        }
    }
}

