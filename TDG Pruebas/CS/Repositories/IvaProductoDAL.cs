using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class IvaProductoDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public IvaProductoDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the IvaProducto table.
		/// </summary>
		public void Insert(IvaProductoEntidad ivaProducto)
		{
			ValidationUtility.ValidateArgument("ivaProducto", ivaProducto);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@PorcentajeIvaProd", ivaProducto.PorcentajeIvaProd)
			};

			ivaProducto.IdIvaProducto = (int) SqlClientUtility.ExecuteScalar(connectionStringName, CommandType.StoredProcedure, "IvaProductoInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the IvaProducto table.
		/// </summary>
		public void Update(IvaProductoEntidad ivaProducto)
		{
			ValidationUtility.ValidateArgument("ivaProducto", ivaProducto);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdIvaProducto", ivaProducto.IdIvaProducto),
				new SqlParameter("@PorcentajeIvaProd", ivaProducto.PorcentajeIvaProd)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "IvaProductoUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the IvaProducto table by its primary key.
		/// </summary>
		public void Delete(int idIvaProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdIvaProducto", idIvaProducto)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "IvaProductoDelete", parameters);
		}

		/// <summary>
		/// Selects a single record from the IvaProducto table.
		/// </summary>
		public IvaProductoEntidad Select(int idIvaProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdIvaProducto", idIvaProducto)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "IvaProductoSelect", parameters))
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
		/// Selects a single record from the IvaProducto table.
		/// </summary>
		public string SelectJson(int idIvaProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdIvaProducto", idIvaProducto)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "IvaProductoSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the IvaProducto table.
		/// </summary>
		public List<IvaProductoEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "IvaProductoSelectAll"))
			{
				List<IvaProductoEntidad> ivaProductoEntidadList = new List<IvaProductoEntidad>();
				while (dataReader.Read())
				{
					IvaProductoEntidad ivaProductoEntidad = MapDataReader(dataReader);
					ivaProductoEntidadList.Add(ivaProductoEntidad);
				}

				return ivaProductoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the IvaProducto table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "IvaProductoSelectAll");
		}

		/// <summary>
		/// Creates a new instance of the IvaProductoEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private IvaProductoEntidad MapDataReader(SqlDataReader dataReader)
		{
			IvaProductoEntidad ivaProductoEntidad = new IvaProductoEntidad();
			ivaProductoEntidad.IdIvaProducto = dataReader.GetInt32("IdIvaProducto", 0);
			ivaProductoEntidad.PorcentajeIvaProd = dataReader.GetInt32("PorcentajeIvaProd", 0);

			return ivaProductoEntidad;
		}

		#endregion
	}
}
