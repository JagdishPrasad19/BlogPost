
namespace Blogpost.Core.Application
{
    public interface ISessionContext
    {
        User.Model.UserSessionModel UserSession { get; set; }
        string SessionId { get; set; }
    }
}
