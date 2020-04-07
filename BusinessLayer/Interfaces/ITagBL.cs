using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface ITagBL
    {
        Tag Create_Tag_IfNotExist(List<string> tagList);
    }
}
