using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class MonedaEmpresaDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public MonedaEmpresaDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the MonedaEmpresa table.
		/// </summary>
		public void Insert(MonedaEmpresaEntidad monedaEmpresa)
		{
			ValidationUtility.ValidateArgument("monedaEmpresa", monedaEmpresa);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdMoneda", monedaEmpresa.IdMoneda),
				new SqlParameter("@CUITEmpresa", monedaEmpresa.CUITEmpresa)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "MonedaEmpresaInsert", parameters);
		}

		/// <summary>
		/// Deletes a record from the MonedaEmpresa table by its primary key.
		/// </summary>
		public void Delete(int idMoneda, int cUITEmpresa)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdMoneda", idMoneda),
				new SqlParameter("@CUITEmpresa", cUITEmpresa)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "MonedaEmpresaDelete", parameters);
		}

		/// <summary>
		/// Deletes a record from the MonedaEmpresa table by a foreign key.
		/// </summary>
		public void DeleteAllByCUITEmpresa(int cUITEmpresa)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUITEmpresa", cUITEmpresa)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "MonedaEmpresaDeleteAllByCUITEmpresa", parameters);
		}

		/// <summary>
		/// Deletes a record from the MonedaEmpresa table by a foreign key.
		/// </summary>
		public void DeleteAllByIdMoneda(int idMoneda)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdMoneda", idMoneda)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "MonedaEmpresaDeleteAllByIdMoneda", parameters);
		}

		/// <summary>
		/// Selects all records from the MonedaEmpresa table by a foreign key.
		/// </summary>
		public List<MonedaEmpresaEntidad> SelectAllByCUITEmpresa(int cUITEmpresa)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUITEmpresa", cUITEmpresa)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "MonedaEmpresaSelectAllByCUITEmpresa", parameters))
			{
				List<MonedaEmpresaEntidad> monedaEmpresaEntidadList = new List<MonedaEmpresaEntidad>();
				while (dataReader.Read())
				{
					MonedaEmpresaEntidad monedaEmpresaEntidad = MapDataReader(dataReader);
					monedaEmpresaEntidadList.Add(monedaEmpresaEntidad);
				}

				return monedaEmpresaEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the MonedaEmpresa table by a foreign key.
		/// </summary>
		public List<MonedaEmpresaEntidad> SelectAllByIdMoneda(int idMoneda)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdMoneda", idMoneda)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "MonedaEmpresaSelectAllByIdMoneda", parameters))
			{
				List<MonedaEmpresaEntidad> monedaEmpresaEntidadList = new List<MonedaEmpresaEntidad>();
				while (dataReader.Read())
				{
					MonedaEmpresaEntidad monedaEmpresaEntidad = MapDataReader(dataReader);
					monedaEmpresaEntidadList.Add(monedaEmpresaEntidad);
				}

				return monedaEmpresaEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the MonedaEmpresa table by a foreign key.
		/// </summary>
		public string SelectAllByCUITEmpresaJson(int cUITEmpresa)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUITEmpresa", cUITEmpresa)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "MonedaEmpresaSelectAllByCUITEmpresa", parameters);
		}

		/// <summary>
		/// Selects all records from the MonedaEmpresa table by a foreign key.
		/// </summary>
		public string SelectAllByIdMonedaJson(int idMoneda)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdMoneda", idMoneda)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "MonedaEmpresaSelectAllByIdMoneda", parameters);
		}

		/// <summary>
		/// Creates a new instance of the MonedaEmpresaEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private MonedaEmpresaEntidad MapDataReader(SqlDataReader dataReader)
		{
			MonedaEmpresaEntidad monedaEmpresaEntidad = new MonedaEmpresaEntidad();
			monedaEmpresaEntidad.IdMoneda = dataReader.GetInt32("IdMoneda", 0);
			monedaEmpresaEntidad.CUITEmpresa = dataReader.GetInt32("CUITEmpresa", 0);

			return monedaEmpresaEntidad;
		}

		#endregion
	}
}
