using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class EstadoPagoDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public EstadoPagoDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the EstadoPago table.
		/// </summary>
		public void Insert(EstadoPagoEntidad estadoPago)
		{
			ValidationUtility.ValidateArgument("estadoPago", estadoPago);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DescripEstadoPago", estadoPago.DescripEstadoPago)
			};

			estadoPago.IdEstadoPago = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "EstadoPagoInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the EstadoPago table.
		/// </summary>
		public void Update(EstadoPagoEntidad estadoPago)
		{
			ValidationUtility.ValidateArgument("estadoPago", estadoPago);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdEstadoPago", estadoPago.IdEstadoPago),
				new SqlParameter("@DescripEstadoPago", estadoPago.DescripEstadoPago)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "EstadoPagoUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the EstadoPago table by its primary key.
		/// </summary>
		public void Delete(int idEstadoPago)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdEstadoPago", idEstadoPago)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "EstadoPagoDelete", parameters);
		}

		/// <summary>
		/// Selects a single record from the EstadoPago table.
		/// </summary>
		public EstadoPagoEntidad Select(int idEstadoPago)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdEstadoPago", idEstadoPago)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "EstadoPagoSelect", parameters))
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
		/// Selects a single record from the EstadoPago table.
		/// </summary>
		public string SelectJson(int idEstadoPago)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdEstadoPago", idEstadoPago)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "EstadoPagoSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the EstadoPago table.
		/// </summary>
		public List<EstadoPagoEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "EstadoPagoSelectAll"))
			{
				List<EstadoPagoEntidad> estadoPagoEntidadList = new List<EstadoPagoEntidad>();
				while (dataReader.Read())
				{
					EstadoPagoEntidad estadoPagoEntidad = MapDataReader(dataReader);
					estadoPagoEntidadList.Add(estadoPagoEntidad);
				}

				return estadoPagoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the EstadoPago table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "EstadoPagoSelectAll");
		}

		/// <summary>
		/// Creates a new instance of the EstadoPagoEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private EstadoPagoEntidad MapDataReader(SqlDataReader dataReader)
		{
			EstadoPagoEntidad estadoPagoEntidad = new EstadoPagoEntidad();
			estadoPagoEntidad.IdEstadoPago = dataReader.GetInt32("IdEstadoPago", 0);
			estadoPagoEntidad.DescripEstadoPago = dataReader.GetString("DescripEstadoPago", null);

			return estadoPagoEntidad;
		}

		#endregion
	}
}
