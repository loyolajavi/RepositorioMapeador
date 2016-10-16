using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class PatenteDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public PatenteDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Patente table.
		/// </summary>
		public void Insert(PatenteEntidad patente)
		{
			ValidationUtility.ValidateArgument("patente", patente);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@NombrePatente", patente.NombrePatente)
			};

			patente.IdPatente = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "PatenteInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the Patente table.
		/// </summary>
		public void Update(PatenteEntidad patente)
		{
			ValidationUtility.ValidateArgument("patente", patente);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPatente", patente.IdPatente),
				new SqlParameter("@NombrePatente", patente.NombrePatente)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PatenteUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the Patente table by its primary key.
		/// </summary>
		public void Delete(int idPatente)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPatente", idPatente)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PatenteDelete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Patente table.
		/// </summary>
		public PatenteEntidad Select(int idPatente)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPatente", idPatente)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "PatenteSelect", parameters))
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
		/// Selects a single record from the Patente table.
		/// </summary>
		public string SelectJson(int idPatente)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPatente", idPatente)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "PatenteSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the Patente table.
		/// </summary>
		public List<PatenteEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "PatenteSelectAll"))
			{
				List<PatenteEntidad> patenteEntidadList = new List<PatenteEntidad>();
				while (dataReader.Read())
				{
					PatenteEntidad patenteEntidad = MapDataReader(dataReader);
					patenteEntidadList.Add(patenteEntidad);
				}

				return patenteEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Patente table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "PatenteSelectAll");
		}

		/// <summary>
		/// Creates a new instance of the PatenteEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private PatenteEntidad MapDataReader(SqlDataReader dataReader)
		{
			PatenteEntidad patenteEntidad = new PatenteEntidad();
			patenteEntidad.IdPatente = dataReader.GetInt32("IdPatente", 0);
			patenteEntidad.NombrePatente = dataReader.GetString("NombrePatente", null);

			return patenteEntidad;
		}

		#endregion
	}
}
