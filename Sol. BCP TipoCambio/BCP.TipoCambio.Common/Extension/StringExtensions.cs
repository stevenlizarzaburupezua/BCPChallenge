using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BCP.TipoCambio.Common.Extension
{
    public static class StringExtensions
    {
        public static bool IsNumeric(this string str) => string.IsNullOrEmpty(str) ? false : new Regex("^[0-9]([.,][0-9]{1,3})?$").IsMatch(str);

        public static bool IsEmail(this string str) => string.IsNullOrEmpty(str) ? false : new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$").IsMatch(str);

        public static bool IsPhoneNumber(this string str) => string.IsNullOrEmpty(str) ? false : new Regex(@"^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$").IsMatch(str);

        public static bool IsGuid(this string str) => string.IsNullOrEmpty(str) ? false : new Regex(@"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$").IsMatch(str);

        public static decimal ToDecimal(this string str) => decimal.Parse(str);
    }
}
