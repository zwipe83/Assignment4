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
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnOK.Enabled = false;
            AddIngredients(CurrRecipe);
            UpdateGUI();
        }
        #endregion
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int CountIngredients()
        {
            int count = 0;
            foreach (var ingredient in lstIngredients.Items)
            {
                if (!string.IsNullOrEmpty((string)ingredient))
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstIngredients.Enabled)
                {
                    lstIngredients.Items.Add(txtNameIngredient.Text ?? throw new ArgumentNullException(nameof(txtNameIngredient.Name), "Input string cannot be null or empty.")); //TODO: Verify exception
                    lstIngredients.SelectedIndex = 0;
                }
                else
                {
                    //FIXED: Maybe null check?
                    if (IngredientIndex >= 0 && IngredientIndex < lstIngredients.Items.Count)
                    {
                        lstIngredients.Items[IngredientIndex] = txtNameIngredient.Text ?? throw new ArgumentNullException(nameof(txtNameIngredient.Name), "Input string cannot be null or empty.");
                        lstIngredients.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                        btnAdd.Text = "Add";
                        lstIngredients.SelectedIndex = 0;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("Index is out of range");
                    }
                }
                txtNameIngredient.Text = String.Empty;
                UpdateGUI();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Recipe recipe = new Recipe(FormMain.MaxNumOfIngredients);

                foreach (var ingredient in lstIngredients.Items)
                {
                    if (!string.IsNullOrEmpty((string)ingredient))
                    {
                        recipe.AddIngredient((string)ingredient, out int lastIndex);
                    }
                    else
                    {
                        throw new ArgumentNullException(nameof(sender), "Input string cannot be null or empty.");
                    }
                }

                CurrRecipe.Ingredients = recipe.Ingredients;
                recipe.Dispose(); //TODO: Most likely not needed
                Close();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            lstIngredients.Items.RemoveAt(lstIngredients.SelectedIndex); //TODO: Check?
            txtNameIngredient.Text = String.Empty;
            UpdateGUI();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            lstIngredients.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Text = "Save";
            IngredientIndex = lstIngredients.SelectedIndex; //TODO: Maybe null check?
            txtNameIngredient.Text = lstIngredients?.SelectedItem?.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNameIngredient_TextChanged(object sender, EventArgs e)
        {
            if (txtNameIngredient.Text.Length > 0)
            {
                btnAdd.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = 0;
            foreach (var item in lstIngredients.Items)
            {
                if (item is not null)
                {
                    count++;
                }
            }

            if (count > 0)
            {
                btnOK.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnOK.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }
        #endregion
    }
}
