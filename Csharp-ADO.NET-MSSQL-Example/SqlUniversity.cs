using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Csharp_ADO.NET_MSSQL_Example
{
    public class SqlUniversity : Database, IAdoNetCommands
    {
        public void Insert(IModel model)
        {
            Cs.Open();
            University univer = model as University;
            if (univer != null)
            {
                Da.InsertCommand = new SqlCommand("IF NOT EXISTS(SELECT * FROM University WHERE Id = @Id and ShortName = @ShortName and FullName = @FullName) " +
                                                  "INSERT INTO University VALUES (@Id, @ShortName, @FullName)", Cs);
                Da.InsertCommand.Parameters.Add("@ShortName", SqlDbType.VarChar).Value = univer.ShortName;
                Da.InsertCommand.Parameters.Add("@FullName", SqlDbType.VarChar).Value = univer.FullName;
                Da.InsertCommand.ExecuteNonQuery();
            
            }
            else { throw new ArgumentException();}
            Cs.Close();
        }

        public void Update(IModel model)
        {
            Cs.Open();
            University univer = model as University;
            if (univer != null)
            {
                Da.UpdateCommand = new SqlCommand(" IF NOT EXISTS(SELECT * FROM University WHERE Id = @Id and ShortName = @ShortName and FullName = @FullName) " +
                                                  "UPDATE University SET Id = @Id, ShortName = @ShortName, FullName = @FullName WHERE Id = @Id", Cs);
                Da.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int).Value = univer.Id; // or comboBox1.SelectedValue;
                Da.UpdateCommand.Parameters.Add("@ShortName", SqlDbType.VarChar).Value = univer.ShortName;
                Da.UpdateCommand.Parameters.Add("@FullName", SqlDbType.VarChar).Value = univer.FullName;
                Da.UpdateCommand.ExecuteNonQuery();

            }
            else { throw new ArgumentException(); }
            Cs.Close();
        }

        public void Delete(IModel model)
        {
            Cs.Open();
            University univer = model as University;
            if (univer != null)
            {
                Da.DeleteCommand = new SqlCommand("IF  EXISTS  (SELECT * FROM University) DELETE FROM University WHERE Id = @Id", Cs);
                Da.DeleteCommand.Parameters.Add("Id", SqlDbType.Int).Value = univer.Id;
                Da.DeleteCommand.ExecuteNonQuery();
            }
            else { throw new ArgumentException(); }
            Cs.Close();


        }


        public List<IModel> ReadDataFromSqlTable()
        {
            List<IModel> listid = new List<IModel>();
            Cs.Open();
            SqlCommand cmd = new SqlCommand("Select * from University", Cs);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var tbl = new University(Convert.ToInt32(dr["Id"]),Convert.ToString(dr["ShortName"]),Convert.ToString(dr["FullName"]));
                listid.Add(tbl);

            }
            return listid;
        }

       
    }
}