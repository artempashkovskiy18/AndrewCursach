using System.Collections.Generic;

namespace WindowsFormsApp2.Constants
{
    public class Videos
    {
        public static readonly Dictionary<string, string> VIDEOS_NAME_URL = new Dictionary<string, string>();

        static Videos()
        {
            VIDEOS_NAME_URL.Add("1", "https://google.com");
            VIDEOS_NAME_URL.Add("2", "https://google.com");
            VIDEOS_NAME_URL.Add("3", "https://google.com");
            VIDEOS_NAME_URL.Add("4", "https://google.com");
        }
    }
}