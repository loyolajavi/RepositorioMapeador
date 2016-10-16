using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TFI.HelperDAL;


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

			using (DataTable dt = SqlClientUtility.ExecuteDataTable(connectionStringName, CommandType.StoredProcedure, "FamiliaSelect", parameters))
			{
                FamiliaEntidad FamiliaEntidad = new FamiliaEntidad();

                FamiliaEntidad = Mapeador.MapearFirst<FamiliaEntidad>(dt);

                return FamiliaEntidad;
			}
		}

		

		/// <summary>
		/// Selects all records from the Familia table.
		/// </summary>
		public List<FamiliaEntidad> SelectAll()
		{
			using (DataTable dt = SqlClientUtility.ExecuteDataTable(connectionStringName, CommandType.StoredProcedure, "FamiliaSelectAll"))
			{
				List<FamiliaEntidad> familiaEntidadList = new List<FamiliaEntidad>();

                familiaEntidadList = Mapeador.Mapear<FamiliaEntidad>(dt);

				return familiaEntidadList;
			}
		}

		#endregion
	}
}
