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
        public async Task<IContact> CreateAsync(string name, string email, string mobilePhone, string jobTitle, DateTime BirthDate)
        {
            var entity = _serviceProvider.GetRequiredService<IContact>();

            entity.Id = Guid.NewGuid();
            entity.Name = name;
            entity.Email = email;
            entity.MobilePhone = mobilePhone;
            entity.JobTitle = jobTitle;
            entity.BirthDate = BirthDate;

            var contact = await _context.Contact.AddAsync((ContactEntity)entity);

            await _context.SaveChangesAsync();

            return contact.Entity;
        }

        public async Task<IEnumerable<IContact>> ReadAllAsync()
        {
            return await _context.Contact.ToListAsync();
        }
    }
}
