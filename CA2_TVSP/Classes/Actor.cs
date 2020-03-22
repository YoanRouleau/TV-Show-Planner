using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_TVSP.Classes
{
    public class Actor : Member
    {

        private String biography;
        private int rating;
        private String imdbPage;

        public Actor(String pFirstName, String pLastName, DateTime pDateOfBirth, String pRole, String pBiography, int pRating, String pImdbPage)
            : base( pFirstName, pLastName, pDateOfBirth, pRole)
        {
            this.Role = pRole;
            this.Biograhy = pBiography;
            this.Rating = pRating;
            this.ImbdPage = pImdbPage;
        }

        public Actor() { }

        public String Biograhy
        {
            get { return biography; }
            set { biography = value; }
        }

        public int Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        public String ImbdPage
        {
            get { return imdbPage; }
            set { imdbPage = value; }
        }


    }
}
