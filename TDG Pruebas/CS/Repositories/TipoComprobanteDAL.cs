using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class TipoComprobanteDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public TipoComprobanteDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the TipoComprobante table.
		/// </summary>
		public void Insert(TipoComprobanteEntidad tipoComprobante)
		{
			ValidationUtility.ValidateArgument("tipoComprobante", tipoComprobante);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DescripTipoComprobante", tipoComprobante.DescripTipoComprobante)
			};

			tipoComprobante.IdTipoComprobante = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "TipoComprobanteInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the TipoComprobante table.
		/// </summary>
		public void Update(TipoComprobanteEntidad tipoComprobante)
		{
			ValidationUtility.ValidateArgument("tipoComprobante", tipoComprobante);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTipoComprobante", tipoComprobante.IdTipoComprobante),
				new SqlParameter("@DescripTipoComprobante", tipoComprobante.DescripTipoComprobante)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "TipoComprobanteUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the TipoComprobante table by its primary key.
		/// </summary>
		public void Delete(int idTipoComprobante)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTipoComprobante", idTipoComprobante)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "TipoComprobanteDelete", parameters);
		}

		/// <summary>
		/// Selects a single record from the TipoComprobante table.
		/// </summary>
		public TipoComprobanteEntidad Select(int idTipoComprobante)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTipoComprobante", idTipoComprobante)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "TipoComprobanteSelect", parameters))
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
		/// Selects a single record from the TipoComprobante table.
		/// </summary>
		public string SelectJson(int idTipoComprobante)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTipoComprobante", idTipoComprobante)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "TipoComprobanteSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the TipoComprobante table.
		/// </summary>
		public List<TipoComprobanteEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "TipoComprobanteSelectAll"))
			{
				List<TipoComprobanteEntidad> tipoComprobanteEntidadList = new List<TipoComprobanteEntidad>();
				while (dataReader.Read())
				{
					TipoComprobanteEntidad tipoComprobanteEntidad = MapDataReader(dataReader);
					tipoComprobanteEntidadList.Add(tipoComprobanteEntidad);
				}

				return tipoComprobanteEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the TipoComprobante table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "TipoComprobanteSelectAll");
		}

		/// <summary>
		/// Creates a new instance of the TipoComprobanteEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private TipoComprobanteEntidad MapDataReader(SqlDataReader dataReader)
		{
			TipoComprobanteEntidad tipoComprobanteEntidad = new TipoComprobanteEntidad();
			tipoComprobanteEntidad.IdTipoComprobante = dataReader.GetInt32("IdTipoComprobante", 0);
			tipoComprobanteEntidad.DescripTipoComprobante = dataReader.GetString("DescripTipoComprobante", null);

			return tipoComprobanteEntidad;
		}

		#endregion
	}
}
