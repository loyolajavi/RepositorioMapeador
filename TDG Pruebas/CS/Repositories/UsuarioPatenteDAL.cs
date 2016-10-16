using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class UsuarioPatenteDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public UsuarioPatenteDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the UsuarioPatente table.
		/// </summary>
		public void Insert(UsuarioPatenteEntidad usuarioPatente)
		{
			ValidationUtility.ValidateArgument("usuarioPatente", usuarioPatente);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", usuarioPatente.CUIT),
				new SqlParameter("@NombreUsuario", usuarioPatente.NombreUsuario),
				new SqlParameter("@IdPatente", usuarioPatente.IdPatente)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "UsuarioPatenteInsert", parameters);
		}

		/// <summary>
		/// Deletes a record from the UsuarioPatente table by its primary key.
		/// </summary>
		public void Delete(int cUIT, string nombreUsuario, int idPatente)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario),
				new SqlParameter("@IdPatente", idPatente)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "UsuarioPatenteDelete", parameters);
		}

		/// <summary>
		/// Deletes a record from the UsuarioPatente table by a foreign key.
		/// </summary>
		public void DeleteAllByIdPatente(int idPatente)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPatente", idPatente)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "UsuarioPatenteDeleteAllByIdPatente", parameters);
		}

		/// <summary>
		/// Deletes a record from the UsuarioPatente table by a foreign key.
		/// </summary>
		public void DeleteAllByCUIT_NombreUsuario(int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "UsuarioPatenteDeleteAllByCUIT_NombreUsuario", parameters);
		}

		/// <summary>
		/// Selects a single record from the UsuarioPatente table.
		/// </summary>
		public UsuarioPatenteEntidad Select(int cUIT, string nombreUsuario, int idPatente)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario),
				new SqlParameter("@IdPatente", idPatente)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "UsuarioPatenteSelect", parameters))
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
		/// Selects a single record from the UsuarioPatente table.
		/// </summary>
		public string SelectJson(int cUIT, string nombreUsuario, int idPatente)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario),
				new SqlParameter("@IdPatente", idPatente)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "UsuarioPatenteSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the UsuarioPatente table by a foreign key.
		/// </summary>
		public List<UsuarioPatenteEntidad> SelectAllByIdPatente(int idPatente)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPatente", idPatente)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "UsuarioPatenteSelectAllByIdPatente", parameters))
			{
				List<UsuarioPatenteEntidad> usuarioPatenteEntidadList = new List<UsuarioPatenteEntidad>();
				while (dataReader.Read())
				{
					UsuarioPatenteEntidad usuarioPatenteEntidad = MapDataReader(dataReader);
					usuarioPatenteEntidadList.Add(usuarioPatenteEntidad);
				}

				return usuarioPatenteEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the UsuarioPatente table by a foreign key.
		/// </summary>
		public List<UsuarioPatenteEntidad> SelectAllByCUIT_NombreUsuario(int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "UsuarioPatenteSelectAllByCUIT_NombreUsuario", parameters))
			{
				List<UsuarioPatenteEntidad> usuarioPatenteEntidadList = new List<UsuarioPatenteEntidad>();
				while (dataReader.Read())
				{
					UsuarioPatenteEntidad usuarioPatenteEntidad = MapDataReader(dataReader);
					usuarioPatenteEntidadList.Add(usuarioPatenteEntidad);
				}

				return usuarioPatenteEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the UsuarioPatente table by a foreign key.
		/// </summary>
		public string SelectAllByIdPatenteJson(int idPatente)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPatente", idPatente)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "UsuarioPatenteSelectAllByIdPatente", parameters);
		}

		/// <summary>
		/// Selects all records from the UsuarioPatente table by a foreign key.
		/// </summary>
		public string SelectAllByCUIT_NombreUsuarioJson(int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "UsuarioPatenteSelectAllByCUIT_NombreUsuario", parameters);
		}

		/// <summary>
		/// Creates a new instance of the UsuarioPatenteEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private UsuarioPatenteEntidad MapDataReader(SqlDataReader dataReader)
		{
			UsuarioPatenteEntidad usuarioPatenteEntidad = new UsuarioPatenteEntidad();
			usuarioPatenteEntidad.CUIT = dataReader.GetInt32("CUIT", 0);
			usuarioPatenteEntidad.NombreUsuario = dataReader.GetString("NombreUsuario", null);
			usuarioPatenteEntidad.IdPatente = dataReader.GetInt32("IdPatente", 0);

			return usuarioPatenteEntidad;
		}

		#endregion
	}
}
