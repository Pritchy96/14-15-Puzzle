using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TileEngine
{
    //this class is simply a souble buffered pannel :D
    class Screen : Panel
    {
        public Screen()
        {
            //Changing some properties:
            this.DoubleBuffered = true;
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;
        }

        //I prefure Redraw() to Invalidate() :P
        public void Redraw()
        {
            this.Invalidate();
        }
    }
}
