using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_WordCloud.Data
{
    public class DataAccess
    {
        //Abstracted my data 'fetch' class.  This could easily be a database call.
        public async Task<List<Tags>> GetTagsAsync()
        {
            List<Tags> temp = new List<Tags>();
            Random random = new Random();//Randomzing the count to see how this looks
            int max = 7;

            temp.Add(new Tags("Lorem", random.Next(max)));
            temp.Add(new Tags("ipsum", random.Next(max)));
            temp.Add(new Tags("dolor", random.Next(max)));
            temp.Add(new Tags("foo", random.Next(max)));
            temp.Add(new Tags("sit", random.Next(max)));
            temp.Add(new Tags("amet", random.Next(max)));

            temp.Add(new Tags("consectetur", random.Next(max)));
            temp.Add(new Tags("adipiscing", random.Next(max)));
            temp.Add(new Tags("elit", random.Next(max)));

            temp.Add(new Tags("metus", random.Next(max)));
            temp.Add(new Tags("auctor", random.Next(max)));
            temp.Add(new Tags("bibendum", random.Next(max)));
            temp.Add(new Tags("facilisis", random.Next(max)));
              
            return temp;
        }

    }
}
