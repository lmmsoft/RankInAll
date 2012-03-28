using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using RankInAll.Storage;

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

        public void UpdateUserInfo(UserInfo userInfo)
        {
            storage.UpdateUserInfo(userInfo);
        }
    }
}
