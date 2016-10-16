using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class ProvinciaDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public ProvinciaDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Provincia table.
		/// </summary>
		public void Insert(ProvinciaEntidad provincia)
		{
			ValidationUtility.ValidateArgument("provincia", provincia);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProvincia", provincia.IdProvincia),
				new SqlParameter("@DescripcionProvincia", provincia.DescripcionProvincia)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ProvinciaInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the Provincia table.
		/// </summary>
		public void Update(ProvinciaEntidad provincia)
		{
			ValidationUtility.ValidateArgument("provincia", provincia);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProvincia", provincia.IdProvincia),
				new SqlParameter("@DescripcionProvincia", provincia.DescripcionProvincia)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ProvinciaUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the Provincia table by its primary key.
		/// </summary>
		public void Delete(int idProvincia)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProvincia", idProvincia)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ProvinciaDelete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Provincia table.
		/// </summary>
		public ProvinciaEntidad Select(int idProvincia)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProvincia", idProvincia)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ProvinciaSelect", parameters))
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
		/// Selects a single record from the Provincia table.
		/// </summary>
		public string SelectJson(int idProvincia)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProvincia", idProvincia)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ProvinciaSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the Provincia table.
		/// </summary>
		public List<ProvinciaEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ProvinciaSelectAll"))
			{
				List<ProvinciaEntidad> provinciaEntidadList = new List<ProvinciaEntidad>();
				while (dataReader.Read())
				{
					ProvinciaEntidad provinciaEntidad = MapDataReader(dataReader);
					provinciaEntidadList.Add(provinciaEntidad);
				}

				return provinciaEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Provincia table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ProvinciaSelectAll");
		}

		/// <summary>
		/// Creates a new instance of the ProvinciaEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private ProvinciaEntidad MapDataReader(SqlDataReader dataReader)
		{
			ProvinciaEntidad provinciaEntidad = new ProvinciaEntidad();
			provinciaEntidad.IdProvincia = dataReader.GetInt32("IdProvincia", 0);
			provinciaEntidad.DescripcionProvincia = dataReader.GetString("DescripcionProvincia", null);

			return provinciaEntidad;
		}

		#endregion
	}
}
