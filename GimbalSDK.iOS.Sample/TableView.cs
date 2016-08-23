using System;
using System.Collections.Generic;
using UIKit;
using Foundation;

namespace GimbalSDK.iOS.Sample
{
	public class Table : UITableViewController, IUITableViewDataSource, IUITableViewDelegate, IDisposable {

		private GimbalFramework.GMBLPlaceManager placeManager;
		private GimbalPlaceManagerDelegate gimbalPlaceManagerDelegate;


		private List<string> events;

		public Table()
		{

			gimbalPlaceManagerDelegate = new GimbalPlaceManagerDelegate(this);
			placeManager = new GimbalFramework.GMBLPlaceManager();
			placeManager.Delegate = gimbalPlaceManagerDelegate;

			events = new List<string> ();


		}

		public override nint NumberOfSections(UITableView tableView)
		{
			return 1;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return events.Count;
		}

		public void addPlaceEvent(String placeEvent)
		{
			events.Add(placeEvent);
			TableView.ReloadData();
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = base.GetCell(tableView, indexPath);

			cell.TextLabel.Text = events[indexPath.Row];

			return cell;
		}

		class GimbalPlaceManagerDelegate : GimbalFramework.GMBLPlaceManagerDelegate
		{
			Table table;

			public GimbalPlaceManagerDelegate(Table tableRef)
			{
				table = tableRef;	
			}
			public override void DidBeginVisit(GimbalFramework.GMBLPlaceManager manager, GimbalFramework.GMBLVisit visit)
			{
				Console.WriteLine("Adapter DidBeginVisit: " + visit.Place.Description);
				table.addPlaceEvent("ENTER: " + visit.Place.Description);
			}

			public override void DidEndVisit(GimbalFramework.GMBLPlaceManager manager, GimbalFramework.GMBLVisit visit)
			{
				Console.WriteLine("Adapter DidEndVisit: " + visit.Place.Description);
				table.addPlaceEvent("EXIT: " + visit.Place.Description);

			}

			public override void DidDetectLocation(GimbalFramework.GMBLPlaceManager manager, CoreLocation.CLLocation location)
			{
				Console.WriteLine("Adapter DidDetectLocation: " + location.Coordinate.Latitude + " " + location.Coordinate.Longitude);
			}

			public override void DidReceiveBeaconSighting(GimbalFramework.GMBLPlaceManager manager, GimbalFramework.GMBLBeaconSighting sighting, NSObject[] visits)
			{
				Console.WriteLine("Adapter DidReceiveBeaconSighting: " + sighting.Beacon.Name);
			}
		}
					
	}
}

