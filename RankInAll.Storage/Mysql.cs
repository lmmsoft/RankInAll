using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace RankInAll.Storage
{
    public class Mysql
    {
        /// <summary>
        /// 建立mysql数据库链接
        /// </summary>
        /// <returns></returns>
        public static MySqlConnection getMySqlCon()
        {
            String mysqlStr = System.Configuration.ConfigurationManager.ConnectionStrings["fish_openjudge_rankinall"].ConnectionString;

            //String mysqlStr = GetString();
            Console.WriteLine(mysqlStr);
            // String mySqlCon = ConfigurationManager.ConnectionStrings["MySqlCon"].ConnectionString;

            MySqlConnection mysql = new MySqlConnection(mysqlStr);
            return mysql;
        }

        /// <summary>
        /// 建立执行命令语句对象
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="mysql"></param>
        /// <returns></returns>
        public static MySqlCommand getSqlCommand(String sql, MySqlConnection mysql)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(sql, mysql);
            //  MySqlCommand mySqlCommand = new MySqlCommand(sql);
            // mySqlCommand.Connection = mysql;
            return mySqlCommand;
        }

        /// <summary>
        /// 查询并获得结果集并遍历
        /// </summary>
        /// <param name="mySqlCommand"></param>
        public static void getResultset(MySqlCommand mySqlCommand)
        {
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine("编号:" + reader.GetInt32(0) + "|姓名:" + reader.GetString(1) + "|AC:" + reader.GetInt32(2) + "|SUBMIT:" + reader.GetString(3));
                    }
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
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="mySqlCommand"></param>
        public static void getInsert(MySqlCommand mySqlCommand)
        {
            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                Console.WriteLine("插入数据失败了！" + message);
            }

        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="mySqlCommand"></param>
        public static void getUpdate(MySqlCommand mySqlCommand)
        {
            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                Console.WriteLine("修改数据失败了！" + message);
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="mySqlCommand"></param>
        public static void getDel(MySqlCommand mySqlCommand)
        {
            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                Console.WriteLine("删除数据失败了！" + message);
            }
        }
    }
}
