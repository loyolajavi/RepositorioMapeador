using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class ListaDeseosDetalleDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public ListaDeseosDetalleDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the ListaDeseosDetalle table.
		/// </summary>
		public void Insert(ListaDeseosDetalleEntidad listaDeseosDetalle)
		{
			ValidationUtility.ValidateArgument("listaDeseosDetalle", listaDeseosDetalle);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdListaDeseos", listaDeseosDetalle.IdListaDeseos),
				new SqlParameter("@IdProducto", listaDeseosDetalle.IdProducto),
				new SqlParameter("@FechaDeseoDetalle", listaDeseosDetalle.FechaDeseoDetalle)
			};

			listaDeseosDetalle.IdListaDeseosDetalle = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "ListaDeseosDetalleInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the ListaDeseosDetalle table.
		/// </summary>
		public void Update(ListaDeseosDetalleEntidad listaDeseosDetalle)
		{
			ValidationUtility.ValidateArgument("listaDeseosDetalle", listaDeseosDetalle);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdListaDeseos", listaDeseosDetalle.IdListaDeseos),
				new SqlParameter("@IdListaDeseosDetalle", listaDeseosDetalle.IdListaDeseosDetalle),
				new SqlParameter("@IdProducto", listaDeseosDetalle.IdProducto),
				new SqlParameter("@FechaDeseoDetalle", listaDeseosDetalle.FechaDeseoDetalle)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ListaDeseosDetalleUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the ListaDeseosDetalle table by its primary key.
		/// </summary>
		public void Delete(int idListaDeseos, int idListaDeseosDetalle)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdListaDeseos", idListaDeseos),
				new SqlParameter("@IdListaDeseosDetalle", idListaDeseosDetalle)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ListaDeseosDetalleDelete", parameters);
		}

		/// <summary>
		/// Deletes a record from the ListaDeseosDetalle table by a foreign key.
		/// </summary>
		public void DeleteAllByIdListaDeseos(int idListaDeseos)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdListaDeseos", idListaDeseos)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ListaDeseosDetalleDeleteAllByIdListaDeseos", parameters);
		}

		/// <summary>
		/// Deletes a record from the ListaDeseosDetalle table by a foreign key.
		/// </summary>
		public void DeleteAllByIdProducto(int idProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ListaDeseosDetalleDeleteAllByIdProducto", parameters);
		}

		/// <summary>
		/// Selects a single record from the ListaDeseosDetalle table.
		/// </summary>
		public ListaDeseosDetalleEntidad Select(int idListaDeseos, int idListaDeseosDetalle)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdListaDeseos", idListaDeseos),
				new SqlParameter("@IdListaDeseosDetalle", idListaDeseosDetalle)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ListaDeseosDetalleSelect", parameters))
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
		/// Selects a single record from the ListaDeseosDetalle table.
		/// </summary>
		public string SelectJson(int idListaDeseos, int idListaDeseosDetalle)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdListaDeseos", idListaDeseos),
				new SqlParameter("@IdListaDeseosDetalle", idListaDeseosDetalle)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ListaDeseosDetalleSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the ListaDeseosDetalle table.
		/// </summary>
		public List<ListaDeseosDetalleEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ListaDeseosDetalleSelectAll"))
			{
				List<ListaDeseosDetalleEntidad> listaDeseosDetalleEntidadList = new List<ListaDeseosDetalleEntidad>();
				while (dataReader.Read())
				{
					ListaDeseosDetalleEntidad listaDeseosDetalleEntidad = MapDataReader(dataReader);
					listaDeseosDetalleEntidadList.Add(listaDeseosDetalleEntidad);
				}

				return listaDeseosDetalleEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the ListaDeseosDetalle table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ListaDeseosDetalleSelectAll");
		}

		/// <summary>
		/// Selects all records from the ListaDeseosDetalle table by a foreign key.
		/// </summary>
		public List<ListaDeseosDetalleEntidad> SelectAllByIdListaDeseos(int idListaDeseos)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdListaDeseos", idListaDeseos)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ListaDeseosDetalleSelectAllByIdListaDeseos", parameters))
			{
				List<ListaDeseosDetalleEntidad> listaDeseosDetalleEntidadList = new List<ListaDeseosDetalleEntidad>();
				while (dataReader.Read())
				{
					ListaDeseosDetalleEntidad listaDeseosDetalleEntidad = MapDataReader(dataReader);
					listaDeseosDetalleEntidadList.Add(listaDeseosDetalleEntidad);
				}

				return listaDeseosDetalleEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the ListaDeseosDetalle table by a foreign key.
		/// </summary>
		public List<ListaDeseosDetalleEntidad> SelectAllByIdProducto(int idProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ListaDeseosDetalleSelectAllByIdProducto", parameters))
			{
				List<ListaDeseosDetalleEntidad> listaDeseosDetalleEntidadList = new List<ListaDeseosDetalleEntidad>();
				while (dataReader.Read())
				{
					ListaDeseosDetalleEntidad listaDeseosDetalleEntidad = MapDataReader(dataReader);
					listaDeseosDetalleEntidadList.Add(listaDeseosDetalleEntidad);
				}

				return listaDeseosDetalleEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the ListaDeseosDetalle table by a foreign key.
		/// </summary>
		public string SelectAllByIdListaDeseosJson(int idListaDeseos)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdListaDeseos", idListaDeseos)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ListaDeseosDetalleSelectAllByIdListaDeseos", parameters);
		}

		/// <summary>
		/// Selects all records from the ListaDeseosDetalle table by a foreign key.
		/// </summary>
		public string SelectAllByIdProductoJson(int idProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ListaDeseosDetalleSelectAllByIdProducto", parameters);
		}

		/// <summary>
		/// Creates a new instance of the ListaDeseosDetalleEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private ListaDeseosDetalleEntidad MapDataReader(SqlDataReader dataReader)
		{
			ListaDeseosDetalleEntidad listaDeseosDetalleEntidad = new ListaDeseosDetalleEntidad();
			listaDeseosDetalleEntidad.IdListaDeseos = dataReader.GetInt32("IdListaDeseos", 0);
			listaDeseosDetalleEntidad.IdListaDeseosDetalle = dataReader.GetInt32("IdListaDeseosDetalle", 0);
			listaDeseosDetalleEntidad.IdProducto = dataReader.GetInt32("IdProducto", 0);
			listaDeseosDetalleEntidad.FechaDeseoDetalle = dataReader.GetDateTime("FechaDeseoDetalle", new DateTime(0));

			return listaDeseosDetalleEntidad;
		}

		#endregion
	}
}
