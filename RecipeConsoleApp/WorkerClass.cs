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
            Console.WriteLine("  -------------------------------------\n" +
                              "  | Choose an option from menu bellow |\n" +
                              "  |     (1) Store Recipe              |\n" +
                              "  |     (2) Display Recipe            |\n" +
                              "  |     (3) Scale Up Recipe           |\n" +
                              "  |     (4) Delete Recipe             |\n" +
                              "  |     (5) Clear Screen              |\n" +
                              "  |     (6) Terminate and Exit        |\n" +
                              "  -------------------------------------");
            //Chhange background Color Add Sounds
            // Type Recipe Name --> Scale 0.5 half, 2 double, 3 triple, Reset --> Display
            //Type Recipe Name --> Display info that Recipe was succesfully deleted
            //Test
        }

        //----------------------------------------------------------------------------//
        /// <summary>
        /// Get option input menu from user
        /// Call menu method to be displayed
        /// </summary>
        public void MenuOption()
        {//Insert Input validation
         //If Input different ask user to enter again
            Console.WriteLine("\n --------------------------------------" +
                              "\n |       Welcome to Recipe App        |\n" +
                              "\n --------------------------------------\n");

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

