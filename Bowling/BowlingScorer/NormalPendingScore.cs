using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScorer
{
    internal class NormalPendingScore : PendingScore
    {
        public NormalPendingScore() { }

        public override bool UseFrameScore()
        {
            return false;
        }
        override public bool ScoreIsComplete()
        {
            return (_scores.Count() > 0 && _scores[0] == 10) || _scores.Count >= 2;
        }

        public override bool SkipFirstVisit()
        {
            return false;
        }
    }
}
