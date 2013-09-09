using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TileEngine
{
    class GameManager
    {
        int width = 0;
        int height = 0;
        int tileSide = 0;

        private BasicState currentState;

        public BasicState CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }

        public GameManager(int width, int height, int tileSide)
        {
            Resources.Setup();
            currentState = new MenuState(this);

            this.width = width;
            this.height = height;
            this.tileSide = tileSide;
        }

        public void BeginGame()
        {
            currentState = new IngameState(width, height, tileSide);
        }

        //Whenever the mouse is moved.
        public void MouseMoved(MouseEventArgs e)
        {
          currentState.MouseMoved(e);
        }

        public void MouseClicked(MouseEventArgs e)
        {
          currentState.MouseClicked(e);
        }

        //Game Loop
        public void Update()
        {
            currentState.Update();
        }

        public void Draw(PaintEventArgs e)
        {
            currentState.Draw(e);
        }

    }
}
