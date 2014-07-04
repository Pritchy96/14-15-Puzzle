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
    class IngameState : BasicState
    {

        //Outline of the tilemap
        private Rectangle gridRectangle;
        Rectangle SaveButtonRect = new Rectangle(40, 648, 177, 53);
        Rectangle LoadButtonRect = new Rectangle(262, 648, 177, 53);
        Rectangle ResetButtonRect = new Rectangle(493, 648, 177, 53);


        public Tile[,] tileArray;
        private Tile mouseTile;
        // private Boolean MouseInGrid = false;
        ArrayList imagePicker = new ArrayList();
        Random rand = new Random();


        //Constructor. Creates the tileArray, imageArray, and sets the Resources.images of the tiles. 
        public IngameState(int width, int height, int TileSide)
        {
            //Gird outline.
            gridRectangle = new Rectangle(49, 9, width + 2, height + 2);
            //Creates the empty array
            tileArray = new Tile[(width / TileSide), (height / TileSide)];

            //X and Y loop values.
            int X = 50;
            int Y = 25;

            //Two loops: First one is the current row we're on, the second is the column.
            for (int i = 0; i < tileArray.GetLength(1); i++)
            {
                for (int j = 0; j < tileArray.GetLength(0); j++)
                {
                    //Creates a new tile using X and Y, position I, J.
                    tileArray[j, i] = new Tile(X, Y, TileSide, Resources.tileEmpty, i);
                    //Increases X for creation/positioning of next tile.
                    X += TileSide;
                }
                //When the inner loop ends, we need to start a new row, both visually and graphically.
                Y += TileSide;
                X = 50;
            }



            Reset();
        }


        //Game Loop
        public override void Update()
        {
        }


        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawImage(Resources.Background, new Rectangle(0, 0, 700, 720));

            foreach (Tile t in tileArray)
            {
                t.Draw(e);
            }
        }

        //Image changer for a single number, just supply the numbers of the tile as a parameter.
        public void ImageChange(int tileRow, int tileColumn)
        {
            //'Moving' the tile.
            try
            {
                //Left
                //To prevent errors, the position is first checked to make sure it is not at the edge of the array.
                if (tileRow != 0)
                {
                    //A check is then done to see if there is a free tile (BlackTile) around it in a certain position (row - 1, left, for instance)
                    if (tileArray[tileRow - 1, tileColumn].TileImage == Resources.tileEmpty)
                    {
                        //If so, replace the current tile with a black tile and replace the free tile with image.
                        tileArray[tileRow - 1, tileColumn].TileImage = tileArray[tileRow, tileColumn].TileImage;
                        tileArray[tileRow, tileColumn].TileImage = Resources.tileEmpty;
                        //Checking method.
                        WinCheck();
                    }
                }
                //Right
                if (tileRow != 3)
                {
                    if (tileArray[tileRow + 1, tileColumn].TileImage == Resources.tileEmpty)
                    {
                        tileArray[tileRow + 1, tileColumn].TileImage = tileArray[tileRow, tileColumn].TileImage;
                        tileArray[tileRow, tileColumn].TileImage = Resources.tileEmpty;
                        WinCheck();
                    }
                }
                //Up
                if (tileColumn != 3)
                {
                    if (tileArray[tileRow, tileColumn + 1].TileImage == Resources.tileEmpty)
                    {
                        tileArray[tileRow, tileColumn + 1].TileImage = tileArray[tileRow, tileColumn].TileImage;
                        tileArray[tileRow, tileColumn].TileImage = Resources.tileEmpty;
                        WinCheck();
                    }
                }
                //Down
                if (tileColumn != 0)
                {
                    if (tileArray[tileRow, tileColumn - 1].TileImage == Resources.tileEmpty)
                    {
                        tileArray[tileRow, tileColumn - 1].TileImage = tileArray[tileRow, tileColumn].TileImage;
                        tileArray[tileRow, tileColumn].TileImage = Resources.tileEmpty;
                        WinCheck();
                    }
                }


            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Error with ImageChange. Probably numbers passed are too big.");
            }
        }

        //Checking to see if the user has won.
        private void WinCheck()
        {
            int tilesCorrect = 0;
            for (int j = 0; j < tileArray.GetLength(0); j++)
            {
                for (int i = 0; i < tileArray.GetLength(1); i++)
                {
                    int imageNumber;

                    // if i = 0, we must use a different formula to stop stuff messing up.
                    if (i == 0)
                    {
                        imageNumber = (i + 1) * (j * 4);
                    }
                    else
                    {
                        // 4 * i is just adding the previous numbers on to the number calculated
                        //by finding how many rows we have gone through and multiplying that by 4.
                        //Remember it starts at 0 so we do not need to -1
                        imageNumber = (4 * j) + i;
                    }

                    if (tileArray[i, j].TileImage == Resources.images[imageNumber])
                    {
                        tilesCorrect++;
                    }
                }
            }

            if (tilesCorrect == tileArray.Length)
            {
                tileArray[0, 0].TileImage = Resources.tileOne;
            }
        }


        //Whenever the mouse is moved.
        public override void MouseMoved(MouseEventArgs e)
        {
        }

        public override void MouseClicked(MouseEventArgs e)
        {
            if (gridRectangle.Contains(e.Location))
            {
                //Mouse Interaction
                int indexi = 0;
                int indexj = 0;

                for (int i = 0; i < tileArray.GetLength(1); i++)
                {
                    for (int j = 0; j < tileArray.GetLength(0); j++)
                    {
                        if (tileArray[j, i].TileRectangle.Contains(e.Location))
                        {
                            indexi = i;
                            indexj = j;
                            mouseTile = tileArray[j, i];
                        }
                    }
                }

                ImageChange(indexj, indexi);
            }
            else
            {
                if (SaveButtonRect.Contains(e.Location))
                {
                    Save();
                }
                else if (LoadButtonRect.Contains(e.Location))
                {
                    Load();
                }

                else if (ResetButtonRect.Contains(e.Location))
                {
                    Reset();
                }
            }
        }

        //Tilemap reconstruction.
        public void Reset()
        {
            imagePicker.Clear();

            //Assigning the Images in the imageArray to the tiles in the tileArray.
            for (int e = 0; e < tileArray.GetLength(1); e++)
            {
                for (int f = 0; f < tileArray.GetLength(0); f++)
                {
                    while (true)
                    {
                        int random = rand.Next(0, 16);

                        //Making sure that an image is only used once.
                        if (imagePicker.Contains(random.ToString()) == false)
                        {
                            imagePicker.Add(random.ToString());
                            tileArray[f, e].TileImage = (Image)Resources.images[random];
                            tileArray[f, e].TileImage.Tag = Resources.imageNames[random];
                            break;

                        }
                    }
                }
            }
        }

        public void Save()
        {
            //Clears loadSave
            string sSave = "";


            //Delete file if exists.
            if (File.Exists(Application.StartupPath + "/SliderSave.txt"))
            {
                File.Delete(Application.StartupPath + "/SliderSave.txt");
                Console.WriteLine("File Deleted");
            }

            //Setting up the string to Save.
            for (int e = 0; e < tileArray.GetLength(1); e++)
            {
                for (int f = 0; f < tileArray.GetLength(0); f++)
                {
                    sSave += tileArray[f, e].TileImage.Tag + ",";
                }
            }
            System.IO.StreamWriter saveFile = new System.IO.StreamWriter(Application.StartupPath + "/SliderSave.txt");
            saveFile.WriteLine(sSave);
            saveFile.Close();
            Console.WriteLine("File Saved: " + sSave);
        }

        public void Load()
        {
            //Clears loadSave
            String sLoad = "";
            if (File.Exists(Application.StartupPath + "/SliderSave.txt"))
            {
                System.IO.StreamReader loadFile = new System.IO.StreamReader(Application.StartupPath + "/SliderSave.txt");
                sLoad = loadFile.ReadLine();
                string[] loadedImages = sLoad.Split(',');
                loadFile.Close();

                for (int e = 0; e < tileArray.GetLength(1); e++)
                {
                    for (int f = 0; f < tileArray.GetLength(0); f++)
                    {
                        //Getting the index by finding the string in the ImageNames list and returning its index.
                        tileArray[e, f].TileImage = (Image)Resources.images[Resources.imageNames.IndexOf(loadedImages[(4 * f) + e])];
                    }
                }
            }

        }


    }
}
