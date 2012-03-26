using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using RankInAll.Utility;
using RankInAll.Core.OnlineJudge;

namespace RankInAll.Core.OnlineJudge.POJ
{
    public class PojRank :IOnlineJudge
    {
        public PojRank(){}

        /// <summary>
        /// 根据oj用户名查询上次ac时间
        /// </summary>
        /// <param name="user_id">oj用户名</param>
        /// <returns>上次ac时间</returns>
        public DateTime GetLastAC(string user_id)
        {
            string web = Http.Get(string.Format("http://poj.org/status?result=0&user_id={0}", user_id), null);
            web.RemoveAllTags();
            if (web == null)
            {
                return new DateTime();//to do
            }
            Regex r = new Regex(@"</font></td><td>.*?</td><td>.*?</td><td>.*?</td><td>.*?</td><td>(.*?)</td></tr>",
                RegexOptions.Compiled);
            var result = r.Match(web);
            if (!result.Success)
            {
                return new DateTime();//todo
            }
            return Convert.ToDateTime(result.Result("$1"));
        }

        /// <summary>
        /// 根据oj用户名查询用户信息
        /// </summary>
        /// <param name="user_id">oj用户名</param>
        /// <returns>用户信息</returns>
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

        /// <summary>
        /// 从oj的搜索页面匹配出list<OjRankEntity>页面里所有用户的oj ac submit等信息
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        public List<OjRankEntity> GetRankList(string web)
        {
            var list = new List<OjRankEntity>();

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

        /// <summary>
        /// oj搜索页面的源码匹配出用户信息
        /// </summary>
        /// <param name="web">oj搜索页面的一段源码</param>
        /// <returns>用户oj的ac submit等信息</returns>
        public OjRankEntity CreateOjRank(string web)
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

        /// <summary>
        /// 根据学校搜索用户
        /// </summary>
        /// <param name="school">学校名</param>
        /// <returns>poj搜索页面的搜索结果</returns>
        public string GetSearchResultByShcool(string school)
        {
            string url = string.Format("http://poj.org/searchuser?key={0}&field=school&B1=GO", school);
            return Http.Get(url, null);
        }

        /// <summary>
        /// 根据email搜索用户
        /// </summary>
        /// <param name="email"></param>
        /// <returns>poj搜索页面的搜索结果</returns>
        public string GetSearchResultByEmail(string email)
        {
            string url = string.Format("http://poj.org/searchuser?key={0}&field=email&B1=GO", email);
            return Http.Get(url, null);
        }

        /// <summary>
        /// 根据nick搜索用户
        /// </summary>
        /// <param name="nick"></param>
        /// <returns>poj搜索页面的搜索结果</returns>
        public string GetSearchResultByNick(string nick)
        {
            string url = string.Format("http://poj.org/searchuser?key={0}&field=nick&B1=GO", nick);
            return Http.Get(url, null);
        }

        /// <summary>
        /// 根据用户名搜索用户
        /// </summary>
        /// <param name="user_id">用户名</param>
        /// <returns>poj搜索页面的搜索结果</returns>
        public string GetSearchResultByUser_id(string user_id)
        {
            string url = string.Format("http://poj.org/searchuser?key={0}&field=user_id&B1=GO", user_id);
            return Http.Get(url, null);
        }

        /// <summary>
        /// 获取oj的搜索结果
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetSearchResult(string key)
        {
            string url = string.Format("http://poj.org/searchuser?key={0}&B1=Search", key);
            return Http.Get(url, null);
        }

    }
}