/*
 *Evan Joseph
 * CIS 297, Project 1, Yahtzee
 * In this program, I create a working Yahtzee game.
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

namespace Yahtzee
{
    public partial class Form1 : Form
    {
        public bool isKeepingDie1 = false;
        public bool isKeepingDie2 = false;
        public bool isKeepingDie3 = false;
        public bool isKeepingDie4 = false;
        public bool isKeepingDie5 = false;
        public int onesScore = 0, twosScore = 0, threesScore = 0, foursScore = 0, fivesScore = 0,
            sixesScore = 0, threeOfAKindScore = 0, fourOfAKindScore = 0, fullHouseScore = 0, 
            smallStraightScore = 0, largeStraightScore = 0, yahtzeeScore = 0, chanceScore = 0, bonusAmount = 0;
        public int numberOfRollsLeft = 3;

        public List<int> dice = new List<int> {0,0,0,0,0};
        
        private static readonly int ZERO_VALUE = 0;
        private static readonly int FULL_HOUSE_VALUE = 25;
        private static readonly int SMALL_STRAIGHT_VALUE = 30;
        private static readonly int LARGE_STRAIGHT_VALUE = 40;
        private static readonly int YAHTZEE_VALUE = 50;
        private static readonly int BONUS_VALUE = 35;
        private static readonly int NUMBER_NEEDED_FOR_BONUS = 63;


        public Form1()
        {
            InitializeComponent();
        }

        public void calculateFinalScores()
        {
            if (checkGameOver())
            {
                int oneThroughSix = onesScore + twosScore + threesScore + foursScore + fivesScore + sixesScore;
                if(oneThroughSix >= NUMBER_NEEDED_FOR_BONUS)
                {
                    bonusAmount = BONUS_VALUE;
                }

                bonusValue.Text = bonusAmount.ToString();
                totalValue.Text = (oneThroughSix + bonusAmount + threeOfAKindScore + fourOfAKindScore + fullHouseScore
                    + smallStraightScore + largeStraightScore + yahtzeeScore + chanceScore).ToString();
            }
        }

        public bool checkGameOver()
        {
            //scoring buttons are disabled when they are used, so all of them being disabled means the game is over
            return (!button1.Enabled && !button2.Enabled && !button3.Enabled && !button4.Enabled &&
                !button5.Enabled && !button6.Enabled && !button7.Enabled && !button8.Enabled &&
                !button9.Enabled && !button10.Enabled && !button11.Enabled && !button12.Enabled &&
                !button13.Enabled);
        }

        public void enableRoll()
        {
            buttonRoll.Enabled = true;
            numberOfRollsLeft = 3;
            buttonKeepDie1.Text = "Not Keeping";
            buttonKeepDie2.Text = "Not Keeping";
            buttonKeepDie3.Text = "Not Keeping";
            buttonKeepDie4.Text = "Not Keeping";
            buttonKeepDie5.Text = "Not Keeping";
            buttonKeepDie1.Enabled = false;
            buttonKeepDie2.Enabled = false;
            buttonKeepDie3.Enabled = false;
            buttonKeepDie4.Enabled = false;
            buttonKeepDie5.Enabled = false;
        }

        public int onesToSixesScoring(int number)
        {
            int sum = 0;
            foreach (int numberOfOccurrences in dice)
            {
                if(numberOfOccurrences == number)
                {
                    sum += number;
                }
            }
            return sum;
        }
        
        public bool checkForThreeOfAKind()
        {
            int numberOfOnes = 0, numberOfTwos = 0, numberOfThrees = 0, numberOfFours = 0, numberOfFives = 0, numberOfSixes = 0;
            for(int i = 0; i < 5; i++)
            {
                if(dice[i] == 1)
                {
                    numberOfOnes++;
                }
                else if (dice[i] == 2)
                {
                    numberOfTwos++;
                }
                else if (dice[i] == 3)
                {
                    numberOfThrees++;
                }
                else if (dice[i] == 4)
                {
                    numberOfFours++;
                }
                else if (dice[i] == 5)
                {
                    numberOfFives++;
                }
               else if (dice[i] == 6)
                {
                    numberOfSixes++;
                }
            }

            if(numberOfOnes >= 3 || numberOfTwos >= 3 || numberOfThrees >= 3 || numberOfFours >= 3 || numberOfFives >= 3 || numberOfSixes >= 3)
            {
                return true;
            }

            return false;
        }

        //checks for 4 or more occurrences of a number
        public bool checkForFourOfAKind()
        {
            int numberOfOnes = 0, numberOfTwos = 0, numberOfThrees = 0, numberOfFours = 0, numberOfFives = 0, numberOfSixes = 0;
            for (int i = 0; i < 5; i++)
            {
                if (dice[i] == 1)
                {
                    numberOfOnes++;
                }
                else if (dice[i] == 2)
                {
                    numberOfTwos++;
                }
                else if (dice[i] == 3)
                {
                    numberOfThrees++;
                }
                else if (dice[i] == 4)
                {
                    numberOfFours++;
                }
                else if (dice[i] == 5)
                {
                    numberOfFives++;
                }
                else if (dice[i] == 6)
                {
                    numberOfSixes++;
                }
            }

            if (numberOfOnes >= 4 || numberOfTwos >= 4 || numberOfThrees >= 4 || numberOfFours >= 4 || numberOfFives >= 4 || numberOfSixes >= 4)
            {
                return true;
            }

            return false;
        }

        //counts how many times each number shows up. if there are 3 of a number and 2 of another number, it's a full house
        public bool checkForFullHouse()
        {
            int numberOfOnes = 0, numberOfTwos = 0, numberOfThrees = 0, numberOfFours = 0, numberOfFives = 0, numberOfSixes = 0;
            for (int i = 0; i < 5; i++)
            {
                if (dice[i] == 1)
                {
                    numberOfOnes++;
                }
                else if (dice[i] == 2)
                {
                    numberOfTwos++;
                }
                else if (dice[i] == 3)
                {
                    numberOfThrees++;
                }
                else if (dice[i] == 4)
                {
                    numberOfFours++;
                }
                else if (dice[i] == 5)
                {
                    numberOfFives++;
                }
                else if (dice[i] == 6)
                {
                    numberOfSixes++;
                }
            }

            if ((numberOfOnes == 2 || numberOfTwos == 2 || numberOfThrees == 2 || numberOfFours == 2 || numberOfFives == 2 || numberOfSixes == 2) &&
                (numberOfOnes == 3 || numberOfTwos == 3 || numberOfThrees == 3 || numberOfFours == 3 || numberOfFives == 3 || numberOfSixes == 3))
            {
                return true;
            }

            return false;
        }

        public bool checkForSmallStraight()
        {
            return ( (dice.Contains(1) && dice.Contains(2) && dice.Contains(3) && dice.Contains(4)) || 
                (dice.Contains(2) && dice.Contains(3) && dice.Contains(4) && dice.Contains(5)) || 
                ( dice.Contains(3) && dice.Contains(4) && dice.Contains(5) && dice.Contains(6)) );
        }

        public bool checkForLargeStraight()
        {
            return ( (dice.Contains(1) && dice.Contains(2) && dice.Contains(3)
                && dice.Contains(4) && dice.Contains(5)) ||  ( dice.Contains(2) && dice.Contains(3)
                && dice.Contains(4) && dice.Contains(5) && dice.Contains(6)) );
        }

        public bool checkForYahtzee()
        {
            return dice[0] == dice[1] && dice[1] == dice[2] && dice[2] ==
                dice[3] && dice[3] == dice[4];
        }

        public int chanceScoring()
        {
            int sum = 0;
            foreach (int numberOfOccurrences in dice)
            {
                    sum += numberOfOccurrences;
            }
            return sum;
        }
        
        public void roll()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 7);

            if (buttonKeepDie1.Text == "Not Keeping")
                dice[0] = random.Next(1, 7);
            if (buttonKeepDie2.Text == "Not Keeping")
                dice[1] = random.Next(1, 7);
            if (buttonKeepDie3.Text == "Not Keeping")
                dice[2] = random.Next(1, 7);
            if (buttonKeepDie4.Text == "Not Keeping")
                dice[3] = random.Next(1, 7);
            if (buttonKeepDie5.Text == "Not Keeping")
                dice[4] = random.Next(1, 7);

            numberOfRollsLeft--; //uses a roll, decrements to get the remaining

            //scoring will disable these buttons because we don't want someone clicking "Keeping" and then
            //not all of their dice would be rolled on their 1st out of 3 rolls. rolling switches this to true
            //so the user can once again keep his dice
            buttonKeepDie1.Enabled = true;
            buttonKeepDie2.Enabled = true;
            buttonKeepDie3.Enabled = true;
            buttonKeepDie4.Enabled = true;
            buttonKeepDie5.Enabled = true;

            labelDie1.Text = dice[0].ToString();
            labelDie2.Text = dice[1].ToString();
            labelDie3.Text = dice[2].ToString();
            labelDie4.Text = dice[3].ToString();
            labelDie5.Text = dice[4].ToString();
            
            //can't roll again if you have no rolls left. using a button to score points will reset numberOfRollsLeft
            //to 3, so the roll button will become Enabled again
            if (numberOfRollsLeft == 0)
            {
                buttonRoll.Enabled = false;
            }
        }

        
        private void button1_Click(object sender, EventArgs e) //ones
        {
            //if they havent rolled yet(numberOfRollsLeft == 3), we don't want this button to do anything, which
            //will prevent multiple scoring buttons being pressed for a single set of dice
            if (numberOfRollsLeft < 3)
            {
                onesScore = onesToSixesScoring(1);
                label1.Text = onesScore.ToString();

                button1.Enabled = false;
                enableRoll();
                if (checkGameOver())
                {
                    calculateFinalScores();
                    buttonRoll.Enabled = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) //twos
        {
            //re-using code instead of making a function for all of the buttons, because I need
            //to change a specific, different button's text and score each time
            if (numberOfRollsLeft < 3)
            {
                twosScore = onesToSixesScoring(2);
                label2.Text = twosScore.ToString();

                button2.Enabled = false;
                enableRoll();
                if (checkGameOver())
                {
                    calculateFinalScores();
                    buttonRoll.Enabled = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) //threes
        {
            if (numberOfRollsLeft < 3)
            {
                threesScore = onesToSixesScoring(3);
                label3.Text = threesScore.ToString();

                button3.Enabled = false;
                enableRoll();
                if (checkGameOver())
                {
                    calculateFinalScores();
                    buttonRoll.Enabled = false;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e) //fours
        {
            if (numberOfRollsLeft < 3)
            {
                foursScore = onesToSixesScoring(4);
                label4.Text = foursScore.ToString();

                button4.Enabled = false;
                enableRoll();
                if (checkGameOver())
                {
                    calculateFinalScores();
                    buttonRoll.Enabled = false;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e) //fives
        {
            if (numberOfRollsLeft < 3)
            {
                fivesScore = onesToSixesScoring(5);
                label5.Text = fivesScore.ToString();

                button5.Enabled = false;
                enableRoll();
                if (checkGameOver())
                {
                    calculateFinalScores();
                    buttonRoll.Enabled = false;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e) //sixes
        {

            if (numberOfRollsLeft < 3)
            {
                sixesScore = onesToSixesScoring(6);
                label6.Text = sixesScore.ToString();

                button6.Enabled = false;
                enableRoll();
                if (checkGameOver())
                {
                    calculateFinalScores();
                    buttonRoll.Enabled = false;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e) //three of a kind
        {
            if (numberOfRollsLeft < 3)
            {
                if (checkForThreeOfAKind())
                {
                    //chance scoring works the same as a successful three/four of a kind
                    threeOfAKindScore = chanceScoring();
                }
                else threeOfAKindScore = ZERO_VALUE;

                label7.Text = threeOfAKindScore.ToString();

                button7.Enabled = false;
                enableRoll();
                if (checkGameOver())
                {
                    calculateFinalScores();
                    buttonRoll.Enabled = false;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e) //four of a kind
        {
            if (numberOfRollsLeft < 3)
            {
                if (checkForFourOfAKind())
                {
                    fourOfAKindScore = chanceScoring();
                }
                else fourOfAKindScore = ZERO_VALUE;
                label8.Text = fourOfAKindScore.ToString();

                button8.Enabled = false;
                enableRoll();
                if (checkGameOver())
                {
                    calculateFinalScores();
                    buttonRoll.Enabled = false;
                }
            }
        }

        private void button9_Click(object sender, EventArgs e) //full house
        {
            if (numberOfRollsLeft < 3)
            {
                if (checkForFullHouse())
                {
                    fullHouseScore = FULL_HOUSE_VALUE;
                }
                else fullHouseScore = ZERO_VALUE;
                label9.Text = fullHouseScore.ToString();

                button9.Enabled = false;
                enableRoll();
                if (checkGameOver())
                {
                    calculateFinalScores();
                    buttonRoll.Enabled = false;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e) //small straight
        {

            if (numberOfRollsLeft < 3)
            {
                if (checkForSmallStraight())
                {
                    smallStraightScore = SMALL_STRAIGHT_VALUE;
                }
                else smallStraightScore = ZERO_VALUE;
                label10.Text = smallStraightScore.ToString();

                button10.Enabled = false;
                enableRoll();
                if (checkGameOver())
                {
                    calculateFinalScores();
                    buttonRoll.Enabled = false;
                }
            }
        }

        private void button11_Click(object sender, EventArgs e) //large straight
        {
            if (numberOfRollsLeft < 3)
            {
                if (checkForLargeStraight())
                {
                    largeStraightScore = LARGE_STRAIGHT_VALUE;
                }
                else largeStraightScore = ZERO_VALUE;
                label11.Text = largeStraightScore.ToString();

                button11.Enabled = false;
                enableRoll();
                if (checkGameOver())
                {
                    calculateFinalScores();
                    buttonRoll.Enabled = false;
                }
            }
        }

        private void button12_Click(object sender, EventArgs e) //yahtzee
        {
            if (numberOfRollsLeft < 3)
            {
                if (checkForYahtzee())
                {
                    yahtzeeScore = YAHTZEE_VALUE;
                }
                else yahtzeeScore = ZERO_VALUE;
                label12.Text = yahtzeeScore.ToString();

                button12.Enabled = false;
                enableRoll();
                if (checkGameOver())
                {
                    calculateFinalScores();
                    buttonRoll.Enabled = false;
                }
            }
        }

        private void button13_Click(object sender, EventArgs e) //chance
        {
            if (numberOfRollsLeft < 3)
            {
                chanceScore = chanceScoring();
                label13.Text = chanceScore.ToString();

                button13.Enabled = false;
                enableRoll();
                if (checkGameOver())
                {
                    calculateFinalScores();
                    buttonRoll.Enabled = false;
                }
            }
        }

        private void buttonKeepDie1_Click(object sender, EventArgs e)
        {
            //We'll be using the labels "Keeping" (meaning that die will not be re-rolled) and "Not Keeping"
            //to determine if a die should be re-rolled or not
            if(buttonKeepDie1.Text == "Keeping")
            {
                buttonKeepDie1.Text = "Not Keeping";
                isKeepingDie1 = false;
            }
            else
            {
                buttonKeepDie1.Text = "Keeping";
                isKeepingDie1 = true;
            }
            
        }

        private void buttonKeepDie2_Click(object sender, EventArgs e)
        {
            if (buttonKeepDie2.Text == "Keeping")
            {
                buttonKeepDie2.Text = "Not Keeping";
                isKeepingDie2 = false;
            }
            else
            {
                buttonKeepDie2.Text = "Keeping";
                isKeepingDie2 = true;
            }
        }

        private void buttonKeepDie3_Click(object sender, EventArgs e)
        {
            if (buttonKeepDie3.Text == "Keeping")
            {
                buttonKeepDie3.Text = "Not Keeping";
                isKeepingDie3 = false;
            }
            else
            {
                buttonKeepDie3.Text = "Keeping";
                isKeepingDie3 = true;
            }
        }

        private void buttonKeepDie4_Click(object sender, EventArgs e)
        {
            if (buttonKeepDie4.Text == "Keeping")
            {
                buttonKeepDie4.Text = "Not Keeping";
                isKeepingDie4 = false;
            }
            else
            {
                buttonKeepDie4.Text = "Keeping";
                isKeepingDie4 = true;
            }
        }

        private void buttonKeepDie5_Click(object sender, EventArgs e)
        {
            if (buttonKeepDie5.Text == "Keeping")
            {
                buttonKeepDie5.Text = "Not Keeping";
                isKeepingDie5 = false;
            }
            else
            {
                buttonKeepDie5.Text = "Keeping";
                isKeepingDie5 = true;
            }
        }

        private void buttonRoll_Click(object sender, EventArgs e)
        {
            roll();
        }
    }
}
