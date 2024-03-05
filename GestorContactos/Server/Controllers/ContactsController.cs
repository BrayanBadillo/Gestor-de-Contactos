using GestorContactos.Contacts.Repositories;
using GestorContactos.Shared;
using Microsoft.AspNetCore.Mvc;

namespace GestorContactos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController( IContactRepository contactRepository )
        {
            _contactRepository = contactRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync( [FromBody] Contact contact )
        {
            if ( contact == null )
            {
                return BadRequest();
            }

            if ( string.IsNullOrEmpty(contact.FirtsName) )
                ModelState.AddModelError("FirtsName", "First Name Can't be empty");

            if ( string.IsNullOrEmpty(contact.LastName) )
                ModelState.AddModelError("LastName", "LastName Name Can't be empty");

            if ( !ModelState.IsValid )
                return BadRequest(ModelState);

            await _contactRepository.CreateContact(contact);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync( int id, [FromBody] Contact contact )
        {
            if ( contact == null )
            {
                return BadRequest();
            }

            if ( string.IsNullOrEmpty(contact.FirtsName) )
                ModelState.AddModelError("FirtsName", "First Name Can't be empty");

            if ( string.IsNullOrEmpty(contact.LastName) )
                ModelState.AddModelError("LastName", "LastName Name Can't be empty");

            if ( !ModelState.IsValid )
                return BadRequest(ModelState);

            await _contactRepository.UpdateContact(contact);

            return NoContent();
        }

        [HttpGet]
        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            return await _contactRepository.GetAllContacts();
        }

        [HttpGet("{id}")]
        public async Task<Contact> GetContactAsync( int id )
        {
            return await _contactRepository.GetContactById(id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteContactAsync(int id )
        {
            await _contactRepository.DeleteContact(id);
        }
    }
}