using System;

namespace TFI.DAL
{
	public class PatenteFamiliaEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PatenteFamiliaEntidad class.
		/// </summary>
		public PatenteFamiliaEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the PatenteFamiliaEntidad class.
		/// </summary>
		public PatenteFamiliaEntidad(int idPatente, int idFamilia)
		{
			this.IdPatente = idPatente;
			this.IdFamilia = idFamilia;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdPatente value.
		/// </summary>
		public int IdPatente { get; set; }

		/// <summary>
		/// Gets or sets the IdFamilia value.
		/// </summary>
		public int IdFamilia { get; set; }

		#endregion
	}
}
