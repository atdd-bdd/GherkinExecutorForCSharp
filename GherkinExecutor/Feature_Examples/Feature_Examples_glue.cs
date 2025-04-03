namespace gherkinexecutor.Feature_Examples
{
    using System;
    using System.Collections.Generic;
    using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

    public class Feature_Examples_glue
    {
        const string DNCString = "?DNC?";

        SolutionForListOfNumber solution = new SolutionForListOfNumber();

        public void Calculation_Convert_F_to_C(List<FandC> values)
        {
            Console.WriteLine("---  " + "Calculation_Convert_F_to_C");
            foreach (FandC value in values)
            {
                Console.WriteLine(value);
                // Add calls to production code and asserts
                FandCInternal i = value.ToFandCInternal();
                int c = TemperatureCalculations.ConvertFahrenheitToCelsius(i.f);
                AreEqual(i.c, c, i.notes);
            }
        }

        public void Rule_ID_must_have_exactly_5_letters_and_begin_with_Q(List<ValueValid> values)
        {
            Console.WriteLine("---  " + "Rule_ID_must_have_exactly_5_letters_and_begin_with_Q");
            foreach (ValueValid value in values)
            {
                Console.WriteLine(value);

                bool expectedException = !bool.Parse(value.valid);
                try
                {
                    new ID(value.value);
                    if (expectedException)
                    {
                        Fail("Invalid value did not throw exeception "
                                + value.value + " " + value.notes);
                    }
                }
                catch (Exception e)
                {
                    if (!expectedException)
                        Fail("Valid value threw exeception " + e
                                + value.value + " " + value.notes);
                }

            }

        }

        public void Given_list_of_numbers(List<LabelValue> values)
        {
            Console.WriteLine("---  " + "Given_list_of_numbers");
            foreach (LabelValue value in values)
            {
                Console.WriteLine(value);
                // Add calls to production code and asserts
                LabelValueInternal i = value.ToLabelValueInternal();
                solution.Add(i);
            }

        }

        public void When_filtered_by_ID_with_value(List<List<string>> values)
        {
            Console.WriteLine("---  " + "When_filtered_by_ID_with_value");
            string id = values[0][0];
            Console.WriteLine("ID is " + id);
            solution.SetFilterValue(new ID(id));
        }

        public void Then_sum_is(List<List<string>> values)
        {
            Console.WriteLine("---  " + "Then_sum_is");
            int expected = Int32.Parse(values[0][0]);
            Console.WriteLine("    expecting " + expected);
            int result = solution.Sum();
            AreEqual(expected, result);

        }

        public void When_filtered_by(List<FilterValue> values)
        {
            Console.WriteLine("---  " + "When_filtered_by");
            foreach (FilterValue value in values)
            {
                Console.WriteLine(value);
                // Add calls to production code and asserts
                FilterValueInternal i = value.ToFilterValueInternal();
                solution.SetFilterValue(i.value);
            }
        }

        public void Then_result(List<ResultValue> values)
        {
            Console.WriteLine("---  " + "Then_result");
            foreach (ResultValue value in values)
            {
                Console.WriteLine(value);
                // Add calls to production code and asserts
                ResultValueInternal i = value.ToResultValueInternal();
                int actual = solution.Sum();
                AreEqual(i.sum, actual);

            }
        }

    }
}
