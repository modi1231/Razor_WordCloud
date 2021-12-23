# Razor_WordCloud
ASP.NET C# Core 2.1 Bare bones word cloud for a website.
For a tutorial for DIC.

https://www.dreamincode.net/forums/topic/412856-aspnet-razor-pages-core-21-tag-cloud/



=================
dreamincode.net tutorial backup ahead of decommissioning

 Post icon  Posted 26 September 2018 - 12:21 AM 

5,564,511 Views

[b][u]Requirements:[/b][/u]
Visual Studio 2017
Core 2.1 / Razor pages
C#

[b][u]Github:[/b][/u]
https://github.com/modi1231/Razor_WordCloud

[img]https://i.imgur.com/HDLgoJc.png[/img]


[b][u]Background:[/b][/u]
Tag clouds are interesting little visual clues on frequency of words used to tag blog posts, news articles, etc.  The gist is the code pulls back a basic SQL SELECT count with the tag, and the 'tag cloud' shows those tags with various sizes (or font styles) to indicate frequency of use.

This should be a pretty quick ninja addition to a page, blog, etc.  Minimal input with nifty output.

[b][u]Outline:[/b][/u]
This project needs only a few things to work.  A list of tags, and a numerical count of how many are in the 'database'.  

After a bit of thinking I figured the most direct route would be to utilize the Razor functionality to insert collection text where ever I want in a page.. like the style!  

When a 'count' is added I can map the value to a range of IF statements.  Those IFs would then return the appropriate CSS font-size style name.

[b][u]Tutorial:[/b][/u]
I start by creating a new, Razor Core 2.1, blank project.  

I go about the business of setting up the Startup.CS  to have MVC, create the _ViewImports, and then create the index.cshtml.

Per my usual work flow I create a 'Data' folder to hold data relevant classes.

Inside the data folder I create the 'Tags' class.  This holds the basic information I would need.
[code]
        public string Tag { get; set; }
        public int Count { get; set; }
        public string HTMLStyle { get; set; }
[/code]
Tag is to display, the count is for determining HTMLStyle, and HTMLStyle is so we can inject that into the CSS styling.

The constructor calls the 'SetHTMLStyle' which should return what CSS style is appropriate for that count.  It could be a number, a range, or how ever you feel like setting it up.  I was more of a one-to-one at the moment.

Don't forget to account for what happens when the number is outside of your given ranges!
[code]
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
[/code]

Inside the data folder I create my typical 'DataAccess' class.  A crucial point of the whole MVC paradigm is to decouple major sections of your code.  That means the 'model' is not part of the view.. the view just shows the data.. and the controller works to update the model for the view.  It also has the great benefit for testing.  I could have spent a long time setting up a database, data interactions, etc and woven that tightly into the view, but instead I have a function that simply returns a Tags object collection.  

In future iterations I could swap out the logic here to be an actual database.. or from a file.. or a JSON call or where ever.. but as long as it returns a collection of Tags objects the rest of my code could care less where the data came from - just that it is there!  

For my testing I use a lot of 'lorem ipsum' nonsense words, and randomize their 'count'.  This means I can refresh the page and see how various styles look without having to re-code/recompile.  Swanky!
[code]
        public async Task<List<Tags>> GetTagsAsync()
        {
            List<Tags> temp = new List<Tags>();
            Random random = new Random();//Randomizing the count to see how this looks
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
[/code]
At this point we are almost done!

Flip to the index.cshtml.

Inside all that is needed is a handful of things.  

The collection of tags to be used in the view
[code]        public List<Tags> myTags { get; set; }[/code]

Getting the tags data.  Again - notice how this code doesn't care the source (DB, file, API, made up, etc), but just cares it gets a specific return.  Nifty!
[code]
        public void OnGet()
        {
            //Set up the data access
            DataAccess temp = new DataAccess();

            //fetch the collection
            myTags = temp.GetTagsAsync().Result;
        }[/code]

On the display side I have an "admin-ish" thing to show what is in the collection (remember for testing the count changes), and their HTMLStyle tag (to verify the IF/ELSEs work).
[code]
<div>
    <h2>Show what's in the collection</h2>
    # of tags: @Model.myTags.Count
    <br /><br />
    @for (int i = 0; i < Model.myTags.Count; i++)
    {
        @Model.myTags[i].Tag;
        <span> - </span>
        @Model.myTags[i].Count;
        <span> - </span>
        @Model.myTags[i].HTMLStyle;
        <br />
    }
</div>
[/code]
The real meat - what the tutorial was for - is at the bottom.  A small amount of work to show injecting C# model objects into the CSS styling using the nift @().

If everything worked well you can run it and F12 to see how the style changes through each iteration of the for loop.  

[code]Tag cloud:<br />
<div style="width: 300px;justify-content: center;background-color:aliceblue;">
    @for (int i = 0; i < Model.myTags.Count; i++)
    {
        <span style="font-size:@(Model.myTags[i].HTMLStyle);">@Model.myTags[i].Tag</span>
    }
</div>[/code]

Honestly - that's it.  A ninja addition ready to be slid into a future project and duties separated to change data sources with minimal fuss!

[b][u]Advanced options:[/b][/u]
Make the tags link to a search to for those tags and return information based on that tag.



[i]!!! Note - I flubbed and used ".Result" with my async calls when I should have used await and _NOT_ the ".Result".  Fixing.[/i]
