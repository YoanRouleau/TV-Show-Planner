using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_TVSP.Classes
{
    public class Channel
    {

		private String channelName;

		public Channel(String pChannelName)
		{
			this.ChannelName = pChannelName;
		}

		public String ChannelName
		{
			get { return channelName; }
			set { channelName = value; }
		}

	}
}
