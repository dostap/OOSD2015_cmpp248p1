using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaryaOAssignment1
{
    public static class Validator
    {
        //check if a value has been entered
        public static bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "") // check if string is empty
            {
                MessageBox.Show(name + " field cannot be empty", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }
        
        //check if the input is an integer and return true or false
        public static bool IsInt32(TextBox textBox, string name)
        {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be an integer", "Entry Error");
                textBox.Focus();
                return false;
            }
        }
        
        //check if the value falls within range ()range values are entered when the function is called)
        //this method works with all numeric types because it uses decimal, which is the widest 
        //and most accurate numeric type
        //arguments will be cast to decimal type
        public static bool IsWithinRange(TextBox textBox, string name, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(name + " must be between " + min
                    + " and " + max + "", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        
    }
}
