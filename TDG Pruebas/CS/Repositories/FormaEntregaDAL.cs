using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TFI.HelperDAL;


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

			using (DataTable dt = SqlClientUtility.ExecuteDataTable(connectionStringName, CommandType.StoredProcedure, "FormaEntregaSelect", parameters))
			{
                FormaEntregaEntidad FormaEntregaEntidad = new FormaEntregaEntidad();

                FormaEntregaEntidad = Mapeador.MapearFirst<FormaEntregaEntidad>(dt);

                return FormaEntregaEntidad;
			}
		}


		/// <summary>
		/// Selects all records from the FormaEntrega table.
		/// </summary>
		public List<FormaEntregaEntidad> SelectAll()
		{
			using (DataTable dt = SqlClientUtility.ExecuteDataTable(connectionStringName, CommandType.StoredProcedure, "FormaEntregaSelectAll"))
			{
				List<FormaEntregaEntidad> formaEntregaEntidadList = new List<FormaEntregaEntidad>();

                formaEntregaEntidadList = Mapeador.Mapear<FormaEntregaEntidad>(dt);

				return formaEntregaEntidadList;
			}
		}

	
		#endregion
	}
}
