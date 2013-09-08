using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TileEngine
{
    public partial class Form1 : Form
    {
        public static int WIDTH = 700;
        public static int HEIGHT = 720;


        Boolean Running = false;
        Thread thread = null;
        GameManager manager = new GameManager(600, 600, 150);

     
        
        public Form1()
        {
            InitializeComponent();
            SetScreenSize(WIDTH, HEIGHT);
            startThread();
        }

        public void startThread()
        {
            //Here we create our thread with a threadStart
            //The thread start defines which method the thread will act on.
            //Note you could also just thread an entire class I think
            thread = new Thread(new ThreadStart(GameUpdate));
            thread.Start();
            Running = true;
        }

        public void killThread()
        {
            //This method simply kills off the thread
            Running = false;
            thread.Abort();
            thread.Join();
        }


        private void SetScreenSize(int width, int height)
        {
            //The screen is docked and resizes with the form
            this.Width = width + 6;
            this.Height = height + 28;
            //The +6 and 28 are beucase of the decoration around the edge of the window
        }


        //This is an event which is pre-generated from the Panel class for drawing to the panel
        //It is called to repain when the invalidate() method is called (we call this in the GameUpdate() method)
        private void Paint(object sender, PaintEventArgs e)
        {
            //Our graphcis object
            Graphics g = e.Graphics;

            manager.Draw(e);
        }

        //This is the method that will be called over and over by the thread
        public void GameUpdate()
        {
            //This method is running on a seperate thread, thus wont create
            //any lag for the windowwhen using while(true)
            while (Running)
            {
                //TODO: add game update code

                manager.Update();

                //NOTE: the screen should always be drawn to after update has finished
                DrawScreen.Redraw();

                //This slows the thread.
                //Idealy in a proper game engine you want thread Stabiliziation :P
                Thread.Sleep(12);
            }
        }

        //
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            killThread();
        }

        //Calls the method MouseClicked within the tileMap class.
        private void MouseClick(object sender, MouseEventArgs e)
        {
            manager.MouseClicked(e);
        }

        //Calls the method MouseMoved within the tileMap class.
        private void MouseMoved(object sender, MouseEventArgs e)
        {
            manager.MouseMoved(e);
        }

        private void Drawstuff(object sender, PaintEventArgs e)
        {
            manager.Draw(e);
        }

        private void Reset(object sender, EventArgs e)
        {
            //TileMap.restart();
        }

        private void Save(object sender, MouseEventArgs e)
        {
        //    TileMap.save();
        }

        private void Load(object sender, EventArgs e)
        {
           // TileMap.load();
        }
    }
}
