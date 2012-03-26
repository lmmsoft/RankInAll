using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RankInAll.Core.OnlineJudge
{
    public interface IOnlineJudge
    {
        /// <summary>
        /// 根据oj用户名查询上次ac时间
        /// </summary>
        /// <param name="user_id">oj用户名</param>
        /// <returns>上次ac时间</returns>
        DateTime GetLastAC(string user_id);

        /// <summary>
        /// 根据oj用户名查询用户信息
        /// </summary>
        /// <param name="user_id">oj用户名</param>
        /// <returns>用户信息</returns>
        OjRankEntity GetUserStatus(string user_id);

        /// <summary>
        /// 从oj的搜索页面匹配出list<OjRankEntity>页面里所有用户的oj ac submit等信息
        /// </summary>
        /// <param name="web"></param>
        /// <returns></returns>
        List<OjRankEntity> GetRankList(string web);

        /// <summary>
        /// oj搜索页面的源码匹配出用户信息
        /// </summary>
        /// <param name="web">oj搜索页面的一段源码</param>
        /// <returns>用户oj的ac submit等信息</returns>
        OjRankEntity CreateOjRank(string web);

        /// <summary>
        /// 获取oj的搜索结果
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        string GetSearchResult(string str);
    }
}
