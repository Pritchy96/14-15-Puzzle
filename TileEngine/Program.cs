using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TileEngine
{
    static class Program
    {
        //This method prints to the console 
        public static void Log(object o)
        {
            System.Console.Out.WriteLine(o.ToString());
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameScreen());
        }
    } 
}
