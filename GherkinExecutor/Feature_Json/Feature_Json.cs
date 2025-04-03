namespace gherkinexecutor.Feature_Json
{
    [TestClass]
    public class Feature_Json
    {


        [TestMethod]
        public void Test_Scenario_Convert_to_Json()
        {
            Feature_Json_glue feature_Json_glue_object = new Feature_Json_glue();

            List<SimpleClass> objectList1 = new List<SimpleClass>{
             new SimpleClass.Builder()
                .SetAnInt("1")
                .SetAString("B")
                .Build()
            };
            feature_Json_glue_object.Given_one_object_is(objectList1);

            string string2 =
                """
            {anInt:"1",aString:"B"}
            """.Trim();
            feature_Json_glue_object.Then_Json_should_be(string2);
        }
        [TestMethod]
        public void Test_Scenario_Convert_from_Json()
        {
            Feature_Json_glue feature_Json_glue_object = new Feature_Json_glue();

            string string3 =
                """
            {anInt:  "1"   ,   aString:"B"  }
            """.Trim();
            feature_Json_glue_object.Given_Json_is(string3);

            List<SimpleClass> objectList4 = new List<SimpleClass>{
             new SimpleClass.Builder()
                .SetAnInt("1")
                .SetAString("B")
                .Build()
            };
            feature_Json_glue_object.Then_the_converted_object_is(objectList4);
        }
        [TestMethod]
        public void Test_Scenario_Convert_to_Json_Array()
        {
            Feature_Json_glue feature_Json_glue_object = new Feature_Json_glue();

            List<SimpleClass> objectList5 = new List<SimpleClass>{
             new SimpleClass.Builder()
                .SetAnInt("1")
                .SetAString("B")
                .Build()
            , new SimpleClass.Builder()
                .SetAnInt("2")
                .SetAString("C")
                .Build()
            };
            feature_Json_glue_object.Given_a_table_is(objectList5);

            string string6 =
                """
            [ {anInt:"1",aString:"B"}
            , {anInt:"2",aString:"C"}
            ]
            """.Trim();
            feature_Json_glue_object.Then_Json_for_table_should_be(string6);
        }
        [TestMethod]
        public void Test_Scenario_Convert_from_Json_Array()
        {
            Feature_Json_glue feature_Json_glue_object = new Feature_Json_glue();

            string string7 =
                """
            [    {anInt:  "1"   ,   aString:"B"  },
            {anInt:  "2"   ,   aString:"C"  }
            ]
            """.Trim();
            feature_Json_glue_object.Given_Json_for_table_is(string7);

            List<SimpleClass> objectList8 = new List<SimpleClass>{
             new SimpleClass.Builder()
                .SetAnInt("1")
                .SetAString("B")
                .Build()
            , new SimpleClass.Builder()
                .SetAnInt("2")
                .SetAString("C")
                .Build()
            };
            feature_Json_glue_object.Then_the_converted_table_should_be(objectList8);
        }
    }
}

