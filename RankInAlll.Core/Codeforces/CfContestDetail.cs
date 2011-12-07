using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RankInAll.Core.Codeforces
{
    public class CfContestDetail
    {
        public virtual string UserName { get; set; }

        public virtual int ContestId { get; set; }

        public virtual int Point { get; set; }
        public virtual int Rank { get; set; }

        public virtual int ProblemNum { get; set; }

        public virtual List<Tuple<int, string>> PointTime { get; set; }

        public virtual int ChallengeFailed { get; set; }
        public virtual int ChallengeSucceed { get; set; }
    }
}
