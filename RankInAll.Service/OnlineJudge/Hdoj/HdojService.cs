using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RankInAll.Core.OnlineJudge;
using RankInAll.Core.OnlineJudge.Hdoj;

namespace RankInAll.Service.OnlineJudge.Hdoj
{
    public class HdojService:IOnlineJudgeService
    {
        HdojRank hdojRank = new HdojRank();

        //public HdojService() { }

        //public HduRealtime TransferRealtime(OjRankEntity rank)
        //{
        //    HduRealtime real = new HduRealtime();
        //    real.AC = rank.Ac;
        //    real.Nickname = rank.UserName;
        //    real.Submit = rank.Submit;
        //    //real.LastAC = hdojRank.GetLastAC(rank.UserName);
        //    return real;
        //}
        //public HduHistory TransferHistory(OjRankEntity rank)
        //{
        //    HduHistory history = new HduHistory();
        //    history.AC = rank.Ac;
        //    history.Nickname = rank.UserName;
        //    history.Submit = rank.Submit;
        //    history.HduDate = DateTime.Today;
        //    return history;
        //}

        /// <summary>
        /// 暂时还没实时rank吧？
        /// </summary>
        void IOnlineJudgeService.Update()
        {
            List<OjRankEntity> list_fetch = hdojRank.GetRankList(hdojRank.GetSearchResult("njust"));
            //Crud<HduRealtime> curd = new Crud<HduRealtime>();
            //HduRealtime realtime;

            foreach (var item in list_fetch)
            {
                //少于5题的不存入实时
                if (item.Ac <= 5)
                    break;
                //realtime = TransferRealtime(item);
                //IList<HduRealtime> list_db = curd.Query("Nickname", realtime.Nickname, 0, 20);
                //if (list_db.Count == 0)
                //{
                //    realtime.LastAC = hdojRank.GetLastAC(realtime.Nickname);
                //    curd.Insert(realtime);
                //}
                //else
                //{
                //    if (list_db[0].AC != realtime.AC)
                //    {
                //        realtime.LastAC = hdojRank.GetLastAC(realtime.Nickname);
                //    }
                //    realtime.Id = list_db[0].Id;
                //    curd.Update(realtime);
                //}
            }
        }
        /// <summary>
        /// 要是效率太低的话直接转换成list<db_rank> 再插入
        /// </summary>
        /// <returns></returns>
        bool IOnlineJudgeService.Daily()
        {
            string web = hdojRank.GetSearchResult("njust");
            if (web == null)
                return false;

            List<OjRankEntity> list_fetch = hdojRank.GetRankList(web);
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
