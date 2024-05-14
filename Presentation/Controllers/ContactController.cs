using BusinessLogic.DTO;
using BusinessLogic.Result;
using BusinessLogic.Services;
using DataAccess.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Presentation.Extensions;

namespace Presentation.Controllers
{
    [Route("api/contact")]
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly UserManager<UserEntity> _userManager;

        public ContactController(ILogger<ContactController> logger, IContactService contactService, UserManager<UserEntity> userManager)
        {
            _contactService = contactService;
            _userManager = userManager;
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> AddContact(ContactDto newContact)
        {
            var user = await _userManager.GetUserAsync(User);

            var result = await _contactService.AddContactAsync(newContact, user.UserName);

            if (result.ResultType == ResultType.Invalid || result.ResultType == ResultType.Unexpected)
            {
                return BadRequest(result.Errors);
            }

            return CreatedAtAction(nameof(GetContact), new { id = result.Data.Id }, result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _contactService.GetAllContactsAsync(user.UserName);
            return this.FromResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _contactService.GetContactAsync(id, user.UserName);
            return this.FromResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveContact(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _contactService.DeleteAsync(id, user.UserName);
            return this.FromResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(Guid id, ContactDto newContact)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _contactService.UpdateContactAsync(id, newContact, user.UserName);
            return this.FromResult(result);
        }
    }
}
