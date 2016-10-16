using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class TelefonoDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public TelefonoDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Telefono table.
		/// </summary>
		public void Insert(TelefonoEntidad telefono)
		{
			ValidationUtility.ValidateArgument("telefono", telefono);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", telefono.CUIT),
				new SqlParameter("@NombreUsuario", telefono.NombreUsuario),
				new SqlParameter("@NroTelefono", telefono.NroTelefono),
				new SqlParameter("@CodArea", telefono.CodArea),
				new SqlParameter("@IdTipoTel", telefono.IdTipoTel)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "TelefonoInsert", parameters);
		}

		/// <summary>
		/// Deletes a record from the Telefono table by its primary key.
		/// </summary>
		public void Delete(int cUIT, string nombreUsuario, string nroTelefono, string codArea, int idTipoTel)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario),
				new SqlParameter("@NroTelefono", nroTelefono),
				new SqlParameter("@CodArea", codArea),
				new SqlParameter("@IdTipoTel", idTipoTel)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "TelefonoDelete", parameters);
		}

		/// <summary>
		/// Deletes a record from the Telefono table by a foreign key.
		/// </summary>
		public void DeleteAllByIdTipoTel(int idTipoTel)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTipoTel", idTipoTel)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "TelefonoDeleteAllByIdTipoTel", parameters);
		}

		/// <summary>
		/// Deletes a record from the Telefono table by a foreign key.
		/// </summary>
		public void DeleteAllByCUIT_NombreUsuario(int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "TelefonoDeleteAllByCUIT_NombreUsuario", parameters);
		}

		/// <summary>
		/// Selects a single record from the Telefono table.
		/// </summary>
		public TelefonoEntidad Select(int cUIT, string nombreUsuario, string nroTelefono, string codArea, int idTipoTel)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario),
				new SqlParameter("@NroTelefono", nroTelefono),
				new SqlParameter("@CodArea", codArea),
				new SqlParameter("@IdTipoTel", idTipoTel)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "TelefonoSelect", parameters))
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
		/// Selects a single record from the Telefono table.
		/// </summary>
		public string SelectJson(int cUIT, string nombreUsuario, string nroTelefono, string codArea, int idTipoTel)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario),
				new SqlParameter("@NroTelefono", nroTelefono),
				new SqlParameter("@CodArea", codArea),
				new SqlParameter("@IdTipoTel", idTipoTel)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "TelefonoSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the Telefono table by a foreign key.
		/// </summary>
		public List<TelefonoEntidad> SelectAllByIdTipoTel(int idTipoTel)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTipoTel", idTipoTel)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "TelefonoSelectAllByIdTipoTel", parameters))
			{
				List<TelefonoEntidad> telefonoEntidadList = new List<TelefonoEntidad>();
				while (dataReader.Read())
				{
					TelefonoEntidad telefonoEntidad = MapDataReader(dataReader);
					telefonoEntidadList.Add(telefonoEntidad);
				}

				return telefonoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Telefono table by a foreign key.
		/// </summary>
		public List<TelefonoEntidad> SelectAllByCUIT_NombreUsuario(int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "TelefonoSelectAllByCUIT_NombreUsuario", parameters))
			{
				List<TelefonoEntidad> telefonoEntidadList = new List<TelefonoEntidad>();
				while (dataReader.Read())
				{
					TelefonoEntidad telefonoEntidad = MapDataReader(dataReader);
					telefonoEntidadList.Add(telefonoEntidad);
				}

				return telefonoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Telefono table by a foreign key.
		/// </summary>
		public string SelectAllByIdTipoTelJson(int idTipoTel)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTipoTel", idTipoTel)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "TelefonoSelectAllByIdTipoTel", parameters);
		}

		/// <summary>
		/// Selects all records from the Telefono table by a foreign key.
		/// </summary>
		public string SelectAllByCUIT_NombreUsuarioJson(int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "TelefonoSelectAllByCUIT_NombreUsuario", parameters);
		}

		/// <summary>
		/// Creates a new instance of the TelefonoEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private TelefonoEntidad MapDataReader(SqlDataReader dataReader)
		{
			TelefonoEntidad telefonoEntidad = new TelefonoEntidad();
			telefonoEntidad.CUIT = dataReader.GetInt32("CUIT", 0);
			telefonoEntidad.NombreUsuario = dataReader.GetString("NombreUsuario", null);
			telefonoEntidad.NroTelefono = dataReader.GetString("NroTelefono", null);
			telefonoEntidad.CodArea = dataReader.GetString("CodArea", null);
			telefonoEntidad.IdTipoTel = dataReader.GetInt32("IdTipoTel", 0);

			return telefonoEntidad;
		}

		#endregion
	}
}
