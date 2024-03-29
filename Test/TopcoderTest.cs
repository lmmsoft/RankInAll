﻿using RankInAll.Core.OnlineContest.Topcoder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestRank
{
    
    
    /// <summary>
    ///这是 TopcoderTest 的测试类，旨在
    ///包含所有 TopcoderTest 单元测试
    ///</summary>
    [TestClass()]
    public class TopcoderTest
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
        ///GetProfile 的测试
        ///</summary>
        [TestMethod()]
        public void GetProfileTest()
        {
            TopcoderProvider target = new TopcoderProvider(); // TODO: 初始化为适当的值
            string user_id = "lmm333"; // TODO: 初始化为适当的值
            User expected = new User()
            {
                Color = "coderTextGray",
                MostRecentEvent = "SRM 532-02.09.12",
                Rating = 864,
                Timesplayed = 14,
                UserName = "lmm333",
                Volatility = 180
            };
            User actual;
            actual = target.GetProfile(user_id);
            //Assert.AreEqual(expected, actual);
            AssertUser(expected, actual);
        }

        private void AssertUser(User a, User b)
        {
            Assert.IsTrue(a.Volatility==b.Volatility);
            Assert.IsTrue(a.MostRecentEvent==b.MostRecentEvent); 
            Assert.IsTrue(a.Color==b.Color);
            Assert.IsTrue(a.Rating == b.Rating);
            Assert.IsTrue(a.Timesplayed == b.Timesplayed);
            Assert.IsTrue(a.UserName == b.UserName);
        }
    }
}
