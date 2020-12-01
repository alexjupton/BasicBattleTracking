using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace PF.API
{
    public struct DieResult
    {
        public int Total;
        public List<int> DieRolls;
        public int modifier;
    }
    public class Dice
    {
        private static RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        public async static Task<DieResult> Roll(int dType, int dCount, int totalModifier)
        {
            int total = 0;
            byte[] random = new byte[4];
            DieResult result = new DieResult();
            result.DieRolls = new List<int>();
            for (int i = 0; i < dCount; i++)
            {
                await Task.Run(() => provider.GetBytes(random));
                int roll = BitConverter.ToInt32(random) % dType + 1;
                total += roll;
                result.DieRolls.Add(roll);
            }
            total += totalModifier;
            result.Total = total;
            result.modifier = totalModifier;
            return result;
        }
    }
}
