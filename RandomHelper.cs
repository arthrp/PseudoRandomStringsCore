using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RandomHelper 
{
    #region Data
    private const string ALPHANUMERIC_CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    private readonly List<string> TWO_CHAR_DOMAINS = new List<string>(){ ".ac",".ad",".ae",".af",".ag",".ai",".al",".am",".an",".ao",
        ".aq",".ar",".as",".at",".au",".aw",".ax",".az",".ba",".bb",".bd",".be",".bf",".bg",".bh",".bi",".bj",".bl",".bm",".bn",".bo",
        ".bq",".br",".bs",".bt",".bv",".bw",".by",".bz",".ca",".cc",".cd",".cf",".cg",".ch",".ci",".ck",".cl",".cm",".cn",".co",".cr",
        ".cu",".cv",".cw",".cx",".cy",".cz",".de",".dj",".dk",".dm",".do",".dz",".ec",".ee",".eg",".eh",".er",".es",".et",".eu",".fi",
        ".fj",".fk",".fm",".fo",".fr",".ga",".gb",".gd",".ge",".gf",".gg",".gh",".gi",".gl",".gm",".gn",".gp",".gq",".gr",".gs",".gt",
        ".gu",".gw",".gy",".hk",".hm",".hn",".hr",".ht",".hu",".id",".ie",".il",".im",".in",".io",".iq",".ir",".is",".it",".je",".jm",
        ".jo",".jp",".ke",".kg",".kh",".ki",".km",".kn",".kp",".kr",".kw",".ky",".kz",".la",".lb",".lc",".li",".lk",".lr",".ls",".lt",
        ".lu",".lv",".ly",".ma",".mc",".md",".me",".mf",".mg",".mh",".mk",".ml",".mm",".mn",".mo",".mp",".mq",".mr",".ms",".mt",".mu",
        ".mv",".mw",".mx",".my",".mz",".na",".nc",".ne",".nf",".ng",".ni",".nl",".no",".np",".nr",".nu",".nz",".om",".pa",".pe",".pf",
        ".pg",".ph",".pk",".pl",".pm",".pn",".pr",".ps",".pt",".pw",".py",".qa",".re",".ro",".rs",".ru",".rw",".sa",".sb",".sc",".sd",
        ".se",".sg",".sh",".si",".sj",".sk",".sl",".sm",".sn",".so",".sr",".ss",".st",".su",".sv",".sx",".sy",".sz",".tc",".td",".tf",
        ".tg",".th",".tj",".tk",".tl",".tm",".tn",".to",".tp",".tr",".tt",".tv",".tw",".tz",".ua",".ug",".uk",".um",".us",".uy",".uz",
        ".va",".vc",".ve",".vg",".vi",".vn",".vu",".wf",".ws",".ye",".yt",".za",".zm",".zw" };
    private readonly List<string> MALE_FIRST_NAMES = new List<string>() {"Jacob","Michael","Joshua","Matthew","Ethan","Andrew","Daniel",
    "Anthony","Christopher","Joseph","William","Alexander","Ryan","David","Nicholas","Tyler","James","John","Jonathan","Nathan","Samuel",
    "Christian","Noah","Dylan","Benjamin","Logan","Brandon","Gabriel","Zachary","Jose","Elijah","Angel","Kevin","Jack","Caleb","Justin",
    "Austin","Evan","Robert","Thomas","Luke","Mason","Aidan","Jackson","Isaiah","Jordan","Gavin","Connor","Aiden","Isaac","Jason",
    "Cameron","Hunter","Jayden","Juan","Charles","Aaron","Lucas","Luis","Owen","Landon","Diego","Brian","Adam","Adrian","Kyle",
    "Eric","Ian","Nathaniel","Carlos","Alex","Bryan","Jesus","Julian","Sean","Carter","Hayden","Jeremiah","Cole","Brayden","Wyatt",
    "Chase","Steven","Timothy","Dominic","Sebastian","Xavier","Jaden","Jesse","Devin","Seth","Antonio","Richard","Miguel","Colin","Cody",
    "Alejandro","Caden","Blake","Carson","Kaden","Jake","Henry","Liam","Victor","Riley","Ashton","Patrick","Bryce","Brady","Vincent",
    "Trevor","Tristan","Mark","Jeremy","Oscar","Marcus","Jorge","Parker","Kaleb","Cooper","Kenneth","Garrett","Joel","Ivan","Josiah",
    "Alan","Conner","Eduardo","Paul","Tanner","Braden","Alexis","Edward","Omar","Nicolas","Jared","Peyton","George","Maxwell","Cristian",
    "Francisco","Collin","Nolan","Preston","Stephen","Ayden","Gage","Levi","Dakota","Micah","Eli","Manuel","Grant","Colton","Damian",
    "Ricardo","Giovanni","Andres","Emmanuel","Peter","Malachi","Cesar","Javier","Max","Hector","Edgar","Shane","Fernando","Ty","Jeffrey",
    "Bradley","Derek","Travis","Brendan","Shawn","Edwin","Spencer","Mario","Dalton","Erick","Johnathan","Erik","Jonah","Donovan",
    "Leonardo","Wesley","Elias","Marco","Trenton","Devon","Brody","Abraham","Jaylen","Bryson","Josue","Sergio","Drew","Damien","Raymond",
    "Andy","Dillon","Gregory","Roberto","Roman","Martin","Andre","Jace","Oliver","Miles","Harrison","Jalen","Corey","Dominick","Avery",
    "Clayton","Pedro","Israel","Calvin","Colby","Dawson","Cayden","Jaiden","Taylor","Landen","Troy","Julio","Trey","Jaxon","Rafael",
    "Dustin","Ruben","Camden","Frank","Scott","Mitchell","Zane","Payton","Kai","Keegan","Skyler","Brett","Johnny","Griffin","Marcos",
    "Derrick","Drake","Raul","Kaiden","Gerardo" };
    private readonly List<string> FEMALE_FIRST_NAMES = new List<string>() {
        "Emily","Emma","Madison","Abigail","Olivia","Isabella","Hannah","Samantha","Ava","Ashley","Sophia","Elizabeth","Alexis",
        "Grace","Sarah","Alyssa","Mia","Natalie","Chloe","Brianna","Lauren","Ella","Anna","Taylor","Kayla","Hailey","Jessica",
        "Victoria","Jasmine","Sydney","Julia","Destiny","Morgan","Kaitlyn","Savannah","Katherine","Alexandra","Rachel","Lily",
        "Megan","Kaylee","Jennifer","Angelina","Makayla","Allison","Brooke","Maria","Trinity","Lillian","Mackenzie","Faith",
        "Sofia","Riley","Haley","Gabrielle","Nicole","Kylie","Katelyn","Zoe","Paige","Gabriella","Jenna","Kimberly","Stephanie",
        "Alexa","Avery","Andrea","Leah","Madeline","Nevaeh","Evelyn","Maya","Mary","Michelle","Jada","Sara","Audrey","Brooklyn",
        "Vanessa","Amanda","Ariana","Rebecca","Caroline","Amelia","Mariah","Jordan","Jocelyn","Arianna","Isabel","Marissa","Autumn",
        "Melanie","Aaliyah","Gracie","Claire","Isabelle","Molly","Mya","Diana","Katie","Leslie","Amber","Danielle","Melissa","Sierra",
        "Madelyn","Addison","Bailey","Catherine","Gianna","Amy","Erin","Jade","Angela","Gabriela","Jacqueline","Shelby","Kennedy","Lydia",
        "Alondra","Adriana","Daniela","Natalia","Breanna","Kathryn","Briana","Ashlyn","Rylee","Eva","Kendall","Peyton","Ruby","Alexandria",
        "Sophie","Charlotte","Reagan","Valeria","Christina","Summer","Kate","Mikayla","Naomi","Layla","Miranda","Laura","Ana","Angel","Alicia",
        "Daisy","Ciara","Margaret","Aubrey","Zoey","Skylar","Genesis","Payton","Courtney","Kylee","Kiara","Alexia","Jillian","Lindsey",
        "Mckenzie","Karen","Giselle","Mariana","Valerie","Sabrina","Alana","Serenity","Kelsey","Cheyenne","Juliana","Lucy","Kelly",
        "Sadie","Bianca","Kyra","Nadia","Lilly","Caitlyn","Jasmin","Ellie","Hope","Cassandra","Jazmin","Crystal","Jordyn","Cassidy",
        "Delaney","Liliana","Angelica","Caitlin","Kyla","Jayla","Adrianna","Tiffany","Abby","Carly","Chelsea","Camila","Erica","Makenzie",
        "Karla","Cadence","Paris","Veronica","Mckenna","Brenda","Bella","Maggie","Karina","Esmeralda","Erika","Makenna","Julianna","Elena",
        "Mallory","Jamie","Alejandra","Cynthia","Ariel","Vivian","Jayden","Amaya","Dakota","Elise","Haylee","Josephine","Aniyah","Bethany",
        "Keira","Aliyah","Laila","Camryn","Fatima","Reese","Annabelle","Monica","Lindsay","Kira","Selena","Macy","Hanna","Heaven","Clara",
        "Katrina","Jazmine","Jadyn","Stella" };
    #endregion

    public string GenerateWeakAlphanumericString(int length)
    {
        return GenerateWeakRandomString(length, ALPHANUMERIC_CHARS);
    }

    ///
    ///Generates email which is compatible with RFC 5322
    ///
    public string GenerateEmail(int totalLength)
    {
        const string validEmailLocalChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!#$%&'*+-/=?^_`{|}~";
        
        var rnd = new Random();
        var totalLengthWithoutDomain = totalLength - 3;
        var localLength = rnd.Next(1,totalLengthWithoutDomain-1);
        var domainLength = totalLengthWithoutDomain - localLength - 1;

        var local = GenerateWeakRandomString(localLength, validEmailLocalChars);
        var domain = GenerateWeakRandomString(domainLength, ALPHANUMERIC_CHARS);

        return local + "@" + domain + TWO_CHAR_DOMAINS.ElementAt(rnd.Next(0,TWO_CHAR_DOMAINS.Count-1));
    }

    public string GenerateWeakRandomString(int length, string validChars)
    {
        var result = new StringBuilder();

        var rnd = new Random();
        for(int i=0; i<length; i++){
            var chr = validChars[rnd.Next(0,validChars.Length)];
            result.Append(chr);
        }

        return result.ToString();
    }

    public string GetRandomName(NameTypeEnum nameType)
    {
        var rnd = new Random();

        switch(nameType)
        {
            case NameTypeEnum.Male:
                return MALE_FIRST_NAMES.ElementAt(rnd.Next(0,MALE_FIRST_NAMES.Count-1));
            case NameTypeEnum.Female:
                return FEMALE_FIRST_NAMES.ElementAt(rnd.Next(0,FEMALE_FIRST_NAMES.Count-1));
            case NameTypeEnum.All:
                var names = MALE_FIRST_NAMES.Concat(FEMALE_FIRST_NAMES);
                return names.ElementAt(rnd.Next(0, names.Count()));
            default:
                throw new ArgumentException("Wrong name type");
        }
    }
    
}