using System;
using System.Collections.Generic;
using System.Text;

namespace Proj0.Dal
{
    interface Utilities
    {	/// <summary>
	/// Helper function that print object to the console by iterating through list or collection
	/// take an object as it parameter
	/// </summary>
	/// <param name="oj"></param>
		public abstract void GetPrinter(object oj);

		//this is use to get the sum of return value of a table
		public abstract int GetSum(project0Context context, int id);

	}
}
