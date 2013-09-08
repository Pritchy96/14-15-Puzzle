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
        private BasicState currentState;

        public BasicState CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }

        public GameManager(int width, int height, int tileSide)
        {
            Resources.Setup();
            currentState = new IngameState(width, height, tileSide);
            
            //currentState = new MenuState();
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
