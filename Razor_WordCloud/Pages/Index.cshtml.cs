using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_WordCloud.Data;

namespace Razor_WordCloud.Pages
{
    public class IndexModel : PageModel
    {
        //collection to show
        public List<Tags> myTags { get; set; }

        public void OnGet()
        {
            //Set up the data access
            DataAccess temp = new DataAccess();

            //fetch the collection
            myTags = temp.GetTagsAsync().Result;
        }
    }
}