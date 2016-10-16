using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

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

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "EstadoProductoSelect", parameters))
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
		/// Selects a single record from the EstadoProducto table.
		/// </summary>
		public string SelectJson(int idEstadoProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdEstadoProducto", idEstadoProducto)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "EstadoProductoSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the EstadoProducto table.
		/// </summary>
		public List<EstadoProductoEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "EstadoProductoSelectAll"))
			{
				List<EstadoProductoEntidad> estadoProductoEntidadList = new List<EstadoProductoEntidad>();
				while (dataReader.Read())
				{
					EstadoProductoEntidad estadoProductoEntidad = MapDataReader(dataReader);
					estadoProductoEntidadList.Add(estadoProductoEntidad);
				}

				return estadoProductoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the EstadoProducto table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "EstadoProductoSelectAll");
		}

		/// <summary>
		/// Creates a new instance of the EstadoProductoEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private EstadoProductoEntidad MapDataReader(SqlDataReader dataReader)
		{
			EstadoProductoEntidad estadoProductoEntidad = new EstadoProductoEntidad();
			estadoProductoEntidad.IdEstadoProducto = dataReader.GetInt32("IdEstadoProducto", 0);
			estadoProductoEntidad.DescripEstadoProducto = dataReader.GetString("DescripEstadoProducto", null);

			return estadoProductoEntidad;
		}

		#endregion
	}
}
