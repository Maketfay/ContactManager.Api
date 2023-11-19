namespace Infrastucture.Entity
{
    public interface IContact
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string MobilePhone { get; set; }
        string Email { get; set; }
        string JobTitle { get; set; }
        DateTime BirthDate { get; set; }
        bool IsDeleted { get; set; }
    }
}
