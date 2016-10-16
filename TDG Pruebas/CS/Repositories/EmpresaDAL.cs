using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class EmpresaDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public EmpresaDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Empresa table.
		/// </summary>
		public void Insert(EmpresaEntidad empresa)
		{
			ValidationUtility.ValidateArgument("empresa", empresa);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", empresa.CUIT),
				new SqlParameter("@NombreEmpresa", empresa.NombreEmpresa)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "EmpresaInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the Empresa table.
		/// </summary>
		public void Update(EmpresaEntidad empresa)
		{
			ValidationUtility.ValidateArgument("empresa", empresa);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", empresa.CUIT),
				new SqlParameter("@NombreEmpresa", empresa.NombreEmpresa)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "EmpresaUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the Empresa table by its primary key.
		/// </summary>
		public void Delete(int cUIT)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "EmpresaDelete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Empresa table.
		/// </summary>
		public EmpresaEntidad Select(int cUIT)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "EmpresaSelect", parameters))
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
		/// Selects a single record from the Empresa table.
		/// </summary>
		public string SelectJson(int cUIT)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "EmpresaSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the Empresa table.
		/// </summary>
		public List<EmpresaEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "EmpresaSelectAll"))
			{
				List<EmpresaEntidad> empresaEntidadList = new List<EmpresaEntidad>();
				while (dataReader.Read())
				{
					EmpresaEntidad empresaEntidad = MapDataReader(dataReader);
					empresaEntidadList.Add(empresaEntidad);
				}

				return empresaEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Empresa table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "EmpresaSelectAll");
		}

		/// <summary>
		/// Creates a new instance of the EmpresaEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private EmpresaEntidad MapDataReader(SqlDataReader dataReader)
		{
			EmpresaEntidad empresaEntidad = new EmpresaEntidad();
			empresaEntidad.CUIT = dataReader.GetInt32("CUIT", 0);
			empresaEntidad.NombreEmpresa = dataReader.GetString("NombreEmpresa", null);

			return empresaEntidad;
		}

		#endregion
	}
}
