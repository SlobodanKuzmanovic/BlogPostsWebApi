﻿using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface ITagDA
    {
        Tag Get_Tag(string tag);

        rm_Tag Get_Tags();

        Tag Create_Tag(string tag);
    }
}
