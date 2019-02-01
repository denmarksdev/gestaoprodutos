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
            this.metroTextBoxEdit = new MetroFramework.Controls.MetroTextBox();
            this.panelLabel = new System.Windows.Forms.Panel();
            this.labelErro = new System.Windows.Forms.Label();
            this.materialLabel = new MaterialSkin.Controls.MaterialLabel();
            this.metroPanel2.SuspendLayout();
            this.panelLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.metroTextBoxEdit);
            this.metroPanel2.Controls.Add(this.panelLabel);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(0, 0);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(806, 44);
            this.metroPanel2.TabIndex = 6;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroTextBoxEdit
            // 
            // 
            // 
            // 
            this.metroTextBoxEdit.CustomButton.Image = null;
            this.metroTextBoxEdit.CustomButton.Location = new System.Drawing.Point(784, 1);
            this.metroTextBoxEdit.CustomButton.Name = "";
            this.metroTextBoxEdit.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxEdit.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxEdit.CustomButton.TabIndex = 1;
            this.metroTextBoxEdit.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxEdit.CustomButton.UseSelectable = true;
            this.metroTextBoxEdit.CustomButton.Visible = false;
            this.metroTextBoxEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroTextBoxEdit.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.metroTextBoxEdit.Lines = new string[0];
            this.metroTextBoxEdit.Location = new System.Drawing.Point(0, 21);
            this.metroTextBoxEdit.MaxLength = 32767;
            this.metroTextBoxEdit.Name = "metroTextBoxEdit";
            this.metroTextBoxEdit.PasswordChar = '\0';
            this.metroTextBoxEdit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxEdit.SelectedText = "";
            this.metroTextBoxEdit.SelectionLength = 0;
            this.metroTextBoxEdit.SelectionStart = 0;
            this.metroTextBoxEdit.ShortcutsEnabled = true;
            this.metroTextBoxEdit.Size = new System.Drawing.Size(806, 23);
            this.metroTextBoxEdit.TabIndex = 4;
            this.metroTextBoxEdit.UseSelectable = true;
            this.metroTextBoxEdit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxEdit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
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
            // CustomEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.metroPanel2);
            this.Name = "CustomEdit";
            this.Size = new System.Drawing.Size(806, 44);
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
        private MetroFramework.Controls.MetroTextBox metroTextBoxEdit;
    }
}
