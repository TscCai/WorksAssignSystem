﻿/******************************************************************************
 * WorksAssign.Persistence 工作安排数据库访问组件
 * CopyRight (C) 2020-2021 TscCai.
 * E-Mail：caijiran@hotmail.com
 *
 * GitHub: https://github.com/TscCai/WorksAssignSystem
 *
 ******************************************************************************
 * 文件名称: RoleNameType.cs
 * 文件说明: 工作角色名称枚举
 * 当前版本: 
 * 创建日期: 2021-02-03
 * 2021-02-03: 增加文件说明
******************************************************************************/
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
        Senior,
        [StringValue("外协人员")]
        ExMember
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
