using System;
using System.Data;
using System.Data.SqlClient;

namespace Csharp_ADO.NET_MSSQL_Example
{
    public class Database
    {
        protected SqlConnection Cs = new SqlConnection("Data Source=(local); Initial Catalog=DbName; Integrated Security=TRUE");
        protected SqlDataAdapter Da = new SqlDataAdapter();
        public DataSet UpdateDataGridView(string sqlCommand)
        {
            Cs.Open();
            DataSet ds = new DataSet();
            Da.SelectCommand = new SqlCommand(sqlCommand, Cs);
            ds.Clear();
            Da.Fill(ds);
            Cs.Close();
            return ds;
            //dataGridView.DataSource = ds.Tables[0]; // to show
        }

        public void BackupDb(string dbName, string path)
        {
            Cs.Open();
            string sql = "BACKUP DATABASE " + dbName + " TO DISK = '" + path + "\\" + dbName + "-" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".bak'";
            var cmd = new SqlCommand(sql, Cs);
            cmd.ExecuteNonQuery();
            Cs.Close();
        }

        public void RestoreDb(string dbName, string path)
        {
            Cs.Open();
            string sql = "Alter Database " + dbName + " Set SINGLE_USER WITH ROLLBACK IMMEDIATE;";
            sql += "Restore Database " + dbName + " FROM Disk = '" + path + "' WITH REPLACE;";
            var cmd = new SqlCommand(sql, Cs);
            cmd.ExecuteNonQuery();
            Cs.Close();
        }

        public void Delete(int rowNumber, string tableName, string idName) // Alternative way to delete row from table. rowNumber != id
        {
            Cs.Open();
            var cmd =
                new SqlCommand("WITH newtbl as(SELECT *, 'row number'=ROW_NUMBER() over (order by " + idName + ") FROM " + tableName + ")" +
                               "delete from newtbl where [row number] = " + rowNumber, Cs);
            cmd.ExecuteNonQuery();
            Cs.Close();
        }
        public DataTable CmbGetValues(string tableName, string idName, string valueName) // Getting rows for comboBox. Works only for tables with 2 values (id, value)
        {
            Cs.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from " + tableName + " order by " + idName, Cs);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow row = dt.NewRow();
            row[valueName] = "";
            dt.Rows.InsertAt(row, 0);
            Cs.Close();
            return dt;

            /*
            metroComboBoxgridMassif.DataSource = SqlOperations.GetMassifNames();
            metroComboBoxgridMassif.ValueMember = "id_mas";
            metroComboBoxgridMassif.DisplayMember = "massif";
             */
        }

        public DataTable CmbGetValues() // Getting rows for comboBox. Works for tables with many values
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT Marshroots.*, Towns.town+' '+stoim_dost+' '+JD_tarif AS Description FROM Marshroots, Towns WHERE Towns.id_town = Marshroots.id_town", Cs);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}