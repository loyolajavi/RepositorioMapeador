using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class DireccionDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public DireccionDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Direccion table.
		/// </summary>
		public void Insert(DireccionEntidad direccion)
		{
			ValidationUtility.ValidateArgument("direccion", direccion);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Calle", direccion.Calle),
				new SqlParameter("@Numero", direccion.Numero),
				new SqlParameter("@Piso", direccion.Piso),
				new SqlParameter("@Departamento", direccion.Departamento),
				new SqlParameter("@Localidad", direccion.Localidad),
				new SqlParameter("@IdProvincia", direccion.IdProvincia),
				new SqlParameter("@IdTipoDireccion", direccion.IdTipoDireccion)
			};

			direccion.IdDireccion = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "DireccionInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the Direccion table.
		/// </summary>
		public void Update(DireccionEntidad direccion)
		{
			ValidationUtility.ValidateArgument("direccion", direccion);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDireccion", direccion.IdDireccion),
				new SqlParameter("@Calle", direccion.Calle),
				new SqlParameter("@Numero", direccion.Numero),
				new SqlParameter("@Piso", direccion.Piso),
				new SqlParameter("@Departamento", direccion.Departamento),
				new SqlParameter("@Localidad", direccion.Localidad),
				new SqlParameter("@IdProvincia", direccion.IdProvincia),
				new SqlParameter("@IdTipoDireccion", direccion.IdTipoDireccion)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "DireccionUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the Direccion table by its primary key.
		/// </summary>
		public void Delete(int idDireccion)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDireccion", idDireccion)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "DireccionDelete", parameters);
		}

		/// <summary>
		/// Deletes a record from the Direccion table by a foreign key.
		/// </summary>
		public void DeleteAllByIdProvincia(int idProvincia)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProvincia", idProvincia)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "DireccionDeleteAllByIdProvincia", parameters);
		}

		/// <summary>
		/// Deletes a record from the Direccion table by a foreign key.
		/// </summary>
		public void DeleteAllByIdTipoDireccion(int idTipoDireccion)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTipoDireccion", idTipoDireccion)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "DireccionDeleteAllByIdTipoDireccion", parameters);
		}

		/// <summary>
		/// Selects a single record from the Direccion table.
		/// </summary>
		public DireccionEntidad Select(int idDireccion)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDireccion", idDireccion)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "DireccionSelect", parameters))
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
		/// Selects a single record from the Direccion table.
		/// </summary>
		public string SelectJson(int idDireccion)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDireccion", idDireccion)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "DireccionSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the Direccion table.
		/// </summary>
		public List<DireccionEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "DireccionSelectAll"))
			{
				List<DireccionEntidad> direccionEntidadList = new List<DireccionEntidad>();
				while (dataReader.Read())
				{
					DireccionEntidad direccionEntidad = MapDataReader(dataReader);
					direccionEntidadList.Add(direccionEntidad);
				}

				return direccionEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Direccion table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "DireccionSelectAll");
		}

		/// <summary>
		/// Selects all records from the Direccion table by a foreign key.
		/// </summary>
		public List<DireccionEntidad> SelectAllByIdProvincia(int idProvincia)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProvincia", idProvincia)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "DireccionSelectAllByIdProvincia", parameters))
			{
				List<DireccionEntidad> direccionEntidadList = new List<DireccionEntidad>();
				while (dataReader.Read())
				{
					DireccionEntidad direccionEntidad = MapDataReader(dataReader);
					direccionEntidadList.Add(direccionEntidad);
				}

				return direccionEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Direccion table by a foreign key.
		/// </summary>
		public List<DireccionEntidad> SelectAllByIdTipoDireccion(int idTipoDireccion)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTipoDireccion", idTipoDireccion)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "DireccionSelectAllByIdTipoDireccion", parameters))
			{
				List<DireccionEntidad> direccionEntidadList = new List<DireccionEntidad>();
				while (dataReader.Read())
				{
					DireccionEntidad direccionEntidad = MapDataReader(dataReader);
					direccionEntidadList.Add(direccionEntidad);
				}

				return direccionEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Direccion table by a foreign key.
		/// </summary>
		public string SelectAllByIdProvinciaJson(int idProvincia)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProvincia", idProvincia)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "DireccionSelectAllByIdProvincia", parameters);
		}

		/// <summary>
		/// Selects all records from the Direccion table by a foreign key.
		/// </summary>
		public string SelectAllByIdTipoDireccionJson(int idTipoDireccion)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTipoDireccion", idTipoDireccion)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "DireccionSelectAllByIdTipoDireccion", parameters);
		}

		/// <summary>
		/// Creates a new instance of the DireccionEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private DireccionEntidad MapDataReader(SqlDataReader dataReader)
		{
			DireccionEntidad direccionEntidad = new DireccionEntidad();
			direccionEntidad.IdDireccion = dataReader.GetInt32("IdDireccion", 0);
			direccionEntidad.Calle = dataReader.GetString("Calle", null);
			direccionEntidad.Numero = dataReader.GetInt32("Numero", 0);
			direccionEntidad.Piso = dataReader.GetInt32("Piso", 0);
			direccionEntidad.Departamento = dataReader.GetString("Departamento", null);
			direccionEntidad.Localidad = dataReader.GetString("Localidad", null);
			direccionEntidad.IdProvincia = dataReader.GetInt32("IdProvincia", 0);
			direccionEntidad.IdTipoDireccion = dataReader.GetInt32("IdTipoDireccion", 0);

			return direccionEntidad;
		}

		#endregion
	}
}
