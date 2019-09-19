/*
 * Yasoob Ali, William Chan, Isaac Abdi, Roshan Nantha
 * January 21st, 2019
 * This is the child class of Fish and is used to set the properties of a salmon bomb
 * 
 * CONTRIBUTIONS
 * ________________________________________________
 * Roshan made all of this
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishvsSharks
{
    class SalmonBomb : Fish
    {
        // constant string used to set the salmon bomb's unit type to "Salmon Bomb"
        public const string UNIT_TYPE = "Salmon Bomb";
        // constant integer used to set the salmon bomb's current health to 0
        private const int CURRENT_HEALTH = 0;
        // constant integer used to set the salmon bomb's maximum health to 0
        private const int MAXIMUM_HEALTH = 0;
        // constant integer used to set the salmon bomb's required waterpower to 12
        private const int REQUIRED_WATERPOWER = 12;

        /// <summary>
        /// SalmonBomb constructor that passes in its unit type, current health, maximum health, and required waterpower
        /// as parameters to the Fish parent class and sets its image to a salmon
        /// </summary>
        public SalmonBomb() : base (UNIT_TYPE, CURRENT_HEALTH, MAXIMUM_HEALTH, REQUIRED_WATERPOWER)
        {
            fishImage = Properties.Resources.salmon;
        }

        /// <summary>
        /// Overrides the Fish's abstract CreateFish() method to create a salmon bomb
        /// </summary>
        /// <returns>returns a salmon bomb object</returns>
        public override Fish CreateFish()
        {
            // returns a salmon bomb object
            return new SalmonBomb();
        }
    }
}
