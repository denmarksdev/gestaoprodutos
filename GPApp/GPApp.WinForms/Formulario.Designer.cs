namespace GPApp.WinForms
{
    partial class Formulario
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
            this.components = new System.ComponentModel.Container();
            this.produtoImagemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.produtoEspecificacaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.produtoImagemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoEspecificacaoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // produtoImagemBindingSource
            // 
            this.produtoImagemBindingSource.DataSource = typeof(GPApp.Model.ProdutoImagem);
            // 
            // produtoEspecificacaoBindingSource
            // 
            this.produtoEspecificacaoBindingSource.DataSource = typeof(GPApp.Model.ProdutoEspecificacao);
            // 
            // Formulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 850);
            this.Name = "Formulario";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.Text = "Erros";
            ((System.ComponentModel.ISupportInitialize)(this.produtoImagemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoEspecificacaoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource produtoImagemBindingSource;
        private System.Windows.Forms.BindingSource produtoEspecificacaoBindingSource;
    }
}