using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RankInAll.Core.OnlineJudge;
using RankInAll.Core.OnlineJudge.POJ;

namespace RankInAll.Service.OnlineJudge.POJ
{
    public class PojService : IOnlineJudgeService
    {
        PojRank pojRank = new PojRank();

        //public PojRealtime TransferRealtime(OjRankEntity rank)
        //{
        //    PojRealtime real = new PojRealtime();
        //    real.AC = rank.Ac;
        //    real.Nickname = rank.UserName;
        //    real.Submit = rank.Submit;
        //    real.LastAC = new PojRank().GetLastAC(rank.UserName);

        //    return real;
        //}
        //public PojHistory TransferHistory(OjRankEntity rank)
        //{
        //    PojHistory history = new PojHistory();
        //    history.AC = rank.Ac;
        //    history.Nickname = rank.UserName;
        //    history.Submit = rank.Submit;
        //    history.PojDate = DateTime.Today;
        //    return history;
        //}


        /// <summary>
        /// 更新实时rank
        /// </summary>
        public void Update()
        {
            List<OjRankEntity> list_fetch = pojRank.GetRankList(pojRank.GetSearchResultByShcool("njust"));
            //var curd = new Crud<PojRealtime>();
            //PojRealtime realtime;

            foreach (var item in list_fetch)
            {
                //debug
                //if (item.Ac > 19)
                //    continue;
                if (item.Ac <= 5)
                    break;
                ////转换格式
                //realtime = TransferRealtime(item);

                ////查询数据库里面的旧记录
                //IList<PojRealtime> list_db = curd.Query("Nickname", realtime.Nickname, 0, 20);
                ////没有旧记录的话插入
                //if (list_db.Count == 0)
                //{
                //    realtime.LastAC = pojRank.GetLastAC(realtime.Nickname);
                //    curd.Insert(realtime);
                //}
                //else
                //{
                ////做题数量增加了，要更新ac日期
                //    if (list_db[0].AC != realtime.AC)
                //    {
                //        realtime.LastAC = pojRank.GetLastAC(realtime.Nickname);
                //    }
                //    realtime.Id = list_db[0].Id;
                //    curd.Update(realtime);
                //}
                ////插入数据库
                //historyEntity = TransferHistory(item);
                //curd.Insert(historyEntity);
                Console.WriteLine("{0}:{1}:{2}:{3}", item.No, item.UserName, item.Ac, item.Submit);
            }
        }

        public bool Daily()
        {
            string web = pojRank.GetSearchResultByShcool("njust");
            if (web == null)
                return false;

            List<OjRankEntity> list_fetch = pojRank.GetRankList(web);

            foreach (var item in list_fetch)
            {
                //少于5题的不存入历史
                if (item.Ac <= 5)
                    break;
                //1.类型转换
                //historyEntity = TransferHistory(item);
                //2.插入数据库
                //curd.Insert(historyEntity);
                //3.控制台输出信息
                Console.WriteLine("{0}:{1}:{2}:{3}", item.No, item.UserName, item.Ac, item.Submit);
            }
            return true;
        }
    }
}
