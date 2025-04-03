namespace gherkinexecutor.Feature_Tables_and_Strings
{
    using System;
    using System.Collections.Generic;
    using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

    public class Feature_Tables_and_Strings_glue
    {
        const string DNCString = "?DNC?";


        public void Star_A_multiline_string_to_a_string(string value)
        {
            Console.WriteLine("---  " + "Star_A_multiline_string_to_a_string");
            Console.WriteLine(value);

        }

        public void Star_A_multiline_string_to_a_List_of_String(List<string> values)
        {
            Console.WriteLine("---  " + "Star_A_multiline_string_to_a_List_of_String");
            foreach (String value in values)
            {
                Console.WriteLine(value);
                // Add calls to production code and asserts
            }

        }

        String originalString;
        public void Given_multiline_string(string value)
        {
            Console.WriteLine("---  " + "Given_multiline_string");
            Console.WriteLine(value);
            originalString = value;
        }

        public void Then_should_be_equal_to_this_list(List<string> values)
        {
            Console.WriteLine("---  " + "Then_should_be_equal_to_this_list");
            string expected = "";
            string newLine = Environment.NewLine;
            foreach (String value in values)
            {
                Console.WriteLine(value);
                expected += value + newLine;
            }
            string result = originalString + newLine;

            CollectionAssert.AreEqual(expected.ToCharArray(), result.ToCharArray(), "Strings are not equal!");

            AreEqual(expected, result);
        }

        public void Star_A_table_to_List_of_List_of_String(List<List<string>> values)
        {
            Console.WriteLine("---  " + "Star_A_table_to_List_of_List_of_String");
            foreach (List<string> value in values)
            {
                Console.WriteLine(value);
                // Add calls to production code and asserts
            }
        }

        public void Star_A_Table_to_List_Of_List_Of_Object(List<List<string>> values)
        {
            List<List<Int32>> im = ConvertList(values);
            Console.WriteLine(im);
            AreEqual(1, im[0][0]);
        }

        public void Star_A_table_to_List_of_Object(List<ExampleClass> values)
        {
            Console.WriteLine("---  " + "Star_A_table_to_List_of_Object");
            foreach (ExampleClass value in values)
            {
                Console.WriteLine(value);
                // Add calls to production code and asserts
            }

        }

        public void Star_A_table_to_List_of_Object_with_Defaults(List<ExampleClass> values)
        {
            Console.WriteLine("---  " + "Star_A_table_to_List_of_Object_with_Defaults");
            foreach (ExampleClass value in values)
            {
                Console.WriteLine(value);
                // Add calls to production code and asserts
            }

        }

        public void Star_A_table_to_List_of_Object_with_Blanks_in_Values(List<ExampleClassWithBlanks> values)
        {
            Console.WriteLine("---  " + "Star_A_table_to_List_of_Object_with_Blanks_in_Values");
            foreach (ExampleClassWithBlanks value in values)
            {
                Console.WriteLine(value);
                // Add calls to production code and asserts
            }

        }

        public void Star_A_table_to_List_of_Object_with_Blanks_in_Defaults(List<ExampleClassWithBlanks> values)
        {
            Console.WriteLine("---  " + "Star_A_table_to_List_of_Object_with_Blanks_in_Defaults");
            foreach (ExampleClassWithBlanks value in values)
            {
                Console.WriteLine(value);
                // Add calls to production code and asserts
            }
        }

        public void Star_A_table_to_String(string value)
        {
            Console.WriteLine("---  " + "Star_A_table_to_String");
            Console.WriteLine(value);
        }


        public void Given_A_table_to_String(string value)
        {
            Console.WriteLine("---  " + "Given_A_table_to_String");
            Console.WriteLine(value);
            originalString = value;
        }

        public void Then_string_should_be_same_as(string value)
        {
            Console.WriteLine("---  " + "Then_string_should_be_same_as");
            Console.WriteLine(value);
            AreEqual(value, originalString);
        }

        List<ExampleClass> originalList;
        public void Given_A_table_to_List_of_Object_with_Defaults(List<ExampleClass> values)
        {
            Console.WriteLine("---  " + "Given_A_table_to_List_of_Object_with_Defaults");
            foreach (ExampleClass value in values)
            {
                Console.WriteLine(value);
                // Add calls to production code and asserts
            }
            originalList = values;
        }

        public void Then_table_should_be_same_as(List<ExampleClass> values)
        {
            Console.WriteLine("---  " + "Then_table_should_be_same_as");
            foreach (ExampleClass value in values)
            {
                Console.WriteLine(value);
                // Add calls to production code and asserts
            }
            bool result = originalList.SequenceEqual(values, new ExampleClass.ExampleClassComparer());
            IsTrue(result, "Lists are not equal");
        }

        public void Given_A_table_to_List_of_Object(List<ExampleClass> values)
        {
            Console.WriteLine("---  " + "Given_A_table_to_List_of_Object");
            foreach (ExampleClass value in values)
            {
                Console.WriteLine(value);
                // Add calls to production code and asserts
            }
            originalList = values;
        }

        public void Then_transposed_table_to_List_of_Object_should_be_the_same(List<ExampleClass> values)
        {
            Console.WriteLine("---  " + "Then_transposed_table_to_List_of_Object_should_be_the_same");
            foreach (ExampleClass value in values)
            {
                Console.WriteLine(value);
                // Add calls to production code and asserts
            }
            bool result = originalList.SequenceEqual(values, new ExampleClass.ExampleClassComparer());

        }

        public static List<List<Int32>> ConvertList(List<List<string>> stringList)
        {
            List<List<Int32>> classList = new List<List<Int32>>();
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
