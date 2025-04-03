namespace gherkinexecutor.Feature_Include
{
    using System;
    using System.Collections.Generic;
    using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

    public class Feature_Include_glue
    {
        const string DNCString = "?DNC?";

        string original;
        public void Given_a_string_include(string value)
        {
            Console.WriteLine("---  " + "Given_a_string_include");
            Console.WriteLine(value);
            original = value;
        }

        public void Then_should_be_equal_to(string value)
        {
            Console.WriteLine("---  " + "Then_should_be_equal_to");
            Console.WriteLine(value);
            AreEqual(value, original);
        }

        List<CSVContents> originalTable;
        public void Given_a_table(List<CSVContents> values)
        {
            Console.WriteLine("---  " + "Given_a_table");
            foreach (CSVContents value in values)
            {
                Console.WriteLine(value);
                // Add calls to production code and asserts
            }
            originalTable = values;

        }

        public void Then_Should_be_equal_to_table(List<CSVContents> values)
        {
            Console.WriteLine("---  " + "Then_Should_be_equal_to_table");
            foreach (CSVContents value in values)
            {
                Console.WriteLine(value);
                // Add calls to production code and asserts
            }
            bool result = originalTable.SequenceEqual(values, new CSVContents.CSVContentsComparer());
            IsTrue(result, "Lists are not equal");
        }

    }
}
