namespace gherkinexecutor.Feature_Define
{
    [TestClass]
    public class Feature_Define
    {


        [TestMethod]
        public void Test_Scenario_Simple_Replacement()
        {
            Feature_Define_glue feature_Define_glue_object = new Feature_Define_glue();

            List<IDValue> objectList1 = new List<IDValue>{
             new IDValue.Builder()
                .SetID("A")
                .SetValue("100")
                .Build()
            , new IDValue.Builder()
                .SetID("B")
                .SetValue("1")
                .Build()
            };
            feature_Define_glue_object.Given_this_data(objectList1);

            List<IDValue> objectList2 = new List<IDValue>{
             new IDValue.Builder()
                .SetID("A")
                .SetValue("100")
                .Build()
            , new IDValue.Builder()
                .SetID("B")
                .SetValue("1")
                .Build()
            };
            feature_Define_glue_object.Then_should_be_equal_to_data(objectList2);
        }
        [TestMethod]
        public void Test_Scenario_Try_out_replacements_with_a_calculation()
        {
            Feature_Define_glue feature_Define_glue_object = new Feature_Define_glue();

            List<IDValue> objectList3 = new List<IDValue>{
             new IDValue.Builder()
                .SetID("A")
                .SetValue("100")
                .Build()
            , new IDValue.Builder()
                .SetID("B")
                .SetValue("1")
                .Build()
            , new IDValue.Builder()
                .SetID("C")
                .SetValue("(1 + 100)/2")
                .Build()
            };
            feature_Define_glue_object.Given_this_data(objectList3);

            List<IDValue> objectList4 = new List<IDValue>{
             new IDValue.Builder()
                .SetID("A")
                .SetValue("100")
                .Build()
            , new IDValue.Builder()
                .SetID("B")
                .SetValue("1")
                .Build()
            , new IDValue.Builder()
                .SetID("C")
                .SetValue("(1 + 100)/2")
                .Build()
            };
            feature_Define_glue_object.Then_should_be_equal_to_data(objectList4);
        }
    }
}

