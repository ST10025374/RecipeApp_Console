using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeConsoleApp
{
    public class RecipeClass
    {    /// Testing GitHub
         /// <summary>
         /// Array to Store Recipe Objects
         /// Can store Max of 10 Recipes
         /// </summary>
        RecipeClass[] RecipeArray = new RecipeClass[10];

        /// <summary>
        /// Array to Store Max of 20 Ingredients
        /// </summary>
        RecipeClass[] IngredientArray = new RecipeClass[10];

        /// <summary>
        /// Store the nmber of ingredients of each recipe
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

        //-------------------------------------------------------------------------------------------//
        /// <summary>
        /// Default Constructor
        /// </summary>
        public RecipeClass()
        {

        }

        //-------------------------------------------------------------------------------------------//
        /// <summary>
        /// Ask User for Number of Ingredients in Recipe and Store Input
        /// </summary>
        /// <param name="NumberOfIngredients"></param>
        public void GetNumberOfIngredients()
        {
            Console.WriteLine("Enter the amount of ingredients in the recipe: ");
            this.NumberOfIngredients = Convert.ToInt16(Console.ReadLine());
        }

        //-------------------------------------------------------------------------------------------//
        /// <summary>
        /// Ask User for Ingredient Name in Recipe and Store Input
        /// </summary>
        public void GetIngredientName()
        {
            Console.WriteLine("Enter the name of the ingredient: ");
            this.IngredientName = Console.ReadLine();
        }

        //-------------------------------------------------------------------------------------------//
        /// <summary>
        /// Ask User for Ingredient Quantity and Store Input
        /// </summary>
        public void GetIngredientQuantity()
        {
            Console.WriteLine("Enter the quantity of the ingredient: ");
            this.IngredientQuantity = Convert.ToDouble(Console.ReadLine());
        }

        //-------------------------------------------------------------------------------------------//
        /// <summary>
        /// Ask User for Unit of Measurement and Store
        /// </summary>
        public void GetUnitOfMeasurement()
        {
            Console.WriteLine("Enter the unit of measurement: ");
            this.UnitOfMeasurement = Console.ReadLine();
        }

        //-------------------------------------------------------------------------------------------//
        /// <summary>
        /// Ask User for recipe steps amount
        /// </summary>
        public void GetNumberOfSteps()
        {
            Console.WriteLine("Enter the amount of steps in the recipe: ");
            this.NumberOfSteps = Convert.ToInt16(Console.ReadLine());
        }

        //-------------------------------------------------------------------------------------------//
        /// <summary>
        /// Ask User step description
        /// </summary>
        public void GetStepDescription()
        {
            Console.WriteLine("Enter the description of step: ");
            this.StepDescription = Console.ReadLine();
        }

        //-------------------------------------------------------------------------------------------//
        /// <summary>
        /// Ask User for Ingredients Details and call other methods for Input 
        /// </summary>
        public void GetIngredientDetails()
        {//----------------> try input validation Try & Catch <-------------//
            Console.WriteLine("-- Type Ingredient Details --");
            GetIngredientName();
            GetUnitOfMeasurement();
            GetIngredientQuantity();
        }

        //-------------------------------------------------------------------------------------------//
        /// <summary>
        /// Call methods 
        /// Ask user for Number of Ingredients and loop calling method to get all details
        /// Loop for amount of steps keep asking for description
        /// </summary>
        public void GetRecipe()
        {
            Console.WriteLine("-- Enter Recipe information bellow --");//-----> Add Color to text <-----//
            GetNumberOfIngredients();

            for (int i = 0; i < this.NumberOfIngredients; i++)
            {//----------------> try Try & Catch <-------------//
                var Ingredient = new RecipeClass();
                Console.WriteLine("-- Ingredient " + i + " --");
                GetIngredientDetails();
                IngredientArray[i].Equals(Ingredient);
                // Try another way without object
            }

            Console.WriteLine("-- Type number of Steps --");
            GetNumberOfSteps();

            for (int i = 0; i < this.NumberOfSteps; i++)
            {
                Console.WriteLine("Step " + (i + 1));
                GetStepDescription();
                // ---> Store In Array <-----//
            }
        }

        //-----------------------------------------------------------------------------------//
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

