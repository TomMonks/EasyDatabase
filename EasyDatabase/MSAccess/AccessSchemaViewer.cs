using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using EasyDatabase;
using EasyDatabase.SQL;

namespace EasyDatabase.MSAccess
{
    public delegate void DataGridCellSelectedEventHandler(object sender, DataGridViewCellEventArgs args);
    
    public partial class AccessSchemaViewer : UserControl
    {
        public enum SchemaMode{
            Tables = 0,
            Queries = 1
        };

        public DataGridCellSelectedEventHandler OnTableSelectEvent;
        public DataGridCellSelectedEventHandler OnFieldSelectEvent;

        protected IDatabase db;

        public AccessSchemaViewer()
        {
            InitializeComponent();
            this.Mode = SchemaMode.Tables;
            
        }

        public SchemaMode Mode { get; set; }


       
        /// <summary>
        /// The MS Access table name selected
        /// </summary>
        public string TableName
        {
            get
            {
                return this.accessSystemDataGridView1.SelectedCells[0].Value.ToString();
            }
        }





        /// <summary>
        /// The MS Access table field selected
        /// </summary>
        public string FieldName
        {
            get
            {
                return this.accessObjectDataGridView1.SelectedCells[0].Value.ToString();
            }
        }

        public IDatabase Database
        {
            get
            {
                return db;
            }
            set
            {
                db = value;
            }
        }

        public void GetSchema()
        {

            if (this.Mode == SchemaMode.Tables)
            {
                this.accessSystemDataGridView1.GetSchema(db, AccessDatabaseCollections.Tables);
                
            }
            else
            {
                this.accessSystemDataGridView1.GetSchema(db, AccessDatabaseCollections.Queries);
            }

            if (this.accessSystemDataGridView1.Rows.Count > 0)
            {
                var tableName = "[" + this.accessSystemDataGridView1[2, 0].Value.ToString() + "]";
                
                GetObjectSchema(tableName);

                //this.accessObjectDataGridView1.DataSource = db.GetTableSchema(tableName);
                this.accessSystemDataGridView1[2, 0].Selected = true;
                if (null != this.OnTableSelectEvent)
                {
                    this.OnTableSelectEvent(this, new DataGridViewCellEventArgs(2,0));
                }
            }


        }


        private void accessSystemDataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            this.accessObjectDataGridView1.DataSource = null;
            var tableName = "[" + this.accessSystemDataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString() +"]";

            GetObjectSchema(tableName);
            //this.accessObjectDataGridView1.DataSource = db.GetTableSchema(tableName);

            if (null != this.OnTableSelectEvent)
            {
                this.OnTableSelectEvent(this, e);
            }
        }

        private void GetObjectSchema(string tableName)
        {
            
            var factory = new AccessObjectSQLFactory() { ObjectName = tableName };
            this.accessObjectDataGridView1.Database = db;
            this.accessObjectDataGridView1.Query = new StandardQueryBuilder(factory);
            this.accessObjectDataGridView1.Execute();
        }

        private void accessObjectDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (null != this.OnFieldSelectEvent)
            {
                this.OnFieldSelectEvent(this, e);
            }
        }

    }
}
