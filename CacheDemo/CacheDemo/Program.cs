using System;
using System.Runtime.Caching;

namespace CacheDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize the cache
            var cache = new MemoryCache("demoCache");

            var cacheItem = new CacheItem("fullName", "Jaimin Shethiya");
            var cacheItemPolicy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60.0)
            };
            //Trick 1 for added a data in cache
            //cache.Add(cacheItem, cacheItemPolicy);

            //Trick 2 for added a data in cache
            //cache.Add("fullName", "Jaimin Shethiya", cacheItemPolicy);

            //Trick 3 for added a data in cache
            //cache.Add("fullName", "Jaimin Shethiya", DateTimeOffset.Now.AddMinutes(10));

            cache.Add(cacheItem, cacheItemPolicy);
            var add = cache.Add(new CacheItem("firstName", "Jaimin"), cacheItemPolicy);
            var add1 = cache.Add(new CacheItem("lastName", "Shethiya"), cacheItemPolicy);

            //check the any key is exists to the cache or not
            var isExists = cache.Contains("fullName");
            Console.WriteLine("is exists {0}", isExists);

            // get the value from the cache
            var fullName = cache.Get("fullName");
            Console.WriteLine("fullName {0}", fullName);

            // get the cache item from the cache
            var fullNameCacheItem = cache.GetCacheItem("fullName");
            Console.WriteLine("fullName {0}", fullNameCacheItem.Value);

            //get the count item from the cache
            var total = cache.GetCount();
            Console.WriteLine("total {0}", total);
           
            //get multiple values from the cache
            var results = cache.GetValues(new string[] { "firstName", "lastName", "fullName" });
            foreach (var result in results)
            {
                Console.WriteLine($"{result.Key} : {result.Value}");
            }

            //add or get existing added a new kew 
            var item = cache.AddOrGetExisting(new CacheItem("middleName", "Ashwinbhai"), cacheItemPolicy);
            Console.WriteLine(item.Value);

            //add or get existing added a new already existing key
            item = cache.AddOrGetExisting(cacheItem, cacheItemPolicy);
            Console.WriteLine(item.Value);

            //remove the data from the cache
            var removeFullName = cache.Remove("fullName");
            Console.WriteLine("fullName {0}", removeFullName);

            Console.ReadLine();
        }
    }
}
