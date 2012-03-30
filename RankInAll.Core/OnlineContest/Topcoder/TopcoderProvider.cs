using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RankInAll.Utility;
using System.Text.RegularExpressions;

namespace RankInAll.Core.OnlineContest.Topcoder
{
    public class TopcoderProvider
    {
        /// <summary>
        /// 获得tc用户信息
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public User GetProfile(string user_id)
        {
            if (user_id == null)
                return null;
            User user = new User();
            user.UserName = user_id.Trim();

            string web = GetProfilePage(user_id.Trim());

            string regexPattern = "<span class=\"(.*)\">(.*)</span>\\s";
            Regex reg = new Regex(regexPattern, RegexOptions.Compiled);
            var match = reg.Match(web);
            if (!match.Success)
                return null;
            user.Color = match.Result("$1").Trim();
            user.Rating = Convert.ToInt32(match.Result("$2").Trim());


            regexPattern = "<td class=\"valueR\">(\\d*?)</td>";
            reg = new Regex(regexPattern, RegexOptions.Compiled);
            
            var matches = reg.Matches(web);
            if (matches.Count<3)
                return null;
            user.Volatility = Convert.ToInt32(matches[0].Result("$1").Trim());
            //user.max_rating = Convert.ToInt32(matches[1].Result("$1").Trim());
            //user.min_raing = Convert.ToInt32(matches[2].Result("$1").Trim());

            regexPattern = ">(\\d+?)</a></td></tr>";
            reg = new Regex(regexPattern, RegexOptions.Compiled);
            match = reg.Match(web);
            if (!match.Success)
                return null;
            user.Timesplayed = Convert.ToInt32(match.Result("$1").Trim());

            regexPattern = "<td class=\"valueR\">(.+?)<br />(.+?)</td></tr>";
            reg = new Regex(regexPattern, RegexOptions.Compiled);
            match = reg.Match(web);
            if (!match.Success)
                return null;
            user.MostRecentEvent = match.Result("$1").Trim() +"-"+ match.Result("$2").Trim();
            return user;
        }

        private string GetProfilePage(string user_id)
        {
            string url = string.Format("http://community.topcoder.com/tc?module=SimpleSearch&ha={0}", user_id);
            return Http.Get(url, true);
        }
    }
}
