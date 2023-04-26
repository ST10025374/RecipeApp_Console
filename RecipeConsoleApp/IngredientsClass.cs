﻿using System;
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

                    if (Option < 1 || Option > 3)
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
    }
}
//---------------------------------------------------------< END >-----------------------------------------------------//
