
/// <summary>
/// Filename: Program.cs
/// Created on: 2024-03-16 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

using Assignment4.Forms;

namespace Assignment4
{
    public partial class FormMain : Form
    {
        #region Fields
        private const int maxNumOfElements = 100;
        private const int maxNumOfIngredients = 20;
        private RecipeManager recipeManager = new RecipeManager(maxNumOfElements);
        private Recipe currRecipe;
        #endregion
        #region Properties
        public static int MaxNumOfIngredients
        {
            get
            {
                return maxNumOfIngredients;
            }
        }
        public static int MaxNumOfElements
        {
            get
            {
                return maxNumOfElements;
            }
        }
        #endregion
        #region Constructors
        public FormMain()
        {
            InitializeComponent();
            currRecipe = new Recipe(MaxNumOfIngredients);
            InitializeGUI();
        }
        #endregion
        #region Initializers
        /// <summary>
        /// Init GUI
        /// </summary>
        public void InitializeGUI()
        {
            cmbFoodCategory.Items.Clear();
            cmbFoodCategory.DataSource = Enum.GetValues(typeof(FoodCategory));
            txtNameRecipe.Text = currRecipe.Name;
            txtDescription.Text = currRecipe.Description;
            btnEditFinish.Enabled = false;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Update GUI
        /// </summary>
        private void UpdateGUI()
        {
            lstRecipe.Items.Clear();
            recipeManager.RecipeListToListBox(lstRecipe);
            txtNameRecipe.Text = currRecipe.Name;
            txtDescription.Text = currRecipe.Description;
        }

        /// <summary>
        /// Clear selection
        /// </summary>
        private void ClearSelection()
        {
            lstRecipe.SelectedIndex = -1;

            ResetCreateNewRecipe();

            UpdateGUI();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            FormIngredients formIngredient = new FormIngredients(currRecipe);
            formIngredient.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            //FIXED: Add checks before blindly adding stuff

            try
            {
                if (string.IsNullOrEmpty(currRecipe.Name))
                {
                    throw new InvalidOperationException("Enter a recipe name!");
                }

                if (currRecipe.CurrentNumberOfIngredients() <= 0)
                {
                    throw new InvalidOperationException("There are no ingredients in your recipe!");
                }

                if (currRecipe.Description.Length <= 0)
                {
                    throw new InvalidOperationException("Please add some instructions how to make your recipe!");
                }

                recipeManager.Add(currRecipe.Name, currRecipe.Category, currRecipe.Ingredients, currRecipe.Description);

                cmbFoodCategory.SelectedIndex = 0;

                currRecipe = new Recipe(MaxNumOfIngredients);

                UpdateGUI();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            try
            {
                currRecipe.Description = txtDescription.Text;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstRecipe_DoubleClick(object sender, EventArgs e)
        {
            if (lstRecipe.SelectedIndex < 0)
            {
                return; //Maybe you clicked on an empty line in the list?
            }

            FormRecipe formRecipe = new FormRecipe(recipeManager.GetRecipeAt(lstRecipe.SelectedIndex));
            formRecipe.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditStart_Click(object sender, EventArgs e)
        {
            lstRecipe.Enabled = false;
            btnEditStart.Enabled = false;
            btnEditFinish.Enabled = true;
            btnAddRecipe.Enabled = false;
            currRecipe = recipeManager.GetRecipeAt(lstRecipe.SelectedIndex);
            txtDescription.Text = currRecipe.Description;
            txtNameRecipe.Text = currRecipe.Name;
            cmbFoodCategory.SelectedIndex = (int)currRecipe.Category;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditFinish_Click(object sender, EventArgs e)
        {
            recipeManager.ChangeElementAtIndex(lstRecipe.SelectedIndex, currRecipe);
            ResetCreateNewRecipe();

            UpdateGUI();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ResetCreateNewRecipe()
        {
            currRecipe = new Recipe(MaxNumOfIngredients);
            cmbFoodCategory.SelectedIndex = 0;
            btnAddRecipe.Enabled = true;
            btnEditStart.Enabled = true;
            btnEditFinish.Enabled = false;
            lstRecipe.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNameRecipe_TextChanged(object sender, EventArgs e)
        {
            try
            {
                currRecipe.Name = txtNameRecipe.Text;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFoodCategory.SelectedIndex >= 0)
            {
                FoodCategory foodCategory;
                foodCategory = (FoodCategory)cmbFoodCategory.SelectedIndex;
                currRecipe.Category = foodCategory;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            recipeManager.DeleteElement(lstRecipe.SelectedIndex);
            UpdateGUI();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearSelection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDescription_MouseClick(object sender, MouseEventArgs e)
        {
            txtDescription.SelectAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDescription_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtNameRecipe.SelectAll();
        }
        #endregion
    }
}
