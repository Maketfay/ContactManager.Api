using Core;
using Infrastucture.Core;
using Infrastucture.Entity;
using Infrastucture.Repositories;
using Infrastucture.Services;

namespace Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<IPagedList<IContact>> GetPagedContactAsync(int page, int pageSize)
        {
            var contactCount = await _contactRepository.ReadCountAsync();
            if (page <= 0 || pageSize <= 0)
            {
                page = 1;
                pageSize = contactCount;
            }

            var contacts = await _contactRepository.ReadCollectionAsync(page, pageSize);

            var contactPagedList = new PagedList<IContact>
            {
                Items = contacts,
                CurrentPage = page,
                PageSize = pageSize,
                TotalItemsCount = contactCount
            };

            return contactPagedList;
        }
    }
}
