using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RankInAll.Core.OnlineContest.Codeforces
{
    //public class CfService
    //{
    //    CodeforcesProvider cf = new CodeforcesProvider();
    //    public void AddContestRating(string user_id)
    //    {
    //        Crud<Rating> crud = new Crud<Rating>();
    //        Rating rating = new Rating();               
    //        var users = cf.GetAllContestResults(user_id);
    //        foreach (var tmp in users)
    //        {
    //            rating.ContestId = tmp.ContestId;
    //            rating.Contestname = tmp.ContestName;
    //            rating.Username = tmp.UserName;
    //            rating.Rank = tmp.Rank;
    //            rating.RaTing = tmp.Rating;
    //            rating.Timesplayed = tmp.Timesplayed;
    //            rating.Type = "CF";
    //            crud.Insert(rating);                  
    //        }
            
    //        //有待插入tb_contest_rating表
    //    }

    //    public void AddContestInfo(int contest_id)
    //    {
    //        var info = cf.GetContestInfo(contest_id);
    //        Crud<Info> crud = new Crud<Info>();
    //        Info tmp = new Info();
    //        tmp.AllNum = info.allnum;
    //        tmp.ContestId = info.ContestId;
    //        tmp.Divc = info.div;
    //        tmp.Type = "CF";
    //        tmp.ContestName = info.ContestName;
    //        //tmp.ContestType
    //        //tmp.ContestDate    
    //        crud.Insert(tmp);
    //        //等待插入数据库info表
    //        //时间有待手动添加
    //    }
        
    //    public void AddContestDetail(int contest_id)
    //    {
    //        //插入数据库question表的数据
    //        List<CfContestDetail> list_fetch = cf.GetContestDetails(contest_id);
    //        int allNum = list_fetch.First().PointTime.Count;
    //        Crud<Detail> crud = new Crud<Detail>();
    //        Crud<Question> crud2 = new Crud<Question>();       
    //        Question question = new Question();
    //        Detail detail = new Detail();
    //        foreach (var item in list_fetch)//每一个user
    //        {
    //            detail.ContestId = item.ContestId;
    //            detail.Username = item.UserName;
    //            detail.AllNum = item.PointTime.Count;
                
    //            detail.ChallengeSuccess = item.ChallengeSucceed;
    //            detail.ChallengeFailed = item.ChallengeFailed;
    //            detail.Type = "cf";
                
    //            //detail.ContestName 等待加入
    //            int allpoint=0;
                
    //            question.ContestId = item.ContestId;          
    //            question.UserName = item.UserName;
    //            question.Type = "cf";
    //            int i=1;
    //            foreach (var pointTime in item.PointTime)//每一个user的每一题
    //            {
    //                int point = pointTime.Item1;//point
    //                question.Point = point;
    //                string time = pointTime.Item2;//time
    //                question.Time = Convert.ToInt32(time);//调试下
    //                question.Num = i;                                       
    //                i++;
    //                allpoint += point;
    //            }
    //        }
    //    }

    //}
}
