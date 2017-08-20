using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using NameCard.Models;
using NameCard.Models.ViewModel;

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

		public bool upsertAccount(Preview _)
		{
			using (var db = new DataClassesDataContext( ConfigurationManager.ConnectionStrings[ "NameCardConnectionString" ].ConnectionString )) {
				try {
					if (db.R_ORDER.Any( x => x.EMail == _.account.EMail && x.Passwd == _.account.Passwd )) {
						R_ORDER _rec = db.R_ORDER.FirstOrDefault( x => x.EMail == _.account.EMail && x.Passwd == _.account.Passwd );
						db.R_ORDER.DeleteOnSubmit( _rec );
						db.SubmitChanges();
					}

					R_ORDER _temp = new R_ORDER() {
						EMail = _.account.EMail,
						Passwd = _.account.Passwd,
						Obverse = _.Observe,
						Reverse = _.Reserve,
					};

					db.R_ORDER.InsertOnSubmit( _temp );
					db.SubmitChanges();

				}
				catch (Exception ee) { return false; }
			}
			return true;
		}
	}
}