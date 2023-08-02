using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScorer
{
    internal class SparePendingScore : PendingScore
    {
        public SparePendingScore() { }

        public override bool UseFrameScore()
        {
            return true;
        }
        override public bool ScoreIsComplete()
        {
            return _scores.Count >= 1;
        }

        public override bool SkipFirstVisit()
        {
            return true;
        }
    }
}
