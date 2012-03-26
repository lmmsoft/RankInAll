using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RankInAll.Core.OnlineContest.Codeforces;

namespace RankInAll.Core.OnlineContest.Codeforces
{
    //public class CfService
    //{
    //    CodeforcesProvider cf = new CodeforcesProvider();
    //    public void AddUser(string user_id)
    //    {
    //        var user_result_history=cf.GetAllContestResults(user_id);
    //        //有待插入tb_contest_rating表
    //    }
    //    public void AddContest(int contest_id)
    //    {
    //        //add contest

    //        //add contestDetail
    //        var detail = cf.GetContestDetails(contest_id);

    //        //add contestResult

    //    }
    //    public void AddContest_(int contest_id)
    //    {
    //        var info = cf.GetContestInfo(contest_id);
    //        //等待插入数据库info表
    //        //时间有待手动添加
    //    }
    //    public void AddContestDetail(int contest_id)
    //    {
    //        //等待插入数据库detail表的数据
    //        List<CfContestDetail> list_fetch = cf.GetContestDetails(contest_id);
            

    //        //question表的数据在
    //        foreach(var item in list_fetch)
    //        {
    //            foreach(var pointTime in item.PointTime)
    //            {
    //                int point = pointTime.Item1;//point
    //                string time = pointTime.Item2;//time
    //            }
    //        }

    //    }


    //    /// <summary>
    //    /// 以下已废弃
    //    /// </summary>
    //    public void AddContestResult(int contest_id)
    //    {
    //        //foreach user in detail
    //        //get rating
    //        List<CfContestResult> list_fetch = new List<CfContestResult>();
    //        var crudResult = new Crud<CfResult>();
    //        var crudDetail = new Crud<CfDetail>();
    //        //crud.Query("Nickname",

    //    }

    //    private CfResult TransferDetail(CfContestResult result)
    //    {
    //        CfResult cfResult = new CfResult();
    //        cfResult.ContestId = result.ContestId;
    //        cfResult.Nickname = result.UserName;
    //        cfResult.Rating = result.Rating;
            
    //        cfResult.RatingChange = result.Change;
    //        cfResult.Timesplayed = result.Timesplayed;
    //        //result.Rank
    //        //result.ContestName
    //        //result.ContestUrl

    //        return cfResult;
    //    }
    //    private CfDetail TransferDetail(CfContestDetail cfContestDetail)
    //    {
    //        CfDetail cfDetail = new CfDetail();
    //        cfDetail.Nickname = cfContestDetail.UserName;
    //        cfDetail.ChallengeSuccess = cfContestDetail.ChallengeSucceed;
    //        cfDetail.ChallengeFailed = cfContestDetail.ChallengeFailed;
    //        //ac 逻辑上要价
    //        cfDetail.Rank = cfContestDetail.Rank;
    //        cfDetail.Point = cfContestDetail.Point;
    //        cfDetail.ProblemNum = cfContestDetail.ProblemNum;

    //        cfDetail.ContestId = cfContestDetail.ContestId;
            
    //        //eggache!!!
    //        int ac = 0;
    //        int cnt = cfContestDetail.PointTime.Count;
    //        for (int i = 0; i < cnt; ++i)
    //        {
    //            //这个是错的
    //            if (cfContestDetail.PointTime[i].Item1 > 0)
    //                ac++;
    //            if (i == 1)
    //            {
    //                cfDetail.Point1 = cfContestDetail.PointTime[i].Item1;
    //                cfDetail.Time1 = cfContestDetail.PointTime[i].Item2;
    //            }
    //            else if (i == 2)
    //            {
    //                cfDetail.Point2 = cfContestDetail.PointTime[i].Item1;
    //                cfDetail.Time2 = cfContestDetail.PointTime[i].Item2;
    //            }
    //            else if (i == 3)
    //            {
    //                cfDetail.Point3 = cfContestDetail.PointTime[i].Item1;
    //                cfDetail.Time3 = cfContestDetail.PointTime[i].Item2;
    //            }
    //            else if (i == 4)
    //            {
    //                cfDetail.Point4 = cfContestDetail.PointTime[i].Item1;
    //                cfDetail.Time4 = cfContestDetail.PointTime[i].Item2;
    //            }
    //            else if (i == 5)
    //            {
    //                cfDetail.Point5 = cfContestDetail.PointTime[i].Item1;
    //                cfDetail.Time5 = cfContestDetail.PointTime[i].Item2;
    //            }
    //            else if (i == 6)
    //            {
    //                cfDetail.Point6 = cfContestDetail.PointTime[i].Item1;
    //                cfDetail.Time6 = cfContestDetail.PointTime[i].Item2;
    //            }
    //            else if (i == 7)
    //            {
    //                cfDetail.Point7 = cfContestDetail.PointTime[i].Item1;
    //                cfDetail.Time7 = cfContestDetail.PointTime[i].Item2;
    //            }
    //            else if (i == 8)
    //            {
    //                cfDetail.Point8 = cfContestDetail.PointTime[i].Item1;
    //                cfDetail.Time8 = cfContestDetail.PointTime[i].Item2;
    //            }
    //            else if (i == 9)
    //            {
    //                cfDetail.Point9 = cfContestDetail.PointTime[i].Item1;
    //                cfDetail.Time9 = cfContestDetail.PointTime[i].Item2;
    //            }
    //            else if (i == 10)
    //            {
    //                cfDetail.Point10 = cfContestDetail.PointTime[i].Item1;
    //                cfDetail.Time10 = cfContestDetail.PointTime[i].Item2;
    //            }
    //            else if (i == 11)
    //            {
    //                cfDetail.Point11 = cfContestDetail.PointTime[i].Item1;
    //                cfDetail.Time11 = cfContestDetail.PointTime[i].Item2;
    //            }
    //        }
    //        //wrong ac
    //        cfDetail.AC = ac;

    //        return cfDetail;
    //    }
    //    private CfResult TransferResult(CfContestResult cfContestResult)
    //    {
    //        var cfResult = new CfResult();
    //        cfResult.Nickname = cfContestResult.UserName;
    //        cfResult.Rating = cfContestResult.Rating;
    //        cfResult.RatingChange = cfContestResult.Change;
    //        cfResult.Timesplayed = cfContestResult.Timesplayed;
    //        //cfResult.CFContest=cfContestResult.ContestId

    //        return cfResult;
    //    }
    //}
}
