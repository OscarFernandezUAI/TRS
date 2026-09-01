namespace GUI_517OF
{
    partial class FormPrincipal_517OF
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            pnlFooter = new Panel();
            treeMenu = new TreeView();
            pnlSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.Controls.Add(pnlFooter);
            pnlSidebar.Controls.Add(treeMenu);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Margin = new Padding(3, 4, 3, 4);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(250, 691);
            pnlSidebar.TabIndex = 1;
            // 
            // pnlFooter
            // 
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 616);
            pnlFooter.Margin = new Padding(3, 4, 3, 4);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(250, 75);
            pnlFooter.TabIndex = 1;
            // 
            // treeMenu
            // 
            treeMenu.Dock = DockStyle.Fill;
            treeMenu.Location = new Point(0, 0);
            treeMenu.Margin = new Padding(3, 4, 3, 4);
            treeMenu.Name = "treeMenu";
            treeMenu.Size = new Size(250, 691);
            treeMenu.TabIndex = 0;
            // 
            // FormPrincipal_517OF
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 691);
            Controls.Add(pnlSidebar);
            IsMdiContainer = true;
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1000, 600);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            pnlSidebar.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.TreeView treeMenu;
        private System.Windows.Forms.Panel pnlFooter;
    }
}

