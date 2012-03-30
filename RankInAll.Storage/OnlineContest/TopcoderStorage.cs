using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RankInAll.Core.OnlineContest.Topcoder;

namespace RankInAll.Storage.OnlineContest
{
    public class TopcoderStorage : IOnlineContestService
    {
        TopcoderProvider provider = new TopcoderProvider();
        Storage storage = new Storage();

        public void UpdateRatings()
        {
            var tc = new RankInAll.Core.OnlineContest.Topcoder.TopcoderProvider();

            List<string> list = storage.GetCFUsers();
            foreach (var userName in list)
            {
                var user = tc.GetProfile(userName);
                //把ur.Rating更新到数据库里面
                if (user != null)
                    storage.UpdateTopcoder(user);
            }
        }

        public void UpdateRating(string userName)
        {
            var user = provider.GetProfile(userName);
            //把ur.Rating更新到数据库里面
            if (user != null)
                storage.UpdateTopcoder(user);
        }
    }
}
