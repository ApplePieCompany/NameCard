using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NameCard.Models;

namespace NameCard.Controllers
{
	public class LoginController : Controller
	{
		ShareController _ShareController = new ShareController();

		// GET: Login
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Index(Account _Account)
		{
			if (ModelState.IsValid) {
				M_ACCOUNT _M_ACCOUNT = _ShareController.fetchAccount( _Account );

				if (_M_ACCOUNT.seq == 0) { _Account.Is = true; }
				else {
					Session[ "Account" ] = _M_ACCOUNT;
					switch (_M_ACCOUNT.AdminKbn) {
						case 0:
							return RedirectToAction( "Index", "User" );
						case 1:
							return RedirectToAction( "Index", "Admin" );
					}
				}
			}
			return View();
		}
	}
}