/*
 * Yasoob Ali, William Chan, Isaac Abdi, Roshan Nantha
 * January 21st, 2019
 * This is the child class of Fish and is used to set the properties of a starfish
 * 
 * CONTRIBUTIONS
 * ________________________________________________
 * William made all of this
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FishvsSharks
{
    class Starfish : Fish
    {
        // constant string that sets the starfish's unit type to Starfish
        public const string UNIT_TYPE = "Starfish";

        // constant integer that sets the starfish's current health to 0
        private const int CURRENT_HEALTH = 0;

        // constant integer that sets the starfish's maximum health to 0
        private const int MAXIMUM_HEALTH = 0;

        // constant integer that sets the starfish's required waterpower to 7
        private const int REQUIRED_WATERPOWER = 7;

        /// <summary>
        /// Starfish constructor that passes on the starfish's unit type, current health, maximum health, and required waterpower
        /// to the Fish parent class' constructor and sets the starfish's image to a starfish
        /// </summary>
        public Starfish() : base(UNIT_TYPE, CURRENT_HEALTH, MAXIMUM_HEALTH, REQUIRED_WATERPOWER)
        {
            //Fish image is the starfish file in resources
            fishImage = Properties.Resources.starfish;
        }

        /// <summary>
        /// Overrides the Fish's abstract CreateFish() method to create a starfish
        /// </summary>
        /// <returns>returns a starfish object</returns>
        public override Fish CreateFish()
        {
            //Returns the starfish
            return new Starfish();
        }

    }
}
