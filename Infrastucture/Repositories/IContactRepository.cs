using Infrastucture.Entity;

namespace Infrastucture.Repositories
{
    public interface IContactRepository
    {
        Task<IContact> CreateAsync(string name, string email, string mobilePhone, string jobTitle, DateTime BirthDate);
        Task<IContact> UpdateAsync(IContact contact, string name, string email, string mobilePhone, string jobTitle, DateTime BirthDate);
        Task<IEnumerable<IContact>> ReadAllAsync(bool isDeleted = false);
        Task<IContact?> ReadAsync(Guid id, bool isDeleted = false);
        Task<IContact> UpdateAsync(IContact contact, bool isDeleted);
    }
}
