using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CommonLayer.Helpers
{
    public class BlogPost
    {
        public static int GenerateRandomNoForSlug()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

        public static string dateTimeParserFromString(string datetime)
        {
            try
            {
                DateTime dateTimeD = Convert.ToDateTime(datetime);
                datetime = dateTimeD.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            }
            catch (Exception)
            {
                return "";
            }
            return datetime;
        }

        public static List<string> fixTagsFromDB(string tagFromDB)
        {
            List<string> rm_Model = new List<string>();

            tagFromDB = tagFromDB.Replace("<tag>", "");
            var tagsList = tagFromDB.Split("</tag>");
            foreach (var item in tagsList)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    rm_Model.Add(item);
                }
            }
            return rm_Model;
        }
    }
}
