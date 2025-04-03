namespace gherkinexecutor.Feature_Data_Definition
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class TestIn
    {
        public string aValue = "0";
        public string bValue = " ";
        public string cValue = "4.0";
        public TestIn() { }
        public TestIn(
            string aValue
            , string bValue
            , string cValue
            )
        {
            this.aValue = aValue;
            this.bValue = bValue;
            this.cValue = cValue;
        }
        public override bool Equals(object? o)
        {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            TestIn _TestIn = (TestIn)o;
            bool result = true;
            if (
                !this.aValue.Equals("?DNC?")
                && !_TestIn.aValue.Equals("?DNC?"))
                if (!_TestIn.aValue.Equals(this.aValue)) result = false;
            if (
                !this.bValue.Equals("?DNC?")
                && !_TestIn.bValue.Equals("?DNC?"))
                if (!_TestIn.bValue.Equals(this.bValue)) result = false;
            if (
                !this.cValue.Equals("?DNC?")
                && !_TestIn.cValue.Equals("?DNC?"))
                if (!_TestIn.cValue.Equals(this.cValue)) result = false;
            return result;
        }
        public override int GetHashCode()

        {
            int hashCode = 1;
            hashCode ^= aValue == null ? 0 : aValue.GetHashCode();
            hashCode ^= bValue == null ? 0 : bValue.GetHashCode();
            hashCode ^= cValue == null ? 0 : cValue.GetHashCode();
            return hashCode;
        }
        public class Builder
        {
            private string aValue = "0";
            private string bValue = " ";
            private string cValue = "4.0";
            public Builder SetAValue(string aValue)
            {
                this.aValue = aValue;
                return this;
            }
            public Builder SetBValue(string bValue)
            {
                this.bValue = bValue;
                return this;
            }
            public Builder SetCValue(string cValue)
            {
                this.cValue = cValue;
                return this;
            }
            public Builder SetCompare()
            {
                aValue = "?DNC?";
                bValue = "?DNC?";
                cValue = "?DNC?";
                return this;
            }
            public TestIn Build()
            {
                return new TestIn(
                    aValue
                    , bValue
                    , cValue
                   );
            }
        }
        public override string ToString()
        {
            return "TestIn {" + " aValue = " + aValue + " " + " bValue = " + bValue + " " + " cValue = " + cValue + " " + "} " + "\\n";
        }
        public string ToJson()
        {
            return " {" + "aValue: " + "\"" + aValue + "\"" + "," + "bValue: " + "\"" + bValue + "\"" + "," + "cValue: " + "\"" + cValue + "\"" + "} ";
        }
        public static TestIn FromJson(string json)
        {
            TestIn instance = new TestIn();

            json = json.Replace("\\s", "");
            string[] keyValuePairs = json.Replace("{", "").Replace("}", "").Split(',');

            foreach (string pair in keyValuePairs)
            {
                string[] entry = pair.Split(':');
                string key = entry[0].Replace("\"", "").Trim();
                string value = entry[1].Replace("\"", "").Trim();

                switch (key)
                {

                    case "aValue":
                        instance.aValue = value;
                        break;
                    case "bValue":
                        instance.bValue = value;
                        break;
                    case "cValue":
                        instance.cValue = value;
                        break;
                    default:
                        Console.Error.WriteLine("Invalid JSON element " + key);
                        break;
                }
            }
            return instance;
        }
        public static string ListToJson(List<TestIn> list)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("[");

            for (int i = 0; i < list.Count; i++)
            {
                jsonBuilder.Append(list[i].ToJson());
                if (i < list.Count - 1)
                {
                    jsonBuilder.Append(",");
                }
            }

            jsonBuilder.Append("]");
            return jsonBuilder.ToString();
        }
        public static List<TestIn> ListFromJson(string json)
        {
            List<TestIn> list = new List<TestIn>();
            json = json.Replace("\\s", "");
            json = json.Replace("[", "").Replace("]", "");
            string[] jsonObjects = json.Split(new[] { "},\\s*{" }, StringSplitOptions.None);
            foreach (string jsonObject in jsonObjects)
            {
                list.Add(TestIn.FromJson(jsonObject));
            }
            return list;
        }
        public class TestInComparer : IEqualityComparer<TestIn>
        {
            public bool Equals(TestIn? x, TestIn? y)
            {
                if (x == null) return false;
                return x.Equals(y);
            }
            public int GetHashCode(TestIn obj)
            {
                return obj.GetHashCode();
            }
        }
        public Existing ToExisting()
        {
            return new Existing(
             int.Parse(aValue)
            , bValue
            , double.Parse(cValue)
            );
        }
    }
}
