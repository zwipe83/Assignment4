/// <summary>
/// Filename: Program.cs
/// Created on: 2024-03-16 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

namespace Assignment4.Forms
{
    public partial class FormIngredients : Form
    {
        #region Fields
        private Recipe _currRecipe;
        private int _ingredientIndex;
        #endregion
        #region Properties
        private Recipe CurrRecipe
        {
            get { return _currRecipe; }
            set { _currRecipe = value; }
        }
        public int IngredientIndex
        {
            get { return _ingredientIndex; }
            set { _ingredientIndex = value; }
        }
        #endregion
        #region Constructors
        public FormIngredients(Recipe recipe)
        {
            InitializeComponent();

            CurrRecipe = recipe;

            InitializeGUI();
        }
        #endregion
        #region Initializers
        /// <summary>
        /// Init GUI
        /// </summary>
        public void InitializeGUI()
        {
            AddIngredients(CurrRecipe);
            UpdateGUI();
        }
        #endregion
        #region Methods
        private void AddIngredients(Recipe recipe)
        {
            foreach (string ingredient in recipe.Ingredients)
            {
                if (ingredient != null)
                {
                    lstIngredients.Items.Add(ingredient);
                }
            }
        }

        private int CountIngredients()
        {
            int count = 0;
            foreach (var ingredient in lstIngredients.Items)
            {
                if (ingredient != null)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Update GUI
        /// </summary>
        private void UpdateGUI()
        {
            lblCurrNumber.Text = CountIngredients().ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lstIngredients.Enabled)
            {
                lstIngredients.Items.Add(txtNameIngredient.Text);
            } 
            else
            {
                lstIngredients.Items[IngredientIndex] = txtNameIngredient.Text;
                lstIngredients.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnAdd.Text = "Add";
            }
            txtNameIngredient.Text = String.Empty;
            UpdateGUI();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Recipe recipe = new Recipe(FormMain.MaxNumOfIngredients);
            int lastIndex;

            foreach (var ingredient in lstIngredients.Items)
            {
                if(ingredient != null)
                {
                    recipe.AddIngredient(ingredient?.ToString(),out lastIndex);
                }
            }

            CurrRecipe.Ingredients = recipe.Ingredients;
            recipe.Dispose();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lstIngredients.Items.RemoveAt(lstIngredients.SelectedIndex);
            txtNameIngredient.Text = String.Empty;
            UpdateGUI();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            lstIngredients.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Text = "Save";
            IngredientIndex = lstIngredients.SelectedIndex;
            txtNameIngredient.Text = lstIngredients?.SelectedItem?.ToString();
        }
        #endregion
    }
}
