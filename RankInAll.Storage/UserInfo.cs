using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RankInAll.Storage
{
    public class UserInfo
    {
        public virtual string NjustOjName { get; set; }
        public virtual string PojName { get; set; }
        public virtual string HdojName { get; set; }
        public virtual string CfName { get; set; }
        public virtual string TcName { get; set; }
        public virtual string TrueName { get; set; }
        public virtual int NjustOjId { get; set; }
        public virtual string AccessToken { get; set; }
        public virtual int Type { get; set; }
    }
    public class DBAllRank
    {
        public virtual string NjustOjName { get; set; }
        public virtual string TrueName { get; set; }
        public virtual int PojAcceptCount { get; set; }
        public virtual int HduAcceptCount { get; set; }
        public virtual int CfRating { get; set; }
        public virtual int TcRating { get; set; }
    }
}
