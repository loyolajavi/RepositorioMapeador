using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class FormaEntregaDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public FormaEntregaDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the FormaEntrega table.
		/// </summary>
		public void Insert(FormaEntregaEntidad formaEntrega)
		{
			ValidationUtility.ValidateArgument("formaEntrega", formaEntrega);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DescripcionFormaEntrega", formaEntrega.DescripcionFormaEntrega)
			};

			formaEntrega.IdFormaEntrega = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "FormaEntregaInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the FormaEntrega table.
		/// </summary>
		public void Update(FormaEntregaEntidad formaEntrega)
		{
			ValidationUtility.ValidateArgument("formaEntrega", formaEntrega);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdFormaEntrega", formaEntrega.IdFormaEntrega),
				new SqlParameter("@DescripcionFormaEntrega", formaEntrega.DescripcionFormaEntrega)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "FormaEntregaUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the FormaEntrega table by its primary key.
		/// </summary>
		public void Delete(int idFormaEntrega)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdFormaEntrega", idFormaEntrega)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "FormaEntregaDelete", parameters);
		}

		/// <summary>
		/// Selects a single record from the FormaEntrega table.
		/// </summary>
		public FormaEntregaEntidad Select(int idFormaEntrega)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdFormaEntrega", idFormaEntrega)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "FormaEntregaSelect", parameters))
			{
				if (dataReader.Read())
				{
					return MapDataReader(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects a single record from the FormaEntrega table.
		/// </summary>
		public string SelectJson(int idFormaEntrega)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdFormaEntrega", idFormaEntrega)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "FormaEntregaSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the FormaEntrega table.
		/// </summary>
		public List<FormaEntregaEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "FormaEntregaSelectAll"))
			{
				List<FormaEntregaEntidad> formaEntregaEntidadList = new List<FormaEntregaEntidad>();
				while (dataReader.Read())
				{
					FormaEntregaEntidad formaEntregaEntidad = MapDataReader(dataReader);
					formaEntregaEntidadList.Add(formaEntregaEntidad);
				}

				return formaEntregaEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the FormaEntrega table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "FormaEntregaSelectAll");
		}

		/// <summary>
		/// Creates a new instance of the FormaEntregaEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private FormaEntregaEntidad MapDataReader(SqlDataReader dataReader)
		{
			FormaEntregaEntidad formaEntregaEntidad = new FormaEntregaEntidad();
			formaEntregaEntidad.IdFormaEntrega = dataReader.GetInt32("IdFormaEntrega", 0);
			formaEntregaEntidad.DescripcionFormaEntrega = dataReader.GetString("DescripcionFormaEntrega", null);

			return formaEntregaEntidad;
		}

		#endregion
	}
}
