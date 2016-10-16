using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class UsuarioDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public UsuarioDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Usuario table.
		/// </summary>
		public void Insert(UsuarioEntidad usuario)
		{
			ValidationUtility.ValidateArgument("usuario", usuario);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdCondicionFiscal", usuario.IdCondicionFiscal),
				new SqlParameter("@IdUsuarioTipo", usuario.IdUsuarioTipo),
				new SqlParameter("@Nombre", usuario.Nombre),
				new SqlParameter("@Apellido", usuario.Apellido),
				new SqlParameter("@Dni", usuario.Dni),
				new SqlParameter("@CUIT", usuario.CUIT),
				new SqlParameter("@Email", usuario.Email),
				new SqlParameter("@NombreUsuario", usuario.NombreUsuario),
				new SqlParameter("@Clave", usuario.Clave),
				new SqlParameter("@CUITEmpresa", usuario.CUITEmpresa)
			};

			usuario.IdUsuario = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "UsuarioInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the Usuario table.
		/// </summary>
		public void Update(UsuarioEntidad usuario)
		{
			ValidationUtility.ValidateArgument("usuario", usuario);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdUsuario", usuario.IdUsuario),
				new SqlParameter("@IdCondicionFiscal", usuario.IdCondicionFiscal),
				new SqlParameter("@IdUsuarioTipo", usuario.IdUsuarioTipo),
				new SqlParameter("@Nombre", usuario.Nombre),
				new SqlParameter("@Apellido", usuario.Apellido),
				new SqlParameter("@Dni", usuario.Dni),
				new SqlParameter("@CUIT", usuario.CUIT),
				new SqlParameter("@Email", usuario.Email),
				new SqlParameter("@NombreUsuario", usuario.NombreUsuario),
				new SqlParameter("@Clave", usuario.Clave),
				new SqlParameter("@CUITEmpresa", usuario.CUITEmpresa)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "UsuarioUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the Usuario table by its primary key.
		/// </summary>
		public void Delete(int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "UsuarioDelete", parameters);
		}

		/// <summary>
		/// Deletes a record from the Usuario table by a foreign key.
		/// </summary>
		public void DeleteAllByIdCondicionFiscal(int idCondicionFiscal)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdCondicionFiscal", idCondicionFiscal)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "UsuarioDeleteAllByIdCondicionFiscal", parameters);
		}

		/// <summary>
		/// Deletes a record from the Usuario table by a foreign key.
		/// </summary>
		public void DeleteAllByCUITEmpresa(int cUITEmpresa)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUITEmpresa", cUITEmpresa)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "UsuarioDeleteAllByCUITEmpresa", parameters);
		}

		/// <summary>
		/// Deletes a record from the Usuario table by a foreign key.
		/// </summary>
		public void DeleteAllByIdUsuarioTipo(int idUsuarioTipo)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdUsuarioTipo", idUsuarioTipo)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "UsuarioDeleteAllByIdUsuarioTipo", parameters);
		}

		/// <summary>
		/// Selects a single record from the Usuario table.
		/// </summary>
		public UsuarioEntidad Select(int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "UsuarioSelect", parameters))
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
		/// Selects a single record from the Usuario table.
		/// </summary>
		public string SelectJson(int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "UsuarioSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the Usuario table.
		/// </summary>
		public List<UsuarioEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "UsuarioSelectAll"))
			{
				List<UsuarioEntidad> usuarioEntidadList = new List<UsuarioEntidad>();
				while (dataReader.Read())
				{
					UsuarioEntidad usuarioEntidad = MapDataReader(dataReader);
					usuarioEntidadList.Add(usuarioEntidad);
				}

				return usuarioEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Usuario table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "UsuarioSelectAll");
		}

		/// <summary>
		/// Selects all records from the Usuario table by a foreign key.
		/// </summary>
		public List<UsuarioEntidad> SelectAllByIdCondicionFiscal(int idCondicionFiscal)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdCondicionFiscal", idCondicionFiscal)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "UsuarioSelectAllByIdCondicionFiscal", parameters))
			{
				List<UsuarioEntidad> usuarioEntidadList = new List<UsuarioEntidad>();
				while (dataReader.Read())
				{
					UsuarioEntidad usuarioEntidad = MapDataReader(dataReader);
					usuarioEntidadList.Add(usuarioEntidad);
				}

				return usuarioEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Usuario table by a foreign key.
		/// </summary>
		public List<UsuarioEntidad> SelectAllByCUITEmpresa(int cUITEmpresa)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUITEmpresa", cUITEmpresa)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "UsuarioSelectAllByCUITEmpresa", parameters))
			{
				List<UsuarioEntidad> usuarioEntidadList = new List<UsuarioEntidad>();
				while (dataReader.Read())
				{
					UsuarioEntidad usuarioEntidad = MapDataReader(dataReader);
					usuarioEntidadList.Add(usuarioEntidad);
				}

				return usuarioEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Usuario table by a foreign key.
		/// </summary>
		public List<UsuarioEntidad> SelectAllByIdUsuarioTipo(int idUsuarioTipo)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdUsuarioTipo", idUsuarioTipo)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "UsuarioSelectAllByIdUsuarioTipo", parameters))
			{
				List<UsuarioEntidad> usuarioEntidadList = new List<UsuarioEntidad>();
				while (dataReader.Read())
				{
					UsuarioEntidad usuarioEntidad = MapDataReader(dataReader);
					usuarioEntidadList.Add(usuarioEntidad);
				}

				return usuarioEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Usuario table by a foreign key.
		/// </summary>
		public string SelectAllByIdCondicionFiscalJson(int idCondicionFiscal)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdCondicionFiscal", idCondicionFiscal)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "UsuarioSelectAllByIdCondicionFiscal", parameters);
		}

		/// <summary>
		/// Selects all records from the Usuario table by a foreign key.
		/// </summary>
		public string SelectAllByCUITEmpresaJson(int cUITEmpresa)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUITEmpresa", cUITEmpresa)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "UsuarioSelectAllByCUITEmpresa", parameters);
		}

		/// <summary>
		/// Selects all records from the Usuario table by a foreign key.
		/// </summary>
		public string SelectAllByIdUsuarioTipoJson(int idUsuarioTipo)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdUsuarioTipo", idUsuarioTipo)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "UsuarioSelectAllByIdUsuarioTipo", parameters);
		}

		/// <summary>
		/// Creates a new instance of the UsuarioEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private UsuarioEntidad MapDataReader(SqlDataReader dataReader)
		{
			UsuarioEntidad usuarioEntidad = new UsuarioEntidad();
			usuarioEntidad.IdUsuario = dataReader.GetInt32("IdUsuario", 0);
			usuarioEntidad.IdCondicionFiscal = dataReader.GetInt32("IdCondicionFiscal", 0);
			usuarioEntidad.IdUsuarioTipo = dataReader.GetInt32("IdUsuarioTipo", 0);
			usuarioEntidad.Nombre = dataReader.GetString("Nombre", null);
			usuarioEntidad.Apellido = dataReader.GetString("Apellido", null);
			usuarioEntidad.Dni = dataReader.GetString("Dni", null);
			usuarioEntidad.CUIT = dataReader.GetInt32("CUIT", 0);
			usuarioEntidad.Email = dataReader.GetString("Email", null);
			usuarioEntidad.NombreUsuario = dataReader.GetString("NombreUsuario", null);
			usuarioEntidad.Clave = dataReader.GetString("Clave", null);
			usuarioEntidad.CUITEmpresa = dataReader.GetInt32("CUITEmpresa", 0);

			return usuarioEntidad;
		}

		#endregion
	}
}
