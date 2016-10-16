using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class ProductoDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public ProductoDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Producto table.
		/// </summary>
		public void Insert(ProductoEntidad producto)
		{
			ValidationUtility.ValidateArgument("producto", producto);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CodigoProducto", producto.CodigoProducto),
				new SqlParameter("@PrecioUnitario", producto.PrecioUnitario),
				new SqlParameter("@IdMarca", producto.IdMarca),
				new SqlParameter("@CUIT", producto.CUIT),
				new SqlParameter("@IdIvaProducto", producto.IdIvaProducto),
				new SqlParameter("@DescripProducto", producto.DescripProducto),
				new SqlParameter("@IdEstadoProducto", producto.IdEstadoProducto)
			};

			producto.IdProducto = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "ProductoInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the Producto table.
		/// </summary>
		public void Update(ProductoEntidad producto)
		{
			ValidationUtility.ValidateArgument("producto", producto);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", producto.IdProducto),
				new SqlParameter("@CodigoProducto", producto.CodigoProducto),
				new SqlParameter("@PrecioUnitario", producto.PrecioUnitario),
				new SqlParameter("@IdMarca", producto.IdMarca),
				new SqlParameter("@CUIT", producto.CUIT),
				new SqlParameter("@IdIvaProducto", producto.IdIvaProducto),
				new SqlParameter("@DescripProducto", producto.DescripProducto),
				new SqlParameter("@IdEstadoProducto", producto.IdEstadoProducto)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ProductoUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the Producto table by its primary key.
		/// </summary>
		public void Delete(int idProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ProductoDelete", parameters);
		}

		/// <summary>
		/// Deletes a record from the Producto table by a foreign key.
		/// </summary>
		public void DeleteAllByCUIT(int cUIT)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ProductoDeleteAllByCUIT", parameters);
		}

		/// <summary>
		/// Deletes a record from the Producto table by a foreign key.
		/// </summary>
		public void DeleteAllByIdEstadoProducto(int idEstadoProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdEstadoProducto", idEstadoProducto)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ProductoDeleteAllByIdEstadoProducto", parameters);
		}

		/// <summary>
		/// Deletes a record from the Producto table by a foreign key.
		/// </summary>
		public void DeleteAllByIdIvaProducto(int idIvaProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdIvaProducto", idIvaProducto)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ProductoDeleteAllByIdIvaProducto", parameters);
		}

		/// <summary>
		/// Deletes a record from the Producto table by a foreign key.
		/// </summary>
		public void DeleteAllByIdMarca(int idMarca)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdMarca", idMarca)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ProductoDeleteAllByIdMarca", parameters);
		}

		/// <summary>
		/// Selects a single record from the Producto table.
		/// </summary>
		public ProductoEntidad Select(int idProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ProductoSelect", parameters))
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
		/// Selects a single record from the Producto table.
		/// </summary>
		public string SelectJson(int idProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ProductoSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the Producto table.
		/// </summary>
		public List<ProductoEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ProductoSelectAll"))
			{
				List<ProductoEntidad> productoEntidadList = new List<ProductoEntidad>();
				while (dataReader.Read())
				{
					ProductoEntidad productoEntidad = MapDataReader(dataReader);
					productoEntidadList.Add(productoEntidad);
				}

				return productoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Producto table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ProductoSelectAll");
		}

		/// <summary>
		/// Selects all records from the Producto table by a foreign key.
		/// </summary>
		public List<ProductoEntidad> SelectAllByCUIT(int cUIT)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ProductoSelectAllByCUIT", parameters))
			{
				List<ProductoEntidad> productoEntidadList = new List<ProductoEntidad>();
				while (dataReader.Read())
				{
					ProductoEntidad productoEntidad = MapDataReader(dataReader);
					productoEntidadList.Add(productoEntidad);
				}

				return productoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Producto table by a foreign key.
		/// </summary>
		public List<ProductoEntidad> SelectAllByIdEstadoProducto(int idEstadoProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdEstadoProducto", idEstadoProducto)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ProductoSelectAllByIdEstadoProducto", parameters))
			{
				List<ProductoEntidad> productoEntidadList = new List<ProductoEntidad>();
				while (dataReader.Read())
				{
					ProductoEntidad productoEntidad = MapDataReader(dataReader);
					productoEntidadList.Add(productoEntidad);
				}

				return productoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Producto table by a foreign key.
		/// </summary>
		public List<ProductoEntidad> SelectAllByIdIvaProducto(int idIvaProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdIvaProducto", idIvaProducto)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ProductoSelectAllByIdIvaProducto", parameters))
			{
				List<ProductoEntidad> productoEntidadList = new List<ProductoEntidad>();
				while (dataReader.Read())
				{
					ProductoEntidad productoEntidad = MapDataReader(dataReader);
					productoEntidadList.Add(productoEntidad);
				}

				return productoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Producto table by a foreign key.
		/// </summary>
		public List<ProductoEntidad> SelectAllByIdMarca(int idMarca)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdMarca", idMarca)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ProductoSelectAllByIdMarca", parameters))
			{
				List<ProductoEntidad> productoEntidadList = new List<ProductoEntidad>();
				while (dataReader.Read())
				{
					ProductoEntidad productoEntidad = MapDataReader(dataReader);
					productoEntidadList.Add(productoEntidad);
				}

				return productoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Producto table by a foreign key.
		/// </summary>
		public string SelectAllByCUITJson(int cUIT)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ProductoSelectAllByCUIT", parameters);
		}

		/// <summary>
		/// Selects all records from the Producto table by a foreign key.
		/// </summary>
		public string SelectAllByIdEstadoProductoJson(int idEstadoProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdEstadoProducto", idEstadoProducto)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ProductoSelectAllByIdEstadoProducto", parameters);
		}

		/// <summary>
		/// Selects all records from the Producto table by a foreign key.
		/// </summary>
		public string SelectAllByIdIvaProductoJson(int idIvaProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdIvaProducto", idIvaProducto)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ProductoSelectAllByIdIvaProducto", parameters);
		}

		/// <summary>
		/// Selects all records from the Producto table by a foreign key.
		/// </summary>
		public string SelectAllByIdMarcaJson(int idMarca)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdMarca", idMarca)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ProductoSelectAllByIdMarca", parameters);
		}

		/// <summary>
		/// Creates a new instance of the ProductoEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private ProductoEntidad MapDataReader(SqlDataReader dataReader)
		{
			ProductoEntidad productoEntidad = new ProductoEntidad();
			productoEntidad.IdProducto = dataReader.GetInt32("IdProducto", 0);
			productoEntidad.CodigoProducto = dataReader.GetString("CodigoProducto", null);
			productoEntidad.PrecioUnitario = dataReader.GetDecimal("PrecioUnitario", Decimal.Zero);
			productoEntidad.IdMarca = dataReader.GetInt32("IdMarca", 0);
			productoEntidad.CUIT = dataReader.GetInt32("CUIT", 0);
			productoEntidad.IdIvaProducto = dataReader.GetInt32("IdIvaProducto", 0);
			productoEntidad.DescripProducto = dataReader.GetString("DescripProducto", null);
			productoEntidad.IdEstadoProducto = dataReader.GetInt32("IdEstadoProducto", 0);

			return productoEntidad;
		}

		#endregion
	}
}
