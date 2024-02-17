using AutoMapper;
using Blazor.Business.Repository.IRepository;
using Blazor.Data.Context;
using Blazor.Data.Entities.NewsEntities;
using Blazor.Model.NewsDtos;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<NewsDTO>> GetAllNews()
        {
            try
            {
                IEnumerable<NewsDTO> newsDTOs = _mapper.Map<IEnumerable<News>, IEnumerable<NewsDTO>>(await _context.News.ToListAsync());
                return newsDTOs;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public async Task<NewsDTO> GetNewsById(int newsId)
        {
            try
            {
                NewsDTO news = _mapper.Map<News, NewsDTO>(await _context.News.SingleOrDefaultAsync(x => x.NewsId == newsId));
                return news;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public async Task<NewsDTO> NewsExistsByTitle(string title)
        {
            return _mapper.Map<News, NewsDTO>(await _context.News.FirstOrDefaultAsync(x => x.Title == title));
        }

        public async Task<int> RemoveNews(int newsId)
        {
            var news = await _context.News.FindAsync(newsId);   
            if (news != null)
            {
                _context.News.Remove(news);
                await _context.SaveChangesAsync();

                return news.NewsId;
            }
            return 0;
        }

        public async Task<int> RemoveNews(NewsDTO news)
        {
            return await RemoveNews(news.NewsId);
        }

        public async Task<NewsDTO> UpdateNews(int newsId, NewsDTO newsDTO)
        {
            try
            {
                if (newsId == newsDTO.NewsId)
                {
                    News newsDetail = await _context.News.FindAsync(newsId);
                    News news = _mapper.Map<NewsDTO, News>(newsDTO, newsDetail);
                    news.EditedBy = "";
                    news.CreatedDate = DateTime.Now;
                    _context.News.Update(news);
                    await _context.SaveChangesAsync();
                    return _mapper.Map<News, NewsDTO>(news);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                return null;
            }
        }
    }
}
