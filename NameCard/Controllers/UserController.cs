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

				string _target = _FormCollection[ "target" ];
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

				return PartialView( _target,_ );
			}
			return new EmptyResult();
		}
	}
}