﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScorer
{
    public class ScoreCardFrame
    {
        public string Score { get; set; }
        public int FrameNumber { get; set; }

        public string[] FrameScores { get; set; } = new string[3];
    }
}
