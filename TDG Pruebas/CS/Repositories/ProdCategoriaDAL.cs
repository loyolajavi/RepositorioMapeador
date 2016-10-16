using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class ProdCategoriaDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public ProdCategoriaDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the ProdCategoria table.
		/// </summary>
		public void Insert(ProdCategoriaEntidad prodCategoria)
		{
			ValidationUtility.ValidateArgument("prodCategoria", prodCategoria);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", prodCategoria.IdProducto),
				new SqlParameter("@IdCategoria", prodCategoria.IdCategoria)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ProdCategoriaInsert", parameters);
		}

		/// <summary>
		/// Deletes a record from the ProdCategoria table by its primary key.
		/// </summary>
		public void Delete(int idProducto, int idCategoria)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto),
				new SqlParameter("@IdCategoria", idCategoria)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ProdCategoriaDelete", parameters);
		}

		/// <summary>
		/// Deletes a record from the ProdCategoria table by a foreign key.
		/// </summary>
		public void DeleteAllByIdCategoria(int idCategoria)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdCategoria", idCategoria)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ProdCategoriaDeleteAllByIdCategoria", parameters);
		}

		/// <summary>
		/// Deletes a record from the ProdCategoria table by a foreign key.
		/// </summary>
		public void DeleteAllByIdProducto(int idProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ProdCategoriaDeleteAllByIdProducto", parameters);
		}

		/// <summary>
		/// Selects all records from the ProdCategoria table by a foreign key.
		/// </summary>
		public List<ProdCategoriaEntidad> SelectAllByIdCategoria(int idCategoria)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdCategoria", idCategoria)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ProdCategoriaSelectAllByIdCategoria", parameters))
			{
				List<ProdCategoriaEntidad> prodCategoriaEntidadList = new List<ProdCategoriaEntidad>();
				while (dataReader.Read())
				{
					ProdCategoriaEntidad prodCategoriaEntidad = MapDataReader(dataReader);
					prodCategoriaEntidadList.Add(prodCategoriaEntidad);
				}

				return prodCategoriaEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the ProdCategoria table by a foreign key.
		/// </summary>
		public List<ProdCategoriaEntidad> SelectAllByIdProducto(int idProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ProdCategoriaSelectAllByIdProducto", parameters))
			{
				List<ProdCategoriaEntidad> prodCategoriaEntidadList = new List<ProdCategoriaEntidad>();
				while (dataReader.Read())
				{
					ProdCategoriaEntidad prodCategoriaEntidad = MapDataReader(dataReader);
					prodCategoriaEntidadList.Add(prodCategoriaEntidad);
				}

				return prodCategoriaEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the ProdCategoria table by a foreign key.
		/// </summary>
		public string SelectAllByIdCategoriaJson(int idCategoria)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdCategoria", idCategoria)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ProdCategoriaSelectAllByIdCategoria", parameters);
		}

		/// <summary>
		/// Selects all records from the ProdCategoria table by a foreign key.
		/// </summary>
		public string SelectAllByIdProductoJson(int idProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ProdCategoriaSelectAllByIdProducto", parameters);
		}

		/// <summary>
		/// Creates a new instance of the ProdCategoriaEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private ProdCategoriaEntidad MapDataReader(SqlDataReader dataReader)
		{
			ProdCategoriaEntidad prodCategoriaEntidad = new ProdCategoriaEntidad();
			prodCategoriaEntidad.IdProducto = dataReader.GetInt32("IdProducto", 0);
			prodCategoriaEntidad.IdCategoria = dataReader.GetInt32("IdCategoria", 0);

			return prodCategoriaEntidad;
		}

		#endregion
	}
}
