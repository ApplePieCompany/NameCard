using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using NameCard.Models;

namespace NameCard.Controllers
{
	public class ShareController
	{
		public M_ACCOUNT fetchAccount(Account _Account)
		{
			M_ACCOUNT _return = new M_ACCOUNT();

			using (var db = new DataClassesDataContext( ConfigurationManager.ConnectionStrings[ "NameCardConnectionString" ].ConnectionString )) {
				try {
					if (db.M_ACCOUNT.Any( x => x.EMail == _Account.Email && x.Passwd == _Account.Passwd )) {
						_return = db.M_ACCOUNT.SingleOrDefault( x => x.EMail == _Account.Email && x.Passwd == _Account.Passwd );
					}
				}
				catch (Exception ee) { }
			}

			return _return;
		}
	}
}