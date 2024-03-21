/// <summary>
/// Filename: Program.cs
/// Created on: 2024-03-16 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Assignment4.Forms
{
    public class Recipe
    {
        private FoodCategory category;
        private string? description;
        private string[] ingredients;
        private string? name;

        public Recipe(int maxNumOfIngredients)
        {
            ingredients = new string[maxNumOfIngredients];
        }

        public Recipe(Recipe objToCopyFrom)
        {
            category = objToCopyFrom.category;
            description = objToCopyFrom.description;
            ingredients = objToCopyFrom.ingredients;
            name = objToCopyFrom.name;
        }
        public Recipe(string name, FoodCategory category, string[] ingredients)
        {
            this.name = name;
            this.category = category;
            this.ingredients = ingredients;
        }

        public FoodCategory Category
        {
            get => category;
            set
            {
                if(typeof(Recipe).IsAssignableFrom(value.GetType()))
                {
                    category = value;
                }
            }
        }

        public string Description
        {
            get => description;
            set
            {
                if(typeof(string).IsAssignableFrom(value.GetType()))
                {  
                    description = value; 
                }
            }
        }

        public string[] Ingredients
        {
            get => ingredients;
            set
            {
                if (typeof(string[]).IsAssignableFrom(value.GetType()))
                {
                    ingredients = value;
                }
            }
        }

        public int MaxNumOfIngredients
        {
            get => ingredients.Length;
        }

        public string Name
        {
            get => name;
            set
            {
                if(typeof(string).IsAssignableFrom(value.GetType()))
                {
                    name = value;
                }
            }
        }

        public bool AddIngredient(string input, out int lastIndex)
        {
            bool ok = true;
            int index = FindVacantPosition();

            if ((index >= 0) && (input != null) && (input != String.Empty))
            {
                ingredients[index] = input;
            }
            else
                ok = false;

            lastIndex = index;

            return ok;
        }

        public bool ChangeIngredientAt(int index, string value)
        {
            throw new System.NotImplementedException();
        }

        private bool CheckIndex(int index)
        {
            throw new System.NotImplementedException();
        }

        public int CurrentNumberOfIngredients()
        {
            throw new System.NotImplementedException();
        }

        public void DefaultValues()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteIngredientAt(int index)
        {
            throw new System.NotImplementedException();
        }

        private int FindVacantPosition()
        {
            int index = -1;

            for (int i = 0; i < ingredients.Length; i++)
            {
                if (ingredients[i] == null)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
