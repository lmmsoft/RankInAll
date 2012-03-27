using RankInAll.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using RankInAll.Core.OnlineJudge;

namespace TestRank
{
    /// <summary>
    ///这是 StorageTest 的测试类，旨在
    ///包含所有 StorageTest 单元测试
    ///</summary>
    [TestClass()]
    public class StorageTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///GetUserInfo 的测试
        ///</summary>
        [TestMethod()]
        public void GetUserInfoTest()
        {
            Storage target = new Storage(); // TODO: 初始化为适当的值
            string user_name = "lmm333"; // TODO: 初始化为适当的值
            UserInfo expected = null; // TODO: 初始化为适当的值
            UserInfo actual;
            actual = target.GetUserInfo(user_name);

            Assert.AreEqual(actual.PojName, "lmm333");
            Assert.AreEqual(actual.Type, 1);

            //测试空结果
            actual = target.GetUserInfo("xxx");
            Assert.IsNull(actual);


        }

        /// <summary>
        ///GetAllRank 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllRankTest()
        {
            Storage target = new Storage(); // TODO: 初始化为适当的值
            int type = 1; // TODO: 初始化为适当的值
            List<DBAllRank> expected = null; // TODO: 初始化为适当的值
            List<DBAllRank> actual;
            actual = target.GetAllRank(type);
            Assert.AreEqual(actual[0].PojAcceptCount, 254);
            Assert.AreEqual(actual[0].HduAcceptCount, 0);
            Assert.AreEqual(actual[0].TrueName, null);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateOJRank 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateOJRankTest()
        {
            Storage target = new Storage(); // TODO: 初始化为适当的值
            OjRankEntity entity = new OjRankEntity()
            {
                UserName="lmm333",
                Ac=123,
            }; // TODO: 初始化为适当的值
            string OJTableName = "hdoj"; // TODO: 初始化为适当的值
            target.UpdateOJRank(entity, OJTableName);
            Assert.Inconclusive("无法验证不返回值的方法。");
        }
    }
}
