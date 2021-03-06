﻿using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class Factory : IFactory
    {
        public IBlogPostDA GetBlogPostDA()
        {
            return new BlogPostDA();
        }

        public ITagDA GetTagDA()
        {
            return new TagDA();
        }
    }
}
