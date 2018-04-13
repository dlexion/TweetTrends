using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tweets
{
    public class TweetsReader
    {
        static public List<Tweet> Read(string path)
        {
            List<Tweet> tweets = new List<Tweet>();

            using (StreamReader sr = new StreamReader(path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    try
                    {

                        string[] str = line.Split(null, 6);

                        PointF point = new PointF(Convert.ToSingle(str[0].Trim(new char[] { ' ', '[', ']', ',' }).Replace('.', ',')),
                                                       Convert.ToSingle(str[1].Trim(new char[] { ' ', '[', ']', ',' }).Replace('.', ',')));

                        DateTime dt = ParseDate(str[3], str[4]);

                        tweets.Add(new Tweet(point, dt, TextReader.Read(str[5])));


                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show(e.Message + "\n" + line);
                    }
                }
                return tweets;
            }


        }

        static private DateTime ParseDate(string date, string time)
        {
            int year, month, day, hour, minute, second;

            string[] splitedDate = date.Split(new char[] { '-' });
            year = Convert.ToInt32(splitedDate[0]);
            month = Convert.ToInt32(splitedDate[1]);
            day = Convert.ToInt32(splitedDate[2]);

            string[] splitedTime = time.Split(new char[] { ':' });
            hour = Convert.ToInt32(splitedTime[0]);
            minute = Convert.ToInt32(splitedTime[1]);
            second = Convert.ToInt32(splitedTime[2]);

            return new DateTime(year, month, day, hour, minute, second);
        }
    }
}
