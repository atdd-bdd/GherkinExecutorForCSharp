namespace gherkinexecutor.Feature_Data_Types
{
    [TestClass]
    public class Feature_Data_Types
    {


        [TestMethod]
        public void Test_Scenario_Use_the_data_types()
        {
            Feature_Data_Types_glue feature_Data_Types_glue_object = new Feature_Data_Types_glue();

            List<AllTypes> objectList1 = new List<AllTypes>{
             new AllTypes.Builder()
                .SetAnInt("0")
                .SetADouble("0.0")
                .SetAChar("x")
                .SetAchar("y")
                .Build()
            , new AllTypes.Builder()
                .SetAnInt("111")
                .SetADouble("222.2")
                .SetAChar("q")
                .SetAchar("")
                .Build()
            };
            feature_Data_Types_glue_object.Given_type_values_are(objectList1);

            List<AllTypes> objectList2 = new List<AllTypes>{
             new AllTypes.Builder()
                .SetAchar("y")
                .SetAnInt("0")
                .SetADouble("0.0")
                .SetAChar("x")
                .Build()
            , new AllTypes.Builder()
                .SetAchar("")
                .SetAnInt("111")
                .SetADouble("222.2")
                .SetAChar("q")
                .Build()
            };
            feature_Data_Types_glue_object.Then_this_should_be_equal(objectList2);
        }
    }
}

