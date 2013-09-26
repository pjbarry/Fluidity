using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ServiceStack.ServiceClient.Web;

namespace Android
{
	[Activity (Label = "Fluidity", MainLauncher = true)]
	public class MainActivity : Activity
	{
		private JsonServiceClient client;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			Console.WriteLine("contacting server");
			client = new JsonServiceClient ("http://192.168.1.123:46362/api");
			var response = client.Get<string> ("users");
			Console.WriteLine(response);
			Console.WriteLine ("json data received");
		}
	}
}


