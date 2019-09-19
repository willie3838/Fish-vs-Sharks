/*
 * Yasoob Ali, William Chan, Isaac Abdi, Roshan Nantha
 * January 21st, 2019
 * This is the child class of Fish and is used to set the properties of an octopus
 * 
 * CONTRIBUTIONS
 * ________________________________________________
 * Yasoob made all of this
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FishvsSharks
{
    class Octopus : Fish
    {
        // A constant string that sets the octupus' unit type which is "Octopus"
        public const string UNIT_TYPE = "Octopus";

        //  A constant integer that sets the octopus' current health which is 0
        private const int CURRENT_HEALTH = 0;

        //  A constant integer that sets the octopus' maximum health which is 0
        private const int MAXIMUM_HEALTH = 0;

        // A constant integer that sets the octopus' required waterpower which is 5
        private const int REQUIRED_WATERPOWER = 5;

        /// <summary>
        /// Octopus constructor that passes on the octopus's properties into the parent class (Fish Class) and sets an octopus image
        /// </summary>
        public Octopus() : base(UNIT_TYPE, CURRENT_HEALTH, MAXIMUM_HEALTH, REQUIRED_WATERPOWER)
        {
            //Fish image is the octopus file in resources
            fishImage = Properties.Resources.octopus;
        }

        /// <summary>
        /// Overrides the Fish's abstract CreateFish() method to return an Octopus object
        /// </summary>
        /// <returns>returns an Octopus object</returns>
        public override Fish CreateFish()
        {
            //Returns the octopus
            return new Octopus();
        }
    }
}

