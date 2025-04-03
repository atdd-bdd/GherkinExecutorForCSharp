using System;

namespace gherkinexecutor.Feature_Full_Test
{
    public class ID
    {
        private readonly string value;

        public ID(string value)
        {
            if (value.Length < 5)
                throw new ArgumentException("Too short");
            if (value.Length > 5)
                throw new ArgumentException("Too long");
            if (value[0] != 'Q')
                throw new ArgumentException("Must begin with Q");

            this.value = value;
        }

        // Alternative validation method
        public bool IsValid()
        {
            if (value.Length < 5)
                return false;
            if (value.Length > 5)
                return false;
            if (value[0] != 'Q')
                return false;

            return true;
        }

        public override bool Equals(object? obj)
        {
            if (obj is ID id)
            {
                return value.Equals(id.value);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public override string ToString()
        {
            return $"ID{{value='{value}'}}";
        }
    }
}
