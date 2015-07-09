// Author: Darya Ostapenko
// Date: June 15, 2015
// Assignment 5
// Usage: Creates a new class Student that will take marks as parameters
//          and include methods to calculate the final overall mark and the final letter grade


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaryaOAssignment1
{
   public class Student
    {

        // properties - provide controlled access to the private data
        //properties are read and write (hence, get and set, both)
        //auto-implemented - private data is created automatically  
        public string Name { get; set;}
        private double AssignmentMark { get; set; }
        private double WorkshopMark { get; set; }
        private double ParticipationMark { get; set; }

        // not specifying set parameter, since my function will only deliver a valid value
        // due to the validator class
        public double FinalMark { get; set; } 
        public string LetterGrade { get; set; }
         
       //define constants for marks
        const double assignmentWeight = 0.35;
        const double workshopWeight = 0.5;
        const double participationWeight = 0.15;

       //define constants for assigning grade letters
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

        
       // constructor - creates a student object, needs marks as parameters
       // there is no constructor with default values
       // my form will only create an instance of this class is there are marks being input
        public Student(double a, double w, double p)
        {   
            // leave empty code or assign some default value
            Name = "";
            AssignmentMark = a;
            WorkshopMark = w;
            ParticipationMark = p;
            FinalMark = CalculateFinalMark();
            LetterGrade = GradeAssign(FinalMark);
        }


        private double CalculateFinalMark()
        {
            // calculate final mark
            FinalMark = assignmentWeight * AssignmentMark + workshopWeight * WorkshopMark
                + participationWeight * ParticipationMark;

            //display final grade and final letter grade
            FinalMark = Math.Round(FinalMark); 
            return FinalMark;
        }


        private string GradeAssign(double FinalMark)
        {
            string finalGrade;
            if (FinalMark >= gradeApluscutoff)
            {
                finalGrade = "A+";
            }
            else if (FinalMark >= gradeAcutoff)
            {
                finalGrade = "A";
            }
            else if (FinalMark >= gradeAmincutoff)
            {
                finalGrade = "A-";
            }
            else if (FinalMark >= gradeBpluscutoff)
            {
                finalGrade = "B+";
            }
            else if (FinalMark >= gradeBcutoff)
            {
                finalGrade = "B";
            }
            else if (FinalMark >= gradeBmincutoff)
            {
                finalGrade = "B-";
            }
            else if (FinalMark >= gradeCpluscutoff)
            {
                finalGrade = "C+";
            }
            else if (FinalMark >= gradeCcutoff)
            {
                finalGrade = "C";
            }
            else if (FinalMark >= gradeCmincutoff)
            {
                finalGrade = "C-";
            }
            else if (FinalMark >= gradeDpluscutoff)
            {
                finalGrade = "D+";
            }
            else if (FinalMark >= gradeDcutoff)
            {
                finalGrade = "D";
            }
            else
            {
                finalGrade = "F";
            }
            return finalGrade;
        }

        // public method to create a string showing student parameters(marks)
        public override string ToString() // overrides method from the Object class
        {   
            string s = "Student: " + Name.ToString() + "\n" +
                "Final Course Mark: " + FinalMark.ToString() + "%" + "\n" +
                "Final Letter Grade: " + LetterGrade + "\n";
            return s;
        }
    }
}
