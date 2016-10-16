using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class PedidoDetalleDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public PedidoDetalleDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the PedidoDetalle table.
		/// </summary>
		public void Insert(PedidoDetalleEntidad pedidoDetalle)
		{
			ValidationUtility.ValidateArgument("pedidoDetalle", pedidoDetalle);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPedidoDetalle", pedidoDetalle.IdPedidoDetalle),
				new SqlParameter("@IdPedido", pedidoDetalle.IdPedido),
				new SqlParameter("@Cantidad", pedidoDetalle.Cantidad),
				new SqlParameter("@PrecioUnitario", pedidoDetalle.PrecioUnitario),
				new SqlParameter("@Descuento", pedidoDetalle.Descuento),
				new SqlParameter("@IdProducto", pedidoDetalle.IdProducto)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PedidoDetalleInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the PedidoDetalle table.
		/// </summary>
		public void Update(PedidoDetalleEntidad pedidoDetalle)
		{
			ValidationUtility.ValidateArgument("pedidoDetalle", pedidoDetalle);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPedidoDetalle", pedidoDetalle.IdPedidoDetalle),
				new SqlParameter("@IdPedido", pedidoDetalle.IdPedido),
				new SqlParameter("@Cantidad", pedidoDetalle.Cantidad),
				new SqlParameter("@PrecioUnitario", pedidoDetalle.PrecioUnitario),
				new SqlParameter("@Descuento", pedidoDetalle.Descuento),
				new SqlParameter("@IdProducto", pedidoDetalle.IdProducto)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PedidoDetalleUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the PedidoDetalle table by its primary key.
		/// </summary>
		public void Delete(int idPedido, int idPedidoDetalle)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPedido", idPedido),
				new SqlParameter("@IdPedidoDetalle", idPedidoDetalle)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PedidoDetalleDelete", parameters);
		}

		/// <summary>
		/// Deletes a record from the PedidoDetalle table by a foreign key.
		/// </summary>
		public void DeleteAllByIdPedido(int idPedido)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPedido", idPedido)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PedidoDetalleDeleteAllByIdPedido", parameters);
		}

		/// <summary>
		/// Deletes a record from the PedidoDetalle table by a foreign key.
		/// </summary>
		public void DeleteAllByIdProducto(int idProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PedidoDetalleDeleteAllByIdProducto", parameters);
		}

		/// <summary>
		/// Selects a single record from the PedidoDetalle table.
		/// </summary>
		public PedidoDetalleEntidad Select(int idPedido, int idPedidoDetalle)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPedido", idPedido),
				new SqlParameter("@IdPedidoDetalle", idPedidoDetalle)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "PedidoDetalleSelect", parameters))
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
		/// Selects a single record from the PedidoDetalle table.
		/// </summary>
		public string SelectJson(int idPedido, int idPedidoDetalle)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPedido", idPedido),
				new SqlParameter("@IdPedidoDetalle", idPedidoDetalle)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "PedidoDetalleSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the PedidoDetalle table.
		/// </summary>
		public List<PedidoDetalleEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "PedidoDetalleSelectAll"))
			{
				List<PedidoDetalleEntidad> pedidoDetalleEntidadList = new List<PedidoDetalleEntidad>();
				while (dataReader.Read())
				{
					PedidoDetalleEntidad pedidoDetalleEntidad = MapDataReader(dataReader);
					pedidoDetalleEntidadList.Add(pedidoDetalleEntidad);
				}

				return pedidoDetalleEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the PedidoDetalle table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "PedidoDetalleSelectAll");
		}

		/// <summary>
		/// Selects all records from the PedidoDetalle table by a foreign key.
		/// </summary>
		public List<PedidoDetalleEntidad> SelectAllByIdPedido(int idPedido)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPedido", idPedido)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "PedidoDetalleSelectAllByIdPedido", parameters))
			{
				List<PedidoDetalleEntidad> pedidoDetalleEntidadList = new List<PedidoDetalleEntidad>();
				while (dataReader.Read())
				{
					PedidoDetalleEntidad pedidoDetalleEntidad = MapDataReader(dataReader);
					pedidoDetalleEntidadList.Add(pedidoDetalleEntidad);
				}

				return pedidoDetalleEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the PedidoDetalle table by a foreign key.
		/// </summary>
		public List<PedidoDetalleEntidad> SelectAllByIdProducto(int idProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "PedidoDetalleSelectAllByIdProducto", parameters))
			{
				List<PedidoDetalleEntidad> pedidoDetalleEntidadList = new List<PedidoDetalleEntidad>();
				while (dataReader.Read())
				{
					PedidoDetalleEntidad pedidoDetalleEntidad = MapDataReader(dataReader);
					pedidoDetalleEntidadList.Add(pedidoDetalleEntidad);
				}

				return pedidoDetalleEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the PedidoDetalle table by a foreign key.
		/// </summary>
		public string SelectAllByIdPedidoJson(int idPedido)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPedido", idPedido)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "PedidoDetalleSelectAllByIdPedido", parameters);
		}

		/// <summary>
		/// Selects all records from the PedidoDetalle table by a foreign key.
		/// </summary>
		public string SelectAllByIdProductoJson(int idProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "PedidoDetalleSelectAllByIdProducto", parameters);
		}

		/// <summary>
		/// Creates a new instance of the PedidoDetalleEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private PedidoDetalleEntidad MapDataReader(SqlDataReader dataReader)
		{
			PedidoDetalleEntidad pedidoDetalleEntidad = new PedidoDetalleEntidad();
			pedidoDetalleEntidad.IdPedidoDetalle = dataReader.GetInt32("IdPedidoDetalle", 0);
			pedidoDetalleEntidad.IdPedido = dataReader.GetInt32("IdPedido", 0);
			pedidoDetalleEntidad.Cantidad = dataReader.GetInt32("Cantidad", 0);
			pedidoDetalleEntidad.PrecioUnitario = dataReader.GetDecimal("PrecioUnitario", Decimal.Zero);
			pedidoDetalleEntidad.Descuento = dataReader.GetInt32("Descuento", 0);
			pedidoDetalleEntidad.IdProducto = dataReader.GetInt32("IdProducto", 0);

			return pedidoDetalleEntidad;
		}

		#endregion
	}
}
