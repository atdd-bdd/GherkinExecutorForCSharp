namespace gherkinexecutor.Feature_Full_Test{
using System.IO;
[TestClass
public class Feature_Full_Test{
       void Log(string value)
            {
           try
           {
           Directory.CreateDirectory("GherkinExecutor/Feature_Full_Test");
	       using (var myLog = new StreamWriter("GherkinExecutor/Feature_Full_Test/log.txt", true))
	           {
	           myLog.WriteLine(value);
		        }
		   }
		   catch (IOException e)
		     	{
			    Console.Error.WriteLine("*** Cannot write to log " + e);
		      	}
		    }

    [TestMethod]
    public void Test_Scenario_Simple_Comparison(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Simple_Comparison");

         List<ATest> objectList1 = new List<ATest>{
             new ATest.Builder()
                .SetAnInt("1")
                .SetAString("something")
                .SetADouble("1.2")
                .Build()
            };
        feature_Full_Test_glue_object.Given_table_is(objectList1);

         List<ATest> objectList2 = new List<ATest>{
             new ATest.Builder()
             .SetCompare()
                .SetAString("something")
                .Build()
            };
        feature_Full_Test_glue_object.When_compared_to(objectList2);

        List<List<string>> stringListList3 = new List<List<string>>{
           new List<string>{
            "true"
            }
            };
        feature_Full_Test_glue_object.Then_result_is(stringListList3);

         List<ATest> objectList4 = new List<ATest>{
             new ATest.Builder()
             .SetCompare()
                .SetAString("something else")
                .Build()
            };
        feature_Full_Test_glue_object.When_compared_to(objectList4);

        List<List<string>> stringListList5 = new List<List<string>>{
           new List<string>{
            "false"
            }
            };
        feature_Full_Test_glue_object.Then_result_is(stringListList5);
        }
    [TestMethod]
    public void Test_Scenario_Use_the_data_types(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Use_the_data_types");

         List<SomeTypes> objectList6 = new List<SomeTypes>{
             new SomeTypes.Builder()
                .SetAnInt("0")
                .SetADouble("0.0")
                .SetAChar("x")
                .SetAchar("y")
                .Build()
            , new SomeTypes.Builder()
                .SetAnInt("111")
                .SetADouble("222.2")
                .SetAChar("q")
                .SetAchar("")
                .Build()
            };
        feature_Full_Test_glue_object.Given_type_values_are(objectList6);

         List<SomeTypes> objectList7 = new List<SomeTypes>{
             new SomeTypes.Builder()
                .SetAchar("y")
                .SetAnInt("0")
                .SetADouble("0.0")
                .SetAChar("x")
                .Build()
            , new SomeTypes.Builder()
                .SetAchar("")
                .SetAnInt("111")
                .SetADouble("222.2")
                .SetAChar("q")
                .Build()
            };
        feature_Full_Test_glue_object.Then_this_should_be_equal(objectList7);
        }
    [TestMethod]
    public void Test_Scenario_Simple_Table_with_int_bad(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Simple_Table_with_int_bad");

         List<ATest> objectList8 = new List<ATest>{
             new ATest.Builder()
                .SetAnInt("q")
                .SetAString("something")
                .SetADouble("1.1")
                .Build()
            };
        feature_Full_Test_glue_object.Given_table_is(objectList8);
        }
    [TestMethod]
    public void Test_Scenario_Simple_Table_with_double_bad(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Simple_Table_with_double_bad");

         List<ATest> objectList9 = new List<ATest>{
             new ATest.Builder()
                .SetAnInt("1")
                .SetAString("something")
                .SetADouble("r")
                .Build()
            };
        feature_Full_Test_glue_object.Given_table_is(objectList9);
        }
    [TestMethod]
    public void Test_Scenario_Simple_Table_with_initializer_bad(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Simple_Table_with_initializer_bad");

         List<ATestBad> objectList10 = new List<ATestBad>{
             new ATestBad.Builder()
                .SetAnInt("1")
                .Build()
            };
        feature_Full_Test_glue_object.Given_table_is_bad_initializer(objectList10);
        }
    [TestMethod]
    public void Test_Scenario_Simple_Replacement(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Simple_Replacement");

         List<IDValue> objectList11 = new List<IDValue>{
             new IDValue.Builder()
                .SetID("A")
                .SetValue("100")
                .Build()
            , new IDValue.Builder()
                .SetID("B")
                .SetValue("1")
                .Build()
            };
        feature_Full_Test_glue_object.Given_this_data(objectList11);

         List<IDValue> objectList12 = new List<IDValue>{
             new IDValue.Builder()
                .SetID("A")
                .SetValue("100")
                .Build()
            , new IDValue.Builder()
                .SetID("B")
                .SetValue("1")
                .Build()
            };
        feature_Full_Test_glue_object.Then_should_be_equal_to_data(objectList12);
        }
    [TestMethod]
    public void Test_Scenario_Try_out_replacements_with_a_calculation(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Try_out_replacements_with_a_calculation");

         List<IDValue> objectList13 = new List<IDValue>{
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
        feature_Full_Test_glue_object.Given_this_data(objectList13);

         List<IDValue> objectList14 = new List<IDValue>{
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
        feature_Full_Test_glue_object.Then_should_be_equal_to_data(objectList14);
        }
    [TestMethod]
    public void Test_Scenario_Temperature_Conversion(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Temperature_Conversion");

         List<FandC> objectList15 = new List<FandC>{
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
        feature_Full_Test_glue_object.Calculation_Convert_F_to_C(objectList15);
        }
    [TestMethod]
    public void Test_Scenario_Domain_Term_ID(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Domain_Term_ID");

         List<ValueValid> objectList16 = new List<ValueValid>{
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
        feature_Full_Test_glue_object.Rule_ID_must_have_exactly_5_letters_and_begin_with_Q(objectList16);
        }
    [TestMethod]
    public void Test_Scenario_Filter_Data(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Filter_Data");

         List<LabelValue> objectList17 = new List<LabelValue>{
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
        feature_Full_Test_glue_object.Given_list_of_numbers(objectList17);

        List<List<string>> stringListList18 = new List<List<string>>{
           new List<string>{
            "Q1234"
            }
            };
        feature_Full_Test_glue_object.When_filtered_by_ID_with_value(stringListList18);

        List<List<string>> stringListList19 = new List<List<string>>{
           new List<string>{
            "4"
            }
            };
        feature_Full_Test_glue_object.Then_sum_is(stringListList19);
        }
    [TestMethod]
    public void Test_Scenario_Filter_Data_Another_Way(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Filter_Data_Another_Way");

         List<LabelValue> objectList20 = new List<LabelValue>{
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
        feature_Full_Test_glue_object.Given_list_of_numbers(objectList20);

         List<FilterValue> objectList21 = new List<FilterValue>{
             new FilterValue.Builder()
                .SetValue("Q1234")
                .Build()
            };
        feature_Full_Test_glue_object.When_filtered_by(objectList21);

         List<ResultValue> objectList22 = new List<ResultValue>{
             new ResultValue.Builder()
                .SetSum("4")
                .Build()
            };
        feature_Full_Test_glue_object.Then_result(objectList22);
        }
    [TestMethod]
    public void Test_Scenario_Use_an_import(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Use_an_import");

         List<ImportData> objectList23 = new List<ImportData>{
             new ImportData.Builder()
                .SetMyWeekday("Monday")
                .SetMyBigInt("1")
                .Build()
            , new ImportData.Builder()
                .SetMyWeekday("Sunday")
                .SetMyBigInt("10000000000")
                .Build()
            };
        feature_Full_Test_glue_object.Given_this_data_should_be_okay(objectList23);
        }
    [TestMethod]
    public void Test_Scenario_Should_fail(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Should_fail");

         List<ImportData> objectList24 = new List<ImportData>{
             new ImportData.Builder()
                .SetMyWeekday("Humpday")
                .SetMyBigInt("1")
                .Build()
            , new ImportData.Builder()
                .SetMyWeekday("Sunday")
                .SetMyBigInt("2")
                .Build()
            };
        feature_Full_Test_glue_object.Given_this_data_should_fail(objectList24);
        }
    [TestMethod]
    public void Test_Scenario_Should_also_fail(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Should_also_fail");

         List<ImportData> objectList25 = new List<ImportData>{
             new ImportData.Builder()
                .SetMyWeekday("Monday")
                .SetMyBigInt("1")
                .Build()
            , new ImportData.Builder()
                .SetMyWeekday("Sunday")
                .SetMyBigInt("A.2")
                .Build()
            };
        feature_Full_Test_glue_object.Given_this_data_should_fail(objectList25);
        }
    [TestMethod]
    public void Test_Scenario_An_include(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_An_include");

        string string26 =
            """
            This is an include string from the main directory
            """.Trim();
        feature_Full_Test_glue_object.Given_a_string_include(string26);

        string string27 =
            """
            This is an include string from the main directory
            """.Trim();
        feature_Full_Test_glue_object.Then_should_be_equal_to(string27);
        }
    [TestMethod]
    public void Test_Scenario_An_include_from_base_directory(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_An_include_from_base_directory");

        string string28 =
            """
            This is an include string from the main directory
            """.Trim();
        feature_Full_Test_glue_object.Given_a_string_include(string28);

        string string29 =
            """
            This is an include string from the main directory
            """.Trim();
        feature_Full_Test_glue_object.Then_should_be_equal_to(string29);
        }
    [TestMethod]
    public void Test_Scenario_An_include_of_CSV_file(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_An_include_of_CSV_file");

         List<CSVContents> objectList30 = new List<CSVContents>{
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
        feature_Full_Test_glue_object.Given_a_table(objectList30);

         List<CSVContents> objectList31 = new List<CSVContents>{
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
        feature_Full_Test_glue_object.Then_Should_be_equal_to_table(objectList31);
        }
    [TestMethod]
    public void Test_Scenario_Simple(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Simple");

         List<ATest> objectList32 = new List<ATest>{
             new ATest.Builder()
                .SetAnInt("1")
                .SetAString("something")
                .SetADouble("1.2")
                .Build()
            };
        feature_Full_Test_glue_object.Given_table_is(objectList32);
        }
    [TestMethod]
    public void Test_Scenario_Here_are_string_options(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Here_are_string_options");

        string string33 =
            """
            One line
            Two line
            """.Trim();
        feature_Full_Test_glue_object.Star_A_multiline_string_to_a_string(string33);

        List<string> stringList34 = new List<string>{
            "Three line"
            ,"Four line"
            };
        feature_Full_Test_glue_object.Star_A_multiline_string_to_a_List_of_String(stringList34);
        }
    [TestMethod]
    public void Test_Scenario_Check_String_Variations(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Check_String_Variations");

        string string35 =
            """
            One line
            Two line
            """.Trim();
        feature_Full_Test_glue_object.Given_multiline_string(string35);

        List<string> stringList36 = new List<string>{
            "One line"
            ,"Two line"
            };
        feature_Full_Test_glue_object.Then_should_be_equal_to_this_list(stringList36);
        }
    [TestMethod]
    public void Test_Scenario_Here_are_table_options(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Here_are_table_options");

        List<List<string>> stringListList37 = new List<List<string>>{
           new List<string>{
            "aa"
            ,"bb"
            }
           ,new List<string>{
            "cc"
            ,"dd"
            }
            };
        feature_Full_Test_glue_object.Star_A_table_to_List_of_List_of_String(stringListList37);

        List<List<string>> stringListList38 = new List<List<string>>{
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
        feature_Full_Test_glue_object.Star_A_Table_to_List_Of_List_Of_Object(stringListList38);

         List<ExampleClass> objectList39 = new List<ExampleClass>{
             new ExampleClass.Builder()
                .SetFieldA("a")
                .SetFieldB("b")
                .Build()
            , new ExampleClass.Builder()
                .SetFieldA("c")
                .SetFieldB("d")
                .Build()
            };
        feature_Full_Test_glue_object.Star_A_table_to_List_of_Object(objectList39);

         List<ExampleClass> objectList40 = new List<ExampleClass>{
             new ExampleClass.Builder()
                .SetFieldA("a")
                .SetFieldB("b")
                .Build()
            , new ExampleClass.Builder()
                .SetFieldA("c")
                .SetFieldB("d")
                .Build()
            };
        feature_Full_Test_glue_object.Star_A_table_to_List_of_Object(objectList40);

         List<ExampleClass> objectList41 = new List<ExampleClass>{
             new ExampleClass.Builder()
                .SetFieldA("a")
                .Build()
            , new ExampleClass.Builder()
                .SetFieldA("c")
                .Build()
            };
        feature_Full_Test_glue_object.Star_A_table_to_List_of_Object_with_Defaults(objectList41);

         List<ExampleClassWithBlanks> objectList42 = new List<ExampleClassWithBlanks>{
             new ExampleClassWithBlanks.Builder()
                .SetField_1(" ")
                .SetField_2("b")
                .Build()
            , new ExampleClassWithBlanks.Builder()
                .SetField_1("c")
                .SetField_2(" ")
                .Build()
            };
        feature_Full_Test_glue_object.Star_A_table_to_List_of_Object_with_Blanks_in_Values(objectList42);

         List<ExampleClassWithBlanks> objectList43 = new List<ExampleClassWithBlanks>{
             new ExampleClassWithBlanks.Builder()
                .SetField_1(" ")
                .Build()
            , new ExampleClassWithBlanks.Builder()
                .SetField_1("c")
                .Build()
            };
        feature_Full_Test_glue_object.Star_A_table_to_List_of_Object_with_Blanks_in_Defaults(objectList43);

        string table44 =
            """
            | aa  | bb  |
            | cc  | dd  |
            """.Trim();
        feature_Full_Test_glue_object.Star_A_table_to_String(table44);
        }
    [TestMethod]
    public void Test_Scenario_Table_to_String(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Table_to_String");

        string table45 =
            """
            | aa  | bb  |
            | cc  | dd  |
            """.Trim();
        feature_Full_Test_glue_object.Given_A_table_to_String(table45);

        string string46 =
            """
            | aa  | bb  |
            | cc  | dd  |
            """.Trim();
        feature_Full_Test_glue_object.Then_string_should_be_same_as(string46);
        }
    [TestMethod]
    public void Test_Scenario_Table_without_all_fields_uses_defaults(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Table_without_all_fields_uses_defaults");

         List<ExampleClass> objectList47 = new List<ExampleClass>{
             new ExampleClass.Builder()
                .SetFieldA("a")
                .Build()
            , new ExampleClass.Builder()
                .SetFieldA("c")
                .Build()
            };
        feature_Full_Test_glue_object.Given_A_table_to_List_of_Object_with_Defaults(objectList47);

         List<ExampleClass> objectList48 = new List<ExampleClass>{
             new ExampleClass.Builder()
                .SetFieldA("a")
                .SetFieldB("x")
                .Build()
            , new ExampleClass.Builder()
                .SetFieldA("c")
                .SetFieldB("x")
                .Build()
            };
        feature_Full_Test_glue_object.Then_table_should_be_same_as(objectList48);
        }
    [TestMethod]
    public void Test_Scenario_Transpose_Table(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Transpose_Table");

         List<ExampleClass> objectList49 = new List<ExampleClass>{
             new ExampleClass.Builder()
                .SetFieldA("a")
                .SetFieldB("b")
                .Build()
            , new ExampleClass.Builder()
                .SetFieldA("c")
                .SetFieldB("d")
                .Build()
            };
        feature_Full_Test_glue_object.Given_A_table_to_List_of_Object(objectList49);

         List<ExampleClass> objectList50 = new List<ExampleClass>{
             new ExampleClass.Builder()
                .SetFieldA("a")
                .SetFieldB("b")
                .Build()
            , new ExampleClass.Builder()
                .SetFieldA("c")
                .SetFieldB("d")
                .Build()
            };
        feature_Full_Test_glue_object.Then_transposed_table_to_List_of_Object_should_be_the_same(objectList50);
        }
    [TestMethod]
    public void Test_Scenario_Make_a_move(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Make_a_move");

        List<List<string>> stringListList51 = new List<List<string>>{
           new List<string>{
            ""
            ,""
            ,""
            }
           ,new List<string>{
            ""
            ,""
            ,""
            }
           ,new List<string>{
            ""
            ,""
            ,""
            }
            };
        feature_Full_Test_glue_object.Given_board_is(stringListList51);

         List<Move> objectList52 = new List<Move>{
             new Move.Builder()
                .SetRow("1")
                .SetColumn("2")
                .SetMark("X")
                .Build()
            };
        feature_Full_Test_glue_object.When_move_is(objectList52);

        string table53 =
            """
            |   | X  |   |
            |   |    |   |
            |   |    |   |
            """.Trim();
        feature_Full_Test_glue_object.Then_board_is_now(table53);
        }
    [TestMethod]
    public void Test_Scenario_Make_a_move_using_single_element(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Make_a_move_using_single_element");

        List<List<string>> stringListList54 = new List<List<string>>{
           new List<string>{
            ""
            ,""
            ,""
            }
           ,new List<string>{
            ""
            ,""
            ,""
            }
           ,new List<string>{
            ""
            ,""
            ,""
            }
            };
        feature_Full_Test_glue_object.Given_board_is(stringListList54);

        List<List<string>> stringListList55 = new List<List<string>>{
           new List<string>{
            "1,2,X"
            }
            };
        feature_Full_Test_glue_object.When_one_move_is(stringListList55);

        string table56 =
            """
            |   | X  |   |
            |   |    |   |
            |   |    |   |
            """.Trim();
        feature_Full_Test_glue_object.Then_board_is_now(table56);
        }
    [TestMethod]
    public void Test_Scenario_Make_multiple_moves(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Make_multiple_moves");

        List<List<string>> stringListList57 = new List<List<string>>{
           new List<string>{
            ""
            ,""
            ,""
            }
           ,new List<string>{
            ""
            ,""
            ,""
            }
           ,new List<string>{
            ""
            ,""
            ,""
            }
            };
        feature_Full_Test_glue_object.Given_board_is(stringListList57);

         List<Move> objectList58 = new List<Move>{
             new Move.Builder()
                .SetRow("1")
                .SetColumn("2")
                .SetMark("X")
                .Build()
            , new Move.Builder()
                .SetRow("2")
                .SetColumn("3")
                .SetMark("O")
                .Build()
            };
        feature_Full_Test_glue_object.When_moves_are(objectList58);

        string table59 =
            """
            |   | X  |    |
            |   |    | O  |
            |   |    |    |
            """.Trim();
        feature_Full_Test_glue_object.Then_board_is_now(table59);
        }
    [TestMethod]
    public void Test_Scenario_check_the_prints_to_see_how_it_works(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_check_the_prints_to_see_how_it_works");

        List<List<string>> stringListList60 = new List<List<string>>{
           new List<string>{
            "0"
            ,"x"
            ,"0"
            }
           ,new List<string>{
            "x"
            ,"0"
            ,"x"
            }
           ,new List<string>{
            "0"
            ,"x"
            ,"0"
            }
            };
        feature_Full_Test_glue_object.Given_board_is(stringListList60);

        string table61 =
            """
            | 0  | x  | 0  |
            | x  | 0  | x  |
            | 0  | x  | 0  |
            """.Trim();
        feature_Full_Test_glue_object.Then_board_is_now(table61);
        }
    [TestMethod]
    public void Test_Scenario_Convert_to_Json(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Convert_to_Json");

         List<SimpleClass> objectList62 = new List<SimpleClass>{
             new SimpleClass.Builder()
                .SetAnInt("1")
                .SetAString("B")
                .Build()
            };
        feature_Full_Test_glue_object.Given_one_object_is(objectList62);

        string string63 =
            """
            {anInt:"1",aString:"B"}
            """.Trim();
        feature_Full_Test_glue_object.Then_Json_should_be(string63);
        }
    [TestMethod]
    public void Test_Scenario_Convert_from_Json(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Convert_from_Json");

        string string64 =
            """
            {anInt:  "1"   ,   aString:"B"  }
            """.Trim();
        feature_Full_Test_glue_object.Given_Json_is(string64);

         List<SimpleClass> objectList65 = new List<SimpleClass>{
             new SimpleClass.Builder()
                .SetAnInt("1")
                .SetAString("B")
                .Build()
            };
        feature_Full_Test_glue_object.Then_the_converted_object_is(objectList65);
        }
    [TestMethod]
    public void Test_Scenario_Convert_to_Json_Array(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Convert_to_Json_Array");

         List<SimpleClass> objectList66 = new List<SimpleClass>{
             new SimpleClass.Builder()
                .SetAnInt("1")
                .SetAString("B")
                .Build()
            , new SimpleClass.Builder()
                .SetAnInt("2")
                .SetAString("C")
                .Build()
            };
        feature_Full_Test_glue_object.Given_a_table_is(objectList66);

        string string67 =
            """
            [ {anInt:"1",aString:"B"}
            , {anInt:"2",aString:"C"}
            ]
            """.Trim();
        feature_Full_Test_glue_object.Then_Json_for_table_should_be(string67);
        }
    [TestMethod]
    public void Test_Scenario_Convert_from_Json_Array(){
         Feature_Full_Test_glue feature_Full_Test_glue_object = new Feature_Full_Test_glue();
        Log("Scenario_Convert_from_Json_Array");

        string string68 =
            """
            [    {anInt:  "1"   ,   aString:"B"  },
            {anInt:  "2"   ,   aString:"C"  }
            ]
            """.Trim();
        feature_Full_Test_glue_object.Given_Json_for_table_is(string68);

         List<SimpleClass> objectList69 = new List<SimpleClass>{
             new SimpleClass.Builder()
                .SetAnInt("1")
                .SetAString("B")
                .Build()
            , new SimpleClass.Builder()
                .SetAnInt("2")
                .SetAString("C")
                .Build()
            };
        feature_Full_Test_glue_object.Then_the_converted_table_should_be(objectList69);
        }
    }
}

