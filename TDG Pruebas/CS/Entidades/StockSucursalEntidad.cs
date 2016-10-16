using System;

namespace TFI.DAL
{
	public class StockSucursalEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the StockSucursalEntidad class.
		/// </summary>
		public StockSucursalEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the StockSucursalEntidad class.
		/// </summary>
		public StockSucursalEntidad(int idProducto, int idSucursal, int cantidadProducto)
		{
			this.IdProducto = idProducto;
			this.IdSucursal = idSucursal;
			this.CantidadProducto = cantidadProducto;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdProducto value.
		/// </summary>
		public int IdProducto { get; set; }

		/// <summary>
		/// Gets or sets the IdSucursal value.
		/// </summary>
		public int IdSucursal { get; set; }

		/// <summary>
		/// Gets or sets the CantidadProducto value.
		/// </summary>
		public int CantidadProducto { get; set; }

		#endregion
	}
}
