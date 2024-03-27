
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
        #endregion
        #region Constructors
        public FormMain()
        {
            InitializeComponent();
            currRecipe = new Recipe(maxNumOfIngredients);
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
        }

        /// <summary>
        /// Clear selection
        /// </summary>
        private void ClearSelection()
        {
            throw new System.NotImplementedException(); //TODO: Not sure what this is supposed to do.
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
            //TODO: Add checks before blindly adding stuff
            recipeManager.Add(currRecipe.Name, currRecipe.Category, currRecipe.Ingredients, currRecipe.Description);

            UpdateGUI();

            txtDescription.Text = String.Empty;
            txtNameRecipe.Text = String.Empty;
            cmbFoodCategory.SelectedIndex = 0;

            currRecipe = new Recipe(maxNumOfIngredients);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            currRecipe.Description = txtDescription.Text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstRecipe_DoubleClick(object sender, EventArgs e)
        {
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
            currRecipe = new Recipe(maxNumOfIngredients);
            txtNameRecipe.Text = String.Empty;
            txtDescription.Text = String.Empty;
            cmbFoodCategory.SelectedIndex = 0;
            btnAddRecipe.Enabled = true;
            btnEditStart.Enabled = true;
            btnEditFinish.Enabled = false;
            lstRecipe.Enabled = true;

            UpdateGUI();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNameRecipe_TextChanged(object sender, EventArgs e)
        {
            //TODO: Null check
            currRecipe.Name = txtNameRecipe.Text;
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
        #endregion
    }
}
