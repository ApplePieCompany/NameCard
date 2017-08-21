using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NameCard.Models.ViewModel;

namespace NameCard.Controllers
{
	public class AdminController : Controller
	{
		ShareController _ShareController = new ShareController();

		// GET: Admin
		public ActionResult Index()
		{
			ViewBag.DATAS = _ShareController.fetchOrder();

			return View();
		}
	}
}