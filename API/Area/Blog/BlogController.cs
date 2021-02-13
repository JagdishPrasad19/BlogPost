using Blogpost.API.Area.Application;
using Blogpost.Core.Application;
using Blogpost.Core.Blog;
using Blogpost.Core.Blog.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogpost.API.Area
{
    [Route("api/[controller]")]
    public class BlogController : ApiControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly ISessionContext _sessionContext;

        public BlogController(IBlogService blogService,ISessionContext sessionContext)
        {
            _blogService = blogService;
            _sessionContext = sessionContext;
        }

        [HttpPost("saveblog")]
        public bool SaveBlog([FromBody] BlogEditModel model)
        {
            var responce = _blogService.SaveBlog(model, _sessionContext.UserSession.UserId);
            if (responce) ResponseModel.Message = "Blog Save Succeffully.";
            return responce;
        }

        [HttpGet("getblog/{blogId}")]
        public BlogEditModel GetBlog(long blogId)
        {
            var responce = _blogService.GetBlog(blogId, _sessionContext.UserSession.UserId);
            if (responce==null) ResponseModel.Message = "No Blog found for you.";
            return responce;
        }

        [HttpGet("getmyblogList")]
        public List<BlogEditModel> GetMyBlogList()
        {
            var responce = _blogService.GetBlogList( _sessionContext.UserSession.UserId);
            if (!responce.Any()) ResponseModel.Message = "No Blog's found for you.";
            return responce;
        }

        [HttpGet("list")]
        public List<BlogEditModel> List()
        {
            var responce = _blogService.List();
            if (!responce.Any()) ResponseModel.Message = "No Blog's found.";
            return responce;
        }
        [HttpGet("delete/{blogId}")]
        public bool Delete(long blogId)
        {
            var responce = _blogService.Delete(blogId,_sessionContext.UserSession.UserId);
            if (!responce) ResponseModel.Message = "Unable to delete blog.";
            return responce;
        }

    }
}
