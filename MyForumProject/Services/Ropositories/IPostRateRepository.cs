using MyForumProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyForumProject.Services.Ropositories
{
    public interface IPostRateRepository
    {
        IQueryable<PostRate> PostRates { get; } 

        void Add(PostRate rate);
        Task AddAsync(PostRate rate);

        void Delete(PostRate rate);
        void Delete(long id);
        Task DeleteAsync(long id);

        bool Contain(long id);
        bool Contain(PostRate rate);

        void Update(PostRate rate);

        PostRate GetById(long id);
        Task<PostRate> GetByIdAsync(long id);
    }

}
