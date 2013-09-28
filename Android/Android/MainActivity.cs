using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ServiceStack.ServiceClient.Web;
using FluidityMVC.Api;
using System.Collections.Generic;
using System.Linq;

namespace Fluidity
{
	[Activity (Label = "Fluidity", MainLauncher = true)]
	public class MainActivity : Activity
	{
		private JsonServiceClient client;

		private IList<User> users;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			client = new JsonServiceClient ("http://192.168.1.123:46362/api/");
		
			PopulateSelectUsers ();
		
		}

		void PopulateSelectUsers ()
		{
			var response = client.Get(new Users());
			users = response.Users.ToList ();

			var names = users.Select (u => u.Name);

			var usersSpinner = FindViewById<Spinner> (Resource.Id.usersSpinner);
			usersSpinner.Adapter = new ArrayAdapter<string> (this, Android.Resource.Layout.SimpleListItem1, names.ToArray ());

		}
	}
}


