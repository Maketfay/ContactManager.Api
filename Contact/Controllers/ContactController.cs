using Contact.ModelBuilders;
using Contact.Models;
using Contact.Validators;
using Core;
using Infrastucture.Repositories;
using Infrastucture.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contact.Controllers
{
    [Route("contact")]
    public class ContactController: ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly ContactValidator _contactValidator;
        private readonly IContactService _contactService;
        private readonly ContactModelBuilder _contactModelBuilder;

        public ContactController(IContactRepository contactRepository, ContactValidator contactValidator, IContactService contactService, ContactModelBuilder contactModelBuilder)
        {
            _contactRepository = contactRepository;
            _contactValidator = contactValidator;
            _contactService = contactService;
            _contactModelBuilder = contactModelBuilder;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody]ContactCreateModel model) 
        {
            var validModel = _contactValidator.Validate(model);
            if (validModel is null)
                return BadRequest();

            var contact = await _contactRepository.CreateAsync(validModel.Name, validModel.Email, validModel.MobilePhone, validModel.JobTitle, validModel.BirthDate);

            var contactModel = _contactModelBuilder.Build(contact);

            return Ok(contactModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts([FromQuery] PagedModel model) 
        {
            var contacts = await _contactService.GetPagedContactAsync(model.Page, model.PageSize);

            var contactsModel = _contactModelBuilder.Build(contacts);

            return Ok(contactsModel);
        }

        [HttpPut]
        public async Task<IActionResult> ChangeContact([FromBody] ContactChangeModel model)
        {
            var validModel = _contactValidator.Validate(model);

            var contact = await _contactRepository.ReadAsync(model.Id);
            if ((contact is null) || (validModel is null))
                return BadRequest();

            contact = await _contactRepository.UpdateAsync(contact, validModel.Name, validModel.Email, validModel.MobilePhone, validModel.JobTitle, validModel.BirthDate);

            var contactModel = _contactModelBuilder.Build(contact);
            
 
           return Ok(contactModel);
        }

        [HttpDelete]
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
