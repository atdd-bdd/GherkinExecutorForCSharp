namespace gherkinexecutor.Feature_Background
{
    using System;
    using System.Collections.Generic;
    using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

    public class Feature_Background_glue
    {
        const string DNCString = "?DNC?";

        string backgroundValue;
        string cleanupValue;
        public void Given_Background_function_sets_a_value(List<List<string>> values)
        {
            Console.WriteLine("---  " + "Given_Background_function_sets_a_value");
            backgroundValue = values[0][0];
            Console.WriteLine(backgroundValue);
        }

        public void Given_value_for_cleanup_should_be_set_to(List<List<string>> values)
        {
            Console.WriteLine("---  " + "Given_value_for_cleanup_should_be_set_to");
            Console.WriteLine(values[0][0]);
            AreEqual(values[0][0], cleanupValue);
        }

        public void Given_a_regular_function()
        {
            Console.WriteLine("---  " + "Given_a_regular_function");
        }

        public void Then_background_should_set_value_to(List<List<string>> values)
        {
            Console.WriteLine("---  " + "Then_background_should_set_value_to");
            Assert.AreEqual(values[0][0], backgroundValue);

        }

        public void And_set_a_value_for_cleanup(List<List<string>> values)
        {
            Console.WriteLine("---  " + "And_set_a_value_for_cleanup");
            cleanupValue = values[0][0];
            Console.WriteLine(cleanupValue);
        }

    }
}
