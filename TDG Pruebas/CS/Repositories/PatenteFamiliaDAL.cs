using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class PatenteFamiliaDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public PatenteFamiliaDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the PatenteFamilia table.
		/// </summary>
		public void Insert(PatenteFamiliaEntidad patenteFamilia)
		{
			ValidationUtility.ValidateArgument("patenteFamilia", patenteFamilia);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPatente", patenteFamilia.IdPatente),
				new SqlParameter("@IdFamilia", patenteFamilia.IdFamilia)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PatenteFamiliaInsert", parameters);
		}

		/// <summary>
		/// Deletes a record from the PatenteFamilia table by its primary key.
		/// </summary>
		public void Delete(int idPatente, int idFamilia)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPatente", idPatente),
				new SqlParameter("@IdFamilia", idFamilia)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PatenteFamiliaDelete", parameters);
		}

		/// <summary>
		/// Deletes a record from the PatenteFamilia table by a foreign key.
		/// </summary>
		public void DeleteAllByIdFamilia(int idFamilia)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdFamilia", idFamilia)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PatenteFamiliaDeleteAllByIdFamilia", parameters);
		}

		/// <summary>
		/// Deletes a record from the PatenteFamilia table by a foreign key.
		/// </summary>
		public void DeleteAllByIdPatente(int idPatente)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPatente", idPatente)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PatenteFamiliaDeleteAllByIdPatente", parameters);
		}

		/// <summary>
		/// Selects all records from the PatenteFamilia table by a foreign key.
		/// </summary>
		public List<PatenteFamiliaEntidad> SelectAllByIdFamilia(int idFamilia)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdFamilia", idFamilia)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "PatenteFamiliaSelectAllByIdFamilia", parameters))
			{
				List<PatenteFamiliaEntidad> patenteFamiliaEntidadList = new List<PatenteFamiliaEntidad>();
				while (dataReader.Read())
				{
					PatenteFamiliaEntidad patenteFamiliaEntidad = MapDataReader(dataReader);
					patenteFamiliaEntidadList.Add(patenteFamiliaEntidad);
				}

				return patenteFamiliaEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the PatenteFamilia table by a foreign key.
		/// </summary>
		public List<PatenteFamiliaEntidad> SelectAllByIdPatente(int idPatente)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPatente", idPatente)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "PatenteFamiliaSelectAllByIdPatente", parameters))
			{
				List<PatenteFamiliaEntidad> patenteFamiliaEntidadList = new List<PatenteFamiliaEntidad>();
				while (dataReader.Read())
				{
					PatenteFamiliaEntidad patenteFamiliaEntidad = MapDataReader(dataReader);
					patenteFamiliaEntidadList.Add(patenteFamiliaEntidad);
				}

				return patenteFamiliaEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the PatenteFamilia table by a foreign key.
		/// </summary>
		public string SelectAllByIdFamiliaJson(int idFamilia)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdFamilia", idFamilia)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "PatenteFamiliaSelectAllByIdFamilia", parameters);
		}

		/// <summary>
		/// Selects all records from the PatenteFamilia table by a foreign key.
		/// </summary>
		public string SelectAllByIdPatenteJson(int idPatente)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPatente", idPatente)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "PatenteFamiliaSelectAllByIdPatente", parameters);
		}

		/// <summary>
		/// Creates a new instance of the PatenteFamiliaEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private PatenteFamiliaEntidad MapDataReader(SqlDataReader dataReader)
		{
			PatenteFamiliaEntidad patenteFamiliaEntidad = new PatenteFamiliaEntidad();
			patenteFamiliaEntidad.IdPatente = dataReader.GetInt32("IdPatente", 0);
			patenteFamiliaEntidad.IdFamilia = dataReader.GetInt32("IdFamilia", 0);

			return patenteFamiliaEntidad;
		}

		#endregion
	}
}
