using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_TVSP.Classes
{
    public class Show
    {

		private String title;
		private String showImage;
		private String genre;
		private int yearOfShow;
		private CastList castList;
		private ProdList prodList;
		private Channel channel;
		private String screeningTime;
		private String synopsis;
		private int rating;


		public Show(String pTitle, String pShowImage, String pGenre, int pYearOfShow, CastList pCastList, ProdList pProdList, 
			Channel pChannel, String pScreeningTime, String pSynopsis, int pRating)
		{
			this.Title = pTitle;
			this.ShowImage = pShowImage;
			this.Genre = pGenre;
			this.YearOfShow = pYearOfShow;
			this.CastList = pCastList;
			this.ProdList = pProdList;
			this.Channel = pChannel;
			this.ScreeningTime = pScreeningTime;
			this.Synopsis = pSynopsis;
			this.rating = pRating;
		}


		public String Title
		{
			get { return title; }
			set { title = value; }
		}

		public String ShowImage
		{
			get { return showImage; }
			set { showImage = value; }
		}

		public String Genre
		{
			get { return genre; }
			set { genre = value; }
		}

		public int YearOfShow
		{
			get { return yearOfShow; }
			set { yearOfShow = value; }
		}

		public CastList CastList
		{
			get { return castList; }
			set { castList = value; }
		}

		public ProdList ProdList
		{
			get { return prodList; }
			set { prodList = value; }
		}

		public Channel Channel
		{
			get { return channel; }
			set { channel = value; }
		}

		public String ScreeningTime
		{
			get { return screeningTime; }
			set { screeningTime = value; }
		}

		public String Synopsis
		{
			get { return synopsis; }
			set { synopsis = value; }
		}

		public int Rating
		{
			get { return rating; }
			set { rating = value; }
		}



	}
}
