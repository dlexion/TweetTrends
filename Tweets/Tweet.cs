using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tweets
{
    class Tweet
    {
        PointF point;
        DateTime date;
        Text message;

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
