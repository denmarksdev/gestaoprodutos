namespace GPApp.WinForms.Componentes
{
    partial class DialogView
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
            this.materialLabelMensagem = new MaterialSkin.Controls.MaterialLabel();
            this.materialRaisedButtonSim = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButtonNao = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // materialLabelMensagem
            // 
            this.materialLabelMensagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabelMensagem.AutoSize = true;
            this.materialLabelMensagem.BackColor = System.Drawing.Color.White;
            this.materialLabelMensagem.Depth = 0;
            this.materialLabelMensagem.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabelMensagem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabelMensagem.Location = new System.Drawing.Point(12, 77);
            this.materialLabelMensagem.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabelMensagem.Name = "materialLabelMensagem";
            this.materialLabelMensagem.Size = new System.Drawing.Size(83, 19);
            this.materialLabelMensagem.TabIndex = 0;
            this.materialLabelMensagem.Text = "Mensagem";
            // 
            // materialRaisedButtonSim
            // 
            this.materialRaisedButtonSim.Depth = 0;
            this.materialRaisedButtonSim.Location = new System.Drawing.Point(12, 282);
            this.materialRaisedButtonSim.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButtonSim.Name = "materialRaisedButtonSim";
            this.materialRaisedButtonSim.Primary = true;
            this.materialRaisedButtonSim.Size = new System.Drawing.Size(79, 23);
            this.materialRaisedButtonSim.TabIndex = 1;
            this.materialRaisedButtonSim.Text = "Sim";
            this.materialRaisedButtonSim.UseVisualStyleBackColor = true;
            this.materialRaisedButtonSim.Click += new System.EventHandler(this.MaterialRaisedButtonSim_Click);
            // 
            // materialRaisedButtonNao
            // 
            this.materialRaisedButtonNao.Depth = 0;
            this.materialRaisedButtonNao.Location = new System.Drawing.Point(97, 282);
            this.materialRaisedButtonNao.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButtonNao.Name = "materialRaisedButtonNao";
            this.materialRaisedButtonNao.Primary = true;
            this.materialRaisedButtonNao.Size = new System.Drawing.Size(79, 23);
            this.materialRaisedButtonNao.TabIndex = 2;
            this.materialRaisedButtonNao.Text = "Não";
            this.materialRaisedButtonNao.UseVisualStyleBackColor = true;
            this.materialRaisedButtonNao.Click += new System.EventHandler(this.MaterialRaisedButton1_Click);
            // 
            // DialogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(514, 317);
            this.Controls.Add(this.materialRaisedButtonNao);
            this.Controls.Add(this.materialRaisedButtonSim);
            this.Controls.Add(this.materialLabelMensagem);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(514, 317);
            this.Name = "DialogView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DialogView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabelMensagem;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButtonSim;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButtonNao;
    }
}