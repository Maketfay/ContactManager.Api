using Infrastucture.Entity;

namespace Infrastucture.Repositories
{
    public interface IContactRepository
    {
        Task<IContact> CreateAsync(string name, string email, string mobilePhone, string jobTitle, DateTime BirthDate);
        Task<IContact> UpdateAsync(IContact contact, string name, string email, string mobilePhone, string jobTitle, DateTime BirthDate);
        Task<IEnumerable<IContact>> ReadAllAsync();
        Task<IContact?> ReadAsync(Guid id);
    }
}
