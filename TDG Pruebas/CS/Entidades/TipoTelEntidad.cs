using System;

namespace TFI.DAL
{
	public class TipoTelEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TipoTelEntidad class.
		/// </summary>
		public TipoTelEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the TipoTelEntidad class.
		/// </summary>
		public TipoTelEntidad(string descripcionTipoTel, int tipo)
            
		{
            this.IdTipoTel = tipo;
			this.DescripcionTipoTel = descripcionTipoTel;
		}

		/// <summary>
		/// Initializes a new instance of the TipoTelEntidad class.
		/// </summary>
	

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdTipoTel value.
		/// </summary>
		public int IdTipoTel { get; set; }

		/// <summary>
		/// Gets or sets the DescripcionTipoTel value.
		/// </summary>
		public string DescripcionTipoTel { get; set; }

		#endregion
	}
}
