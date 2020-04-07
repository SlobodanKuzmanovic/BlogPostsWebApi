using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IFactory
    {
        IBlogPostDA GetBlogPostDA();
        ITagDA GetTagDA();
    }
}
