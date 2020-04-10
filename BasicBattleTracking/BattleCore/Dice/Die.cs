using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCore.Dice
{
    public class Die
    {
        public struct RollResult
        {
            public int result;
            public List<int> rollValues;
            public int modifier;
        }

        private int dType;
        public Die()
        {
            dType = 20;
        }

        public Die(int type)
        {
            dType = type;
        }

        public RollResult Roll(int count = 1, int modifier = 0)
        {
            RollResult result = new RollResult();
            result.rollValues = new List<int>();
            Random randy = new Random();
            for (int i = 0; i < count; i++)
            {
                int newVal = randy.Next(dType) + 1;
                result.rollValues.Add(newVal);
                result.result += newVal;
            }
            result.result += modifier;
            result.modifier = modifier;
            return result;
        }

        public static int RollD20()
        {
            Die die = new Die(20);
            var result = die.Roll();
            return result.result;
        }
    }
}
