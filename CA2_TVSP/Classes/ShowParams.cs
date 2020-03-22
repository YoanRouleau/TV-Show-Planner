using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_TVSP.Classes
{
    public class ShowParams
    {
		
		public ShowParams() { }
		
		public String Title{ get; set; }
		public String ShowImage { get; set; }
		public String Genre { get; set; }
		public String Synopsis { get; set; }
		public CastList CastList { get; set; }
		public ProdList ProdList { get; set; }
		public int YearOfShow { get; set; }
		public Channel Channel { get; set; }
		public String ScreeningTime { get; set; }
	}
}
