﻿/// <summary>
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
        /// Add recipe
        /// </summary>
        public bool Add(Recipe recipe)
        {
            try
            {
                int index = FindVacantPosition();
                if (index < 0)
                    throw new IndexOutOfRangeException($"No vacant position for recipe found, array is full! Max count is: {MaxNumOfElements}");
                recipeList[index] = recipe;

                return true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Add recipe
        /// </summary>
        public bool Add(string name, FoodCategory category, string[] ingredients, string description)
        {
            try
            {
                Add(new Recipe(name, category, ingredients, description));
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
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
        }

        /// <summary>
        /// Find vacant position
        /// </summary>
        public int FindVacantPosition()
        {
            int index = -1;

            for (int i = 0; i < RecipeList.Length; i++)
            {
                if (RecipeList[i] == null)
                {
                    index = i;
                    break;
                }
            }
            return index;
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
            return null;
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
        /// <param name="recipe"></param>
        /// <returns></returns>
        public int GetNumOfIngredients(Recipe recipe)
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
                    listbox.Items.Add($"{recipe.Name}\t\t\t{recipe.Category}\t\t\t{GetNumOfIngredients(recipe)}");
                }
            }
        }
        #endregion
    }
}
