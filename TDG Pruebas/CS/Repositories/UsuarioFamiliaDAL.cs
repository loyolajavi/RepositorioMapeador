using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class UsuarioFamiliaDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public UsuarioFamiliaDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the UsuarioFamilia table.
		/// </summary>
		public void Insert(UsuarioFamiliaEntidad usuarioFamilia)
		{
			ValidationUtility.ValidateArgument("usuarioFamilia", usuarioFamilia);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", usuarioFamilia.CUIT),
				new SqlParameter("@NombreUsuario", usuarioFamilia.NombreUsuario),
				new SqlParameter("@IdFamilia", usuarioFamilia.IdFamilia)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "UsuarioFamiliaInsert", parameters);
		}

		/// <summary>
		/// Deletes a record from the UsuarioFamilia table by its primary key.
		/// </summary>
		public void Delete(int cUIT, string nombreUsuario, int idFamilia)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario),
				new SqlParameter("@IdFamilia", idFamilia)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "UsuarioFamiliaDelete", parameters);
		}

		/// <summary>
		/// Deletes a record from the UsuarioFamilia table by a foreign key.
		/// </summary>
		public void DeleteAllByIdFamilia(int idFamilia)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdFamilia", idFamilia)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "UsuarioFamiliaDeleteAllByIdFamilia", parameters);
		}

		/// <summary>
		/// Deletes a record from the UsuarioFamilia table by a foreign key.
		/// </summary>
		public void DeleteAllByCUIT_NombreUsuario(int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "UsuarioFamiliaDeleteAllByCUIT_NombreUsuario", parameters);
		}

		/// <summary>
		/// Selects a single record from the UsuarioFamilia table.
		/// </summary>
		public UsuarioFamiliaEntidad Select(int cUIT, string nombreUsuario, int idFamilia)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario),
				new SqlParameter("@IdFamilia", idFamilia)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "UsuarioFamiliaSelect", parameters))
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
		/// Selects a single record from the UsuarioFamilia table.
		/// </summary>
		public string SelectJson(int cUIT, string nombreUsuario, int idFamilia)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario),
				new SqlParameter("@IdFamilia", idFamilia)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "UsuarioFamiliaSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the UsuarioFamilia table by a foreign key.
		/// </summary>
		public List<UsuarioFamiliaEntidad> SelectAllByIdFamilia(int idFamilia)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdFamilia", idFamilia)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "UsuarioFamiliaSelectAllByIdFamilia", parameters))
			{
				List<UsuarioFamiliaEntidad> usuarioFamiliaEntidadList = new List<UsuarioFamiliaEntidad>();
				while (dataReader.Read())
				{
					UsuarioFamiliaEntidad usuarioFamiliaEntidad = MapDataReader(dataReader);
					usuarioFamiliaEntidadList.Add(usuarioFamiliaEntidad);
				}

				return usuarioFamiliaEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the UsuarioFamilia table by a foreign key.
		/// </summary>
		public List<UsuarioFamiliaEntidad> SelectAllByCUIT_NombreUsuario(int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "UsuarioFamiliaSelectAllByCUIT_NombreUsuario", parameters))
			{
				List<UsuarioFamiliaEntidad> usuarioFamiliaEntidadList = new List<UsuarioFamiliaEntidad>();
				while (dataReader.Read())
				{
					UsuarioFamiliaEntidad usuarioFamiliaEntidad = MapDataReader(dataReader);
					usuarioFamiliaEntidadList.Add(usuarioFamiliaEntidad);
				}

				return usuarioFamiliaEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the UsuarioFamilia table by a foreign key.
		/// </summary>
		public string SelectAllByIdFamiliaJson(int idFamilia)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdFamilia", idFamilia)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "UsuarioFamiliaSelectAllByIdFamilia", parameters);
		}

		/// <summary>
		/// Selects all records from the UsuarioFamilia table by a foreign key.
		/// </summary>
		public string SelectAllByCUIT_NombreUsuarioJson(int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "UsuarioFamiliaSelectAllByCUIT_NombreUsuario", parameters);
		}

		/// <summary>
		/// Creates a new instance of the UsuarioFamiliaEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private UsuarioFamiliaEntidad MapDataReader(SqlDataReader dataReader)
		{
			UsuarioFamiliaEntidad usuarioFamiliaEntidad = new UsuarioFamiliaEntidad();
			usuarioFamiliaEntidad.CUIT = dataReader.GetInt32("CUIT", 0);
			usuarioFamiliaEntidad.NombreUsuario = dataReader.GetString("NombreUsuario", null);
			usuarioFamiliaEntidad.IdFamilia = dataReader.GetInt32("IdFamilia", 0);

			return usuarioFamiliaEntidad;
		}

		#endregion
	}
}
