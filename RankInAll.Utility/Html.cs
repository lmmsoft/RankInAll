using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RankInAll.Utility
{
    public static class Html
    {
        public static string RemoveAttribute(this string input, string tag)
        {
            return Regex.Replace(input, string.Format(@"<{0}[^>]*?>", tag), string.Format("<{0}>", tag), RegexOptions.IgnoreCase);
        }

        public static string RemoveTagAndContent(this string input, string tag)
        {
            return Regex.Replace(input, string.Format(@"<{0}[^>]*?>.*?</{0}>", tag), "", RegexOptions.IgnoreCase);
        }

        public static string RemoveTag(this string input, string tag)
        {
            string ret;
            ret = Regex.Replace(input, string.Format(@"<{0} [^>]*?>", tag), "", RegexOptions.IgnoreCase);
            ret = Regex.Replace(ret, string.Format(@"</{0}>", tag), "", RegexOptions.IgnoreCase);
            ret = Regex.Replace(ret, string.Format(@"<{0}>", tag), "", RegexOptions.IgnoreCase);
            return ret;
        }

        public static string RemoveAllTags(this string input)
        {
            string ret;
            ret = Regex.Replace(input, @"<[^>]*?>", "", RegexOptions.IgnoreCase);
            ret = Regex.Replace(ret, @"</[^>]*?>", "", RegexOptions.IgnoreCase);
            return ret;
        }

        public static string GetContent(this string input, string tag, string attribute)
        {
            Regex reg = new Regex(string.Format(@"<{0} {1}>(.*?)</{2}>", tag, attribute, tag), RegexOptions.IgnoreCase);
            var match = reg.Match(input);
            if (match.Success)
            {
                return match.Result("$1");
            }
            return null;
        }
    }
}
