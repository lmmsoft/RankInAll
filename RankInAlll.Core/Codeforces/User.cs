using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RankInAll.Core.Codeforces
{
    class User
    {
        public virtual int No { get; set; }
        public virtual string UserName { get; set; }
        public virtual string NickName { get; set; }
        public virtual int Timesplayed { get; set; }
        public virtual int Rating { get; set; }
        public virtual string Color { get; set; }
    }
}
