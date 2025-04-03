namespace gherkinexecutor.Feature_Background
{
    [TestClass]
    public class Feature_Background
    {


        void Test_Background(Feature_Background_glue feature_Background_glue_object)
        {

            List<List<string>> stringListList1 = new List<List<string>>{
           new List<string>{
            "Background Here"
            }
            };
            feature_Background_glue_object.Given_Background_function_sets_a_value(stringListList1);
        }
        void Test_Cleanup(Feature_Background_glue feature_Background_glue_object)
        {

            List<List<string>> stringListList2 = new List<List<string>>{
           new List<string>{
            "Cleanup Here"
            }
            };
            feature_Background_glue_object.Given_value_for_cleanup_should_be_set_to(stringListList2);
        }
        [TestMethod]
        public void Test_Scenario_Should_have_Background_and_Cleanup()
        {
            Feature_Background_glue feature_Background_glue_object = new Feature_Background_glue();
            Test_Background(feature_Background_glue_object);

            feature_Background_glue_object.Given_a_regular_function();

            List<List<string>> stringListList4 = new List<List<string>>{
           new List<string>{
            "Background Here"
            }
            };
            feature_Background_glue_object.Then_background_should_set_value_to(stringListList4);

            List<List<string>> stringListList5 = new List<List<string>>{
           new List<string>{
            "Cleanup Here"
            }
            };
            feature_Background_glue_object.And_set_a_value_for_cleanup(stringListList5);
            Test_Cleanup(feature_Background_glue_object); // from previous
        }
        [TestMethod]
        public void Test_Scenario_Should_also_have_Background_and_Cleanup()
        {
            Feature_Background_glue feature_Background_glue_object = new Feature_Background_glue();
            Test_Background(feature_Background_glue_object);

            feature_Background_glue_object.Given_a_regular_function();

            List<List<string>> stringListList7 = new List<List<string>>{
           new List<string>{
            "Background Here"
            }
            };
            feature_Background_glue_object.Then_background_should_set_value_to(stringListList7);

            List<List<string>> stringListList8 = new List<List<string>>{
           new List<string>{
            "Cleanup Here"
            }
            };
            feature_Background_glue_object.And_set_a_value_for_cleanup(stringListList8);
            Test_Cleanup(feature_Background_glue_object); // at the end
        }
    }
}

