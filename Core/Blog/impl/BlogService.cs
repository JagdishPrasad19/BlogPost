using Blogpost.Application.Attributes;
using Blogpost.Core.Application;
using Blogpost.Core.Blog.Model;
using System.Linq;
using System.Collections.Generic;

namespace Blogpost.Core.Blog.impl
{
    [DefaultImplementation]
    public class BlogService : IBlogService
    {
        private readonly IRepository<Blogpost.Core.Blog.Domain.Blog> _blogRepository;
        public BlogService(IUnitOfWork _unitOfWork)
        {
            _blogRepository = _unitOfWork.Repository<Blogpost.Core.Blog.Domain.Blog>();
        }  
    

        public bool SaveBlog(BlogEditModel model,long userId)
        {
            if (model.Id > 0)
            {
              var _blog =  _blogRepository.Table.FirstOrDefault(x => x.Id == model.Id);
                if(_blog!= default)
                {
                    _blog.Titel = model.Titel;
                    _blog.Content = model.Content;
                    _blogRepository.Save(_blog);
                    return true;
                }
            }
            return CreateNewBlog(model, userId);
        }

        private bool CreateNewBlog(BlogEditModel model, long userId)
        {
            _blogRepository.Save(new Domain.Blog { UserId = userId, Titel = model.Titel, Content = model.Content, IsNew = true });
            return true;
        }


        public BlogEditModel GetBlog(long blogId,long userId)
        {
            var _blog = _blogRepository.Table.FirstOrDefault(x => x.Id == blogId && x.UserId == userId && !x.IsDeleted);
            if (_blog != default)
                return new BlogEditModel { Id = _blog.Id, Titel = _blog.Titel, Content = _blog.Content };
            else return default;
        }

        public List<BlogEditModel> GetBlogList(long userId)
        {
            return _blogRepository.Table.Where(x => x.UserId == userId && !x.IsDeleted).Select(x=> new BlogEditModel { Id= x.Id,Titel = x.Titel,Content = x.Content}).ToList();
            
        }

        public List<BlogEditModel> List()
        {
            return _blogRepository.Table.Where(x =>  !x.IsDeleted).Select(x => new BlogEditModel {  Titel = x.Titel, Content = x.Content }).ToList();
        }

        public bool Delete(long blogId,long userId)
        {
            var _blog = _blogRepository.Table.FirstOrDefault(x => x.Id == blogId && x.UserId == userId && !x.IsDeleted);
            if (_blog == default) return false;

            _blog.IsDeleted = true;
            _blogRepository.Save(_blog);
            return true;
        }

    }
}
