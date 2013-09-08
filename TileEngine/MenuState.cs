using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace TileEngine
{
    //This class creates a matrix of tiles and visually creates & positions them.
    class MenuState : BasicState
    {
        //Constructor. Creates the tileArray, imageArray, and sets the images of the tiles. 
        public MenuState()
        {
        }


        //Game Loop
        public override void Update()
        {
        }


        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawImage(Resources.Background, new Rectangle(0, 0, 700, 720));

        }

        //Whenever the mouse is moved.
        public override void MouseMoved(MouseEventArgs e)
        {

        }

        public override void MouseClicked(MouseEventArgs e)
        {


        }
    }
}