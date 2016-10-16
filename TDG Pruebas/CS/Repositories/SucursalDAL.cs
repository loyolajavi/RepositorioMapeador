using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class SucursalDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public SucursalDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Sucursal table.
		/// </summary>
		public void Insert(SucursalEntidad sucursal)
		{
			ValidationUtility.ValidateArgument("sucursal", sucursal);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DescripSucursal", sucursal.DescripSucursal),
				new SqlParameter("@DireccionSucursal", sucursal.DireccionSucursal),
				new SqlParameter("@CUIT", sucursal.CUIT)
			};

			sucursal.IdSucursal = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "SucursalInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the Sucursal table.
		/// </summary>
		public void Update(SucursalEntidad sucursal)
		{
			ValidationUtility.ValidateArgument("sucursal", sucursal);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdSucursal", sucursal.IdSucursal),
				new SqlParameter("@DescripSucursal", sucursal.DescripSucursal),
				new SqlParameter("@DireccionSucursal", sucursal.DireccionSucursal),
				new SqlParameter("@CUIT", sucursal.CUIT)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "SucursalUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sucursal table by its primary key.
		/// </summary>
		public void Delete(int idSucursal)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdSucursal", idSucursal)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "SucursalDelete", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sucursal table by a foreign key.
		/// </summary>
		public void DeleteAllByDireccionSucursal(int direccionSucursal)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DireccionSucursal", direccionSucursal)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "SucursalDeleteAllByDireccionSucursal", parameters);
		}

		/// <summary>
		/// Deletes a record from the Sucursal table by a foreign key.
		/// </summary>
		public void DeleteAllByCUIT(int cUIT)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "SucursalDeleteAllByCUIT", parameters);
		}

		/// <summary>
		/// Selects a single record from the Sucursal table.
		/// </summary>
		public SucursalEntidad Select(int idSucursal)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdSucursal", idSucursal)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "SucursalSelect", parameters))
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
		/// Selects a single record from the Sucursal table.
		/// </summary>
		public string SelectJson(int idSucursal)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdSucursal", idSucursal)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "SucursalSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the Sucursal table.
		/// </summary>
		public List<SucursalEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "SucursalSelectAll"))
			{
				List<SucursalEntidad> sucursalEntidadList = new List<SucursalEntidad>();
				while (dataReader.Read())
				{
					SucursalEntidad sucursalEntidad = MapDataReader(dataReader);
					sucursalEntidadList.Add(sucursalEntidad);
				}

				return sucursalEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Sucursal table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "SucursalSelectAll");
		}

		/// <summary>
		/// Selects all records from the Sucursal table by a foreign key.
		/// </summary>
		public List<SucursalEntidad> SelectAllByDireccionSucursal(int direccionSucursal)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DireccionSucursal", direccionSucursal)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "SucursalSelectAllByDireccionSucursal", parameters))
			{
				List<SucursalEntidad> sucursalEntidadList = new List<SucursalEntidad>();
				while (dataReader.Read())
				{
					SucursalEntidad sucursalEntidad = MapDataReader(dataReader);
					sucursalEntidadList.Add(sucursalEntidad);
				}

				return sucursalEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Sucursal table by a foreign key.
		/// </summary>
		public List<SucursalEntidad> SelectAllByCUIT(int cUIT)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "SucursalSelectAllByCUIT", parameters))
			{
				List<SucursalEntidad> sucursalEntidadList = new List<SucursalEntidad>();
				while (dataReader.Read())
				{
					SucursalEntidad sucursalEntidad = MapDataReader(dataReader);
					sucursalEntidadList.Add(sucursalEntidad);
				}

				return sucursalEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Sucursal table by a foreign key.
		/// </summary>
		public string SelectAllByDireccionSucursalJson(int direccionSucursal)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@DireccionSucursal", direccionSucursal)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "SucursalSelectAllByDireccionSucursal", parameters);
		}

		/// <summary>
		/// Selects all records from the Sucursal table by a foreign key.
		/// </summary>
		public string SelectAllByCUITJson(int cUIT)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "SucursalSelectAllByCUIT", parameters);
		}

		/// <summary>
		/// Creates a new instance of the SucursalEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private SucursalEntidad MapDataReader(SqlDataReader dataReader)
		{
			SucursalEntidad sucursalEntidad = new SucursalEntidad();
			sucursalEntidad.IdSucursal = dataReader.GetInt32("IdSucursal", 0);
			sucursalEntidad.DescripSucursal = dataReader.GetString("DescripSucursal", null);
			sucursalEntidad.DireccionSucursal = dataReader.GetInt32("DireccionSucursal", 0);
			sucursalEntidad.CUIT = dataReader.GetInt32("CUIT", 0);

			return sucursalEntidad;
		}

		#endregion
	}
}
