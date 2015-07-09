// Author: Darya Ostapenko
// Date: June 9, 2015
// Usage: Calculate student's final mark and letter grade

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaryaOAssignment1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void lblCalculate_Click(object sender, EventArgs e)
        {
            // declare input variables
            double assignmentMark;
            double workshopMark;
            double participationMark;
            double finalMark;
            string finalGrade;

            //declare constants
            const double assignmentWeight = 0.35;
            const double workshopWeight = 0.5;
            const double participationWeight = 0.15;

            //get inputs
            assignmentMark = Convert.ToDouble(txtAssignments.Text);
            workshopMark = Convert.ToDouble(txtWorkshop.Text);
            participationMark = Convert.ToDouble(txtParticipation.Text);

            // calculate final mark
            finalMark = assignmentWeight * assignmentMark + workshopWeight * workshopMark + participationWeight * participationMark;

            //assign final letter grade

            if (finalMark >= 90)
            {
                finalGrade = "A+";
            }
            else if (finalMark >= 85)
            {
                finalGrade = "A";
            }
            else if (finalMark >= 80)
            {
                finalGrade = "A-";
            }
            else if (finalMark >= 77)
            {
                finalGrade = "B+";
            }
            else if (finalMark >= 73)
            {
                finalGrade = "B";
            }
            else if (finalMark >= 70)
            {
                finalGrade = "B-";
            }
            else if (finalMark >= 67)
            {
                finalGrade = "C+";
            }
            else if (finalMark >= 63)
            {
                finalGrade = "C";
            }
            else if (finalMark >= 60)
            {
                finalGrade = "C-";
            }
            else if (finalMark >= 55)
            {
                finalGrade = "D+";
            }
            else if (finalMark >= 50)
            {
                finalGrade = "D";
            }
            else
            {
                finalGrade = "F";
            }

            //display final grade and final letter grade
            finalMark = Math.Round(finalMark);
            finalMark = finalMark / 100;                        //get finalMark as a fraction
            txtStudentMark.Text = finalMark.ToString("P0");     //display finalMark as percent
            txtStudentGrade.Text = finalGrade;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // create a clear button by resetting all text boxes to empty strings
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAssignments.Text = "";
            txtWorkshop.Text = "";
            txtParticipation.Text = "";
            txtStudentMark.Text = "";
            txtStudentGrade.Text = "";
            txtAssignments.Focus();
        }
    }
}
