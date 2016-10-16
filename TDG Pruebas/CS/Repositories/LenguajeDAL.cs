using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class LenguajeDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public LenguajeDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Lenguaje table.
		/// </summary>
		public void Insert(LenguajeEntidad lenguaje)
		{
			ValidationUtility.ValidateArgument("lenguaje", lenguaje);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DescripcionLenguaje", lenguaje.DescripcionLenguaje)
			};

			lenguaje.IdLenguaje = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "LenguajeInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the Lenguaje table.
		/// </summary>
		public void Update(LenguajeEntidad lenguaje)
		{
			ValidationUtility.ValidateArgument("lenguaje", lenguaje);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdLenguaje", lenguaje.IdLenguaje),
				new SqlParameter("@DescripcionLenguaje", lenguaje.DescripcionLenguaje)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "LenguajeUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the Lenguaje table by its primary key.
		/// </summary>
		public void Delete(int idLenguaje)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdLenguaje", idLenguaje)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "LenguajeDelete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Lenguaje table.
		/// </summary>
		public LenguajeEntidad Select(int idLenguaje)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdLenguaje", idLenguaje)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "LenguajeSelect", parameters))
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
		/// Selects a single record from the Lenguaje table.
		/// </summary>
		public string SelectJson(int idLenguaje)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdLenguaje", idLenguaje)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "LenguajeSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the Lenguaje table.
		/// </summary>
		public List<LenguajeEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "LenguajeSelectAll"))
			{
				List<LenguajeEntidad> lenguajeEntidadList = new List<LenguajeEntidad>();
				while (dataReader.Read())
				{
					LenguajeEntidad lenguajeEntidad = MapDataReader(dataReader);
					lenguajeEntidadList.Add(lenguajeEntidad);
				}

				return lenguajeEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Lenguaje table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "LenguajeSelectAll");
		}

		/// <summary>
		/// Creates a new instance of the LenguajeEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private LenguajeEntidad MapDataReader(SqlDataReader dataReader)
		{
			LenguajeEntidad lenguajeEntidad = new LenguajeEntidad();
			lenguajeEntidad.IdLenguaje = dataReader.GetInt32("IdLenguaje", 0);
			lenguajeEntidad.DescripcionLenguaje = dataReader.GetString("DescripcionLenguaje", null);

			return lenguajeEntidad;
		}

		#endregion
	}
}
