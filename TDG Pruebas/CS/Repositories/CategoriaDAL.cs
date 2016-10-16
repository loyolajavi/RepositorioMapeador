using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class CategoriaDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public CategoriaDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Categoria table.
		/// </summary>
		public void Insert(CategoriaEntidad categoria)
		{
			ValidationUtility.ValidateArgument("categoria", categoria);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DescripCategoria", categoria.DescripCategoria)
			};

			categoria.IdCategoria = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "CategoriaInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the Categoria table.
		/// </summary>
		public void Update(CategoriaEntidad categoria)
		{
			ValidationUtility.ValidateArgument("categoria", categoria);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdCategoria", categoria.IdCategoria),
				new SqlParameter("@DescripCategoria", categoria.DescripCategoria)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "CategoriaUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the Categoria table by its primary key.
		/// </summary>
		public void Delete(int idCategoria)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdCategoria", idCategoria)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "CategoriaDelete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Categoria table.
		/// </summary>
		public CategoriaEntidad Select(int idCategoria)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdCategoria", idCategoria)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "CategoriaSelect", parameters))
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
		/// Selects a single record from the Categoria table.
		/// </summary>
		public string SelectJson(int idCategoria)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdCategoria", idCategoria)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "CategoriaSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the Categoria table.
		/// </summary>
		public List<CategoriaEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "CategoriaSelectAll"))
			{
				List<CategoriaEntidad> categoriaEntidadList = new List<CategoriaEntidad>();
				while (dataReader.Read())
				{
					CategoriaEntidad categoriaEntidad = MapDataReader(dataReader);
					categoriaEntidadList.Add(categoriaEntidad);
				}

				return categoriaEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Categoria table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "CategoriaSelectAll");
		}

		/// <summary>
		/// Creates a new instance of the CategoriaEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private CategoriaEntidad MapDataReader(SqlDataReader dataReader)
		{
			CategoriaEntidad categoriaEntidad = new CategoriaEntidad();
			categoriaEntidad.IdCategoria = dataReader.GetInt32("IdCategoria", 0);
			categoriaEntidad.DescripCategoria = dataReader.GetString("DescripCategoria", null);

			return categoriaEntidad;
		}

		#endregion
	}
}
