using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class ComprobanteDetalleDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public ComprobanteDetalleDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the ComprobanteDetalle table.
		/// </summary>
		public void Insert(ComprobanteDetalleEntidad comprobanteDetalle)
		{
			ValidationUtility.ValidateArgument("comprobanteDetalle", comprobanteDetalle);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdComprobanteDetalle", comprobanteDetalle.IdComprobanteDetalle),
				new SqlParameter("@NroComprobante", comprobanteDetalle.NroComprobante),
				new SqlParameter("@IdSucursal", comprobanteDetalle.IdSucursal),
				new SqlParameter("@IdTipoComprobante", comprobanteDetalle.IdTipoComprobante),
				new SqlParameter("@CUIT", comprobanteDetalle.CUIT),
				new SqlParameter("@IdProducto", comprobanteDetalle.IdProducto),
				new SqlParameter("@CantidadProducto", comprobanteDetalle.CantidadProducto),
				new SqlParameter("@PrecioUnitarioFact", comprobanteDetalle.PrecioUnitarioFact)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ComprobanteDetalleInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the ComprobanteDetalle table.
		/// </summary>
		public void Update(ComprobanteDetalleEntidad comprobanteDetalle)
		{
			ValidationUtility.ValidateArgument("comprobanteDetalle", comprobanteDetalle);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdComprobanteDetalle", comprobanteDetalle.IdComprobanteDetalle),
				new SqlParameter("@NroComprobante", comprobanteDetalle.NroComprobante),
				new SqlParameter("@IdSucursal", comprobanteDetalle.IdSucursal),
				new SqlParameter("@IdTipoComprobante", comprobanteDetalle.IdTipoComprobante),
				new SqlParameter("@CUIT", comprobanteDetalle.CUIT),
				new SqlParameter("@IdProducto", comprobanteDetalle.IdProducto),
				new SqlParameter("@CantidadProducto", comprobanteDetalle.CantidadProducto),
				new SqlParameter("@PrecioUnitarioFact", comprobanteDetalle.PrecioUnitarioFact)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ComprobanteDetalleUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the ComprobanteDetalle table by its primary key.
		/// </summary>
		public void Delete(int idComprobanteDetalle, int nroComprobante, int idSucursal, int idTipoComprobante, int cUIT)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdComprobanteDetalle", idComprobanteDetalle),
				new SqlParameter("@NroComprobante", nroComprobante),
				new SqlParameter("@IdSucursal", idSucursal),
				new SqlParameter("@IdTipoComprobante", idTipoComprobante),
				new SqlParameter("@CUIT", cUIT)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ComprobanteDetalleDelete", parameters);
		}

		/// <summary>
		/// Deletes a record from the ComprobanteDetalle table by a foreign key.
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

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ComprobanteDetalleDeleteAllByNroComprobante_IdSucursal_IdTipoComprobante_CUIT", parameters);
		}

		/// <summary>
		/// Deletes a record from the ComprobanteDetalle table by a foreign key.
		/// </summary>
		public void DeleteAllByIdProducto(int idProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ComprobanteDetalleDeleteAllByIdProducto", parameters);
		}

		/// <summary>
		/// Selects a single record from the ComprobanteDetalle table.
		/// </summary>
		public ComprobanteDetalleEntidad Select(int idComprobanteDetalle, int nroComprobante, int idSucursal, int idTipoComprobante, int cUIT)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdComprobanteDetalle", idComprobanteDetalle),
				new SqlParameter("@NroComprobante", nroComprobante),
				new SqlParameter("@IdSucursal", idSucursal),
				new SqlParameter("@IdTipoComprobante", idTipoComprobante),
				new SqlParameter("@CUIT", cUIT)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ComprobanteDetalleSelect", parameters))
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
		/// Selects a single record from the ComprobanteDetalle table.
		/// </summary>
		public string SelectJson(int idComprobanteDetalle, int nroComprobante, int idSucursal, int idTipoComprobante, int cUIT)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdComprobanteDetalle", idComprobanteDetalle),
				new SqlParameter("@NroComprobante", nroComprobante),
				new SqlParameter("@IdSucursal", idSucursal),
				new SqlParameter("@IdTipoComprobante", idTipoComprobante),
				new SqlParameter("@CUIT", cUIT)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ComprobanteDetalleSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the ComprobanteDetalle table.
		/// </summary>
		public List<ComprobanteDetalleEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ComprobanteDetalleSelectAll"))
			{
				List<ComprobanteDetalleEntidad> comprobanteDetalleEntidadList = new List<ComprobanteDetalleEntidad>();
				while (dataReader.Read())
				{
					ComprobanteDetalleEntidad comprobanteDetalleEntidad = MapDataReader(dataReader);
					comprobanteDetalleEntidadList.Add(comprobanteDetalleEntidad);
				}

				return comprobanteDetalleEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the ComprobanteDetalle table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ComprobanteDetalleSelectAll");
		}

		/// <summary>
		/// Selects all records from the ComprobanteDetalle table by a foreign key.
		/// </summary>
		public List<ComprobanteDetalleEntidad> SelectAllByNroComprobante_IdSucursal_IdTipoComprobante_CUIT(int nroComprobante, int idSucursal, int idTipoComprobante, int cUIT)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@NroComprobante", nroComprobante),
				new SqlParameter("@IdSucursal", idSucursal),
				new SqlParameter("@IdTipoComprobante", idTipoComprobante),
				new SqlParameter("@CUIT", cUIT)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ComprobanteDetalleSelectAllByNroComprobante_IdSucursal_IdTipoComprobante_CUIT", parameters))
			{
				List<ComprobanteDetalleEntidad> comprobanteDetalleEntidadList = new List<ComprobanteDetalleEntidad>();
				while (dataReader.Read())
				{
					ComprobanteDetalleEntidad comprobanteDetalleEntidad = MapDataReader(dataReader);
					comprobanteDetalleEntidadList.Add(comprobanteDetalleEntidad);
				}

				return comprobanteDetalleEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the ComprobanteDetalle table by a foreign key.
		/// </summary>
		public List<ComprobanteDetalleEntidad> SelectAllByIdProducto(int idProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ComprobanteDetalleSelectAllByIdProducto", parameters))
			{
				List<ComprobanteDetalleEntidad> comprobanteDetalleEntidadList = new List<ComprobanteDetalleEntidad>();
				while (dataReader.Read())
				{
					ComprobanteDetalleEntidad comprobanteDetalleEntidad = MapDataReader(dataReader);
					comprobanteDetalleEntidadList.Add(comprobanteDetalleEntidad);
				}

				return comprobanteDetalleEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the ComprobanteDetalle table by a foreign key.
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

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ComprobanteDetalleSelectAllByNroComprobante_IdSucursal_IdTipoComprobante_CUIT", parameters);
		}

		/// <summary>
		/// Selects all records from the ComprobanteDetalle table by a foreign key.
		/// </summary>
		public string SelectAllByIdProductoJson(int idProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ComprobanteDetalleSelectAllByIdProducto", parameters);
		}

		/// <summary>
		/// Creates a new instance of the ComprobanteDetalleEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private ComprobanteDetalleEntidad MapDataReader(SqlDataReader dataReader)
		{
			ComprobanteDetalleEntidad comprobanteDetalleEntidad = new ComprobanteDetalleEntidad();
			comprobanteDetalleEntidad.IdComprobanteDetalle = dataReader.GetInt32("IdComprobanteDetalle", 0);
			comprobanteDetalleEntidad.NroComprobante = dataReader.GetInt32("NroComprobante", 0);
			comprobanteDetalleEntidad.IdSucursal = dataReader.GetInt32("IdSucursal", 0);
			comprobanteDetalleEntidad.IdTipoComprobante = dataReader.GetInt32("IdTipoComprobante", 0);
			comprobanteDetalleEntidad.CUIT = dataReader.GetInt32("CUIT", 0);
			comprobanteDetalleEntidad.IdProducto = dataReader.GetInt32("IdProducto", 0);
			comprobanteDetalleEntidad.CantidadProducto = dataReader.GetInt32("CantidadProducto", 0);
			comprobanteDetalleEntidad.PrecioUnitarioFact = dataReader.GetDecimal("PrecioUnitarioFact", Decimal.Zero);

			return comprobanteDetalleEntidad;
		}

		#endregion
	}
}
