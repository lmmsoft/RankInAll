using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RankInAll.Service.OnlineContest;
using RankInAll.Core.OnlineContest.Topcoder;

namespace RankInAll.Service.OnlineContest.Topcoder
{
    public class TCService : IOnlineContestService
    {
        TopcoderProvider tc = new TopcoderProvider();

        void IOnlineContestService.UpdateRating()
        {
            //从数据库拿到所有tc账号
            //把User改成数据库的实体类
            List<User> users=new List<User>();

            //根据每个user_name抓取用户信息
            foreach (var user in users)
            {
                var ur=tc.GetProfile(user.UserName);
                //把ur.Rating更新到数据库里面
            }
            
        }
    }
}
