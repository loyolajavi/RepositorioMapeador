using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class CondicionFiscalDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public CondicionFiscalDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the CondicionFiscal table.
		/// </summary>
		public void Insert(CondicionFiscalEntidad condicionFiscal)
		{
			ValidationUtility.ValidateArgument("condicionFiscal", condicionFiscal);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Descripcion", condicionFiscal.Descripcion)
			};

			condicionFiscal.IdCondicionFiscal = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "CondicionFiscalInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the CondicionFiscal table.
		/// </summary>
		public void Update(CondicionFiscalEntidad condicionFiscal)
		{
			ValidationUtility.ValidateArgument("condicionFiscal", condicionFiscal);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdCondicionFiscal", condicionFiscal.IdCondicionFiscal),
				new SqlParameter("@Descripcion", condicionFiscal.Descripcion)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "CondicionFiscalUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the CondicionFiscal table by its primary key.
		/// </summary>
		public void Delete(int idCondicionFiscal)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdCondicionFiscal", idCondicionFiscal)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "CondicionFiscalDelete", parameters);
		}

		/// <summary>
		/// Selects a single record from the CondicionFiscal table.
		/// </summary>
		public CondicionFiscalEntidad Select(int idCondicionFiscal)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdCondicionFiscal", idCondicionFiscal)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "CondicionFiscalSelect", parameters))
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
		/// Selects a single record from the CondicionFiscal table.
		/// </summary>
		public string SelectJson(int idCondicionFiscal)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdCondicionFiscal", idCondicionFiscal)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "CondicionFiscalSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the CondicionFiscal table.
		/// </summary>
		public List<CondicionFiscalEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "CondicionFiscalSelectAll"))
			{
				List<CondicionFiscalEntidad> condicionFiscalEntidadList = new List<CondicionFiscalEntidad>();
				while (dataReader.Read())
				{
					CondicionFiscalEntidad condicionFiscalEntidad = MapDataReader(dataReader);
					condicionFiscalEntidadList.Add(condicionFiscalEntidad);
				}

				return condicionFiscalEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the CondicionFiscal table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "CondicionFiscalSelectAll");
		}

		/// <summary>
		/// Creates a new instance of the CondicionFiscalEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private CondicionFiscalEntidad MapDataReader(SqlDataReader dataReader)
		{
			CondicionFiscalEntidad condicionFiscalEntidad = new CondicionFiscalEntidad();
			condicionFiscalEntidad.IdCondicionFiscal = dataReader.GetInt32("IdCondicionFiscal", 0);
			condicionFiscalEntidad.Descripcion = dataReader.GetString("Descripcion", null);

			return condicionFiscalEntidad;
		}

		#endregion
	}
}