using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tweets
{
    public class Tweet
    {
        PointF point;
        DateTime date;
        Text message;

        public Text Message { get => message; }

        public Tweet(PointF point, DateTime dateTime, Text text)
        {
            this.point = point;
            this.date = dateTime;
            this.message = text;
        }

        public override string ToString()
        {
            return message.ToString();
        }
    }
}
