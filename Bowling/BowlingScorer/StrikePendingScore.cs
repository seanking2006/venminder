using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScorer
{
    internal class StrikePendingScore : PendingScore
    {
        public StrikePendingScore() { }

        public override bool UseFrameScore()
        {
            return true;
        }
        override public bool ScoreIsComplete() 
        {
            return _scores.Count >= 2;
        }
        public override bool SkipFirstVisit()
        {
            return true;
        }
    }
}
