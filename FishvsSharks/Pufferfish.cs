/*
 * Yasoob Ali, William Chan, Isaac Abdi, Roshan Nantha
 * January 21st, 2019
 * This is the child class of Fish and is used to set the properties of a pufferfish
 * 
 * CONTRIBUTIONS
 * ________________________________________________
 * Isaac made all of this
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FishvsSharks
{
    class Pufferfish : Fish
    {
        // constant string used to set the pufferfish's unit type to "Pufferfish
        public const string UNIT_TYPE = "Pufferfish";

        // constant integer used to set the pufferfish's current health to 0
        private const int CURRENT_HEALTH = 0;

        // constant integer used to set the pufferfish's maximum health to 0
        private const int MAXIMUM_HEALTH = 0;

        // constant integer used to set the pufferfish's required waterpower to 0
        private const int REQUIRED_WATERPOWER = 5;

        /// <summary>
        /// Pufferfish constructor that passes in its unit type, current health, maximum health, and required waterpower
        /// as parameters to the Fish parent class and sets its iamge to a pufferfish image
        /// </summary>
        public Pufferfish() : base(UNIT_TYPE, CURRENT_HEALTH, MAXIMUM_HEALTH, REQUIRED_WATERPOWER)
        {
            // sets the pufferfishes image
            fishImage = Properties.Resources.pufferfish;
        }

        /// <summary>
        ///  Overrides the Fish's abstract CreateFish() method to create a pufferfish
        /// </summary>
        /// <returns>returns a pufferfish object</returns>
        public override Fish CreateFish()
        {
            // returns a pufferfish object
            return new Pufferfish();
        }
    }
}
