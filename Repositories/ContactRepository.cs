using Entity;
using Infrastucture.Entity;
using Infrastucture.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public ContactRepository(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }
        public async Task<IContact> CreateAsync(string name, string email, string mobilePhone, string jobTitle, DateTime? BirthDate)
        {
            var entity = _serviceProvider.GetRequiredService<IContact>();

            entity.Id = Guid.NewGuid();
            entity.Name = name;
            entity.Email = email;
            entity.MobilePhone = mobilePhone;
            entity.JobTitle = jobTitle;
            entity.BirthDate = BirthDate;
            entity.IsDeleted = false;

            var contact = await _context.Contact.AddAsync((ContactEntity)entity);

            await _context.SaveChangesAsync();

            return contact.Entity;
        }

        public async Task<IEnumerable<IContact>> ReadCollectionAsync(int page, int pageSize, bool isDeleted = false)
        {
            var contactQuery = _context.Contact
                .Where(c => c.IsDeleted == isDeleted)
                .OrderBy(c => c.Name)
                .Skip(((page - 1) * pageSize))
                .Take(pageSize);

            return await contactQuery.ToListAsync();
        }

        public async Task<IContact?> ReadAsync(Guid id, bool isDeleted = false)
        {
            return await _context.Contact.FirstOrDefaultAsync(c => c.Id.Equals(id) && c.IsDeleted == isDeleted);
        }

        public async Task<int> ReadCountAsync(bool isDeleted = false)
        {
            return await _context.Contact.Where(c => c.IsDeleted == isDeleted).CountAsync();
        }

        public async Task<IContact> UpdateAsync(IContact contact, string name, string email, string mobilePhone, string jobTitle, DateTime? BirthDate)
        {
            contact.Name = name;
            contact.Email = email;
            contact.MobilePhone = mobilePhone;
            contact.JobTitle = jobTitle;
            contact.BirthDate = BirthDate;

            await _context.SaveChangesAsync();

            return contact;
        }

        public async Task<IContact> UpdateAsync(IContact contact, bool isDeleted)
        {
            contact.IsDeleted = isDeleted;

            await _context.SaveChangesAsync();

            return contact;
        }
    }
}
