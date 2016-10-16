using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class TipoTelDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public TipoTelDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the TipoTel table.
		/// </summary>
		public void Insert(TipoTelEntidad tipoTel)
		{
			ValidationUtility.ValidateArgument("tipoTel", tipoTel);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DescripcionTipoTel", tipoTel.DescripcionTipoTel)
			};

			tipoTel.IdTipoTel = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "TipoTelInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the TipoTel table.
		/// </summary>
		public void Update(TipoTelEntidad tipoTel)
		{
			ValidationUtility.ValidateArgument("tipoTel", tipoTel);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTipoTel", tipoTel.IdTipoTel),
				new SqlParameter("@DescripcionTipoTel", tipoTel.DescripcionTipoTel)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "TipoTelUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the TipoTel table by its primary key.
		/// </summary>
		public void Delete(int idTipoTel)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTipoTel", idTipoTel)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "TipoTelDelete", parameters);
		}

		/// <summary>
		/// Selects a single record from the TipoTel table.
		/// </summary>
		public TipoTelEntidad Select(int idTipoTel)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTipoTel", idTipoTel)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "TipoTelSelect", parameters))
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
		/// Selects a single record from the TipoTel table.
		/// </summary>
		public string SelectJson(int idTipoTel)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTipoTel", idTipoTel)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "TipoTelSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the TipoTel table.
		/// </summary>
		public List<TipoTelEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "TipoTelSelectAll"))
			{
				List<TipoTelEntidad> tipoTelEntidadList = new List<TipoTelEntidad>();
				while (dataReader.Read())
				{
					TipoTelEntidad tipoTelEntidad = MapDataReader(dataReader);
					tipoTelEntidadList.Add(tipoTelEntidad);
				}

				return tipoTelEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the TipoTel table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "TipoTelSelectAll");
		}

		/// <summary>
		/// Creates a new instance of the TipoTelEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private TipoTelEntidad MapDataReader(SqlDataReader dataReader)
		{
			TipoTelEntidad tipoTelEntidad = new TipoTelEntidad();
			tipoTelEntidad.IdTipoTel = dataReader.GetInt32("IdTipoTel", 0);
			tipoTelEntidad.DescripcionTipoTel = dataReader.GetString("DescripcionTipoTel", null);

			return tipoTelEntidad;
		}

		#endregion
	}
}
