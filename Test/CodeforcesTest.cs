using RankInAll.Core.OnlineContest.Codeforces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestRank
{


    /// <summary>
    ///这是 CodeforcesTest 的测试类，旨在
    ///包含所有 CodeforcesTest 单元测试
    ///</summary>
    [TestClass()]
    public class CodeforcesTest
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
        ///GetAllContestResults 的测试
        ///</summary>
        [TestMethod()]
        public void GetprofileTest()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            string user_id = "lmm333";

            CfContestResult expected1 = new CfContestResult()
            {
                UserName = "lmm333",
                Rating = 1379,
                ContestId = 26,
                ContestName = "Codeforces Beta Round #26 (Codeforces format)",
                Change = -121,
                Rank = 481,
                ContestUrl = "/contest/26/standings",
                Timesplayed = 1
            };
            CfContestResult expected2 = new CfContestResult()
            {
                UserName = "lmm333",
                Rating = 1481,
                ContestId = 117,
                ContestName = "Codeforces Beta Round #88",
                Change = 1,
                Rank = 686,
                ContestUrl = "/contest/117/standings",
                Timesplayed = 12
            };

            List<CfContestResult> actual;
            actual = target.GetAllContestResults(user_id);

            Assert.IsNotNull(actual);

            AssertCfContestResult(expected1, actual[0]);
            AssertCfContestResult(expected2, actual[11]);

        }
        private void AssertCfContestResult(CfContestResult a, CfContestResult b)
        {
            Assert.IsTrue(a.Change == b.Change);
            Assert.IsTrue(a.ContestId == b.ContestId);
            Assert.IsTrue(a.ContestName == b.ContestName);
            Assert.IsTrue(a.ContestUrl == b.ContestUrl);
            Assert.IsTrue(a.Rank == b.Rank);
            Assert.IsTrue(a.Rating == b.Rating);
            Assert.IsTrue(a.Timesplayed == b.Timesplayed);
            Assert.IsTrue(a.UserName == b.UserName);
        }

        /// <summary>
        ///Getprofile 的测试
        ///</summary>
        [TestMethod()]
        public void GetprofileTest1()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            string user_id = "acrush";

            User actual;
            actual = target.GetProfile(user_id);
            Assert.AreEqual(actual.Rating, 2521);
            Assert.AreEqual(actual.Timesplayed, 13);
        }

        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest1()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 128;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);

            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "Gassa",
                Point = 5338,
                ChallengeFailed = 1,
                ChallengeSucceed = 4,
                Rank = 2
            };

            compareCfContestDetail(gassa, actual[1]);
        }

        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest2()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 99;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);

            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));

            CfContestDetail sazzad = new CfContestDetail()
            {
                UserName = "sazzad",
                Point = 2750,
                ChallengeFailed = 1,
                ChallengeSucceed = 3,
                Rank = 4,
                PointTime = list,
                ProblemNum = 5
            };

            compareCfContestDetail(sazzad, actual[3]);
        }

        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest3()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 131;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);

            CfContestDetail user = new CfContestDetail()
            {
                UserName = "lmm333",
                Point = 1096,
                ChallengeFailed = 1,
                ChallengeSucceed = 0,
                Rank = 850
            };

            compareCfContestDetail(user, actual[849]);
        }

        private static void compareCfContestDetail(CfContestDetail a, CfContestDetail b)
        {
            Assert.AreEqual(a.Rank, b.Rank);
            Assert.AreEqual(a.UserName, b.UserName);
            Assert.AreEqual(a.Point, b.Point);
            Assert.AreEqual(a.ChallengeSucceed, b.ChallengeSucceed);
            Assert.AreEqual(a.ChallengeFailed, b.ChallengeFailed);
        }

        private static void compareCfResult(CfContestResult a, CfContestResult b)
        {
            Assert.AreEqual(a.Rank, b.Rank);
            Assert.AreEqual(a.UserName, b.UserName);
            Assert.AreEqual(a.Change, b.Change);
            Assert.AreEqual(a.ContestId, b.ContestId);
            Assert.AreEqual(a.ContestUrl, b.ContestUrl);
            Assert.AreEqual(a.ContestName, b.ContestName);
            Assert.AreEqual(a.Rating, b.Rating);
            Assert.AreEqual(a.Timesplayed, b.Timesplayed);
        }

        /// <summary>
        ///GetAllContestResults 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllContestResultsTest()
        {
            CodeforcesProvider target = new CodeforcesProvider(); // TODO: 初始化为适当的值
            string user_id = "lmm333"; // TODO: 初始化为适当的值

            CfContestResult expected_1 = new CfContestResult
            {
                UserName = "lmm333",
                ContestName = "Codeforces Beta Round #26 (Codeforces format)",
                ContestUrl = "/contest/26/standings",
                ContestId = 26,
                Rating = 1379,
                Change = -121,
                Rank = 481,
                Timesplayed = 1
            };
            CfContestResult expected_14 = new CfContestResult
            {
                UserName = "lmm333",
                ContestName = "Codeforces Beta Round #96 (Div. 2)",
                ContestUrl = "/contest/133/standings",
                ContestId = 133,
                Rating = 1401,
                Change = -29,
                Rank = 697,
                Timesplayed = 14
            };

            List<CfContestResult> actual;
            actual = target.GetAllContestResults(user_id);

            compareCfResult(expected_1, actual[0]);
            compareCfResult(expected_14, actual[13]);
        }

        /// <summary>
        ///GetContestStandingPages 的测试  比赛结果分页表
        ///</summary>
        [TestMethod()]
        [DeploymentItem("RankInAlll.Core.dll")]
        public void GetContestStandingPagesTest()
        {
            CodeforcesProvider_Accessor target = new CodeforcesProvider_Accessor(); // TODO: 初始化为适当的值
            int contestId = 139; // TODO: 初始化为适当的值

            int expected = 18; // TODO: 初始化为适当的值
            int actual;
            actual = target.GetContestStandingPages(contestId);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///GetContestInfo 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestInfoTest()
        {
            CodeforcesProvider target = new CodeforcesProvider(); // TODO: 初始化为适当的值
            int contestId = 139; // TODO: 初始化为适当的值
            CfContestInfo expected = new CfContestInfo()
            {
                ContestUrl = "http://codeforces.com/contest/139/standings/page/1",
                ContestName = "Codeforces Beta Round #99 (Div. 2)",
                ContestId = 139,
                type = "cf",
                div=2
            };
                
            CfContestInfo actual;
            actual = target.GetContestInfo(contestId);
            Assert.AreEqual(expected.ContestId, actual.ContestId);
            Assert.AreEqual(expected.ContestName, actual.ContestName);
            Assert.AreEqual(expected.div, actual.div);
            Assert.AreEqual(expected.ContestUrl, actual.ContestUrl);
            Assert.AreEqual(expected.type, actual.type);
        }
    }
}
