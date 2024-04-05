using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Tools
{
    internal class UsersCreator
    {
        public static List<DBUser> getUsers()
        {
            List<DBUser> list = new List<DBUser>
            {
                new DBUser("Michael"  , "Brown"   , "michael.brown@gmail.com", new DateTime(1980, 12, 5)),
                new DBUser("Jessica"  , "Wilson"  , "jessica.wilson@gmail.com", new DateTime(1995, 2, 18)),
                new DBUser("David"    , "Taylor"  , "david.taylor@gmail.com", new DateTime(1983, 9, 30)),
                new DBUser("Sarah"    , "Anderson", "sarah.anderson@gmail.com", new DateTime(1979, 7, 25)),
                new DBUser("Matthew"  , "Thomas"  , "matthew.thomas@gmail.com", new DateTime(1990, 4, 3)),
                new DBUser("Emily"    , "Martinez", "emily.martinez@gmail.com", new DateTime(1973, 6, 17)),
                new DBUser("Daniel"   , "Hernandez", "daniel.hernandez@gmail.com", new DateTime(1998, 10, 12)),
                new DBUser("Ashley"   , "Young"   , "ashley.young@gmail.com", new DateTime(1989, 8, 29)),
                new DBUser("Christopher", "King" , "christopher.king@gmail.com", new DateTime(2000, 1, 7)),
                new DBUser("Amanda"   , "Scott"   , "amanda.scott@gmail.com", new DateTime(1970, 5, 24)),
                new DBUser("James"    , "Lopez"   , "james.lopez@gmail.com", new DateTime(1993, 2, 14)),
                new DBUser("Megan"    , "Green"   , "megan.green@gmail.com", new DateTime(1982, 11, 11)),
                new DBUser("Ryan"     , "Adams"   , "ryan.adams@gmail.com", new DateTime(1977, 10, 19)),
                new DBUser("Jennifer" , "Campbell", "jennifer.campbell@gmail.com", new DateTime(1992, 6, 8)),
                new DBUser("Justin"   , "Evans"   , "justin.evans@gmail.com", new DateTime(1976, 4, 2)),
                new DBUser("Nicole"   , "Garcia"  , "nicole.garcia@gmail.com", new DateTime(1984, 9, 28)),
                new DBUser("Andrew"   , "Nelson"  , "andrew.nelson@gmail.com", new DateTime(1997, 3, 23)),
                new DBUser("Lauren"   , "Hill"    , "lauren.hill@gmail.com", new DateTime(1986, 12, 20)),
                new DBUser("Brandon"  , "Ramirez" , "brandon.ramirez@gmail.com", new DateTime(1974, 7, 15)),
                new DBUser("Elizabeth", "Carter"  , "elizabeth.carter@gmail.com", new DateTime(1994, 5, 3)),
                new DBUser("Joshua"   , "Wright"  , "joshua.wright@gmail.com", new DateTime(1978, 1, 1)),
                new DBUser("Samantha" , "Perez"   , "samantha.perez@gmail.com", new DateTime(1981, 10, 27)),
                new DBUser("Kevin"    , "Hall"    , "kevin.hall@gmail.com", new DateTime(1996, 8, 14)),
                new DBUser("Hannah"   , "Turner"  , "hannah.turner@gmail.com", new DateTime(1971, 4, 9)),
                new DBUser("Tyler"    , "Morris"  , "tyler.morris@gmail.com", new DateTime(1988, 2, 22)),
                new DBUser("Kayla"    , "Watson"  , "kayla.watson@gmail.com", new DateTime(1999, 11, 16)),
                new DBUser("Alexander", "Brooks"  , "alexander.brooks@gmail.com", new DateTime(1972, 9, 13)),
                new DBUser("Emma"     , "Russell" , "emma.russell@gmail.com", new DateTime(1991, 7, 5)),
                new DBUser("Zachary"  , "Dunn"    , "zachary.dunn@gmail.com", new DateTime(1973, 6, 4)),
                new DBUser("Victoria" , "Gordon"  , "victoria.gordon@gmail.com", new DateTime(1987, 4, 28)),
                new DBUser("Kyle"     , "Kelley"  , "kyle.kelley@gmail.com", new DateTime(1995, 3, 19)),
                new DBUser("Alexis"   , "Baker"   , "alexis.baker@gmail.com", new DateTime(1980, 12, 12)),
                new DBUser("Nathan"   , "Rivera"  , "nathan.rivera@gmail.com", new DateTime(1975, 10, 31)),
                new DBUser("Madison"  , "Mitchell", "madison.mitchell@gmail.com", new DateTime(1992, 8, 25)),
                new DBUser("Olivia"   , "Ward"    , "olivia.ward@gmail.com", new DateTime(1978, 7, 18)),
                new DBUser("Ethan"    , "Lynch"   , "ethan.lynch@gmail.com", new DateTime(1986, 6, 7)),
                new DBUser("Grace"    , "Harrison", "grace.harrison@gmail.com", new DateTime(1997, 4, 1)),
                new DBUser("Logan"    , "Ferguson", "logan.ferguson@gmail.com", new DateTime(1979, 2, 23)),
                new DBUser("Alyssa"   , "Murray"  , "alyssa.murray@gmail.com", new DateTime(1989, 12, 17)),
                new DBUser("Cody"     , "Olson"   , "cody.olson@gmail.com", new DateTime(1994, 11, 9)),
                new DBUser("Julia"    , "Kim"     , "julia.kim@gmail.com", new DateTime(1983, 10, 5)),
                new DBUser("Aaron"    , "Austin"  , "aaron.austin@gmail.com", new DateTime(1990, 9, 2)),
                new DBUser("Hailey"   , "Parker"  , "hailey.parker@gmail.com", new DateTime(1976, 8, 26)),
                new DBUser("Christian", "Hudson"  , "christian.hudson@gmail.com", new DateTime(1981, 7, 21)),
                new DBUser("Lily"     , "Griffin" , "lily.griffin@gmail.com", new DateTime(1993, 6, 15)),
                new DBUser("Gavin"    , "Gomez"   , "gavin.gomez@gmail.com", new DateTime(1974, 5, 7)),
                new DBUser("Sydney"   , "Wallace" , "sydney.wallace@gmail.com", new DateTime(1985, 4, 3)),
                new DBUser("Brianna"  , "Coleman" , "brianna.coleman@gmail.com", new DateTime(1996, 3, 28)),
                new DBUser("Marcus"   , "Woods"   , "marcus.woods@gmail.com", new DateTime(1977, 2, 19)),
                new DBUser("Mia"      , "Grant"   , "mia.grant@gmail.com", new DateTime(1982, 1, 13)),
                new DBUser("Zoe"      , "Wagner"  , "zoe.wagner@gmail.com", new DateTime(1999, 12, 8))
            };
            return list;
        }
    }
}
