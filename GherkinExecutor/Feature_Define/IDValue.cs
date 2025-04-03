namespace gherkinexecutor.Feature_Define
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class IDValue
    {
        public string iD = "";
        public string value = "";
        public IDValue() { }
        public IDValue(
            string iD
            , string value
            )
        {
            this.iD = iD;
            this.value = value;
        }
        public override bool Equals(object? o)
        {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            IDValue _IDValue = (IDValue)o;
            bool result = true;
            if (
                !this.iD.Equals("?DNC?")
                && !_IDValue.iD.Equals("?DNC?"))
                if (!_IDValue.iD.Equals(this.iD)) result = false;
            if (
                !this.value.Equals("?DNC?")
                && !_IDValue.value.Equals("?DNC?"))
                if (!_IDValue.value.Equals(this.value)) result = false;
            return result;
        }
        public override int GetHashCode()

        {
            int hashCode = 1;
            hashCode ^= iD == null ? 0 : iD.GetHashCode();
            hashCode ^= value == null ? 0 : value.GetHashCode();
            return hashCode;
        }
        public class Builder
        {
            private string iD = "";
            private string value = "";
            public Builder SetID(string iD)
            {
                this.iD = iD;
                return this;
            }
            public Builder SetValue(string value)
            {
                this.value = value;
                return this;
            }
            public Builder SetCompare()
            {
                iD = "?DNC?";
                value = "?DNC?";
                return this;
            }
            public IDValue Build()
            {
                return new IDValue(
                    iD
                    , value
                   );
            }
        }
        public override string ToString()
        {
            return "IDValue {" + " iD = " + iD + " " + " value = " + value + " " + "} " + "\\n";
        }
        public string ToJson()
        {
            return " {" + "iD: " + "\"" + iD + "\"" + "," + "value: " + "\"" + value + "\"" + "} ";
        }
        public static IDValue FromJson(string json)
        {
            IDValue instance = new IDValue();

            json = json.Replace("\\s", "");
            string[] keyValuePairs = json.Replace("{", "").Replace("}", "").Split(',');

            foreach (string pair in keyValuePairs)
            {
                string[] entry = pair.Split(':');
                string key = entry[0].Replace("\"", "").Trim();
                string value = entry[1].Replace("\"", "").Trim();

                switch (key)
                {

                    case "iD":
                        instance.iD = value;
                        break;
                    case "value":
                        instance.value = value;
                        break;
                    default:
                        Console.Error.WriteLine("Invalid JSON element " + key);
                        break;
                }
            }
            return instance;
        }
        public static string ListToJson(List<IDValue> list)
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
        public static List<IDValue> ListFromJson(string json)
        {
            List<IDValue> list = new List<IDValue>();
            json = json.Replace("\\s", "");
            json = json.Replace("[", "").Replace("]", "");
            string[] jsonObjects = json.Split(new[] { "},\\s*{" }, StringSplitOptions.None);
            foreach (string jsonObject in jsonObjects)
            {
                list.Add(IDValue.FromJson(jsonObject));
            }
            return list;
        }
        public class IDValueComparer : IEqualityComparer<IDValue>
        {
            public bool Equals(IDValue? x, IDValue? y)
            {
                if (x == null) return false;
                return x.Equals(y);
            }
            public int GetHashCode(IDValue obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
