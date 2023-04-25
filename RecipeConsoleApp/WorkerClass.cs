using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeConsoleApp
{
    public class WorkerClass
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public WorkerClass()
        {

        }

        //-----------------------------------------------------------------//
        /// <summary>
        /// Display Menu to user
        /// </summary>
        public void DisplayMenu()
        {
            Console.WriteLine("\nChoose an option from Menu bellow");
            Console.WriteLine("(1) Store Recipe");
            Console.WriteLine("(2) Display Recipe");
            Console.WriteLine("(3) Scale Up Recipe");
            // Type Recipe Name --> Scale 0.5 half, 2 double, 3 triple, Reset --> Display
            Console.WriteLine("(4) Delete Recipe");
            //Type Recipe Name --> Display info that Recipe was succesfully deleted
            //Test
            Console.WriteLine("(5) Clear Screen");
            Console.WriteLine("(6) Terminate and Exit");
            Console.WriteLine("----------------------------------");
            //Chhange background Color Add Sounds
        }

        //----------------------------------------------------------------------------//
        /// <summary>
        /// Get option input menu from user
        /// Call menu method to be displayed
        /// </summary>
        public void MenuOption()
        {//Insert Input validation
         //If Input different ask user to enter again
            Console.WriteLine("\n-------------------------------------" +
                              "------- Welcome to Recipe App -------\n" +
                              "\n-------------------------------------");

            DisplayMenu();

            var Option = string.Empty;

            switch (Option)
            {
                case "1":

                    break;

                case "2":

                    break;

                case "3":

                    break;

                case "4":

                    break;

                case "5":

                    break;

                case "6":

                    break;

                default:

                    break;
            }

        }
    }
}
//---------------------------------------------------------< END >-----------------------------------------------------//

