using System;

namespace TFI.DAL
{
	public class FormaPagoEntidades
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FormaPagoEntidades class.
		/// </summary>
		public FormaPagoEntidades()
		{
		}

		/// <summary>
		/// Initializes a new instance of the FormaPagoEntidades class.
		/// </summary>
		public FormaPagoEntidades(string descripFormaPago)
		{
			this.DescripFormaPago = descripFormaPago;
		}

		/// <summary>
		/// Initializes a new instance of the FormaPagoEntidades class.
		/// </summary>
		public FormaPagoEntidades(int idFormaPago, string descripFormaPago)
		{
			this.IdFormaPago = idFormaPago;
			this.DescripFormaPago = descripFormaPago;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdFormaPago value.
		/// </summary>
		public int IdFormaPago { get; set; }

		/// <summary>
		/// Gets or sets the DescripFormaPago value.
		/// </summary>
		public string DescripFormaPago { get; set; }

		#endregion
	}
}
