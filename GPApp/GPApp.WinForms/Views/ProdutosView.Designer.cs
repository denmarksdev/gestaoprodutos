using GPApp.WinForms.Componentes;

namespace GPApp.WinForms.Views
{
    partial class ProdutosView
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
            this.metroButtonFiltrar = new MetroFramework.Controls.MetroButton();
            this.metroButtonIncluir = new MetroFramework.Controls.MetroButton();
            this.metroButtonEmail = new MetroFramework.Controls.MetroButton();
            this.tabControlProdutos = new GPApp.WinForms.Componentes.TabControlCustom();
            this.tabPageListagem = new System.Windows.Forms.TabPage();
            this.metroPanelGrid = new MetroFramework.Controls.MetroPanel();
            this.tabPageEdicao = new System.Windows.Forms.TabPage();
            this.panelEditProduto = new System.Windows.Forms.Panel();
            this.tabControlProdutos.SuspendLayout();
            this.tabPageListagem.SuspendLayout();
            this.tabPageEdicao.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroButtonFiltrar
            // 
            this.metroButtonFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButtonFiltrar.Location = new System.Drawing.Point(195, 27);
            this.metroButtonFiltrar.Name = "metroButtonFiltrar";
            this.metroButtonFiltrar.Size = new System.Drawing.Size(113, 23);
            this.metroButtonFiltrar.TabIndex = 1;
            this.metroButtonFiltrar.Text = "Filtrar";
            this.metroButtonFiltrar.UseSelectable = true;
            // 
            // metroButtonIncluir
            // 
            this.metroButtonIncluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButtonIncluir.Location = new System.Drawing.Point(334, 27);
            this.metroButtonIncluir.Name = "metroButtonIncluir";
            this.metroButtonIncluir.Size = new System.Drawing.Size(75, 23);
            this.metroButtonIncluir.TabIndex = 4;
            this.metroButtonIncluir.Text = "Incluir";
            this.metroButtonIncluir.UseSelectable = true;
            this.metroButtonIncluir.Click += new System.EventHandler(this.MetroButtonIncluir_Click);
            // 
            // metroButtonEmail
            // 
            this.metroButtonEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroButtonEmail.Location = new System.Drawing.Point(415, 27);
            this.metroButtonEmail.Name = "metroButtonEmail";
            this.metroButtonEmail.Size = new System.Drawing.Size(75, 23);
            this.metroButtonEmail.TabIndex = 5;
            this.metroButtonEmail.Text = "Enviar email";
            this.metroButtonEmail.UseSelectable = true;
            this.metroButtonEmail.Click += new System.EventHandler(this.MetroButtonEmail_Click);
            // 
            // tabControlProdutos
            // 
            this.tabControlProdutos.Controls.Add(this.tabPageListagem);
            this.tabControlProdutos.Controls.Add(this.tabPageEdicao);
            this.tabControlProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlProdutos.Location = new System.Drawing.Point(20, 60);
            this.tabControlProdutos.Name = "tabControlProdutos";
            this.tabControlProdutos.SelectedIndex = 0;
            this.tabControlProdutos.Size = new System.Drawing.Size(984, 648);
            this.tabControlProdutos.TabIndex = 3;
            // 
            // tabPageListagem
            // 
            this.tabPageListagem.BackColor = System.Drawing.Color.White;
            this.tabPageListagem.Controls.Add(this.metroPanelGrid);
            this.tabPageListagem.Location = new System.Drawing.Point(4, 22);
            this.tabPageListagem.Name = "tabPageListagem";
            this.tabPageListagem.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageListagem.Size = new System.Drawing.Size(976, 622);
            this.tabPageListagem.TabIndex = 0;
            this.tabPageListagem.Text = "Listagem";
            // 
            // metroPanelGrid
            // 
            this.metroPanelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanelGrid.HorizontalScrollbarBarColor = true;
            this.metroPanelGrid.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanelGrid.HorizontalScrollbarSize = 10;
            this.metroPanelGrid.Location = new System.Drawing.Point(3, 3);
            this.metroPanelGrid.Name = "metroPanelGrid";
            this.metroPanelGrid.Size = new System.Drawing.Size(970, 616);
            this.metroPanelGrid.TabIndex = 2;
            this.metroPanelGrid.VerticalScrollbarBarColor = true;
            this.metroPanelGrid.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanelGrid.VerticalScrollbarSize = 10;
            // 
            // tabPageEdicao
            // 
            this.tabPageEdicao.BackColor = System.Drawing.Color.White;
            this.tabPageEdicao.Controls.Add(this.panelEditProduto);
            this.tabPageEdicao.Location = new System.Drawing.Point(4, 22);
            this.tabPageEdicao.Name = "tabPageEdicao";
            this.tabPageEdicao.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEdicao.Size = new System.Drawing.Size(976, 622);
            this.tabPageEdicao.TabIndex = 1;
            this.tabPageEdicao.Text = "Edição";
            // 
            // panelEditProduto
            // 
            this.panelEditProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEditProduto.Location = new System.Drawing.Point(3, 3);
            this.panelEditProduto.Name = "panelEditProduto";
            this.panelEditProduto.Size = new System.Drawing.Size(970, 616);
            this.panelEditProduto.TabIndex = 0;
            // 
            // ProdutosView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 728);
            this.Controls.Add(this.metroButtonEmail);
            this.Controls.Add(this.metroButtonIncluir);
            this.Controls.Add(this.tabControlProdutos);
            this.Controls.Add(this.metroButtonFiltrar);
            this.MinimumSize = new System.Drawing.Size(1024, 728);
            this.Name = "ProdutosView";
            this.Text = "ProdutosView";
            this.tabControlProdutos.ResumeLayout(false);
            this.tabPageListagem.ResumeLayout(false);
            this.tabPageEdicao.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanelGrid;
        private MetroFramework.Controls.MetroButton metroButtonFiltrar;
        private TabControlCustom tabControlProdutos;
        private System.Windows.Forms.TabPage tabPageListagem;
        private System.Windows.Forms.TabPage tabPageEdicao;
        private MetroFramework.Controls.MetroButton metroButtonIncluir;
        private MetroFramework.Controls.MetroButton metroButtonEmail;
        private System.Windows.Forms.Panel panelEditProduto;
    }
}