/// <summary>
/// Filename: Program.cs
/// Created on: 2024-03-16 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 
using static Assignment4.FormMain;

namespace Assignment4.Forms
{
    internal class RecipeManager
    {
        #region Fields
        private Recipe[] recipeList;
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public RecipeManager(int maxNumOfElements)
        {
            recipeList = new Recipe[maxNumOfElements];
        }
        public Recipe[] RecipeList
        {
            get => recipeList;
            set => recipeList = value;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Add recipe to array
        /// </summary>
        private bool Add(Recipe recipe)
        {
            int index = FindVacantPosition();
            if (index < 0)
                throw new IndexOutOfRangeException($"No vacant position for recipe found, array is full! Max count is: {MaxNumOfElements}");
            recipeList[index] = recipe;

            return true;
        }

        /// <summary>
        /// Add recipe to array
        /// </summary>
        public bool Add(string name, FoodCategory category, string[] ingredients, string description)
        {
            try
            {
                Add(new Recipe(name, category, ingredients, description));
                return true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Change element
        /// </summary>
        public void ChangeElementAtIndex(int index, Recipe recipe)
        {
            if (CheckIndex(index))
            {
                RecipeList[index] = recipe;
            }
            else
            {
                throw new IndexOutOfRangeException($"Invalid index({index}) when trying to change an element.");
            }
        }

        /// <summary>
        /// Check index
        /// </summary>
        private bool CheckIndex(int index)
        {
            return (index >= 0 && index < RecipeList.Length);
        }

        /// <summary>
        /// Delete element
        /// </summary>
        public void DeleteElement(int index)
        {
            if (CheckIndex(index))
            {
                RecipeList[index] = null;
                MoveElementsOneStepToLeft(index);
            }
            else
            {
                throw new IndexOutOfRangeException($"Invalid index({index}) when trying to delete an element.");
            }
        }

        /// <summary>
        /// Find vacant position
        /// </summary>
        private int FindVacantPosition()
        {
            return Array.IndexOf(RecipeList, null);
        }

        /// <summary>
        /// Get current number of recipes
        /// </summary>
        public int GetCurrentNumberOfRecipes()
        {
            int count = 0;

            for (int i = 0; i < RecipeList.Length; i++)
            {
                if (recipeList[i] != null)
                    count++;
            }
            return count;
        }

        /// <summary>
        /// Get recipe at
        /// </summary>
        public Recipe? GetRecipeAt(int index)
        {
            if (CheckIndex(index))
            {
                return recipeList[index];
            }
            else
            {
                throw new IndexOutOfRangeException($"Invalid index({index}) when trying to retreive an element.");
            }
        }

        /// <summary>
        /// Move elements one step to left
        /// </summary>
        private void MoveElementsOneStepToLeft(int index)
        {
            for (int i = index; i < RecipeList.Length - 1; i++)
            {
                RecipeList[i] = RecipeList[i + 1];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param _name="recipe"></param>
        /// <returns></returns>
        private int GetNumOfIngredients(Recipe recipe)
        {
            int ingredients = 0;

            foreach (var ingredient in recipe.Ingredients)
            {
                if (ingredient != null)
                {
                    ingredients++;
                }
            }

            return ingredients;
        }

        /// <summary>
        /// Recipe list to string
        /// </summary>
        public string RecipeListToString()
        {
            string infoString = String.Empty;

            for (int i = 0, j = 0; i < recipeList.Length; i++)
            {
                if (recipeList[i] != null)
                {
                    infoString += recipeList[i].ToString() + "\n";
                    j++;
                }
            }
            return infoString;
        }

        /// <summary>
        /// Recipe list to string
        /// </summary>
        public void RecipeListToListBox(ListBox listbox)
        {
            foreach (var recipe in recipeList)
            {
                if (recipe != null)
                {
                    listbox.Items.Add(string.Format("{0,-44} {1,-40} {2,5}", recipe.Name, recipe.Category, GetNumOfIngredients(recipe)));
                }
            }
        }
        #endregion
    }
}
