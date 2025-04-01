namespace gherkinexecutor.Feature_Include{
[TestClass]
public class Feature_Include{


    [TestMethod]
    public void Test_Scenario_An_include(){
         Feature_Include_glue feature_Include_glue_object = new Feature_Include_glue();

        string string1 =
            """
            This is an include string from the main directory
            """.Trim();
        feature_Include_glue_object.Given_a_string_include(string1);

        string string2 =
            """
            This is an include string from the main directory
            """.Trim();
        feature_Include_glue_object.Then_should_be_equal_to(string2);
        }
    [TestMethod]
    public void Test_Scenario_An_include_from_base_directory(){
         Feature_Include_glue feature_Include_glue_object = new Feature_Include_glue();

        string string3 =
            """
            This is an include string from the main directory
            """.Trim();
        feature_Include_glue_object.Given_a_string_include(string3);

        string string4 =
            """
            This is an include string from the main directory
            """.Trim();
        feature_Include_glue_object.Then_should_be_equal_to(string4);
        }
    [TestMethod]
    public void Test_Scenario_An_include_of_CSV_file(){
         Feature_Include_glue feature_Include_glue_object = new Feature_Include_glue();

         List<CSVContents> objectList5 = new List<CSVContents>{
             new CSVContents.Builder()
                .SetA("a")
                .SetB("b,c")
                .SetC("d,")
                .Build()
            , new CSVContents.Builder()
                .SetA("1")
                .SetB("2")
                .SetC("3")
                .Build()
            };
        feature_Include_glue_object.Given_a_table(objectList5);

         List<CSVContents> objectList6 = new List<CSVContents>{
             new CSVContents.Builder()
                .SetA("a")
                .SetB("b,c")
                .SetC("d,")
                .Build()
            , new CSVContents.Builder()
                .SetA("1")
                .SetB("2")
                .SetC("3")
                .Build()
            };
        feature_Include_glue_object.Then_Should_be_equal_to_table(objectList6);
        }
    }
}

