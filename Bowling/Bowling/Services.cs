using BowlingScorer;

namespace Bowling
{
    public static class Services
    {
        private static BowlingScoreKeeper? _keeper;

        private static object cacheLock = new object();
        public static BowlingScoreKeeper Keeper
        {
            get
            {
                lock (cacheLock)
                {
                    if (_keeper == null)
                    {
                        _keeper = new BowlingScoreKeeper();
                    }
                    return _keeper;
                }
            }
        }
    }
}
