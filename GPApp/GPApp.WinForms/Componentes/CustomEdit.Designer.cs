namespace GPApp.WinForms.Componentes
{
    partial class CustomEdit
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.panelLabel = new System.Windows.Forms.Panel();
            this.labelErro = new System.Windows.Forms.Label();
            this.materialLabel = new MaterialSkin.Controls.MaterialLabel();
            this.materialSingleLineTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.metroPanel2.SuspendLayout();
            this.panelLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.panelLabel);
            this.metroPanel2.Controls.Add(this.materialSingleLineTextField);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(0, 0);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(806, 49);
            this.metroPanel2.TabIndex = 6;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // panelLabel
            // 
            this.panelLabel.BackColor = System.Drawing.Color.White;
            this.panelLabel.Controls.Add(this.labelErro);
            this.panelLabel.Controls.Add(this.materialLabel);
            this.panelLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLabel.Location = new System.Drawing.Point(0, 0);
            this.panelLabel.Name = "panelLabel";
            this.panelLabel.Size = new System.Drawing.Size(806, 23);
            this.panelLabel.TabIndex = 3;
            // 
            // labelErro
            // 
            this.labelErro.AutoSize = true;
            this.labelErro.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelErro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelErro.ForeColor = System.Drawing.Color.Red;
            this.labelErro.Location = new System.Drawing.Point(45, 0);
            this.labelErro.Name = "labelErro";
            this.labelErro.Size = new System.Drawing.Size(37, 18);
            this.labelErro.TabIndex = 1;
            this.labelErro.Text = "Erro";
            // 
            // materialLabel
            // 
            this.materialLabel.AutoSize = true;
            this.materialLabel.Depth = 0;
            this.materialLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.materialLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel.Location = new System.Drawing.Point(0, 0);
            this.materialLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel.Name = "materialLabel";
            this.materialLabel.Size = new System.Drawing.Size(45, 19);
            this.materialLabel.TabIndex = 0;
            this.materialLabel.Text = "Label";
            // 
            // materialSingleLineTextField
            // 
            this.materialSingleLineTextField.BackColor = System.Drawing.Color.White;
            this.materialSingleLineTextField.Depth = 0;
            this.materialSingleLineTextField.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.materialSingleLineTextField.Hint = "";
            this.materialSingleLineTextField.ImeMode = System.Windows.Forms.ImeMode.On;
            this.materialSingleLineTextField.Location = new System.Drawing.Point(0, 26);
            this.materialSingleLineTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField.Name = "materialSingleLineTextField";
            this.materialSingleLineTextField.PasswordChar = '\0';
            this.materialSingleLineTextField.SelectedText = "";
            this.materialSingleLineTextField.SelectionLength = 0;
            this.materialSingleLineTextField.SelectionStart = 0;
            this.materialSingleLineTextField.Size = new System.Drawing.Size(806, 23);
            this.materialSingleLineTextField.TabIndex = 2;
            this.materialSingleLineTextField.Text = "Edit";
            this.materialSingleLineTextField.UseSystemPasswordChar = false;
            // 
            // CustomEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.metroPanel2);
            this.Name = "CustomEdit";
            this.Size = new System.Drawing.Size(806, 49);
            this.metroPanel2.ResumeLayout(false);
            this.panelLabel.ResumeLayout(false);
            this.panelLabel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel2;
        private System.Windows.Forms.Panel panelLabel;
        private System.Windows.Forms.Label labelErro;
        private MaterialSkin.Controls.MaterialLabel materialLabel;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField;
    }
}
