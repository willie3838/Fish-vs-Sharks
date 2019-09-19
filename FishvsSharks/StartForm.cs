/*
 * Yasoob Ali, William Chan, Isaac Abdi, Roshan Nantha
 * January 21st, 2019
 * This is the GameManager class that manages the fish, user, sharks, and waterpower
 * 
 * CONTRIBUTIONS
 * ________________________________________________
 * 
 * Contributions made in the Save and Load button will be specified in the subprograms
 * 
 * William:

    Methods
    _______________
    btnback_Click


    Roshan:

    Methods
    _______________
    StartForm


    Variables and their sets/get
    ______________________________
    System.Media.SoundPlayer startSoundPlayer



    Yasoob:

    Methods
    _______________
    btnControls_Click


    Isaac:

    Methods
    _______________
    btnStart_Click
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FishvsSharks
{
    public partial class StartForm : Form
    {
        // creates a vairable that plays sound
        System.Media.SoundPlayer startSoundPlayer = new System.Media.SoundPlayer(@"MoshPit.wav");

        /// <summary>
        /// StartForm constructor that initializes the music and form components
        /// </summary>
        public StartForm()
        {
            InitializeComponent();
            // starts playing the music
            startSoundPlayer.Play();
            // loops through the music
            startSoundPlayer.PlayLooping();
        }

        /// <summary>
        /// Starts the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            // if the name and goal is blank
            if (txtName.Text == "" || txtGoal.Text == "")
            {
                // prompt the user to enter a name and goal
                MessageBox.Show("Please enter a name and a goal, and remember to save!");
            }
            else
            {
                // hide the form
                this.Hide();
                // create a game form
                GameForm frm = new GameForm();
                // make the game form appear
                frm.ShowDialog();
            }
        }

        /// <summary>
        /// Saves the name and goal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                /////////////////////// ROSHAN ///////////////////////
                // save the file into the name the user chose
                using (StreamWriter file = new StreamWriter("Goal.txt"))
                {
                    // output the entire textbox into the file
                    // use file.Write so that there will not be a blank line
                    // at the bottom of the file
                    file.Write(txtGoal.Text);
                }

                ////////////////////// ISAAC ////////////////////////////
                // save the file into the name the user chose
                using (StreamWriter file = new StreamWriter("Name.txt"))
                {
                    // output the entire textbox into the file
                    // use file.Write so that there will not be a blank line
                    // at the bottom of the file
                    file.Write(txtName.Text);
                }
            }
            // runs this code if there is an error
            catch (Exception)
            {
                // Show that an unkown error happened
                MessageBox.Show("An unkown error happened.");
            }
        }

        /// <summary>
        /// Loads the saved data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                /////////////////////// ROSHAN /////////////////////////
                // loads the data stored in the Goal.txt file
                using (StreamReader file = new StreamReader("Goal.txt"))
                {
                    // sets the label's text to the file's text
                    txtGoal.Text = file.ReadToEnd();
                }
                /////////////////////// ISAAC //////////////////////////
                // loads the data stored in the Name.txt file
                using (StreamReader file = new StreamReader("Name.txt"))
                {
                    // sets the label's text to the file's text
                    txtName.Text = file.ReadToEnd();
                }

                ////////////////////// WILLIAM ////////////////////////////
                // loads the data stored in the Points.txt file
                using (StreamReader file = new StreamReader("Points.txt"))
                {
                    // sets the label's text to the file's text
                    lblPoints.Text = "Previous Points: " + file.ReadToEnd();
                }
                //////////////////////// YASOOB //////////////////////
                // loads the data stored in the Level.txt file
                using (StreamReader file = new StreamReader("Level.txt"))
                {
                    // sets the label's text to the file's text
                    lblLevel.Text = "Previous Level: " + file.ReadToEnd();
                }

            }
            // Runs this code if there is an error
            catch (Exception)
            {
                // show that the file could not be loaded
                MessageBox.Show("Could not load file.");
            }
        }

        /// <summary>
        /// Checks if the controls button was clicked and makes the instructions panel visible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnControls_Click(object sender, EventArgs e)
        {
            // makes the panel visible
            pnlControls.Visible = true;
        }

        /// <summary>
        /// Checks if the back button was clicked and makes the instructions panel invisible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            // makes the panel invisible
            pnlControls.Visible = false;
        }
    }
}
