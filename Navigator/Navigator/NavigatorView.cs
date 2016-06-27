using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Navigator
{
	public class NavigatorView
	{
		private List<Marker> listMarker;

		public List<Marker> ListMarker 
		{
			get 
			{
				return listMarker;
			}
		}

		public NavigatorView() 
		{
			var marker1 = new Marker(48.51, 2.21);
			marker1.Name = "Paris";
			var marker2 = new Marker(51.30, 0.73);
			marker2.Name = "London";
			listMarker = new List<Marker>();
			listMarker.Add(marker1);
			listMarker.Add(marker2);
		}

	}
}