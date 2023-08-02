using BowlingScorer;

namespace BowlingTest
{
    [TestClass]
    public class BowlingTest
    {
        [TestMethod]
        public void TestSimpleFrame()
        {
            var scorer = new BowlingScoreKeeper();
            var frameOneBowlOne = scorer.Bowl(1);
            var frameOneBowlTwo = scorer.Bowl(2);

            Assert.AreEqual(10, frameOneBowlTwo.Frames.Length);
            Assert.AreEqual(3, frameOneBowlTwo.Frames[0].FrameScores.Length);
            Assert.AreEqual(1, frameOneBowlTwo.Frames[0].FrameScores[0]);
            Assert.AreEqual(2, frameOneBowlTwo.Frames[0].FrameScores[1]);
            Assert.AreEqual(3, frameOneBowlTwo.Frames[0].Score);
        }

        [TestMethod]
        public void TestSpare()
        {
            var scorer = new BowlingScoreKeeper();
            var frameOneBowlOne = scorer.Bowl(9);
            var frameOneBowlTwo = scorer.Bowl(1);

            Assert.AreEqual(9, frameOneBowlTwo.Frames[0].FrameScores[0]);
            Assert.AreEqual(1, frameOneBowlTwo.Frames[0].FrameScores[1]);
            Assert.AreEqual(0, frameOneBowlTwo.Frames[0].Score);

            var frameTwoBowlOne = scorer.Bowl(3);
            Assert.AreEqual(13, frameTwoBowlOne.Score);
        }

        [TestMethod]
        public void TestStrike()
        {
            var scorer = new BowlingScoreKeeper();
            var frameOneBowlOne = scorer.Bowl(10);

            Assert.AreEqual(10, frameOneBowlOne.Frames[0].FrameScores[0]);
            Assert.AreEqual(0, frameOneBowlOne.Frames[0].Score);

            var frameTwoBowlOne = scorer.Bowl(1);
            Assert.AreEqual(1, frameTwoBowlOne.Frames[1].FrameScores[0]);
            var frameTwoBowlTwo = scorer.Bowl(4);
            Assert.AreEqual(4, frameTwoBowlTwo.Frames[1].FrameScores[1]);
                      
        }

        [TestMethod]
        public void TestThreeStrikes()
        {
            var scorer = new BowlingScoreKeeper();
            var frameOneBowlOne = scorer.Bowl(10);

            Assert.AreEqual(10, frameOneBowlOne.Frames[0].FrameScores[0]);
            Assert.AreEqual(0, frameOneBowlOne.Frames[0].Score);
            Assert.AreEqual(1, frameOneBowlOne.Frames[0].FrameNumber);

            var frameTwoBowlOne = scorer.Bowl(10);
            
            Assert.AreEqual(10, frameTwoBowlOne.Frames[1].FrameScores[0]);
            Assert.AreEqual(0, frameTwoBowlOne.Frames[1].Score);
            Assert.AreEqual(2, frameOneBowlOne.Frames[1].FrameNumber);

            var frameThreeBowlOne = scorer.Bowl(10);
            
            Assert.AreEqual(10, frameThreeBowlOne.Frames[2].FrameScores[0]);
            Assert.AreEqual(0, frameThreeBowlOne.Frames[2].Score);
            Assert.AreEqual(3, frameOneBowlOne.Frames[2].FrameNumber);

            Assert.AreEqual(30, frameOneBowlOne.Frames[0].Score);
            Assert.AreEqual(0, frameTwoBowlOne.Frames[1].Score);
            Assert.AreEqual(0, frameThreeBowlOne.Frames[2].Score);




        }
        [TestMethod]
        public void TestGameLength()
        {
            var gameKeeper = new BowlingScoreKeeper();
            gameKeeper.Bowl(0);
            gameKeeper.Bowl(0);

            gameKeeper.Bowl(0);
            gameKeeper.Bowl(0);

            gameKeeper.Bowl(0);
            gameKeeper.Bowl(0);

            gameKeeper.Bowl(0);
            gameKeeper.Bowl(0);

            gameKeeper.Bowl(0);
            gameKeeper.Bowl(0);

            gameKeeper.Bowl(0);
            gameKeeper.Bowl(0);

            gameKeeper.Bowl(0);
            gameKeeper.Bowl(0);

            gameKeeper.Bowl(0);
            gameKeeper.Bowl(0);

            gameKeeper.Bowl(0);
            gameKeeper.Bowl(0);

            gameKeeper.Bowl(0);
            gameKeeper.Bowl(0);

            Assert.IsTrue(gameKeeper.GameState.GameCompleted);
        }

        [TestMethod]
        public void TestGameLengthTenthFrameThirdBowl()
        {
            var gameKeeper = new BowlingScoreKeeper();
            gameKeeper.Bowl(0);
            gameKeeper.Bowl(0);

            gameKeeper.Bowl(0);
            gameKeeper.Bowl(0);

            gameKeeper.Bowl(0);
            gameKeeper.Bowl(0);

            gameKeeper.Bowl(0);
            gameKeeper.Bowl(0);

            gameKeeper.Bowl(0);
            gameKeeper.Bowl(0);

            gameKeeper.Bowl(0);
            gameKeeper.Bowl(0);

            gameKeeper.Bowl(0);
            gameKeeper.Bowl(0);

            gameKeeper.Bowl(0);
            gameKeeper.Bowl(0);

            gameKeeper.Bowl(0);
            gameKeeper.Bowl(0);

            gameKeeper.Bowl(10);
            gameKeeper.Bowl(0);
            Assert.IsFalse(gameKeeper.GameState.GameCompleted);

            gameKeeper.Bowl(0);

            Assert.IsTrue(gameKeeper.GameState.GameCompleted);
        }

        [TestMethod]
        public void Test110Score()
        {
            var gameKeeper = new BowlingScoreKeeper();

            //Frame 1
            gameKeeper.Bowl(4);
            var frameOneBowlTwo = gameKeeper.Bowl(3);
            Assert.AreEqual(7, frameOneBowlTwo.Frames[0].Score);

            //Frame 2
            gameKeeper.Bowl(7);
            var frameTwoBowlTwo = gameKeeper.Bowl(3);
            Assert.AreEqual(0, frameTwoBowlTwo.Frames[1].Score);

            //Frame 3
            gameKeeper.Bowl(5);
            Assert.AreEqual(22, frameTwoBowlTwo.Frames[1].Score);
            var frameThreeBowlTwo = gameKeeper.Bowl(2);
            Assert.AreEqual(29, frameThreeBowlTwo.Frames[2].Score);

            //Frame 4
            gameKeeper.Bowl(8);
            var frame5Bowl2 = gameKeeper.Bowl(1);

            Assert.AreEqual(38, frame5Bowl2.Frames[3].Score);

            //Frame 5
            gameKeeper.Bowl(4);
            gameKeeper.Bowl(6);

            //frame 6
            var frame6Bowl1 = gameKeeper.Bowl(2);
            Assert.AreEqual(50, frame6Bowl1.Frames[4].Score);
            var frame6Bowl2 = gameKeeper.Bowl(4);
            Assert.AreEqual(56, frame6Bowl2.Frames[5].Score);

            //frame 7
            gameKeeper.Bowl(8);
            var frame7Bowl2 = gameKeeper.Bowl(0);
            Assert.AreEqual(64, frame7Bowl2.Frames[6].Score);

            //frame 8
            gameKeeper.Bowl(8);
            var frame8Bowl2 = gameKeeper.Bowl(0);
            Assert.AreEqual(72, frame8Bowl2.Frames[7].Score);

            //frame 9
            gameKeeper.Bowl(8);
            gameKeeper.Bowl(2);

            //frame 10
            var frame10Bowl1 = gameKeeper.Bowl(10);
            Assert.AreEqual(92, frame10Bowl1.Frames[8].Score);
            gameKeeper.Bowl(1);
            Assert.IsFalse(gameKeeper.GameState.GameCompleted);

            var frame10Bowl2 = gameKeeper.Bowl(7);
            Assert.AreEqual(110, frame10Bowl2.Frames[9].Score);
            Assert.IsTrue(gameKeeper.GameState.GameCompleted);
        }

        [TestMethod]
        public void PerfectGame()
        {
            var gameKeeper = new BowlingScoreKeeper();

            gameKeeper.Bowl(10);
            gameKeeper.Bowl(10);
            gameKeeper.Bowl(10);
            gameKeeper.Bowl(10);
            gameKeeper.Bowl(10);
            gameKeeper.Bowl(10);
            gameKeeper.Bowl(10);
            gameKeeper.Bowl(10);
            gameKeeper.Bowl(10);
            gameKeeper.Bowl(10);
            gameKeeper.Bowl(10);
            var frame10Bowl3 = gameKeeper.Bowl(10);
            Assert.AreEqual(300, frame10Bowl3.Frames[9].Score);
        }

        [TestMethod]
        public void AllSpares()
        {
            var gameKeeper = new BowlingScoreKeeper();

            gameKeeper.Bowl(4);
            gameKeeper.Bowl(6);

            gameKeeper.Bowl(4);
            gameKeeper.Bowl(6);

            gameKeeper.Bowl(4);
            gameKeeper.Bowl(6);

            gameKeeper.Bowl(4);
            gameKeeper.Bowl(6);

            gameKeeper.Bowl(4);
            gameKeeper.Bowl(6);

            gameKeeper.Bowl(4);
            gameKeeper.Bowl(6);

            gameKeeper.Bowl(4);
            gameKeeper.Bowl(6);

            gameKeeper.Bowl(4);
            gameKeeper.Bowl(6);

            gameKeeper.Bowl(4);
            gameKeeper.Bowl(6);

            gameKeeper.Bowl(4);
            var frame10Bowl2 = gameKeeper.Bowl(6);
            Assert.AreEqual(136, frame10Bowl2.Frames[9].Score);
            Assert.IsTrue(frame10Bowl2.GameCompleted);
        }

        [TestMethod]
        public void TestInvalidInputNegativeNumber()
        {
            var gameKeeper = new BowlingScoreKeeper();

            var invalidInput = gameKeeper.Bowl(-1);
            Assert.IsFalse(invalidInput.BowlWasValid);
        }

        [TestMethod]
        public void TestInvalidInputHighNumber()
        {
            var gameKeeper = new BowlingScoreKeeper();

            var invalidInput = gameKeeper.Bowl(11);
            Assert.IsFalse(invalidInput.BowlWasValid);
        }

        [TestMethod]
        public void TestInvalidInputBadSecondScore()
        {
            var gameKeeper = new BowlingScoreKeeper();

            gameKeeper.Bowl(3);
            var invalidInput = gameKeeper.Bowl(8);
            Assert.IsFalse(invalidInput.BowlWasValid);
        }
    }
}