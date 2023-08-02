using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScorer
{
    public class BowlingInfo
    {
        public bool BowlWasValid { get; set; }

        public List<string> Errors { get; set; } = new List<string>();
        
        public int Score { get; set; }
        public Boolean GameCompleted { get; set; }
        public int CurrentFrameNumber { get; set; }
        public Frame? CurrentFrame { get; set; }

        public Frame[] Frames { get; set; } = new Frame[10];

        public BowlingInfo()
        {


            for (int i = 0; i < Frames.Length; i++)
            {
                Frames[i] = new Frame();
                Frames[i].FrameNumber = i + 1;
                if (i > 0)
                {
                    Frames[i].PreviousFrame = Frames[i - 1];
                }
            }
            for (int i = 0; i < Frames.Length; i++)
            {
                if (i < Frames.Length - 1)
                {
                    Frames[i].NextFrame = Frames[i + 1];
                }
            }
            CurrentFrame = Frames[0];
        }
    }
}
