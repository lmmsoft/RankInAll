using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RankInAll.Core.OnlineContest.Codeforces;

namespace RankInAll.Storage.OnlineContest
{
    public class CodeforcesStorage : IOnlineContestService
    {
        CodeforcesProvider provider = new CodeforcesProvider();
        Storage storage = new Storage();

        public void UpdateRatings()
        {
            var cf = new RankInAll.Core.OnlineContest.Codeforces.CodeforcesProvider();

            List<string> list = storage.GetCFUsers();
            foreach (var userName in list)
            {
                var user = cf.GetProfile(userName);
                //把ur.Rating更新到数据库里面
                if (user != null)
                    storage.UpdateCodeforce(user);
            }
        }

        public void UpdateRating(string userName)
        {
            var user = provider.GetProfile(userName);
            //把ur.Rating更新到数据库里面
            if (user != null)
                storage.UpdateCodeforce(user);
        }

        /// <summary>
        /// 根据比赛id获取比赛的一些信息
        /// </summary>
        /// <param name="constent_id"></param>
        void AddContestInfo(int constent_id)
        {
            //目前能抓到type="cf"  url  name  div 暂时抓不到data
            CfContestInfo info = provider.GetContestInfo(constent_id);
            //存入数据库
            //save info
        }

        /// <summary>
        /// 根据比赛id获取所有人的比赛信息
        /// </summary>
        /// <param name="constent_id"></param>
        void AddContestResult(int constent_id)
        {
            //抓到比赛的所有结果，包括user里面没有的用户，都要存到数据库里面噢（方便后期增加新用户嘛）
            List<CfContestDetail> list = provider.GetContestDetails(constent_id);

            //下面是存储比赛详细结果
            foreach (var detail in list)
            {
                //detail.PointTime是个list<Tuple<int, string> >大小是detail.ProblemNum,具体内容看注释
                foreach (var PT in detail.PointTime)
                {
                    int point = PT.Item1;
                    string time = PT.Item2;
                }
            }
        }

        /// <summary>
        /// 批量增加cf比赛信息和比赛结果
        /// </summary>
        void AddContestsAndResult(int from, int to)
        {
            if (from >= to)
            {
                int tmp = to;
                to = from;
                from = tmp;
            }
            for (int index = from; index <= to; ++index)
            {
                AddContestInfo(index);
                AddContestResult(index);
            }
        }



    }
}
