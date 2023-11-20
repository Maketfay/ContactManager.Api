using Infrastucture.Core;
using Infrastucture.Entity;

namespace Infrastucture.Services
{
    public interface IContactService
    {
        Task<IPagedList<IContact>> GetPagedContactAsync(int page, int pageSize);
    }
}
