using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace TileEngine
{
    //This class holds the imformation about a single tile in the tilemap

    class Tile
    {
        private Rectangle RECTANGLE;
        private Image IMAGE;

        public Tile(int X, int Y, int SideWidth, Image image, int i)
        {
            //Creates a rectangle for drawing from the constructor information
            RECTANGLE = new Rectangle(X, Y, SideWidth, SideWidth);

            //Stores the Image.
            IMAGE = image;
        }

        //These are properties. They are exclusing to C#.
        //Just an easier way of doing get() and set() methods
        public Image TileImage
        {
            get{ return IMAGE; }
            set { IMAGE = value; }
        }

        public Rectangle TileRectangle
        {
            get { return RECTANGLE; }
            //may be unneeded. (Not currently used)
            set { RECTANGLE = value; }
        }

        public void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawImage(IMAGE, TileRectangle);
        }
    }
}

 
