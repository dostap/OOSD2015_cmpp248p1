// Author: Darya Ostapenko
// Date: June 15, 2015
// Assignment 5
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
using System.Text.RegularExpressions; //added to format listbox output
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaryaOAssignment1
{
    public partial class frmCalculateMark : Form
    {

        List<Student> students = new List<Student>(); // create an empty list called students
        int nrStudents = 0; // counter for students, initialize to zero   
        
        public frmCalculateMark()
        {
            InitializeComponent();
        }

        //declare global variables and initialize 
        double averageMark = 0;
        double totalMarks = 0;
        double studentsPassed = 0;
        double studentsFailed = 0;
        
        private void btnCalculate_Click(object sender, EventArgs e)
        {
           
            //declare output variables
            double assignmentMark;
            double workshopMark;
            double participationMark;
            double finalMark;
                      
            //validate data entered by user
            try
            {
                //check validity
                // if you don't have a valid value from user, don't execute the following blocks

                if (IsValidData())
                {
                    //increment number of student every time a button is clicked
                    nrStudents++;

                    //get inputs from the user
                    assignmentMark = Convert.ToDouble(txtAssignments.Text);
                    workshopMark = Convert.ToDouble(txtWorkshop.Text);
                    participationMark = Convert.ToDouble(txtParticipation.Text);

                    // create object of new student
                    Student nextStudent = new Student(assignmentMark, workshopMark, participationMark); 
                    nextStudent.Name = txtStudentName.Text;

                    //calculate new class average by using student object property FinalMark
                    totalMarks += nextStudent.FinalMark;
                    averageMark = totalMarks / nrStudents;
                    averageMark = Math.Round(averageMark)/100;

                    //calculate how many students got over 50% and passed and how many students failed. 
                    //Display results in textboxes 
                    if (nextStudent.FinalMark >= 50)
                    {
                        studentsPassed++;
                        txtPassed.Text = studentsPassed.ToString();
                    }
                    else
                    {
                        studentsFailed++;
                        txtFailed.Text = studentsFailed.ToString();
                    }

                    students.Add(nextStudent); // add the new student to the list

                    //display student info in the listbox
                    //listbox does not support newlines, so have to split the resulting string into several
                    //since the string deliminator is not one character but several, use Regex.Split
                    ltbStudentInfo.Items.Add(nrStudents + ". "); //this displays number of thestudent as you enter them
                    foreach (string s in Regex.Split(nextStudent.ToString(), "\n"))
                        ltbStudentInfo.Items.Add(s); 
                    
                    //display final mark and grade
                    finalMark = nextStudent.FinalMark*0.01;// get finalMark as fraction so it can be displayed as a percent
                    txtStudentMark.Text = finalMark.ToString("P0");
                    txtStudentGrade.Text = nextStudent.LetterGrade;
                    txtAverageMark.Text = averageMark.ToString("P0"); 

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
            txtStudentMark.Text = "";
            txtStudentGrade.Text = "";
            txtAverageMark.Text = "";
            txtPassed.Text = "";
            txtFailed.Text = "";
            txtAssignments.Text = "";
            txtWorkshop.Text = "";
            txtParticipation.Text = "";
            txtStudentName.Text = "";

            //set variables to zero
            totalMarks = 0;
            nrStudents = 0;

            //let first textbox get focus
            txtStudentName.Focus();

            //clear listbox of all items
            ltbStudentInfo.Items.Clear();
        }

        // create a clear button to only clear current student's data
        private void btnClearOne_Click(object sender, EventArgs e)
        {
            //set textboxes to empry strings
            txtAssignments.Text = "";
            txtWorkshop.Text = "";
            txtParticipation.Text = "";
            txtStudentName.Text = "";
        }

    }
}


