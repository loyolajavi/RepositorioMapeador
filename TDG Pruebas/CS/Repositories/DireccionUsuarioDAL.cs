using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class DireccionUsuarioDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public DireccionUsuarioDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the DireccionUsuario table.
		/// </summary>
		public void Insert(DireccionUsuarioEntidad direccionUsuario)
		{
			ValidationUtility.ValidateArgument("direccionUsuario", direccionUsuario);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDireccion", direccionUsuario.IdDireccion),
				new SqlParameter("@CUIT", direccionUsuario.CUIT),
				new SqlParameter("@NombreUsuario", direccionUsuario.NombreUsuario)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "DireccionUsuarioInsert", parameters);
		}

		/// <summary>
		/// Deletes a record from the DireccionUsuario table by its primary key.
		/// </summary>
		public void Delete(int idDireccion, int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDireccion", idDireccion),
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "DireccionUsuarioDelete", parameters);
		}

		/// <summary>
		/// Deletes a record from the DireccionUsuario table by a foreign key.
		/// </summary>
		public void DeleteAllByIdDireccion(int idDireccion)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDireccion", idDireccion)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "DireccionUsuarioDeleteAllByIdDireccion", parameters);
		}

		/// <summary>
		/// Deletes a record from the DireccionUsuario table by a foreign key.
		/// </summary>
		public void DeleteAllByCUIT_NombreUsuario(int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "DireccionUsuarioDeleteAllByCUIT_NombreUsuario", parameters);
		}

		/// <summary>
		/// Selects a single record from the DireccionUsuario table.
		/// </summary>
		public DireccionUsuarioEntidad Select(int idDireccion, int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDireccion", idDireccion),
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "DireccionUsuarioSelect", parameters))
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
		/// Selects a single record from the DireccionUsuario table.
		/// </summary>
		public string SelectJson(int idDireccion, int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDireccion", idDireccion),
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "DireccionUsuarioSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the DireccionUsuario table by a foreign key.
		/// </summary>
		public List<DireccionUsuarioEntidad> SelectAllByIdDireccion(int idDireccion)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDireccion", idDireccion)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "DireccionUsuarioSelectAllByIdDireccion", parameters))
			{
				List<DireccionUsuarioEntidad> direccionUsuarioEntidadList = new List<DireccionUsuarioEntidad>();
				while (dataReader.Read())
				{
					DireccionUsuarioEntidad direccionUsuarioEntidad = MapDataReader(dataReader);
					direccionUsuarioEntidadList.Add(direccionUsuarioEntidad);
				}

				return direccionUsuarioEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the DireccionUsuario table by a foreign key.
		/// </summary>
		public List<DireccionUsuarioEntidad> SelectAllByCUIT_NombreUsuario(int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "DireccionUsuarioSelectAllByCUIT_NombreUsuario", parameters))
			{
				List<DireccionUsuarioEntidad> direccionUsuarioEntidadList = new List<DireccionUsuarioEntidad>();
				while (dataReader.Read())
				{
					DireccionUsuarioEntidad direccionUsuarioEntidad = MapDataReader(dataReader);
					direccionUsuarioEntidadList.Add(direccionUsuarioEntidad);
				}

				return direccionUsuarioEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the DireccionUsuario table by a foreign key.
		/// </summary>
		public string SelectAllByIdDireccionJson(int idDireccion)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDireccion", idDireccion)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "DireccionUsuarioSelectAllByIdDireccion", parameters);
		}

		/// <summary>
		/// Selects all records from the DireccionUsuario table by a foreign key.
		/// </summary>
		public string SelectAllByCUIT_NombreUsuarioJson(int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "DireccionUsuarioSelectAllByCUIT_NombreUsuario", parameters);
		}

		/// <summary>
		/// Creates a new instance of the DireccionUsuarioEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private DireccionUsuarioEntidad MapDataReader(SqlDataReader dataReader)
		{
			DireccionUsuarioEntidad direccionUsuarioEntidad = new DireccionUsuarioEntidad();
			direccionUsuarioEntidad.IdDireccion = dataReader.GetInt32("IdDireccion", 0);
			direccionUsuarioEntidad.CUIT = dataReader.GetInt32("CUIT", 0);
			direccionUsuarioEntidad.NombreUsuario = dataReader.GetString("NombreUsuario", null);

			return direccionUsuarioEntidad;
		}

		#endregion
	}
}
