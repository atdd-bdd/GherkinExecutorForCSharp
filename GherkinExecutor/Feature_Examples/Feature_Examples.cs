namespace gherkinexecutor.Feature_Examples{
[TestClass]
public class Feature_Examples{


[TestMethod]
    public void Test_Scenario_Temperature_Conversion(){
         Feature_Examples_glue feature_Examples_glue_object = new Feature_Examples_glue();

         List<FandC> objectList1 = new List<FandC>{
             new FandC.Builder()
                .SetF("32")
                .SetC("0")
                .SetNotes("Freezing")
                .Build()
            , new FandC.Builder()
                .SetF("212")
                .SetC("100")
                .SetNotes("Boiling")
                .Build()
            , new FandC.Builder()
                .SetF("-40")
                .SetC("-40")
                .SetNotes("Below zero")
                .Build()
            };
        feature_Examples_glue_object.Calculation_Convert_F_to_C(objectList1);
        }
[TestMethod]
    public void Test_Scenario_Domain_Term_ID(){
         Feature_Examples_glue feature_Examples_glue_object = new Feature_Examples_glue();

         List<ValueValid> objectList2 = new List<ValueValid>{
             new ValueValid.Builder()
                .SetValue("Q1234")
                .SetValid("true")
                .SetNotes("")
                .Build()
            , new ValueValid.Builder()
                .SetValue("Q123")
                .SetValid("false")
                .SetNotes("Too short")
                .Build()
            , new ValueValid.Builder()
                .SetValue("Q12345")
                .SetValid("false")
                .SetNotes("Too long")
                .Build()
            , new ValueValid.Builder()
                .SetValue("A1234")
                .SetValid("false")
                .SetNotes("Must begin with Q")
                .Build()
            };
        feature_Examples_glue_object.Rule_ID_must_have_exactly_5_letters_and_begin_with_Q(objectList2);
        }
[TestMethod]
    public void Test_Scenario_Filter_Data(){
         Feature_Examples_glue feature_Examples_glue_object = new Feature_Examples_glue();

         List<LabelValue> objectList3 = new List<LabelValue>{
             new LabelValue.Builder()
                .SetID("Q1234")
                .SetValue("1")
                .Build()
            , new LabelValue.Builder()
                .SetID("Q9999")
                .SetValue("2")
                .Build()
            , new LabelValue.Builder()
                .SetID("Q1234")
                .SetValue("3")
                .Build()
            };
        feature_Examples_glue_object.Given_list_of_numbers(objectList3);

        List<List<string>> stringListList4 = new List<List<string>>{
           new List<string>{
            "Q1234"
            }
            };
        feature_Examples_glue_object.When_filtered_by_ID_with_value(stringListList4);

        List<List<string>> stringListList5 = new List<List<string>>{
           new List<string>{
            "4"
            }
            };
        feature_Examples_glue_object.Then_sum_is(stringListList5);
        }
[TestMethod]
    public void Test_Scenario_Filter_Data_Another_Way(){
         Feature_Examples_glue feature_Examples_glue_object = new Feature_Examples_glue();

         List<LabelValue> objectList6 = new List<LabelValue>{
             new LabelValue.Builder()
                .SetID("Q1234")
                .SetValue("1")
                .Build()
            , new LabelValue.Builder()
                .SetID("Q9999")
                .SetValue("2")
                .Build()
            , new LabelValue.Builder()
                .SetID("Q1234")
                .SetValue("3")
                .Build()
            };
        feature_Examples_glue_object.Given_list_of_numbers(objectList6);

         List<FilterValue> objectList7 = new List<FilterValue>{
             new FilterValue.Builder()
                .SetValue("Q1234")
                .Build()
            };
        feature_Examples_glue_object.When_filtered_by(objectList7);

         List<ResultValue> objectList8 = new List<ResultValue>{
             new ResultValue.Builder()
                .SetSum("4")
                .Build()
            };
        feature_Examples_glue_object.Then_result(objectList8);
        }
    }
}

