using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ranking;

namespace RankInAll.Core.Hdoj
{
    public class HdojService
    {
        HdojRank hdojRank = new HdojRank();

        public HdojService() { }

        public void UpdateRealtime()
        {
            
            List<OjRankEntity> list_fetch = hdojRank.GetRankList(hdojRank.GetSearchResult("njust"));
            Crud<HduRealtime> curd = new Crud<HduRealtime>();
            HduRealtime realtime;

            foreach (var item in list_fetch)
            {
                //少于5题的不存入实时
                if (item.Ac <= 5)
                    break;
                realtime = TransferRealtime(item);
                IList<HduRealtime> list_db = curd.Query("Nickname", realtime.Nickname, 0, 20);
                if (list_db.Count == 0)
                {
                    realtime.LastAC = hdojRank.GetLastAC(realtime.Nickname);
                    curd.Insert(realtime);
                }
                else
                {
                    if (list_db[0].AC != realtime.AC)
                    {
                        realtime.LastAC = hdojRank.GetLastAC(realtime.Nickname);
                    }
                    realtime.Id = list_db[0].Id;
                    curd.Update(realtime);
                }
            }
        }

        public void UpdateHistory()
        {
            List<OjRankEntity> list_fetch = hdojRank.GetRankList(hdojRank.GetSearchResult("njust"));
            Crud<HduHistory> curd = new Crud<HduHistory>();
            HduHistory historyEntity;

            foreach (var item in list_fetch)
            {
                //少于5题的不存入历史
                if (item.Ac <= 5)
                    break;
                historyEntity = TransferHistory(item);
                curd.Insert(historyEntity);
            }
        }

        public HduRealtime TransferRealtime(OjRankEntity rank)
        {
            HduRealtime real = new HduRealtime();
            real.AC = rank.Ac;
            real.Nickname = rank.UserName;
            real.Submit = rank.Submit;
            //real.LastAC = hdojRank.GetLastAC(rank.UserName);
            return real;
        }
        public HduHistory TransferHistory(OjRankEntity rank)
        {
            HduHistory history = new HduHistory();
            history.AC = rank.Ac;
            history.Nickname = rank.UserName;
            history.Submit = rank.Submit;
            history.HduDate = DateTime.Today;
            return history;
        }
    }
}
