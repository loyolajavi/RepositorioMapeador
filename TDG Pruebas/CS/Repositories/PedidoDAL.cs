using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class PedidoDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public PedidoDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

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

			pedido.IdPedido = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "PedidoInsert", parameters);
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

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PedidoUpdate", parameters);
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

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PedidoDelete", parameters);
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

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PedidoDeleteAllByDireccionEntrega", parameters);
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

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PedidoDeleteAllByCUIT", parameters);
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

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PedidoDeleteAllByIdEstadoPedido", parameters);
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

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PedidoDeleteAllByIdFormaEntrega", parameters);
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

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PedidoDeleteAllByCUIT_NombreUsuario", parameters);
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

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "PedidoSelect", parameters))
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
		/// Selects a single record from the Pedido table.
		/// </summary>
		public string SelectJson(int idPedido)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPedido", idPedido)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "PedidoSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the Pedido table.
		/// </summary>
		public List<PedidoEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "PedidoSelectAll"))
			{
				List<PedidoEntidad> pedidoEntidadList = new List<PedidoEntidad>();
				while (dataReader.Read())
				{
					PedidoEntidad pedidoEntidad = MapDataReader(dataReader);
					pedidoEntidadList.Add(pedidoEntidad);
				}

				return pedidoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Pedido table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "PedidoSelectAll");
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

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "PedidoSelectAllByDireccionEntrega", parameters))
			{
				List<PedidoEntidad> pedidoEntidadList = new List<PedidoEntidad>();
				while (dataReader.Read())
				{
					PedidoEntidad pedidoEntidad = MapDataReader(dataReader);
					pedidoEntidadList.Add(pedidoEntidad);
				}

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

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "PedidoSelectAllByCUIT", parameters))
			{
				List<PedidoEntidad> pedidoEntidadList = new List<PedidoEntidad>();
				while (dataReader.Read())
				{
					PedidoEntidad pedidoEntidad = MapDataReader(dataReader);
					pedidoEntidadList.Add(pedidoEntidad);
				}

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

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "PedidoSelectAllByIdEstadoPedido", parameters))
			{
				List<PedidoEntidad> pedidoEntidadList = new List<PedidoEntidad>();
				while (dataReader.Read())
				{
					PedidoEntidad pedidoEntidad = MapDataReader(dataReader);
					pedidoEntidadList.Add(pedidoEntidad);
				}

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

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "PedidoSelectAllByIdFormaEntrega", parameters))
			{
				List<PedidoEntidad> pedidoEntidadList = new List<PedidoEntidad>();
				while (dataReader.Read())
				{
					PedidoEntidad pedidoEntidad = MapDataReader(dataReader);
					pedidoEntidadList.Add(pedidoEntidad);
				}

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

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "PedidoSelectAllByCUIT_NombreUsuario", parameters))
			{
				List<PedidoEntidad> pedidoEntidadList = new List<PedidoEntidad>();
				while (dataReader.Read())
				{
					PedidoEntidad pedidoEntidad = MapDataReader(dataReader);
					pedidoEntidadList.Add(pedidoEntidad);
				}

				return pedidoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Pedido table by a foreign key.
		/// </summary>
		public string SelectAllByDireccionEntregaJson(int direccionEntrega)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DireccionEntrega", direccionEntrega)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "PedidoSelectAllByDireccionEntrega", parameters);
		}

		/// <summary>
		/// Selects all records from the Pedido table by a foreign key.
		/// </summary>
		public string SelectAllByCUITJson(int cUIT)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "PedidoSelectAllByCUIT", parameters);
		}

		/// <summary>
		/// Selects all records from the Pedido table by a foreign key.
		/// </summary>
		public string SelectAllByIdEstadoPedidoJson(int idEstadoPedido)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdEstadoPedido", idEstadoPedido)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "PedidoSelectAllByIdEstadoPedido", parameters);
		}

		/// <summary>
		/// Selects all records from the Pedido table by a foreign key.
		/// </summary>
		public string SelectAllByIdFormaEntregaJson(int idFormaEntrega)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdFormaEntrega", idFormaEntrega)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "PedidoSelectAllByIdFormaEntrega", parameters);
		}

		/// <summary>
		/// Selects all records from the Pedido table by a foreign key.
		/// </summary>
		public string SelectAllByCUIT_NombreUsuarioJson(int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "PedidoSelectAllByCUIT_NombreUsuario", parameters);
		}

		/// <summary>
		/// Creates a new instance of the PedidoEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private PedidoEntidad MapDataReader(SqlDataReader dataReader)
		{
			PedidoEntidad pedidoEntidad = new PedidoEntidad();
			pedidoEntidad.IdPedido = dataReader.GetInt32("IdPedido", 0);
			pedidoEntidad.FechaPedido = dataReader.GetDateTime("FechaPedido", new DateTime(0));
			pedidoEntidad.FechaFinPedido = dataReader.GetDateTime("FechaFinPedido", new DateTime(0));
			pedidoEntidad.NombreUsuario = dataReader.GetString("NombreUsuario", null);
			pedidoEntidad.PlazoEntrega = dataReader.GetInt32("PlazoEntrega", 0);
			pedidoEntidad.IdEstadoPedido = dataReader.GetInt32("IdEstadoPedido", 0);
			pedidoEntidad.IdFormaEntrega = dataReader.GetInt32("IdFormaEntrega", 0);
			pedidoEntidad.CUIT = dataReader.GetInt32("CUIT", 0);
			pedidoEntidad.NumeroTracking = dataReader.GetString("NumeroTracking", null);
			pedidoEntidad.DireccionEntrega = dataReader.GetInt32("DireccionEntrega", 0);

			return pedidoEntidad;
		}

		#endregion
	}
}
