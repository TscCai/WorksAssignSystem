using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorksAssign.Persistence {
    public enum RoleNameType {
        [StringValue("负责人")]
        Leader,
        [StringValue("管理人员")]
        Manager,
        [StringValue("专责监护")]
        Guardian,
        [StringValue("青工")]
        YoungGuy,
        [StringValue("骨干")]
        Senior
    }

    public class StringValue : Attribute {
        private string _value;

        public StringValue(string value) {
            _value = value;
        }

        public string Value {
            get { return _value; }
        }
    }

    public static class StringEnum {
        public static string GetEnumStringValue(this System.Enum value) {
            string output = null;
            System.Type type = value.GetType();
            System.Reflection.FieldInfo fi = type.GetField(value.ToString());
            StringValue[] attrs = fi.GetCustomAttributes(typeof(StringValue), false) as StringValue[];
            if (attrs.Length > 0) {
                output = attrs[0].Value;
            }
            return output;
        }
    }
}
