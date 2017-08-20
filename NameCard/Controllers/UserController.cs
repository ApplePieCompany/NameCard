using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NameCard.Models;
using NameCard.Models.ViewModel;

namespace NameCard.Controllers
{
	public class UserController : Controller
	{
		// GET: User
		public ActionResult Index()
		{
			Preview _Preview = new Preview() { account = Session[ "Account" ] as M_ACCOUNT };

			ViewBag.STYLE = Session[ "Preview" ] = _Preview;
			ViewBag.ACCOUNT = Session[ "Account" ] as M_ACCOUNT;

			return View();
		}


		[HttpPost]
		public ActionResult ShowPreview(FormCollection _FormCollection)
		{
			if (Request.IsAjaxRequest()) {

				string _name = _FormCollection[ "name" ];
				string _val = _FormCollection[ "val" ];

				Preview _ = Session[ "Preview" ] as Preview;
				switch (_name) {
					case "O":
						_.Observe = int.Parse( _val );
						break;
					case "R":
						_.Reserve = int.Parse( _val );
						break;
				}
				Session[ "Preview" ] = _;

				string _return = GetPreview( _name, _val, _ );

				return Content( _return, "text/plain" );
			}
			return new EmptyResult();
		}

		private string GetPreview(string _name, string _val, Preview _)
		{
			string _return = "";

			Dictionary < string, string> CONST_DIC = new Dictionary<string, string>() {
				{"O1","<div>名刺表パターン１</div><div>name</div>" },
				{"O2","<div>名刺表パターン２</div><div>name</div>" },
				{"O3","<div>名刺表パターン３</div><div>name</div>" },
				{"O4","<div>名刺表パターン４</div><div>name</div>" },
				{"O5","<div>名刺表パターン５</div><div>name</div>" },
				{"R1","<div>名刺ウラパターン１</div><div>name</div>" },
				{"R2","<div>名刺ウラパターン２</div><div>name</div>" },
				{"R3","<div>名刺ウラパターン３</div><div>name</div>" },
				{"R4","<div>名刺ウラパターン４</div><div>name</div>" },
				{"R5","<div>名刺ウラパターン５</div><div>name</div>" }
			};

			string _temp = CONST_DIC[ _name + _val ].ToString();
			switch (_name) {
				case "O":_return = _temp.Replace( "name", _.account.FirstName + "　" + _.account.LastName );break;
				case "R":_return = _temp.Replace( "name", _.account.FirstNameEn + "　" + _.account.LastNameEn );break;
			}

			return _return;
		}
	}
}