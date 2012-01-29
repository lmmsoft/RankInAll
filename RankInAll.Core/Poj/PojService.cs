using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ranking;

namespace RankInAll.Core.Poj
{
    public class PojService
    {
        PojRank pojRank = new PojRank();
        public void UpdateRealtime()
        {
            List<OjRankEntity> list_fetch = pojRank.GetRankList(pojRank.GetSearchResultByShcool("njust"));
            var curd = new Crud<PojRealtime>();
            PojRealtime realtime;

            foreach (var item in list_fetch)
            {
                //debug
                //if (item.Ac > 19)
                //    continue;
                if (item.Ac <= 5)
                    break;
                realtime = TransferRealtime(item);
                IList<PojRealtime> list_db = curd.Query("Nickname", realtime.Nickname, 0, 20);
                if (list_db.Count == 0)
                {
                    realtime.LastAC = pojRank.GetLastAc(realtime.Nickname);
                    curd.Insert(realtime);
                }
                else
                {
                    if (list_db[0].AC != realtime.AC)
                    {
                        realtime.LastAC = pojRank.GetLastAc(realtime.Nickname);
                    }
                    realtime.Id = list_db[0].Id;
                    curd.Update(realtime);
                }
                //historyEntity = TransferHistory(item);
                //curd.Insert(historyEntity);
                Console.WriteLine("{0}:{1}:{2}:{3}", item.No, item.UserName, item.Ac, item.Submit);
            }
        }

        public void UpdateHistory()
        {
            List<OjRankEntity> list_fetch = pojRank.GetRankList(pojRank.GetSearchResultByShcool("njust"));
            Crud<PojHistory> curd = new Crud<PojHistory>();
            PojHistory historyEntity;
            
            foreach (var item in list_fetch)
            {
                //少于5题的不存入历史
                if (item.Ac <= 5)
                    break;
                historyEntity = TransferHistory(item);
                curd.Insert(historyEntity);
                Console.WriteLine("{0}:{1}:{2}:{3}", item.No, item.UserName, item.Ac, item.Submit);
            }
        }

        public PojRealtime TransferRealtime(OjRankEntity rank)
        {
            PojRealtime real = new PojRealtime();
            real.AC = rank.Ac;
            real.Nickname = rank.UserName;
            real.Submit = rank.Submit;
            real.LastAC = new PojRank().GetLastAc(rank.UserName);

            return real;
        }
        public PojHistory TransferHistory(OjRankEntity rank)
        {
            PojHistory history = new PojHistory();
            history.AC = rank.Ac;
            history.Nickname = rank.UserName;
            history.Submit = rank.Submit;
            history.PojDate = DateTime.Today;
            return history;
        }
        
    }
}
