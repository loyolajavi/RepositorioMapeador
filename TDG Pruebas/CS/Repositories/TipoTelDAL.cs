using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TFI.HelperDAL;
namespace TFI.DAL.DAL
{
	public class TipoTelDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public TipoTelDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the TipoTel table.
		/// </summary>
		public void Insert(TipoTelEntidad tipoTel)
		{
			ValidationUtility.ValidateArgument("tipoTel", tipoTel);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DescripcionTipoTel", tipoTel.DescripcionTipoTel)
			};

			tipoTel.IdTipoTel = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "TipoTelInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the TipoTel table.
		/// </summary>
		public void Update(TipoTelEntidad tipoTel)
		{
			ValidationUtility.ValidateArgument("tipoTel", tipoTel);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTipoTel", tipoTel.IdTipoTel),
				new SqlParameter("@DescripcionTipoTel", tipoTel.DescripcionTipoTel)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "TipoTelUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the TipoTel table by its primary key.
		/// </summary>
		public void Delete(int idTipoTel)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTipoTel", idTipoTel)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "TipoTelDelete", parameters);
		}

		/// <summary>
		/// Selects a single record from the TipoTel table.
		/// </summary>
		public TipoTelEntidad Select(int idTipoTel)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTipoTel", idTipoTel)
			};

            using (DataTable dt = SqlClientUtility.ExecuteDataTable(connectionStringName, CommandType.StoredProcedure, "TipoTelSelect", parameters))
			{
                TipoTelEntidad entidad = new TipoTelEntidad();
                //       

                entidad = Mapeador.MapearFirst<TipoTelEntidad>(dt);



                return entidad;
			}
		}

		

		/// <summary>
		/// Selects all records from the TipoTel table.
		/// </summary>
		public List<TipoTelEntidad> SelectAll()
		{
            using (DataTable dt = SqlClientUtility.ExecuteDataTable(connectionStringName, CommandType.StoredProcedure, "TipoTelSelectAll"))
			{
                List<TipoTelEntidad> lista = new List<TipoTelEntidad>();
                lista = Mapeador.Mapear<TipoTelEntidad>(dt);

                return lista;
			}
		}

	

		

		#endregion
	}
}
