using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tweets
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tweet> tweets = TweetsReader.Read(@"D:\PS3_TweetTrens\trends\data\my_job.txt");
            Console.WriteLine(tweets.Count);
            foreach (var tweet in tweets)
            {
                Console.WriteLine(tweet);
            }
            Console.ReadKey();
        }
    }
}
