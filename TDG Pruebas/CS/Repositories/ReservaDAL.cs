using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class ReservaDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public ReservaDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Reserva table.
		/// </summary>
		public void Insert(ReservaEntidad reserva)
		{
			ValidationUtility.ValidateArgument("reserva", reserva);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPedido", reserva.IdPedido),
				new SqlParameter("@IdPedidoDetalle", reserva.IdPedidoDetalle),
				new SqlParameter("@IdSucursal", reserva.IdSucursal),
				new SqlParameter("@Activo", reserva.Activo),
				new SqlParameter("@Fecha", reserva.Fecha)
			};

			reserva.IdReserva = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "ReservaInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the Reserva table.
		/// </summary>
		public void Update(ReservaEntidad reserva)
		{
			ValidationUtility.ValidateArgument("reserva", reserva);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdReserva", reserva.IdReserva),
				new SqlParameter("@IdPedido", reserva.IdPedido),
				new SqlParameter("@IdPedidoDetalle", reserva.IdPedidoDetalle),
				new SqlParameter("@IdSucursal", reserva.IdSucursal),
				new SqlParameter("@Activo", reserva.Activo),
				new SqlParameter("@Fecha", reserva.Fecha)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ReservaUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the Reserva table by its primary key.
		/// </summary>
		public void Delete(int idReserva)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdReserva", idReserva)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ReservaDelete", parameters);
		}

		/// <summary>
		/// Deletes a record from the Reserva table by a foreign key.
		/// </summary>
		public void DeleteAllByIdPedido_IdPedidoDetalle(int idPedido, int idPedidoDetalle)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPedido", idPedido),
				new SqlParameter("@IdPedidoDetalle", idPedidoDetalle)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ReservaDeleteAllByIdPedido_IdPedidoDetalle", parameters);
		}

		/// <summary>
		/// Deletes a record from the Reserva table by a foreign key.
		/// </summary>
		public void DeleteAllByIdSucursal(int idSucursal)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdSucursal", idSucursal)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ReservaDeleteAllByIdSucursal", parameters);
		}

		/// <summary>
		/// Selects a single record from the Reserva table.
		/// </summary>
		public ReservaEntidad Select(int idReserva)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdReserva", idReserva)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ReservaSelect", parameters))
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
		/// Selects a single record from the Reserva table.
		/// </summary>
		public string SelectJson(int idReserva)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdReserva", idReserva)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ReservaSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the Reserva table.
		/// </summary>
		public List<ReservaEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ReservaSelectAll"))
			{
				List<ReservaEntidad> reservaEntidadList = new List<ReservaEntidad>();
				while (dataReader.Read())
				{
					ReservaEntidad reservaEntidad = MapDataReader(dataReader);
					reservaEntidadList.Add(reservaEntidad);
				}

				return reservaEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Reserva table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ReservaSelectAll");
		}

		/// <summary>
		/// Selects all records from the Reserva table by a foreign key.
		/// </summary>
		public List<ReservaEntidad> SelectAllByIdPedido_IdPedidoDetalle(int idPedido, int idPedidoDetalle)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPedido", idPedido),
				new SqlParameter("@IdPedidoDetalle", idPedidoDetalle)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ReservaSelectAllByIdPedido_IdPedidoDetalle", parameters))
			{
				List<ReservaEntidad> reservaEntidadList = new List<ReservaEntidad>();
				while (dataReader.Read())
				{
					ReservaEntidad reservaEntidad = MapDataReader(dataReader);
					reservaEntidadList.Add(reservaEntidad);
				}

				return reservaEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Reserva table by a foreign key.
		/// </summary>
		public List<ReservaEntidad> SelectAllByIdSucursal(int idSucursal)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdSucursal", idSucursal)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ReservaSelectAllByIdSucursal", parameters))
			{
				List<ReservaEntidad> reservaEntidadList = new List<ReservaEntidad>();
				while (dataReader.Read())
				{
					ReservaEntidad reservaEntidad = MapDataReader(dataReader);
					reservaEntidadList.Add(reservaEntidad);
				}

				return reservaEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Reserva table by a foreign key.
		/// </summary>
		public string SelectAllByIdPedido_IdPedidoDetalleJson(int idPedido, int idPedidoDetalle)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPedido", idPedido),
				new SqlParameter("@IdPedidoDetalle", idPedidoDetalle)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ReservaSelectAllByIdPedido_IdPedidoDetalle", parameters);
		}

		/// <summary>
		/// Selects all records from the Reserva table by a foreign key.
		/// </summary>
		public string SelectAllByIdSucursalJson(int idSucursal)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdSucursal", idSucursal)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ReservaSelectAllByIdSucursal", parameters);
		}

		/// <summary>
		/// Creates a new instance of the ReservaEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private ReservaEntidad MapDataReader(SqlDataReader dataReader)
		{
			ReservaEntidad reservaEntidad = new ReservaEntidad();
			reservaEntidad.IdReserva = dataReader.GetInt32("IdReserva", 0);
			reservaEntidad.IdPedido = dataReader.GetInt32("IdPedido", 0);
			reservaEntidad.IdPedidoDetalle = dataReader.GetInt32("IdPedidoDetalle", 0);
			reservaEntidad.IdSucursal = dataReader.GetInt32("IdSucursal", 0);
			reservaEntidad.Activo = dataReader.GetBoolean("Activo", false);
			reservaEntidad.Fecha = dataReader.GetDateTime("Fecha", new DateTime(0));

			return reservaEntidad;
		}

		#endregion
	}
}
