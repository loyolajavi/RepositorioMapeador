using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class StockSucursalDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public StockSucursalDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the StockSucursal table.
		/// </summary>
		public void Insert(StockSucursalEntidad stockSucursal)
		{
			ValidationUtility.ValidateArgument("stockSucursal", stockSucursal);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", stockSucursal.IdProducto),
				new SqlParameter("@IdSucursal", stockSucursal.IdSucursal),
				new SqlParameter("@CantidadProducto", stockSucursal.CantidadProducto)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "StockSucursalInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the StockSucursal table.
		/// </summary>
		public void Update(StockSucursalEntidad stockSucursal)
		{
			ValidationUtility.ValidateArgument("stockSucursal", stockSucursal);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", stockSucursal.IdProducto),
				new SqlParameter("@IdSucursal", stockSucursal.IdSucursal),
				new SqlParameter("@CantidadProducto", stockSucursal.CantidadProducto)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "StockSucursalUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the StockSucursal table by its primary key.
		/// </summary>
		public void Delete(int idProducto, int idSucursal)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto),
				new SqlParameter("@IdSucursal", idSucursal)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "StockSucursalDelete", parameters);
		}

		/// <summary>
		/// Deletes a record from the StockSucursal table by a foreign key.
		/// </summary>
		public void DeleteAllByIdProducto(int idProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "StockSucursalDeleteAllByIdProducto", parameters);
		}

		/// <summary>
		/// Deletes a record from the StockSucursal table by a foreign key.
		/// </summary>
		public void DeleteAllByIdSucursal(int idSucursal)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdSucursal", idSucursal)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "StockSucursalDeleteAllByIdSucursal", parameters);
		}

		/// <summary>
		/// Selects a single record from the StockSucursal table.
		/// </summary>
		public StockSucursalEntidad Select(int idProducto, int idSucursal)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto),
				new SqlParameter("@IdSucursal", idSucursal)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "StockSucursalSelect", parameters))
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
		/// Selects a single record from the StockSucursal table.
		/// </summary>
		public string SelectJson(int idProducto, int idSucursal)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto),
				new SqlParameter("@IdSucursal", idSucursal)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "StockSucursalSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the StockSucursal table.
		/// </summary>
		public List<StockSucursalEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "StockSucursalSelectAll"))
			{
				List<StockSucursalEntidad> stockSucursalEntidadList = new List<StockSucursalEntidad>();
				while (dataReader.Read())
				{
					StockSucursalEntidad stockSucursalEntidad = MapDataReader(dataReader);
					stockSucursalEntidadList.Add(stockSucursalEntidad);
				}

				return stockSucursalEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the StockSucursal table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "StockSucursalSelectAll");
		}

		/// <summary>
		/// Selects all records from the StockSucursal table by a foreign key.
		/// </summary>
		public List<StockSucursalEntidad> SelectAllByIdProducto(int idProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "StockSucursalSelectAllByIdProducto", parameters))
			{
				List<StockSucursalEntidad> stockSucursalEntidadList = new List<StockSucursalEntidad>();
				while (dataReader.Read())
				{
					StockSucursalEntidad stockSucursalEntidad = MapDataReader(dataReader);
					stockSucursalEntidadList.Add(stockSucursalEntidad);
				}

				return stockSucursalEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the StockSucursal table by a foreign key.
		/// </summary>
		public List<StockSucursalEntidad> SelectAllByIdSucursal(int idSucursal)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdSucursal", idSucursal)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "StockSucursalSelectAllByIdSucursal", parameters))
			{
				List<StockSucursalEntidad> stockSucursalEntidadList = new List<StockSucursalEntidad>();
				while (dataReader.Read())
				{
					StockSucursalEntidad stockSucursalEntidad = MapDataReader(dataReader);
					stockSucursalEntidadList.Add(stockSucursalEntidad);
				}

				return stockSucursalEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the StockSucursal table by a foreign key.
		/// </summary>
		public string SelectAllByIdProductoJson(int idProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "StockSucursalSelectAllByIdProducto", parameters);
		}

		/// <summary>
		/// Selects all records from the StockSucursal table by a foreign key.
		/// </summary>
		public string SelectAllByIdSucursalJson(int idSucursal)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdSucursal", idSucursal)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "StockSucursalSelectAllByIdSucursal", parameters);
		}

		/// <summary>
		/// Creates a new instance of the StockSucursalEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private StockSucursalEntidad MapDataReader(SqlDataReader dataReader)
		{
			StockSucursalEntidad stockSucursalEntidad = new StockSucursalEntidad();
			stockSucursalEntidad.IdProducto = dataReader.GetInt32("IdProducto", 0);
			stockSucursalEntidad.IdSucursal = dataReader.GetInt32("IdSucursal", 0);
			stockSucursalEntidad.CantidadProducto = dataReader.GetInt32("CantidadProducto", 0);

			return stockSucursalEntidad;
		}

		#endregion
	}
}
