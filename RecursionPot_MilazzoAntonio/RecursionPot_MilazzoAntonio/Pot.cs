using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionPot_MilazzoAntonio
{
    //credit to Professor Emre for starting the code
    class Pot
    {
        //private means that only members of this class
        //can access (read or change) these variables
        private int diameter = 9;
        private int minimumDiameter = 1;
        private string measurementSystem = "inches";
        private int step = 1;

        //Constructor
        //When an instance is made, the statements in this method
        //will run first, and only once
        public Pot()
        {
         
            Console.WriteLine("Steps to draw a Dogon-like pot:");
         DrawPot();
        }

        private void DrawPot()
        {
            
            //if-then conditional statement
            if (diameter <= minimumDiameter)
            {
                Console.WriteLine($"{step}. Draw the lid");
            }
            else
            {
                Console.WriteLine($"{step}. Draw a circle that is {diameter} {measurementSystem} in size");


                //TODO: Add code to reduce the value of the variable diameter by 2/3
                diameter = diameter * 2 / 3;
                //TODO: increment value of the variable step
                step++;
                //TODO: add a recursive function/method call to invoke this method again
                DrawPot();

            }
        }

    }
}
