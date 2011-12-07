using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using RankInAll.Utility;

namespace RankInAll.Core.Hdoj
{
    class HdojRank
    {
        public HdojRank() { }
        public OjRankEntity GetUserStatus(string user_id)
        {
            OjRankEntity ojRankEntity = new OjRankEntity();
            ojRankEntity.UserName=user_id.Trim().ToLower();

            string url = string.Format("http://acm.hdu.edu.cn/userstatus.php?user={0}", user_id);
            string web = Http.Get(url, null);

            string regex = "<h1 style=\"color:#1A5CC8\" align=center><a href='mailto:(.*?)'>(.*?)</a></h1>";
            Regex reg = new Regex(regex, RegexOptions.Compiled);
            var match = reg.Match(web);
            if (!match.Success)
                return null;
            ojRankEntity.Email = match.Result("$1").Trim();
            ojRankEntity.NickName = match.Result("$2").Trim();
            
            regex = @"<tr><td>Rank</td><td align=center>(\d*?)</td></tr>";
            reg = new Regex(regex, RegexOptions.Compiled);
            match = reg.Match(web);
            if (!match.Success)
                return null;
            ojRankEntity.No = Convert.ToInt32(match.Result("$1"));

            regex = @"<tr><td>Problems Solved</td><td align=center>(\d*?)</td></tr>";
            reg = new Regex(regex, RegexOptions.Compiled);
            match = reg.Match(web);
            if (!match.Success)
                return null;
            ojRankEntity.Ac = Convert.ToInt32(match.Result("$1"));

            regex = @"<tr><td>Submissions</td><td align=center>(\d*?)</td></tr>";
            reg = new Regex(regex, RegexOptions.Compiled);
            match = reg.Match(web);
            if (!match.Success)
                return null;
            ojRankEntity.Submit = Convert.ToInt32(match.Result("$1"));

            regex = "<i style=\"color:blue\">from: (.*?)&nbsp;";
            reg = new Regex(regex, RegexOptions.Compiled);
            match = reg.Match(web);
            if (!match.Success)
                return null;
            ojRankEntity.School = match.Result("$1").Trim().ToLower();
            if(ojRankEntity.School=="unknown")
                ojRankEntity.School="";//没有学校的特殊情况

            return ojRankEntity;
        }
        public OjRankEntity CreateOjRank(string web)
        {
            string regex = @"<td>(\d*?)</td><td><img width='42px' height='27px' src='/images/country/(\d*?).gif'/></td><td><a href='userstatus.php\?user=(.*?)'>(.*?)</a></td><td><a href='mailto:(.*?)'>(.*?)</a></td><td>(.*?)</td><td>(\d*?)</td><td>(\d*?)</td>";
            Regex reg = new Regex(regex, RegexOptions.Compiled);
            var match = reg.Match(web);

            if (!match.Success)
            {
                return null;
            }

            return new OjRankEntity()
            {
                No = Convert.ToInt32(match.Result("$9")),//hdoj总排名
                //2 country
                UserName = match.Result("$3").Trim(),
                NickName = match.Result("$4").Trim(),
                School = match.Result("$7").Trim().ToLower(),
                Email = match.Result("$6").Trim(),
                Ac = Convert.ToInt32(match.Result("$8")),
                //Submit = Convert.ToInt32(match.Result("$7"))
            };
        }
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
        public string GetSearchResult(string str)
        {
            string url = string.Format("http://acm.hdu.edu.cn/search.php?field=author&key={0}", str);
            return Http.Get(url, null);
        }
        public DateTime GetLastAC(string user_id)
        {
            string web = Http.Get(string.Format("http://acm.hdu.edu.cn/status.php?first=&pid=&user={0}&lang=0&status=0", user_id), null);
            Regex r = new Regex(@"><td height=22px>\d+</td><td>(?<SubmitTime>.*?)</td><",
                RegexOptions.Compiled);
            var result = r.Match(web);
            if (!result.Success)
            {
                return new DateTime();//todo xx
            }
            return Convert.ToDateTime(result.Groups["SubmitTime"].Value);
        }
    }
}
