/// <summary>
/// Filename: Program.cs
/// Created on: 2024-03-16 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 
namespace Assignment4.Forms
{
    public class Recipe
    {
        #region Fields
        private FoodCategory category;
        private string? description;
        private string[]? ingredients;
        private string? name;
        #endregion
        #region Constructors
        public Recipe(int maxNumOfIngredients)
        {
            DefaultValues(maxNumOfIngredients);
        }

        public Recipe(Recipe recipeToCopyFrom) //TODO: Remove?
        {
            category = recipeToCopyFrom.category;
            description = recipeToCopyFrom.description;
            ingredients = recipeToCopyFrom.ingredients;
            name = recipeToCopyFrom.name;
        }
        public Recipe(string name, FoodCategory category, string[] ingredients, string description)
        {
            try
            {
                Name = name;
                Category = category;
                Ingredients = ingredients;
                Description = description;
            }
            catch
            {
                throw;
            }
        }
        #endregion
        #region Properties
        public FoodCategory Category
        {
            get => category;
            set
            {
                category = value;
            }
        }

        public string Description
        {
            get => description;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    description = string.Empty;
                    throw new ArgumentException("Description can not be null or empty.");
                }
                description = value;
            }
        }

        public string[]? Ingredients
        {
            get => ingredients;
            set
            {
                if (value != null && value.Length > 0)
                {
                    ingredients = value;
                }
            }
        }

        public string? Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    name = string.Empty;
                    throw new ArgumentException("Name can not be null or empty.");
                }
                name = value;
            }
        }
        #endregion
        #region Methods

        /// <summary>
        /// Add an ingredient to current recipe
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool AddIngredient(string input) //FIXED: Is lastIndex needed?
        {
            bool ok = true;
            int index = FindVacantPosition();

            if (CheckIndex(index) && CheckInput(input))
            {
                Ingredients[index] = input; //FIXED: Maybe null check?
            }
            else
            {
                ok = false;
            }

            return ok;
        }

        /// <summary>
        /// Check for correct input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool CheckInput(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        /// <summary>
        /// Change an ingredient in a specific recipe
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ChangeIngredientAt(int index, string value)
        {
            bool ok = true;
            if (CheckIndex(index) && CheckInput(value))
            {
                Ingredients[index] = value;
            }
            else
            {
                ok = false;
            }

            return ok;
        }

        /// <summary>
        /// Check index is in range
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool CheckIndex(int index)
        {
            return (index >= 0 && index < Ingredients.Length);
        }

        /// <summary>
        /// Check Ingredients is not null
        /// </summary>
        /// <param name="ingredients"></param>
        /// <returns></returns>
        private bool CheckIngredients(string[] ingredients)
        {
            return (ingredients is not null);
        }

        /// <summary>
        /// Get current number of ingredients
        /// </summary>
        /// <returns></returns>
        public int CurrentNumberOfIngredients()
        {
            int count = 0;

            if (CheckIngredients(Ingredients))
            {
                foreach (var ingredient in Ingredients) //FIXED: Maybe add null check
                {
                    if (ingredient != null)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// Sets default values for recipe
        /// </summary>
        public void DefaultValues(int maxNumOfIngredients)
        {
            Name = "<Enter recipe name>";
            Category = FoodCategory.Meats;
            Description = "<Enter recipe descriptions>";
            Ingredients = new string[maxNumOfIngredients];
        }

        /// <summary>
        /// Delete an ingredient from a recipe
        /// </summary>
        /// <param name="index"></param>
        public void DeleteIngredientAt(int index)
        {
            if (CheckIndex(index) && CheckIngredients(Ingredients)) //FIXED: Maybe add null check
            {
                Ingredients[index] = null;
            }
        }

        /// <summary>
        /// Find first vacant(null) position in array
        /// </summary>
        /// <returns></returns>
        private int FindVacantPosition()
        {
            int index = -1;

            if (CheckIngredients(Ingredients))
            {
                for (int i = 0; i < Ingredients.Length; i++) //FIXED: Maybe add null check
                {
                    if (Ingredients[i] == null)
                    {
                        index = i;
                        break;
                    }
                }
            }

            return index;
        }

        /// <summary>
        /// Override for ToString()
        /// </summary>
        /// <returns>Name of recipe</returns>
        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
