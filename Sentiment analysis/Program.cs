using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentiment_analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            SentimentDictionary dictionary = new SentimentDictionary(@"D:\PS3_TweetTrens\trends\data\sentiments.csv");
            dictionary.Read();

            SentimentCalculation.Calculate(dictionary, Tweets.TweetsReader.Read(@"D:\PS3_TweetTrens\trends\data\my_job.txt"));
            Console.ReadKey();
        }
    }
}
