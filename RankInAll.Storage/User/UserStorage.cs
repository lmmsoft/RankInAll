using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using RankInAll.Storage;
using Fish.OpenJudge.OpenPlatform.SDK;

namespace RankInAll.Storage
{
    public class UserStorage
    {
        Storage storage = new Storage();

        /// <summary>
        /// 获得一个用户的信息
        /// </summary>
        /// <param name="user_name"></param>
        /// <returns></returns>
        public UserInfo GetUserInfo(string user_name)
        {
            return storage.GetUserInfo(user_name);
        }
        public UserInfo GetUserInfo(int njustoj_id)
        {
            return storage.GetUserInfo(njustoj_id);
        }

        public void UpdateUserInfo(UserInfo userInfo)
        {
            storage.UpdateUserInfo(userInfo);
        }

        public UserInfo UpdateUserName(UserInfo userInfo,int njustOjId)
        {
            var old = GetUserInfo(njustOjId);

            userInfo.AccessToken = old.AccessToken;
            userInfo.Type = old.Type;
            userInfo.NjustOjId = old.NjustOjId;
            userInfo.NjustOjName = old.NjustOjName;

            if (userInfo.CfName!=null && old.CfName != userInfo.CfName)
            {
                var sto_cf = new OnlineContest.CodeforcesStorage();
                sto_cf.UpdateRating(userInfo.CfName);
            }
            if (userInfo.TcName != null && old.TcName != userInfo.TcName)
            {
                var sto_tc = new OnlineContest.TopcoderStorage();
                sto_tc.UpdateRating(userInfo.TcName);
            }

            UpdateUserInfo(userInfo);

            return userInfo;
        }

        public UserInfo UpdateUserApi(Fish.OpenJudge.OpenPlatform.SDK.UserInfo apiInfo, int njustOjId, string AccessToken)
        {
            var userInfo = GetUserInfo(njustOjId);
            if (userInfo == null)
            {
                userInfo = new UserInfo();
            }

            userInfo.NjustOjId = njustOjId;
            userInfo.Type = 1;
            userInfo.NjustOjName=apiInfo.Name;
            userInfo.TrueName = apiInfo.NickName;
            userInfo.AccessToken = AccessToken;

            UpdateUserInfo(userInfo);

            return userInfo;
        }
    }
}
