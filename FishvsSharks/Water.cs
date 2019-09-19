/*
 * Yasoob Ali, William Chan, Isaac Abdi, Roshan Nantha
 * January 21st, 2019
 * This is the child class of Fish and is used to set the properties of water
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
    class Water : Fish
    {
        // constant string used to set the water's unit type to "Water"
        public const string UNIT_TYPE = "Water";
        // constant integer used to set the water's current health to 0
        private const int CURRENT_HEALTH = 0;
        // constant integer used to set the water's maximum health to 0
        private const int MAXIMUM_HEALTH = 0;
        // constant integer used to set the water's required waterpower to 0
        private const int REQUIRED_WATERPOWER = 0;

        /// <summary>
        /// Water constructor that passes in its unit type, current health, maximum health, and required waterpower
        /// as parameters to the Fish parent class and sets its image to water
        /// </summary>
        public Water() : base(UNIT_TYPE, CURRENT_HEALTH, MAXIMUM_HEALTH, REQUIRED_WATERPOWER)
        {
            fishImage = Properties.Resources.water;
        }

        /// <summary>
        /// Overrides the Fish's abstract CreateFish() method to create water
        /// </summary>
        /// <returns>returns a water object</returns>
        public override Fish CreateFish()
        {
            // returns a water object
            return new Water();
        }
    }
}
