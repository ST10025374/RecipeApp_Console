﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace RecipeConsoleApp
{
    public class RecipeClass
    {    
        /// <summary>
        /// Store recipe name
        /// </summary>
        private string RecipeName { get; set; } = string.Empty;

        /// <summary>
        /// Store the number of ingredients of each recipe
        /// </summary>
        private int NumberOfIngredients { get; set; } = 0;

        /// <summary>
        /// Store Ingredient Name
        /// </summary>
        private string IngredientName { get; set; } = string.Empty;

        /// <summary>
        /// Store Ingredient Quantity
        /// </summary>
        private double IngredientQuantity { get; set; } = 0.0;

        /// <summary>
        /// Store Ingredient Unit Of Measurement
        /// </summary>
        private string UnitOfMeasurement { get; set; } = string.Empty;

        /// <summary>
        /// Store the recipe number of steps
        /// </summary>
        private int NumberOfSteps { get; set; } = 0;

        /// <summary>
        /// Will store a description of each step in Recipe
        /// </summary>
        private string StepDescription { get; set; } = string.Empty;

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
                    Console.WriteLine("Enter the name of the recipe: ");
                    this.RecipeName = Console.ReadLine();
                }
                catch (FormatException)
                {
                    Valid = false;
                    Console.WriteLine("Sorry, you did not enter a valid name. Please try again.");
                }
            } while (!Valid);
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
                    Console.WriteLine("Enter the amount of ingredients in the recipe: ");
                    this.NumberOfIngredients = int.Parse(Console.ReadLine()); 
                }
                catch (FormatException)
                {
                    Valid = false;
                    Console.WriteLine("Sorry, you did not enter a valid number. Please try again.");
                }
            } while (!Valid);
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
                    Console.WriteLine("Enter the name of the ingredient: ");
                    this.IngredientName = Console.ReadLine();
                }
                catch (FormatException)
                {
                    Valid = false;
                    Console.WriteLine("Sorry, you did not enter a valid name. Please try again.");
                }
            } while (!Valid);
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
                    Console.WriteLine("Enter the quantity of the ingredient: ");
                    this.IngredientQuantity = double.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Valid = false;
                    Console.WriteLine("Sorry, you did not enter a valid number. Please try again.");
                }
            } while (!Valid);
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
                    Console.WriteLine("Select the unit of measurement by typing the option number: \n" +
                              "[1] Gram (g) \n" +
                              "[2] Tablespoon (tbsp) \n" +
                              "[3] Cup (c)");

                    Option = int.Parse(Console.ReadLine());

                    if(Option < 1 || Option > 3)
                    {
                        Valid = false;
                    }
                }
                catch (FormatException)
                {
                    Valid = false;
                    Console.WriteLine("Sorry, you did not select a valid option. Please try again.");
                }
            } while (!Valid);
          
            switch (Option)
            {
                case 1:
                    this.UnitOfMeasurement = "grams";
                    break;                  
                case 2:
                    this.UnitOfMeasurement = "tablespoons";
                    break;
                case 3:
                    this.UnitOfMeasurement = "cups";
                    break;
            }         
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
                    Console.WriteLine("Enter the amount of steps in the recipe: ");
                    this.NumberOfSteps = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Valid = false;
                    Console.WriteLine("Sorry, you did not enter a valid number. Please try again.");
                }
            } while (!Valid);
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
            //try to loop for amount of steps including numeration when asking user for input
            do
            {
                try
                {
                    Console.WriteLine("Enter the description of step: ");
                    this.StepDescription = Console.ReadLine();
                }
                catch (FormatException)
                {
                    Valid = false;
                    Console.WriteLine("Sorry, you did not enter a valid description. Please try again.");
                }
            } while (!Valid);   
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Ask User for Ingredients Details calling methods to get Inputs
        /// </summary>
        public void GetIngredientDetails()
        {
            Console.WriteLine("\nType Ingredient Details" +
                              "\n-----------------------\n");
            GetIngredientName();
            GetUnitOfMeasurement();
            GetIngredientQuantity();
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Method that calls methods 
        /// Asks user for Number of Ingredients and call method to get an ingredient detail
        /// Will loop for the number of ingredient specified
        /// Loop for amount of steps and keeps asking for description
        /// </summary>
        public void GetRecipe()
        {
            //Recipe must be stored in array (object array)
            //Ingredient also in separate array (object array or 2D)
            //And this array store in recipe object
            //Steps also mst be stored in array (string 1D array)

            Console.WriteLine("\nEnter Recipe information bellow" +
                              "\n-------------------------------\n");
            //-----> Add Color to text <-----//
            
            GetRecipeName();
            GetNumberOfIngredients();

            for (int i = 0; i < this.NumberOfIngredients; i++)
            {
                //-- Add ingredient details to object to be stored in Array --//
                Console.WriteLine("\nIngredient " + (i + 1) + 
                                  "\n------------\n");
                GetIngredientDetails();
            }

            Console.WriteLine("\nType number of Steps" +
                              "\n--------------------");
            
            GetNumberOfSteps();

            for (int i = 0; i < this.NumberOfSteps; i++)
            {
                Console.WriteLine("\nStep " + (i + 1));
                GetStepDescription();
                // ---> Store In Array <-----//
            }
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Calls method that gets user Inputs and Stores Object In Array 
        /// </summary>
        public void StoreRecipeData()
        {
            var Recipe = new RecipeClass();

            GetRecipe();
            //--------> Look For Solution <--------//
            RecipeArray[0].Equals(Recipe);
            //var unit RecipeArray[0].UnitOfMeasurement;
        }

    }
}
//---------------------------------------------------------< END >-----------------------------------------------------//

