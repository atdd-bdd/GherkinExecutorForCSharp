namespace gherkinexecutor.Feature_Tables_and_Strings
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    public class ExampleClassWithBlanks
    {
        public string field_1 = " ";
        public string field_2 = " ";
        public ExampleClassWithBlanks() { }
        public ExampleClassWithBlanks(
            string field_1
            , string field_2
            )
        {
            this.field_1 = field_1;
            this.field_2 = field_2;
        }
        public override bool Equals(object? o)
        {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            ExampleClassWithBlanks _ExampleClassWithBlanks = (ExampleClassWithBlanks)o;
            bool result = true;
            if (
                !this.field_1.Equals("?DNC?")
                && !_ExampleClassWithBlanks.field_1.Equals("?DNC?"))
                if (!_ExampleClassWithBlanks.field_1.Equals(this.field_1)) result = false;
            if (
                !this.field_2.Equals("?DNC?")
                && !_ExampleClassWithBlanks.field_2.Equals("?DNC?"))
                if (!_ExampleClassWithBlanks.field_2.Equals(this.field_2)) result = false;
            return result;
        }
        public override int GetHashCode()

        {
            int hashCode = 1;
            hashCode ^= field_1 == null ? 0 : field_1.GetHashCode();
            hashCode ^= field_2 == null ? 0 : field_2.GetHashCode();
            return hashCode;
        }
        public class Builder
        {
            private string field_1 = " ";
            private string field_2 = " ";
            public Builder SetField_1(string field_1)
            {
                this.field_1 = field_1;
                return this;
            }
            public Builder SetField_2(string field_2)
            {
                this.field_2 = field_2;
                return this;
            }
            public Builder SetCompare()
            {
                field_1 = "?DNC?";
                field_2 = "?DNC?";
                return this;
            }
            public ExampleClassWithBlanks Build()
            {
                return new ExampleClassWithBlanks(
                    field_1
                    , field_2
                   );
            }
        }
        public override string ToString()
        {
            return "ExampleClassWithBlanks {" + " field_1 = " + field_1 + " " + " field_2 = " + field_2 + " " + "} " + "\\n";
        }
        public string ToJson()
        {
            return " {" + "field_1: " + "\"" + field_1 + "\"" + "," + "field_2: " + "\"" + field_2 + "\"" + "} ";
        }
        public static ExampleClassWithBlanks FromJson(string json)
        {
            ExampleClassWithBlanks instance = new ExampleClassWithBlanks();

            json = json.Replace("\\s", "");
            string[] keyValuePairs = json.Replace("{", "").Replace("}", "").Split(',');

            foreach (string pair in keyValuePairs)
            {
                string[] entry = pair.Split(':');
                string key = entry[0].Replace("\"", "").Trim();
                string value = entry[1].Replace("\"", "").Trim();

                switch (key)
                {

                    case "field_1":
                        instance.field_1 = value;
                        break;
                    case "field_2":
                        instance.field_2 = value;
                        break;
                    default:
                        Console.Error.WriteLine("Invalid JSON element " + key);
                        break;
                }
            }
            return instance;
        }
        public static string ListToJson(List<ExampleClassWithBlanks> list)
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
        public static List<ExampleClassWithBlanks> ListFromJson(string json)
        {
            List<ExampleClassWithBlanks> list = new List<ExampleClassWithBlanks>();
            json = Regex.Replace(json, @"\s", "");
            json = Regex.Replace(json, @"\[", "").Replace("]", "");
            string[] jsonObjects = Regex.Split(json, @"(?<=\}),\s*(?=\{)");
            foreach (string jsonObject in jsonObjects)
            {
                list.Add(ExampleClassWithBlanks.FromJson(jsonObject));
            }
            return list;
        }
        public class ExampleClassWithBlanksComparer : IEqualityComparer<ExampleClassWithBlanks>
        {
            public bool Equals(ExampleClassWithBlanks? x, ExampleClassWithBlanks? y)
            {
                if (x == null) return false;
                return x.Equals(y);
            }
            public int GetHashCode(ExampleClassWithBlanks obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
