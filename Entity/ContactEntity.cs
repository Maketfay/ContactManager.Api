using Infrastucture.Entity;

namespace Entity
{
    public class ContactEntity: IContact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
