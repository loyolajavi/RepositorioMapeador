using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TFI.HelperDAL;


namespace TFI.DAL.DAL
{
	public class CategoriaDAL
	{

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

			categoria.IdCategoria = (int) SqlClientUtility.ExecuteScalar(SqlClientUtility.connectionStringName, CommandType.StoredProcedure, "CategoriaInsert", parameters);
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

			SqlClientUtility.ExecuteNonQuery(SqlClientUtility.connectionStringName, CommandType.StoredProcedure, "CategoriaUpdate", parameters);
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

			SqlClientUtility.ExecuteNonQuery(SqlClientUtility.connectionStringName, CommandType.StoredProcedure, "CategoriaDelete", parameters);
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

			using (DataTable dt = SqlClientUtility.ExecuteDataTable(SqlClientUtility.connectionStringName, CommandType.StoredProcedure, "CategoriaSelect", parameters))
			{
                CategoriaEntidad CategoriaEntidad = new CategoriaEntidad();

                CategoriaEntidad = Mapeador.MapearFirst<CategoriaEntidad>(dt);

                return CategoriaEntidad;
			}
		}


		/// <summary>
		/// Selects all records from the Categoria table.
		/// </summary>
		public List<CategoriaEntidad> SelectAll()
		{
			using (DataTable dt = SqlClientUtility.ExecuteDataTable(SqlClientUtility.connectionStringName, CommandType.StoredProcedure, "CategoriaSelectAll"))
			{
				List<CategoriaEntidad> categoriaEntidadList = new List<CategoriaEntidad>();

                categoriaEntidadList = Mapeador.Mapear<CategoriaEntidad>(dt);

				return categoriaEntidadList;
			}
		}


		#endregion
	}
}
