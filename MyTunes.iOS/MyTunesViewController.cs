using UIKit;
using MyTunes.Shared;
using System.Collections;
using System.Linq;

namespace MyTunes
{
	public class MyTunesViewController : UITableViewController
	{
		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();

			if (UIDevice.CurrentDevice.CheckSystemVersion(7,0)) {
				TableView.ContentInset = new UIEdgeInsets (20, 0, 0, 0);
			}
		}

		public async override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var songs = await SongLoader.Load();

			TableView.Source = new ViewControllerSource<Song> (TableView) {
				DataSource = songs.ToList(),
				TextProc = s => s.Name,
				DetailTextProc = s => s.Artist + " - " + s.Album
			};
//			TableView.Source = new ViewControllerSource<string>(TableView) {
//				DataSource = new string[] { "One", "Two", "Three" },
//			};
		}
	}

}

