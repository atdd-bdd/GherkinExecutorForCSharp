namespace gherkinexecutor.Feature_Include
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class CSVContents
    {
        public string a = "";
        public string b = "";
        public string c = "";
        public CSVContents() { }
        public CSVContents(
            string a
            , string b
            , string c
            )
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public override bool Equals(object? o)
        {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            CSVContents _CSVContents = (CSVContents)o;
            bool result = true;
            if (
                !this.a.Equals("?DNC?")
                && !_CSVContents.a.Equals("?DNC?"))
                if (!_CSVContents.a.Equals(this.a)) result = false;
            if (
                !this.b.Equals("?DNC?")
                && !_CSVContents.b.Equals("?DNC?"))
                if (!_CSVContents.b.Equals(this.b)) result = false;
            if (
                !this.c.Equals("?DNC?")
                && !_CSVContents.c.Equals("?DNC?"))
                if (!_CSVContents.c.Equals(this.c)) result = false;
            return result;
        }
        public override int GetHashCode()

        {
            int hashCode = 1;
            hashCode ^= a == null ? 0 : a.GetHashCode();
            hashCode ^= b == null ? 0 : b.GetHashCode();
            hashCode ^= c == null ? 0 : c.GetHashCode();
            return hashCode;
        }
        public class Builder
        {
            private string a = "";
            private string b = "";
            private string c = "";
            public Builder SetA(string a)
            {
                this.a = a;
                return this;
            }
            public Builder SetB(string b)
            {
                this.b = b;
                return this;
            }
            public Builder SetC(string c)
            {
                this.c = c;
                return this;
            }
            public Builder SetCompare()
            {
                a = "?DNC?";
                b = "?DNC?";
                c = "?DNC?";
                return this;
            }
            public CSVContents Build()
            {
                return new CSVContents(
                    a
                    , b
                    , c
                   );
            }
        }
        public override string ToString()
        {
            return "CSVContents {" + " a = " + a + " " + " b = " + b + " " + " c = " + c + " " + "} " + "\\n";
        }
        public string ToJson()
        {
            return " {" + "a: " + "\"" + a + "\"" + "," + "b: " + "\"" + b + "\"" + "," + "c: " + "\"" + c + "\"" + "} ";
        }
        public static CSVContents FromJson(string json)
        {
            CSVContents instance = new CSVContents();

            json = json.Replace("\\s", "");
            string[] keyValuePairs = json.Replace("{", "").Replace("}", "").Split(',');

            foreach (string pair in keyValuePairs)
            {
                string[] entry = pair.Split(':');
                string key = entry[0].Replace("\"", "").Trim();
                string value = entry[1].Replace("\"", "").Trim();

                switch (key)
                {

                    case "a":
                        instance.a = value;
                        break;
                    case "b":
                        instance.b = value;
                        break;
                    case "c":
                        instance.c = value;
                        break;
                    default:
                        Console.Error.WriteLine("Invalid JSON element " + key);
                        break;
                }
            }
            return instance;
        }
        public static string ListToJson(List<CSVContents> list)
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
        public static List<CSVContents> ListFromJson(string json)
        {
            List<CSVContents> list = new List<CSVContents>();
            json = json.Replace("\\s", "");
            json = json.Replace("[", "").Replace("]", "");
            string[] jsonObjects = json.Split(new[] { "},\\s*{" }, StringSplitOptions.None);
            foreach (string jsonObject in jsonObjects)
            {
                list.Add(CSVContents.FromJson(jsonObject));
            }
            return list;
        }
        public class CSVContentsComparer : IEqualityComparer<CSVContents>
        {
            public bool Equals(CSVContents? x, CSVContents? y)
            {
                if (x == null) return false;
                return x.Equals(y);
            }
            public int GetHashCode(CSVContents obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
