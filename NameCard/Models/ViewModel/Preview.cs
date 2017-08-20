using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NameCard.Models.ViewModel
{
	public class Preview
	{
		public M_ACCOUNT account { get; set; } = new M_ACCOUNT();
		public int Observe { get; set; } = -1;
		public int Reserve { get; set; } = -1;

		public Preview() { }
	}
}