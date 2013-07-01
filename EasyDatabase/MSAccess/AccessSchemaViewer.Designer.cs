namespace EasyDatabase.MSAccess
{
    partial class AccessSchemaViewer
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
            this.accessObjectDataGridView1 = new EasyDatabase.MSAccess.AccessObjectDataGridView();
            this.accessSystemDataGridView1 = new EasyDatabase.MSAccess.AccessSystemDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.accessObjectDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accessSystemDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // accessObjectDataGridView1
            // 
            this.accessObjectDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.accessObjectDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accessObjectDataGridView1.Location = new System.Drawing.Point(304, 3);
            this.accessObjectDataGridView1.Name = "accessObjectDataGridView1";
            this.accessObjectDataGridView1.Size = new System.Drawing.Size(289, 200);
            this.accessObjectDataGridView1.TabIndex = 1;
            this.accessObjectDataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.accessObjectDataGridView1_CellClick);
            // 
            // accessSystemDataGridView1
            // 
            this.accessSystemDataGridView1.AllowUserToAddRows = false;
            this.accessSystemDataGridView1.AllowUserToDeleteRows = false;
            this.accessSystemDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.accessSystemDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.accessSystemDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accessSystemDataGridView1.Location = new System.Drawing.Point(3, 3);
            this.accessSystemDataGridView1.Name = "accessSystemDataGridView1";
            this.accessSystemDataGridView1.RowHeadersVisible = false;
            this.accessSystemDataGridView1.Size = new System.Drawing.Size(295, 200);
            this.accessSystemDataGridView1.TabIndex = 0;
            this.accessSystemDataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.accessSystemDataGridView1_CellClick_1);
            // 
            // AccessSchemaViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.accessObjectDataGridView1);
            this.Controls.Add(this.accessSystemDataGridView1);
            this.Name = "AccessSchemaViewer";
            this.Size = new System.Drawing.Size(597, 206);
            ((System.ComponentModel.ISupportInitialize)(this.accessObjectDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accessSystemDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AccessSystemDataGridView accessSystemDataGridView1;
        private AccessObjectDataGridView accessObjectDataGridView1;
    }
}
