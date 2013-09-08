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
        public static Image tileEmpty = Image.FromFile("Images/Empty.png");
        public static Image tileOne = Image.FromFile("Images/One.png");
        public static Image tileTwo = Image.FromFile("Images/Two.png");
        public static Image tileThree = Image.FromFile("Images/Three.png");
        public static Image tileFour = Image.FromFile("Images/Four.png");
        public static Image tileFive = Image.FromFile("Images/Five.png");
        public static Image tileSix = Image.FromFile("Images/Six.png");
        public static Image tileSeven = Image.FromFile("Images/Seven.png");
        public static Image tileEight = Image.FromFile("Images/Eight.png");
        public static Image tileNine = Image.FromFile("Images/Nine.png");
        public static Image tileTen = Image.FromFile("Images/Ten.png");
        public static Image tileEleven = Image.FromFile("Images/Eleven.png");
        public static Image tileTwelve = Image.FromFile("Images/Twelve.png");
        public static Image tileThirteen = Image.FromFile("Images/Thirteen.png");
        public static Image tileFourteen = Image.FromFile("Images/Fourteen.png");
        public static Image tileFifteen = Image.FromFile("Images/Fifteen.png");
        public static Image tileSixteen = Image.FromFile("Images/Sixteen.png");

        public static Image Background = Image.FromFile("Images/Background.png");

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
