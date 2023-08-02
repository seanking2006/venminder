using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScorer
{
    public class Frame 
    {
        public Frame? NextFrame { get; set; } = null;
        public Frame? PreviousFrame { get; set; } = null;
        public int FrameNumber { get; set; } = 1;
        public int Score { get; set; }
        public int[] FrameScores { get; set; } = new int[3];

        public bool CalculatingPendingScore { get; set; }

        public void SetScore(int score)
        {
            if (ScoreIndex < FrameScores.Length)
            {
                FrameScores[ScoreIndex] = score;
                ScoreIndex++;
                if (FrameNumber < 10 && ScoreIndex == 0 && score == 10)
                {
                    ScoreIndex++;
                }
            }
        }

        public bool IsStrikeInFirstFrame()
        {
            return ScoreIndex == 1 && FrameScores[0] == 10;
        }

        public bool IsSpare()
        {
            return FrameNumber < 10 && ScoreIndex == 2 && GetFrameScoreSum() == 10;
        }
        public bool IsFrameFull()
        {
            if (FrameNumber < 10)
            {
                if (ScoreIndex == 1)
                {
                    return FrameScores[0] == 10;
                }
               
                return ScoreIndex > 1;
            }
            else
            {
                if (ScoreIndex > 1)
                {

                    if (FrameScores[0] == 10)
                    {
                        return ScoreIndex > 2;
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public bool IsLastFrame()
        {
            return FrameNumber == 10;
        }
        public Boolean IsLastScore()
        {
            if (FrameNumber < 10)
            {
                return ScoreIndex == 1;
            }
            else
            {
                if (ScoreIndex > 0 && FrameScores[0] == 10)
                {
                    return ScoreIndex == 2;
                }
                else
                {
                    return ScoreIndex == 1;
                }
            }
        }
        public int ScoreIndex { get; set; }
        public int GetFrameScoreSum()
        {
            int sum = 0;
            foreach (int score in FrameScores)
            {
                sum = sum += score;
            }

            return sum;
        }

        public bool IsComplete()
        {
            if (FrameNumber < 10)
            {
                return ScoreIndex > 1;
            }
            else
            {
                if (ScoreIndex > 0 && FrameScores[0] == 10)
                {
                    return ScoreIndex > 2;
                }
                else
                {
                    return ScoreIndex > 1;
                }
            }
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public Frame()
        {
            for (int i = 0; i < FrameScores.Length; i++)
            {
                FrameScores[i] = 0;
            }
        }

    }
}
