namespace gherkinexecutor.Feature_Define
{
    using System;
    using System.Collections.Generic;
    using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

    public class Feature_Define_glue
    {
        const string DNCString = "?DNC?";

        List<IDValue> original;
        public void Given_this_data(List<IDValue> values)
        {
            Console.WriteLine("---  " + "Given_this_data");
            foreach (IDValue value in values)
            {
                Console.WriteLine(value);
                // Add calls to production code and asserts
            }
            original = values;
        }

        public void Then_should_be_equal_to_data(List<IDValue> values)
        {
            Console.WriteLine("---  " + "Then_should_be_equal_to_data");
            foreach (IDValue value in values)
            {
                Console.WriteLine(value);
                // Add calls to production code and asserts
            }
            bool result = original.SequenceEqual(values, new IDValue.IDValueComparer());
            IsTrue(result, "Lists do not match");
        }

    }
}
