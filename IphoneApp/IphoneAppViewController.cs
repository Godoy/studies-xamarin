using System;
using System.Drawing;
using System.Collections.Generic;
using GithubApi;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace IphoneApp
{
	public partial class IphoneAppViewController : UIViewController
	{
		public IphoneAppViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();

			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			btnSearch.TouchUpInside	+= async (object sender, EventArgs e) => {
				var github = new GithubApi.Github();
				var repositories = await github.GetAsync(txtUser.Text);

				lvwRepositories.Source = new TableViewSource(repositories);
				lvwRepositories.ReloadData();

			};
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion
	}

	public class TableViewSource : UITableViewSource {
		private List<string> _repositories;
		public TableViewSource(List<string> repositories) {
			this._repositories = repositories;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return _repositories.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell ("TableViewCell");
			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Default, "TableViewCell");

			cell.TextLabel.Text = _repositories [indexPath.Row];
			return cell;
		}

	}
}