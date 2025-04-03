namespace gherkinexecutor.Feature_Tables_and_Strings
{
    [TestClass]
    public class Feature_Tables_and_Strings
    {


        [TestMethod]
        public void Test_Scenario_Here_are_string_options()
        {
            Feature_Tables_and_Strings_glue feature_Tables_and_Strings_glue_object = new Feature_Tables_and_Strings_glue();

            string string1 =
                """
            One line
            Two line
            """.Trim();
            feature_Tables_and_Strings_glue_object.Star_A_multiline_string_to_a_string(string1);

            List<string> stringList2 = new List<string>{
            "Three line"
            ,"Four line"
            };
            feature_Tables_and_Strings_glue_object.Star_A_multiline_string_to_a_List_of_String(stringList2);
        }
        [TestMethod]
        public void Test_Scenario_Check_String_Variations()
        {
            Feature_Tables_and_Strings_glue feature_Tables_and_Strings_glue_object = new Feature_Tables_and_Strings_glue();

            string string3 =
                """
            One line
            Two line
            """.Trim();
            feature_Tables_and_Strings_glue_object.Given_multiline_string(string3);

            List<string> stringList4 = new List<string>{
            "One line"
            ,"Two line"
            };
            feature_Tables_and_Strings_glue_object.Then_should_be_equal_to_this_list(stringList4);
        }
        [TestMethod]
        public void Test_Scenario_Here_are_table_options()
        {
            Feature_Tables_and_Strings_glue feature_Tables_and_Strings_glue_object = new Feature_Tables_and_Strings_glue();

            List<List<string>> stringListList5 = new List<List<string>>{
           new List<string>{
            "aa"
            ,"bb"
            }
           ,new List<string>{
            "cc"
            ,"dd"
            }
            };
            feature_Tables_and_Strings_glue_object.Star_A_table_to_List_of_List_of_String(stringListList5);

            List<List<string>> stringListList6 = new List<List<string>>{
           new List<string>{
            "1"
            ,"2"
            }
           ,new List<string>{
            "3"
            ,"4"
            }
           ,new List<string>{
            "5"
            ,"6"
            }
            };
            feature_Tables_and_Strings_glue_object.Star_A_Table_to_List_Of_List_Of_Object(stringListList6);

            List<ExampleClass> objectList7 = new List<ExampleClass>{
             new ExampleClass.Builder()
                .SetFieldA("a")
                .SetFieldB("b")
                .Build()
            , new ExampleClass.Builder()
                .SetFieldA("c")
                .SetFieldB("d")
                .Build()
            };
            feature_Tables_and_Strings_glue_object.Star_A_table_to_List_of_Object(objectList7);

            List<ExampleClass> objectList8 = new List<ExampleClass>{
             new ExampleClass.Builder()
                .SetFieldA("a")
                .SetFieldB("b")
                .Build()
            , new ExampleClass.Builder()
                .SetFieldA("c")
                .SetFieldB("d")
                .Build()
            };
            feature_Tables_and_Strings_glue_object.Star_A_table_to_List_of_Object(objectList8);

            List<ExampleClass> objectList9 = new List<ExampleClass>{
             new ExampleClass.Builder()
                .SetFieldA("a")
                .Build()
            , new ExampleClass.Builder()
                .SetFieldA("c")
                .Build()
            };
            feature_Tables_and_Strings_glue_object.Star_A_table_to_List_of_Object_with_Defaults(objectList9);

            List<ExampleClassWithBlanks> objectList10 = new List<ExampleClassWithBlanks>{
             new ExampleClassWithBlanks.Builder()
                .SetField_1(" ")
                .SetField_2("b")
                .Build()
            , new ExampleClassWithBlanks.Builder()
                .SetField_1("c")
                .SetField_2(" ")
                .Build()
            };
            feature_Tables_and_Strings_glue_object.Star_A_table_to_List_of_Object_with_Blanks_in_Values(objectList10);

            List<ExampleClassWithBlanks> objectList11 = new List<ExampleClassWithBlanks>{
             new ExampleClassWithBlanks.Builder()
                .SetField_1(" ")
                .Build()
            , new ExampleClassWithBlanks.Builder()
                .SetField_1("c")
                .Build()
            };
            feature_Tables_and_Strings_glue_object.Star_A_table_to_List_of_Object_with_Blanks_in_Defaults(objectList11);

            string table12 =
                """
            | aa  | bb  |
            | cc  | dd  |
            """.Trim();
            feature_Tables_and_Strings_glue_object.Star_A_table_to_String(table12);
        }
        [TestMethod]
        public void Test_Scenario_Table_to_String()
        {
            Feature_Tables_and_Strings_glue feature_Tables_and_Strings_glue_object = new Feature_Tables_and_Strings_glue();

            string table13 =
                """
            | aa  | bb  |
            | cc  | dd  |
            """.Trim();
            feature_Tables_and_Strings_glue_object.Given_A_table_to_String(table13);

            string string14 =
                """
            | aa  | bb  |
            | cc  | dd  |
            """.Trim();
            feature_Tables_and_Strings_glue_object.Then_string_should_be_same_as(string14);
        }
        [TestMethod]
        public void Test_Scenario_Table_without_all_fields_uses_defaults()
        {
            Feature_Tables_and_Strings_glue feature_Tables_and_Strings_glue_object = new Feature_Tables_and_Strings_glue();

            List<ExampleClass> objectList15 = new List<ExampleClass>{
             new ExampleClass.Builder()
                .SetFieldA("a")
                .Build()
            , new ExampleClass.Builder()
                .SetFieldA("c")
                .Build()
            };
            feature_Tables_and_Strings_glue_object.Given_A_table_to_List_of_Object_with_Defaults(objectList15);

            List<ExampleClass> objectList16 = new List<ExampleClass>{
             new ExampleClass.Builder()
                .SetFieldA("a")
                .SetFieldB("x")
                .Build()
            , new ExampleClass.Builder()
                .SetFieldA("c")
                .SetFieldB("x")
                .Build()
            };
            feature_Tables_and_Strings_glue_object.Then_table_should_be_same_as(objectList16);
        }
        [TestMethod]
        public void Test_Scenario_Transpose_Table()
        {
            Feature_Tables_and_Strings_glue feature_Tables_and_Strings_glue_object = new Feature_Tables_and_Strings_glue();

            List<ExampleClass> objectList17 = new List<ExampleClass>{
             new ExampleClass.Builder()
                .SetFieldA("a")
                .SetFieldB("b")
                .Build()
            , new ExampleClass.Builder()
                .SetFieldA("c")
                .SetFieldB("d")
                .Build()
            };
            feature_Tables_and_Strings_glue_object.Given_A_table_to_List_of_Object(objectList17);

            List<ExampleClass> objectList18 = new List<ExampleClass>{
             new ExampleClass.Builder()
                .SetFieldA("a")
                .SetFieldB("b")
                .Build()
            , new ExampleClass.Builder()
                .SetFieldA("c")
                .SetFieldB("d")
                .Build()
            };
            feature_Tables_and_Strings_glue_object.Then_transposed_table_to_List_of_Object_should_be_the_same(objectList18);
        }
    }
}

