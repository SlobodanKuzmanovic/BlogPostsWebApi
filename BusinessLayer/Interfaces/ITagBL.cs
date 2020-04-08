using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface ITagBL
    {
        List<Tag> Create_Tags_IfNotExist(List<string> tagList);
        rm_Tag Get_Tags();
    }
}
