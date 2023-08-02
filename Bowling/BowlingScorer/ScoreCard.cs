using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScorer
{
    public class ScoreCard
    {
        public int Score { get; set; }

        public bool GameCompleted { get; set; }

        public bool BowlWasValid { get; set; }

        public List<string> Errors { get; set; } = new List<string>();
        public ScoreCardFrame[] Frames { get; set; } = new ScoreCardFrame[10];
    }
}
