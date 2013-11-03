using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF_Constants
{
    public static class Constants
    {
        public static class EditModes
        {
            public const int ReadMode = 0;
            public const int EditMode = 1;
            public const int AddMode = 2;
        }

        public static class Sex
        {
            public const string WomanString = "Kobieta";
            public const string ManString = "Mężczyzna";
            public const bool WomanValue = false;
            public const bool ManValue = true;
        }

        public static class Profile
        {
            public static readonly IList<String> StringList = new ReadOnlyCollection<string>
            (new List<String> { 
                 "a","b","c","d","e","nauczyciel","rodzic"});

            public static char? GetLetter(string profile)
            {
                switch (profile)
                {
                    case "a":
                        return 'a';
                    case "b":
                        return 'b';
                    case "c":
                        return 'c';
                    case "d":
                        return 'd';
                    case "e":
                        return 'e';
                    case "nauczyciel":
                        return 'n';
                }
                return null;
            }

            public static string GetString(char letter)
            {
                switch (letter)
                {
                    case 'a':
                        return "a";
                    case 'b':
                        return "b";
                    case 'c':
                        return "c";
                    case 'd':
                        return "d";
                    case 'e':
                        return "e";
                    case 'n':
                        return "nauczyciel";
                }
                return null;
            }



        } 
    }
}
