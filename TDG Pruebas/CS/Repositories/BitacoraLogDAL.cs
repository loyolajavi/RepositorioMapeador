using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TFI.HelperDAL;


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

			using (DataTable dt = SqlClientUtility.ExecuteDataTable(connectionStringName, CommandType.StoredProcedure, "BitacoraLogSelect", parameters))
			{
                BitacoraLogEntidad BitacoraLogEntidad = new BitacoraLogEntidad();

                BitacoraLogEntidad = Mapeador.MapearFirst<BitacoraLogEntidad>(dt);

                return BitacoraLogEntidad;
			}
		}

		/// <summary>
		/// Selects all records from the BitacoraLog table.
		/// </summary>
		public List<BitacoraLogEntidad> SelectAll()
		{
			using (DataTable dt = SqlClientUtility.ExecuteDataTable(connectionStringName, CommandType.StoredProcedure, "BitacoraLogSelectAll"))
			{
				List<BitacoraLogEntidad> bitacoraLogEntidadList = new List<BitacoraLogEntidad>();

                bitacoraLogEntidadList = Mapeador.Mapear<BitacoraLogEntidad>(dt);

				return bitacoraLogEntidadList;
			}
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

			using (DataTable dt = SqlClientUtility.ExecuteDataTable(connectionStringName, CommandType.StoredProcedure, "BitacoraLogSelectAllByCUIT_NombreUsuario", parameters))
			{
				List<BitacoraLogEntidad> bitacoraLogEntidadList = new List<BitacoraLogEntidad>();

                bitacoraLogEntidadList = Mapeador.Mapear<BitacoraLogEntidad>(dt);

                return bitacoraLogEntidadList;

			}
		}


		#endregion
	}
}
