﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using BasicBattleTracking.Forms;
using BattleCore;

namespace BasicBattleTracking
{
    static class Program
    {
        public static string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\BasicBattleTracking";
        public static Settings activeSettings;
        public static string ProgramName = "Pathfinder Omnitool";
        public static string activeSessionName;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        
        static void Main()
        {
            LogMessageQueue.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }

        public static int getAbilityMod(int abilityScore)
        {
            int mod = 0;
            if (abilityScore >= 10)
            {
                mod = (abilityScore - 10) / 2;
            }
            else
            {
                mod = (abilityScore - 11) / 2;
            }
            return mod;
        }

        private static void SplashScreen()
        {
            Application.Run(new SplashScreen());
        }
    }
}
