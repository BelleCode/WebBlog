using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBlog.Services.Iterfaces
{
    public interface ISlugService
    {
        string UrlFriendly(string title);

        //determine if slug is unique or not
        bool SlugIsUnique(string slug);
    }
}