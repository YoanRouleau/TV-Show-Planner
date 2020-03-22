using CA2_TVSP.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CA2_TVSP
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static List<Show> showToDisplay = new List<Show>();
        public static List<Show> allTheShows = new List<Show>();
        public MainPage()
        {
            //ALLOW THE APP TO AVOID HAVING DUPLICATES AT START
            showToDisplay.Clear();
            allTheShows.Clear();

            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(334, 627);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(334, 627));


            //CHANNELS--------------------------------------------------
            Channel bbc = new Channel("BBC One");
            Channel hbo = new Channel("HBO");
            Channel history = new Channel("History");
            Channel theCW = new Channel("The CW");
            Channel tvtokyo = new Channel("TV Tokyo");
            //----------------------------------------------------------


            //SHERLOCK---------------------------------
            Actor bCumberbatch = new Actor("Benedict", "Cumberbatch", new DateTime(1976, 8, 15), "Main Role", "Benedict Timothy Carlton Cumberbatch CBE (born 19 July 1976) " +
                "is an English actor. A graduate of the Victoria University of Manchester, he continued his training at the London Academy of Music and Dramatic Art, " +
                "obtaining a Master of Arts in Classical Acting.", 5, "https://www.imdb.com/name/nm1212722/");

            Actor mFreeman = new Actor("Martin", "Freeman", new DateTime(1971, 9, 8), "Main Role", "Martin John Christopher Freeman is an English actor and comedian, known " +
                "for portraying Bilbo Baggins in Peter Jackson's The Hobbit film trilogy (2012–2014), Tim Canterbury in the original UK version of sitcom mockumentary The Office " +
                "(2001–2003), Dr. John Watson in the British crime drama Sherlock (2010–2017), and Lester Nygaard in the dark comedy-crime drama TV series Fargo (2014).", 4,
                "https://www.imdb.com/name/nm0293509/");

            Actor aScott = new Actor("Andrew", "Scott", new DateTime(1976, 10, 21), "Bad guy", "Andrew Scott is an Irish actor. He achieved widespread " +
                "recognition for playing the role of Jim Moriarty in the BBC series Sherlock, a role that earned him the BAFTA Television Award for Best Supporting Actor. Scott won " +
                "further acclaim playing the title role of Hamlet in a 2017 production first staged at the Almeida Theatre, for which he was nominated for the Laurence Olivier Award " +
                "for Best Actor.", 3, "https://www.imdb.com/name/nm0778831/");

            Actor lBrealey = new Actor("Louise", "Brealey", new DateTime(1979, 3, 27), "Secondary Role", "Louise Brealey, also credited as Loo Brealey, is an English actress, writer " +
                "and journalist. She played Molly Hooper in Sherlock, Cass in Back with David Mitchell and Robert Webb, Scottish professor Jude McDermid in Clique, Gillian Chamberlain " +
                "in A Discovery of Witches and Donna Harman in Death in Paradise.Louise Brealey, also credited as Loo Brealey, is an English actress, writer and journalist. She played " +
                "Molly Hooper in Sherlock, Cass in Back with David Mitchell and Robert Webb, Scottish professor Jude McDermid in Clique, Gillian Chamberlain in A Discovery of Witches " +
                "and Donna Harman in Death in Paradise.", 4, "https://www.imdb.com/name/nm1154764/");

            Staff mGatiss = new Staff("Mark", "Gatiss", new DateTime(1966, 11, 17), "Producer");

            List<Actor> sherlockCast = new List<Actor>();
            sherlockCast.Add(bCumberbatch);
            sherlockCast.Add(mFreeman);
            sherlockCast.Add(aScott);
            sherlockCast.Add(lBrealey);

            List<Staff> sherlockProd = new List<Staff>();
            sherlockProd.Add(mGatiss);

            CastList sherlockCastList = new CastList(sherlockCast);
            ProdList sherlockProdList = new ProdList(sherlockProd);

            Show sherlock = new Show("Sherlock", "sherlock_poster", "Detective", 2010, sherlockCastList, sherlockProdList, bbc, "Thursday, 9PM", "Sherlock depicts consulting detective Sherlock Holmes(Benedict Cumberbatch) solving various " +
                "mysteries in modern - day London.Holmes is assisted by his flatmate and friend, Dr.John Watson(Martin Freeman), who has returned from military " +
                "service in Afghanistan with the Royal Army Medical Corps.Although Metropolitan Police Service Detective Inspector Greg Lestrade(Rupert Graves) and others " +
                "are suspicious of Holmes at first, over time, his exceptional intellect and bold powers of observation persuade them of his value.", 5);
            //-------------------------------------------


            //WATCHMEN-----------------------------------
            Actor rKing = new Actor("Regina", "King", new DateTime(1971, 1, 15), "Main Role", "Regina King was born on January 15, 1971 in Los Angeles, California. She is best known " +
                "for her role as Mary Jenkins's (played by Marla Gibbs) studious daughter, Brenda Jenkins, on the popular 1980s sitcom, 227 and for her critically-acclaimed supporting" +
                " role in the feature film Jerry Maguire.", 4, "https://www.imdb.com/name/nm0005093/");

            Actor jIrons = new Actor("Jeremy", "Irons", new DateTime(1948, 9, 19), "Secondary Role", "Jeremy John Irons is an English actor. After receiving " +
                "classical training at the Bristol Old Vic Theatre School, Irons began his acting career on stage in 1969 and has since appeared in many West End theatre productions, " +
                "including The Winter's Tale, Macbeth, Much Ado About Nothing, The Taming of the Shrew, Godspell, Richard II, and Embers. In 1984, he made his Broadway debut in Tom Stoppard's" +
                " The Real Thing and received a Tony Award for Best Actor.", 3, "https://www.imdb.com/name/nm0000460/");

            Actor dJohnson = new Actor("Don", "Johnson", new DateTime(1949, 12, 15), "Secondary Role", "Donnie Wayne Johnson (born December 15, 1949) is an American actor, producer, director, " +
                "singer, and songwriter.[1] He played the role of James Sonny Crockett in the 1980s television series Miami Vice, winning a Golden Globe for his work in the role. He also had" +
                " the eponymous lead role in the 1990s cop series Nash Bridges. He has received a star on the Hollywood Walk of Fame.[2] Johnson was the American Power Boat Association's 1988 World" +
                " Champion of the Offshore World Cup.[3]", 5, "https://www.imdb.com/name/nm0000467/");

            Staff dLindelof = new Staff("Damon", "Lindelof", new DateTime(1973, 4, 24), "Producer");

            List<Actor> watchmenCast = new List<Actor>();
            watchmenCast.Add(rKing);
            watchmenCast.Add(jIrons);
            watchmenCast.Add(dJohnson);

            List<Staff> watchmenProd = new List<Staff>();
            watchmenProd.Add(dLindelof);

            CastList watchmenCastList = new CastList(watchmenCast);
            ProdList watchmenProdList = new ProdList(watchmenProd);

            Show watchmen = new Show("Watchmen", "watchmen_poster", "Super Heroes", 2019, watchmenCastList, watchmenProdList, hbo, "Monday, 10AM", "Watchmen takes place 34 years after " +
                "the events of the comic series.Set in the comic's alternate history of the 20th century, vigilantes, once seen as heroes, have been outlawed due to their violent methods. " +
                "In 1985, Adrian Veidt, formerly known as the vigilante Ozymandias, created a fake attack on New York City by a squid-like alien that resulted in millions within New York " +
                "being killed, coercing nations to work together against a common threat and to avert a nuclear holocaust. Veidt's actions disgusted his former companions, with Rorschach " +
                "planning to tell the world of Veidt's misdeeds before he is vaporized by Doctor Manhattan, who subsequently left the planet, unaware Rorschach had sent his journal to be " +
                "published beforehand.", 4);
            //--------------------------------------------

            //VIKING--------------------------------------
            Actor kWinnick = new Actor("Katheryn", "Winnick", new DateTime(1977, 12, 17), "Main Role", "Winnick has appeared in many films, including Stand Up Guys, Failure to Launch, Love & " +
                "Other Drugs, and Killers. She has guest-starred in numerous television shows, most notably House,[7] The Glades, Bones, Law & Order, Law & Order: Criminal Intent, CSI, CSI: NY, " +
                "CSI: Miami, Criminal Minds, Person of Interest, and Nikita. In her role on Bones, she portrays Hannah Burley, a war correspondent who had been posted to cover the war in " +
                "Afghanistan and becomes a love interest for main character Seeley Booth.", 4, "https://www.imdb.com/name/nm0935395/");

            Actor tFimmel = new Actor("Travis", "Fimmel", new DateTime(1979, 7, 15), "Main Role", "Fimmel studied under Hollywood acting coach Ivana Chubbuck, taking two years to pluck up the " +
                "courage to audition for his first role, saying half of acting is overcoming your fears letting yourself be vulnerable in front of people. He landed the title lead in Warner Bros. " +
                "2003 TV series Tarzan, described by CNN as one of the five hottest things happening in entertainment right now, in which he did most of his own stunts. In addition, " +
                "he appeared in the studio's pilot Rocky Point with Lauren Holly in 2005, the Fox film Southern Comfort with Madeleine Stowe in 2006 and The Big Valley with Richard Dreyfuss and Jessica" +
                " Lange in 2011.", 5, "https://www.imdb.com/name/nm1379938/");

            Actor aLudwig = new Actor("Alexander", "Ludwig", new DateTime(1992, 5, 7), "Secondary Role", "Ludwig began his career at the age of nine when he featured in a Harry Potter toy commercial, a job " +
                "that enabled him to sign on with an agent and obtain more commercial work. Later he was cast in movies such as Air Bud: World Pup (2000), MXP: Most Extreme Primate (2003), Scary Godmother: " +
                "The Revenge of Jimmy (2005), Eve and the Fire Horse (2005), The Sandlot: Heading Home (also known as The Sandlot 3) (2007). In addition to cinema, Ludwig has also worked in television. He has " +
                "performed in movies made for television, such as A Little Thing Called Murder (2006), and television series such as The Dead Zone.[1] Ludwig obtained his leading role in The Seeker: The Dark Is " +
                "Rising (2007) after a \"gruelling audition process.\"By his count, he had 16 auditions before finally being cast.", 4, "https://www.imdb.com/name/nm1573253/");

            Actor gSkarsgard = new Actor("Gustaf", "Skarsgard", new DateTime(1980, 11, 12), "Secondary Role", "Gustaf Skarsgård was born in Stockholm, Sweden, to Swedish actor Stellan Skarsgård and his first wife, " +
                "My, a physician. He has five siblings: Alexander, Sam, Bill, Eija and Valter, and two half-brothers Ossian and Kolbjörn from his father's second wife, Megan Everett.[1] Alexander, Bill, and Valter " +
                "are also actors. His godfather is Swedish actor Peter Stormare.", 4, "https://www.imdb.com/name/nm0803890/");

            Staff mHirst = new Staff("Michael", "Hirst", new DateTime(1952, 9, 21), "Producer");
            Staff aMarshall = new Staff("Aaron", "Marshall", new DateTime(1987, 5, 14), "Editor");
            Staff tSeaborn = new Staff("Tad", "Seaborn", new DateTime(1966, 7, 18), "Editor");

            List <Actor> vikingsCast = new List<Actor>();
            vikingsCast.Add(kWinnick);
            vikingsCast.Add(tFimmel);
            vikingsCast.Add(aLudwig);
            vikingsCast.Add(gSkarsgard);

            List<Staff> vikingsProd = new List<Staff>();
            vikingsProd.Add(mHirst);
            vikingsProd.Add(aMarshall);
            vikingsProd.Add(tSeaborn);

            CastList vikingsCastList = new CastList(vikingsCast);
            ProdList vikingProdList = new ProdList(vikingsProd);

            Show vikings = new Show("Vikings", "vikings_poster", "Action", 2013, vikingsCastList, vikingProdList, history, "Saturday, 5PM", "The series is inspired by the tales of the Norsemen of early medieval " +
                "Scandinavia.It broadly follows the exploits of the legendary Viking chieftain Ragnar Lothbrok and his crew, family and descendants, as notably laid down in the 13th - century sagas Ragnars saga " +
                "Loðbrókar and Ragnarssona þáttr, as well as in Saxo Grammaticus's 12th-century work Gesta Danorum. Norse legendary sagas were partially fictional tales based in the Norse oral tradition, written " +
                "down about 200 to 400 years after the events they describe. Further inspiration is taken from historical sources of the period, such as records of the Viking raid on Lindisfarne depicted in the " +
                "second episode, or Ahmad ibn Fadlan's 10th - century account of the Varangians.The series begins at the start of the Viking Age, marked by the Lindisfarne raid in 793.", 4);
            //--------------------------------------------

            //PUNISHER------------------------------------
            Actor jBernthal = new Actor("Jon", "Bernthal", new DateTime(1976, 9, 20), "Main Role", "Jonathan Edward Bernthal is an American actor. Bernthal began his " +
                "career in theater before guest starring on various television shows. He gained critical acclaim and prominence for his portrayal of Shane Walsh on the AMC series The Walking Dead (2010–2012; 2018). " +
                "He later starred in supporting and leading roles in various critically acclaimed films including The Wolf of Wall Street (2013), Fury (2014), Sicario (2015), The Accountant (2016), Baby Driver, Wind " +
                "River (both 2017), Widows (2018), and Ford v Ferrari (2019). In 2015, he was cast as Frank Castle / Punisher as part of the Netflix MCU web series.He debuted on Daredevil before starring in his own " +
                "titular series The Punisher(2017–2019).", 5, "https://www.imdb.com/name/nm1256532/");

            Actor bBarnes = new Actor("Ben", "Barnes", new DateTime(1981, 8, 20), "Main Role", "Benjamin Thomas Barnes (born 20 August 1981) is an English actor and singer. He is best known for his roles as Prince Caspian in " +
                "The Chronicles of Narnia film series, Logan Delos in Westworld, and Billy Russo in The Punisher. He is set to star in the upcoming Netflix series Shadow and Bone. He has also played Tom Ward in the fantasy " +
                "film Seventh Son, the titular role in Dorian Gray, supporting roles in The Words and The Big Wedding, Samuel Adams in the 2015 miniseries Sons of Liberty, and Benjamin Greene in 2019 miniseries " +
                "Gold Digger.", 4, "https://www.imdb.com/name/nm1602660/");

            Staff sLightfoot = new Staff("Steve", "Lightfoot", new DateTime(1976, 11, 11), "Creator");
            Staff tBates = new Staff("Tyler", "Bates", new DateTime(1988, 10, 2), "Composer");

            List<Actor> punisherCast = new List<Actor>();
            punisherCast.Add(jBernthal);
            punisherCast.Add(bBarnes);

            List<Staff> punisherProd = new List<Staff>();
            punisherProd.Add(sLightfoot);
            punisherProd.Add(tBates);

            CastList punisherCastList = new CastList(punisherCast);
            ProdList punisherProdList = new ProdList(punisherProd);

            Show punisher = new Show("The Punisher", "punisher_poster", "Action", 2017, punisherCastList, punisherProdList, hbo, "Tuesday, 9:15PM", "After exacting revenge on those responsible for the death of his family " +
                "(see second season of Daredevil), the first season finds former Force Recon Marine Frank Castle, known throughout New York City as \"the Punisher\", uncovering a larger conspiracy beyond what was done to him " +
                "and his family. The second season sees Castle, who has been living a quiet life on the road, drawn into the mystery surrounding the attempted murder of Amy Bendix, forcing him to decide if he should embrace " +
                "his life as the Punisher.", 5);
            //--------------------------------------------

            //ARROW---------------------------------------
            Actor sAmell = new Actor("Stephen", "Amell", new DateTime(1981, 5, 8), "Main Role", "Stephen Adam Amell (born May 8, 1981) is a Canadian actor and producer, best known for playing Oliver Queen / Green Arrow on " +
                "The CW superhero series Arrow, the show that started the Arrowverse. A lifelong professional wrestling fan, he has made appearances in major professional wrestling promotions, including working a match for WWE " +
                "in 2015 and for Ring of Honor in 2017, joining the stable Bullet Club and later The Elite.", 4, "https://www.imdb.com/name/nm1854386/");

            Actor kCassidy = new Actor("Katie", "Cassidy", new DateTime(1986, 11, 25), "Main Role", "Katherine Evelyn Anita Cassidy (born November 25, 1986) is an American actress and director. Following several minor " +
                "television roles, she came to attention as a scream queen after starring in the horror films When a Stranger Calls (2006), as Kelli Presley in Black Christmas (2006) and as Ruby in the third season of the " +
                "horror series Supernatural (2007–08). Following a supporting role in the action film Taken (2008), Cassidy played leading roles in the mystery horror series Harper's Island (2009) and the remake of the " +
                "drama series Melrose Place (2009–10). She starred as Kris Fowles in the slasher film remake A Nightmare on Elm Street (2010) and had a recurring role as Juliet Sharp during the fourth season of " +
                "the teen drama Gossip Girl (2010–12).", 5, "https://www.imdb.com/name/nm1556320/");

            Staff wMericle = new Staff("Wendy", "Mericle", new DateTime(1991, 1, 11), "Producer");
            Staff mGuggenheim = new Staff("Marc", "Guggenheim", new DateTime(1971, 2, 14), "Co-Producer");
            Staff bNeely = new Staff("Blake", "Neely", new DateTime(1965, 4, 28), "Musics");

            List<Actor> arrowCast = new List<Actor>();
            arrowCast.Add(sAmell);
            arrowCast.Add(kCassidy);

            List<Staff> arrowProd = new List<Staff>();
            arrowProd.Add(wMericle);
            arrowProd.Add(mGuggenheim);
            arrowProd.Add(bNeely);

            CastList arrowCastList = new CastList(arrowCast);
            ProdList arrowProdList = new ProdList(arrowProd);

            Show arrow = new Show("Arrow", "arrow_poster", "Heroes", 2012, arrowCastList, arrowProdList, theCW, "Wednesday, 9PM", "Following a shipwreck, Oliver Queen, a young playboy billionaire, disappears at sea with his father " +
                "and his girlfriend. Found alive five years later on an island near the Chinese coast, he returns home transformed to Starling City with a mission: to honor the memory of his father and rid the city of its thugs. " +
                "With John Diggle, his bodyguard, and Felicity Smoak, a computer geek, Oliver secretly leads a ruthless war against crime.", 4);
            //--------------------------------------------

            //HOUSE OF CARDS------------------------------
            Actor kSpacey = new Actor("Kevin", "Spacey", new DateTime(1959, 7, 26), "Main Role", "Kevin Spacey Fowler KBE (born July 26, 1959) is an American actor, producer, and singer. Spacey began his career as a stage actor " +
                "during the 1980s, obtaining supporting roles in film and television. He gained critical acclaim in the 1990s that culminated in his first Academy Award for Best Supporting Actor for the neo-noir crime thriller " +
                "The Usual Suspects (1995) and an Academy Award for Best Actor for the midlife crisis-themed drama American Beauty (1999).", 5, "https://www.imdb.com/name/nm0000228/");

            Actor rWright = new Actor("Robin", "Wright", new DateTime(1966, 4, 8), "Main Role", "Robin Gayle Wright (born April 8, 1966) is an American actress and director. She is the recipient of eight Primetime Emmy Award " +
                "nominations and has earned a Golden Globe Award and a Satellite Award for her work in television. Wright first gained attention for her role in the NBC Daytime soap opera Santa Barbara, as Kelly Capwell from " +
                "1984 to 1988.She then made the transition to film, starring in the romantic comedy fantasy adventure film The Princess Bride(1987).This role led Wright to further success in the film industry, with starring " +
                "roles in films such as Forrest Gump(1994).", 5, "https://www.imdb.com/name/nm0000705/");

            Actor mKelly = new Actor("Michael", "Kelly", new DateTime(1969, 5, 22), "Secondary Role", "Michael Joseph Kelly Jr. (born May 22, 1969) is an American actor. He is best known for his role as Doug Stamper in House " +
                "of Cards, as well as for roles in films such as Changeling, Dawn of the Dead, The Adjustment Bureau, Chronicle, Now You See Me, and Everest. He also appeared in the television miniseries Generation Kill, " +
                "six episodes of The Sopranos as Agent Ron Goddard,[1] the Criminal Minds spin-off series Criminal Minds: Suspect Behavior, and as Dr. Edgar Dumbarton in Taboo.", 3, "https://www.imdb.com/name/nm0446672/");

            Staff bWillimon = new Staff("Beau", "Willimon", new DateTime(1982, 11, 2), "Creator");
            Staff dFincher = new Staff("David", "Fincher", new DateTime(1967, 11, 6), "Producer");
            Staff eBryld = new Staff("Eigil", "Bryld", new DateTime(1972, 12, 12), "Cinematography");

            List<Actor> houseofcardsCast = new List<Actor>();
            houseofcardsCast.Add(kSpacey);
            houseofcardsCast.Add(rWright);
            houseofcardsCast.Add(mKelly);

            List<Staff> houseofcardsProd = new List<Staff>();
            houseofcardsProd.Add(bWillimon);
            houseofcardsProd.Add(dFincher);
            houseofcardsProd.Add(eBryld);

            CastList houseofcardsCastList = new CastList(houseofcardsCast);
            ProdList houseofcardsProdList = new ProdList(houseofcardsProd);

            Show houseofcards = new Show("House of Cards", "houseofcards_poster", "Political Drama", 2014, houseofcardsCastList, houseofcardsProdList, hbo, "Monday, 1PM", "House of Cards is an American political thriller web " +
                "television series created by Beau Willimon. It is an adaptation of the 1990 BBC miniseries of the same title and based on the novel of the same title by Michael Dobbs. The first 13-episode season was released " +
                "on February 1, 2013. House of Cards is set in Washington, D.C.and is the story of Congressman Frank Underwood(Kevin Spacey), a Democrat from South Carolina's 5th congressional district and House Majority Whip, " +
                "and his equally ambitious wife Claire Underwood (Robin Wright).", 3);
            //--------------------------------------------


            //ONE PUNCH MAN-------------------------------
            Actor mFurukawa = new Actor("Makoto", "Furukawa", new DateTime(1989, 9, 29), "Main Role", "Makoto Furukawa (古川 慎, Furukawa Makoto, born September 29, 1989) is a Japanese voice actor and singer previously " +
                "affiliated with Space Craft Entertainment. He became a freelancer in September 2018.[1] He joined the record label, Toy's Factory, in December 2018.[2] He made his solo singer debut under Lantis in July " +
                "2018 with the song \"miserable masquerade\" produced by Satoru Kuwabara. He played Saitama in One-Punch Man and Banri Tada in Golden Time.", 5, "https://www.imdb.com/name/nm4646711/");

            Actor kIshikawa = new Actor("Kaito", "Ishikawa", new DateTime(1993, 10, 3), "Secondary Role", "Kaito Ishikawa(石川 界人, Ishikawa Kaito), born October 13, 1993 in Tokyo, is a Japanese actor.", 5, 
                "https://www.imdb.com/name/nm5481013/");

            Staff tSuzuki = new Staff("Tomohiro", "Suzuki", new DateTime(1978, 11, 11), "Writter");
            Staff cMatsui = new Staff("Chinatsu", "Matsuhi", new DateTime(1982, 12, 4), "Producer");

            List<Actor> onepunchmanCast = new List<Actor>();
            onepunchmanCast.Add(mFurukawa);
            onepunchmanCast.Add(kIshikawa);

            List<Staff> onepunchmanProd = new List<Staff>();
            onepunchmanProd.Add(tSuzuki);
            onepunchmanProd.Add(cMatsui);

            CastList onepunchmanCastList = new CastList(onepunchmanCast);
            ProdList onepunchmanProdList = new ProdList(onepunchmanProd);

            Show onepunchman = new Show("One Punch Man", "onepunchman_poster", "Heroes", 2012, onepunchmanCastList, onepunchmanProdList, tvtokyo, "Sunday, 9AM", "On an unnamed Earth-like supercontinent planet, " +
                "powerful monsters and villains have been wreaking havoc in the cities. To combat them, the millionaire Agoni creates the Hero Association, which employs superheroes to stop them. Saitama, an" +
                " unassociated hero, hails from the metropolis of City-Z and performs heroic deeds for his own entertainment. He has trained himself to the point where he can effortlessly defeat any opponent with " +
                "a single punch, but becomes bored with his own omnipotence.", 5);

            //--------------------------------------------


            //FATE STAY NIGHT-----------------------------
            Actor aKawasumi = new Actor("Ayako", "Kawasumi", new DateTime(1976, 3, 14), "Main Role", "Ayako Kawasumi is a seiyū, having started in 1997. She has participated as a voice actress in more than a hundred " +
                "anime series, and in about fifty video games.", 4, "https://www.imdb.com/name/nm0442933/");

            Actor jSuwabe = new Actor("Juichi", "Suwabe", new DateTime(1972, 3, 19), "Secondary", "Junichi Suwabe (諏訪部 順一, Suwabe Jun'ichi, born March 29, 1972) is a Japanese voice actor and singer from Tokyo. He " +
                "is affiliated with Haikyō. His popular roles include Keigo Atobe in The Prince of Tennis, Victor Nikiforov in Yuri!!! on ICE, Grimmjow Jaegerjaquez in Bleach, Yami Sukehiro in Black Clover, Archer in " +
                "Fate/stay night, Ren Jinguji in Uta no Prince-sama, Undertaker in Black Butler, Leone Abbacchio in JoJo's Bizarre Adventure: Golden Wind, Daiki Aomine in Kuroko's Basketball, Shōta Aizawa in My Hero " +
                "Academia, Takashi Komuro in Highschool of the Dead and Dandy in Space Dandy. He was nominated for a Best Singing Award at the 6th Seiyu Awards, and received a Best Supporting Actor award " +
                "at the 7th Seiyu Awards.", 5, "https://www.imdb.com/name/nm1146347/");

            Staff yYamaguchi = new Staff("Yuji", "Yamaguchi", new DateTime(1978, 12, 13), "Director");

            List<Actor> fatestaynightCast = new List<Actor>();
            fatestaynightCast.Add(aKawasumi);
            fatestaynightCast.Add(jSuwabe);

            List<Staff> fatestaynightProd = new List<Staff>();
            fatestaynightProd.Add(yYamaguchi);

            CastList fatestaynightCastList = new CastList(fatestaynightCast);
            ProdList fatestaynightProdList = new ProdList(fatestaynightProd);

            Show fatestaynight = new Show("Fate Stay Night", "fatestaynight_poster", "Action", 2014, fatestaynightCastList, fatestaynightProdList, tvtokyo, "Tuesday, 6PM", "The story revolves around Shirou Emiya, a " +
                "hardworking and honest teenager who unwillingly enters the fifth iteration of a to-the-death battle royale called the Holy Grail War, where combatants fight with magic and Heroes throughout history " +
                "for a chance to have their wishes granted. Orphaned and the sole survivor of a massive fire in Fuyuki City as a child, Shirou was taken in by a retired magus named Kiritsugu Emiya, who died some " +
                "years later. Shirou's feelings of responsibility for those who died and his own salvation through his father formed a strong desire for justice and peace in him. Thus, he earnestly trains his body " +
                "and minuscule ability with magic with the goal of helping others, even if people often abuse his generosity.", 5);
            //--------------------------------------------


            //THE 100-------------------------------------
            Actor eTaylor = new Actor("Eliza", "Taylor", new DateTime(1989, 10, 24), "Main Role", "Eliza Jane Taylor-Cotter Morley (born 24 October 1989), known professionally as Eliza Taylor, is an Australian actress." +
                " She is best known for her roles as Janae Timmins on the Australian soap opera Neighbours (2005–08) and Clarke Griffin on The CW drama series The 100 (2014–present).", 4, "https://www.imdb.com/name/nm1343638/");

            Actor pTurco = new Actor("Paige", "Turco", new DateTime(1965, 5, 17), "Main Role", "Jean Paige Turco (born May 17, 1965) is an American actress, best known for her role as April O'Neil in Teenage Mutant Ninja " +
                "Turtles II: The Secret of the Ooze and Teenage Mutant Ninja Turtles III.[1] Other notable roles include Melanie Cortlandt on the ABC soap opera All My Children, Terri Lowell in the CBS series The Agency, " +
                "and appearances in American Gothic, NYPD Blue, Party of Five and Person of Interest. From 2014 to 2019 she starred as Abigail Griffin in the post-apocalyptic drama series, The 100.", 3, "https://www.imdb.com/name/nm0876958/");

            Staff jRothenberg = new Staff("Jason", "Rothenberg", new DateTime(1967, 10, 15), "Producer");

            List<Actor> the100cast = new List<Actor>();
            the100cast.Add(eTaylor);
            the100cast.Add(pTurco);

            List<Staff> the100prod = new List<Staff>();
            the100prod.Add(jRothenberg);

            CastList the100castList = new CastList(the100cast);
            ProdList the100prodList = new ProdList(the100prod);

            Show the100 = new Show("The 100", "the100_poster", "Survival", 2016, the100castList, the100prodList, hbo, "Monday, 10PM", "The series follows a group of post-apocalyptic survivors, chiefly a group of criminal adolescents, " +
                "including Clarke Griffin (Eliza Taylor), Finn Collins (Thomas McDonell), Bellamy Blake (Bob Morley), Octavia Blake (Marie Avgeropoulos), Jasper Jordan (Devon Bostick), Monty Green (Christopher Larkin), Raven Reyes " +
                "(Lindsey Morgan), John Murphy (Richard Harmon), and Wells Jaha (Eli Goree). They are among the first people from a space habitat, the Ark, to return to Earth after a devastating nuclear apocalypse. Other lead characters" +
                "include Dr. Abby Griffin (Paige Turco), Clarke's mother; Marcus Kane (Henry Ian Cusick), a council member on the Ark; and Thelonious Jaha (Isaiah Washington), the Chancellor of the Ark and Wells's father.", 4);
            //--------------------------------------------

            //

            //MUST WATCH
            showToDisplay.Add(sherlock);
            showToDisplay.Add(watchmen);
            showToDisplay.Add(vikings);
            showToDisplay.Add(punisher);
            showToDisplay.Add(onepunchman);

            //ALL THE SHOWS
            allTheShows.Add(arrow);
            allTheShows.Add(houseofcards);
            allTheShows.Add(onepunchman);
            allTheShows.Add(vikings);
            allTheShows.Add(watchmen);
            allTheShows.Add(sherlock);
            allTheShows.Add(punisher);
            allTheShows.Add(fatestaynight);
            allTheShows.Add(the100);



            //CREATE SHOW TILES ON THE HOMEPAGE
            foreach (Show s in showToDisplay)
            {
                //STACKPANNEL
                StackPanel stp = new StackPanel();
                    stp.Name = s.Title;
                    stp.Tapped += new TappedEventHandler(ShowTile_Tapped);
                    stp.Height = 170;
                    stp.Width = 90;
                    stp.Background = new SolidColorBrush(Colors.White);
                    stp.Margin = new Thickness(0, 0, 10, 0);

                //IMAGE
                Image img = new Image();
                BitmapImage imgSrc = new BitmapImage();
                    imgSrc.UriSource = new Uri("ms-appx:///Images/" + s.ShowImage + ".jpg");

                img.Source = imgSrc;

                //TEXTBLOCK
                TextBlock txt = new TextBlock();
                    txt.Text = s.Title;
                    txt.Foreground = new SolidColorBrush(Colors.Black);
                    txt.FontSize = 9;
                    txt.Margin = new Thickness(5, 5, 0, 0);

                //STAR CONTAINERS
                StackPanel stpStars = new StackPanel();
                    stpStars.Orientation = Orientation.Horizontal;
                    stpStars.Margin = new Thickness(5, 3, 0, 0);
                    stpStars.HorizontalAlignment = HorizontalAlignment.Left;

                //STARS
                for(int i=0 ; i<5 ; i++)
                {
                    Image star = new Image();
                        star.Height = 9;
                        star.Margin = new Thickness(0, 0, 4, 0);

                    BitmapImage starSrc = new BitmapImage();

                    if (i < s.Rating)
                    {
                        starSrc.UriSource = new Uri("ms-appx:///Images/star_full.png");
                        star.Source = starSrc;
                        stpStars.Children.Add(star);
                    }
                    else
                    {
                        starSrc.UriSource = new Uri("ms-appx:///Images/star_empty.png");
                        star.Source = starSrc;
                        stpStars.Children.Add(star);
                    }
                }

                //APPEND COMPONENTS
                stp.Children.Add(img);
                stp.Children.Add(txt);
                stp.Children.Add(stpStars);

                mustWatchSection.Children.Add(stp);
            }

            foreach (Show s in allTheShows)
            {
                //STACKPANNEL
                StackPanel stp = new StackPanel();
                stp.Name = s.Title;
                stp.Tapped += new TappedEventHandler(ShowTile_Tapped);
                stp.Height = 170;
                stp.Width = 90;
                stp.Background = new SolidColorBrush(Colors.White);
                stp.Margin = new Thickness(6.5, 6.5, 6.5, 6.5);

                //IMAGE
                Image img = new Image();
                BitmapImage imgSrc = new BitmapImage();
                imgSrc.UriSource = new Uri("ms-appx:///Images/" + s.ShowImage + ".jpg");

                img.Source = imgSrc;

                //TEXTBLOCK
                TextBlock txt = new TextBlock();
                txt.Text = s.Title;
                txt.Foreground = new SolidColorBrush(Colors.Black);
                txt.FontSize = 9;
                txt.Margin = new Thickness(5, 5, 0, 0);

                //STAR CONTAINERS
                StackPanel stpStars = new StackPanel();
                stpStars.Orientation = Orientation.Horizontal;
                stpStars.Margin = new Thickness(5, 3, 0, 0);
                stpStars.HorizontalAlignment = HorizontalAlignment.Left;

                //STARS
                for (int i = 0; i < 5; i++)
                {
                    Image star = new Image();
                    star.Height = 9;
                    star.Margin = new Thickness(0, 0, 4, 0);

                    BitmapImage starSrc = new BitmapImage();

                    if (i < s.Rating)
                    {
                        starSrc.UriSource = new Uri("ms-appx:///Images/star_full.png");
                        star.Source = starSrc;
                        stpStars.Children.Add(star);
                    }
                    else
                    {
                        starSrc.UriSource = new Uri("ms-appx:///Images/star_empty.png");
                        star.Source = starSrc;
                        stpStars.Children.Add(star);
                    }
                }


                //APPEND COMPONENTS
                stp.Children.Add(img);
                stp.Children.Add(txt);
                stp.Children.Add(stpStars);

                allShowsSection.Children.Add(stp);
            }

        }

        private void ShowTile_Tapped(object sender, TappedRoutedEventArgs e)
        {

            StackPanel clickedShow = sender as StackPanel;
            DependencyObject showTitleContainer = VisualTreeHelper.GetChild(clickedShow, 1);
            TextBlock showName = showTitleContainer as TextBlock;

            string showNameToFind = showName.Text;

            Show tmpShow = allTheShows.Find(x => x.Title == showNameToFind);

            var showParameters = new ShowParams();
            showParameters.Title = tmpShow.Title;
            showParameters.ShowImage = tmpShow.ShowImage;
            showParameters.Genre = tmpShow.Genre;
            showParameters.Synopsis = tmpShow.Synopsis;
            showParameters.CastList = tmpShow.CastList;
            showParameters.ProdList = tmpShow.ProdList;
            showParameters.YearOfShow = tmpShow.YearOfShow;
            showParameters.Channel = tmpShow.Channel;
            showParameters.ScreeningTime = tmpShow.ScreeningTime;
                
            Frame.Navigate(typeof(FilmPage), showParameters);
        }
    }
}

