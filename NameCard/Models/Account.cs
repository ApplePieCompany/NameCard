using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace NameCard.Models
{
	public class Account
	{
		[Required( ErrorMessage = "Emailが入力されていません" )]
		public string Email { get; set; }

		[DataType( DataType.Password )]
		[Required( ErrorMessage = "パスワードが入力されていません" )]
		public string Passwd { get; set; }

		public bool Is { get; set; }

		public Account()
		{
			this.Is = false;
		}
	}
}