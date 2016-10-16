using System;

namespace TFI.DAL
{
	public class PagoEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PagoEntidad class.
		/// </summary>
		public PagoEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the PagoEntidad class.
		/// </summary>
		public PagoEntidad(int idPedido, DateTime fechaPago, int idEstadoPago, int idFormaPago, decimal montoPago, int nroComprobante, int idSucursal, int idTipoComprobante, int cUIT)
		{
			this.IdPedido = idPedido;
			this.FechaPago = fechaPago;
			this.IdEstadoPago = idEstadoPago;
			this.IdFormaPago = idFormaPago;
			this.MontoPago = montoPago;
			this.NroComprobante = nroComprobante;
			this.IdSucursal = idSucursal;
			this.IdTipoComprobante = idTipoComprobante;
			this.CUIT = cUIT;
		}

		/// <summary>
		/// Initializes a new instance of the PagoEntidad class.
		/// </summary>
		public PagoEntidad(int idPago, int idPedido, DateTime fechaPago, int idEstadoPago, int idFormaPago, decimal montoPago, int nroComprobante, int idSucursal, int idTipoComprobante, int cUIT)
		{
			this.idPago = idPago;
			this.idPedido = idPedido;
			this.fechaPago = fechaPago;
			this.idEstadoPago = idEstadoPago;
			this.idFormaPago = idFormaPago;
			this.montoPago = montoPago;
			this.nroComprobante = nroComprobante;
			this.idSucursal = idSucursal;
			this.idTipoComprobante = idTipoComprobante;
			this.cUIT = cUIT;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdPago value.
		/// </summary>
		public int IdPago { get; set; }

		/// <summary>
		/// Gets or sets the IdPedido value.
		/// </summary>
		public int IdPedido { get; set; }

		/// <summary>
		/// Gets or sets the FechaPago value.
		/// </summary>
		public DateTime FechaPago { get; set; }

		/// <summary>
		/// Gets or sets the IdEstadoPago value.
		/// </summary>
		public int IdEstadoPago { get; set; }

		/// <summary>
		/// Gets or sets the IdFormaPago value.
		/// </summary>
		public int IdFormaPago { get; set; }

		/// <summary>
		/// Gets or sets the MontoPago value.
		/// </summary>
		public decimal MontoPago { get; set; }

		/// <summary>
		/// Gets or sets the NroComprobante value.
		/// </summary>
		public int NroComprobante { get; set; }

		/// <summary>
		/// Gets or sets the IdSucursal value.
		/// </summary>
		public int IdSucursal { get; set; }

		/// <summary>
		/// Gets or sets the IdTipoComprobante value.
		/// </summary>
		public int IdTipoComprobante { get; set; }

		/// <summary>
		/// Gets or sets the CUIT value.
		/// </summary>
		public int CUIT { get; set; }

		#endregion
	}
}
