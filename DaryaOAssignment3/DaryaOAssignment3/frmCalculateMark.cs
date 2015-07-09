// Author: Darya Ostapenko
// Date: June 11, 2015
// Assignment 3
// Usage: Calculate student's final mark and letter grade
// Acknowdledgement: I used parts of the FutureValue project code for validation
//                   such as IsPresent, IsWithinRange, IsInt32

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
    public partial class frmCalculateMark : Form
    {
        public frmCalculateMark()
        {
            InitializeComponent();
        }

        //declare global variables
        double averageMark = 0;
        int numberOfStudents = 0;
        double totalMarks = 0;

        //declare constants
        const double assignmentWeight = 0.35;
        const double workshopWeight = 0.5;
        const double participationWeight = 0.15;
        const int gradeApluscutoff = 90;
        const int gradeAcutoff = 85;
        const int gradeAmincutoff = 80;
        const int gradeBpluscutoff = 77;
        const int gradeBcutoff = 73;
        const int gradeBmincutoff = 70;
        const int gradeCpluscutoff = 67;
        const int gradeCcutoff = 63;
        const int gradeCmincutoff = 60;
        const int gradeDpluscutoff = 55;
        const int gradeDcutoff = 50;
        
        private void lblCalculate_Click(object sender, EventArgs e)
        {
            // declare input variables
            double assignmentMark;
            double workshopMark;
            double participationMark;

            //declare output variables
            double finalMark;
            string finalGrade;
            string listboxOutput;
                      
            //validate data entered by user
            try
            {
                //check validity
                // if you don't have a valid value, don't execute the following blocks
                if (IsValidData())
                {
                    //increment number of student every time a button is clicked
                    numberOfStudents++;

                    calculateGradeAndMarks(out assignmentMark, out workshopMark, out participationMark, 
                        out finalMark, out finalGrade);

                    //add string to the listbox describing student history so far
                    listboxOutput = "Student " + numberOfStudents + ", Final Mark: " 
                        + txtStudentMark.Text + ", Final Grade: " 
                        + finalGrade;
                    ltbStudentInfo.Items.Add(listboxOutput);
                }
            }
                //display if an exception that has not been anticipated is thrown
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + //get description of error
                    ex.GetType().ToString() + "\n" + //get the type of class that was used to create the exception object
                    ex.StackTrace, "Exception"); //stack trace is a list of methods called before exception occurred
            }
        }

        private void calculateGradeAndMarks(out double assignmentMark, out double workshopMark, 
            out double participationMark, out double finalMark, out string finalGrade)
        {
            //get inputs from the user
            assignmentMark = Convert.ToDouble(txtAssignments.Text);
            workshopMark = Convert.ToDouble(txtWorkshop.Text);
            participationMark = Convert.ToDouble(txtParticipation.Text);

            // calculate final mark
            finalMark = assignmentWeight * assignmentMark + workshopWeight * workshopMark
                + participationWeight * participationMark;

            //assign final letter grade
            finalGrade = gradeAssign(finalMark);

            //calculate new class average
            totalMarks += finalMark;
            averageMark = totalMarks / numberOfStudents;

            //display final grade and final letter grade
            finalMark = Math.Round(finalMark);
            finalMark = finalMark / 100;                        //get finalMark as a fraction
            txtStudentMark.Text = finalMark.ToString("P0");     //display finalMark as percent
            txtStudentGrade.Text = finalGrade;
            averageMark = averageMark / 100;                    //get averageMark as a fraction
            txtAverageMark.Text = averageMark.ToString("P0");   //display averageMark as percent
        }

        private static string gradeAssign(double finalMark)
        {
            string finalGrade;
            if (finalMark >= gradeApluscutoff)
            {
                finalGrade = "A+";
            }
            else if (finalMark >= gradeAcutoff)
            {
                finalGrade = "A";
            }
            else if (finalMark >= gradeAmincutoff)
            {
                finalGrade = "A-";
            }
            else if (finalMark >= gradeBpluscutoff)
            {
                finalGrade = "B+";
            }
            else if (finalMark >= gradeBcutoff)
            {
                finalGrade = "B";
            }
            else if (finalMark >= gradeBmincutoff)
            {
                finalGrade = "B-";
            }
            else if (finalMark >= gradeCpluscutoff)
            {
                finalGrade = "C+";
            }
            else if (finalMark >= gradeCcutoff)
            {
                finalGrade = "C";
            }
            else if (finalMark >= gradeCmincutoff)
            {
                finalGrade = "C-";
            }
            else if (finalMark >= gradeDpluscutoff)
            {
                finalGrade = "D+";
            }
            else if (finalMark >= gradeDcutoff)
            {
                finalGrade = "D";
            }
            else
            {
                finalGrade = "F";
            }
            return finalGrade;
        }

        //validation tests to be run
        public bool IsValidData()
        {
            return
               // compound conditions

                // use short circuit && operator: don't evaluate the second/third statement
                //unless necessary
                // Order of tests IS important, because:
                //IsInt32 assumes there is a value
                //IsWithinRange assumes valid numeric type

                 // Validate the Assignment mark text box
                Validator.IsPresent(txtAssignments, "Assignment mark") &&
                Validator.IsInt32(txtAssignments, "Assignment mark") &&
                Validator.IsWithinRange(txtAssignments, "Assignment mark", 0, 100) && //set the range to be 0 to 100

                // Validate the Workshop text box
                Validator.IsPresent(txtWorkshop, "Workshop mark") &&
                Validator.IsInt32(txtWorkshop, "Workshop mark") &&
                Validator.IsWithinRange(txtWorkshop, "Workshop mark", 0, 100) &&//set the range to be 0 to 100

                // Validate the Participation text box
                Validator.IsPresent(txtParticipation, "Participation mark") &&
                Validator.IsInt32(txtParticipation, "Participation mark") &&
                Validator.IsWithinRange(txtParticipation, "Participation mark", 0, 100);//set the range to be 0 to 100
        }

        // add a button to exit out of the form when clicked
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // create a clear button by resetting all text boxes to empty strings
        private void btnClear_Click(object sender, EventArgs e)
        {
            //set textboxes to empry strings
            txtAssignments.Text = "";
            txtWorkshop.Text = "";
            txtParticipation.Text = "";
            txtStudentMark.Text = "";
            txtStudentGrade.Text = "";
            txtAverageMark.Text = "";

            //set variables to zero
            totalMarks = 0;
            numberOfStudents = 0;

            //let first textbox get focus
            txtAssignments.Focus();

            //clear listbox of all items
            ltbStudentInfo.Items.Clear();
        }

    }
}


