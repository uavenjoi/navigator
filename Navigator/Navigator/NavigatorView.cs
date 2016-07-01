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
		const string fileStorageFolder = "Files";
		const string fileStorageName = "write.txt";
		public readonly string currentPath = HttpRuntime.AppDomainAppPath;

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
		}

		public string FileStorageFolder
		{
			get { return fileStorageFolder; }
		}

		public string FileStorageName
		{
			get { return fileStorageName; }
		}

		private void GetCoordinatesList()
		{
			const int numberOfSubstrings = 13;
			double latDegree = 0;
			double lonDegree = 0;
			double latMinutes = 0;
			double lonMinutes = 0;
			double latSeconds = 0;
			double lonSeconds = 0;
			double longitude = 0;
			double latitude = 0;
			listMarker = new List<Marker>();
			string cityName = string.Empty;
			Marker marker= null;
			var lines = GetLinesFromFile();
			if (lines != null)
			{
				foreach (var line in lines)
				{
					if (!String.IsNullOrEmpty(line))
					{
						var cityCoordinates = line.Split(' ').ToList().Where(s=> !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
						if (cityCoordinates.Count == numberOfSubstrings)
						{
							cityName = cityCoordinates[4]+ " " + cityCoordinates[5];
							double.TryParse(cityCoordinates[6], NumberStyles.Float, CultureInfo.InvariantCulture, out lonDegree);
							double.TryParse(cityCoordinates[7], NumberStyles.Float, CultureInfo.InvariantCulture, out lonMinutes);
							double.TryParse(cityCoordinates[8], NumberStyles.Float, CultureInfo.InvariantCulture, out lonSeconds);
							double.TryParse(cityCoordinates[9], NumberStyles.Float, CultureInfo.InvariantCulture, out latDegree);
							double.TryParse(cityCoordinates[10], NumberStyles.Float, CultureInfo.InvariantCulture, out latMinutes);
							double.TryParse(cityCoordinates[11], NumberStyles.Float, CultureInfo.InvariantCulture, out latSeconds);
							latitude=latDegree + latMinutes*0.01 + latSeconds*0.0001;
							longitude = lonDegree+lonMinutes*0.01+lonSeconds*0.0001;
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

		private List<string> GetLinesFromFile()
		{
			string lineStartCoordinates = "+SITE/ID";
			string linesEndCoordinates = "-SITE/ID";
			var fileStorageFullPath = Path.Combine(currentPath, fileStorageFolder, fileStorageName);
			var lines = File.ReadAllLines(fileStorageFullPath);
			List<string> coordLinesList = new List<string>();
			bool isCoordinateLine = false;

			foreach (var line in lines)
			{
				if (String.Compare(line, linesEndCoordinates) == 0) 
					break;
				if (!isCoordinateLine && String.Compare(line, lineStartCoordinates) == 0)
					isCoordinateLine = true;
				if (isCoordinateLine)
				{
					coordLinesList.Add(line);
				}
			}
			return coordLinesList;
		}
	}
}