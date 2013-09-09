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

        Rectangle playButtonRect = new Rectangle(150, 600, 400, 100);
        GameManager manager;

        public MenuState(GameManager manager)
        {
            this.manager = manager;
        }


        //Game Loop
        public override void Update()
        {
        }


        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawImage(Resources.MenuBackground, new Rectangle(0, 0, 700, 720));

        }

        //Whenever the mouse is moved.
        public override void MouseMoved(MouseEventArgs e)
        {

        }

        public override void MouseClicked(MouseEventArgs e)
        {
            if (playButtonRect.Contains(e.Location))
            {
                manager.BeginGame();
            }
        }
    }
}