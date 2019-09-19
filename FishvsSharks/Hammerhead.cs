/*
 * Yasoob Ali, William Chan, Isaac Abdi, Roshan Nantha
 * January 21st, 2019
 * This is child class of the Shark and is used to set the properties of a Hammerhead
 * 
 * CONTRIBUTIONS
 * ________________________________________________
 * Isaac made all of this
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishvsSharks
{
    class Hammerhead : Sharks
    {
        // string constant that gives the unit type of the child class: "Hammerhead"
        public const string UNIT_TYPE = "Hammerhead";

        // integer constant for the Hammerhead's current health which is set to 5
        private const int CURRENT_HEALTH = 5;
        // integer constant for the Hammerhead's maximum health which is set to 5
        private const int MAXIMUM_HEALTH = 5;

        /// <summary>
        /// Hammerhead constructor that takes in x and y integers as parameters for its hitBox's location and
        /// passes in it's unit type, current health, maximum health, attack damage, x, and y as parameters
        /// to the Shark parent class. Moreover, it also sets the Hammerhead's image to a Hammerhead.
        /// </summary>
        /// <param name="x">the x coordinate of the hammerhead</param>
        /// <param name="y">the y coordinate of the hammerhead</param>
        public Hammerhead(int x, int y) : base(UNIT_TYPE, CURRENT_HEALTH, MAXIMUM_HEALTH, x, y)
        {
            // Sets the shark to have the hammerhead shark image
            sharkImage = Properties.Resources.Hammerhead;
        }
    }
}
