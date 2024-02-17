using Blazor.Business.Repository.IRepository;
using Blazor.Data.Context;
using Blazor.Model.NewsDtos;

namespace Blazor.Business.Repository
{
    public class NewsRepository : INewsRepository
    {
        private readonly ApplicationDbContext _context;
        public NewsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<NewsDTO> CreateNews(NewsDTO newsDTO)
        {

            await _context.News.AddAsync();
        }

        public Task<IEnumerable<NewsDTO>> GetAllNews()
        {
            throw new NotImplementedException();
        }

        public Task<NewsDTO> GetNewsById(int newsId)
        {
            throw new NotImplementedException();
        }

        public Task<NewsDTO> NewsExistsByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public Task<NewsDTO> RemoveNews(int newsId)
        {
            throw new NotImplementedException();
        }

        public Task<NewsDTO> RemoveNews(NewsDTO news)
        {
            throw new NotImplementedException();
        }

        public Task<NewsDTO> UpdateNews(int id, NewsDTO newsDTO)
        {
            throw new NotImplementedException();
        }
    }
}
