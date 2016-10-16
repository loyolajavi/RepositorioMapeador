using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TFI.HelperDAL;


namespace TFI.DAL.DAL
{
	public class EstadoProductoDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public EstadoProductoDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the EstadoProducto table.
		/// </summary>
		public void Insert(EstadoProductoEntidad estadoProducto)
		{
			ValidationUtility.ValidateArgument("estadoProducto", estadoProducto);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DescripEstadoProducto", estadoProducto.DescripEstadoProducto)
			};

			estadoProducto.IdEstadoProducto = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "EstadoProductoInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the EstadoProducto table.
		/// </summary>
		public void Update(EstadoProductoEntidad estadoProducto)
		{
			ValidationUtility.ValidateArgument("estadoProducto", estadoProducto);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdEstadoProducto", estadoProducto.IdEstadoProducto),
				new SqlParameter("@DescripEstadoProducto", estadoProducto.DescripEstadoProducto)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "EstadoProductoUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the EstadoProducto table by its primary key.
		/// </summary>
		public void Delete(int idEstadoProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdEstadoProducto", idEstadoProducto)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "EstadoProductoDelete", parameters);
		}

		/// <summary>
		/// Selects a single record from the EstadoProducto table.
		/// </summary>
		public EstadoProductoEntidad Select(int idEstadoProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdEstadoProducto", idEstadoProducto)
			};

			using (DataTable dt = SqlClientUtility.ExecuteDataTable(connectionStringName, CommandType.StoredProcedure, "EstadoProductoSelect", parameters))
			{
                EstadoProductoEntidad EstadoProductoEntidad = new EstadoProductoEntidad();

                EstadoProductoEntidad = Mapeador.MapearFirst<EstadoProductoEntidad>(dt);

                return EstadoProductoEntidad;
			}
		}


		/// <summary>
		/// Selects all records from the EstadoProducto table.
		/// </summary>
		public List<EstadoProductoEntidad> SelectAll()
		{
			using (DataTable dt = SqlClientUtility.ExecuteDataTable(connectionStringName, CommandType.StoredProcedure, "EstadoProductoSelectAll"))
			{
				List<EstadoProductoEntidad> estadoProductoEntidadList = new List<EstadoProductoEntidad>();

                estadoProductoEntidadList = Mapeador.Mapear<EstadoProductoEntidad>(dt);

				return estadoProductoEntidadList;
			}
		}


		#endregion
	}
}
