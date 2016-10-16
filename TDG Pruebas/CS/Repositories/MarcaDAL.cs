using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class MarcaDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public MarcaDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Marca table.
		/// </summary>
		public void Insert(MarcaEntidad marca)
		{
			ValidationUtility.ValidateArgument("marca", marca);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DescripcionMarca", marca.DescripcionMarca)
			};

			marca.IdMarca = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "MarcaInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the Marca table.
		/// </summary>
		public void Update(MarcaEntidad marca)
		{
			ValidationUtility.ValidateArgument("marca", marca);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdMarca", marca.IdMarca),
				new SqlParameter("@DescripcionMarca", marca.DescripcionMarca)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "MarcaUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the Marca table by its primary key.
		/// </summary>
		public void Delete(int idMarca)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdMarca", idMarca)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "MarcaDelete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Marca table.
		/// </summary>
		public MarcaEntidad Select(int idMarca)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdMarca", idMarca)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "MarcaSelect", parameters))
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
		/// Selects a single record from the Marca table.
		/// </summary>
		public string SelectJson(int idMarca)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdMarca", idMarca)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "MarcaSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the Marca table.
		/// </summary>
		public List<MarcaEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "MarcaSelectAll"))
			{
				List<MarcaEntidad> marcaEntidadList = new List<MarcaEntidad>();
				while (dataReader.Read())
				{
					MarcaEntidad marcaEntidad = MapDataReader(dataReader);
					marcaEntidadList.Add(marcaEntidad);
				}

				return marcaEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Marca table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "MarcaSelectAll");
		}

		/// <summary>
		/// Creates a new instance of the MarcaEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private MarcaEntidad MapDataReader(SqlDataReader dataReader)
		{
			MarcaEntidad marcaEntidad = new MarcaEntidad();
			marcaEntidad.IdMarca = dataReader.GetInt32("IdMarca", 0);
			marcaEntidad.DescripcionMarca = dataReader.GetString("DescripcionMarca", null);

			return marcaEntidad;
		}

		#endregion
	}
}
