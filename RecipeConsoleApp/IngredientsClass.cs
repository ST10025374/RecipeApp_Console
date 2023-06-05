using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeConsoleApp
{
    public class IngredientsClass
    {
        /// <summary>
        /// Store the number of ingredients of each recipe
        /// </summary>
        public int NumberOfIngredients { get; set; } = 0;

        /// <summary>
        /// Store Ingredient Name
        /// </summary>
        public string IngredientName { get; set; } = string.Empty;

        /// <summary>
        /// Store Ingredient Quantity
        /// </summary>
        public double IngredientQuantity { get; set; } = 0.0;

        /// <summary>
        /// Store Ingredient Unit Of Measurement
        /// </summary>
        public string UnitOfMeasurement { get; set; } = string.Empty;

        /// <summary>
        /// Store Ingredient number of Calories
        /// </summary>
        public int IngredientCalories { get; set; } = 0;

        /// <summary>
        /// Store Ingredient Food Group
        /// </summary>
        public string IngredientFoodGroup { get; set; } = string.Empty;

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Default Constructor
        /// </summary>
        public IngredientsClass()
        {

        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Ask User for Number of Ingredients in Recipe and Store Input
        /// Keep asking till correct input requested is added
        /// In case incorrect input is added will display error message
        /// </summary>
        /// <param name="NumberOfIngredients"></param>
        public void GetNumberOfIngredients()
        {
            Boolean Valid = true;

            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Valid = true;

                    Console.WriteLine("\nEnter the amount of ingredients in the recipe: ");

                    Console.ResetColor();

                    this.NumberOfIngredients = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Valid = false;

                    Console.WriteLine("\nSorry, you did not enter a valid number" +
                        ". Please try again.\n", Console.ForegroundColor);

                    Console.ResetColor();
                }
            } while (Valid.Equals(false));
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Ask User for Ingredient Name in Recipe and Store Input
        /// Keep asking till correct input requested is added
        /// In case incorrect input is added will display error message
        /// </summary>
        public void GetIngredientName()
        {
            Boolean Valid = true;

            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Valid = true;

                    Console.WriteLine("Enter the name of the ingredient: ", Console.ForegroundColor);

                    Console.ResetColor();

                    this.IngredientName = Console.ReadLine();
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Valid = false;

                    Console.WriteLine("\nSorry, you did not " +
                        "enter a valid name. Please try again.", Console.ForegroundColor);

                    Console.ResetColor();
                }
            } while (Valid.Equals(false));
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Ask User for Ingredient Quantity and Store Input
        /// Keep asking till correct input requested is added
        /// In case incorrect input is added will display error message
        /// </summary>
        public void GetIngredientQuantity()
        {
            Boolean Valid = true;

            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Valid = true;

                    Console.WriteLine("\nEnter the quantity of the ingredient: ", Console.ForegroundColor);

                    Console.ResetColor();

                    this.IngredientQuantity = double.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Valid = false;

                    Console.WriteLine("\nSorry, you did not enter a " +
                        "valid number. Please try again.\n", Console.ForegroundColor);

                    Console.ResetColor();
                }
            } while (Valid.Equals(false));
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Ask User for Unit of Measurement and Record
        /// User can select from 3 options
        /// Method stores string of unit of measurement selected by user
        /// Keep asking till correct input requested is added
        /// In case incorrect input is added will display error message
        /// </summary>
        public void GetUnitOfMeasurement()
        {
            Boolean Valid = true;

            int Option = 0;

            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Valid = true;

                    Console.WriteLine("\nSelect the unit of measurement by typing the option number: \n" +
                              "[1] Gram (g) \n" +
                              "[2] Tablespoon (tbsp) \n" +
                              "[3] Cup (c) \n" +
                              "Type option:", Console.ForegroundColor);
                    
                    Console.ResetColor();

                    Option = int.Parse(Console.ReadLine());

                    if (Option < 1 || Option > 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Valid = false;

                        Console.WriteLine("\nSorry, you did not " +
                            "select a valid option. Please try again.\n", Console.ForegroundColor);

                        Console.ResetColor();
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Valid = false;

                    Console.WriteLine("\nSorry, you did not select a " +
                        "valid option. Please try again.\n", Console.ForegroundColor);

                    Console.ResetColor();
                }
            } while (Valid.Equals(false));

            switch (Option)
            {
                case 1:
                    this.UnitOfMeasurement = "g";
                    break;
                case 2:
                    this.UnitOfMeasurement = "tbsp";
                    break;
                case 3:
                    this.UnitOfMeasurement = "C";
                    break;
            }
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to get calories from user
        /// if incorrect input is typed display warning and ask input again
        /// </summary>
        public void GetIngredientCalories()
        {
            Boolean Valid = true;

            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Valid = true;

                    Console.WriteLine("\nEnter the number of calories of " +
                        "the ingredient: ", Console.ForegroundColor);

                    Console.ResetColor();

                    this.IngredientCalories = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Valid = false;

                    Console.WriteLine("\nSorry, you did not enter a " +
                        "valid number. Please try again.\n", Console.ForegroundColor);

                    Console.ResetColor();
                }
            } while (Valid.Equals(false));
        }

        /// <summary>
        /// Method to get Ingredient Food Group
        /// Displays options to user and user inputs desired option
        /// </summary>
        public void GetIngredientFoodGroup()
        {
            Boolean Valid = true;

            int Option = 0;

            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Valid = true;

                    Console.WriteLine("\nSelect the food group that the " +
                        "ingredient belongs to, by typing the option number: \n" +
                              "[1] Vegetable \n" +
                              "[2] Fruit \n" +
                              "[3] Grain \n" +
                              "[4] Dairy \n" +
                              "[5] Protein \n" +
                              "[6] Spice \n" +
                              "[7] Herb \n" +
                              "[8] Oil \n" +
                              "[9] Water \n" +
                              "Type option:", Console.ForegroundColor);

                    Console.ResetColor();

                    Option = int.Parse(Console.ReadLine());

                    if (Option < 1 || Option > 9)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Valid = false;

                        Console.WriteLine("\nSorry, you did not " +
                            "select a valid option. Please try again.\n", Console.ForegroundColor);

                        Console.ResetColor();
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Valid = false;

                    Console.WriteLine("\nSorry, you did not select a " +
                        "valid option. Please try again.\n", Console.ForegroundColor);

                    Console.ResetColor();
                }
            } while (Valid.Equals(false));

            switch (Option)
            {
                case 1:
                    this.IngredientFoodGroup = "Vegetable";
                    break;

                case 2:
                    this.IngredientFoodGroup = "Fruit";
                    break;

                case 3:
                    this.IngredientFoodGroup = "Grain";
                    break;

                case 4:
                    this.IngredientFoodGroup = "Dairy";
                     break;

                case 5:
                    this.IngredientFoodGroup = "Protein";
                    break;

                case 6:
                    this.IngredientFoodGroup = "Spice";
                    break;

                case 7:
                    this.IngredientFoodGroup = "Herb";
                    break;   
            
                case 8:
                    this.IngredientFoodGroup = "Oil";
                    break;

                case 9:
                    this.IngredientFoodGroup = "Water";
                    break;
            }
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Ask User for Ingredients Details calling methods to get Inputs
        /// </summary>
        public void GetIngredientDetails()
        {            
            GetIngredientName();

            GetUnitOfMeasurement();

            GetIngredientQuantity();

            GetIngredientCalories();

            GetIngredientFoodGroup();
        }
    }
}
//---------------------------------------------------------< END >-----------------------------------------------------//

