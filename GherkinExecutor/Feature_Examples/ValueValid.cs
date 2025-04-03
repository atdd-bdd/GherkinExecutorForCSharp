namespace gherkinexecutor.Feature_Examples
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class ValueValid
    {
        public string value = "0";
        public string valid = "false";
        public string notes = "";
        public ValueValid() { }
        public ValueValid(
            string value
            , string valid
            , string notes
            )
        {
            this.value = value;
            this.valid = valid;
            this.notes = notes;
        }
        public override bool Equals(object? o)
        {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            ValueValid _ValueValid = (ValueValid)o;
            bool result = true;
            if (
                !this.value.Equals("?DNC?")
                && !_ValueValid.value.Equals("?DNC?"))
                if (!_ValueValid.value.Equals(this.value)) result = false;
            if (
                !this.valid.Equals("?DNC?")
                && !_ValueValid.valid.Equals("?DNC?"))
                if (!_ValueValid.valid.Equals(this.valid)) result = false;
            if (
                !this.notes.Equals("?DNC?")
                && !_ValueValid.notes.Equals("?DNC?"))
                if (!_ValueValid.notes.Equals(this.notes)) result = false;
            return result;
        }
        public override int GetHashCode()

        {
            int hashCode = 1;
            hashCode ^= value == null ? 0 : value.GetHashCode();
            hashCode ^= valid == null ? 0 : valid.GetHashCode();
            hashCode ^= notes == null ? 0 : notes.GetHashCode();
            return hashCode;
        }
        public class Builder
        {
            private string value = "0";
            private string valid = "false";
            private string notes = "";
            public Builder SetValue(string value)
            {
                this.value = value;
                return this;
            }
            public Builder SetValid(string valid)
            {
                this.valid = valid;
                return this;
            }
            public Builder SetNotes(string notes)
            {
                this.notes = notes;
                return this;
            }
            public Builder SetCompare()
            {
                value = "?DNC?";
                valid = "?DNC?";
                notes = "?DNC?";
                return this;
            }
            public ValueValid Build()
            {
                return new ValueValid(
                    value
                    , valid
                    , notes
                   );
            }
        }
        public override string ToString()
        {
            return "ValueValid {" + " value = " + value + " " + " valid = " + valid + " " + " notes = " + notes + " " + "} " + "\\n";
        }
        public string ToJson()
        {
            return " {" + "value: " + "\"" + value + "\"" + "," + "valid: " + "\"" + valid + "\"" + "," + "notes: " + "\"" + notes + "\"" + "} ";
        }
        public static ValueValid FromJson(string json)
        {
            ValueValid instance = new ValueValid();

            json = json.Replace("\\s", "");
            string[] keyValuePairs = json.Replace("{", "").Replace("}", "").Split(',');

            foreach (string pair in keyValuePairs)
            {
                string[] entry = pair.Split(':');
                string key = entry[0].Replace("\"", "").Trim();
                string value = entry[1].Replace("\"", "").Trim();

                switch (key)
                {

                    case "value":
                        instance.value = value;
                        break;
                    case "valid":
                        instance.valid = value;
                        break;
                    case "notes":
                        instance.notes = value;
                        break;
                    default:
                        Console.Error.WriteLine("Invalid JSON element " + key);
                        break;
                }
            }
            return instance;
        }
        public static string ListToJson(List<ValueValid> list)
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
        public static List<ValueValid> ListFromJson(string json)
        {
            List<ValueValid> list = new List<ValueValid>();
            json = json.Replace("\\s", "");
            json = json.Replace("[", "").Replace("]", "");
            string[] jsonObjects = json.Split(new[] { "},\\s*{" }, StringSplitOptions.None);
            foreach (string jsonObject in jsonObjects)
            {
                list.Add(ValueValid.FromJson(jsonObject));
            }
            return list;
        }
        public class ValueValidComparer : IEqualityComparer<ValueValid>
        {
            public bool Equals(ValueValid? x, ValueValid? y)
            {
                if (x == null) return false;
                return x.Equals(y);
            }
            public int GetHashCode(ValueValid obj)
            {
                return obj.GetHashCode();
            }
        }
        public ValueValidInternal ToValueValidInternal()
        {
            return new ValueValidInternal(
             value
            , Boolean.Parse(valid)
            , notes
            );
        }
    }
}
