using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IFactory
    {
        IBlogPost GetBlogPost();
        ITagBL GetTagBL();
    }
}
