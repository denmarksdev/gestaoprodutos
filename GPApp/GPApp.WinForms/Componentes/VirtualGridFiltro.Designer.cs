namespace GPApp.WinForms.Componentes
{
    partial class VirtualGridFiltro
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroPanelFiltro = new MetroFramework.Controls.MetroPanel();
            this.metroTextBoxPequisa = new MetroFramework.Controls.MetroTextBox();
            this.metroButtonPesquisar = new MetroFramework.Controls.MetroButton();
            this.tableLayoutPanelGrid = new System.Windows.Forms.TableLayoutPanel();
            this.htmlLabelRodape = new MetroFramework.Drawing.Html.HtmlLabel();
            this.virtualGridPrincipal = new GPApp.WinForms.Componentes.VirtualGrid();
            this.metroPanelGrid = new MetroFramework.Controls.MetroPanel();
            this.metroPanelFiltro.SuspendLayout();
            this.tableLayoutPanelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.virtualGridPrincipal)).BeginInit();
            this.metroPanelGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanelFiltro
            // 
            this.metroPanelFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanelFiltro.Controls.Add(this.metroTextBoxPequisa);
            this.metroPanelFiltro.Controls.Add(this.metroButtonPesquisar);
            this.metroPanelFiltro.HorizontalScrollbarBarColor = true;
            this.metroPanelFiltro.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanelFiltro.HorizontalScrollbarSize = 10;
            this.metroPanelFiltro.Location = new System.Drawing.Point(96, 153);
            this.metroPanelFiltro.Name = "metroPanelFiltro";
            this.metroPanelFiltro.Size = new System.Drawing.Size(493, 26);
            this.metroPanelFiltro.TabIndex = 1;
            this.metroPanelFiltro.VerticalScrollbarBarColor = true;
            this.metroPanelFiltro.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanelFiltro.VerticalScrollbarSize = 10;
            // 
            // metroTextBoxPequisa
            // 
            // 
            // 
            // 
            this.metroTextBoxPequisa.CustomButton.Image = null;
            this.metroTextBoxPequisa.CustomButton.Location = new System.Drawing.Point(394, 2);
            this.metroTextBoxPequisa.CustomButton.Name = "";
            this.metroTextBoxPequisa.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxPequisa.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxPequisa.CustomButton.TabIndex = 1;
            this.metroTextBoxPequisa.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxPequisa.CustomButton.UseSelectable = true;
            this.metroTextBoxPequisa.CustomButton.Visible = false;
            this.metroTextBoxPequisa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTextBoxPequisa.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.metroTextBoxPequisa.Lines = new string[0];
            this.metroTextBoxPequisa.Location = new System.Drawing.Point(0, 0);
            this.metroTextBoxPequisa.MaxLength = 32767;
            this.metroTextBoxPequisa.Name = "metroTextBoxPequisa";
            this.metroTextBoxPequisa.PasswordChar = '\0';
            this.metroTextBoxPequisa.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxPequisa.SelectedText = "";
            this.metroTextBoxPequisa.SelectionLength = 0;
            this.metroTextBoxPequisa.SelectionStart = 0;
            this.metroTextBoxPequisa.ShortcutsEnabled = true;
            this.metroTextBoxPequisa.Size = new System.Drawing.Size(418, 26);
            this.metroTextBoxPequisa.TabIndex = 2;
            this.metroTextBoxPequisa.UseSelectable = true;
            this.metroTextBoxPequisa.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxPequisa.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButtonPesquisar
            // 
            this.metroButtonPesquisar.Dock = System.Windows.Forms.DockStyle.Right;
            this.metroButtonPesquisar.Location = new System.Drawing.Point(418, 0);
            this.metroButtonPesquisar.Name = "metroButtonPesquisar";
            this.metroButtonPesquisar.Size = new System.Drawing.Size(75, 26);
            this.metroButtonPesquisar.TabIndex = 3;
            this.metroButtonPesquisar.Text = "Pesquisar";
            this.metroButtonPesquisar.UseSelectable = true;
            this.metroButtonPesquisar.Click += new System.EventHandler(this.MetroButtonPesquisar_Click);
            // 
            // tableLayoutPanelGrid
            // 
            this.tableLayoutPanelGrid.ColumnCount = 1;
            this.tableLayoutPanelGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelGrid.Controls.Add(this.htmlLabelRodape, 0, 1);
            this.tableLayoutPanelGrid.Controls.Add(this.metroPanelGrid, 0, 0);
            this.tableLayoutPanelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelGrid.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelGrid.Name = "tableLayoutPanelGrid";
            this.tableLayoutPanelGrid.RowCount = 2;
            this.tableLayoutPanelGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelGrid.Size = new System.Drawing.Size(678, 304);
            this.tableLayoutPanelGrid.TabIndex = 2;
            // 
            // htmlLabelRodape
            // 
            this.htmlLabelRodape.AutoScroll = true;
            this.htmlLabelRodape.AutoScrollMinSize = new System.Drawing.Size(71, 23);
            this.htmlLabelRodape.AutoSize = false;
            this.htmlLabelRodape.BackColor = System.Drawing.SystemColors.Window;
            this.htmlLabelRodape.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlLabelRodape.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.htmlLabelRodape.Location = new System.Drawing.Point(3, 272);
            this.htmlLabelRodape.Name = "htmlLabelRodape";
            this.htmlLabelRodape.Size = new System.Drawing.Size(672, 29);
            this.htmlLabelRodape.TabIndex = 1;
            this.htmlLabelRodape.Text = "Informações";
            // 
            // virtualGridPrincipal
            // 
            this.virtualGridPrincipal.AllowUserToAddRows = false;
            this.virtualGridPrincipal.AllowUserToDeleteRows = false;
            this.virtualGridPrincipal.AllowUserToResizeColumns = false;
            this.virtualGridPrincipal.AllowUserToResizeRows = false;
            this.virtualGridPrincipal.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.virtualGridPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.virtualGridPrincipal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.virtualGridPrincipal.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(94)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.virtualGridPrincipal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.virtualGridPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.virtualGridPrincipal.ColunaChave = null;
            this.virtualGridPrincipal.ConsultaAction = null;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.virtualGridPrincipal.DefaultCellStyle = dataGridViewCellStyle11;
            this.virtualGridPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.virtualGridPrincipal.EnableHeadersVisualStyles = false;
            this.virtualGridPrincipal.ErroPaginacao = false;
            this.virtualGridPrincipal.ErroPagincaoAction = null;
            this.virtualGridPrincipal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.virtualGridPrincipal.GetValue = null;
            this.virtualGridPrincipal.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.virtualGridPrincipal.Inicializa = null;
            this.virtualGridPrincipal.Location = new System.Drawing.Point(0, 0);
            this.virtualGridPrincipal.Name = "virtualGridPrincipal";
            this.virtualGridPrincipal.OrderAction = null;
            this.virtualGridPrincipal.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.virtualGridPrincipal.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.virtualGridPrincipal.RowHeadersVisible = false;
            this.virtualGridPrincipal.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.virtualGridPrincipal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.virtualGridPrincipal.Size = new System.Drawing.Size(672, 263);
            this.virtualGridPrincipal.TabIndex = 2;
            this.virtualGridPrincipal.VirtualMode = true;
            // 
            // metroPanelGrid
            // 
            this.metroPanelGrid.Controls.Add(this.metroPanelFiltro);
            this.metroPanelGrid.Controls.Add(this.virtualGridPrincipal);
            this.metroPanelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanelGrid.HorizontalScrollbarBarColor = true;
            this.metroPanelGrid.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanelGrid.HorizontalScrollbarSize = 10;
            this.metroPanelGrid.Location = new System.Drawing.Point(3, 3);
            this.metroPanelGrid.Name = "metroPanelGrid";
            this.metroPanelGrid.Size = new System.Drawing.Size(672, 263);
            this.metroPanelGrid.TabIndex = 2;
            this.metroPanelGrid.VerticalScrollbarBarColor = true;
            this.metroPanelGrid.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanelGrid.VerticalScrollbarSize = 10;
            // 
            // VirtualGridFiltro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanelGrid);
            this.Name = "VirtualGridFiltro";
            this.Size = new System.Drawing.Size(678, 304);
            this.metroPanelFiltro.ResumeLayout(false);
            this.tableLayoutPanelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.virtualGridPrincipal)).EndInit();
            this.metroPanelGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanelFiltro;
        private MetroFramework.Controls.MetroButton metroButtonPesquisar;
        private MetroFramework.Controls.MetroTextBox metroTextBoxPequisa;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGrid;
        private MetroFramework.Drawing.Html.HtmlLabel htmlLabelRodape;
        private VirtualGrid virtualGridPrincipal;
        private MetroFramework.Controls.MetroPanel metroPanelGrid;
    }
}
