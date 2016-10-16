using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class LenguajeControlDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public LenguajeControlDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the LenguajeControl table.
		/// </summary>
		public void Insert(LenguajeControlEntidad lenguajeControl)
		{
			ValidationUtility.ValidateArgument("lenguajeControl", lenguajeControl);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Texto", lenguajeControl.Texto),
				new SqlParameter("@IdLenguaje", lenguajeControl.IdLenguaje),
				new SqlParameter("@Valor", lenguajeControl.Valor)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "LenguajeControlInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the LenguajeControl table.
		/// </summary>
		public void Update(LenguajeControlEntidad lenguajeControl)
		{
			ValidationUtility.ValidateArgument("lenguajeControl", lenguajeControl);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Texto", lenguajeControl.Texto),
				new SqlParameter("@IdLenguaje", lenguajeControl.IdLenguaje),
				new SqlParameter("@Valor", lenguajeControl.Valor)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "LenguajeControlUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the LenguajeControl table by its primary key.
		/// </summary>
		public void Delete(string texto, int idLenguaje)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Texto", texto),
				new SqlParameter("@IdLenguaje", idLenguaje)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "LenguajeControlDelete", parameters);
		}

		/// <summary>
		/// Deletes a record from the LenguajeControl table by a foreign key.
		/// </summary>
		public void DeleteAllByIdLenguaje(int idLenguaje)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdLenguaje", idLenguaje)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "LenguajeControlDeleteAllByIdLenguaje", parameters);
		}

		/// <summary>
		/// Selects a single record from the LenguajeControl table.
		/// </summary>
		public LenguajeControlEntidad Select(string texto, int idLenguaje)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Texto", texto),
				new SqlParameter("@IdLenguaje", idLenguaje)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "LenguajeControlSelect", parameters))
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
		/// Selects a single record from the LenguajeControl table.
		/// </summary>
		public string SelectJson(string texto, int idLenguaje)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Texto", texto),
				new SqlParameter("@IdLenguaje", idLenguaje)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "LenguajeControlSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the LenguajeControl table.
		/// </summary>
		public List<LenguajeControlEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "LenguajeControlSelectAll"))
			{
				List<LenguajeControlEntidad> lenguajeControlEntidadList = new List<LenguajeControlEntidad>();
				while (dataReader.Read())
				{
					LenguajeControlEntidad lenguajeControlEntidad = MapDataReader(dataReader);
					lenguajeControlEntidadList.Add(lenguajeControlEntidad);
				}

				return lenguajeControlEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the LenguajeControl table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "LenguajeControlSelectAll");
		}

		/// <summary>
		/// Selects all records from the LenguajeControl table by a foreign key.
		/// </summary>
		public List<LenguajeControlEntidad> SelectAllByIdLenguaje(int idLenguaje)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdLenguaje", idLenguaje)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "LenguajeControlSelectAllByIdLenguaje", parameters))
			{
				List<LenguajeControlEntidad> lenguajeControlEntidadList = new List<LenguajeControlEntidad>();
				while (dataReader.Read())
				{
					LenguajeControlEntidad lenguajeControlEntidad = MapDataReader(dataReader);
					lenguajeControlEntidadList.Add(lenguajeControlEntidad);
				}

				return lenguajeControlEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the LenguajeControl table by a foreign key.
		/// </summary>
		public string SelectAllByIdLenguajeJson(int idLenguaje)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdLenguaje", idLenguaje)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "LenguajeControlSelectAllByIdLenguaje", parameters);
		}

		/// <summary>
		/// Creates a new instance of the LenguajeControlEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private LenguajeControlEntidad MapDataReader(SqlDataReader dataReader)
		{
			LenguajeControlEntidad lenguajeControlEntidad = new LenguajeControlEntidad();
			lenguajeControlEntidad.Texto = dataReader.GetString("Texto", null);
			lenguajeControlEntidad.IdLenguaje = dataReader.GetInt32("IdLenguaje", 0);
			lenguajeControlEntidad.Valor = dataReader.GetString("Valor", null);

			return lenguajeControlEntidad;
		}

		#endregion
	}
}
