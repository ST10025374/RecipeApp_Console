﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace RecipeConsoleApp
{
    /// <summary>
    /// Delegate
    /// </summary>
    /// <param name="message"></param>
    delegate void MyDelegate(string Message);

    public class RecipeClass
    {
        /// <summary>
        /// Store recipe name
        /// </summary>
        public string RecipeName { get; set; } = string.Empty;

        /// <summary>
        /// Instance of Ingredients class
        /// </summary>
        public IngredientsClass Ingredients = new IngredientsClass();

        /// <summary>
        /// Instance of Step class
        /// </summary>
        public StepClass Steps = new StepClass();

        /// <summary>
        /// Array to store details of each ingredient in recipe
        /// </summary>
        public List<IngredientsClass> IngredientsArray = new List<IngredientsClass>();

        /// <summary>
        /// Array to store each recipe 
        /// </summary>
        public List<RecipeClass> RecipeArray = new List<RecipeClass>();

        /// <summary>
        /// Array to store each step description
        /// </summary>
        public List<StepClass> StepArray = new List<StepClass>();

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Default Constructor
        /// </summary>
        public RecipeClass()
        {
            
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Gets recipe name from user
        /// Keep asking till correct input requested is added
        /// In case incorrect input is added will display error message
        /// </summary>
        public void GetRecipeName()
        {
            Boolean Valid = true;

            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Valid = true;

                    Console.WriteLine("Enter the name of the recipe: ", Console.ForegroundColor);

                    Console.ResetColor();

                    this.RecipeName = Console.ReadLine(); 
                    
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
        /// Method that calls methods 
        /// Asks user for Number of Ingredients and call method to get an ingredient detail
        /// Will loop for the number of ingredient specified
        /// Loop for amount of steps and keeps asking for description and store in StepArray
        /// Store all Data in Recipe Object including Arrays
        /// If user while adding calories adds up to more than 300 display message
        /// </summary>
        public void GetRecipe()
        {
            var Recipe = new RecipeClass();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("\nEnter Recipe information bellow" +
                              "\n-------------------------------\n", Console.ForegroundColor);

            Console.ResetColor();

            Recipe.GetRecipeName();

            Ingredients.GetNumberOfIngredients();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("\nType Ingredient Details" +
                              "\n-----------------------", Console.ForegroundColor);

            Console.ResetColor();

            int Sum = 0;

            for (int i = 0; i < Ingredients.NumberOfIngredients; i++)
            {
                var NewIngredient = new IngredientsClass();

                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("\nIngredient " + (i + 1) +
                                  "\n------------\n", Console.ForegroundColor);

                Console.ResetColor();

                NewIngredient.GetIngredientDetails();

                Sum += NewIngredient.IngredientCalories;

                Recipe.IngredientsArray.Add(NewIngredient);
            }

            if (Sum > 300)
            {
                CaloriesWarning();
            }

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("\nType number of Steps" +
                              "\n--------------------", Console.ForegroundColor);

            Console.ResetColor();

            Steps.GetNumberOfSteps();

            for (int i = 0; i < Steps.NumberOfSteps; i++)
            {
                var NewStep = new StepClass();

                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("\nStep " + (i + 1), Console.ForegroundColor);

                Console.ResetColor();

                NewStep.GetStepDescription();

                Recipe.StepArray.Add(NewStep);
            }      
            this.RecipeArray.Add(Recipe);
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Displays Recipe to User
        /// Ask user for Recipe Option
        /// If there is no recipes saved it will return
        /// If user selects recipe option that does not exist system will ask again
        /// </summary>
        public void DisplayRecipeData()
        {
            if (RecipeArray.Count.Equals(0))
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("\nSorry, there is no recipes saved at the moment", Console.ForegroundColor);

                Console.ResetColor();

                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("\nDisplay Recipe" +
                              "\n--------------\n", Console.ForegroundColor);

            Console.ResetColor();

            DisplayRecipeNameList();

            Boolean Valid = true;

            int Option = 0;

            do
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Valid = true;

                    Console.WriteLine("\nType option number " +
                        "from above recipes to diplay: ", Console.ForegroundColor);

                    Console.ResetColor();

                    Option = int.Parse(Console.ReadLine());

                    if ((RecipeArray.Count() - 1) < Option)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Valid = false;

                        Console.WriteLine("\nSorry, you did not enter" +
                            " a valid option. Please try again.", Console.ForegroundColor);

                        Console.ResetColor();
                    }
                }
                catch (FormatException)
                {
                    Valid = false;

                    Console.ForegroundColor= ConsoleColor.Red;

                    Console.WriteLine("\nSorry, you did not enter a valid option. Please try again.");

                    Console.ResetColor();
                }
            } while (Valid.Equals(false));

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("\nRecipe Name: " +             
                              "\n------------\n", Console.ForegroundColor);

            Console.WriteLine("Name: " 
                + this.RecipeArray[Option].RecipeName, Console.ForegroundColor);

            Console.ResetColor();

            DisplayIngredientData(Option);

            DisplayRecipeSteps(Option);
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Display Steps descriptions
        /// Loops thru step array and displays
        /// </summary>
        public void DisplayRecipeSteps(int Option)
        {
            int StepArrayLength = this.RecipeArray[Option].StepArray.Count;

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("\nRecipe Steps" +
                              "\n------------\n", Console.ForegroundColor);

            for (int i = 0; i < StepArrayLength; i++)
            {
                Console.WriteLine("Step " + (i + 1) + " : "
                    + this.RecipeArray[Option].StepArray[i].StepDescription);

            }
            Console.ResetColor();
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Display Recipe Name
        /// This method is called in DisplayRecipeNameList
        /// </summary>
        public void DisplayRecipeName(int Number)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(" (" + Number + ") Recipe name: "
                + this.RecipeArray[Number].RecipeName, Console.ForegroundColor);

            Console.ResetColor();
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Display Ingredients details
        /// Name and Quantity and unit of meausurament
        /// Loops thru length of Ingredients array
        /// Nested ifs display explanation for range of calories
        /// </summary>
        public void DisplayIngredientData(int Option)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("\nIngredients" +
                              "\n-----------\n", Console.ForegroundColor );

            int IngredientsArrayLength = this.RecipeArray[Option].IngredientsArray.Count;

                for (int i = 0; i < IngredientsArrayLength; i++)
                {
                    Console.WriteLine("Ingredient " + (i + 1) + " : "
                        + this.RecipeArray[Option].IngredientsArray[i].IngredientName + " -> "
                        + this.RecipeArray[Option].IngredientsArray[i].IngredientQuantity + " ("
                        + this.RecipeArray[Option].IngredientsArray[i].UnitOfMeasurement + ")  "
                        + this.RecipeArray[Option].IngredientsArray[i].IngredientFoodGroup);
                }

            Console.WriteLine("\nTotal Calories" +
                              "\n--------------\n", Console.ForegroundColor);

            int Sum = SumCalories(Option, this.RecipeArray);

            Console.WriteLine("Calories: " + Sum, Console.ForegroundColor);

            if (Sum < 300)
            {
                Console.WriteLine("\nNote: Very low calories ideial " +
                    "for a breakfast on a diet", Console.ForegroundColor);
            }
            else if (Sum >= 300 && Sum <= 500)
            {
                Console.WriteLine("\nNote: Low calories, ideial for a " +
                    "ligth lunch ", Console.ForegroundColor);
            }
            else if (Sum > 500 && Sum <= 800)
            {
                Console.WriteLine("\nNote: Moderate calories, balanced meal " +
                    "for an after workout", Console.ForegroundColor);
            }
            else
            {
                Console.WriteLine("\nNote: High calories, Ideial for building " +
                    "muscle in bulking season", Console.ForegroundColor);
            }

            Console.ResetColor();
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to display recipe names list
        /// Loop thru Recipe Array
        /// This method is called in Display Recipe Data
        /// Compares two Recipe objects based on their Name property using the string.Compare method. 
        /// </summary>
        public void DisplayRecipeNameList()
        {
            this.RecipeArray.Sort((Recipe1, Recipe2) => string.Compare(Recipe1.RecipeName, Recipe2.RecipeName));

            for (int i = 0; i < this.RecipeArray.Count; i++)
            {
                DisplayRecipeName(i);
            }
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Method To Delete Recipe
        /// If user selects recipe option that does not exist system will ask again
        /// </summary>
        public void DeleteRecipe()
        {
            if (RecipeArray.Count.Equals(0))
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.Clear();

                Console.WriteLine("\nSorry, there is no recipes " +
                    "saved at the moment", Console.ForegroundColor);

                Console.ResetColor();

                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("\nDelete Recipe" +
                              "\n-------------\n", Console.ForegroundColor);

            Console.ResetColor();

            DisplayRecipeNameList();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Type Recipe option that must be deleted: ", Console.ForegroundColor);

            Console.ResetColor();

            int DeleteOption = 0;

            Boolean Valid = true;

            do
            {
                try
                {
                    Valid = true;

                    DeleteOption = int.Parse(Console.ReadLine());

                    if ((RecipeArray.Count() - 1) < DeleteOption)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Valid = false;

                        Console.WriteLine("\nSorry, you did not " +
                            "enter a valid option. Please try again.", Console.ForegroundColor);

                        Console.ResetColor();
                    }
                }
                catch (FormatException)
                {
                    Valid = false;

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("\nSorry, you did not " +
                        "enter a valid Option. Please try again.", Console.ForegroundColor);

                    Console.ResetColor();
                }
            } while (Valid.Equals(false));

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("\nAre you sure you want to delete. "
                            + "\n(1) Yes"
                            + "\n(2) No", Console.ForegroundColor);

            Console.ResetColor();

            int Option = 0;

            do
            {
                try
                {             
                    Valid = true;

                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.WriteLine("Choose an option:", Console.ForegroundColor);

                    Console.ResetColor();

                    Option = int.Parse(Console.ReadLine());

                    if (Option < 1 || Option > 2)
                    {
                        Valid = false;
                    }
                }
                catch (FormatException)
                {
                    Valid = false;

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("\nSorry, you did not enter " +
                        "a valid Option. Please try again.", Console.ForegroundColor);

                    Console.ResetColor();
                }
            } while (Valid.Equals(false));

            if (Option.Equals(1))
            {
                RecipeArray.Remove(RecipeArray[DeleteOption]);
            }
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Scale Up Recipe
        /// If user selects recipe option that does not exist system will ask again
        /// If user selects invalid recipe option system will ask again
        /// Method keeps looping till user terminates
        /// </summary>
        public void ScaleUp()
        {
            if (RecipeArray.Count.Equals(0))
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("\nSorry, there is no recipes " +
                    "saved at the moment", Console.ForegroundColor);

                Console.ResetColor();

                return;
            }

            Boolean Control = false; 

            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine("\nScale Up Recipe" +
                              "\n-------------\n", Console.ForegroundColor);

                Console.ResetColor();

                Boolean Valid = true;

                int ScaleOption = 0;

                int RecipeOption = 0;

                DisplayRecipeNameList();

                do
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.WriteLine("\nSelect Recipe " +
                            "option to Scale up: ", Console.ForegroundColor);

                        Console.ResetColor();

                        Valid = true;

                        RecipeOption = int.Parse(Console.ReadLine());

                        if ((RecipeArray.Count() - 1) < RecipeOption)
                        {
                            Valid = false;

                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine("\nSorry, you did not " +
                                "enter a valid option. Please try again.", Console.ForegroundColor);

                            Console.ResetColor();
                        }
                    }
                    catch (FormatException)
                    {
                        Valid = false;
                        
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("\nSorry, you did not " +
                            "enter a valid Option. Please try again.", Console.ForegroundColor);

                        Console.ResetColor();
                    }

                } while (Valid.Equals(false));

                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("\n (1) Half 0.5"
                            + "\n (2) Double 2"
                            + "\n (3) Triple"
                            + "\n (4) Reset"
                            + "\n (5) Go back to menu\n", Console.ForegroundColor);

                Console.ResetColor();

                do
                {
                    try
                    {
                        Valid = true;

                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.WriteLine("Select Scale up Options bellow:", Console.ForegroundColor);

                        Console.ResetColor();

                        ScaleOption = int.Parse(Console.ReadLine());

                        if (ScaleOption < 1 || ScaleOption > 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine("\nSorry, you did not " +
                                "enter a valid Option. Please try again.", Console.ForegroundColor);

                            Console.ResetColor();

                            Valid = false;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Valid = false;

                        Console.WriteLine("\nSorry, you did not " +
                            "enter a valid Option. Please try again.", Console.ForegroundColor);

                        Console.ResetColor();
                    }

                } while (Valid.Equals(false));

                switch (ScaleOption)
                {
                    case 1:
                        ScaleUpCalc(RecipeOption, 0.5);

                        break;
                    case 2:
                        ScaleUpCalc(RecipeOption, 2);

                        break;
                    case 3:
                        ScaleUpCalc(RecipeOption, 3);

                        break;
                    case 4:
                        ScaleUpCalc(RecipeOption, 1);

                        break;
                    case 5:
                        Control = true;

                        break;
                }
            } while (Control.Equals(false));
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to do calculations for Scale
        /// Method converts tbs to cup if value of tbs bigger than 16 and vice versa
        /// Method also displays result of calculations
        /// Ing Quantity is converted to only one decimal place
        /// </summary>
        public void ScaleUpCalc(int Option, double Constant)
        {
            int IngredientsArrayLength = this.RecipeArray[Option].IngredientsArray.Count;

            for (int i = 0; i < IngredientsArrayLength; i++)
            {
                string IngName = this.RecipeArray[Option].IngredientsArray[i].IngredientName;

                double IngQuantity = (this.RecipeArray[Option].IngredientsArray[i].IngredientQuantity) * Constant;
                
                string IngUnit = this.RecipeArray[Option].IngredientsArray[i].UnitOfMeasurement;

                if ((IngQuantity < 1) && IngUnit.Equals("C"))
                {
                    double IngQuantityCalc = IngQuantity * 16;

                    IngQuantity = IngQuantityCalc;

                    IngUnit = "tbsp";
                }

                if ((IngQuantity >= 16) && IngUnit.Equals("tbsp"))
                {
                    double IngQuantityCalc = IngQuantity / 16;

                    IngQuantity = IngQuantityCalc;

                    IngUnit = "C";
                }

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("\nIngredient " + (i + 1) + " : "
                    + IngName + " -> "
                    + IngQuantity.ToString("0.0") + " "
                    + IngUnit, Console.ForegroundColor);

                Console.ResetColor();
            }
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to sum all calories in Recipe
        /// Method receives index from RecipeArray List to sum up ingredients
        /// loops thru list to sum all values 
        /// </summary>
        public int SumCalories(int Index, List<RecipeClass> RecipeArray)
        {
           int Sum = 0;

           for (int i = 0; i < RecipeArray[Index].IngredientsArray.Count; i++)
           {
                Sum = Sum + RecipeArray[Index].IngredientsArray[i].IngredientCalories;              
           }
            return Sum;
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to send message to user using delegates
        /// Delegate is declared and message is passed to method
        /// </summary>
        public void CaloriesWarning()
        {
            MyDelegate UserMessage = new MyDelegate(DisplayMessage);

            UserMessage("\n--> Recipe Exceeds 300 Calories <--\nNote: High Caloric food can lead to weigth gain");
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Displays message to User
        /// </summary>
        /// <param name="Message"></param>
        public void DisplayMessage(string Message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine(Message, Console.ForegroundColor);

            Console.ResetColor();
        }
    }
}
//---------------------------------------------------------< END >-----------------------------------------------------//


