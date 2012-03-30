using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using MySql.Data.MySqlClient;


namespace RankInAll.Storage
{
    public class Storage
    {
        MySqlConnection mySqlCon;
        MySqlCommand mySqlCommand;
        MySqlDataReader reader;
        public Storage()
        {
            mySqlCon = Mysql.getMySqlCon();
            mySqlCommand = new MySqlCommand();
            mySqlCommand.Connection = mySqlCon;
            mySqlCon.Open();
        }
        public void test()
        {
            //查询sql
            String sqlSearch = "select * from oj_history";
            //插入sql
            String sqlInsert = "insert into student values (12,'张三',25,'大专')";
            //修改sql
            String sqlUpdate = "update student set name='李四' where id= 3";
            //删除sql
            String sqlDel = "delete from student where id = 12";
            //打印SQL语句
            //Console.WriteLine(sqlDel);


            //四种语句对象
            //MySqlCommand mySqlCommand = getSqlCommand(sqlSearch, mysql);
            MySqlCommand mySqlCommand = Mysql.getSqlCommand(sqlSearch, mySqlCon);
            //MySqlCommand mySqlCommand = getSqlCommand(sqlUpdate, mysql);
            //MySqlCommand mySqlCommand = getSqlCommand(sqlDel, mysql);



            mySqlCon.Open();
            //getResultset(mySqlCommand);
            //getInsert(mySqlCommand);



            //PojRank pojRank = new PojRank();
            //List<OjRankEntity> list_fetch = pojRank.GetRankList(pojRank.GetSearchResultByShcool("njust"));

            //foreach (var item in list_fetch)
            //{
            //    if (item.Ac < 10)
            //        break;
            //    mySqlCommand.CommandText = GetInsertSql(item, 1);
            //    Console.WriteLine(mySqlCommand.CommandText);

            //    mySqlCommand.ExecuteNonQuery();
            //}
            //Console.WriteLine("今日POJ任务执行完毕");


            //var hdojRank = new HdojRank();
            //list_fetch = hdojRank.GetRankList(hdojRank.GetSearchResult("njust"));
            //foreach (var item in list_fetch)
            //{
            //    if (item.Ac < 10)
            //        break;
            //    mySqlCommand.CommandText = GetInsertSql(item, 2);
            //    Console.WriteLine(mySqlCommand.CommandText);

            //    mySqlCommand.ExecuteNonQuery();
            //}
            //Console.WriteLine("今日HDOJ任务执行完毕");

            //getUpdate(mySqlCommand);
            //getDel(mySqlCommand);


            //记得关闭
            mySqlCon.Close();
            //String readLine = Console.ReadLine();
        }

        public static string GetConnectionString()
        {
            IEnumerable<string> str = File.ReadLines("config.txt");
            return str.First();
        }

        /// <summary>
        /// 获得一个用户的信息 根据用户名
        /// </summary>
        /// <param name="user_name"></param>
        /// <returns></returns>
        public UserInfo GetUserInfo(string user_name)
        {
            mySqlCommand.CommandText = SQL.GetUser(user_name);
            UserInfo userinfo = null;
            reader = mySqlCommand.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    userinfo = new UserInfo()
                    {
                        NjustOjName = reader.GetString("njustoj_name"),
                        PojName = CheckStringDBNull("poj_name"),
                        HdojName = CheckStringDBNull("hdoj_name"),
                        CfName = CheckStringDBNull("cf_name"),
                        TrueName = CheckStringDBNull("true_name"),
                        NjustOjId = reader.GetInt32("njustoj_id"),
                        AccessToken = CheckStringDBNull("token"),
                        Type = reader.GetInt32("type")
                    };
                }
            }
            catch (Exception)
            {
                Console.WriteLine("查询失败了！");
            }
            finally
            {
                reader.Close();
            }
            return userinfo;
        }

        /// <summary>
        /// 获得一个用户的信息 根据njustoj-id
        /// </summary>
        /// <param name="njustoj_id"></param>
        /// <returns></returns>
        public UserInfo GetUserInfo(int njustoj_id)
        {
            mySqlCommand.CommandText = SQL.GetUser(njustoj_id);
            UserInfo userinfo = null;
            reader = mySqlCommand.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    userinfo = new UserInfo()
                    {
                        NjustOjName = reader.GetString("njustoj_name"),
                        PojName = CheckStringDBNull("poj_name"),
                        HdojName = CheckStringDBNull("hdoj_name"),
                        CfName = CheckStringDBNull("cf_name"),
                        TcName = CheckStringDBNull("tc_name"),
                        TrueName = CheckStringDBNull("true_name"),
                        NjustOjId = reader.GetInt32("njustoj_id"),
                        AccessToken = CheckStringDBNull("token"),
                        Type = reader.GetInt32("type")
                    };
                }
            }
            catch (Exception)
            {
                Console.WriteLine("查询失败了！");
            }
            finally
            {
                reader.Close();
            }
            return userinfo;
        }

        /// <summary>
        /// 更新一个用户的信息
        /// </summary>
        /// <param name="user_name"></param>
        /// <returns></returns>
        public void UpdateUserInfo(UserInfo userInfo)
        {
            mySqlCommand.CommandText = SQL.UpdateUser(userInfo);
            mySqlCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// 获取rank （要重构抽出）
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<DBAllRank> GetRanks(int type)
        {
            mySqlCommand.CommandText = SQL.GetRanks(0, 200, type);
            List<DBAllRank> list = new List<DBAllRank>();
            reader = mySqlCommand.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    list.Add(new DBAllRank()
                    {
                        PojAcceptCount = CheckIntDBNull("poj"),
                        HduAcceptCount = CheckIntDBNull("hdoj"),
                        CfRating = CheckIntDBNull("cf"),
                        TcRating = CheckIntDBNull("tc"),
                        NjustOjName = CheckStringDBNull("njustoj_name"),
                        TrueName = CheckStringDBNull("true_name")
                    });
                }
            }
            catch (Exception)
            {
                Console.WriteLine("查询失败了！");
            }
            finally
            {
                reader.Close();
            }
            return list;
        }

        /// <summary>
        /// 获取rank （要重构抽出）
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public DBAllRank GetRank(int njustoj_id)
        {
            mySqlCommand.CommandText = SQL.GetRank(njustoj_id);
            DBAllRank rank = null;
            reader = mySqlCommand.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    rank = (new DBAllRank()
                    {
                        PojAcceptCount = CheckIntDBNull("poj"),
                        HduAcceptCount = CheckIntDBNull("hdoj"),
                        CfRating = CheckIntDBNull("cf"),
                        TcRating = CheckIntDBNull("tc"),
                        NjustOjName = CheckStringDBNull("njustoj_name"),
                        TrueName = CheckStringDBNull("true_name")
                    });
                }
            }
            catch (Exception)
            {
                Console.WriteLine("查询失败了！");
            }
            finally
            {
                reader.Close();
            }
            return rank;
        }

        public void UpdateCodeforce(RankInAll.Core.OnlineContest.Codeforces.User user)
        {
            mySqlCommand.CommandText = SQL.UpdateCodeforcesUser(user);
            mySqlCommand.ExecuteNonQuery();
        }

        public void UpdateTopcoder(RankInAll.Core.OnlineContest.Topcoder.User user)
        {
            mySqlCommand.CommandText = SQL.UpdateTopcoderUser(user);
            mySqlCommand.ExecuteNonQuery();
        }

        public void UpdateOJRank(RankInAll.Core.OnlineJudge.OjRankEntity entity, string OJTableName)
        {
            mySqlCommand.CommandText = SQL.UpdateOJRank(entity, OJTableName);
            mySqlCommand.ExecuteNonQuery();
        }


        /// <summary>
        /// 获得所有cf用户名
        /// </summary>
        /// <returns></returns>
        public List<string> GetCFUsers()
        {
            mySqlCommand.CommandText = SQL.GetCodeforcesUsers();
            List<string> list = new List<string>();
            reader = mySqlCommand.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    list.Add(CheckStringDBNull("cf_name"));
                }
            }
            catch (Exception)
            {
                Console.WriteLine("查询失败了！");
            }
            finally
            {
                reader.Close();
            }
            return list;
        }

        public List<string> GetTCUsers()
        {
            mySqlCommand.CommandText = SQL.GetTopcoderUsers();
            List<string> list = new List<string>();
            reader = mySqlCommand.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    list.Add(CheckStringDBNull("tc_name"));
                }
            }
            catch (Exception)
            {
                Console.WriteLine("查询失败了！");
            }
            finally
            {
                reader.Close();
            }
            return list;
        }


        /// <summary>
        /// 防止db null引发的异常
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public string CheckStringDBNull(string row)
        {
            if (Convert.IsDBNull(reader[row]))
            {
                return null;
            }
            else
                return reader.GetString(row);
        }

        public int CheckIntDBNull(string row)
        {
            if (Convert.IsDBNull(reader[row]))
            {
                return 0;
            }
            else
                return reader.GetInt32(row);
        }
    }
}
