using System;

namespace TFI.DAL
{
	public class PatenteEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PatenteEntidad class.
		/// </summary>
		public PatenteEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the PatenteEntidad class.
		/// </summary>
		public PatenteEntidad(string nombrePatente)
		{
			this.NombrePatente = nombrePatente;
		}

		/// <summary>
		/// Initializes a new instance of the PatenteEntidad class.
		/// </summary>
		public PatenteEntidad(int idPatente, string nombrePatente)
		{
			this.IdPatente = idPatente;
			this.NombrePatente = nombrePatente;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdPatente value.
		/// </summary>
		public int IdPatente { get; set; }

		/// <summary>
		/// Gets or sets the NombrePatente value.
		/// </summary>
		public string NombrePatente { get; set; }

		#endregion
	}
}
