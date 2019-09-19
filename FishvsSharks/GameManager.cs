/*
 * Yasoob Ali, William Chan, Isaac Abdi, Roshan Nantha
 * January 21st, 2019
 * This is the GameManager class that manages the fish, user, sharks, and waterpower
 * 
 * CONTRIBUTIONS
 * ________________________________________________
 * 
    Isaac: 

    Methods
    ____________________________________

    GameManager constructor, GenerateWaterPower, GetAllWaterPower, RemoveWaterPower, GetGrid, PuffExplosion, GameOver

    Variables and their sets/gets
    __________________________________

    rows, column, Fish[,] fish, puffExplosionStatus, puffRow, puffCol


    William: 

    Methods
    _____________________

    FlopGenerateWaterPower, GetAllSharks, Save points, RemoveFish, StarExplosion, EraseExplosions, FishCreator, Update


    Variables and their sets/get
    ____________________

    Fish[] fishFactory, List<Waterpower> waterPower, startExplosionStatus, starRow, starColumn


    Yasoob: 

    Methods
    __________________________

    CollisionDetection, GetAllFish, Save Level, RemoveShark, OctopusExplosion, AddSharks, SharkAttackMovement, FishFactory


    Variables and their sets/get
    ____________________________

    List<Sharks> shark, octExplosionStatus, octRow, octCol, level


    Roshan: 

    Methods
    _____________________________

    AddSpit, MoveSpit, RemoveSpitOutofBounds, RemoveSpit, CheckSpitHitShark, CheckFishCanSpit, GetReaFish,
    SalmonBombExplosion

    Variables and their sets/get
    _________________________
    salmonBombExplosionStatus, salmonRow, salmonColumn, point, lives


 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace FishvsSharks
{
    class GameManager
    {
        // A private integer that stores the amount of waterpower the player currently has. Value starts at 3 because the player gets some to start the game with.
        private int waterPowerCounter = 3;

        // A private fish array will be used to store all the possible types of fish
        private Fish[] fishFactory;
        // a private integer that stores the number of rows and columns on the grid
        private int rows, columns;
        // a fish 2d array that consists of the fish on the island
        private Fish[,] fish;

        // a private list that stores all waterpower objects in the game
        private List<Waterpower> waterPower = new List<Waterpower>();
        // a private list that stores all shark objects in the game
        private List<Sharks> shark = new List<Sharks>();

        //A private boolean to store the status of whether a starfish explosion is occuring or not. 
        private bool starExplosionStatus = false;
        // a private integer used to store the star's current row and column
        private int starRow, starColumn;

        // a private boolean to store the status of the salmon bomb (checks if the user has used it or not)
        private bool salmonBombExplosionStatus = false;
        // a private integer used to store the salmon's current row and column
        private int salmonRow, salmonColumn;

        // a private boolean to store the status of whether a pufferfish explosion is occuring or not. 
        private bool puffExplosionStatus = false;
        // a private integer used to store the pufferfish's current row and column
        private int puffRow, puffCol;

        // a private boolean to store the status of whether an octopus explosion is occuring or not. 
        private bool octExplosionStatus = false;
        // a private integer used to store the octopus' current row and column
        private int octRow, octCol;

        // a private boolean used to store the status of when or not to increase the spawn rate of the sharks
        private bool increaseSpawnRate = false;

        // private integers used to store the user's level which starts at 1, points which starts at 0, and lives which starts at 3
        private int level = 1, points = 0, lives = 3;


        // a private list that stores all spit objects on the grid
        private List<Spit> spit = new List<Spit>();

        // a private integer used to store the time passed in the timer
        private int tmr;

        /// <summary>
        /// GameManager constructor that takes in the columns and rows as parameters. 
        /// It also initializes the fishFactor array, the fish 2D array, and sets all grid points to water
        /// </summary>
        /// <param name="columns">Takes in the number of columns the game grid will have.</param>
        /// <param name="rows">Takes in the number of rows the game grid will have.</param>
        public GameManager(int columns, int rows)
        {
            // makes a fish array with a size of 7
            fishFactory = new Fish[7];
            // sets the first index to a FlopFish object
            fishFactory[0] = new FlopFish();
            // sets the second index to a FishSpitter object
            fishFactory[1] = new FishSpitter();
            // sets the third index to a FishEgg object
            fishFactory[2] = new FishEgg();
            // sets the fourth index to a Pufferfish object
            fishFactory[3] = new Pufferfish();
            // sets the fifth index to an Octopus object
            fishFactory[4] = new Octopus();
            // sets the sixth index to a Starfish object
            fishFactory[5] = new Starfish();
            // sets the seventh index to a SalmonBomb object
            fishFactory[6] = new SalmonBomb();

            // initializes a 2d array named fish with the given columns and rows
            fish = new Fish[columns, rows];

            // sets the columns to the given columns
            this.columns = columns;
            // sets the rows to the given rows
            this.rows = rows;

            // Initialize all the grid points to water 
            for (int j = 0; j < columns; j++)
            {
                for (int k = 0; k < rows; k++)
                {
                    fish[j, k] = new Water();
                }
            }
        }

        /// <summary>
        /// Gets the integer for the grid's number of rows
        /// </summary>
        public int Rows
        {
            get { return rows; }
        }

        /// <summary>
        /// Gets the integer for the grid's number of columns
        /// </summary>
        public int Columns
        {
            get { return columns; }
        }

        /// <summary>
        /// Gets the integer for the user's number of points
        /// </summary>
        public int Points
        {
            get { return points; }
        }

        /// <summary>
        /// Gets the integer for the user's level
        /// </summary>
        public int Level
        {
            get { return level; }
        }

        /// <summary>
        /// Gets the integer for the user's lives
        /// </summary>
        public int Lives
        {
            get { return lives; }

            private set
            {
                // cannot allow negative lives
                if (value < 0)
                {
                    lives = 0;
                }
                // life between 0 and the maximum is being assigned
                else
                {
                    lives = value;
                }

            }
        }

        /// <summary>
        /// Gets the 2d array for Fish that stores all the fish on the grid
        /// </summary>
        public Fish[,] GetRealFish
        {
            get { return fish; }
        }

        /// <summary>
        /// Gets the integer that stores the amount of waterpower the user has
        /// </summary>
        public int WaterPowerCounter
        {
            get { return waterPowerCounter; }
        }

        /// <summary>
        /// Gets the integer that stores the starfish's current row
        /// </summary>
        public int StarRow
        {
            get { return starRow; }
        }

        /// <summary>
        /// Gets the integer that stores the starfish's current column
        /// </summary>
        public int StarColumn
        {
            get { return starColumn; }
        }

        /// <summary>
        /// Gets the boolean that stores the starfish's explosion status
        /// </summary>
        public bool StarExplosionStatus
        {
            get { return starExplosionStatus; }
        }

        /// <summary>
        /// Gets the boolean that stores the salmon bomb's explosion status
        /// </summary>
        public bool SalmonBombExplosionStatus
        {
            get { return salmonBombExplosionStatus; }
        }

        /// <summary>
        /// Gets the integer that stores the salmon bomb's current row
        /// </summary>
        public int SalmonRow
        {
            get { return salmonRow; }
        }

        /// <summary>
        /// Gets the integer that stores the salmon bomb's current column
        /// </summary>
        public int SalmonColumn
        {
            get { return salmonColumn; }
        }

        /// <summary>
        /// Get the integer that stores the pufferfish's current row
        /// </summary>
        public int PuffRow
        {
            get { return puffRow; }
        }

        /// <summary>
        /// Get the integer that stores the pufferfish's current column
        /// </summary>
        public int PuffCol
        {
            get { return puffCol; }
        }

        /// <summary>
        /// Get the boolean that stores the pufferfish's explosion status
        /// </summary>
        public bool PuffExplosionStatus
        {
            get { return puffExplosionStatus; }
        }

        /// <summary>
        /// Get the integer that stores the octopus' current row
        /// </summary>
        public int OctRow
        {
            get { return octRow; }
        }

        /// <summary>
        /// Get the integer that stores the octupus' current column
        /// </summary>
        public int OctCol
        {
            get { return octCol; }
        }

        /// <summary>
        /// Get the boolean that stores the octopus' explosion status
        /// </summary>
        public bool OctExplosionStatus
        {
            get { return octExplosionStatus; }
        }

        /// <summary>
        /// Get the boolean that stores whether or not the spawn rate should be increases
        /// </summary>
        public bool IncreaseSpawnRate
        {
            get { return increaseSpawnRate; }
        }

        /// <summary>
        /// A method that generates waterpower at random locations on the grid 
        /// </summary>
        /// <param name="x">Random X location.</param>
        /// <param name="y">Random Y location</param>
        public void GenerateWaterPower(int x, int y)
        {
            // Adds a new waterpower to the list
            waterPower.Add(new Waterpower(x, y));
        }

        /// <summary>
        /// A method that generates waterpower which are generate by flop fish
        /// </summary>
        public void FlopGenerateWaterPower()
        {
            // MAKING A NESTED FOR LOOP TO LOOP THROUGH THE GRID TO FIND A FLOP FISH
            for (int j = 0; j < columns; j++)
            {
                for (int k = 0; k < rows; k++)
                {
                    // if the current location is a flop fish, and it has been equal to or over 5 seconds since it has spawned/generated water power
                    if (fish[j, k].UnitType == FlopFish.UNIT_TYPE && Environment.TickCount - fish[j, k].FlopFishStartTime >= 5000)
                    {
                        // generate waterpower at the flop fish's given location
                        GenerateWaterPower(fish[j, k].HitBox.Location.X, fish[j, k].HitBox.Location.Y);
                        // Resets flopTime in order to add delay between waterpower generation
                        fish[j, k].ResetFlopTime();
                    }
                }
            }
        }


        /// <summary>
        /// A List<Spit> method that duplicates the manager's current list for all spit objects and returns copy
        /// </summary>
        /// <returns>Returns the list of spit</returns>
        public List<Spit> GetAllSpit()
        {
            //Create a shallow copy of the spit list 
            List<Spit> allSpit = new List<Spit>();

            //Copy all the spit from the original list into the shallow copy
            for (int i = 0; i < spit.Count; i++)
            {
                allSpit.Add(spit[i]);
            }

            //Return the copied list of spit
            return allSpit;
        }


        /// <summary>
        /// A method that adds the spit to the spit list 
        /// </summary>
        /// <param name="fishSpitterLocation">The location of the fish spitter that is using the current spit</param>
        public void AddSpit(Point fishSpitterLocation)
        {
            //Add the spit with the location of the fish spitter that's using it 
            spit.Add(new Spit(fishSpitterLocation.X + GameForm.CELL_SIZE / 2, fishSpitterLocation.Y + GameForm.CELL_SIZE / 2));

        }


        /// <summary>
        /// A method that moves the spit
        /// </summary>
        public void MoveSpit()
        {
            //Loops through all the spit in the spit list
            for (int i = 0; i < spit.Count; i++)
            {
                //Move the spit right by sending it as a parameter to MoveSpit in the Spit class
                spit[i].MoveSpit(spit[i]);
            }
        }


        /// <summary>
        /// A method that removes the spit when it goes over the grid
        /// </summary>
        public void RemoveSpitOutOfBounds(GameForm frm)
        {
            //Loop through the spit list
            for (int i = 0; i < spit.Count; i++)
            {
                //If the spit is greater or equal than the GameForm's width
                if (spit[i].SpitHitBox.X >= GameForm.CELL_SIZE * 7 - Spit.SPIT_WIDTH)
                {
                    //Remove the spit
                    spit.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// A method that removes spit
        /// </summary>
        /// <param name="k">The index the spit has to be removed at</param>
        public void RemoveSpit(int k)
        {
            //Loop through the spit list
            for (int i = 0; i < spit.Count; i++)
            {
                //If the index matches the removed spit's index
                if (i == k)
                {
                    //Remove the spit
                    spit.RemoveAt(i);
                }
            }
        }


        /// <summary>
        /// A boolean function that checks if the spit hit a shark
        /// </summary>
        /// <returns>returns true if the spit intersects with a shark</returns>
        public bool CheckSpitHitShark()
        {
            // MAKING A FOR LOOP TO LOOP THROUGH THE SPIT LIST
            for (int i = 0; i < spit.Count; i++)
            { 
                // MAKING A FOR LOOP TO LOOP THROUGH THE SHARK LIST
                for (int j = 0; j < shark.Count; j++)
                {
                    //If the spit intersects with the shark
                    if (spit[i].SpitHitBox.IntersectsWith(shark[j].Hitbox))
                    {
                        //The shark gets attacked by the spit
                        shark[j].GetAttackedBySpit(shark[j]);

                        //Remove the spit
                        RemoveSpit(i);

                        //Return true
                        return true;
                    }
                }
            }

            //Return false if no spit has hit the shark
            return false;
        }


        /// <summary>
        /// A boolean function that checks if the fish is able to spit
        /// </summary>
        /// <param name="fish">Takes in the fish that wants to spit as a parameter</param>
        /// <returns>Returns true if the fish can spit or false if it can't spit</returns>
        public bool CheckFishCanSpit(Fish fish)
        {
            //If the fish can spit (if the CanSpit function in the Fish class returns true)
            if (fish.CanSpit(fish) == true)
            {
                //Return true
                return true;
            }

            //If the fish can't spit return false
            return false;
        }


        /// <summary>
        /// A method that detectc if the shark has collided with any fish on the screen.
        /// </summary>
        public void CollisionDetection()
        {
            // MAKES A FOR LOOP TO LOOP THROUGH THE COLUMNS ON THE GRID
            for (int i = 0; i < columns; i++)
            {
                // MAKES A FOR LOOP TO LOOP THROUGH THE ROWS ON THE GRID
                for (int j = 0; j < rows; j++)
                {
                    // MAKES A FOR LOOP TO LOOP THROUGH THE SHRLAS LIST
                    for (int z = 0; z < shark.Count; z++)
                    {

                        // If it finds any fish that have their hitbox intersecting with a shark's hitbox, it will set that shark's collide status to be equal to true.
                        if (fish[i, j].HitBox.IntersectsWith(shark[z].Hitbox))
                        {
                            shark[z].SetCollide(true);
                        }

                    }

                }
            }
        }


        /// <summary>
        /// A List<Sharks> function that creates a copy of the shark list and returns the copy
        /// </summary>
        /// <returns></returns>
        public List<Sharks> GetAllSharks()
        {
            // Creates a shallow copy of the sharks list
            List<Sharks> allSharks = new List<Sharks>();

            // Adds all sharks on previous list called shark to new list called allSharks and returns that.
            for (int i = 0; i < shark.Count; i++)
            {
                allSharks.Add(shark[i]);
            }

            return allSharks;
        }

        /// <summary>
        /// A Fish[,] function that creates a copy of the current 2d array for fish and returns it
        /// </summary>
        /// <returns></returns>
        public Fish[,] GetAllFish()
        {
            // Creates a shallow copy of the 2d array fish
            Fish[,] allFish = new Fish[columns, rows];

            // Adds all fish on previous 2d array to the new 2d array called all allFish. 
            // Does this by using a nested for-loop to cycle through all the columns and rows in the grid to locate all fish.
            for (int j = 0; j < columns; j++)
            {
                for (int k = 0; k < rows; k++)
                {
                    allFish[j, k] = fish[j, k];
                }
            }

            return allFish;
        }

        /// <summary>
        /// A List<Waterpower> function that creates a copy of the waterpower list and returns a copy
        /// </summary>
        /// <returns></returns>
        public List<Waterpower> GetAllWaterPower()
        {
            // Creates a shallow copy of the waterpower list
            List<Waterpower> allWaterPower = new List<Waterpower>();

            // Adds all waterPower from previous list to new 'allWaterPower' list and returns it.
            for (int i = 0; i < waterPower.Count; i++)
            {
                allWaterPower.Add(waterPower[i]);
            }

            return allWaterPower;
        }


        /// <summary>
        /// A method that removes water power from the map once the user clicks on it.
        /// </summary>
        /// <param name="mouseLocation"></param>
        public void RemoveWaterPower(Point mouseLocation)
        {
            // MAKES A FOR LOOP THAT LOOPS THROUGH THE WATERPOWER LIST
            for (int i = 0; i < waterPower.Count; i++)
            {
                // if the waterpower is clicked by the user
                if (waterPower[i].HitBox.Contains(mouseLocation))
                {
                    // remove the waterpower from the grid
                    waterPower.Remove(waterPower[i]);
                    // add one waterpower to the user's inventory
                    waterPowerCounter++;
                }
            }
        }

        /// <summary>
        /// A method used to save how many points and what level the user was on before losing the game.
        /// </summary>
        public void SavePointsAndLevel()
        {
            // attempts this code first
            try
            {
                ///////////////// WILLIAM //////////////////////
                // save the file into the file Point.txt
                using (StreamWriter file = new StreamWriter("Points.txt"))
                {
                    // output the points variable into the file
                    file.Write(points);
                }
                /////////////// YASOOB //////////////////////////////
                // save the file into the name the user chose
                using (StreamWriter file = new StreamWriter("Level.txt"))
                {
                    // output the level variable into the file
                    file.Write(level);
                }
            }
            // runs this code if there is an error
            catch (Exception)
            {
                return;
            }
        }

        /// <summary>
        /// A method that removes fish if they are killed
        /// </summary>
        public void RemoveFish()
        {
            // MAKES A NESTED FOR LOOP TO LOOP THROUGH THE 2D ARRAY THAT CONTAINS ALL THE FRIST
            for (int j = 0; j < columns; j++)
            {
                for (int k = 0; k < rows; k++)
                {
                    // if the fish's current health is less than or equal to 0 and it is not water
                    if (fish[j, k].CurrentHealth <= 0 && fish[j, k].UnitType != Water.UNIT_TYPE)
                    {
                        // change it to water as the fish has died
                        fish[j, k] = new Water();
                    }
                }
            }
        }

        /// <summary>
        /// A method that removes sharks if they are killed.
        /// </summary>
        public void RemoveShark()
        {
            // MAKES A FOR LOOP TO LOOP THROUGH THE SHARKS LIST
            for (int i = 0; i < shark.Count; i++)
            {
                // if the shark has a current health that is less than or equal to 0
                if (shark[i].CurrentHealth <= 0)
                {
                    // remove the shark
                    shark.Remove(shark[i]);
                    // increase the player's points by 1
                    points++;

                    // After the player reaches 5 points, sharks will spawn at an increaes spawn rate.
                    // The level also increases when this happens
                    if (points % 5 == 0 && points != 0)
                    {
                        // increase the player's level by 1
                        level++;
                        // make increase spawn rate true
                        increaseSpawnRate = true;
                    }
                }
            }


        }

        /// <summary>
        /// A Fish function that takes in the columns and rows of the grid as parameters and checks to see if
        /// they match the given grid
        /// </summary>
        /// <param name="col">Takes in the grid column.</param>
        /// <param name="row">Takes in the grid row.</param>
        /// <returns></returns>
        public Fish GetGrid(int col, int row)
        {
            // make sure that the row and col are valid
            if (row >= 0 && row < rows && col >= 0 && col < columns)
            {
                return fish[col, row];
            }

            // if the parameters are invalid, return null
            return null;
        }

        /// <summary>
        /// A method that checks if the user dropped a starfish bomb.
        /// </summary>
        /// <param name="fishType">Takes in the fish type.</param>
        /// <param name="row">Takes in the row number.</param>
        /// <param name="col">Takes in the column number.</param>
        public void StarExplosion(Fish fishType, int row, int col)
        {
            // if the unit type is a starfish
            if (fishType.UnitType == Starfish.UNIT_TYPE)
            {
                // set the explosion status to true
                starExplosionStatus = true;
                // store the starfish's current row
                starRow = row;
                // store the starfish's current column
                starColumn = col;

            }
        }

        /// <summary>
        /// A method that checks if the user dropped a pufferfish bomb.
        /// </summary>
        /// <param name="fishType">Takes in the fish type.</param>
        /// <param name="row">Takes in the row number.</param>
        /// <param name="col">Takes in the column number.</param>
        public void PuffExplosion(Fish fishType, int row, int col)
        {
            // if the unit type is a pufferfish
            if (fishType.UnitType == Pufferfish.UNIT_TYPE)
            {
                // set the explosion status to true
                puffExplosionStatus = true;
                // store the pufferfish's current row
                puffRow = row;
                // store the pufferfish's current column
                puffCol = col;
            }
        }

        /// <summary>
        /// A method that checks if the user dropped a octopus bomb.
        /// </summary>
        /// <param name="fishType">Takes in the fish type.</param>
        /// <param name="row">Takes in the row number.</param>
        /// <param name="col">Takes in the column number.</param>
        public void OctopusExplosion(Fish fishType, int row, int col)
        {

            // if the unit type is an octopus
            if (fishType.UnitType == Octopus.UNIT_TYPE)
            {
                // set the explosion status to true
                octExplosionStatus = true;
                // store the octopus' current row
                octRow = row;
                // store the octopus' current column
                octCol = col;
            }
        }

        /// <summary>
        /// A method that checks if the user dropped a salmon bomb
        /// </summary>
        /// <param name="fishType">The type of fish</param>
        /// <param name="row">The row the user dropped the salmon bomb </param>
        /// <param name="col">The column the user dropped the salmon bomb</param>
        public void SalmonBombExplosion(Fish fishType, int row, int col)
        {
            // if the unit type is a salmon bomb
            if (fishType.UnitType == SalmonBomb.UNIT_TYPE)
            {
                // set the explosion status to true
                salmonBombExplosionStatus = true;

                // store the salmon bomb's current row
                salmonRow = row;

                // store the salmon bom's current column
                salmonColumn = col;
            }
        }


        /// <summary>
        /// A boolean function taht removes explosions from the grid once the explosion has finished.
        /// </summary>
        /// <param name="frm">Takes in the Gameform.</param>
        /// <returns>returns true if the an explosion has occured and it has been past or equal to 500 milliseconds, otherwise return false</returns>
        public bool EraseExplosions(GameForm frm)
        {

            // If the time passed after an explosion is greater than or equal to 500 milliseconds and the starfish's explosion status is true
            if (Environment.TickCount - frm.StarExplosionStartTime >= 500 && starExplosionStatus == true)
            {
                // set the star's explosion status to false
                starExplosionStatus = false;
                // return true;
                return true;
            }
            // else if the time passed after an explosion is greater than or equal to 500 milliseconds and the salmon bomb's explosion status is true
            else if (Environment.TickCount - frm.SalmonBombExplosionStartTime >= 500 && salmonBombExplosionStatus == true)
            {
                // set the salmon bomb's explosion status to false
                salmonBombExplosionStatus = false;

                //Return true
                return true;
            }
            // else if the time passed after an explosion is greater than or equal to 500 milliseconds and the pufferfish's explosion status is true
            else if (Environment.TickCount - frm.PuffExplosionStartTime >= 500 && puffExplosionStatus == true)
            {
                // set the pufferfish's explosion status to false
                puffExplosionStatus = false;
                // return true;
                return true;
            }
            // else if the time passed after an explosion is greater than or equal to 500 milliseconds and the octopus' explosion status is true
            else if (Environment.TickCount - frm.OctExplosionStartTime >= 500 && octExplosionStatus == true)
            {
                // set the octopus' explosion status to false
                octExplosionStatus = false;
                // return true
                return true;
            }
            // return false
            return false;
        }


        /// <summary>
        /// A boolean function that creates fish once they are placed on the grid.
        /// </summary>
        /// <param name="row">Takes in the row number.</param>
        /// <param name="col">Takes in the column number.</param>
        /// <param name="type">Takes in the fish type.</param>
        /// <param name="frm">Takes in the gameform.</param>
        /// <returns>returns true if the fish object is not null, there is enough waterpower, and if the fish type is not water. Otherwise
        /// return false</returns>
        public bool FishCreator(int row, int col, int type, GameForm frm)
        {
            // makes a new fish object using the fish factory
            Fish newFish = FishFactory(type);

            // if the fish object is not null, the user has enough waterpower, and the current grid is water
            if (newFish != null && waterPowerCounter >= newFish.RequiredWaterPower && fish[col, row].UnitType == Water.UNIT_TYPE)
            {
                // create a fish on the grid's location
                fish[col, row] = newFish;
                // set a hitbox for it
                newFish.SetHitBox(this, frm);
                // check to see if it is a starfish
                StarExplosion(newFish, row, col);
                // check to see if it is a salmon bomb
                SalmonBombExplosion(newFish, row, col);
                // check to see if it is a pufferfish
                PuffExplosion(newFish, row, col);
                // check to see if it is an octopus
                OctopusExplosion(newFish, row, col);
                // subtract the fish's required waterpower fomr the user's total waterpower
                waterPowerCounter -= newFish.RequiredWaterPower;
                return true;
            }

            // return false if the fish could not be built
            return false;
        }

        /// <summary>
        /// A method that adds sharks to the map periodically.
        /// </summary>
        /// <param name="randomLocation">Takes in a random location for the shark's Y coordinate.</param>
        /// <param name="sharkType">Takes in the shark type.</param>
        public void AddSharks(int randomLocation, string sharkType)
        {
            // an integer used to set the shark's y coordinate
            int spawnZoneY = 0;

 
            // if the value is 0 set the y coordinate to 0
            if (randomLocation == 0)
            {
                spawnZoneY = 0;
            }
            // else if the value is 1 set the y coordinate to 100
            else if (randomLocation == 1)
            {
                spawnZoneY = 100;
            }
            // else if the value is 2 set the y coordinate to 200
            else if (randomLocation == 2)
            {
                spawnZoneY = 200;
            }
            // else if the value is 3 set the y coordinate to 300
            else if (randomLocation == 3)
            {
                spawnZoneY = 300;
            }

         
            // if the shark is a regular shark, add a regular shark to the list in its given location
            if (sharkType == RegularShark.UNIT_TYPE)
            {
                shark.Add(new RegularShark(700, spawnZoneY));
            }
            // else if the shark is a hammerhead, add a hammerhead to the list in its given location
            else if (sharkType == Hammerhead.UNIT_TYPE)
            {
                shark.Add(new Hammerhead(700, spawnZoneY));
            }

        }

        /// <summary>
        /// A boolean function to check if the game is over
        /// </summary>
        /// <returns>return true if the player's lives is 0, otherwise return false</returns>
        public bool GameOver()
        {
            // If the player reaches 0 lives, calls the SavePointsAndLevels function to save progress and exits them from the game.
            if (lives == 0)
            {
                SavePointsAndLevel();
                // returns true
                return true;
            }

            // Otherwise, return false
            return false;
        }

        /// <summary>
        /// A method that uses shark collision detection and controls the shark's movement when attacking the fish
        /// </summary>
        public void SharkAttackMovement()
        {
            // MAKES A FOR LOOP TO RUN THROUGH THE SHARKS LIST
            for (int i = 0; i < shark.Count; i++)
            {
                // If the shark is not colliding with any fish, calls the SharkMove subprogram in order to have the shark move left.
                if (shark[i].GetCollide == false)
                {
                    shark[i].SharkMove();
                }
                // If the shark is current colliding with a fish, it uses a nested for-loop to cycle through the entire grid to locate which fish are colliding with the shark.
                else if (shark[i].GetCollide == true)
                {
                    // MAKES A NESTED FOR LOOP TO RUN THROUGH THE GRID
                    for (int k = 0; k < columns; k++)
                    {
                        for (int j = 0; j < rows; j++)
                        {
                            // if the shark is intersecting with the fish and the tmr variable used to store the time for the shark's attack rate is divisible by 100
                            if (fish[k, j].HitBox.IntersectsWith(shark[i].Hitbox) && tmr % 100 == 0)
                            {
                                // make the fish lose health as the shark is attacking it
                                fish[k, j].GetAttacked(shark[i].UnitType);
                            }
                        }
                    }

                    // Sets the shark's collide status to be false. This is here in order to allow the shark to continue moving after killing a fish.
                    shark[i].SetCollide(false);
                }

                // If the shark leaves the screen, will kill the shark by removing it from the list
                if (shark[i].Hitbox.X <= 0)
                {
                    shark.RemoveAt(i);
                    // removes one life from the user
                    this.Lives--;
                }
            }
        }


        /// <summary>
        /// A Fish function used to create the different types of fish.
        /// </summary>
        /// <param name="type">Takes in the fish type.</param>
        /// <returns>return a fish object if the type is valid, otherwise return null</returns>
        private Fish FishFactory(int type)
        {
            // the type is greater than 0 and is less than the array length
            if (type >= 0 && type < fishFactory.Length)
            {
                // return the fish that is created
                return fishFactory[type].CreateFish();
            }
            // invalid type given
            return null;
        }

        /// <summary>
        /// A method that is responsible for numerous subprograms that should be constantly running. This is called in the timer.
        /// </summary>
        /// <param name="frm"></param>
        public void Update(GameForm frm)
        {
            // Increases every timer tick. 
            tmr++;

            // Calls the different subprograms that need to be constantly running.

            // checks for collision between the sharks and fish
            CollisionDetection();
            // controls the shark's movement when attacking
            SharkAttackMovement();
            // sets increase spawn rate to false
            increaseSpawnRate = false;
            // causes flop fish to generate waterpower
            FlopGenerateWaterPower();
            // moves the spit
            MoveSpit();
            // removes the spit when it is off the grid
            RemoveSpitOutOfBounds(frm);
            // checks if the spit hit a shark
            CheckSpitHitShark();
            // removes dead sharks
            RemoveShark();
            // removes dead fish
            RemoveFish();

        }


    }
}
