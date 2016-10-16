using System;

namespace TFI.DAL
{
	public class SucursalEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SucursalEntidad class.
		/// </summary>
		public SucursalEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the SucursalEntidad class.
		/// </summary>
		public SucursalEntidad(string descripSucursal, int direccionSucursal, int cUIT)
		{
			this.DescripSucursal = descripSucursal;
			this.DireccionSucursal = direccionSucursal;
			this.CUIT = cUIT;
		}

		/// <summary>
		/// Initializes a new instance of the SucursalEntidad class.
		/// </summary>
		public SucursalEntidad(int idSucursal, string descripSucursal, int direccionSucursal, int cUIT)
		{
			this.idSucursal = idSucursal;
			this.descripSucursal = descripSucursal;
			this.direccionSucursal = direccionSucursal;
			this.cUIT = cUIT;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdSucursal value.
		/// </summary>
		public int IdSucursal { get; set; }

		/// <summary>
		/// Gets or sets the DescripSucursal value.
		/// </summary>
		public string DescripSucursal { get; set; }

		/// <summary>
		/// Gets or sets the DireccionSucursal value.
		/// </summary>
		public int DireccionSucursal { get; set; }

		/// <summary>
		/// Gets or sets the CUIT value.
		/// </summary>
		public int CUIT { get; set; }

		#endregion
	}
}