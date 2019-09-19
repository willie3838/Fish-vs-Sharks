/*
 * Yasoob Ali, William Chan, Isaac Abdi, Roshan Nantha
 * January 21st, 2019
 * This is the child class of Sharks and is used to set the properties of a RegularShark
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
    class RegularShark : Sharks
    {
        // a constant string that sets the regular shark's unit type to: Regular shark
        public const string UNIT_TYPE = "Regular shark";

        // a constant integer that sets the regular shark's current health to 4
        private const int CURRENT_HEALTH = 4;

        // a constant integer that sets the regular shark's maximum health to 4
        private const int MAXIMUM_HEALTH = 4;


        /// <summary>
        /// Regular shark constructor that passes on the regular sharks properties into the parent class (Shark Class) and sets its image to a regular shark
        /// </summary>
        /// <param name="x">The regular shark's x-coordinate</param>
        /// <param name="y">The regular shark's y-coordinate</param>
        public RegularShark(int x, int y) : base(UNIT_TYPE, CURRENT_HEALTH, MAXIMUM_HEALTH,x, y)
        {
            //The shark image is the Regular_Shark image in resources
            sharkImage = Properties.Resources.Regular_Shark;
        }
    }
}
