/*
 * Yasoob Ali, William Chan, Isaac Abdi, Roshan Nantha
 * January 21st, 2019
 * This is the waterpower class that manages the creation of waterpower
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
using System.Drawing;

namespace FishvsSharks
{
    class Waterpower
    {
        // constant integers used to store the LENGTH and WIDTH of the waterpower's rectangle
        private const int LENGTH = 50, WIDTH = 50;

        // an image used to store the waterpower's image
        private Image waterPowerImage;

        // a rectangle used to store the waterpower's hitbox
        private Rectangle hitBox;

        /// <summary>
        /// Gets a rectangle that stores the waterpower's hitbox
        /// </summary>
        public Rectangle HitBox
        {
            get { return hitBox; }
        }

        /// <summary>
        /// Gets an iamge that stores the waterpower's image
        /// </summary>
        public Image WaterPowerImage
        {
            get { return waterPowerImage; }
        }

        /// <summary>
        /// Waterpower constructor that takes in the x and y coordinates for its location
        /// </summary>
        /// <param name="x">x coordinate of the waterpower</param>
        /// <param name="y">y coordinate of the waterpower</param>
        public Waterpower(int x, int y)
        {
            // sets image for waterpower
            this.waterPowerImage = Properties.Resources.waterpower;
            // sets hitbox's x and y coordinates and dimensions for waterpower
            this.hitBox = new Rectangle(x, y, LENGTH, WIDTH);
        }
    }
}
