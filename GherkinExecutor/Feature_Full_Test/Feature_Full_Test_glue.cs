namespace gherkinexecutor.Feature_Full_Test {
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using System.IO;

public class Feature_Full_Test_glue {
    const string DNCString = "?DNC?";
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

    public void Given_table_is(List<ATest> values ) {
        Console.WriteLine("---  " + "Given_table_is");
        Log("---  " + "Given_table_is");
        foreach (ATest value in values){
                  Log(value.ToString());}
        foreach (ATest value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              ATestInternal i = value.ToATestInternal();
              }
    }

    public void When_compared_to(List<ATest> values ) {
        Console.WriteLine("---  " + "When_compared_to");
        Log("---  " + "When_compared_to");
        foreach (ATest value in values){
                  Log(value.ToString());}
        foreach (ATest value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              ATestInternal i = value.ToATestInternal();
              }
    }

    public void Then_result_is(List<List<string>> values ) {
        Console.WriteLine("---  " + "Then_result_is");
        Log("---  " + "Then_result_is");
        foreach (List<string> value in values){
                  Log(string.Join("|", value));}
        foreach (List<string> value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              }
    }

    public void Given_type_values_are(List<SomeTypes> values ) {
        Console.WriteLine("---  " + "Given_type_values_are");
        Log("---  " + "Given_type_values_are");
        foreach (SomeTypes value in values){
                  Log(value.ToString());}
        foreach (SomeTypes value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              SomeTypesInternal i = value.ToSomeTypesInternal();
              }
    }

    public void Then_this_should_be_equal(List<SomeTypes> values ) {
        Console.WriteLine("---  " + "Then_this_should_be_equal");
        Log("---  " + "Then_this_should_be_equal");
        foreach (SomeTypes value in values){
                  Log(value.ToString());}
        foreach (SomeTypes value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              SomeTypesInternal i = value.ToSomeTypesInternal();
              }
    }

    public void Given_table_is_bad_initializer(List<ATestBad> values ) {
        Console.WriteLine("---  " + "Given_table_is_bad_initializer");
        Log("---  " + "Given_table_is_bad_initializer");
        foreach (ATestBad value in values){
                  Log(value.ToString());}
        foreach (ATestBad value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              ATestBadInternal i = value.ToATestBadInternal();
              }
    }

    public void Given_this_data(List<IDValue> values ) {
        Console.WriteLine("---  " + "Given_this_data");
        Log("---  " + "Given_this_data");
        foreach (IDValue value in values){
                  Log(value.ToString());}
        foreach (IDValue value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              }
    }

    public void Then_should_be_equal_to_data(List<IDValue> values ) {
        Console.WriteLine("---  " + "Then_should_be_equal_to_data");
        Log("---  " + "Then_should_be_equal_to_data");
        foreach (IDValue value in values){
                  Log(value.ToString());}
        foreach (IDValue value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              }
    }

    public void Calculation_Convert_F_to_C(List<FandC> values ) {
        Console.WriteLine("---  " + "Calculation_Convert_F_to_C");
        Log("---  " + "Calculation_Convert_F_to_C");
        foreach (FandC value in values){
                  Log(value.ToString());}
        foreach (FandC value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              FandCInternal i = value.ToFandCInternal();
              }
    }

    public void Rule_ID_must_have_exactly_5_letters_and_begin_with_Q(List<ValueValid> values ) {
        Console.WriteLine("---  " + "Rule_ID_must_have_exactly_5_letters_and_begin_with_Q");
        Log("---  " + "Rule_ID_must_have_exactly_5_letters_and_begin_with_Q");
        foreach (ValueValid value in values){
                  Log(value.ToString());}
        foreach (ValueValid value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              ValueValidInternal i = value.ToValueValidInternal();
              }
    }

    public void Given_list_of_numbers(List<LabelValue> values ) {
        Console.WriteLine("---  " + "Given_list_of_numbers");
        Log("---  " + "Given_list_of_numbers");
        foreach (LabelValue value in values){
                  Log(value.ToString());}
        foreach (LabelValue value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              LabelValueInternal i = value.ToLabelValueInternal();
              }
    }

    public void When_filtered_by_ID_with_value(List<List<string>> values ) {
        Console.WriteLine("---  " + "When_filtered_by_ID_with_value");
        Log("---  " + "When_filtered_by_ID_with_value");
        foreach (List<string> value in values){
                  Log(string.Join("|", value));}
        foreach (List<string> value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              }
    }

    public void Then_sum_is(List<List<string>> values ) {
        Console.WriteLine("---  " + "Then_sum_is");
        Log("---  " + "Then_sum_is");
        foreach (List<string> value in values){
                  Log(string.Join("|", value));}
        foreach (List<string> value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              }
    }

    public void When_filtered_by(List<FilterValue> values ) {
        Console.WriteLine("---  " + "When_filtered_by");
        Log("---  " + "When_filtered_by");
        foreach (FilterValue value in values){
                  Log(value.ToString());}
        foreach (FilterValue value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              FilterValueInternal i = value.ToFilterValueInternal();
              }
    }

    public void Then_result(List<ResultValue> values ) {
        Console.WriteLine("---  " + "Then_result");
        Log("---  " + "Then_result");
        foreach (ResultValue value in values){
                  Log(value.ToString());}
        foreach (ResultValue value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              ResultValueInternal i = value.ToResultValueInternal();
              }
    }

    public void Given_this_data_should_be_okay(List<ImportData> values ) {
        Console.WriteLine("---  " + "Given_this_data_should_be_okay");
        Log("---  " + "Given_this_data_should_be_okay");
        foreach (ImportData value in values){
                  Log(value.ToString());}
        foreach (ImportData value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              ImportDataInternal i = value.ToImportDataInternal();
              }
    }

    public void Given_this_data_should_fail(List<ImportData> values ) {
        Console.WriteLine("---  " + "Given_this_data_should_fail");
        Log("---  " + "Given_this_data_should_fail");
        foreach (ImportData value in values){
                  Log(value.ToString());}
        foreach (ImportData value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              ImportDataInternal i = value.ToImportDataInternal();
              }
    }

    public void Given_a_string_include(string value ) {
        Console.WriteLine("---  " + "Given_a_string_include");
        Log("---  " + "Given_a_string_include");
        Log(value.ToString());
        Console.WriteLine(value);
    }

    public void Then_should_be_equal_to(string value ) {
        Console.WriteLine("---  " + "Then_should_be_equal_to");
        Log("---  " + "Then_should_be_equal_to");
        Log(value.ToString());
        Console.WriteLine(value);
    }

    public void Given_a_table(List<CSVContents> values ) {
        Console.WriteLine("---  " + "Given_a_table");
        Log("---  " + "Given_a_table");
        foreach (CSVContents value in values){
                  Log(value.ToString());}
        foreach (CSVContents value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              }
    }

    public void Then_Should_be_equal_to_table(List<CSVContents> values ) {
        Console.WriteLine("---  " + "Then_Should_be_equal_to_table");
        Log("---  " + "Then_Should_be_equal_to_table");
        foreach (CSVContents value in values){
                  Log(value.ToString());}
        foreach (CSVContents value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              }
    }

    public void Star_A_multiline_string_to_a_string(string value ) {
        Console.WriteLine("---  " + "Star_A_multiline_string_to_a_string");
        Log("---  " + "Star_A_multiline_string_to_a_string");
        Log(value.ToString());
        Console.WriteLine(value);
    }

    public void Star_A_multiline_string_to_a_List_of_String(List<string> values ) {
        Console.WriteLine("---  " + "Star_A_multiline_string_to_a_List_of_String");
        Log("---  " + "Star_A_multiline_string_to_a_List_of_String");
        foreach (String value in values){
                  Log(value.ToString());}
        foreach (String value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              }
    }

    public void Given_multiline_string(string value ) {
        Console.WriteLine("---  " + "Given_multiline_string");
        Log("---  " + "Given_multiline_string");
        Log(value.ToString());
        Console.WriteLine(value);
    }

    public void Then_should_be_equal_to_this_list(List<string> values ) {
        Console.WriteLine("---  " + "Then_should_be_equal_to_this_list");
        Log("---  " + "Then_should_be_equal_to_this_list");
        foreach (String value in values){
                  Log(value.ToString());}
        foreach (String value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              }
    }

    public void Star_A_table_to_List_of_List_of_String(List<List<string>> values ) {
        Console.WriteLine("---  " + "Star_A_table_to_List_of_List_of_String");
        Log("---  " + "Star_A_table_to_List_of_List_of_String");
        foreach (List<string> value in values){
                  Log(string.Join("|", value));}
        foreach (List<string> value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              }
    }

    public void Star_A_Table_to_List_Of_List_Of_Object(List<List<string>> values ) {
    List<List<Int32>> im = ConvertList(values);
    Console.WriteLine(im);
        Log("---  " + "Star_A_Table_to_List_Of_List_Of_Object");
    }

    public void Star_A_table_to_List_of_Object(List<ExampleClass> values ) {
        Console.WriteLine("---  " + "Star_A_table_to_List_of_Object");
        Log("---  " + "Star_A_table_to_List_of_Object");
        foreach (ExampleClass value in values){
                  Log(value.ToString());}
        foreach (ExampleClass value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              }
    }

    public void Star_A_table_to_List_of_Object_with_Defaults(List<ExampleClass> values ) {
        Console.WriteLine("---  " + "Star_A_table_to_List_of_Object_with_Defaults");
        Log("---  " + "Star_A_table_to_List_of_Object_with_Defaults");
        foreach (ExampleClass value in values){
                  Log(value.ToString());}
        foreach (ExampleClass value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              }
    }

    public void Star_A_table_to_List_of_Object_with_Blanks_in_Values(List<ExampleClassWithBlanks> values ) {
        Console.WriteLine("---  " + "Star_A_table_to_List_of_Object_with_Blanks_in_Values");
        Log("---  " + "Star_A_table_to_List_of_Object_with_Blanks_in_Values");
        foreach (ExampleClassWithBlanks value in values){
                  Log(value.ToString());}
        foreach (ExampleClassWithBlanks value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              }
    }

    public void Star_A_table_to_List_of_Object_with_Blanks_in_Defaults(List<ExampleClassWithBlanks> values ) {
        Console.WriteLine("---  " + "Star_A_table_to_List_of_Object_with_Blanks_in_Defaults");
        Log("---  " + "Star_A_table_to_List_of_Object_with_Blanks_in_Defaults");
        foreach (ExampleClassWithBlanks value in values){
                  Log(value.ToString());}
        foreach (ExampleClassWithBlanks value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              }
    }

    public void Star_A_table_to_String(string value ) {
        Console.WriteLine("---  " + "Star_A_table_to_String");
        Log("---  " + "Star_A_table_to_String");
        Log(value.ToString());
        Console.WriteLine(value);
    }

    public void Given_A_table_to_String(string value ) {
        Console.WriteLine("---  " + "Given_A_table_to_String");
        Log("---  " + "Given_A_table_to_String");
        Log(value.ToString());
        Console.WriteLine(value);
    }

    public void Then_string_should_be_same_as(string value ) {
        Console.WriteLine("---  " + "Then_string_should_be_same_as");
        Log("---  " + "Then_string_should_be_same_as");
        Log(value.ToString());
        Console.WriteLine(value);
    }

    public void Given_A_table_to_List_of_Object_with_Defaults(List<ExampleClass> values ) {
        Console.WriteLine("---  " + "Given_A_table_to_List_of_Object_with_Defaults");
        Log("---  " + "Given_A_table_to_List_of_Object_with_Defaults");
        foreach (ExampleClass value in values){
                  Log(value.ToString());}
        foreach (ExampleClass value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              }
    }

    public void Then_table_should_be_same_as(List<ExampleClass> values ) {
        Console.WriteLine("---  " + "Then_table_should_be_same_as");
        Log("---  " + "Then_table_should_be_same_as");
        foreach (ExampleClass value in values){
                  Log(value.ToString());}
        foreach (ExampleClass value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              }
    }

    public void Given_A_table_to_List_of_Object(List<ExampleClass> values ) {
        Console.WriteLine("---  " + "Given_A_table_to_List_of_Object");
        Log("---  " + "Given_A_table_to_List_of_Object");
        foreach (ExampleClass value in values){
                  Log(value.ToString());}
        foreach (ExampleClass value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              }
    }

    public void Then_transposed_table_to_List_of_Object_should_be_the_same(List<ExampleClass> values ) {
        Console.WriteLine("---  " + "Then_transposed_table_to_List_of_Object_should_be_the_same");
        Log("---  " + "Then_transposed_table_to_List_of_Object_should_be_the_same");
        foreach (ExampleClass value in values){
                  Log(value.ToString());}
        foreach (ExampleClass value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              }
    }

    public void Given_board_is(List<List<string>> values ) {
        Console.WriteLine("---  " + "Given_board_is");
        Log("---  " + "Given_board_is");
        foreach (List<string> value in values){
                  Log(string.Join("|", value));}
        foreach (List<string> value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              }
    }

    public void When_move_is(List<Move> values ) {
        Console.WriteLine("---  " + "When_move_is");
        Log("---  " + "When_move_is");
        foreach (Move value in values){
                  Log(value.ToString());}
        foreach (Move value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              MoveInternal i = value.ToMoveInternal();
              }
    }

    public void Then_board_is_now(string value ) {
        Console.WriteLine("---  " + "Then_board_is_now");
        Log("---  " + "Then_board_is_now");
        Log(value.ToString());
        Console.WriteLine(value);
    }

    public void When_one_move_is(List<List<string>> values ) {
        Console.WriteLine("---  " + "When_one_move_is");
        Log("---  " + "When_one_move_is");
        foreach (List<string> value in values){
                  Log(string.Join("|", value));}
        foreach (List<string> value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              }
    }

    public void When_moves_are(List<Move> values ) {
        Console.WriteLine("---  " + "When_moves_are");
        Log("---  " + "When_moves_are");
        foreach (Move value in values){
                  Log(value.ToString());}
        foreach (Move value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              MoveInternal i = value.ToMoveInternal();
              }
    }

    public void Given_one_object_is(List<SimpleClass> values ) {
        Console.WriteLine("---  " + "Given_one_object_is");
        Log("---  " + "Given_one_object_is");
        foreach (SimpleClass value in values){
                  Log(value.ToString());}
        foreach (SimpleClass value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              SimpleClassInternal i = value.ToSimpleClassInternal();
              }
    }

    public void Then_Json_should_be(string value ) {
        Console.WriteLine("---  " + "Then_Json_should_be");
        Log("---  " + "Then_Json_should_be");
        Log(value.ToString());
        Console.WriteLine(value);
    }

    public void Given_Json_is(string value ) {
        Console.WriteLine("---  " + "Given_Json_is");
        Log("---  " + "Given_Json_is");
        Log(value.ToString());
        Console.WriteLine(value);
    }

    public void Then_the_converted_object_is(List<SimpleClass> values ) {
        Console.WriteLine("---  " + "Then_the_converted_object_is");
        Log("---  " + "Then_the_converted_object_is");
        foreach (SimpleClass value in values){
                  Log(value.ToString());}
        foreach (SimpleClass value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              SimpleClassInternal i = value.ToSimpleClassInternal();
              }
    }

    public void Given_a_table_is(List<SimpleClass> values ) {
        Console.WriteLine("---  " + "Given_a_table_is");
        Log("---  " + "Given_a_table_is");
        foreach (SimpleClass value in values){
                  Log(value.ToString());}
        foreach (SimpleClass value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              SimpleClassInternal i = value.ToSimpleClassInternal();
              }
    }

    public void Then_Json_for_table_should_be(string value ) {
        Console.WriteLine("---  " + "Then_Json_for_table_should_be");
        Log("---  " + "Then_Json_for_table_should_be");
        Log(value.ToString());
        Console.WriteLine(value);
    }

    public void Given_Json_for_table_is(string value ) {
        Console.WriteLine("---  " + "Given_Json_for_table_is");
        Log("---  " + "Given_Json_for_table_is");
        Log(value.ToString());
        Console.WriteLine(value);
    }

    public void Then_the_converted_table_should_be(List<SimpleClass> values ) {
        Console.WriteLine("---  " + "Then_the_converted_table_should_be");
        Log("---  " + "Then_the_converted_table_should_be");
        foreach (SimpleClass value in values){
                  Log(value.ToString());}
        foreach (SimpleClass value in values){
             Console.WriteLine(value);
             // Add calls to production code and asserts
              SimpleClassInternal i = value.ToSimpleClassInternal();
              }
    }

public static List<List<Int32>> ConvertList(List<List<string>> stringList)
{List < List <Int32>> classList = new List<List<Int32>>();
    foreach (List<string> innerList in stringList)
    {
        List<Int32> innerClassList = new List<Int32>();
        foreach (string s in innerList)
        {
            innerClassList.Add(Int32.Parse(s));
        }
        classList.Add(innerClassList);
    }
    return classList;
}
    }
}
