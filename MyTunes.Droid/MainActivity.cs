using Android.App;
using Android.OS;
using MyTunes.Shared;
using System.Collections;
using System.Linq;

namespace MyTunes
{
	[Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : ListActivity
	{
		protected async override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

//			ListAdapter = new ListAdapter<string>() {
//				DataSource = new[] { "One", "Two", "Three" }
//			};
			var songs = await SongLoader.Load();

			ListAdapter = new ListAdapter<Song> () {
				DataSource = songs.ToList(),
				TextProc = s => s.Name,
				DetailTextProc = s => s.Artist + " - " + s.Album
			};
		}
	}
}


