namespace Assignment4.Forms
{
    partial class FormIngredients
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
            grpIngredient = new GroupBox();
            lstIngredients = new ListBox();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            txtNameIngredient = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            lblNumIngredients = new Label();
            lblCurrNumber = new Label();
            grpIngredient.SuspendLayout();
            SuspendLayout();
            // 
            // grpIngredient
            // 
            grpIngredient.Controls.Add(lstIngredients);
            grpIngredient.Controls.Add(btnDelete);
            grpIngredient.Controls.Add(btnEdit);
            grpIngredient.Controls.Add(btnAdd);
            grpIngredient.Controls.Add(txtNameIngredient);
            grpIngredient.Location = new Point(12, 47);
            grpIngredient.Name = "grpIngredient";
            grpIngredient.Size = new Size(506, 351);
            grpIngredient.TabIndex = 0;
            grpIngredient.TabStop = false;
            grpIngredient.Text = "Ingredient";
            // 
            // lstIngredients
            // 
            lstIngredients.FormattingEnabled = true;
            lstIngredients.ItemHeight = 15;
            lstIngredients.Location = new Point(6, 64);
            lstIngredients.Name = "lstIngredients";
            lstIngredients.Size = new Size(391, 274);
            lstIngredients.TabIndex = 5;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(412, 111);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(412, 64);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(412, 22);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtNameIngredient
            // 
            txtNameIngredient.Location = new Point(6, 22);
            txtNameIngredient.Name = "txtNameIngredient";
            txtNameIngredient.Size = new Size(391, 23);
            txtNameIngredient.TabIndex = 0;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(150, 418);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 1;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(305, 418);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblNumIngredients
            // 
            lblNumIngredients.AutoSize = true;
            lblNumIngredients.Location = new Point(12, 24);
            lblNumIngredients.Name = "lblNumIngredients";
            lblNumIngredients.Size = new Size(127, 15);
            lblNumIngredients.TabIndex = 3;
            lblNumIngredients.Text = "Number of ingredients";
            // 
            // lblCurrNumber
            // 
            lblCurrNumber.AutoSize = true;
            lblCurrNumber.Location = new Point(493, 24);
            lblCurrNumber.Name = "lblCurrNumber";
            lblCurrNumber.Size = new Size(25, 15);
            lblCurrNumber.TabIndex = 4;
            lblCurrNumber.Text = "000";
            // 
            // FormIngredients
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(530, 453);
            Controls.Add(lblCurrNumber);
            Controls.Add(lblNumIngredients);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(grpIngredient);
            Name = "FormIngredients";
            Text = "FormIngredients";
            grpIngredient.ResumeLayout(false);
            grpIngredient.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpIngredient;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnAdd;
        private TextBox txtNameIngredient;
        private Button btnOK;
        private Button btnCancel;
        private Label lblNumIngredients;
        private Label lblCurrNumber;
        private ListBox lstIngredients;
    }
}