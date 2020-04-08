using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostsWebApi.Controllers
{
    [Route("api/tags")]
    [ApiController]
    public class TagAPI : ControllerBase
    {
        ITagBL _tagBL;
        public TagAPI()
        {
            if (BusinessLayer.Scope.Factory == null)
            {
                BusinessLayer.Scope.Factory = new BusinessLayer.Factory();
            }
            _tagBL = BusinessLayer.Scope.Factory.GetTagBL();
        }

        [HttpGet]
        public rm_Tag Get()
        {
            return _tagBL.Get_Tags();
        }
    }
}