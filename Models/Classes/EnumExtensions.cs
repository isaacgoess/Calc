﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Calc.Models.Classes
{
        public static class EnumExtensions
        {
            public static string GetDescription(this Enum GenericEnum) //Hint: Change the method signature and input paramter to use the type parameter T
            {
                Type genericEnumType = GenericEnum.GetType();
                MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
                if ((memberInfo != null && memberInfo.Length > 0))
                {
                    var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                    if ((_Attribs != null && _Attribs.Count() > 0))
                    {
                        return ((System.ComponentModel.DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                    }
                }
                return GenericEnum.ToString();
            }
        }
    }