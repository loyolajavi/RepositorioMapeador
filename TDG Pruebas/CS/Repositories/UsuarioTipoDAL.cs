using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class UsuarioTipoDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public UsuarioTipoDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the UsuarioTipo table.
		/// </summary>
		public void Insert(UsuarioTipoEntidad usuarioTipo)
		{
			ValidationUtility.ValidateArgument("usuarioTipo", usuarioTipo);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Descripcion", usuarioTipo.Descripcion)
			};

			usuarioTipo.IdUsuarioTipo = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "UsuarioTipoInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the UsuarioTipo table.
		/// </summary>
		public void Update(UsuarioTipoEntidad usuarioTipo)
		{
			ValidationUtility.ValidateArgument("usuarioTipo", usuarioTipo);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdUsuarioTipo", usuarioTipo.IdUsuarioTipo),
				new SqlParameter("@Descripcion", usuarioTipo.Descripcion)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "UsuarioTipoUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the UsuarioTipo table by its primary key.
		/// </summary>
		public void Delete(int idUsuarioTipo)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdUsuarioTipo", idUsuarioTipo)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "UsuarioTipoDelete", parameters);
		}

		/// <summary>
		/// Selects a single record from the UsuarioTipo table.
		/// </summary>
		public UsuarioTipoEntidad Select(int idUsuarioTipo)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdUsuarioTipo", idUsuarioTipo)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "UsuarioTipoSelect", parameters))
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
		/// Selects a single record from the UsuarioTipo table.
		/// </summary>
		public string SelectJson(int idUsuarioTipo)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdUsuarioTipo", idUsuarioTipo)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "UsuarioTipoSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the UsuarioTipo table.
		/// </summary>
		public List<UsuarioTipoEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "UsuarioTipoSelectAll"))
			{
				List<UsuarioTipoEntidad> usuarioTipoEntidadList = new List<UsuarioTipoEntidad>();
				while (dataReader.Read())
				{
					UsuarioTipoEntidad usuarioTipoEntidad = MapDataReader(dataReader);
					usuarioTipoEntidadList.Add(usuarioTipoEntidad);
				}

				return usuarioTipoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the UsuarioTipo table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "UsuarioTipoSelectAll");
		}

		/// <summary>
		/// Creates a new instance of the UsuarioTipoEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private UsuarioTipoEntidad MapDataReader(SqlDataReader dataReader)
		{
			UsuarioTipoEntidad usuarioTipoEntidad = new UsuarioTipoEntidad();
			usuarioTipoEntidad.IdUsuarioTipo = dataReader.GetInt32("IdUsuarioTipo", 0);
			usuarioTipoEntidad.Descripcion = dataReader.GetString("Descripcion", null);

			return usuarioTipoEntidad;
		}

		#endregion
	}
}
