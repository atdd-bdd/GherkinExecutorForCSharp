namespace gherkinexecutor.Feature_Simple_Test{
[TestClass]
public class Feature_Simple_Test{


    [TestMethod]
    public void Test_Scenario_Simple(){
         Feature_Simple_Test_glue feature_Simple_Test_glue_object = new Feature_Simple_Test_glue();

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

