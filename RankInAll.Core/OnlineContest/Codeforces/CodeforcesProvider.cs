using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RankInAll.Utility;
using System.Text.RegularExpressions;

namespace RankInAll.Core.OnlineContest.Codeforces
{
    public class CodeforcesProvider
    {
        public List<CfContestResult> GetAllContestResults(string user_id)
        {
            List<CfContestResult> resultList = new List<CfContestResult>();

            string url = string.Format("http://codeforces.com/profile/{0}", user_id);
            string web = Http.Get(url, null);
            
            string regexPattern = "\\[\\s*?(\\d*?),\\s*?(\\d*?),\\s*?(\\d*?),\\s*?\"(.*?)\",\\s*?\"(.*?)\",\\s*?(-?\\d.*?),\\s*(\\d*),\\s*\"(.*?)\",\\s+\"(.*?)\"\\s+?\\]";
            Regex reg = new Regex(regexPattern, RegexOptions.Compiled);
            var matchs = reg.Matches(web);
            if (matchs.Count <= 0)
                return null;
            int timesPlayed = 0;
            foreach (Match mat in matchs)
            {
                resultList.Add(new CfContestResult()
                {
                    UserName = user_id,
                    Timesplayed = ++timesPlayed,

                    //guid=Convert.ToInt32(mat.Result("$1"));
                    Rating = Convert.ToInt32(mat.Result("$2")),
                    ContestId = Convert.ToInt32(mat.Result("$3")),
                    ContestName = mat.Result("$4"),
                    //russian ContestName=mat.Result("$5"),
                    Change = Convert.ToInt32(mat.Result("$6")),
                    Rank = Convert.ToInt32(mat.Result("$7")),
                    ContestUrl = mat.Result("$8")
                    //user title=ContestUrl=mat.Result("$9")
                });
            }
            return resultList;
        }
        //the same as above
        //public List<CfContestDetail> GetConteset
        //\[\s+(?<id>\d+?),\s+(?<rating>\d+?),\s+(?<contestId>\d+?),\s+\"(?<contestName>.*?)\",\s+\"(?<contestNameRU>.*?)\",\s+(?<change>[-\d]+),\s+(?<rank>[\d]+),\s+\"(?<url>.*?)\",\s+\"(?<title>.*?)\"

        /// <summary>
        /// 获得cf用户信息
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public User GetProfile(string user_id)
        {
            User user = new User();
            user.UserName = user_id.Trim().ToLower();

            //string url = string.Format("http://codeforces.com/profile/{0}", user_id);
            //string web = Http.Get(url, null);

            string web = GetProfilePage(user_id.Trim());

            string regexPattern = "<span style=\"font-weight:bold;\" class=\"user-(.*?)\">(\\d*?)</span>";
            Regex reg = new Regex(regexPattern, RegexOptions.Compiled);
            var match = reg.Match(web);
            if (!match.Success)
                return null;
            user.Color = match.Result("$1").Trim();
            user.Rating = Convert.ToInt32(match.Result("$2").Trim());

            regexPattern = "\\[\\s*?(\\d*?),\\s*?(\\d*?),\\s*?(\\d*?),\\s*?\"(.*?)\",\\s*?\"(.*?)\",\\s*?(-?\\d.*?),\\s*(\\d*),\\s*\"(.*?)\",\\s+\"(.*?)\"\\s+?\\]";
            reg = new Regex(regexPattern, RegexOptions.Compiled);
            var matchs = reg.Matches(web);
            if (matchs.Count <= 0)
                return null;
            user.Timesplayed = matchs.Count;

            return user;

        }
        
        /// <summary>
        /// 获得cf比赛的信息
        /// </summary>
        /// <param name="contestId">比赛url里面的id</param>
        /// <returns></returns>
        public CfContestInfo GetContestInfo(int contestId)
        {
            var info = new CfContestInfo();
            info.ContestId = contestId;
            info.type = "cf";

            string url = string.Format("http://codeforces.com/contest/{0}/standings/page/1", contestId);
            string web = Http.Get(url, null);

            info.ContestUrl=url;
            

            string regexPattern = "0.5em auto;\\\">(.*?)</div>";
            Regex reg = new Regex(regexPattern, RegexOptions.Compiled);
            var match = reg.Match(web);
            info.ContestName = match.Result("$1").Trim();


            regexPattern = @"Div\. (\d)";
            reg = new Regex(regexPattern, RegexOptions.Compiled);
            match = reg.Match(web);
            info.div = Convert.ToInt32(match.Result("$1"));

            return info;
        }

        /// <summary>
        /// 获得某场比赛的详细成绩
        /// </summary>
        /// <param name="contestId"></param>
        /// <returns></returns>
        public List<CfContestDetail> GetContestDetails(int contestId)
        {
            List<CfContestDetail> resultList = new List<CfContestDetail>();

            int pageNum = GetContestStandingPages(contestId);
            if (pageNum == 0)
                return null;

            for (int pageId = 1; pageId <= pageNum; ++pageId)
            {
                CreateContestDetailPage(contestId, resultList, pageId);
                //resultList.AddRange(resultList);
            }

            return resultList;
        }

        /// <summary>
        /// 匹配每个分页里面的所有参赛者的成功，代码比较烂，需要重构。。。
        /// </summary>
        /// <param name="contestId"></param>
        /// <param name="resultList"></param>
        /// <param name="pageId"></param>
        private static void CreateContestDetailPage(int contestId, List<CfContestDetail> resultList, int pageId)
        {
            string url = string.Format("http://codeforces.com/contest/{0}/standings/page/{1}", contestId, pageId);
            string web = Http.Get(url, null);

            string regexPattern = "<tr participantId=\"(\\d*?)\">\\s*?(<td>\\s*?\\d+[\\s\\S]*?)</tr>";
            Regex reg = new Regex(regexPattern, RegexOptions.Compiled);
            var matchs = reg.Matches(web);
            //if (matchs.Count <= 0)
            //    return null;
            foreach (Match mat in matchs)
            {
                string result = mat.Result("$2");
                var contestDetail = CreateContestDetail(result);
                contestDetail.ContestId = contestId;
                //userId in cf= Convert.ToInt32(mat.Result("$1"));
                resultList.Add(contestDetail);
            }
        }

        /// <summary>
        /// 获得某场cf比赛的standing一共有多少页
        /// </summary>
        /// <param name="contestId"></param>
        /// <returns></returns>
        private int GetContestStandingPages(int contestId)
        {
            string url = string.Format("http://codeforces.com/contest/{0}/standings/page/1", contestId);
            string web = Http.Get(url, null);

            if(web==null)//没抓到数据
                return 0;

            string regexPattern = @"/contest/(\d+)/standings/page/(\d+)";
            Regex reg = new Regex(regexPattern, RegexOptions.Compiled);
            var matchs = reg.Matches(web);

            return matchs.Count+1;
        }

        /// <summary>
        /// 由搜索结果获得某人某场比赛的具体成绩
        /// </summary>
        /// <param name="web_result"></param>
        /// <returns></returns>
        private static CfContestDetail CreateContestDetail(string web_result)
        {
            var contestDetail = new CfContestDetail();

            string regexPattern = "<td([\\s\\S]*?)</td>";
            Regex reg = new Regex(regexPattern, RegexOptions.Compiled);
            var matchs = reg.Matches(web_result);
            if (matchs.Count <= 0)
                return null;

            contestDetail.ProblemNum = matchs.Count - 4;


            string sRank = ">\\s*?(\\d+)";
            Regex rRank = new Regex(sRank, RegexOptions.Compiled);
            var match = rRank.Match(matchs[0].Result("$1"));
            contestDetail.Rank = Convert.ToInt32(match.Result("$1"));


            string sName = "<a href=.*? title=.*? class=.*?>(.*?)</a>";
            Regex rName = new Regex(sName, RegexOptions.Compiled);
            match = rName.Match(matchs[1].Result("$1"));
            contestDetail.UserName = match.Result("$1");


            string sPoint = "<span style=\"font-weight:bold;\">(\\d*?)</span>";
            Regex rPoint = new Regex(sPoint, RegexOptions.Compiled);
            match = rPoint.Match(matchs[2].Result("$1"));
            if (match.Success)
                contestDetail.Point = Convert.ToInt32(match.Result("$1"));
            else
                contestDetail.Point = 0;


            string sChallengeSucceed = "<span class=\"successfullChallengeCount\" title=\"Successful hacking attempts\">\\+(\\d*?)</span>";
            Regex rChallengeSucceed = new Regex(sChallengeSucceed, RegexOptions.Compiled);
            match = rChallengeSucceed.Match(matchs[3].Result("$1"));
            if (match.Success)
                contestDetail.ChallengeSucceed = Convert.ToInt32(match.Result("$1"));
            else
                contestDetail.ChallengeSucceed = 0;

            string sChallengeFailed = "<span class=\"unsuccessfullChallengeCount\" title=\"Unsuccessful hacking attempts\">-(\\d*?)</span>";
            Regex rChallengeFailed = new Regex(sChallengeFailed, RegexOptions.Compiled);
            match = rChallengeFailed.Match(matchs[3].Result("$1"));
            if (match.Success)
                contestDetail.ChallengeFailed = Convert.ToInt32(match.Result("$1"));
            else
                contestDetail.ChallengeFailed = 0;

            //5/6 problems to be fetched

            //抓取每道题目的信息
            contestDetail.PointTime = new List<Tuple<int, string>>();
            for (int i = 1; i <= contestDetail.ProblemNum; ++i)
            {
                string td = matchs[i + 3].Result("$1");//从0开始

                string sPassed = "<span class=\"cell-passed-system-test\">(\\d*?)</span>";
                Regex rPassed = new Regex(sPassed, RegexOptions.Compiled);
                match = rPassed.Match(td);
                if (match.Success)
                {//ac
                    int point = Convert.ToInt32(match.Result("$1"));

                    string sTime = "<span class=\"cell-time\">(.*?)</span>";
                    Regex rTime = new Regex(sTime, RegexOptions.Compiled);
                    match = rTime.Match(td);

                    string time = match.Result("$1");
                    contestDetail.PointTime.Add(Tuple.Create<int, string>(point, time));
                }
                else
                {
                    string sFailed = "<span class=\"cell-failed-system-test\">\\s+([-\\d]+)\\s+</span>";
                    Regex rFailed = new Regex(sFailed, RegexOptions.Compiled);
                    match = rFailed.Match(td);
                    if (match.Success)
                    {//failed
                        int point = Convert.ToInt32(match.Result("$1"));
                        contestDetail.PointTime.Add(Tuple.Create<int, string>(point, ""));
                    }
                    else
                    {
                        contestDetail.PointTime.Add(Tuple.Create<int, string>(0, ""));
                    }
                }
            }

            //1:rank   
            //2：name   
            //3：总分  有分数   否则直接0
            //4：challenge
            //成功：
            //失败，后面-是否要转义还不明确：

            return contestDetail;
        }

        /// <summary>
        /// 尚未实现 不明用途 orz!!! 三个月之前自己写的代码没有注释，现在竟然就看不懂了。。。
        /// </summary>
        /// <param name="result"></param>
        /// <param name="point"></param>
        /// <param name="timeOrTimes"></param>
        private static void CreateSubmitDetail(string result, out int point, out int timeOrTimes)
        {
            point = 0;
            timeOrTimes = 0;
            //            ac
            //<td problemId="(\d+?)" title="Passed System Test, \+, (.*?)">\s*?<span class="cell-passed-system-

            //test">(\d*?)</span>\s*?<span class="cell-time">(\d\d:\d\d)</span>\s*?</td>
            //$1 problemId
            //$2 language
            //$3 points
            //$4 time

            //wa
            //<td problemId="(\d*?)" title="Failed System Test, (.*?)">\s*?<span class="cell-failed-system-

            //test">\s*?(-\d*?)\s*?</span>\s*?</td>
            //$1 problemId
            //$2 language
            //$3 wa times

            //no submit
            //<td>\s*?<span class="cell-unsubmitted">\s*?&nbsp;\s*?</span>\s*?</td>
        }

        private string GetProfilePage(string user_id)
        {
            string url = string.Format("http://codeforces.com/profile/{0}", user_id);
            return Http.Get(url, null);
        }
    }
}
