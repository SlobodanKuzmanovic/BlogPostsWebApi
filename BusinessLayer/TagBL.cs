using BusinessLayer.Interfaces;
using CommonLayer;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    internal class TagBL : ITagBL
    {
        ITagDA _tagDA;
        public TagBL()
        {
            _tagDA = DataAccessLayer.Scope.Factory.GetTagDA();
        }
        public List<Tag> Create_Tags_IfNotExist(List<string> tagList)
        {
            List<Tag> rm_Tags = new List<Tag>();  
            foreach (var item in tagList)
            {
                var singleTag = _tagDA.Get_Tag(item);
                if (singleTag == null)
                {
                    singleTag = _tagDA.Create_Tag(item);
                }
                rm_Tags.Add(singleTag);
            }
            return rm_Tags;
        }
    }
}
