using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RankInAll.Core
{
    public class OjRankEntity
    {
        public virtual int No { get; set; }
        public virtual string UserName { get; set; }
        public virtual string NickName { get; set; }
        public virtual string School { get; set; }
        public virtual string Email { get; set; }
        public virtual int Ac { get; set; }
        public virtual int Submit { get; set; }
    }
}
