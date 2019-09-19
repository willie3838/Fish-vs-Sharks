/*
 * Yasoob Ali, William Chan, Isaac Abdi, Roshan Nantha
 * January 21st, 2019
 * This is the abstract parent class for the RegularShark class as well as the Hammerhead class, which are each different types of sharks
 * 
 * CONTRIBUTIONS
 * ________________________________________________
 * 
    William: 

    Methods
    _______________________________

    Fish constructor, CreateFish

    Variables and their sets/get
    _______________________________
    currentHealth, maximumhealth, flopStartTime


    Roshan:

    Methods
    _______________________________

    CanSpit


    Isaac: 

    Methods
    ______________________________
    GetFishLocation

    Variables and their sets/get
    _______________________________
    unitType, requiredWaterPower


    Yasoob:

    Methods
    ____________________________
    GetAttacked

    Variables and their sets/get
    _____________________________
    fishImage, hitBox

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FishvsSharks
{
    abstract class Fish
    {
        // protected integers used to store the fish's current and maximum health
        protected int currentHealth, maximumHealth;

        // protected string used to the store the fish's unit type
        protected string unitType;

        // protected integer used to store the required waterpower to create a fish
        protected int requiredWaterPower;

        // protected integer used to store when a flop fish is created which is used to time when it generates waterpower
        protected int flopStartTime;

        // protected Image used to store the fish's image
        protected Image fishImage;
        // protected Rectangle used to store the fish's hitBox
        protected Rectangle hitBox;

        // private integer used to store the last time fish spitter spat
        private int timeSpitted = 0;

        // An Abstract fish method used to create fish
        public abstract Fish CreateFish();

        /// <summary>
        /// Fish Constructor that takes in the unit type, current health, maximum health, and required waterpower
        /// as parametes
        /// </summary>
        /// <param name="unitType">Takes in what type of unit the fish will be.</param>
        /// <param name="currentHealth">Takes in the amount of current health the fish will have.</param>
        /// <param name="maximumHealth">Takes in the amount of max health the fish will have.</param>
        /// <param name="requiredWaterPower">Takes in the required amount of water power needed to spawn fish.</param>
        public Fish(string unitType, int currentHealth, int maximumHealth, int requiredWaterPower)
        {
            // sets the fish's unit type to the given unit type
            this.unitType = unitType;
            // sets the fish's maximum health to the given maximum health
            this.maximumHealth = maximumHealth;
            // sets the fish's current health to the given current health
            this.CurrentHealth = currentHealth;
            // sets the fish's required waterpower to the given required waterpower
            this.requiredWaterPower = requiredWaterPower;


            // If the type of unit that spawns is a flopfish, records the time that it spawns
            if (unitType == FlopFish.UNIT_TYPE)
            {
                flopStartTime = Environment.TickCount;
            }

        }

        /// <summary>
        /// Get the integer for the time that the flop fish is spawned
        /// </summary>
        public int FlopFishStartTime
        {
            get { return flopStartTime; }
        }

        /// <summary>
        /// Get the string for the fish's unit type
        /// </summary>
        public string UnitType
        {
            get { return unitType; }
        }

        /// <summary>
        /// Get the rectangle for the fish's hit box
        /// </summary>
        public Rectangle HitBox
        {
            get { return hitBox; }
        }

        /// <summary>
        /// Get the image for the fish's image
        /// </summary>
        public Image FishImage
        {
            get { return fishImage; }
        }

        /// <summary>
        /// Get the integer for the fish's required waterpower
        /// </summary>
        public int RequiredWaterPower
        {
            get { return requiredWaterPower; }
        }


        /// <summary>
        /// Get the integer for the time a spit was launched
        /// </summary>
        public int TimeSpitted
        {
            get { return timeSpitted; }
        }


        /// <summary>
        /// Boolean function that checks if the fish spitter can spit
        /// </summary>
        /// <param name="fish">Takes in the fish spitter that wants to spit</param>
        /// <returns>Returns true if it can spit or false if it can't spit</returns>
        public bool CanSpit(Fish fish)
        {
            //If the time since the fish spitter last spat is more than 1 second and the fish's type is a fish spitter
            if (Environment.TickCount - timeSpitted >= 1000 && fish.unitType == FishSpitter.UNIT_TYPE)
            {
                //Make timeSpitted equal the current time
                timeSpitted = Environment.TickCount;

                //Return true
                return true;
            }

            //If it can't spit then return false
            return false;
        }


        /// <summary>
        /// Method that gets the location of fish spitter on the grid
        /// </summary>
        /// <param name="manager">Takes in the GameManger class as a parameter</param>
        /// <param name="frm">Takes in the Gameform as a parameter</param>
        public void GetFishLocation(GameManager manager, GameForm frm, int col, int row)
        {
            //Get a 2D array of the grid by using the GetAllFishGrid() method in the GameForm
            Rectangle[,] grid = frm.GetAllFishGrid();

            //Get a 2D array of the fishes by using the GetAllFish() method in the GameManager
            Fish[,] fishes = manager.GetAllFish();

            // MAKING NESTED FOR LOOPS TO LOOP THROUGH THE 2D GRID TO FIND FISH SPITTERS AND IF
            // THEY CAN SPIT
            for (int j = 0; j < GameForm.GRID_SIZE_COLUMNS; j++)
            {
                for (int k = 0; k < GameForm.GRID_SIZE_ROWS; k++)
                {
                    if (j == col && k == row)
                    {
                        //If the fish is a fish spitter and it is able to spit
                        if (fishes[j, k].UnitType == FishSpitter.UNIT_TYPE && manager.CheckFishCanSpit(fishes[j, k]) == true)
                        {
                            //Change the location of the original fish spitter on the 2D array to equal
                            //the location of the fish spitter on the copy of the 2D array
                            manager.GetRealFish[j, k].hitBox.Location = fishes[j, k].hitBox.Location;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// A method that causes the fish to lose X amount of health depending on the type of shark type that attacks it
        /// </summary>
        /// <param name="unitType">Takes in the type of shark it is being attacked by in order to determine damage</param>
        public void GetAttacked(string unitType)
        {
            // If attacked by regular shark, loses 2 HP from currentHealth
            if (unitType == RegularShark.UNIT_TYPE)
            {
                this.CurrentHealth -= 2;
            }
            // If attacked by a hammerhead shark, loses 3 HP from currentHealth
            else if (unitType == Hammerhead.UNIT_TYPE)
            {
                this.CurrentHealth -= 3;
            }
        }


        /// <summary>
        /// Method that resets the start time of the flop fish. Used when waterpower is spawned.
        /// </summary>
        public void ResetFlopTime()
        {
            this.flopStartTime = Environment.TickCount;
        }

        /// <summary>
        /// Method that assigns a hitbox for all the fish on the grid.
        /// </summary>
        /// <param name="manager">Takes in the gameManager as a parameter in order to get allfish</param>
        /// <param name="frm">Takes in the gameform as a paramter in order to access grid.</param>
        public void SetHitBox(GameManager manager, GameForm frm)
        {
            // Create 2 new 2D-arrays for fish and grid using the GetAllFish() method from the GameManager
            // and GetAllFishGrid() from the GameForm
            Fish[,] fish = manager.GetAllFish();
            Rectangle[,] grid = frm.GetAllFishGrid();

            // MAKES A NESTED FOR LOOP TO LOOP THROUGH THE 2D GRID AND CHECKS IF THE FISH ON THE GRID IS THE CURRENT FISH USING THIS METHOD 
            for (int j = 0; j < GameForm.GRID_SIZE_COLUMNS; j++)
            {
                for (int k = 0; k < GameForm.GRID_SIZE_ROWS; k++)
                {
                    // If the fish found is the fish using this method
                    if (fish[j, k] == this)
                    {
                        // set the x and y locations of the fish's hitbox to the grid's x and y locations
                        this.hitBox = new Rectangle(grid[j, k].Location.X, grid[j, k].Location.Y, 100, 100);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the integer for the fish's current health
        /// </summary>
        public int CurrentHealth
        {
            get { return currentHealth; }
            private set
            {
                // cannot allow negative health
                if (value < 0)
                {
                    currentHealth = 0;
                }
                // cannot allow health higher than the maximum
                else if (value > maximumHealth)
                {
                    currentHealth = maximumHealth;
                }
                // a health between 0 and the maximum is being assigned
                else
                {
                    currentHealth = value;
                }

            }
        }
    }
}
