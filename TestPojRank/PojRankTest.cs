using RankInAll.Core.Poj;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RankInAll.Core;
using System.Collections.Generic;

namespace TestRank
{


    /// <summary>
    ///这是 PojRankTest 的测试类，旨在
    ///包含所有 PojRankTest 单元测试
    ///</summary>
    [TestClass()]
    public class PojRankTest
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
        [DeploymentItem("RankInAlll.Core.dll")]
        public void CreateOjRankTest()
        {
            PojRank_Accessor target = new PojRank_Accessor(); // TODO: 初始化为适当的值

            string web = @"<tr bgcolor=#C0C0C0><td width=10%>1</td><td><a href=userstatus?user_id=ghostplant>ghostplant</a></td><td>( ^_^ ) </td><td>njust </td><td>497251726@qq.com </td><td>706</td><td>1530</td></tr>"; // TODO: 初始化为适当的值

            OjRankEntity_Accessor expected = new OjRankEntity_Accessor()
            {
                Ac = 706,
                Submit = 1530,
                UserName = "ghostplant",
                NickName = "( ^_^ )",
                School = "njust",
                Email = "497251726@qq.com",
                No = 1
            }; // TODO: 初始化为适当的值

            OjRankEntity_Accessor actual;
            actual = target.CreateOjRank(web);

            AssertOjRankEntity_Accessor(expected, actual);

            //Assert.IsTrue(loumingming.Equals(actual));
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetRankList 的测试
        ///</summary>
        [TestMethod()]
        [DeploymentItem("RankInAlll.Core.dll")]
        public void GetRankListTest()
        {
            PojRank target = new PojRank(); // TODO: 初始化为适当的值
            string web = target.GetSearchResultByEmail("lmm"); // TODO: 初始化为适当的值
            Assert.IsNotNull(web);

            //IEnumerable<OjRankEntity_Accessor> loumingming = new List<OjRankEntity_Accessor>(); // TODO: 初始化为适当的值

            List<OjRankEntity> actual;
            actual = target.GetRankList(web);
            Assert.IsNotNull(actual);

            Assert.IsTrue(actual.Count == 65);

            //actual.GetEnumerator().MoveNext();

            IEnumerable<OjRankEntity> iterator = actual;
            OjRankEntity ojRankEntity1 = actual[0];

            Assert.IsTrue(ojRankEntity1.Ac == 2);
            Assert.AreEqual(ojRankEntity1.Submit, 5);
            Assert.AreEqual(ojRankEntity1.NickName, "crystal");
            Assert.IsTrue(actual[64].School == "北京大学");
        }

        /// <summary>
        ///GetUserStatus 的测试
        ///</summary>
        [TestMethod()]
        public void GetUserStatusTest()
        {
            PojRank target = new PojRank(); // TODO: 初始化为适当的值
            string user_id = "ltj_njust"; // TODO: 初始化为适当的值
            OjRankEntity actual;
            actual = target.GetUserStatus(user_id);

            OjRankEntity expected = new OjRankEntity()// TODO: 初始化为适当的值
            {
                Ac = 344,
                Submit = 711,
                UserName = "ltj_njust",
                NickName = "messiah",
                School = "njust",
                Email = "491507927@qq.com",
                No = 1199
            };

            AssertOjRankEntity(actual, expected);
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
        private static void AssertOjRankEntity_Accessor(OjRankEntity_Accessor expected, OjRankEntity_Accessor actual)
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
