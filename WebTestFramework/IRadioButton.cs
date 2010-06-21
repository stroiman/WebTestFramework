using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebTestFramework
{
	/// <summary>
	/// Represents a radio button on a web page (input type=radio)
	/// </summary>
	public interface IRadioButton
	{
		/// <summary>
		/// Selects the radio button.
		/// </summary>
		void Select();
	}
}
