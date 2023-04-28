using System;
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
        public string RecipeName { get; set; } = string.Empty;

        /// <summary>
        /// Store the recipe number of steps
        /// </summary>
        public int NumberOfSteps { get; set; } = 0;

        /// <summary>
        /// Will store a description of each step in Recipe
        /// </summary>
        public string StepDescription { get; set; } = string.Empty;
        
        /// <summary>
        /// Instance of Ingredients class
        /// </summary>
        public IngredientsClass Ingredients = new IngredientsClass();

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
        public string[] StepArray = new string[50];

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
        /// Method that calls methods 
        /// Asks user for Number of Ingredients and call method to get an ingredient detail
        /// Will loop for the number of ingredient specified
        /// Loop for amount of steps and keeps asking for description and store in StepArray
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
            Ingredients.GetNumberOfIngredients();

            for (int i = 0; i < Ingredients.NumberOfIngredients; i++)
            {
                var NewIngredient = new IngredientsClass();

                Console.WriteLine("\nIngredient " + (i + 1) + 
                                  "\n------------\n");

                NewIngredient.GetIngredientDetails();
                NewIngredient.NumberOfIngredients = Ingredients.NumberOfIngredients;
                NewIngredient.IngredientName = Ingredients.IngredientName;
                NewIngredient.IngredientQuantity = Ingredients.IngredientQuantity;
                NewIngredient.UnitOfMeasurement = Ingredients.UnitOfMeasurement;

                IngredientsArray.Add(NewIngredient);
            }

            Console.WriteLine("\nType number of Steps" +
                              "\n--------------------");
            
            GetNumberOfSteps();

            for (int i = 0; i < this.NumberOfSteps; i++)
            {
                Console.WriteLine("\nStep " + (i + 1));
                GetStepDescription();
                StepArray[i] = this.StepDescription;
            }
        }

        //---------------------------------------------------------------------------------------//
        /// <summary>
        /// Calls method that gets user Inputs and Stores Object In RecipeArray
        /// Stores Ingredient and step array in recipe array
        /// </summary>
        public void StoreRecipeData()
        {
            var NewRecipe = new RecipeClass();

            GetRecipe();

            NewRecipe.RecipeName = this.RecipeName;
            NewRecipe.NumberOfSteps = this.NumberOfSteps;
            NewRecipe.StepArray = this.StepArray;
            NewRecipe.IngredientsArray = this.IngredientsArray;

            RecipeArray.Add(NewRecipe);
        }

        /// <summary>
        /// Displays Recipe to User
        /// Ask user for Recipe Option
        /// </summary>
        public int GetRecipeData()
        {
            Console.WriteLine("\nDisplay Recipe" +
                              "\n--------------\n");
            var ArrayLength = this.RecipeArray.Count;

            for (int i = 0; i < ArrayLength ;i++) 
            {
                var RecipName = this.RecipeArray[i].RecipeName;

                Console.WriteLine( " (" + (i + 1) + ") " + this.RecipeName);
            }

            Boolean Valid = true;

            int Option = 0;

            do
            {
                try
                {
                    Console.WriteLine("\nType option number from above recipes to diplay: ");
                    Option = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Valid = false;
                    Console.WriteLine("Sorry, you did not enter a valid Recipe. Please try again.");
                }
            } while (!Valid);

            return Option;
        }

        /// <summary>
        /// Display recipe information
        /// </summary>
        public void DisplayRecipeData(int Option)
        {
            
            
            DisplayIngredientData(Option);

            int StepArrayLength = this.RecipeArray[Option].StepArray.Length;
                 
            for (int i = 0; i < StepArrayLength; i++)
            {
                Console.WriteLine("\nStep " + (i +1) + " :" + this.StepArray[i]);
            }



        }

        /// <summary>
        /// 
        /// </summary>
        public void DisplayRecipeDName(int Option)
        {
            Console.WriteLine("\nRecipe name :" + this.RecipeArray[Option].RecipeName );
        }

        /// <summary>
        /// Display Ingredients details
        /// </summary>
        public void DisplayIngredientData(int Option)
        { Console.WriteLine()   a
            for (int i = 0; i < this.RecipeArray[Option].IngredientsArray.Count; i++)
            {
                Console.WriteLine("Ingredient name " + (i + 1) + ": " + this.RecipeArray[Option].IngredientsArray[i].IngredientName);
                Console.WriteLine("Ingredient Quantity: " 
                    + this.RecipeArray[Option].IngredientsArray[i].IngredientQuantity 
                    + " " + this.RecipeArray[Option].IngredientsArray[i].UnitOfMeasurement);
            }
        }
    }
}
//---------------------------------------------------------< END >-----------------------------------------------------//

