using System.ComponentModel;
using System.Net.NetworkInformation;
using static System.Formats.Asn1.AsnWriter;

namespace BowlingScorer
{
    public class BowlingScoreKeeper
    {
        public BowlingInfo GameState { get; set; } = new BowlingInfo();
        private Queue<PendingScore> _pendingScores = new Queue<PendingScore>();

        public BowlingScoreKeeper()
        {
           
        }

        public BowlingInfo GetCurrentState()
        {
            return GameState;
        }

        public void Reset()
        {
            GameState = new BowlingInfo();
            _pendingScores.Clear();
        }

        private void SaveScore(int score)
        {
            if (!GameState.GameCompleted)
            {
                var frame = GameState.CurrentFrame ?? GameState.Frames[0];

                frame.SetScore(score);

                SetPendingScores(frame);

                if (frame.IsFrameFull())
                {
                    if (frame.NextFrame != null)
                    {
                        GameState.CurrentFrame = frame.NextFrame;
                    }
                    else
                    {
                        GameState.GameCompleted = true;
                    }
                }
            }
        }

        public void SetPendingScores(Frame frame)
        {
            if(frame.IsStrikeInFirstFrame()) 
            {
                var pendingScore = new StrikePendingScore();
                pendingScore.FrameToScore = frame;
                _pendingScores.Enqueue(pendingScore);
            }
            else if (frame.IsSpare())
            {
                var pendingScore = new SparePendingScore();
                pendingScore.FrameToScore = frame;
                _pendingScores.Enqueue(pendingScore);
            }
            else if (frame.IsComplete()) 
            {
                var pendingScore = new NormalPendingScore();
                pendingScore.FrameToScore = frame;
                pendingScore.AddScore(frame.FrameScores[0]);
                pendingScore.AddScore(frame.FrameScores[1]);
                if (frame.FrameNumber == 10)
                {
                    pendingScore.AddScore(frame.FrameScores[2]);
                }
                _pendingScores.Enqueue(pendingScore);
            }
        }
            

            //if (_pendingScores.Count > 0)
            //{
            //    CalculatePendingScores(score, frame);
            //}
            //else
            //{
            //    if (GameState.CurrentFrameNumber < 10 && frame.ScoreIndex >= 1)
            //    {
            //        if (frame.FrameScores[0] == 10)
            //        {
            //            var strike = new StrikePendingScore();
            //            strike.FrameToScore = GameState.CurrentFrame ?? new Frame();
            //            _pendingScores.Enqueue(strike);
            //        }
            //        frame.Score = frame.GetFrameScoreSum();
            //        GameState.Score = frame.Score;
            //    }

            //}
            //for(int i = 0; i < GameState.Frames.Length; i++)
            //{
            //    var currentFrame = GameState.Frames[i];
            //    currentFrame.Score = currentFrame.GetFrameScoreSum();
            //}
        //}

        //private void CalculatePendingScores(int score, Frame frame)
        //{
        //    Queue<PendingScore> holdingQueue = new Queue<PendingScore>();
        //    while (_pendingScores.Count > 0)
        //    {
        //        var pendingScore = _pendingScores.Dequeue();
        //        pendingScore.AddScore(score);

        //        if (!pendingScore.ScoreIsComplete())
        //        {
        //            holdingQueue.Enqueue(pendingScore);
        //        }
        //        else
        //        {
        //            frame.Score = GameState.Score + pendingScore.GetScore();
        //            GameState.Score = frame.Score;
        //        }
        //    }
        //    _pendingScores = holdingQueue;
        //}

        public void CalculatePendingScores(int score)
        {
            Queue<PendingScore> holdingScores = new Queue<PendingScore>();
            while(_pendingScores.Count > 0)
            {
                var currentScore = _pendingScores.Dequeue();
                if (currentScore.ScoreIsComplete())
                {
                    CalculateScore(currentScore);
                }
                else
                {
                    if (currentScore.SkipFirstVisit() && currentScore.VisitCount == 0)
                    {

                    }
                    else
                    {
                        currentScore.AddScore(score);
                    }
                    if (currentScore.ScoreIsComplete())
                    {
                        CalculateScore(currentScore);
                    }
                    else
                    {
                        holdingScores.Enqueue(currentScore);
                    }
                }
                currentScore.Visit();
            }
            _pendingScores = new Queue<PendingScore>(holdingScores);
        }

        public void CalculateScore(PendingScore pending)
        {
            Frame scoringFrame = pending.FrameToScore;
            int previousFrameScore = 0;
            if (scoringFrame.PreviousFrame != null)
            {
                previousFrameScore = scoringFrame.PreviousFrame.Score;
            }

            int frameScore = 0;
            if (pending.UseFrameScore())
            {
                frameScore = scoringFrame.GetFrameScoreSum();
            }

            int finalScore = previousFrameScore + frameScore + pending.GetScore();
            pending.FrameToScore.Score = finalScore;
            GameState.Score = finalScore;
        }


        public BowlingInfo Bowl(int score)
        {
            GameState.BowlWasValid = ValidateScore(score);

            if (GameState.BowlWasValid && !GameState.GameCompleted)
            {
                SaveScore(score);
                CalculatePendingScores(score);
            }
            return GameState;
        }

        private bool ValidateScore(int score)
        {
            if (score < 0 || score > 10)
            {
                GameState.Errors.Add("Score must be between 0 and 10");
                return false;
            }
            if (GameState.CurrentFrame != null)
            {
                if (GameState.CurrentFrame.FrameNumber < 10 && 
                    GameState.CurrentFrame.ScoreIndex == 1)
                {
                    if (GameState.CurrentFrame.FrameScores[0] + score > 10)
                    {
                        GameState.Errors.Add("The sum of the scores must be less than or equal to 10");
                        return false;
                    }
                }
            }
            return true;
        }
    }
}