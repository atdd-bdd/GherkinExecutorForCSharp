namespace gherkinexecutor.Feature_Examples
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class LabelValue
    {
        public string iD = "";
        public string value = "0";
        public LabelValue() { }
        public LabelValue(
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
            LabelValue _LabelValue = (LabelValue)o;
            bool result = true;
            if (
                !this.iD.Equals("?DNC?")
                && !_LabelValue.iD.Equals("?DNC?"))
                if (!_LabelValue.iD.Equals(this.iD)) result = false;
            if (
                !this.value.Equals("?DNC?")
                && !_LabelValue.value.Equals("?DNC?"))
                if (!_LabelValue.value.Equals(this.value)) result = false;
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
            private string value = "0";
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
            public LabelValue Build()
            {
                return new LabelValue(
                    iD
                    , value
                   );
            }
        }
        public override string ToString()
        {
            return "LabelValue {" + " iD = " + iD + " " + " value = " + value + " " + "} " + "\\n";
        }
        public string ToJson()
        {
            return " {" + "iD: " + "\"" + iD + "\"" + "," + "value: " + "\"" + value + "\"" + "} ";
        }
        public static LabelValue FromJson(string json)
        {
            LabelValue instance = new LabelValue();

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
        public static string ListToJson(List<LabelValue> list)
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
        public static List<LabelValue> ListFromJson(string json)
        {
            List<LabelValue> list = new List<LabelValue>();
            json = json.Replace("\\s", "");
            json = json.Replace("[", "").Replace("]", "");
            string[] jsonObjects = json.Split(new[] { "},\\s*{" }, StringSplitOptions.None);
            foreach (string jsonObject in jsonObjects)
            {
                list.Add(LabelValue.FromJson(jsonObject));
            }
            return list;
        }
        public class LabelValueComparer : IEqualityComparer<LabelValue>
        {
            public bool Equals(LabelValue? x, LabelValue? y)
            {
                if (x == null) return false;
                return x.Equals(y);
            }
            public int GetHashCode(LabelValue obj)
            {
                return obj.GetHashCode();
            }
        }
        public LabelValueInternal ToLabelValueInternal()
        {
            return new LabelValueInternal(
             new ID(iD)
            , Int32.Parse(value)
            );
        }
    }
}
