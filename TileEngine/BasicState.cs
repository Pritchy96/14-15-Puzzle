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
    abstract class BasicState
    {
        //Game Loop
        public virtual void Update()
        {
        }


        public virtual void Draw(PaintEventArgs e)
        {
           // e.Graphics.DrawImage(Background, new Rectangle(0, 0, 700, 720));
        }

        //Whenever the mouse is moved.
        public virtual void MouseMoved(MouseEventArgs e)
        {
        }

        public virtual void MouseClicked(MouseEventArgs e)
        {
        }

    }
}