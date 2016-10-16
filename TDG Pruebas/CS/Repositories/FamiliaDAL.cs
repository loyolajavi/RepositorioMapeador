using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class FamiliaDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public FamiliaDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Familia table.
		/// </summary>
		public void Insert(FamiliaEntidad familia)
		{
			ValidationUtility.ValidateArgument("familia", familia);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@NombreFamilia", familia.NombreFamilia)
			};

			familia.IdFamilia = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "FamiliaInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the Familia table.
		/// </summary>
		public void Update(FamiliaEntidad familia)
		{
			ValidationUtility.ValidateArgument("familia", familia);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdFamilia", familia.IdFamilia),
				new SqlParameter("@NombreFamilia", familia.NombreFamilia)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "FamiliaUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the Familia table by its primary key.
		/// </summary>
		public void Delete(int idFamilia)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdFamilia", idFamilia)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "FamiliaDelete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Familia table.
		/// </summary>
		public FamiliaEntidad Select(int idFamilia)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdFamilia", idFamilia)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "FamiliaSelect", parameters))
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
		/// Selects a single record from the Familia table.
		/// </summary>
		public string SelectJson(int idFamilia)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdFamilia", idFamilia)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "FamiliaSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the Familia table.
		/// </summary>
		public List<FamiliaEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "FamiliaSelectAll"))
			{
				List<FamiliaEntidad> familiaEntidadList = new List<FamiliaEntidad>();
				while (dataReader.Read())
				{
					FamiliaEntidad familiaEntidad = MapDataReader(dataReader);
					familiaEntidadList.Add(familiaEntidad);
				}

				return familiaEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Familia table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "FamiliaSelectAll");
		}

		/// <summary>
		/// Creates a new instance of the FamiliaEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private FamiliaEntidad MapDataReader(SqlDataReader dataReader)
		{
			FamiliaEntidad familiaEntidad = new FamiliaEntidad();
			familiaEntidad.IdFamilia = dataReader.GetInt32("IdFamilia", 0);
			familiaEntidad.NombreFamilia = dataReader.GetString("NombreFamilia", null);

			return familiaEntidad;
		}

		#endregion
	}
}
