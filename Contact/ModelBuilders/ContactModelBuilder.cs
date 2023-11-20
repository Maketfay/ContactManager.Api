using Contact.Models;
using Core;
using Infrastucture.Core;
using Infrastucture.Entity;

namespace Contact.ModelBuilders
{
    public class ContactModelBuilder
    {
        public PagedList<ContactModel> Build(IPagedList<IContact> contactPage)
        {
            var contactModels = contactPage.Items.Select(c => Build(c));

            return new PagedList<ContactModel>
            {
                Items = contactModels,
                CurrentPage = contactPage.CurrentPage,
                PageSize = contactPage.PageSize,
                TotalItemsCount = contactPage.TotalItemsCount
            };
        }

        public ContactModel Build(IContact contact)
        {
            return new ContactModel 
            {
                Id = contact.Id,
                Email = contact.Email,
                Name = contact.Name,
                BirthDate = contact.BirthDate,
                JobTitle = contact.JobTitle,
                MobilePhone = contact.MobilePhone
            };
        }
    }
}
