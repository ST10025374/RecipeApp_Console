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
        /// Instance of ReipeClass
        /// </summary>
        public RecipeClass Recipe = new RecipeClass();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public WorkerClass()
        {

        }

        //--------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Call DisplayMenu and GetMenuOption method 
        /// Show Menu and get user menu input option
        /// Show Heading
        /// Continue looping/calling menu and asking for input till user selects exit option from menu
        /// </summary>
        public void StartWorker()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("\n --------------------------------------" +
                              "\n |       Welcome to Recipe App        |\n" +
                              " --------------------------------------\n", Console.ForegroundColor);

            Console.ResetColor();

            do
            {
                DisplayMenu();
   
                GetMenuOption();
            } while (true);
        }

        //--------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Display Menu to user
        /// </summary>
        public void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("\n  -------------------------------------\n" +
                              "  | Choose an option from menu bellow |\n" +
                              "  |     (1) Store Recipe              |\n" +
                              "  |     (2) Display Recipe            |\n" +
                              "  |     (3) Scale Up Recipe           |\n" +
                              "  |     (4) Delete Recipe             |\n" +
                              "  |     (5) Clear Screen              |\n" +
                              "  |     (6) Terminate and Exit        |\n" +
                              "  -------------------------------------\n" +
                              "  Type the number next to the option desired: ", Console.ForegroundColor);

            Console.ResetColor();
        }

        //--------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Get option input menu from user
        /// Call methods from selected options
        /// If user enters invalid input loop until user types correct input
        /// Only range from 1 to 6 is valid otherwise it will continue to loop because of if statement 
        /// </summary>
        public void GetMenuOption()
        {
            Boolean Valid = true;
            int Option = 0;

            do
            {
                try
                {
                    Valid = true;
                    Option = int.Parse(Console.ReadLine());

                    if (Option < 1 || Option > 6)
                    {
                        Valid = false;

                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("\nSorry, you did not enter a " +
                            "valid option. Please try again.", Console.ForegroundColor);

                        Console.ResetColor();
                    }
                }
                catch (FormatException)
                {
                    Valid = false;

                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("\nSorry, you did not enter a " +
                        "valid option. Please try again.", Console.ForegroundColor   );
                    
                    Console.ResetColor();

                    DisplayMenu();
                }
            } while (Valid.Equals(false));

            switch (Option)
            {
                case 1:
                    Console.Clear();

                    Recipe.GetRecipe();

                    break;

                case 2:
                        Recipe.DisplayRecipeData();

                    break;

                case 3:
                        Recipe.ScaleUp();

                    break;

                case 4:
                        Recipe.DeleteRecipe();

                    break;

                case 5:
                        Console.Clear();

                    break;

                case 6:
                    Exit();

                    break;
            }
        }

        //--------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Terminate Program
        /// </summary>
        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
//---------------------------------------------------------< END >-----------------------------------------------------//

