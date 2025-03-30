namespace gherkinexecutor.Feature_Import{
class Feature_Import{


    [TestMethod]
    public void Test_Scenario_Use_an_import(){
         Feature_Import_glue feature_Import_glue_object = new Feature_Import_glue();

        List<ImportData> objectList1 = new List<ImportData>(
             new ImportData.Builder()
                .SetMyPattern("a.*")
                .SetMyWeekday("MONDAY")
                .SetMyBigInt("1")
                .Build()
            , new ImportData.Builder()
                .SetMyPattern("[ab]")
                .SetMyWeekday("SUNDAY")
                .SetMyBigInt("10000000000")
                .Build()
            );
        .Given_this_data_should_be_okay(objectList1);
        }
    [TestMethod]
    public void Test_Scenario_Should_fail(){
         Feature_Import_glue feature_Import_glue_object = new Feature_Import_glue();

        List<ImportData> objectList2 = new List<ImportData>(
             new ImportData.Builder()
                .SetMyPattern("a.*")
                .SetMyWeekday("SOMEONE")
                .SetMyBigInt("1")
                .Build()
            , new ImportData.Builder()
                .SetMyPattern("[ab]")
                .SetMyWeekday("SUNDAY")
                .SetMyBigInt("2")
                .Build()
            );
        .Given_this_data_should_fail(objectList2);
        }
    [TestMethod]
    public void Test_Scenario_Should_also_fail(){
         Feature_Import_glue feature_Import_glue_object = new Feature_Import_glue();

        List<ImportData> objectList3 = new List<ImportData>(
             new ImportData.Builder()
                .SetMyPattern("a.*")
                .SetMyWeekday("MONDAY")
                .SetMyBigInt("1")
                .Build()
            , new ImportData.Builder()
                .SetMyPattern("[ab]")
                .SetMyWeekday("SUNDAY")
                .SetMyBigInt("A.2")
                .Build()
            );
        .Given_this_data_should_fail(objectList3);
        }
    }
}

