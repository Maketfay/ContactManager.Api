using Contact.Models;

namespace Contact.Validators
{
    public class ContactValidator
    {
        public ContactCreateModel Validate(ContactCreateModel model)
        {
            if (model is null || string.IsNullOrWhiteSpace(model.Name))
                return null;

            if (model.Name.Equals(string.Empty))
                return null;

            if(model.JobTitle is null)
                model.JobTitle = string.Empty;

            if (model.Email is null)
                model.Email = string.Empty;

            if (!model.MobilePhone.Contains("+"))
                model.MobilePhone = model.MobilePhone.Insert(0, "+");

            return model;
        }

        public ContactChangeModel Validate(ContactChangeModel model)
        {
            if (model is null || string.IsNullOrWhiteSpace(model.Name))
                return null;

            if (!model.MobilePhone.Contains("+"))
                model.MobilePhone = model.MobilePhone.Insert(0, "+");

            return model;
        }
    }
}
