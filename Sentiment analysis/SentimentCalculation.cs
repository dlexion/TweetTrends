using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweets;

namespace Sentiment_analysis
{
    class SentimentCalculation
    {
        public static void Calculate(SentimentDictionary dictionary, List<Tweet> tweets)
        {
            File.Delete("sentiment_log.txt");
            foreach (var tweet in tweets)
            {
                Console.WriteLine("{0} : {1}", tweet, Calculate(dictionary, tweet.Message));
                Console.WriteLine(tweets.IndexOf(tweet));
            }
        }

        private static double? Calculate(SentimentDictionary dictionary, Text tweet)
        {
            double? result = 0;
            bool hasChanged = false;
            using (StreamWriter sw = new StreamWriter("sentiment_log.txt",true))
            {
                foreach (var sentence in tweet.Sentences)
                {
                    string key;
                    for (int i = 0; i < sentence.Words.Count; i++)
                    {
                        key = sentence.Words[i].Wd.ToLower();
                        double? temp = null;
                        int count = 0;

                        while (true)
                        {
                            if (dictionary.ContainsKey(key) && !dictionary.ContainsSubstring(key + " "))
                            {
                                result += dictionary.GetValue(key);
                                hasChanged = true;
                                sw.WriteLine("{0} : {1}", key, dictionary.GetValue(key));
                                sw.WriteLine("Total : {0}", result);
                                temp = null;
                                count = 0;
                                break;
                            }
                            else if (dictionary.ContainsSubstring(key + " ") && i + 1 < sentence.Words.Count && sentence.Words[i].Mark == null)
                            {
                                if (dictionary.ContainsKey(key))
                                {
                                    temp = dictionary.GetValue(key);
                                }
                                sw.WriteLine("1111{0} : {1}", key, temp == null ? "not fount" : temp.ToString());
                                count++;
                                key += " " + sentence.Words[++i].Wd.ToLower();
                                sw.WriteLine("Add word: {0}", sentence.Words[i].Wd.ToLower());
                            }
                            else
                            {
                                sw.WriteLine("!!!!!!{0} : {1}", key, "not found");
                                if (temp != null)
                                {
                                    result += temp;
                                    hasChanged = true;
                                    temp = null;
                                    sw.WriteLine("Total : {0}", result);

                                }

                                i -= count;
                                count = 0;
                                //sw.WriteLine("{0} : {1}", key, temp);
                                break;
                            }
                        }

                    }
                }
                sw.WriteLine("{0} : {1}", tweet, result);
                return hasChanged ? result : null;
            }

        }
    }
}
