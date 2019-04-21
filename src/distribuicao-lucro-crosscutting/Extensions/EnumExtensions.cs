using System;
using System.ComponentModel;
using System.Reflection;

namespace DistribuicaoLucro.CrossCutting.Extensions
{
    public static class EnumExtensions
    {
        public static Enum RetornarEnum<T>(string descricao)
        {
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                Type genericEnumType = value.GetType();
                MemberInfo[] memberInfo = genericEnumType.GetMember(value.ToString());
                if ((memberInfo != null && memberInfo.Length > 0))
                {
                    var attribute = (DescriptionAttribute)memberInfo[0]?.GetCustomAttribute(typeof(DescriptionAttribute), false);
                    if (attribute?.Description == descricao)
                        return (value as Enum);
                }
            }
            return null;
        }

        public static object RetornarDefaultValue<T>(this Enum enumValue)
        {
            Type genericEnumType = enumValue.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(enumValue.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var attribute = (DefaultValueAttribute)memberInfo[0]?.GetCustomAttribute(typeof(DefaultValueAttribute), false);
                return attribute?.Value;
            }
            return null;
        }
    }
}