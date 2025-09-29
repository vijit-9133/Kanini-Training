using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    internal class Player
    {
        private List<int> oversBowledList;

        public Player()
        {
            oversBowledList = new List<int>();
        }

        public void AddOversDetails(int oversBowled)
        {
            oversBowledList.Add(oversBowled);
        }

        public int GetNoOfBallsBowled()
        {
            int totalBalls = 0;
            foreach (int overs in oversBowledList)
            {
                totalBalls += overs * 6;
            }
            return totalBalls;
        }
    }
}
