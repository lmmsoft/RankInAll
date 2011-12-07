using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RankInAll.Core.Codeforces
{
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
}
