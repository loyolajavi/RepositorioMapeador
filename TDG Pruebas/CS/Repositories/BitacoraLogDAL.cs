using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace TFI.DAL.DAL
{
	public class BitacoraLogDAL
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public BitacoraLogDAL(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the BitacoraLog table.
		/// </summary>
		public void Insert(BitacoraLogEntidad bitacoraLog)
		{
			ValidationUtility.ValidateArgument("bitacoraLog", bitacoraLog);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdBitacoraLog", bitacoraLog.IdBitacoraLog),
				new SqlParameter("@CUIT", bitacoraLog.CUIT),
				new SqlParameter("@NombreUsuario", bitacoraLog.NombreUsuario),
				new SqlParameter("@Evento", bitacoraLog.Evento),
				new SqlParameter("@FechaEvento", bitacoraLog.FechaEvento)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "BitacoraLogInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the BitacoraLog table.
		/// </summary>
		public void Update(BitacoraLogEntidad bitacoraLog)
		{
			ValidationUtility.ValidateArgument("bitacoraLog", bitacoraLog);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdBitacoraLog", bitacoraLog.IdBitacoraLog),
				new SqlParameter("@CUIT", bitacoraLog.CUIT),
				new SqlParameter("@NombreUsuario", bitacoraLog.NombreUsuario),
				new SqlParameter("@Evento", bitacoraLog.Evento),
				new SqlParameter("@FechaEvento", bitacoraLog.FechaEvento)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "BitacoraLogUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the BitacoraLog table by its primary key.
		/// </summary>
		public void Delete(int idBitacoraLog)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdBitacoraLog", idBitacoraLog)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "BitacoraLogDelete", parameters);
		}

		/// <summary>
		/// Deletes a record from the BitacoraLog table by a foreign key.
		/// </summary>
		public void DeleteAllByCUIT_NombreUsuario(int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "BitacoraLogDeleteAllByCUIT_NombreUsuario", parameters);
		}

		/// <summary>
		/// Selects a single record from the BitacoraLog table.
		/// </summary>
		public BitacoraLogEntidad Select(int idBitacoraLog)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdBitacoraLog", idBitacoraLog)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "BitacoraLogSelect", parameters))
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
		/// Selects a single record from the BitacoraLog table.
		/// </summary>
		public string SelectJson(int idBitacoraLog)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdBitacoraLog", idBitacoraLog)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "BitacoraLogSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the BitacoraLog table.
		/// </summary>
		public List<BitacoraLogEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "BitacoraLogSelectAll"))
			{
				List<BitacoraLogEntidad> bitacoraLogEntidadList = new List<BitacoraLogEntidad>();
				while (dataReader.Read())
				{
					BitacoraLogEntidad bitacoraLogEntidad = MapDataReader(dataReader);
					bitacoraLogEntidadList.Add(bitacoraLogEntidad);
				}

				return bitacoraLogEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the BitacoraLog table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "BitacoraLogSelectAll");
		}

		/// <summary>
		/// Selects all records from the BitacoraLog table by a foreign key.
		/// </summary>
		public List<BitacoraLogEntidad> SelectAllByCUIT_NombreUsuario(int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "BitacoraLogSelectAllByCUIT_NombreUsuario", parameters))
			{
				List<BitacoraLogEntidad> bitacoraLogEntidadList = new List<BitacoraLogEntidad>();
				while (dataReader.Read())
				{
					BitacoraLogEntidad bitacoraLogEntidad = MapDataReader(dataReader);
					bitacoraLogEntidadList.Add(bitacoraLogEntidad);
				}

				return bitacoraLogEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the BitacoraLog table by a foreign key.
		/// </summary>
		public string SelectAllByCUIT_NombreUsuarioJson(int cUIT, string nombreUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@CUIT", cUIT),
				new SqlParameter("@NombreUsuario", nombreUsuario)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "BitacoraLogSelectAllByCUIT_NombreUsuario", parameters);
		}

		/// <summary>
		/// Creates a new instance of the BitacoraLogEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private BitacoraLogEntidad MapDataReader(SqlDataReader dataReader)
		{
			BitacoraLogEntidad bitacoraLogEntidad = new BitacoraLogEntidad();
			bitacoraLogEntidad.IdBitacoraLog = dataReader.GetInt32("IdBitacoraLog", 0);
			bitacoraLogEntidad.CUIT = dataReader.GetInt32("CUIT", 0);
			bitacoraLogEntidad.NombreUsuario = dataReader.GetString("NombreUsuario", null);
			bitacoraLogEntidad.Evento = dataReader.GetString("Evento", null);
			bitacoraLogEntidad.FechaEvento = dataReader.GetDateTime("FechaEvento", new DateTime(0));

			return bitacoraLogEntidad;
		}

		#endregion
	}
}
