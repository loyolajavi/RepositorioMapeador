using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class EstadoPedidoDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public EstadoPedidoDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the EstadoPedido table.
		/// </summary>
		public void Insert(EstadoPedidoEntidad estadoPedido)
		{
			ValidationUtility.ValidateArgument("estadoPedido", estadoPedido);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DescripcionEstadoPedido", estadoPedido.DescripcionEstadoPedido)
			};

			estadoPedido.IdEstadoPedido = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "EstadoPedidoInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the EstadoPedido table.
		/// </summary>
		public void Update(EstadoPedidoEntidad estadoPedido)
		{
			ValidationUtility.ValidateArgument("estadoPedido", estadoPedido);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdEstadoPedido", estadoPedido.IdEstadoPedido),
				new SqlParameter("@DescripcionEstadoPedido", estadoPedido.DescripcionEstadoPedido)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "EstadoPedidoUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the EstadoPedido table by its primary key.
		/// </summary>
		public void Delete(int idEstadoPedido)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdEstadoPedido", idEstadoPedido)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "EstadoPedidoDelete", parameters);
		}

		/// <summary>
		/// Selects a single record from the EstadoPedido table.
		/// </summary>
		public EstadoPedidoEntidad Select(int idEstadoPedido)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdEstadoPedido", idEstadoPedido)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "EstadoPedidoSelect", parameters))
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
		/// Selects a single record from the EstadoPedido table.
		/// </summary>
		public string SelectJson(int idEstadoPedido)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdEstadoPedido", idEstadoPedido)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "EstadoPedidoSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the EstadoPedido table.
		/// </summary>
		public List<EstadoPedidoEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "EstadoPedidoSelectAll"))
			{
				List<EstadoPedidoEntidad> estadoPedidoEntidadList = new List<EstadoPedidoEntidad>();
				while (dataReader.Read())
				{
					EstadoPedidoEntidad estadoPedidoEntidad = MapDataReader(dataReader);
					estadoPedidoEntidadList.Add(estadoPedidoEntidad);
				}

				return estadoPedidoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the EstadoPedido table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "EstadoPedidoSelectAll");
		}

		/// <summary>
		/// Creates a new instance of the EstadoPedidoEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private EstadoPedidoEntidad MapDataReader(SqlDataReader dataReader)
		{
			EstadoPedidoEntidad estadoPedidoEntidad = new EstadoPedidoEntidad();
			estadoPedidoEntidad.IdEstadoPedido = dataReader.GetInt32("IdEstadoPedido", 0);
			estadoPedidoEntidad.DescripcionEstadoPedido = dataReader.GetString("DescripcionEstadoPedido", null);

			return estadoPedidoEntidad;
		}

		#endregion
	}
}
