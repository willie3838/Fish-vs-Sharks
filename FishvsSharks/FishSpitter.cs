/*
 * Yasoob Ali, William Chan, Isaac Abdi, Roshan Nantha
 * January 21st, 2019
 * This is the child class of Fish and is used to set the properties of a fish spitter
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
    class FishSpitter : Fish
    {
        // constant string that sets the fish spitter's unit type to "Fish spitter"
        public const string UNIT_TYPE = "Fish spitter";

        // constant integer used to set the fish spitter's current health to 3
        private const int CURRENT_HEALTH = 3;

        // constant integer used to set the fish spitter's maximum health to 3
        private const int MAXIMUM_HEALTH = 3;

        // constant integer used to set the fish spitter's required waterpower to 2
        private const int REQUIRED_WATERPOWER = 2;

        /// <summary>
        /// FishSpitter constructor that passes on its unit type, current health, maximum health, and required waterpower
        /// as parameters to the Fish parent class and sets the fish spitter's image to a fish spitter
        /// </summary>
        public FishSpitter() : base(UNIT_TYPE, CURRENT_HEALTH, MAXIMUM_HEALTH, REQUIRED_WATERPOWER)
        {
            // sets the fishes image
            fishImage = Properties.Resources.fishshooter;
        }

        /// <summary>
        /// Overrides the Fish's abstract CreateFish() method to create a FishSpitter
        /// </summary>
        /// <returns></returns>
        public override Fish CreateFish()
        {
            // returns to parent class
            return new FishSpitter();
        }
    }
}
