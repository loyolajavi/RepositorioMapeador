using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class MonedaDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public MonedaDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Moneda table.
		/// </summary>
		public void Insert(MonedaEntidad moneda)
		{
			ValidationUtility.ValidateArgument("moneda", moneda);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdMoneda", moneda.IdMoneda),
				new SqlParameter("@Nombre", moneda.Nombre),
				new SqlParameter("@Cotizacion", moneda.Cotizacion)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "MonedaInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the Moneda table.
		/// </summary>
		public void Update(MonedaEntidad moneda)
		{
			ValidationUtility.ValidateArgument("moneda", moneda);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdMoneda", moneda.IdMoneda),
				new SqlParameter("@Nombre", moneda.Nombre),
				new SqlParameter("@Cotizacion", moneda.Cotizacion)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "MonedaUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the Moneda table by its primary key.
		/// </summary>
		public void Delete(int idMoneda)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdMoneda", idMoneda)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "MonedaDelete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Moneda table.
		/// </summary>
		public MonedaEntidad Select(int idMoneda)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdMoneda", idMoneda)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "MonedaSelect", parameters))
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
		/// Selects a single record from the Moneda table.
		/// </summary>
		public string SelectJson(int idMoneda)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdMoneda", idMoneda)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "MonedaSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the Moneda table.
		/// </summary>
		public List<MonedaEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "MonedaSelectAll"))
			{
				List<MonedaEntidad> monedaEntidadList = new List<MonedaEntidad>();
				while (dataReader.Read())
				{
					MonedaEntidad monedaEntidad = MapDataReader(dataReader);
					monedaEntidadList.Add(monedaEntidad);
				}

				return monedaEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Moneda table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "MonedaSelectAll");
		}

		/// <summary>
		/// Creates a new instance of the MonedaEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private MonedaEntidad MapDataReader(SqlDataReader dataReader)
		{
			MonedaEntidad monedaEntidad = new MonedaEntidad();
			monedaEntidad.IdMoneda = dataReader.GetInt32("IdMoneda", 0);
			monedaEntidad.Nombre = dataReader.GetString("Nombre", null);
			monedaEntidad.Cotizacion = dataReader.GetDecimal("Cotizacion", Decimal.Zero);

			return monedaEntidad;
		}

		#endregion
	}
}
