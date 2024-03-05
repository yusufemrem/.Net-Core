using BusinessLayer.Abstract;
using DtoLayer.Contact;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactMessageController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactMessageController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("NotificationBox")]
        public IActionResult NotificationBox()
        {
            var values = _contactService.GetList();
            return Ok(values);
        }

        [HttpPost("SendMessage")]
        public IActionResult SendMessage(ContactMessageDto contactMessageDto)
        {
            Contact contact = new Contact
            {
                ContactID = contactMessageDto.ContactID,
                ContactUserName = contactMessageDto.ContactUserName,
                ContactSubject = contactMessageDto.ContactSubject,
                ContactMessage = contactMessageDto.ContactMessage,
                ContactDate = DateTime.Now.Date
            };
            _contactService.TAdd(contact);
            return Ok();
        }
    }
}
