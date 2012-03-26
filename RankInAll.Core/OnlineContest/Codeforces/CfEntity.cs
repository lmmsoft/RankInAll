using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RankInAll.Core.OnlineContest.Codeforces
{
    class CfEntity
    {
    }
    public class User
    {
        public virtual int No { get; set; }
        public virtual string UserName { get; set; }
        public virtual string NickName { get; set; }
        public virtual int Timesplayed { get; set; }
        public virtual int Rating { get; set; }
        public virtual string Color { get; set; }
    }

    public class CfContestInfo
    {
        public virtual string ContestName { get; set; }
        public virtual string ContestUrl { get; set; }
        public virtual int ContestId { get; set; }
        public virtual DateTime ContestDate { get; set; }
        public virtual int div { get; set; }
        //public virtual int allnum { get; set; }
        public virtual string type { get; set; }//这个数据库里面指的是cf或tc，以后要重构
    }
    public class CfContestDetail
    {
        public virtual string UserName { get; set; }

        public virtual int ContestId { get; set; }
        /// <summary>
        /// 比赛的得分
        /// </summary>
        public virtual int Point { get; set; }
        /// <summary>
        /// 比赛排名
        /// </summary>
        public virtual int Rank { get; set; }
        /// <summary>
        /// 比赛题目数量
        /// </summary>
        public virtual int ProblemNum { get; set; }
        /// <summary>
        /// 这是个list,里面包含 Tuple(int, string) 分别是用户某道题的得分和时间，如(1104, "01:06")，如果没交题，是(0, "")，如果交题但是failed ,类似于(-2, "") int熟悉时失败次数
        /// </summary>
        public virtual List<Tuple<int, string> > PointTime { get; set; }

        public virtual int ChallengeFailed { get; set; }
        public virtual int ChallengeSucceed { get; set; }
    }
    public class CfContestResult
    {
        public virtual string UserName { get; set; }

        public virtual string ContestName { get; set; }
        public virtual string ContestUrl { get; set; }
        public virtual int ContestId { get; set; }

        public virtual int Timesplayed { get; set; }
        public virtual int Rating { get; set; }
        public virtual int Rank { get; set; }
        public virtual int Change { get; set; }
    }
    //都是大于等于
    public enum Color
    {
        Red = 2200,
        Orange = 1900,
        Violet = 1700,
        Blue = 1500,
        green = 1200,
        grey = 0
    }
    public enum Title
    {
        Internationalgrandmaster = 2600,
        Grandmaster = 2200,
        Internationalmaster = 2050,
        Master = 1900,
        Candidatemaster = 1700,
        Expert = 1500,
        Specialist = 1350,
        Pupil = 1200,
        Newbie = 0
    }
}
