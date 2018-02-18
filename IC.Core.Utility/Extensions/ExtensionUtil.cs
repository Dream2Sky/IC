using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace IC.Core.Utility.Extensions
{
    public static class ExtensionUtil
    {
        public static string GetDescription(this Enum @enum)
        {
            var name = @enum.ToString();
            var field = @enum.GetType().GetField(name);
            if (field == null) return name;
            var att = System.Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute), false);
            return att == null ? field.Name : ((DescriptionAttribute)att).Description;
        }
    }
}
