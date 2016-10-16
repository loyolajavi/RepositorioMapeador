using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class PagoDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public PagoDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Pago table.
		/// </summary>
		public void Insert(PagoEntidad pago)
		{
			ValidationUtility.ValidateArgument("pago", pago);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPedido", pago.IdPedido),
				new SqlParameter("@FechaPago", pago.FechaPago),
				new SqlParameter("@IdEstadoPago", pago.IdEstadoPago),
				new SqlParameter("@IdFormaPago", pago.IdFormaPago),
				new SqlParameter("@MontoPago", pago.MontoPago),
				new SqlParameter("@NroComprobante", pago.NroComprobante),
				new SqlParameter("@IdSucursal", pago.IdSucursal),
				new SqlParameter("@IdTipoComprobante", pago.IdTipoComprobante),
				new SqlParameter("@CUIT", pago.CUIT)
			};

			pago.IdPago = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "PagoInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the Pago table.
		/// </summary>
		public void Update(PagoEntidad pago)
		{
			ValidationUtility.ValidateArgument("pago", pago);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPago", pago.IdPago),
				new SqlParameter("@IdPedido", pago.IdPedido),
				new SqlParameter("@FechaPago", pago.FechaPago),
				new SqlParameter("@IdEstadoPago", pago.IdEstadoPago),
				new SqlParameter("@IdFormaPago", pago.IdFormaPago),
				new SqlParameter("@MontoPago", pago.MontoPago),
				new SqlParameter("@NroComprobante", pago.NroComprobante),
				new SqlParameter("@IdSucursal", pago.IdSucursal),
				new SqlParameter("@IdTipoComprobante", pago.IdTipoComprobante),
				new SqlParameter("@CUIT", pago.CUIT)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PagoUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the Pago table by its primary key.
		/// </summary>
		public void Delete(int idPago)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPago", idPago)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PagoDelete", parameters);
		}

		/// <summary>
		/// Deletes a record from the Pago table by a foreign key.
		/// </summary>
		public void DeleteAllByNroComprobante_IdSucursal_IdTipoComprobante_CUIT(int nroComprobante, int idSucursal, int idTipoComprobante, int cUIT)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@NroComprobante", nroComprobante),
				new SqlParameter("@IdSucursal", idSucursal),
				new SqlParameter("@IdTipoComprobante", idTipoComprobante),
				new SqlParameter("@CUIT", cUIT)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PagoDeleteAllByNroComprobante_IdSucursal_IdTipoComprobante_CUIT", parameters);
		}

		/// <summary>
		/// Deletes a record from the Pago table by a foreign key.
		/// </summary>
		public void DeleteAllByCUIT(int cUIT)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PagoDeleteAllByCUIT", parameters);
		}

		/// <summary>
		/// Deletes a record from the Pago table by a foreign key.
		/// </summary>
		public void DeleteAllByIdEstadoPago(int idEstadoPago)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdEstadoPago", idEstadoPago)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PagoDeleteAllByIdEstadoPago", parameters);
		}

		/// <summary>
		/// Deletes a record from the Pago table by a foreign key.
		/// </summary>
		public void DeleteAllByIdFormaPago(int idFormaPago)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdFormaPago", idFormaPago)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PagoDeleteAllByIdFormaPago", parameters);
		}

		/// <summary>
		/// Deletes a record from the Pago table by a foreign key.
		/// </summary>
		public void DeleteAllByIdPedido(int idPedido)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPedido", idPedido)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PagoDeleteAllByIdPedido", parameters);
		}

		/// <summary>
		/// Selects a single record from the Pago table.
		/// </summary>
		public PagoEntidad Select(int idPago)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPago", idPago)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "PagoSelect", parameters))
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
		/// Selects a single record from the Pago table.
		/// </summary>
		public string SelectJson(int idPago)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPago", idPago)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "PagoSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the Pago table.
		/// </summary>
		public List<PagoEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "PagoSelectAll"))
			{
				List<PagoEntidad> pagoEntidadList = new List<PagoEntidad>();
				while (dataReader.Read())
				{
					PagoEntidad pagoEntidad = MapDataReader(dataReader);
					pagoEntidadList.Add(pagoEntidad);
				}

				return pagoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Pago table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "PagoSelectAll");
		}

		/// <summary>
		/// Selects all records from the Pago table by a foreign key.
		/// </summary>
		public List<PagoEntidad> SelectAllByNroComprobante_IdSucursal_IdTipoComprobante_CUIT(int nroComprobante, int idSucursal, int idTipoComprobante, int cUIT)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@NroComprobante", nroComprobante),
				new SqlParameter("@IdSucursal", idSucursal),
				new SqlParameter("@IdTipoComprobante", idTipoComprobante),
				new SqlParameter("@CUIT", cUIT)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "PagoSelectAllByNroComprobante_IdSucursal_IdTipoComprobante_CUIT", parameters))
			{
				List<PagoEntidad> pagoEntidadList = new List<PagoEntidad>();
				while (dataReader.Read())
				{
					PagoEntidad pagoEntidad = MapDataReader(dataReader);
					pagoEntidadList.Add(pagoEntidad);
				}

				return pagoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Pago table by a foreign key.
		/// </summary>
		public List<PagoEntidad> SelectAllByCUIT(int cUIT)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "PagoSelectAllByCUIT", parameters))
			{
				List<PagoEntidad> pagoEntidadList = new List<PagoEntidad>();
				while (dataReader.Read())
				{
					PagoEntidad pagoEntidad = MapDataReader(dataReader);
					pagoEntidadList.Add(pagoEntidad);
				}

				return pagoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Pago table by a foreign key.
		/// </summary>
		public List<PagoEntidad> SelectAllByIdEstadoPago(int idEstadoPago)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdEstadoPago", idEstadoPago)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "PagoSelectAllByIdEstadoPago", parameters))
			{
				List<PagoEntidad> pagoEntidadList = new List<PagoEntidad>();
				while (dataReader.Read())
				{
					PagoEntidad pagoEntidad = MapDataReader(dataReader);
					pagoEntidadList.Add(pagoEntidad);
				}

				return pagoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Pago table by a foreign key.
		/// </summary>
		public List<PagoEntidad> SelectAllByIdFormaPago(int idFormaPago)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdFormaPago", idFormaPago)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "PagoSelectAllByIdFormaPago", parameters))
			{
				List<PagoEntidad> pagoEntidadList = new List<PagoEntidad>();
				while (dataReader.Read())
				{
					PagoEntidad pagoEntidad = MapDataReader(dataReader);
					pagoEntidadList.Add(pagoEntidad);
				}

				return pagoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Pago table by a foreign key.
		/// </summary>
		public List<PagoEntidad> SelectAllByIdPedido(int idPedido)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPedido", idPedido)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "PagoSelectAllByIdPedido", parameters))
			{
				List<PagoEntidad> pagoEntidadList = new List<PagoEntidad>();
				while (dataReader.Read())
				{
					PagoEntidad pagoEntidad = MapDataReader(dataReader);
					pagoEntidadList.Add(pagoEntidad);
				}

				return pagoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Pago table by a foreign key.
		/// </summary>
		public string SelectAllByNroComprobante_IdSucursal_IdTipoComprobante_CUITJson(int nroComprobante, int idSucursal, int idTipoComprobante, int cUIT)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@NroComprobante", nroComprobante),
				new SqlParameter("@IdSucursal", idSucursal),
				new SqlParameter("@IdTipoComprobante", idTipoComprobante),
				new SqlParameter("@CUIT", cUIT)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "PagoSelectAllByNroComprobante_IdSucursal_IdTipoComprobante_CUIT", parameters);
		}

		/// <summary>
		/// Selects all records from the Pago table by a foreign key.
		/// </summary>
		public string SelectAllByCUITJson(int cUIT)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "PagoSelectAllByCUIT", parameters);
		}

		/// <summary>
		/// Selects all records from the Pago table by a foreign key.
		/// </summary>
		public string SelectAllByIdEstadoPagoJson(int idEstadoPago)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdEstadoPago", idEstadoPago)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "PagoSelectAllByIdEstadoPago", parameters);
		}

		/// <summary>
		/// Selects all records from the Pago table by a foreign key.
		/// </summary>
		public string SelectAllByIdFormaPagoJson(int idFormaPago)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdFormaPago", idFormaPago)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "PagoSelectAllByIdFormaPago", parameters);
		}

		/// <summary>
		/// Selects all records from the Pago table by a foreign key.
		/// </summary>
		public string SelectAllByIdPedidoJson(int idPedido)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPedido", idPedido)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "PagoSelectAllByIdPedido", parameters);
		}

		/// <summary>
		/// Creates a new instance of the PagoEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private PagoEntidad MapDataReader(SqlDataReader dataReader)
		{
			PagoEntidad pagoEntidad = new PagoEntidad();
			pagoEntidad.IdPago = dataReader.GetInt32("IdPago", 0);
			pagoEntidad.IdPedido = dataReader.GetInt32("IdPedido", 0);
			pagoEntidad.FechaPago = dataReader.GetDateTime("FechaPago", new DateTime(0));
			pagoEntidad.IdEstadoPago = dataReader.GetInt32("IdEstadoPago", 0);
			pagoEntidad.IdFormaPago = dataReader.GetInt32("IdFormaPago", 0);
			pagoEntidad.MontoPago = dataReader.GetDecimal("MontoPago", Decimal.Zero);
			pagoEntidad.NroComprobante = dataReader.GetInt32("NroComprobante", 0);
			pagoEntidad.IdSucursal = dataReader.GetInt32("IdSucursal", 0);
			pagoEntidad.IdTipoComprobante = dataReader.GetInt32("IdTipoComprobante", 0);
			pagoEntidad.CUIT = dataReader.GetInt32("CUIT", 0);

			return pagoEntidad;
		}

		#endregion
	}
}
