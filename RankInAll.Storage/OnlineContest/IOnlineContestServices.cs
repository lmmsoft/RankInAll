using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RankInAll.Storage.OnlineContest
{
    public interface IOnlineContestService
    {
        void UpdateRatings();
        void UpdateRating(string user_name);
    }
}