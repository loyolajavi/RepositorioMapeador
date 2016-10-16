using System;

namespace TFI.DAL
{
	public class ComprobanteEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ComprobanteEntidad class.
		/// </summary>
		public ComprobanteEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the ComprobanteEntidad class.
		/// </summary>
		public ComprobanteEntidad(int nroComprobante, int idSucursal, int cUIT, int idTipoComprobante, int idComprobante, DateTime fechaComprobante, int idPedido)
		{
			this.NroComprobante = nroComprobante;
			this.IdSucursal = idSucursal;
			this.CUIT = cUIT;
			this.IdTipoComprobante = idTipoComprobante;
			this.IdComprobante = idComprobante;
			this.FechaComprobante = fechaComprobante;
			this.IdPedido = idPedido;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the NroComprobante value.
		/// </summary>
		public int NroComprobante { get; set; }

		/// <summary>
		/// Gets or sets the IdSucursal value.
		/// </summary>
		public int IdSucursal { get; set; }

		/// <summary>
		/// Gets or sets the CUIT value.
		/// </summary>
		public int CUIT { get; set; }

		/// <summary>
		/// Gets or sets the IdTipoComprobante value.
		/// </summary>
		public int IdTipoComprobante { get; set; }

		/// <summary>
		/// Gets or sets the IdComprobante value.
		/// </summary>
		public int IdComprobante { get; set; }

		/// <summary>
		/// Gets or sets the FechaComprobante value.
		/// </summary>
		public DateTime FechaComprobante { get; set; }

		/// <summary>
		/// Gets or sets the IdPedido value.
		/// </summary>
		public int IdPedido { get; set; }

		#endregion
	}
}
