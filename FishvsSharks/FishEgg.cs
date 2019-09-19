/*
 * Yasoob Ali, William Chan, Isaac Abdi, Roshan Nantha
 * January 21st, 2019
 * This is the child class of Fish and is used to set the properties of a fish egg.
 * 
 * CONTRIBUTIONS
 * ________________________________________________
 * Yasoob made all of this
 */

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FishvsSharks
{
    class FishEgg : Fish
    {
        // a string constant used to set the fish egg's unit type: "Egg"
        private const string UNIT_TYPE = "Egg";

        // an integer constant used to set the fish egg's current health which is 7
        private const int CURRENT_HEALTH = 7;

        // an integer constant used to set the fish egg's maximum health which is 7
        private const int MAXIMUM_HEALTH = 7;

        // an integer constant is used to set the fish egg's required water power to 5
        private const int REQUIRED_WATERPOWER = 5;

        /// <summary>
        /// Fish Egg's constructor that passes in its unit type, current health, maximum health, and required waterpower
        /// as the parameters for the parent FIsh class' constructor
        /// </summary>
        public FishEgg() : base(UNIT_TYPE, CURRENT_HEALTH, MAXIMUM_HEALTH, REQUIRED_WATERPOWER)
        {
            //Fish image is the egg file in resources
            fishImage = Properties.Resources.egg;
        }

        /// <summary>
        /// Overrides the abstract CreateFish method to return a fish egg
        /// </summary>
        /// <returns></returns>
        public override Fish CreateFish()
        {
            //Return the fish egg
            return new FishEgg();
        }
    }
}

