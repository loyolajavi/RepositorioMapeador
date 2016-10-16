using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class ListaDeseoDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public ListaDeseoDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the ListaDeseos table.
		/// </summary>
		public void Insert(ListaDeseoEntidad listaDeseo)
		{
			ValidationUtility.ValidateArgument("listaDeseo", listaDeseo);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", listaDeseo.CUIT),
				new SqlParameter("@NombreUsuario", listaDeseo.NombreUsuario)
			};

			listaDeseo.IdListaDeseos = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "ListaDeseosInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the ListaDeseos table.
		/// </summary>
		public void Update(ListaDeseoEntidad listaDeseo)
		{
			ValidationUtility.ValidateArgument("listaDeseo", listaDeseo);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdListaDeseos", listaDeseo.IdListaDeseos),
				new SqlParameter("@CUIT", listaDeseo.CUIT),
				new SqlParameter("@NombreUsuario", listaDeseo.NombreUsuario)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ListaDeseosUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the ListaDeseos table by its primary key.
		/// </summary>
		public void Delete(int idListaDeseos)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdListaDeseos", idListaDeseos)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ListaDeseosDelete", parameters);
		}

		/// <summary>
		/// Deletes a record from the ListaDeseos table by a foreign key.
		/// </summary>
		public void DeleteAllByCUIT_NombreUsuario(int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ListaDeseosDeleteAllByCUIT_NombreUsuario", parameters);
		}

		/// <summary>
		/// Selects a single record from the ListaDeseos table.
		/// </summary>
		public ListaDeseoEntidad Select(int idListaDeseos)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdListaDeseos", idListaDeseos)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ListaDeseosSelect", parameters))
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
		/// Selects a single record from the ListaDeseos table.
		/// </summary>
		public string SelectJson(int idListaDeseos)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdListaDeseos", idListaDeseos)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ListaDeseosSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the ListaDeseos table.
		/// </summary>
		public List<ListaDeseoEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ListaDeseosSelectAll"))
			{
				List<ListaDeseoEntidad> listaDeseoEntidadList = new List<ListaDeseoEntidad>();
				while (dataReader.Read())
				{
					ListaDeseoEntidad listaDeseoEntidad = MapDataReader(dataReader);
					listaDeseoEntidadList.Add(listaDeseoEntidad);
				}

				return listaDeseoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the ListaDeseos table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ListaDeseosSelectAll");
		}

		/// <summary>
		/// Selects all records from the ListaDeseos table by a foreign key.
		/// </summary>
		public List<ListaDeseoEntidad> SelectAllByCUIT_NombreUsuario(int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ListaDeseosSelectAllByCUIT_NombreUsuario", parameters))
			{
				List<ListaDeseoEntidad> listaDeseoEntidadList = new List<ListaDeseoEntidad>();
				while (dataReader.Read())
				{
					ListaDeseoEntidad listaDeseoEntidad = MapDataReader(dataReader);
					listaDeseoEntidadList.Add(listaDeseoEntidad);
				}

				return listaDeseoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the ListaDeseos table by a foreign key.
		/// </summary>
		public string SelectAllByCUIT_NombreUsuarioJson(int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ListaDeseosSelectAllByCUIT_NombreUsuario", parameters);
		}

		/// <summary>
		/// Creates a new instance of the ListaDeseoEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private ListaDeseoEntidad MapDataReader(SqlDataReader dataReader)
		{
			ListaDeseoEntidad listaDeseoEntidad = new ListaDeseoEntidad();
			listaDeseoEntidad.IdListaDeseos = dataReader.GetInt32("IdListaDeseos", 0);
			listaDeseoEntidad.CUIT = dataReader.GetInt32("CUIT", 0);
			listaDeseoEntidad.NombreUsuario = dataReader.GetString("NombreUsuario", null);

			return listaDeseoEntidad;
		}

		#endregion
	}
}
