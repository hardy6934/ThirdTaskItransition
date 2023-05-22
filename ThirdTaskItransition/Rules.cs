using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdTaskItransition
{
    internal class Rules
    {
        private int count;
        public Rules(int count) { 
            this.count = count;
        }

        
        public string whoWon(int compChoise, int personChoise)
        {
            if (compChoise == personChoise)
                return "Draw";
 
            else if ((personChoise > compChoise && personChoise - compChoise <= count / 2) || (personChoise < compChoise && compChoise - personChoise > count / 2))
            {
                return "Lose";
            }
            else return "Win";
        }
    }
}
