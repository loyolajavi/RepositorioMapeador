using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TFI.HelperDAL;

namespace TFI.DAL.DAL
{
	public class FormaPagoDAL
	{


        private string connectionStringName;
		

		#region Methods

		/// <summary>
		/// Saves a record to the FormaPago table.
		/// </summary>
        //public void Insert(FormaPagoEntidades formaPago)
        //{

        
        //    ValidationUtility.ValidateArgument("formaPago", formaPago);

        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //        new SqlParameter("@DescripFormaPago", formaPago.DescripFormaPago)
        //    };

        //    formaPago.IdFormaPago = (int) SqlClientUtility.ExecuteScalar("asdf", CommandType.StoredProcedure, "FormaPagoInsert", parameters);
        //    SqlClientUtility.ExecuteDataTable("asdf", CommandType.StoredProcedure, "FormaPagoInsert", parameters);

        //}



 		/// <summary>
		/// Updates a record in the FormaPago table.
		/// </summary>
        public void Update(FormaPagoEntidades formaPago)
        {
            ValidationUtility.ValidateArgument("formaPago", formaPago);

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdFormaPago", formaPago.IdFormaPago),
                new SqlParameter("@DescripFormaPago", formaPago.DescripFormaPago)
            };

            SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "FormaPagoUpdate", parameters);
        }

		/// <summary>
		/// Deletes a record from the FormaPago table by its primary key.
		/// </summary>
        public void Delete(int idFormaPago)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IdFormaPago", idFormaPago)
            };

            SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "FormaPagoDelete", parameters);
        }

		/// <summary>
		/// Selects a single record from the FormaPago table.
		/// </summary>
        //public FormaPagoEntidades Select(int idFormaPago)
        //{
        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //        new SqlParameter("@IdFormaPago", idFormaPago)
        //    };

        //    using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "FormaPagoSelect", parameters))
        //    {
        //        if (dataReader.Read())
        //        {
        //            return MapDataReader(dataReader);
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}

		/// <summary>
		/// Selects a single record from the FormaPago table.
		/// </summary>
        //public string SelectJson(int idFormaPago)
        //{
        //    SqlParameter[] parameters = new SqlParameter[]
        //    {
        //        new SqlParameter("@IdFormaPago", idFormaPago)
        //    };

        //    return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "FormaPagoSelect", parameters);
        //}

		/// <summary>
		/// Selects all records from the FormaPago table.
		/// </summary>
		public List<FormaPagoEntidades> SelectAll()
		{
            //Para el connection string en vez del string usar: string connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString; 
            //Y tiene que estar la libreria: using System.Configuration;
            using (DataTable dt = SqlClientUtility.ExecuteDataTable("data source=JAVI-PC\\SQLEXPRESS;initial catalog=Ecommercetfiv12;integrated security=sspi", CommandType.StoredProcedure, "FormaPagoSelectAll"))
			{
				List<FormaPagoEntidades> formaPagoEntidadesList = new List<FormaPagoEntidades>();
                //while (dt.Read())
                //{
                //    FormaPagoEntidades formaPagoEntidades = MapDataReader(dataReader);
                //    formaPagoEntidadesList.Add(formaPagoEntidades);
                //}

                formaPagoEntidadesList = Mapeador.Mapear<FormaPagoEntidades>(dt);       



				return formaPagoEntidadesList;
			}
		}


        public List<FormaPagoEntidades> SelectAllk()
        {

            using (DataTable dt = SqlClientUtility.ExecuteDataTable(connectionStringName, CommandType.StoredProcedure, "FormaPagoSelectAll"))
            {
                List<FormaPagoEntidades> formaPagoEntidadesList2 = new List<FormaPagoEntidades>();

                formaPagoEntidadesList2 = Mapeador.Mapear<FormaPagoEntidades>(dt);

                return formaPagoEntidadesList2;
            }
        }






















		/// <summary>
		/// Selects all records from the FormaPago table.
		/// </summary>
        //public string SelectAllJson()
        //{
        //    return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "FormaPagoSelectAll");
        //}

		/// <summary>
		/// Creates a new instance of the FormaPagoEntidades class and populates it with data from the specified SqlDataReader.
		/// </summary>
        //private FormaPagoEntidades MapDataReader(SqlDataReader dataReader)
        //{
        //    FormaPagoEntidades formaPagoEntidade = new FormaPagoEntidades();
        //    formaPagoEntidade.IdFormaPago = dataReader.GetInt32("IdFormaPago", 0);
        //    formaPagoEntidade.DescripFormaPago = dataReader.GetString("DescripFormaPago", null);

        //    return formaPagoEntidade;
        //}

		#endregion
	}
}
