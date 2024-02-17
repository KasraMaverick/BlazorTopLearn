using Blazor.Model.NewsDtos;

namespace Blazor.Business.Repository.IRepository
{
    public interface INewsRepository
    {
        public Task<NewsDTO> CreateNews(NewsDTO newsDTO);

        public Task<NewsDTO> UpdateNews(int id, NewsDTO newsDTO);

        public Task<NewsDTO> GetNewsById(int newsId);

        public Task<IEnumerable<NewsDTO>> GetAllNews();

        public Task<NewsDTO> NewsExistsByTitle(string title);

        public Task<NewsDTO> RemoveNews(int newsId);

        public Task<NewsDTO> RemoveNews(NewsDTO news);


    }
}
