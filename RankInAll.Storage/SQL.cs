using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RankInAll.Core.OnlineJudge;
//using RankInAll.Core.OnlineContest;

namespace RankInAll.Storage
{
    public class SQL
    {
        /// <summary>
        /// 更新一条ojrank
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="OJTableName"></param>
        /// <returns></returns>
        public static string UpdateOJRank(OjRankEntity entity, string OJTableName)
        {
            string sql = string.Format("REPLACE INTO `{0}` VALUES (NULL, '{1}', '{2}', '{3}', '{4}', '{5}')",
                OJTableName, entity.UserName, entity.Ac, entity.Submit, DateTime.Today, DateTime.Today);
            return sql;
        }

        //public static string GetSqlOJRankSelectAll(OjRankEntity entity, string OJTableName)
        //{
        //    string sql = string.Format("REPLACE INTO `{0}` VALUES (NULL, '{1}', '{2}', '{3}', '{4}', '{5}')",
        //        OJTableName, entity.UserName, entity.Ac, entity.Submit, DateTime.Today, DateTime.Today);
        //    return sql;
        //}
        
        public static string UpdateTopcoderUser(RankInAll.Core.OnlineContest.Topcoder.User user)
        {
            string sql = string.Format("REPLACE INTO `rank_in_all`.`tc` (`id`, `user_name`, `rating`, `volatility`, `last_contest`) VALUES (NULL, '{0}', '{1}', '{2}', '{3}')",
                user.UserName, user.Rating, user.Volatility, user.MostRecentEvent);
            return sql;
        }
        public static string UpdateCodeforcesUser(RankInAll.Core.OnlineContest.Codeforces.User user)
        {
            string sql = string.Format("REPLACE INTO `rank_in_all`.`cf` (`id`, `user_name`, `rating`, `last_contest`) VALUES ('{0}', '{1}', '{2}', '{3}')",
                null, user.UserName, user.Rating, null);
            return sql;
        }
        public static string GetAll(int start,int length,int type)
        {
            string sql = string.Format("SELECT user.njustoj_name, user.true_name,poj.ac as poj,hdoj.ac as hdoj,cf.rating as cf,tc.rating as tc FROM `user`\n"
                        + "left JOIN poj\n"
                        + "on user.poj_name=poj.user_name\n"
                        + "\n"
                        + "left JOIN hdoj\n"
                        + "on user.hdoj_name=hdoj.user_name\n"
                        + "\n"
                        + "left JOIN cf\n"
                        + "on user.cf_name=cf.user_name\n"
                        + "\n"
                        + "left JOIN tc\n"
                        + "on user.tc_name=tc.user_name "
                        + "WHERE TYPE ={2} "
                        + "ORDER BY poj.ac DESC  LIMIT {0},{1} ",
                        start,length,type);
            return sql;
        }

        public static string GetUser(string user_name)
        {
            string sql = string.Format("SELECT * FROM `rank_in_all`.`user` WHERE njustoj_name='{0}'",
                user_name);
            return sql;
        }
        public static string UpdateUser(UserInfo user)
        {
            string sql = string.Format("REPLACE INTO `rank_in_all`.`user`"
                +" (`id`, `njustoj_name`, `poj_name`, `hdoj_name`, `cf_name`, `tc_name`, `true_name`, `njustoj_id`, `token`, `type`) "
                +"VALUES (NULL, '{0}', '{1}', '{2}', '{3}', '{4}', {5}, {6}, {7}, '{8}');",
                user.NjustOjName,user.PojName,user.HdojName,user.CfName,user.TcName,user.TrueName,user.NjustOjId,user.AccessToken,user.Type);
            return sql;
        }
        public static string Check(string user_name, int type)
        {
            string sql = string.Format("SELECT * FROM `user` WHERE njustoj_name='{0}' and type={1}",
                user_name, type);
            return sql;
        }
    }
}
