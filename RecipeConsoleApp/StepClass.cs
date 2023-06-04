using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeConsoleApp
{
    public class StepClass
    {
        /// <summary>
        /// Store the recipe number of steps
        /// </summary>
        public int NumberOfSteps { get; set; } = 0;

        /// <summary>
        /// Will store a description of each step in Recipe
        /// </summary>
        public string StepDescription { get; set; } = string.Empty;

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Default Constructor
        /// </summary>
        public StepClass()
        { 
        
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Ask User for recipe steps amount
        /// Keep asking till correct input requested is added
        /// In case incorrect input is added will display error message
        /// </summary>
        public void GetNumberOfSteps()
        {
            Boolean Valid = true;

            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green; 

                    Valid = true;

                    Console.WriteLine("Enter the amount of " +
                        "steps in the recipe: ", Console.ForegroundColor);

                    Console.ResetColor();

                    this.NumberOfSteps = int.Parse(Console.ReadLine());

                }
                catch (FormatException)
                {
                    Console.ForegroundColor= ConsoleColor.Red;

                    Valid = false;

                    Console.WriteLine("\nSorry, you did not enter " +
                        "a valid number. Please try again.\n", Console.ForegroundColor);

                    Console.ResetColor();
                }
            } while (Valid.Equals(false));
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Ask User for step description
        /// Keep asking till correct input requested is added
        /// In case incorrect input is added will display error message
        /// </summary>
        public void GetStepDescription()
        {
            Boolean Valid = true;
 
            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Valid = true;

                    Console.WriteLine("Enter the " +
                        "description of step: ", Console.ForegroundColor);

                    Console.ResetColor();

                    this.StepDescription = Console.ReadLine();
                }
                catch (FormatException)
                {
                    Console.ForegroundColor= ConsoleColor.Red;

                    Valid = false;

                    Console.WriteLine("\nSorry, you did not enter " +
                        "a valid description. Please try again.\n", Console.ForegroundColor);

                    Console.ResetColor();   
                }
            } while (Valid.Equals(false));
        }
    }
}
//---------------------------------------------------------< END >-----------------------------------------------------//
