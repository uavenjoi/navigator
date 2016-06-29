using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Services;
using System.Web.UI.WebControls;
using Subgurim.Controles;
using Subgurim.Controles.GoogleChartIconMaker;
using System.Drawing;
using System.IO;

namespace Navigator
{
	public partial class _Default : Page
	{
		NavigatorView navigatorView;
		protected void Page_Load(object sender, EventArgs e)
		{
			//if (!IsPostBack)
			//{
				navigatorView = new NavigatorView();
				var center = new GLatLng(48.51, 2.21);
				Gmap1.setCenter(center, 5);

				foreach (var marker in navigatorView.ListMarker)
				{
					if (marker.Latitude > -90 && marker.Latitude < 90)
					{
						var icon = new PinIcon(PinIcons.flag, Color.Coral);
						var xpinLetter = new XPinLetter(PinShapes.pin_star, "C", Color.Blue, Color.White, Color.Chocolate);
						var location = new GLatLng(marker.Latitude, marker.Longitude);
						Gmap1.Add(new GMarker(location, new GMarkerOptions(new GIcon(xpinLetter.ToString(), xpinLetter.Shadow()))));
						var gMarker = new GMarker(new GLatLng(marker.Latitude, marker.Longitude),
											new GMarkerOptions(new GIcon(icon.ToString(), icon.Shadow())));
						var tableText = String.Format(Marker.infoTableHtml, marker.Name, marker.Name, marker.Name);
						var infoWindow = new GInfoWindow(gMarker, tableText, false, GListener.Event.click);
						Gmap1.Add(infoWindow);
					}
				}
			//}
		}

		protected void FileUpload(object sender, EventArgs e)
		{
			HttpPostedFile file = Request.Files["fileUpload"];
			if (file != null)
			{
				var filePath = Path.GetFullPath(file.FileName);
				ProcessFile(file);
			}
		}

		private void ProcessFile(HttpPostedFile file)
		{
			string cityName = null;
			double longtitude = 0;
			double latitude = 0;
			navigatorView = new NavigatorView();
			var fileStorageFullPath = Path.Combine(navigatorView.currentPath, navigatorView.FileStorageFolder, navigatorView.FileStorageName);
			if (file != null)
			{
				using (var writeText = new StreamWriter(fileStorageFullPath))
				{
					var lines = new StreamReader(file.InputStream).ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
					foreach (var line in lines)
					{
						writeText.WriteLine(line);
					}
				}
			}
		}

	}
}