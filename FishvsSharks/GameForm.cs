/*
 * Yasoob Ali, William Chan, Isaac Abdi, Roshan Nantha
 * January 21st, 2019
 * This is the GameManager class that manages the fish, user, sharks, and waterpower
 * 
 * CONTRIBUTIONS
 * ________________________________________________
 * Contributions in the OnPaint and Timer are specified

    William:

    Methods
    ____________________
    CreateGrid
    Form1_MouseDown
    Form1_MouseUp


    Roshan:

    Methods
    _____________________
    CheckFishSpitterOnGrid
    Form1_MouseClick


    Isaac:

    Methods
    ____________________
    GetAllFishGrid
    Form1_MouseMove
    GameForm_FormClosing


    Yasoob: 

    Methods
    _____________________
    CreateToolBar
    CheckSharksOnGrid

 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FishvsSharks
{
    public partial class GameForm : Form
    {
        // a public integer constant used to store the number of columns for the grid
        public const int GRID_SIZE_COLUMNS = 7;
        // a public integer constant sued to store the number of rows for the grid
        public const int GRID_SIZE_ROWS = 4;

        // a private 2d rectangle array that is used to create the 4x7 grid
        private Rectangle[,] grid = new Rectangle[GRID_SIZE_COLUMNS, GRID_SIZE_ROWS];

        // a public integer constant used to store the cell size in the grid which is 100
        public const int CELL_SIZE = 100;

        // a public integer constant used to store the size of the toolbar which is 7
        private const int TOOL_BAR_SIZE = 7;

        // a rectangle array used to store the rectangles of each toolbar image
        private Rectangle[] toolbar = new Rectangle[TOOL_BAR_SIZE];
        // an image array used to store the images of each fish for the toolbar
        private Image[] toolbarImages = new Image[TOOL_BAR_SIZE];

        //Toolbar constant for if nothing is selected
        private const int NO_SELECTION = -1;

        //Integer used to store the current selection
        //Right now it is set to no selection
        private int toolbarSelection = NO_SELECTION;

        // GameManager object used to access GameManager methods
        private GameManager manager;

        // private integer used to store the water power's spawn rate (3 seconds)
        private int waterPowerSpawnRate = 3000;

        // private integer used to store the shark's spawn rate (5 seconds)
        private int sharkSpawnRate = 5000;

        // Rectangle used for the dragging animation
        private Rectangle imageDragBox;

        //Random object that generates random numbers
        private Random randomGenerator = new Random();

        // private integer that stores the time that the game starts and is used to spawn waterpower
        private int gameStartTime = 0;

        // private integer that stores the time that the game starts and is used to spawn sharks
        private int gameStartTime2 = 0;

        // private integer that stores the time that a starfish explodes
        private int starExplosionStartTime = 0;

        // private integer that stores the time that a salmon bomb explodes
        private int salmonBombExplosionStartTime = 0;

        // private integer that stores the time that a pufferfish explodes
        private int puffExplosionStartTime = 0;

        // private integer that stores the time that an octopus explodes
        private int octExplosionStartTime = 0;

  


        public GameForm()
        {
            //Runs the CreateGrid() subprogram
            //Creates the grid
            CreateGrid();

            // Initializes the manager object by passing the the grid's columns and rows
            manager = new GameManager(GRID_SIZE_COLUMNS, GRID_SIZE_ROWS);

            InitializeComponent();

            // set gameStartTime to the current time
            gameStartTime = Environment.TickCount;

            // set gameStartTime2 to the current time
            gameStartTime2 = Environment.TickCount;

            //Runs the CreateToolBar subprogram 
            //Creates the tool bar
            CreateToolBar();

            //Creating the imageDragBox by passing in the x and y coordinates and length and width
            imageDragBox = new Rectangle(0, 0, 50, 50);
        }

        /// <summary>
        /// Gets the integer that stores the octopus's explosion time
        /// </summary>
        public int OctExplosionStartTime
        {
            get { return octExplosionStartTime; }
        }

        /// <summary>
        /// Gets the integer that stores the starfish's explosion time
        /// </summary>
        public int StarExplosionStartTime
        {
            get { return starExplosionStartTime; }
        }

        /// <summary>
        /// Gets the integer that stores the pufferfish's explosion time
        /// </summary>
        public int PuffExplosionStartTime
        {
            get { return puffExplosionStartTime; }
        }

        /// <summary>
        /// Gets the integer that stores the salmon bomb's explosion start time
        /// </summary>
        public int SalmonBombExplosionStartTime
        {
            get { return salmonBombExplosionStartTime; }
        }

        /// <summary>
        /// Method that creates the grid
        /// </summary>
        private void CreateGrid()
        {
            // MAKES A NESTED FOR LOOP THAT LOOPS THROUGH THE 2D ARRAY OF RECTANGLES
            for (int j = 0; j < GRID_SIZE_COLUMNS; j++)
            {
                for (int k = 0; k < GRID_SIZE_ROWS; k++)
                {
                    //Create the rectangle at the grid's coordinates
                    grid[j, k] = new Rectangle(j * CELL_SIZE, k * CELL_SIZE, CELL_SIZE, CELL_SIZE);
                }
            }
        }

        /// <summary>
        /// Create the tool bar
        /// </summary>
        private void CreateToolBar()
        {
            // sets the first index to the flop fish image
            toolbarImages[0] = Properties.Resources.flopfish;
            // sets the second index to the fish spitter image
            toolbarImages[1] = Properties.Resources.fishshooter;
            // sets the third index to the fish egg images
            toolbarImages[2] = Properties.Resources.egg;
            // sets the fourth index to the pufferfish image
            toolbarImages[3] = Properties.Resources.pufferfish;
            // sets the fifth index to the octopus image
            toolbarImages[4] = Properties.Resources.octopus;
            // sets the fixth index to the starfish image
            toolbarImages[5] = Properties.Resources.starfish;
            // sets the sixth index to the salmon image
            toolbarImages[6] = Properties.Resources.salmon;

            // sets the toolbar's y-coordinate to the bottom of the sceen
            int yLocation = ClientSize.Height - CELL_SIZE - 40;

            // MAKES A FOR LOOP TO LOOP THROUGH THE TOOLBAR ARRAY TO CREATE THE RECTANGLES AT THE GIVEN LOCATIONS
            for (int k = 0; k < toolbar.Length; k++)
            {
                toolbar[k] = new Rectangle(k * CELL_SIZE + 140, yLocation, 90, CELL_SIZE);
            }
        }

        /// <summary>
        /// A Rectangle[,] method that makes a copy of the 2D array and returns a copy
        /// </summary>
        /// <returns></returns>
        public Rectangle[,] GetAllFishGrid()
        {
            //Create a shallow copy of the grid 2D array
            Rectangle[,] allFishGrid = new Rectangle[GRID_SIZE_COLUMNS, GRID_SIZE_ROWS];

            //Copy the orignal grid onto the shallow copy
            for (int j = 0; j < GRID_SIZE_COLUMNS; j++)
            {
                for (int k = 0; k < GRID_SIZE_ROWS; k++)
                {
                    allFishGrid[j, k] = grid[j, k];
                }
            }

            //Return the shallow copy
            return allFishGrid;
        }


        /// <summary>
        /// A boolean function that checks to see if there is a fish spitter on the grid
        /// </summary>
        /// <returns>Returns true if a fish spitter is on the grid or false if there is no fish spitter on the grid</returns>
        private bool CheckFishSpitterOnGrid()
        {
            //Get a copy of the fishes 2D array using the manager's GetAllFish() method
            Fish[,] fishes = manager.GetAllFish();

            // MAKES A NESTED FOR LOOP TO LOOP THROUGH THE 2D ARRAY TO FIND FISH SPITTERS
            for (int j = 0; j < GRID_SIZE_COLUMNS; j++)
            {
                for (int k = 0; k < GRID_SIZE_ROWS; k++)
                {
                    //If the fish is a fish spitter
                    if (fishes[j, k].UnitType == FishSpitter.UNIT_TYPE)
                    {
                        //Return true 
                        return true;
                    }
                }
            }

            //If there is not fish spitter on the grid, return false
            return false;
        }

        /// <summary>
        /// Boolean function that checks if there are sharks on the grid
        /// </summary>
        /// <returns>Returns true if there are sharks or false if there are none</returns>
        private bool CheckSharksOnGrid()
        {
            //Get a list of the sharks using the manager's GetAllSharks() method
            List<Sharks> sharks = manager.GetAllSharks();

            //If there is more than 1 shark in the list
            if (sharks.Count > 0)
            {
                //Return true
                return true;
            }

            //If there are no sharks then return false
            return false;
        }

        /// <summary>
        /// Overrides the built in GameForm's graphics to draw the game
        /// //Draws the grid, explosions, fishes, sharks and spit
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            ///////////////// WILLIAM //////////////////////////////
            // MAKES A NESTED FOR LOOP TO LOOP THROUGH THE GRID
            for (int j = 0; j < GRID_SIZE_COLUMNS; j++)
            {
                for (int k = 0; k < GRID_SIZE_ROWS; k++)
                {
                    //Draws water on the grid
                    e.Graphics.DrawImage(Properties.Resources.water, grid[j, k]);

                    //Draws the fishes image on the grid
                    e.Graphics.DrawImage(manager.GetGrid(j, k).FishImage, grid[j, k]);

                    //Outlines the grid in black
                    e.Graphics.DrawRectangle(Pens.Black, grid[j, k]);
                }
            }

            ///////////////////// YASOOB ///////////////////////
            // MAKES A FOR LOOP TO LOOP THROUGH THE TOOLBAR ARRAY
            for (int k = 0; k < toolbar.Length; k++)
            {
                //Draw the toolbar images at the bottom of the screen
                e.Graphics.DrawImage(toolbarImages[k], toolbar[k]);
            }

            ///////////////////// YASOOB ///////////////////////
            //Draw the mouse drag if there is somethine selected
            if (toolbarSelection != NO_SELECTION)
            {
                e.Graphics.DrawImage(toolbarImages[toolbarSelection], imageDragBox);
            }


            ////////////////////// ROSHAN ////////////////////////////
            //Get a list of the sharks using the manager GetAllSharks() method
            List<Sharks> allSharks = manager.GetAllSharks();
            // MAKES A FOR LOOP TO LOOP THROUGH THE ALLSHARKS LIST
            for (int j = 0; j < allSharks.Count; j++)
            {
                //Draws the shark
                e.Graphics.DrawImage(allSharks[j].SharkImage, allSharks[j].Hitbox);
            }

            ///////////////////////// WILLIAM /////////////////////////////////
            //If the starfish explosion status is true
            if (manager.StarExplosionStatus == true)
            {
                // MAKE A NESTED LOOP TO LOOP THROUGH THE ROWS OF THE EXPLOSION
                for (int j = manager.StarColumn; j < manager.StarColumn + 1; j++)
                {
                    for (int k = 0; k < GRID_SIZE_ROWS; k++)
                    {
                        //Draw an explosion where the starfish has its explosion on its column
                        e.Graphics.DrawImage(Properties.Resources.explosion, grid[j, k]);

                        // MAKES A FOR LOOP TO LOOP THROUGH THE ALLSHARKS LIST
                        for (int z = 0; z < allSharks.Count; z++)
                        {
                            //If the grid contains a shark
                            if (grid[j, k].Contains(allSharks[z].Hitbox.Location))
                            {
                                //The shark gets exploded (it dies)
                                allSharks[z].GetExploded();
                            }
                        }
                    }
                }

                // MAKES A NESTED FOR LOOP TO LOOP THROUGH THE COLUMNS OF THE EXPLOSION
                for (int j = 0; j < GRID_SIZE_COLUMNS; j++)
                {
                    for (int k = manager.StarRow; k < manager.StarRow + 1; k++)
                    {
                        //Draw an explosion where the starfish has its explosion on its row
                        e.Graphics.DrawImage(Properties.Resources.explosion, grid[j, k]);

                        // MAKES A FOR LOOP TO LOOP THROUGH THE ALLSHARKS LIST
                        for (int z = 0; z < allSharks.Count; z++)
                        {
                            //If the grid contains a shark
                            if (grid[j, k].Contains(allSharks[z].Hitbox.Location))
                            {
                                //The shark gets exploded (it dies)
                                allSharks[z].GetExploded();
                            }
                        }
                    }
                }

                //If the star's explosion time is 0
                if (starExplosionStartTime == 0)
                {
                    //The star's explosion time equals the current time
                    starExplosionStartTime = Environment.TickCount;
                }

                //If the explosions have to be erased
                if (manager.EraseExplosions(this))
                {
                    // MAKES A FOR LOOP TO LOOP THROUGH THE GRID
                    for (int j = 0; j < GRID_SIZE_COLUMNS; j++)
                    {
                        for (int k = 0; k < GRID_SIZE_ROWS; k++)
                        {
                            //Draw the fish's image
                            e.Graphics.DrawImage(manager.GetGrid(j, k).FishImage, grid[j, k]);

                            //Outline the grid in black
                            e.Graphics.DrawRectangle(Pens.Black, grid[j, k]);
                        }
                    }

                    //Make the star's explosion time equal the current time
                    starExplosionStartTime = 0;
                }
            }

            /////////////////////////// ROSHAN ///////////////////////////////
            //If the salmon explosion status is true
            if (manager.SalmonBombExplosionStatus == true)
            {
                // MAKES A FOR LOOP THAT LOOPS THROUGH THE WHOLE GRID TO EXPLODE
                for (int j = 0; j < GRID_SIZE_COLUMNS; j++)
                {
                    for (int k = 0; k < GRID_SIZE_ROWS; k++)
                    {
                        //Draw the explosion image at coordinate [j,k]
                        e.Graphics.DrawImage(Properties.Resources.explosion, grid[j, k]);

                        // MAKES A FOR LOOP TO LOOP THROUGH THE ALLSHARKS LIST
                        for (int z = 0; z < allSharks.Count; z++)
                        {
                            //If the grid contains a shark
                            if (grid[j, k].Contains(allSharks[z].Hitbox.Location))
                            {
                                //The shark gets exploded (it dies)
                                allSharks[z].GetExploded();
                            }
                        }
                    }
                }

                //If the salmonBombExplosionStartTime is 0
                if (salmonBombExplosionStartTime == 0)
                {
                    //Make salmonBombExplosionStartTime equal the current time
                    salmonBombExplosionStartTime = Environment.TickCount;
                }

                //If the explosion has to be erased
                if (manager.EraseExplosions(this))
                {
                    //MAKES A FOR LOOP TO LOOP THROUGH THE GRID
                    for (int j = 0; j < GRID_SIZE_COLUMNS; j++)
                    {
                        for (int k = 0; k < GRID_SIZE_ROWS; k++)
                        {
                            //Draw the fish image in the grid 
                            e.Graphics.DrawImage(manager.GetGrid(j, k).FishImage, grid[j, k]);
                            // Outline the grids in black
                            e.Graphics.DrawRectangle(Pens.Black, grid[j, k]);
                        }
                    }
                    //Set salmonBombExplosionStartTime back to 0
                    salmonBombExplosionStartTime = 0;
                }
            }

            /////////////////////// ISAAC /////////////////////////////////////
            //If the pufferfish explosion status is true
            if (manager.PuffExplosionStatus == true)
            {
                // MAKES A NESTED FOR LOOP TO LOOP THROUGH THE COLUMNS OF THE EXPLOSION
                for (int j = 0; j < GRID_SIZE_COLUMNS; j++)
                {
                    for (int k = manager.PuffRow; k < manager.PuffRow + 1; k++)
                    {
                        //Draws an explosion on the grid
                        e.Graphics.DrawImage(Properties.Resources.explosion, grid[j, k]);

                        // MAKES A FOR LOOP TO LOOP THROUGH THE ALLSHARKS LIST
                        for (int z = 0; z < allSharks.Count; z++)
                        {
                            //If the grid contains a shark
                            if (grid[j, k].Contains(allSharks[z].Hitbox.Location))
                            {
                                //The shark gets exploded (it dies)
                                allSharks[z].GetExploded();
                            }
                        }
                    }
                }

                //If the pufferfish's explosion time equals 0
                if (puffExplosionStartTime == 0)
                {
                    //Make it equal the current time
                    puffExplosionStartTime = Environment.TickCount;
                }

                //If the explosions have to be erased
                if (manager.EraseExplosions(this))
                {
                    // MAKES A NESTED FOR LOOP TO LOOP THROUGH THE GRID
                    for (int j = 0; j < GRID_SIZE_COLUMNS; j++)
                    {
                        for (int k = 0; k < GRID_SIZE_ROWS; k++)
                        {
                            //Draw the fish image in the grid and the geometry
                            e.Graphics.DrawImage(manager.GetGrid(j, k).FishImage, grid[j, k]);

                            //Outline the grid in black
                            e.Graphics.DrawRectangle(Pens.Black, grid[j, k]);
                        }
                    }

                    //Make the pufferfish's start time equal 0
                    puffExplosionStartTime = 0;
                }
            }

            //////////////////////// YASOOB //////////////////////////////
            //If the octopus's explosion status is true
            if (manager.OctExplosionStatus == true)
            {
                // MAKES A NESTED FOR LOOP THAT LOOPS THROUGH THE EXPLOSION'S ROWS
                for (int j = manager.OctCol; j < manager.OctCol + 1; j++)
                {
                    for (int k = 0; k < GRID_SIZE_ROWS; k++)
                    {
                        //Draw an explosion on that coordinate of the grid
                        e.Graphics.DrawImage(Properties.Resources.explosion, grid[j, k]);

                        // MAKES A FOR LOOP TO LOOP THROUGH THE ALLSHARKS LIST
                        for (int z = 0; z < allSharks.Count; z++)
                        {
                            //If the grid contains a shark
                            if (grid[j, k].Contains(allSharks[z].Hitbox.Location))
                            {
                                //The shark gets exploded (it dies)
                                allSharks[z].GetExploded();
                            }
                        }
                    }
                }

                // if the octopus' start time is equal to 0
                if (octExplosionStartTime == 0)
                {
                    // make it equal to the current time
                    octExplosionStartTime = Environment.TickCount;
                }

                // If the explosions have to be erased
                if (manager.EraseExplosions(this))
                {
                    // MAKES A NESTED FOR LOOP TO LOOP THROUGH THE GRID
                    for (int j = 0; j < GRID_SIZE_COLUMNS; j++)
                    {
                        for (int k = 0; k < GRID_SIZE_ROWS; k++)
                        {
                            //Draw the fish image in the grid and the geometry
                            e.Graphics.DrawImage(manager.GetGrid(j, k).FishImage, grid[j, k]);

                            //Outline the grid in black
                            e.Graphics.DrawRectangle(Pens.Black, grid[j, k]);
                        }
                    }
                    // set the explosion start time to 0
                    octExplosionStartTime = 0;
                }
            }

            //////////////////////////////////// WILLIAM ///////////////////////////////////////
            // gets a copy of the waterpower list by using the manager's method GetAllWaterPower()
            List<Waterpower> allWaterPower = manager.GetAllWaterPower();
            // MAKES A FOR LOOP TO LOOP THROUGH THE ALLWATERPOWER LIST
            for (int i = 0; i < allWaterPower.Count; i++)
            {
                // draws the waterpower
                e.Graphics.DrawImage(allWaterPower[i].WaterPowerImage, allWaterPower[i].HitBox);
            }

            /////////////////////////////////// ROSHAN ////////////////////////////////////
            // gets a copy of the spit list by using the manager's method GetAllSpit();
            List<Spit> spit = manager.GetAllSpit();
            // MAKES A FOR LOOP TO LOOP THROUGH THE SPIT LIST
            for (int i = 0; i < spit.Count; i++)
            {
                //Draws the spit
                e.Graphics.DrawImage(spit[i].SpitImage, spit[i].SpitHitBox);
            }
        }

        /// <summary>
        /// Method when a mouse button is down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //Remove any selection
            toolbarSelection = NO_SELECTION;

            //Search the toolbar rectangles to see if any was clicked
            for (int k = 0; k < toolbar.Length; k++)
            {
                //Save the index of the fish type that was selected
                if (toolbar[k].Contains(e.Location))
                {
                    toolbarSelection = k;
                }
            }
        }

        /// <summary>
        /// Method when a mouse button is up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            //Only do a search if a toolbar selection was made
            if (toolbarSelection != NO_SELECTION)
            {
                // MAKES A NESTED FOR LOOP TO LOOP THROUGH THE GRID TO FIND OUT WHICH GRID'S RECTANGLE WAS MOUSEUP'D
                for (int j = 0; j < GRID_SIZE_COLUMNS; j++)
                {
                    for (int k = 0; k < GRID_SIZE_ROWS; k++)
                    {
                        //If the current grid cell contains the mouse up
                        //Coordinate, we have found where the user wants to build
                        if (grid[j, k].Contains(e.Location))
                        {

                            //Sends the column, row, fish type and gameform as a parameter into FishCreator in GameManager
                            //Creates a fish using those parameters
                            manager.FishCreator(k, j, toolbarSelection, this);

                            //Remove the toolbar selection
                            toolbarSelection = NO_SELECTION;

                            //Return
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Timer that contains all methods/function that need to be constantly run
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrGeneral_Tick(object sender, EventArgs e)
        {
            ////////////////////////// YASOOB/////////////////////////
            //Make the water power label display how much water power the user has
            lblWaterPower.Text = "Water power: " + manager.WaterPowerCounter.ToString();
            /////////////// ROSHAN /////////////////////////
            //Make the points label display how much points the user has
            lblPoints.Text = "Points: " + manager.Points;
            /////////////// YASOOB /////////////////////////
            //Make the levels label display what level the user is on
            lblLevel.Text = "Level: " + manager.Level;
            ////////////////// ROSHAN ///////////////////////
            //Make the lives label display how many lives the user has
            lblLives.Text = "Lives: " + manager.Lives;

            ///////////////////////// WILLIAM ///////////////////////////////
            //If more than 3 seconds has passes since the last water power spawn
            if (Environment.TickCount - gameStartTime >= waterPowerSpawnRate)
            {
                //Create a water power at a random coordinate
                //X coordinate is between 0 and 699
                //Y coordinate is between 0 and 299
                manager.GenerateWaterPower(randomGenerator.Next(0, 700), randomGenerator.Next(0, 300));

                //Make gameStartTime equal the current time
                gameStartTime = Environment.TickCount;
            }

            ////////////////////// YASOOB //////////////////////////////////////////
            //If IncreaseSpawnRate returns true
            if (manager.IncreaseSpawnRate)
            {
                //Decrease the spawn rate by 200 milliseconds
                sharkSpawnRate -= 200;
            }

            ////////////////// WILLIAM ///////////////////////////
            //If more than 5 seconds has passed since last shark spawn
            if (Environment.TickCount - gameStartTime2 >= sharkSpawnRate)
            {

                // Generates a random number from 0 to 1
                int randomSharkType = randomGenerator.Next(0, 2);

                //Generate a random number from 0 to 3
                int randomSharkLocation = randomGenerator.Next(0, 4);

                //If the shark type number is 0
                if (randomSharkType == 0)
                {
                    //Create a regular shark
                    manager.AddSharks(randomSharkLocation, RegularShark.UNIT_TYPE);
                }

                //If the shark type number is 1
                else if (randomSharkType == 1)
                {
                    //Create a hammerhead shark
                    manager.AddSharks(randomSharkLocation, Hammerhead.UNIT_TYPE);
                }

                //Make gameStartTime2 equal the current time
                gameStartTime2 = Environment.TickCount;

            }

            //////////////////////////// ROSHAN ////////////////////////////
            //If there is a fish spitter on the grid and if there are sharks on the grid
            if (CheckFishSpitterOnGrid() == true && CheckSharksOnGrid() == true)
            {
                //Get a copy of the fishes 2D array using the manager's method GetAllFish();
                Fish[,] fishes = manager.GetAllFish();

                // MAKE A NESTED FOR LOOP THAT LOOPS THROUGH THE GRID TO FIND IF THERE IS A FISH SPITTER AND IF IT CAN SPIT
                for (int j = 0; j < GRID_SIZE_COLUMNS; j++)
                {
                    for (int k = 0; k < GRID_SIZE_ROWS; k++)
                    {
                        //If the fish type is fish spitter and the fish spitter is able to spit
                        if (fishes[j, k].UnitType == FishSpitter.UNIT_TYPE && manager.CheckFishCanSpit(fishes[j, k]) == true)
                        {
                            //Get the location of the fish spitter that is able to spit
                            fishes[j, k].GetFishLocation(manager, this, j, k);

                            //Add spit where the fish spitter is located
                            manager.AddSpit(fishes[j, k].HitBox.Location);
                        }
                    }
                }
            }

            /////////////// ISAAC ////////////////////////
            //If the GameOver function returns true 
            if (manager.GameOver())
            {
                //Disable the timer
                tmrGeneral.Enabled = false;

                // sets the label to the level that the player ended with
                lblGameOverLevel.Text = "Level: " + manager.Level;
                // sets the label to the total amount of points the player acquired
                lblGameOverPoints.Text = "Total Points: " + manager.Points;
                // make the game over panel visible
                pnlGameOver.Visible = true;
               
            }

            ////////////////// YASOOB //////////////////////
            //Run the update subprogram in GameManager
            manager.Update(this);

            //Refresh the graphics
            Refresh();
        }

        /// <summary>
        /// Checks when the mouse moves
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //If a toolbar selection has been made, save
            //The coordinates of the mouse
            if (toolbarSelection != NO_SELECTION)
            {
                //Create a image of the selection while dragging
                imageDragBox.Location = new Point(e.Location.X - CELL_SIZE / 4, e.Location.Y - CELL_SIZE / 4);
            }
        }

        /// <summary>
        /// Checks if the form closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Close the application
            Application.Exit();
        }

        /// <summary>
        /// Check if there is a mouse click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //Remove the water power if the user clicked on it
            manager.RemoveWaterPower(e.Location);
        }
    }
}
