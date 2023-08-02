using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScorer
{
    public class ScoreCardFrame
    {
        public int Score { get; set; }
        public int FrameNumber { get; set; }

        public int[] FrameScores { get; set; } = new int[3];
    }
}
