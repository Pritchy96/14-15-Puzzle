using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileEngine
{
    static class Resources
    {


        public static List<Image> images = new List<Image>(16);
        public static List<String> imageNames = new List<String>(16);

        //Image Import
        public static Image tileEmpty = Puzzler.Properties.Resources.Empty;
        public static Image tileOne = Puzzler.Properties.Resources.One;
        public static Image tileTwo = Puzzler.Properties.Resources.Two;
        public static Image tileThree = Puzzler.Properties.Resources.Three;
        public static Image tileFour = Puzzler.Properties.Resources.Four;
        public static Image tileFive = Puzzler.Properties.Resources.Five;
        public static Image tileSix = Puzzler.Properties.Resources.Six;
        public static Image tileSeven = Puzzler.Properties.Resources.Seven;
        public static Image tileEight = Puzzler.Properties.Resources.Eight;
        public static Image tileNine = Puzzler.Properties.Resources.Nine;
        public static Image tileTen = Puzzler.Properties.Resources.Ten;
        public static Image tileEleven = Puzzler.Properties.Resources.Eleven;
        public static Image tileTwelve = Puzzler.Properties.Resources.Twelve;
        public static Image tileThirteen = Puzzler.Properties.Resources.Thirteen;
        public static Image tileFourteen = Puzzler.Properties.Resources.Fourteen;
        public static Image tileFifteen = Puzzler.Properties.Resources.Fifteen;
        public static Image tileSixteen = Puzzler.Properties.Resources.Sixteen;

        public static Image Background = Puzzler.Properties.Resources.Background;
        public static Image MenuBackground  = Puzzler.Properties.Resources.MenuBackground;

        public static void Setup()
        {
        
            imageNames.Add("tileEmpty");
            imageNames.Add("tileTwo");
            imageNames.Add("tileThree");
            imageNames.Add("tileFour");
            imageNames.Add("tileFive");
            imageNames.Add("tileSix");
            imageNames.Add("tileSeven");
            imageNames.Add("tileEight");
            imageNames.Add("tileNine");
            imageNames.Add("tileTen");
            imageNames.Add("tileEleven");
            imageNames.Add("tileTwelve");
            imageNames.Add("tileThirteen");
            imageNames.Add("tileFourteen");
            imageNames.Add("tileFifteen");
            imageNames.Add("tileSixteen");

            images.Add(tileEmpty);
            images.Add(tileTwo);
            images.Add(tileThree);
            images.Add(tileFour);
            images.Add(tileFive);
            images.Add(tileSix);
            images.Add(tileSeven);
            images.Add(tileEight);
            images.Add(tileNine);
            images.Add(tileTen);
            images.Add(tileEleven);
            images.Add(tileTwelve);
            images.Add(tileThirteen);
            images.Add(tileFourteen);
            images.Add(tileFifteen);
            images.Add(tileSixteen);
        }
    }
}
