using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data; 

using System.Windows.Forms;
using EasyDatabase;

namespace EasyDatabase.MSAccess
{

    /// <summary>
    /// Provides a list of either all Access Tables or Queries.  
    /// </summary>
    public class AccessSystemDataGridView : DataGridView
    {

        protected const string TABLE_HEADER = "TABLE";
        protected const string QUERY_HEADER = "QUERY";

        /// <summary>
        /// Get and display the database schema; either tables (including system tables) or queries.
        /// </summary>
        /// <param name="db">The specified database</param>
        /// <param name="collection">The type to return.  Use AccessDatabaseCollections object to parameterise</param>
        public void GetSchema(IDatabase db, string collection)
        {
            this.DataSource = db.GetSchema(collection);

            foreach (DataGridViewColumn col in this.Columns)
            {
                if (col.Name == NameColumnHeader(collection))
                {
                    col.HeaderText = GetHeaderText(collection);
                }
                else
                {
                    col.Visible = false;
                }
            }
        }

        private string NameColumnHeader(string collection)
        {
            return CollectionTypeNonPlural(collection) + "_NAME";
        }

        private string TypeColumnHeader(string collection)
        {
            return CollectionTypeNonPlural(collection)  + "_TYPE";
        }


        private string CollectionTypeNonPlural(string collection)
        {
            return collection.Substring(0, collection.Length - 1).ToUpper();
        }


        private string GetHeaderText(string collection){
            if(collection == AccessDatabaseCollections.Tables){
                return TABLE_HEADER;
            }
            else{
                return QUERY_HEADER;
            }
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // AccessSystemDataGridView
            // 
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToOrderColumns = true;
            this.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.RowHeadersVisible = false;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }


  

}
