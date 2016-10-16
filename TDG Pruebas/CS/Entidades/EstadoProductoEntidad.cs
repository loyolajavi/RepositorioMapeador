using System;

namespace TFI.DAL
{
	public class EstadoProductoEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EstadoProductoEntidad class.
		/// </summary>
		public EstadoProductoEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the EstadoProductoEntidad class.
		/// </summary>
		public EstadoProductoEntidad(string descripEstadoProducto)
		{
			this.DescripEstadoProducto = descripEstadoProducto;
		}

		/// <summary>
		/// Initializes a new instance of the EstadoProductoEntidad class.
		/// </summary>
		public EstadoProductoEntidad(int idEstadoProducto, string descripEstadoProducto)
		{
			this.idEstadoProducto = idEstadoProducto;
			this.descripEstadoProducto = descripEstadoProducto;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdEstadoProducto value.
		/// </summary>
		public int IdEstadoProducto { get; set; }

		/// <summary>
		/// Gets or sets the DescripEstadoProducto value.
		/// </summary>
		public string DescripEstadoProducto { get; set; }

		#endregion
	}
}
