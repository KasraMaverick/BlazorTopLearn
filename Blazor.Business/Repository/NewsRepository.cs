using AutoMapper;
using Blazor.Business.Repository.IRepository;
using Blazor.Data.Context;
using Blazor.Data.Entities.NewsEntities;
using Blazor.Model.NewsDtos;

namespace Blazor.Business.Repository
{
    public class NewsRepository : INewsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public NewsRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<NewsDTO> CreateNews(NewsDTO newsDTO)
        {
            var news = _mapper.Map<NewsDTO, News>(newsDTO);
            news.CreatedDate = DateTime.Now;
            news.CreatedBy = "";
            var addedNews = await _context.News.AddAsync(news);
            await _context.SaveChangesAsync();
            return _mapper.Map<News, NewsDTO>(addedNews.Entity);
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
