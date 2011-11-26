using RankInAll.Core.Hdoj;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RankInAll.Core;
using System.Collections.Generic;

namespace TestRank
{
    
    
    /// <summary>
    ///这是 HdojRankTest 的测试类，旨在
    ///包含所有 HdojRankTest 单元测试
    ///</summary>
    [TestClass()]
    public class HdojRankTest
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
        ///CreateOjRank 的测试
        ///</summary>
        [TestMethod()]
        public void CreateOjRankTest()
        {
            HdojRank target = new HdojRank(); // TODO: 初始化为适当的值
            string web = @"<tr><td>2</td><td><img width='42px' height='27px' src='/images/country/1.gif'/></td><td><a href='userstatus.php?user=lmm333'>c-lou</a></td><td><a href='mailto:lmm333@126.com'>lmm333@126.com</a></td><td>njust</td><td>71</td><td>5128</td></tr>"; // TODO: 初始化为适当的值
            OjRankEntity expected = new OjRankEntity()
            {
                Ac = 71,
                //Submit = 711,
                UserName = "lmm333",
                NickName = "c-lou",
                School = "njust",
                Email = "lmm333@126.com",
                No = 2
            }; // TODO: 初始化为适当的值
            OjRankEntity actual;
            actual = target.CreateOjRank(web);

            Assert.AreEqual(expected.Ac, actual.Ac);
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.NickName, actual.NickName);
            Assert.AreEqual(expected.No, actual.No);
            Assert.AreEqual(expected.School, actual.School);
            Assert.AreEqual(expected.Submit, actual.Submit);
            Assert.AreEqual(expected.UserName, actual.UserName);
            //Assert.AreEqual(loumingming, actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetRankList 的测试 无school
        ///</summary>
        [TestMethod()]
        public void GetRankListTest1()
        {
            HdojRank target = new HdojRank(); // TODO: 初始化为适当的值
            string web = target.GetSearchResult("lmm333"); // TODO: 初始化为适当的值
            Assert.IsNotNull(web);

            OjRankEntity lmm333 = new OjRankEntity()
            {
                Ac = 71,
                Submit = 0,
                UserName = "lmm333",
                NickName = "c-lou",
                School = "njust",
                Email = "lmm333@126.com",
                No = 5132
            }; // TODO: 初始化为适当的值

            List<OjRankEntity> actual;
            actual = target.GetRankList(web);

            Assert.IsTrue(actual.Count == 1);
            AssertOjRankEntity(actual[0], lmm333);
        }

        /// <summary>
        ///GetRankList 的测试
        ///</summary>
        [TestMethod()]
        public void GetRankListTest2()
        {
            HdojRank target = new HdojRank(); // TODO: 初始化为适当的值
            string web = target.GetSearchResult("njust"); // TODO: 初始化为适当的值
            Assert.IsNotNull(web);

            OjRankEntity lmm333 = new OjRankEntity()
            {
                Ac = 71,
                Submit = 0,
                UserName = "lmm333",
                NickName = "c-lou",
                School = "njust",
                Email = "lmm333@126.com",
                No = 5132
            }; // TODO: 初始化为适当的值

            OjRankEntity stsky = new OjRankEntity()
            {
                Ac = 47,
                Submit = 0,
                UserName = "stsky",
                NickName = "*[njust]STsky",
                School = "",
                Email = "454638096@qq.com",
                No = 7879
            };


            List<OjRankEntity> actual;
            actual = target.GetRankList(web);

            Assert.IsTrue(actual.Count == 62);
            AssertOjRankEntity(actual[1], lmm333);
            AssertOjRankEntity(actual[3], stsky);

            //Assert.AreEqual(loumingming, actual);
        }

        /// <summary>
        ///GetUserStatus 的测试
        ///</summary>
        [TestMethod()]
        public void GetUserStatusTest()
        {
            HdojRank target = new HdojRank(); // TODO: 初始化为适当的值
            string user_id = "lmm333"; // TODO: 初始化为适当的值

            OjRankEntity actual;
            actual = target.GetUserStatus(user_id);

            OjRankEntity lmm333 = new OjRankEntity()
            {
                Ac = 71,
                Submit = 178,
                UserName = "lmm333",
                NickName = "c-lou",
                School = "njust",
                Email = "lmm333@126.com",
                No = 5132
            }; // TODO: 初始化为适当的值

            AssertOjRankEntity(actual, lmm333);
        }

        private static void AssertOjRankEntity(OjRankEntity actual, OjRankEntity expected)
        {
            Assert.AreEqual(expected.Ac, actual.Ac);
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.NickName, actual.NickName);
            Assert.AreEqual(expected.No, actual.No);
            Assert.AreEqual(expected.School, actual.School);
            Assert.AreEqual(expected.Submit, actual.Submit);
            Assert.AreEqual(expected.UserName, actual.UserName);
        }
    }
}
