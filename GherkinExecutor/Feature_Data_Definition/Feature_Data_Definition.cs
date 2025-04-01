namespace gherkinexecutor.Feature_Data_Definition{
[TestClass]
public class Feature_Data_Definition{


    [TestMethod]
    public void Test_Scenario_Simple_Comparison(){
         Feature_Data_Definition_glue feature_Data_Definition_glue_object = new Feature_Data_Definition_glue();

         List<ATest> objectList1 = new List<ATest>{
             new ATest.Builder()
                .SetAnInt("1")
                .SetAString("something")
                .SetADouble("1.2")
                .Build()
            };
        feature_Data_Definition_glue_object.Given_table_is(objectList1);

         List<ATest> objectList2 = new List<ATest>{
             new ATest.Builder()
             .SetCompare()
                .SetAString("something")
                .Build()
            };
        feature_Data_Definition_glue_object.When_compared_to(objectList2);

        List<List<string>> stringListList3 = new List<List<string>>{
           new List<string>{
            "true"
            }
            };
        feature_Data_Definition_glue_object.Then_result_is(stringListList3);

         List<ATest> objectList4 = new List<ATest>{
             new ATest.Builder()
             .SetCompare()
                .SetAString("something else")
                .Build()
            };
        feature_Data_Definition_glue_object.When_compared_to(objectList4);

        List<List<string>> stringListList5 = new List<List<string>>{
           new List<string>{
            "false"
            }
            };
        feature_Data_Definition_glue_object.Then_result_is(stringListList5);
        }
    }
}

