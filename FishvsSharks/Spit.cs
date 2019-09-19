/*
 * Yasoob Ali, William Chan, Isaac Abdi, Roshan Nantha
 * January 21st, 2019
 * This is the Spit class that manages how the spit is made and moved
 * 
 * CONTRIBUTIONS
 * _______________________________________________
 *  
 *  William:

    Methods
    __________________________

    N/A

    Variables and their sets/get
    ___________________________
    spitImage


    Roshan:

    Methods
    ___________________________
    MoveSpit

    Variables and their sets/get
    ___________________________
    spitHitBox


    Isaac:
    Methods
    __________________________
    Spit

    Variables and their sets/get
    __________________________
    SPIT_HEIGHT


    Yasoob:
    Methods
    __________________________
    N/A

    Variables and their sets/get
    __________________________
    SPIT_WIDTH, SPIT_SPEED


 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FishvsSharks
{
    class Spit
    {
        // an image that stores the spit's image
        private Image spitImage;

        // a rectangle that store's the spit's hitbox
        private Rectangle spitHitBox;

        // a constant integer that stores the spit's speed
        public const int SPIT_SPEED = 4;

        // a constant integer that stores the spit's height
        public const int SPIT_HEIGHT = 30;
        // a constant integer that stores the spit's width
        public const int SPIT_WIDTH = 30;

        /// <summary>
        /// Gets an image that stores the spit's image
        /// </summary>
        public Image SpitImage
        {
            get { return spitImage; }
        }

        /// <summary>
        /// Get a rectangle that stores the spit's hit box
        /// </summary>
        public Rectangle SpitHitBox
        {
            get { return spitHitBox; }
        }

        /// <summary>
        /// Spit constructor that takes in integers that store the spit's x and y coordinates to create spit
        /// </summary>
        /// <param name="spitX">The x-coordinate where the spit will spawn</param>
        /// <param name="spitY">The y-coordinate where the spit will spawn</param>
        public Spit(int spitX, int spitY)
        {
            //Create the spit's rectangle
            this.spitHitBox = new Rectangle(spitX, spitY, SPIT_WIDTH, SPIT_HEIGHT);

            //Use the image in resources for spit
            this.spitImage = Properties.Resources.spit;
        }

        /// <summary>
        /// Method that is used to move the spit
        /// </summary>
        /// <param name="spit">The spit that is moving</param>
        public void MoveSpit(Spit spit)
        {
            //Move the spit right by the spit's speed (spit only travels horozontally)
            spit.spitHitBox.X += SPIT_SPEED;
        }
    }
}
