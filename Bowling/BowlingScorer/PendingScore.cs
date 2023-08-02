using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScorer
{
    public abstract class PendingScore
    {
        protected int _visitCount = 0;
        protected List<int> _scores = new List<int>();

        public void Visit()
        {
            _visitCount++;
        }

        public int VisitCount {  get { return _visitCount; } }
        public Frame FrameToScore { get; set; } = new Frame();
        public virtual bool ScoreIsComplete()
        {
            return false;
        }

        public virtual bool UseFrameScore()
        {
            return false;
        }
        public virtual int GetScore()
        {
            int scoreSum = 0;
            foreach (int score in _scores)
            {
                scoreSum += score;
            }
            return scoreSum;
        }

        public virtual void AddScore(int score)
        {
            _scores.Add(score);
        }

        public virtual bool SkipFirstVisit()
        {
            return false;
        }
    }
}
