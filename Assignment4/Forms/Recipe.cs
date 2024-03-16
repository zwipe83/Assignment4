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

namespace Assignment4.Forms
{
    internal class Recipe
    {
        private FoodCategory category;
        private string description;
        private string[] ingredients;
        private string name;

        public Recipe(int maxNumOfIngredients)
        {
            throw new System.NotImplementedException();
        }

        public FoodCategory Category
        {
            get => default;
            set
            {
            }
        }

        public string Description
        {
            get => default;
            set
            {
            }
        }

        public string[] Ingredients
        {
            get => default;
            set
            {
            }
        }

        public int MaxNumOfIngredients
        {
            get => default;
            set
            {
            }
        }

        public string Name
        {
            get => default;
            set
            {
            }
        }

        public bool AddIngredient(string input)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            throw new System.NotImplementedException();
        }
    }
}
