/*
 * Yasoob Ali, William Chan, Isaac Abdi, Roshan Nantha
 * January 21st, 2019
 * This is the parent class for the RegularShark class as well as the Hammerhead class, which are each different types of sharks
 * 
 * CONTRIBUTIONS
 * ________________________________________________
 * 
    William:

    Methods
    ____________________________
    SharkMove, SetCollide

    Variables and their sets/get
    ______________________________

    currentHealth, maximumHealth, unitType

    //////////////////////////////////////////////////////
    Roshan:

    Methods
    _____________________________
    GetAttackedBySpit

    Variables and their sets/get
    _____________________________
    LENGTH, WIDTH

    /////////////////////////////////////////////////////
    Isaac:

    Methods
    ______________________________
    GetExploded

    Variables and their sets/get
    ______________________________
    hitBox

    ///////////////////////////////////////////////////////
    Yasoob:

    Methods
    _____________________________
    Sharks constructor

    Variables and their sets/get
    ______________________________
    sharkImage, collide
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FishvsSharks
{
    class Sharks
    {

        // Declares protected integers that store the shark's current health, max health
        protected int currentHealth, maximumHealth;
        // protected string that stores the shark's unit type
        protected string unitType;

        // Declares protected image that store's the shark's image
        protected Image sharkImage;
        // Declares a protected rectangle named hitBox that store's the shark's location and gives it a width and length
        protected Rectangle hitBox;

        // Sets constant integers for the length and width of the sharks. This will be used for its hitbox size.
        private const int LENGTH = 100, WIDTH = 100;

        // The status of whether a shark is colliding with a fish or not. 
        private bool collide;

        /// <summary>
        /// Get the integer for currentHealth
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

        /// <summary>
        /// Get the rectangle for the shark's hitbox
        /// </summary>
        public Rectangle Hitbox
        {
            get { return hitBox; }
        }

        /// <summary>
        /// Get the Image for the shark's sharkImage
        /// </summary>
        public Image SharkImage
        {
            get { return sharkImage; }
        }

        /// <summary>
        /// Get the string for the shark's unit type
        /// </summary>
        public string UnitType
        {
            get { return unitType; }
        }

        /// <summary>
        /// Get the boolean for the shark's collide status
        /// </summary>
        public bool GetCollide
        {
            get { return collide; }
        }

        /// <summary>
        /// A method that sets the collision status of the shark. Will set it to either true or false.
        /// </summary>
        /// <param name="collideCheck">Inputs a boolean from where its called and this value will become the value of 'collide' in the shark class.</param>
        public void SetCollide(bool collideCheck)
        {
            // If the inputted value is true, collide is set to true
            if (collideCheck == true)
            {
                collide = true;
            }
            // If the inputted value is false, collide is set to false
            else
            {
                collide = false;
            }

        }

        /// <summary>
        /// Method used to reduce the shark's current health when hit by spit
        /// </summary>
        /// <param name="shark">The shark that is getting attacked by spit</param>
        public void GetAttackedBySpit(Sharks shark)
        {
            //The shark's current health is decreased by 2
            shark.CurrentHealth -= 2;
        }

        /// <summary>
        /// Method used to reduce the shark's current health to 0 when it comes in contact with an explosion
        /// </summary>
        public void GetExploded()
        {
            this.currentHealth = 0;
        }

        /// <summary>
        /// Function that allows the shark to move. Will constantly be running in the timer with the shark constantly moving left unless it collides with a fish or dies.
        /// </summary>
        public void SharkMove()
        {
            this.hitBox.X -= 2;
        }

        /// <summary>
        /// Shark constructor that takes in the string unitType, integer currentHealth, integer maximumHealth, 
        /// integer x, and integer y as parameters
        /// </summary>
        /// <param name="unitType">Takes in what unit type the shark will be.</param>
        /// <param name="currentHealth">Takes in the amount of current health the shark will have.</param>
        /// <param name="maximumHealth">Takes in the amount of max health the shark will have.</param>
        /// <param name="x">Takes in the starting X coordinate of the shark.</param>
        /// <param name="y">Takes in the starting Y coordinate of the shark.</param>
        public Sharks(string unitType, int currentHealth, int maximumHealth, int x, int y)
        {
            // sets the shark's hitBox to the given location at x and y, and sets the shark's width and length
            hitBox = new Rectangle(x, y, WIDTH, LENGTH);
            // sets the shark's unitType to the given unitType
            this.unitType = unitType;
            // sets the shark's maximumHealth to the given maximumHealth
            this.maximumHealth = maximumHealth;
            // sets the shark's CurrentHealth to the given currentHealth
            this.CurrentHealth = currentHealth;
        }
    }

}