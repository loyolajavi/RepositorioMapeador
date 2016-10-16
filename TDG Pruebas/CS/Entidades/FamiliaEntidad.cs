using System;

namespace TFI.DAL
{
	public class FamiliaEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FamiliaEntidad class.
		/// </summary>
		public FamiliaEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the FamiliaEntidad class.
		/// </summary>
		public FamiliaEntidad(string nombreFamilia)
		{
			this.NombreFamilia = nombreFamilia;
		}

		/// <summary>
		/// Initializes a new instance of the FamiliaEntidad class.
		/// </summary>
		public FamiliaEntidad(int idFamilia, string nombreFamilia)
		{
			this.idFamilia = idFamilia;
			this.nombreFamilia = nombreFamilia;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdFamilia value.
		/// </summary>
		public int IdFamilia { get; set; }

		/// <summary>
		/// Gets or sets the NombreFamilia value.
		/// </summary>
		public string NombreFamilia { get; set; }

		#endregion
	}
}
