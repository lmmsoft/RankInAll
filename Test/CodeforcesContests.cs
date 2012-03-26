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
    public class CodeforcesContests
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
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest128()
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
                Rank = 2,
                ProblemNum = 5
            };

            compareCfContestDetail(gassa, actual[1]);
        }



        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest127()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 127;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "Nodar",
                Point = 3604,
                ChallengeFailed = 0,
                ChallengeSucceed = 1,
                PointTime = list,
                Rank = 17
            };

            compareCfContestDetail(gassa, actual[16]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest131()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 131;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "liuq901",
                Point = 9068,
                ChallengeFailed = 2,
                ChallengeSucceed = 5,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
      
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest26()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 26;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "dzhulgakov",
                Point = 5440,
                ChallengeFailed = 0,
                ChallengeSucceed = 1,
                PointTime = list,
                Rank = 4
            };

            compareCfContestDetail(gassa, actual[3]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest27()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 27;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "AnshAryan",
                Point = 6510,
                ChallengeFailed = 1,
                ChallengeSucceed = 4,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest28()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 28;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "dzhulgakov",
                Point = 4238,
                ChallengeFailed = 0,
                ChallengeSucceed = 0,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest29()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 29;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "a4461494",
                Point = 4932,
                ChallengeFailed = 0,
                ChallengeSucceed = 6,
                PointTime = list,
                Rank = 2
            };

            compareCfContestDetail(gassa, actual[1]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest30()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 30;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "rng_58",
                Point = 4676,
                ChallengeFailed = 1,
                ChallengeSucceed = 4,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest31()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 31;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "moondy",
                Point = 6424,
                ChallengeFailed = 0,
                ChallengeSucceed = 10,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest32()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 32;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "Rei",
                Point = 4928,
                ChallengeFailed = 1,
                ChallengeSucceed = 7,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest33()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 33;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "tourist",
                Point = 7342,
                ChallengeFailed = 0,
                ChallengeSucceed = 7,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest34()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 34;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "a4461497",
                Point = 6908,
                ChallengeFailed = 2,
                ChallengeSucceed = 4,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest35()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 35;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "Naginchik",
                Point = 6018,
                ChallengeFailed = 0,
                ChallengeSucceed = 1,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest36()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 36;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "Coder",
                Point = 4708,
                ChallengeFailed = 2,
                ChallengeSucceed = 2,
                PointTime = list,
                Rank = 3
            };

            compareCfContestDetail(gassa, actual[2]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest37()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 37;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "tourist",
                Point = 4664,
                ChallengeFailed = 3,
                ChallengeSucceed = 7,
                PointTime = list,
                Rank = 3
            };

            compareCfContestDetail(gassa, actual[2]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest40()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 40;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "tourist",
                Point = 6496,
                ChallengeFailed = 1,
                ChallengeSucceed = 6,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
      
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest41()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 41;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "sygi",
                Point = 6442,
                ChallengeFailed = 2,
                ChallengeSucceed = 6,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
       
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest42()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 42;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "tourist",
                Point = 5814,
                ChallengeFailed = 0,
                ChallengeSucceed = 3,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest43()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 43;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "Mimino",
                Point = 6804,
                ChallengeFailed = 2,
                ChallengeSucceed = 9,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest47()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 47;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "Ress",
                Point = 2720,
                ChallengeFailed = 1,
                ChallengeSucceed = 0,
                PointTime = list,
                Rank = 9
            };

            compareCfContestDetail(gassa, actual[8]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest49()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 49;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "Angel",
                Point = 4020,
                ChallengeFailed = 1,
                ChallengeSucceed = 0,
                PointTime = list,
                Rank = 5
            };

            compareCfContestDetail(gassa, actual[4]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest50()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 50;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "vepifanov",
                Point = 7812,
                ChallengeFailed = 0,
                ChallengeSucceed = 12,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest51()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 51;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "tourist",
                Point = 7010,
                ChallengeFailed = 1,
                ChallengeSucceed = 5,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest52()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 52;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "ilyakor",
                Point = 3354,
                ChallengeFailed = 0,
                ChallengeSucceed = 5,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest53()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 53;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "PAG",
                Point = 3970,
                ChallengeFailed = 1,
                ChallengeSucceed = 0,
                PointTime = list,
                Rank = 5
            };

            compareCfContestDetail(gassa, actual[4]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest54()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 54;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "winger",
                Point = 4540,
                ChallengeFailed = 0,
                ChallengeSucceed = 1,
                PointTime = list,
                Rank = 2
            };

            compareCfContestDetail(gassa, actual[1]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest55()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 55;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "Petr",
                Point = 5156,
                ChallengeFailed = 0,
                ChallengeSucceed = 6,
                PointTime = list,
                Rank = 5
            };

            compareCfContestDetail(gassa, actual[4]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest56()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 56;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "Isun",
                Point = 3744,
                ChallengeFailed = 0,
                ChallengeSucceed = 0,
                PointTime = list,
                Rank = 4
            };

            compareCfContestDetail(gassa, actual[3]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest57()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 57;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "tourist",
                Point = 5762,
                ChallengeFailed = 0,
                ChallengeSucceed = 12,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest58()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 58;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "winmad",
                Point = 4598,
                ChallengeFailed = 0,
                ChallengeSucceed = 3,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest59()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 59;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "Sisu",
                Point = 6414,
                ChallengeFailed = 1,
                ChallengeSucceed = 5,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest60()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 60;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "tourist",
                Point = 5736,
                ChallengeFailed = 0,
                ChallengeSucceed = 7,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest61()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 61;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "hell.dot",
                Point = 6260,
                ChallengeFailed = 1,
                ChallengeSucceed = 11,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest62()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 62;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "tourist",
                Point = 4096,
                ChallengeFailed = 0,
                ChallengeSucceed = 1,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest63()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 63;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "levlam",
                Point = 6436,
                ChallengeFailed = 0,
                ChallengeSucceed = 1,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest65()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 65;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "Gassa",
                Point = 5844,
                ChallengeFailed = 0,
                ChallengeSucceed = 27,
                PointTime = list,
                Rank = 2
            };

            compareCfContestDetail(gassa, actual[1]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest66()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 66;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "Kepnu4",
                Point = 7098,
                ChallengeFailed = 1,
                ChallengeSucceed = 7,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest67()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 67;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "tourist",
                Point = 6944,
                ChallengeFailed = 1,
                ChallengeSucceed = 10,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest68()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 68;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "rng_58",
                Point = 4112,
                ChallengeFailed = 0,
                ChallengeSucceed = 0,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest69()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 69;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "Solo",
                Point = 7066,
                ChallengeFailed = 3,
                ChallengeSucceed = 5,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }
        /// <summary>
        ///GetContestDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetContestDetailsTest70()
        {
            CodeforcesProvider target = new CodeforcesProvider();
            int contestId = 70;

            List<CfContestDetail> actual;
            actual = target.GetContestDetails(contestId);
            List<Tuple<int, string>> list = new List<Tuple<int, string>>();
            list.Add(Tuple.Create<int, string>(488, "00:06"));
            list.Add(Tuple.Create<int, string>(908, "00:23"));
            list.Add(Tuple.Create<int, string>(1104, "01:06"));
            list.Add(Tuple.Create<int, string>(0, ""));
            list.Add(Tuple.Create<int, string>(0, ""));
            CfContestDetail gassa = new CfContestDetail()
            {
                UserName = "Petr",
                Point = 6466,
                ChallengeFailed = 1,
                ChallengeSucceed = 8,
                PointTime = list,
                Rank = 1
            };

            compareCfContestDetail(gassa, actual[0]);
        }


        private static void compareCfContestDetail(CfContestDetail a, CfContestDetail b)
        {
            Assert.AreEqual(a.Rank, b.Rank);
            Assert.AreEqual(a.UserName, b.UserName);
            Assert.AreEqual(a.Point, b.Point);
            Assert.AreEqual(a.ChallengeSucceed, b.ChallengeSucceed);
            Assert.AreEqual(a.ChallengeFailed, b.ChallengeFailed);
            //Assert.AreEqual(a.PointTime, b.PointTime);

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
    }

    

}
/**
通过:26-37,40,41,42,43,47,49-63,65,66,67,68,69,70
 * 
 * 失败：1-25,38,39,44,45,46,48,64
*/