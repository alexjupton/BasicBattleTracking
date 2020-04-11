using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCore
{
    public static class LogMessageQueue
    {
        public static Queue<string> msgQueue { get; private set; }

        public static void Log (string message)
        {
            msgQueue.Enqueue(message);
        }

        public static void Initialize()
        {
            msgQueue = new Queue<string>();
        }
    }
}
