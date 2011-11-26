using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using RankInAll.Utility;

namespace RankInAll.Core.Poj
{
    class PojRank : IOjRank
    {
        public PojRank()
        {

        }
        public OjRankEntity GetUserStatus(string user_id)
        {
            OjRankEntity ojRankEntity = new OjRankEntity();

            string url = string.Format("http://poj.org/userstatus?user_id={0}", user_id);
            string web = Http.Get(url, null);


            string regex = @"<font size=5 color=blue><a href=send\?to=(.*?)>(.*?)--(.*?)</a></font>";
            Regex reg = new Regex(regex, RegexOptions.Compiled);
            var match = reg.Match(web);
            if (!match.Success)
                return null;
            ojRankEntity.UserName = match.Result("$1").Trim();
            ojRankEntity.NickName = match.Result("$3").Trim();

            //<td align=center width=25%>(.*?)</td>
            string regexString = @"<td align=center width=25%>(.*?)</td>";
            Regex regex2 = new Regex(regexString, RegexOptions.Compiled);
            var matches = regex2.Matches(web);


            regex = @"<font color=red>(\d*?)</font>";
            reg = new Regex(regex, RegexOptions.Compiled);
            match = reg.Match(matches[0].Result("$0"));
            if (!match.Success)
                return null;
            ojRankEntity.No = Convert.ToInt32(match.Result("$1"));

            regex = string.Format(@"<a href=status\?result=0&user_id={0}>(\d*?)</a></td>", ojRankEntity.UserName);
            reg = new Regex(regex, RegexOptions.Compiled);
            match = reg.Match(matches[1].Result("$0"));
            if (!match.Success)
                return null;
            ojRankEntity.Ac = Convert.ToInt32(match.Result("$1"));

            regex = string.Format(@"<a href=status\?user_id={0}>(\d*?)</a></td>", ojRankEntity.UserName);
            reg = new Regex(regex, RegexOptions.Compiled);
            match = reg.Match(matches[2].Result("$0"));
            if (!match.Success)
                return null;
            ojRankEntity.Submit = Convert.ToInt32(match.Result("$1"));

            regex = @"<td align=center width=25%>(.*?)</td>";
            reg = new Regex(regex, RegexOptions.Compiled);
            match = reg.Match(matches[3].Result("$0"));
            if (!match.Success)
                return null;
            ojRankEntity.School = match.Result("$1").Trim().ToLower();

            regex = @"<td align=center width=25%>(.*?)</td>";
            reg = new Regex(regex, RegexOptions.Compiled);
            match = reg.Match(matches[4].Result("$0"));
            if (!match.Success)
                return null;
            ojRankEntity.Email = match.Result("$1").Trim();

            return ojRankEntity;
        }
        public List<OjRankEntity> GetRankList(string web)
        {
            var list = new List<OjRankEntity>();
            //web = ReplaceTag(web);


            Regex regex = new Regex(@"<tr(.+?)</tr>", RegexOptions.Compiled);
            var matchs = regex.Matches(web);

            foreach (Match element in matchs)
            {
                string ret = "";
                if (element.Success)
                {
                    ret = element.Result("$1");
                }
                OjRankEntity ojRankEntity = CreateOjRank(ret);
                if (ojRankEntity != null)
                {
                    list.Add(ojRankEntity);
                }
            }
            return list;
        }

        private void CreateOjRanksBySchool()
        {
            //Console.WriteLine("hello world!");
            string web = GetSearchResultByShcool("njust");
            string regexString = @"<td width=10%>(\d+)</td><td><a href=userstatus\?user_id=([^>]+)>\w+</a></td><td>(.*?)</td><td>(.*?)</td><td>(.*?)</td><td>(\d+)</td><td>(\d+)</td></regex>";
            Regex reg = new Regex(regexString, RegexOptions.Compiled);

            //var matchs =reg.Match(web);

            IList<PojRank> PojRanks = new List<PojRank>();

            var matchs = reg.Matches(web);
            Console.WriteLine("count=" + matchs.Count);
            foreach (Match match in matchs)
            {
                Console.WriteLine(match.Result("$1"));
                Console.WriteLine(match.Result("$2"));
                Console.WriteLine(match.Result("$3"));
                Console.WriteLine(match.Result("$4"));
                Console.WriteLine(match.Result("$5"));
                Console.WriteLine(match.Result("$6"));
                Console.WriteLine(match.Result("$7"));

                OjRankEntity pojRankEntity = new OjRankEntity();
                pojRankEntity.No = Convert.ToInt32(match.Result("$1"));
                pojRankEntity.UserName = match.Result("$2").Trim();
                pojRankEntity.NickName = match.Result("$3").Trim();
                pojRankEntity.School = match.Result("$4").Trim();
                pojRankEntity.Email = match.Result("$5").Trim();
                pojRankEntity.Ac = Convert.ToInt32("$6");
                pojRankEntity.Submit = Convert.ToInt32("$7");

            }


            Console.WriteLine("end!");
            Console.Beep();
            Console.ReadLine();

        }
        private OjRankEntity CreateOjRank(string web)
        {
            string regex = @"<td width=10%>(\d+)</td><td><a href=userstatus\?user_id=([^>]+)>\w+</a></td><td>(.*?)</td><td>(.*?)</td><td>(.*?)</td><td>(\d+)</td><td>(\d+)</td>";
            Regex reg = new Regex(regex, RegexOptions.Compiled);
            var match = reg.Match(web);

            if (!match.Success)
            {
                return null;
            }

            return new OjRankEntity()
            {
                No = Convert.ToInt32(match.Result("$1")),
                UserName = match.Result("$2").Trim(),
                NickName = match.Result("$3").Trim(),
                School = match.Result("$4").Trim().ToLower(),
                Email = match.Result("$5").Trim(),
                Ac = Convert.ToInt32(match.Result("$6")),
                Submit = Convert.ToInt32(match.Result("$7"))
            };
        }

        public string GetSearchResultByShcool(string school)
        {
            string url = string.Format("http://poj.org/searchuser?key={0}&field=school&B1=GO", school);
            return Http.Get(url, null);
        }
        public string GetSearchResultByEmail(string email)
        {
            string url = string.Format("http://poj.org/searchuser?key={0}&field=email&B1=GO", email);
            return Http.Get(url, null);
        }
        public string GetSearchResultByNick(string nick)
        {
            string url = string.Format("http://poj.org/searchuser?key={0}&field=nick&B1=GO", nick);
            return Http.Get(url, null);
        }
        public string GetSearchResultByUser_id(string user_id)
        {
            string url = string.Format("http://poj.org/searchuser?key={0}&field=user_id&B1=GO", user_id);
            return Http.Get(url, null);
        }

        //private static string ReplaceTag(string str)
        //{
        //    str = str.RemoveTagAndContent("script");
        //    str = str.RemoveTagAndContent("head");
        //    str = str.RemoveTagAndContent("form");
        //    str = str.RemoveTag("p");
        //    str = str.RemoveTag("a");
        //    str = str.RemoveTag("font");
        //    str = str.RemoveAttribute("regexPattern");
        //    str = str.RemoveAttribute("td");
        //    return str;
        //}
    }
}