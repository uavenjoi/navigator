using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Globalization;

namespace Navigator
{
	public class NavigatorView
	{
		private List<Marker> listMarker;
		string fileStorageName = "write.txt";
		string currentPath = HttpRuntime.AppDomainAppPath;

		public List<Marker> ListMarker 
		{
			get 
			{
				return listMarker;
			}
		}

		public NavigatorView() 
		{
			GetCoordinatesList();

			//var marker1 = new Marker(48.51, 2.21);
			//marker1.Name = "Paris";
			//var marker2 = new Marker(51.30, 0.73);
			//marker2.Name = "London";
			//listMarker = new List<Marker>();
			//listMarker.Add(marker1);
			//listMarker.Add(marker2);
		}

		private void GetCoordinatesList()
		{
			listMarker = new List<Marker>();
			var fileStorageFullPath = Path.Combine(currentPath, fileStorageName);
			var lines = File.ReadAllLines(fileStorageFullPath);
			double latitude = 0;
			double longitude = 0;
			string cityName = string.Empty;
			Marker marker= null;
			foreach (var line in lines)
			{
				if(!String.IsNullOrEmpty(line))
				{
					var cityCoordinates = line.Split(' ').ToList();
					if (cityCoordinates.Count == 3)
					{
						cityName = cityCoordinates[0];
						double.TryParse(cityCoordinates[1], NumberStyles.Any, CultureInfo.InvariantCulture,  out latitude);
						double.TryParse(cityCoordinates[2], NumberStyles.Any, CultureInfo.InvariantCulture,  out longitude);
						marker = new Marker(latitude, longitude);
						marker.Name = cityName;
					}
					if (marker != null)
					{
						listMarker.Add(marker);
					}
				}
			}
		}
	}
}