namespace gherkinexecutor.Feature_Examples
{
    using System.Collections.Generic;
    public class SolutionForListOfNumber
    {
        private readonly List<LabelValueInternal> values = new List<LabelValueInternal>();
        private ID filterValue = new ID("Q0000");

        public void Add(LabelValueInternal value)
        {
            values.Add(value);
        }

        public void SetFilterValue(ID value)
        {
            filterValue = value;
        }

        public int Sum()
        {
            int sum = 0;
            foreach (LabelValueInternal element in values)
            {
                if (element.iD.Equals(filterValue))
                {
                    sum += element.value;
                }
            }
            return sum;
        }
    }
}
