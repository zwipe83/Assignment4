namespace Assignment4
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpAddRecipe = new GroupBox();
            txtDescription = new TextBox();
            btnAddRecipe = new Button();
            btnAddIngredient = new Button();
            cmbFoodCategory = new ComboBox();
            lblCategory = new Label();
            txtNameRecipe = new TextBox();
            lblNameRecipe = new Label();
            lstRecipe = new ListBox();
            btnEditStart = new Button();
            btnEditFinish = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            lblInstructions = new Label();
            lblListRecipe = new Label();
            lblListCategory = new Label();
            lblListNumIngredients = new Label();
            grpAddRecipe.SuspendLayout();
            SuspendLayout();
            // 
            // grpAddRecipe
            // 
            grpAddRecipe.Controls.Add(txtDescription);
            grpAddRecipe.Controls.Add(btnAddRecipe);
            grpAddRecipe.Controls.Add(btnAddIngredient);
            grpAddRecipe.Controls.Add(cmbFoodCategory);
            grpAddRecipe.Controls.Add(lblCategory);
            grpAddRecipe.Controls.Add(txtNameRecipe);
            grpAddRecipe.Controls.Add(lblNameRecipe);
            grpAddRecipe.Location = new Point(12, 12);
            grpAddRecipe.Name = "grpAddRecipe";
            grpAddRecipe.Size = new Size(365, 426);
            grpAddRecipe.TabIndex = 0;
            grpAddRecipe.TabStop = false;
            grpAddRecipe.Text = "Add new recipe";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(6, 91);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(353, 300);
            txtDescription.TabIndex = 7;
            txtDescription.TextChanged += txtDescription_TextChanged;
            // 
            // btnAddRecipe
            // 
            btnAddRecipe.Location = new Point(6, 397);
            btnAddRecipe.Name = "btnAddRecipe";
            btnAddRecipe.Size = new Size(353, 23);
            btnAddRecipe.TabIndex = 6;
            btnAddRecipe.Text = "Add Recipe";
            btnAddRecipe.UseVisualStyleBackColor = true;
            btnAddRecipe.Click += btnAddRecipe_Click;
            // 
            // btnAddIngredient
            // 
            btnAddIngredient.Location = new Point(205, 62);
            btnAddIngredient.Name = "btnAddIngredient";
            btnAddIngredient.Size = new Size(154, 23);
            btnAddIngredient.TabIndex = 4;
            btnAddIngredient.Text = "Add Ingredients";
            btnAddIngredient.UseVisualStyleBackColor = true;
            btnAddIngredient.Click += btnAddIngredient_Click;
            // 
            // cmbFoodCategory
            // 
            cmbFoodCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFoodCategory.FormattingEnabled = true;
            cmbFoodCategory.Location = new Point(65, 62);
            cmbFoodCategory.Name = "cmbFoodCategory";
            cmbFoodCategory.Size = new Size(134, 23);
            cmbFoodCategory.TabIndex = 3;
            cmbFoodCategory.SelectedIndexChanged += cmbFoodCategory_SelectedIndexChanged;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(6, 65);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(55, 15);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Category";
            // 
            // txtNameRecipe
            // 
            txtNameRecipe.Location = new Point(120, 29);
            txtNameRecipe.Name = "txtNameRecipe";
            txtNameRecipe.Size = new Size(239, 23);
            txtNameRecipe.TabIndex = 1;
            txtNameRecipe.TextChanged += txtNameRecipe_TextChanged;
            // 
            // lblNameRecipe
            // 
            lblNameRecipe.AutoSize = true;
            lblNameRecipe.Location = new Point(6, 32);
            lblNameRecipe.Name = "lblNameRecipe";
            lblNameRecipe.Size = new Size(88, 15);
            lblNameRecipe.TabIndex = 0;
            lblNameRecipe.Text = "Name of recipe";
            // 
            // lstRecipe
            // 
            lstRecipe.FormattingEnabled = true;
            lstRecipe.ItemHeight = 15;
            lstRecipe.Location = new Point(383, 44);
            lstRecipe.Name = "lstRecipe";
            lstRecipe.Size = new Size(671, 334);
            lstRecipe.TabIndex = 1;
            lstRecipe.DoubleClick += lstRecipe_DoubleClick;
            // 
            // btnEditStart
            // 
            btnEditStart.Location = new Point(383, 384);
            btnEditStart.Name = "btnEditStart";
            btnEditStart.Size = new Size(75, 23);
            btnEditStart.TabIndex = 2;
            btnEditStart.Text = "Edit-Begin";
            btnEditStart.UseVisualStyleBackColor = true;
            btnEditStart.Click += btnEditStart_Click;
            // 
            // btnEditFinish
            // 
            btnEditFinish.Location = new Point(560, 384);
            btnEditFinish.Name = "btnEditFinish";
            btnEditFinish.Size = new Size(75, 23);
            btnEditFinish.TabIndex = 3;
            btnEditFinish.Text = "Edit-Finish";
            btnEditFinish.UseVisualStyleBackColor = true;
            btnEditFinish.Click += btnEditFinish_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(754, 384);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(928, 384);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(126, 23);
            btnClear.TabIndex = 5;
            btnClear.Text = "Clear Selection";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // lblInstructions
            // 
            lblInstructions.AutoSize = true;
            lblInstructions.Location = new Point(607, 417);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new Size(198, 15);
            lblInstructions.TabIndex = 6;
            lblInstructions.Text = "Double click an item for instructions";
            // 
            // lblListRecipe
            // 
            lblListRecipe.AutoSize = true;
            lblListRecipe.Location = new Point(420, 12);
            lblListRecipe.Name = "lblListRecipe";
            lblListRecipe.Size = new Size(39, 15);
            lblListRecipe.TabIndex = 7;
            lblListRecipe.Text = "Name";
            // 
            // lblListCategory
            // 
            lblListCategory.AutoSize = true;
            lblListCategory.Location = new Point(697, 12);
            lblListCategory.Name = "lblListCategory";
            lblListCategory.Size = new Size(55, 15);
            lblListCategory.TabIndex = 8;
            lblListCategory.Text = "Category";
            // 
            // lblListNumIngredients
            // 
            lblListNumIngredients.Location = new Point(974, 9);
            lblListNumIngredients.Name = "lblListNumIngredients";
            lblListNumIngredients.Size = new Size(80, 32);
            lblListNumIngredients.TabIndex = 9;
            lblListNumIngredients.Text = "Number of ingredients";
            lblListNumIngredients.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1066, 450);
            Controls.Add(lblListNumIngredients);
            Controls.Add(lblListCategory);
            Controls.Add(lblListRecipe);
            Controls.Add(lblInstructions);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnEditFinish);
            Controls.Add(btnEditStart);
            Controls.Add(lstRecipe);
            Controls.Add(grpAddRecipe);
            Name = "FormMain";
            Text = "Recipe Book by Samuel Jeffman";
            grpAddRecipe.ResumeLayout(false);
            grpAddRecipe.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpAddRecipe;
        private Button btnAddIngredient;
        private ComboBox cmbFoodCategory;
        private Label lblCategory;
        private TextBox txtNameRecipe;
        private Label lblNameRecipe;
        private Button btnAddRecipe;
        private ListBox lstRecipe;
        private Button btnEditStart;
        private Button btnEditFinish;
        private Button btnDelete;
        private Button btnClear;
        private Label lblInstructions;
        private Label lblListRecipe;
        private Label lblListCategory;
        private Label lblListNumIngredients;
        private TextBox txtDescription;
    }
}