using System.Collections.Generic;

namespace WindowsFormsApp2.Constants
{
    public class Videos
    {
        public static readonly Dictionary<string, string> VIDEOS_NAME_URL = new Dictionary<string, string>();

        static Videos()
        {
            VIDEOS_NAME_URL.Add("Photoshop відео", "Photoshop.mp4");
            VIDEOS_NAME_URL.Add("AR анімація", "AR.mp4");
            VIDEOS_NAME_URL.Add("Autocad анімація", "Autocad.mp4");
            VIDEOS_NAME_URL.Add("3DS анімація", "3DS.mp4");
        }
    }
}