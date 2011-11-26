using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RankInAll.Core.Codeforces
{
    class CfContestDetail
    {
        public virtual string UserName { get; set; }

        public virtual int ContestId { get; set; }

        public virtual int Point { get; set; }
        public virtual int Rank { get; set; }

        public virtual int PointA { get; set; }
        public virtual int PointB { get; set; }
        public virtual int PointC { get; set; }
        public virtual int PointD { get; set; }
        public virtual int PointE { get; set; }

        public virtual string TimeA { get; set; }
        public virtual string TimeB { get; set; }
        public virtual string TimeC { get; set; }
        public virtual string TimeD { get; set; }
        public virtual string TimeE { get; set; }

        public virtual int ChallengeFailed { get; set; }
        public virtual int ChallengeSucceed { get; set; }
    }
}
