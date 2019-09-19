/*
 * Yasoob Ali, William Chan, Isaac Abdi, Roshan Nantha
 * January 21st, 2019
 * This is the child class of Fish and is used to set the properties of a flopfish
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
    class FlopFish : Fish
    {
        // constant string that sets the flop fish's unit type to Flop fish
        public const string UNIT_TYPE = "Flop fish";
        // constant integer that sets the flop fish's current health to 2
        private const int CURRENT_HEALTH = 2;
        // constant integer that sets the flop fish's maximum health to 2
        private const int MAXIMUM_HEALTH = 2;
        // constant integer that sets the flop fish's required waterpower to 2
        private const int REQUIRED_WATERPOWER = 2;

        /// <summary>
        /// Octopus constructor that passes on the octopus's properties into the parent class (Fish Class) and sets an octopus image
        /// </summary>
        public FlopFish() : base (UNIT_TYPE, CURRENT_HEALTH, MAXIMUM_HEALTH, REQUIRED_WATERPOWER)
        {
            //Fish image is the flopfish file in resources
            fishImage = Properties.Resources.flopfish;         
        }

        /// <summary>
        /// Overrides the Fish's abstract CreateFish() method to return an FlopFish object
        /// </summary>
        /// <returns>returns a flopfish object</returns>
        public override Fish CreateFish()
        {
            // returns a FlopFish object
            return new FlopFish();
        }
    }
}
