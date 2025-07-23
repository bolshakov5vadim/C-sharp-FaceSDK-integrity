using SimpleTODOLesson.Models;

namespace SimpleTODOLesson.Services.Interfaces
{
    public interface IPostsService
    {
        PostModel Create(PostModel model);

        PostModel Update(PostModel model);

        void Delete(int id);

        PostModel Get(int id);

        List<PostModel> GetAll();
    }
}
