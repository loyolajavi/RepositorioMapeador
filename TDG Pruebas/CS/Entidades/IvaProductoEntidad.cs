using System;

namespace TFI.DAL
{
	public class IvaProductoEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IvaProductoEntidad class.
		/// </summary>
		public IvaProductoEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the IvaProductoEntidad class.
		/// </summary>
		public IvaProductoEntidad(int porcentajeIvaProd)
		{
			this.PorcentajeIvaProd = porcentajeIvaProd;
		}

		/// <summary>
		/// Initializes a new instance of the IvaProductoEntidad class.
		/// </summary>
		public IvaProductoEntidad(int idIvaProducto, int porcentajeIvaProd)
		{
			this.idIvaProducto = idIvaProducto;
			this.porcentajeIvaProd = porcentajeIvaProd;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdIvaProducto value.
		/// </summary>
		public int IdIvaProducto { get; set; }

		/// <summary>
		/// Gets or sets the PorcentajeIvaProd value.
		/// </summary>
		public int PorcentajeIvaProd { get; set; }

		#endregion
	}
}
