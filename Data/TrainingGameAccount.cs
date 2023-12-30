using System;
using System.Collections.Generic;

namespace lab3
{
    class TrainingGameAccount : GameAccount
    {
        public TrainingGameAccount(string userName) : base(userName) { }

        public override int CalculatePoints(int rating, bool isWin)
        {
            if (isWin)
            {
                return rating + 10;
            }
            else
            {
                return rating = 0;
            }
        }
    }
}
