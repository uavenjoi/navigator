using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Navigator
{
	public class Marker
	{

		#region constants
		public const string infoTableHtml = @"<div>
												Test Marker
												<a href='test'>{0}</a>
												<br>
												<table style=""border: 1px solid #000088;"">
													<tr style=""border: 1px solid #000088;"">
														<td>{1}</td>
														<td>{2}</td>
													</tr>
													<tr>
														<td>One</td>
														<td>Two</td>
													</tr>
												</table>
											</div>";
		#endregion
		public double Longitude { get; set; }
		public double Latitude { get; set; }
		public string Name { get; set; }

		public Marker(double latitude, double longitude)
		{
			Longitude = longitude;
			Latitude = latitude;
		}
	}
}