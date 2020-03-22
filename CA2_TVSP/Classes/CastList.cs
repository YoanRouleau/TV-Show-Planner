using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_TVSP.Classes
{
    public class CastList
    {

		private List<Actor> castingList;

		public CastList(List<Actor> pCastingList)
		{
			this.CastingList = pCastingList;
		}

		public CastList() { }

		public List<Actor> CastingList
		{
			get { return castingList; }
			set { castingList = value; }
		}


	}
}
