using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_WordCloud.Data
{
 

    public class Tags
    {
        public string Tag { get; set; }
        public int Count { get; set; }
        public string HTMLStyle { get; set; }

        /// <summary>
        ///  quick constructor.
        /// </summary>
        public Tags(string val, int num)
        {
            Tag = val;
            Count = num;
            HTMLStyle = SetHTMLSize(num);
        }

        /// <summary>
        /// Translate the count ranges to CSS font sizing.
        /// </summary>
        private string SetHTMLSize(int num)
        {
            //Easily adapted to ranges if you want to tweak the count to size.

            string ret = "medium"; // in case things go 'over' the size, use medium.

            if(num <= 1)
            {
                ret = "x-small";
            }else if( num < 2)
            {
                ret = "small";
            }
            else if (num < 3)
            {
                ret = "medium";
            }
            else if (num < 4)
            {
                ret = "large";
            }
            else if (num < 5)
            {
                ret = "x-large";
            }
            else if (num < 6)
            {
                ret = "xx-large";
            }
            return ret;
        }
    }
}
