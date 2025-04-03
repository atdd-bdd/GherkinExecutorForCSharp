namespace gherkinexecutor.Feature_Json
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
    public class Feature_Json_glue
    {
        const string DNCString = "?DNC?";

        List<SimpleClass> original;


        public void Given_one_object_is(List<SimpleClass> values)
        {
            Console.WriteLine("---  " + "Given_one_object_is");
            foreach (SimpleClass value in values)
            {
                Console.WriteLine(value);
                // Add calls to production code and asserts
                SimpleClassInternal i = value.ToSimpleClassInternal();
            }
            original = values;

        }

        public void Then_Json_should_be(string value)
        {
            Console.WriteLine("---  " + "Then_Json_should_be");
            Console.WriteLine(value);
            String result = original[0].ToJson().Trim();
            result = Regex.Replace(result, @"\s", "");
            String expected = Regex.Replace(value, @"\s", "");
            AreEqual(value, result);
        }

        String originalJson;

        public void Given_Json_is(string value)
        {
            Console.WriteLine("---  " + "Given_Json_is");
            Console.WriteLine(value);
            originalJson = value;
        }

        public void Then_the_converted_object_is(List<SimpleClass> values)
        {
            Console.WriteLine("---  " + "Then_the_converted_object_is");
            SimpleClass expected = SimpleClass.FromJson(originalJson);
            SimpleClass value = values[0];
            AreEqual(expected, value);

        }
        List<SimpleClass> originalList;
        public void Given_a_table_is(List<SimpleClass> values)
        {
            Console.WriteLine("---  " + "Given_a_table_is");
            foreach (SimpleClass value in values)
            {
                Console.WriteLine(value);
                // Add calls to production code and asserts
                SimpleClassInternal i = value.ToSimpleClassInternal();
            }
            originalList = values;

        }

        public void Then_Json_for_table_should_be(string value)
        {
            Console.WriteLine("---  " + "Then_Json_for_table_should_be");
            Console.WriteLine(value);
            string result = SimpleClass.ListToJson(originalList);
            result = Regex.Replace(result, @"\s", "");
            string expected = value;

            expected = Regex.Replace(expected, @"\s", "");
            Assert.AreEqual(expected, result);
        }

        public void Given_Json_for_table_is(string value)
        {
            Console.WriteLine("---  " + "Given_Json_for_table_is");
            Console.WriteLine(value);
            originalJson = value;
        }

        public void Then_the_converted_table_should_be(List<SimpleClass> values)
        {
            Console.WriteLine("---  " + "Then_the_converted_table_should_be");
            foreach (SimpleClass value in values)
            {
                Console.WriteLine(value);
                // Add calls to production code and asserts
                SimpleClassInternal i = value.ToSimpleClassInternal();
            }
            List<SimpleClass> result = SimpleClass.ListFromJson(originalJson);
            foreach (SimpleClass sc in result)
            { Console.WriteLine(sc); }
            bool compare = values.SequenceEqual(result, new SimpleClass.SimpleClassComparer());
            IsTrue(compare, "Lists are not equal");
        }

    }
}
