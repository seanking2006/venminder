using BowlingScorer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bowling.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BowlingScoreController : ControllerBase
    {
        [HttpPost("bowl")]
        public ScoreCard Bowl(int score)
        {
            var gameInfo = Services.Keeper.Bowl(score);
            return GetScoreCard(gameInfo);
        }

        [HttpDelete("reset")] 
        public void Reset() 
        {
            Services.Keeper.Reset();
        }
        private ScoreCard GetScoreCard(BowlingInfo info)
        {
            var card = new ScoreCard();
            card.Score = info.Score;
            card.BowlWasValid = info.BowlWasValid;
            card.Errors = info.Errors;
            card.GameCompleted = info.GameCompleted;

            for (int i = 0; i < info.Frames.Length; i++)
            {
                var gameStateFrame = info.Frames[i];
                card.Frames[i] = new ScoreCardFrame();
                card.Frames[i].FrameNumber = gameStateFrame.FrameNumber;
                if (i < gameStateFrame.FrameNumber)
                {
                    card.Frames[i].Score = gameStateFrame.Score.ToString();
                }
                else
                {
                    card.Frames[i].Score = "-";
                }
                for (int j = 0; j < gameStateFrame.FrameScores.Length; j++)
                {
                    if (j < gameStateFrame.ScoreIndex)
                    {
                        card.Frames[i].FrameScores[j] = gameStateFrame.FrameScores[j].ToString();
                    }
                    else
                    {
                        card.Frames[i].FrameScores[j] = "-";
                    }
                }
            }
            return card;
        }
    }
}
