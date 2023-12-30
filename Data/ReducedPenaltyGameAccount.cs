using System;
using System.Collections.Generic;

namespace lab3
{
    class ReducedPenaltyGameAccount : GameAccount
    {
        public ReducedPenaltyGameAccount(string userName) : base(userName) { }

        public override int CalculatePoints(int rating, bool isWin)
        {
            if (isWin)
            {
                return rating;
            }
            else
            {
                return rating / 2;
            }
        }
    }
}
