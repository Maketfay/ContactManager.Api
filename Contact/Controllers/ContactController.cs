using Contact.Models;
using Contact.Validators;
using Infrastucture.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Contact.Controllers
{
    public class ContactController: ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly ContactValidator _contactValidator;
        public ContactController(IContactRepository contactRepository, ContactValidator contactValidator)
        {
            _contactRepository = contactRepository;
            _contactValidator = contactValidator;
        }

        [HttpPost("contact")]
        public async Task<IActionResult> CreateContact([FromBody] ContactCreateModel model) 
        {
            var isModelValid = _contactValidator.Validate(model);
            if(!isModelValid)
                return BadRequest();

            var contact = await _contactRepository.CreateAsync(model.Name, model.Email, model.phoneNumber, model.JobTitle, model.BirthDate);

            return Ok(new ContactModel
            {
                Id = contact.Id,
                Email = contact.Email,
                Name = contact.Name,
                BirthDate = contact.BirthDate,
                JobTitle = contact.JobTitle,
                MobilePhone = contact.MobilePhone
            });
        }

        [HttpGet("contact")]
        public async Task<IActionResult> GetContacts() 
        {
            var contacts = await _contactRepository.ReadAllAsync();

            var contactsModel = contacts.Select(c => new ContactModel {
                Id = c.Id,
                Email = c.Email,
                Name = c.Name,
                BirthDate = c.BirthDate,
                JobTitle = c.JobTitle,
                MobilePhone = c.MobilePhone
            });

            return Ok(contactsModel);
        }

        [HttpPut("contact")]
        public async Task<IActionResult> ChangeContact([FromBody] ContactChangeModel model)
        {
            var contact = await _contactRepository.ReadAsync(model.Id);
            if (contact is null)
                return BadRequest();

            contact = await _contactRepository.UpdateAsync(contact, model.Name, model.Email, model.mobilePhone, model.JobTitle, model.BirthDate);

            return Ok(new ContactModel { 
                Id = contact.Id,
                Email = contact.Email,
                Name = contact.Name,
                BirthDate = contact.BirthDate,
                JobTitle = contact.JobTitle,
                MobilePhone = contact.MobilePhone
            });
        }

        [HttpDelete("contact")]
        public async Task<IActionResult> DeleteContact([FromBody] ContactDeleteModel model)
        {
            var contact = await _contactRepository.ReadAsync(model.Id);
            if (contact is null)
                return BadRequest();

            var result = await _contactRepository.UpdateAsync(contact, isDeleted: true);
            return Ok();
        }
    }
}
