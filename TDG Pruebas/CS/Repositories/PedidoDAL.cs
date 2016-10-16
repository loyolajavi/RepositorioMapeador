using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TFI.HelperDAL;

namespace TFI.DAL.DAL
{
	public class PedidoDAL
	{


		#region Methods

		/// <summary>
		/// Saves a record to the Pedido table.
		/// </summary>
		public void Insert(PedidoEntidad pedido)
		{
			ValidationUtility.ValidateArgument("pedido", pedido);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@FechaPedido", pedido.FechaPedido),
				new SqlParameter("@FechaFinPedido", pedido.FechaFinPedido),
				new SqlParameter("@NombreUsuario", pedido.NombreUsuario),
				new SqlParameter("@PlazoEntrega", pedido.PlazoEntrega),
				new SqlParameter("@IdEstadoPedido", pedido.IdEstadoPedido),
				new SqlParameter("@IdFormaEntrega", pedido.IdFormaEntrega),
				new SqlParameter("@CUIT", pedido.CUIT),
				new SqlParameter("@NumeroTracking", pedido.NumeroTracking),
				new SqlParameter("@DireccionEntrega", pedido.DireccionEntrega)
			};

            pedido.IdPedido = (int)SqlClientUtility.ExecuteScalar(SqlClientUtility.connectionStringName, CommandType.StoredProcedure, "PedidoInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the Pedido table.
		/// </summary>
		public void Update(PedidoEntidad pedido)
		{
			ValidationUtility.ValidateArgument("pedido", pedido);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPedido", pedido.IdPedido),
				new SqlParameter("@FechaPedido", pedido.FechaPedido),
				new SqlParameter("@FechaFinPedido", pedido.FechaFinPedido),
				new SqlParameter("@NombreUsuario", pedido.NombreUsuario),
				new SqlParameter("@PlazoEntrega", pedido.PlazoEntrega),
				new SqlParameter("@IdEstadoPedido", pedido.IdEstadoPedido),
				new SqlParameter("@IdFormaEntrega", pedido.IdFormaEntrega),
				new SqlParameter("@CUIT", pedido.CUIT),
				new SqlParameter("@NumeroTracking", pedido.NumeroTracking),
				new SqlParameter("@DireccionEntrega", pedido.DireccionEntrega)
			};

            SqlClientUtility.ExecuteNonQuery(SqlClientUtility.connectionStringName, CommandType.StoredProcedure, "PedidoUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the Pedido table by its primary key.
		/// </summary>
		public void Delete(int idPedido)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPedido", idPedido)
			};

            SqlClientUtility.ExecuteNonQuery(SqlClientUtility.connectionStringName, CommandType.StoredProcedure, "PedidoDelete", parameters);
		}

		/// <summary>
		/// Deletes a record from the Pedido table by a foreign key.
		/// </summary>
		public void DeleteAllByDireccionEntrega(int direccionEntrega)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DireccionEntrega", direccionEntrega)
			};

            SqlClientUtility.ExecuteNonQuery(SqlClientUtility.connectionStringName, CommandType.StoredProcedure, "PedidoDeleteAllByDireccionEntrega", parameters);
		}

		/// <summary>
		/// Deletes a record from the Pedido table by a foreign key.
		/// </summary>
		public void DeleteAllByCUIT(int cUIT)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT)
			};

            SqlClientUtility.ExecuteNonQuery(SqlClientUtility.connectionStringName, CommandType.StoredProcedure, "PedidoDeleteAllByCUIT", parameters);
		}

		/// <summary>
		/// Deletes a record from the Pedido table by a foreign key.
		/// </summary>
		public void DeleteAllByIdEstadoPedido(int idEstadoPedido)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdEstadoPedido", idEstadoPedido)
			};

            SqlClientUtility.ExecuteNonQuery(SqlClientUtility.connectionStringName, CommandType.StoredProcedure, "PedidoDeleteAllByIdEstadoPedido", parameters);
		}

		/// <summary>
		/// Deletes a record from the Pedido table by a foreign key.
		/// </summary>
		public void DeleteAllByIdFormaEntrega(int idFormaEntrega)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdFormaEntrega", idFormaEntrega)
			};

            SqlClientUtility.ExecuteNonQuery(SqlClientUtility.connectionStringName, CommandType.StoredProcedure, "PedidoDeleteAllByIdFormaEntrega", parameters);
		}

		/// <summary>
		/// Deletes a record from the Pedido table by a foreign key.
		/// </summary>
		public void DeleteAllByCUIT_NombreUsuario(int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

            SqlClientUtility.ExecuteNonQuery(SqlClientUtility.connectionStringName, CommandType.StoredProcedure, "PedidoDeleteAllByCUIT_NombreUsuario", parameters);
		}

		/// <summary>
		/// Selects a single record from the Pedido table.
		/// </summary>
		public PedidoEntidad Select(int idPedido)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPedido", idPedido)
			};

            using (DataTable dt = SqlClientUtility.ExecuteDataTable(SqlClientUtility.connectionStringName, CommandType.StoredProcedure, "PedidoSelect", parameters))
			{
                PedidoEntidad PedidoEntidad = new PedidoEntidad();

                PedidoEntidad = Mapeador.MapearFirst<PedidoEntidad>(dt);

                return PedidoEntidad;
			}
		}


		/// <summary>
		/// Selects all records from the Pedido table.
		/// </summary>
		public List<PedidoEntidad> SelectAll()
		{
            using (DataTable dt = SqlClientUtility.ExecuteDataTable(SqlClientUtility.connectionStringName, CommandType.StoredProcedure, "PedidoSelectAll"))
			{
				List<PedidoEntidad> pedidoEntidadList = new List<PedidoEntidad>();

                pedidoEntidadList = Mapeador.Mapear<PedidoEntidad>(dt);

				return pedidoEntidadList;
			}
		}



		/// <summary>
		/// Selects all records from the Pedido table by a foreign key.
		/// </summary>
		public List<PedidoEntidad> SelectAllByDireccionEntrega(int direccionEntrega)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DireccionEntrega", direccionEntrega)
			};

            using (DataTable dt = SqlClientUtility.ExecuteDataTable(SqlClientUtility.connectionStringName, CommandType.StoredProcedure, "PedidoSelectAllByDireccionEntrega", parameters))
			{
				List<PedidoEntidad> pedidoEntidadList = new List<PedidoEntidad>();

                pedidoEntidadList = Mapeador.Mapear<PedidoEntidad>(dt);

				return pedidoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Pedido table by a foreign key.
		/// </summary>
		public List<PedidoEntidad> SelectAllByCUIT(int cUIT)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT)
			};

            using (DataTable dt = SqlClientUtility.ExecuteDataTable(SqlClientUtility.connectionStringName, CommandType.StoredProcedure, "PedidoSelectAllByCUIT", parameters))
			{
				List<PedidoEntidad> pedidoEntidadList = new List<PedidoEntidad>();

                pedidoEntidadList = Mapeador.Mapear<PedidoEntidad>(dt);

				return pedidoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Pedido table by a foreign key.
		/// </summary>
		public List<PedidoEntidad> SelectAllByIdEstadoPedido(int idEstadoPedido)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdEstadoPedido", idEstadoPedido)
			};

            using (DataTable dt = SqlClientUtility.ExecuteDataTable(SqlClientUtility.connectionStringName, CommandType.StoredProcedure, "PedidoSelectAllByIdEstadoPedido", parameters))
			{
				List<PedidoEntidad> pedidoEntidadList = new List<PedidoEntidad>();

                pedidoEntidadList = Mapeador.Mapear<PedidoEntidad>(dt);

				return pedidoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Pedido table by a foreign key.
		/// </summary>
		public List<PedidoEntidad> SelectAllByIdFormaEntrega(int idFormaEntrega)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdFormaEntrega", idFormaEntrega)
			};

            using (DataTable dt = SqlClientUtility.ExecuteDataTable(SqlClientUtility.connectionStringName, CommandType.StoredProcedure, "PedidoSelectAllByIdFormaEntrega", parameters))
			{
				List<PedidoEntidad> pedidoEntidadList = new List<PedidoEntidad>();

                pedidoEntidadList = Mapeador.Mapear<PedidoEntidad>(dt);

				return pedidoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Pedido table by a foreign key.
		/// </summary>
		public List<PedidoEntidad> SelectAllByCUIT_NombreUsuario(int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

            using (DataTable dt = SqlClientUtility.ExecuteDataTable(SqlClientUtility.connectionStringName, CommandType.StoredProcedure, "PedidoSelectAllByCUIT_NombreUsuario", parameters))
			{
				List<PedidoEntidad> pedidoEntidadList = new List<PedidoEntidad>();

                pedidoEntidadList = Mapeador.Mapear<PedidoEntidad>(dt);

				return pedidoEntidadList;
			}
		}

	
		#endregion
	}
}
