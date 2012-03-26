using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RankInAll.Core.OnlineContest.Topcoder
{
    class TcEntity
    {
    }
    public class User
    {
        public virtual string UserName { get; set; }
        public virtual int Timesplayed { get; set; }
        public virtual int Rating { get; set; }
        public virtual int Volatility { get; set; }
        public virtual string Color { get; set; }
        public virtual string MostRecentEvent { get; set; }
    } 
}
