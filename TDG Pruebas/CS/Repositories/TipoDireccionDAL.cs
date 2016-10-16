using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class TipoDireccionDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public TipoDireccionDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the TipoDireccion table.
		/// </summary>
		public void Insert(TipoDireccionEntidad tipoDireccion)
		{
			ValidationUtility.ValidateArgument("tipoDireccion", tipoDireccion);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTipoDireccion", tipoDireccion.IdTipoDireccion),
				new SqlParameter("@DescripcionDireccion", tipoDireccion.DescripcionDireccion)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "TipoDireccionInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the TipoDireccion table.
		/// </summary>
		public void Update(TipoDireccionEntidad tipoDireccion)
		{
			ValidationUtility.ValidateArgument("tipoDireccion", tipoDireccion);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTipoDireccion", tipoDireccion.IdTipoDireccion),
				new SqlParameter("@DescripcionDireccion", tipoDireccion.DescripcionDireccion)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "TipoDireccionUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the TipoDireccion table by its primary key.
		/// </summary>
		public void Delete(int idTipoDireccion)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTipoDireccion", idTipoDireccion)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "TipoDireccionDelete", parameters);
		}

		/// <summary>
		/// Selects a single record from the TipoDireccion table.
		/// </summary>
		public TipoDireccionEntidad Select(int idTipoDireccion)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTipoDireccion", idTipoDireccion)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "TipoDireccionSelect", parameters))
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
		/// Selects a single record from the TipoDireccion table.
		/// </summary>
		public string SelectJson(int idTipoDireccion)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTipoDireccion", idTipoDireccion)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "TipoDireccionSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the TipoDireccion table.
		/// </summary>
		public List<TipoDireccionEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "TipoDireccionSelectAll"))
			{
				List<TipoDireccionEntidad> tipoDireccionEntidadList = new List<TipoDireccionEntidad>();
				while (dataReader.Read())
				{
					TipoDireccionEntidad tipoDireccionEntidad = MapDataReader(dataReader);
					tipoDireccionEntidadList.Add(tipoDireccionEntidad);
				}

				return tipoDireccionEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the TipoDireccion table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "TipoDireccionSelectAll");
		}

		/// <summary>
		/// Creates a new instance of the TipoDireccionEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private TipoDireccionEntidad MapDataReader(SqlDataReader dataReader)
		{
			TipoDireccionEntidad tipoDireccionEntidad = new TipoDireccionEntidad();
			tipoDireccionEntidad.IdTipoDireccion = dataReader.GetInt32("IdTipoDireccion", 0);
			tipoDireccionEntidad.DescripcionDireccion = dataReader.GetString("DescripcionDireccion", null);

			return tipoDireccionEntidad;
		}

		#endregion
	}
}
