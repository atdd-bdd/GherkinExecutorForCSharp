namespace gherkinexecutor.Feature_Data_Definition_Error{
using System.IO;
[TestClass]
public class Feature_Data_Definition_Error{
       void Log(string value)
            {
           try
           {
           Directory.CreateDirectory("GherkinExecutor/Feature_Data_Definition_Error");
	       using (var myLog = new StreamWriter("GherkinExecutor/Feature_Data_Definition_Error/log.txt", true))
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
    public void Test_Scenario_Simple_Table_with_int_bad(){
         Feature_Data_Definition_Error_glue feature_Data_Definition_Error_glue_object = new Feature_Data_Definition_Error_glue();
        Log("Scenario_Simple_Table_with_int_bad");

         List<ATest> objectList1 = new List<ATest>{
             new ATest.Builder()
                .SetAnInt("q")
                .SetAString("something")
                .SetADouble("1.1")
                .Build()
            };
        feature_Data_Definition_Error_glue_object.Given_table_is(objectList1);
        }
    [TestMethod]
    public void Test_Scenario_Simple_Table_with_double_bad(){
         Feature_Data_Definition_Error_glue feature_Data_Definition_Error_glue_object = new Feature_Data_Definition_Error_glue();
        Log("Scenario_Simple_Table_with_double_bad");

         List<ATest> objectList2 = new List<ATest>{
             new ATest.Builder()
                .SetAnInt("1")
                .SetAString("something")
                .SetADouble("r")
                .Build()
            };
        feature_Data_Definition_Error_glue_object.Given_table_is(objectList2);
        }
    [TestMethod]
    public void Test_Scenario_Simple_Table_with_initializer_bad(){
         Feature_Data_Definition_Error_glue feature_Data_Definition_Error_glue_object = new Feature_Data_Definition_Error_glue();
        Log("Scenario_Simple_Table_with_initializer_bad");

         List<ATestBad> objectList3 = new List<ATestBad>{
             new ATestBad.Builder()
                .SetAnInt("1")
                .Build()
            };
        feature_Data_Definition_Error_glue_object.Given_table_is_bad_initializer(objectList3);
        }
    }
}

