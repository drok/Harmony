using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace  HarmonyLib

{
	/// <summary>An exception caused by a user call to the library.</summary>
	///
	[Serializable]
	public class HarmonyUserException : HarmonyException
	{
		/// <summary>The Harmony Instance that was in use when the exception occured</summary>
		///
		public readonly Harmony harmonyInstance;

		internal HarmonyUserException(Harmony inst, string message) : base(message) {
			this.harmonyInstance = inst;
		}
		internal HarmonyUserException(Harmony inst, string message, Exception innerException) : base(message, innerException) {
			this.harmonyInstance = inst;
		}
	}
}
