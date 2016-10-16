using System;

namespace TFI.DAL
{
	public class TipoComprobanteEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TipoComprobanteEntidad class.
		/// </summary>
		public TipoComprobanteEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the TipoComprobanteEntidad class.
		/// </summary>
		public TipoComprobanteEntidad(string descripTipoComprobante)
		{
			this.DescripTipoComprobante = descripTipoComprobante;
		}

		/// <summary>
		/// Initializes a new instance of the TipoComprobanteEntidad class.
		/// </summary>
		

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdTipoComprobante value.
		/// </summary>
		public int IdTipoComprobante { get; set; }

		/// <summary>
		/// Gets or sets the DescripTipoComprobante value.
		/// </summary>
		public string DescripTipoComprobante { get; set; }

		#endregion
	}
}
