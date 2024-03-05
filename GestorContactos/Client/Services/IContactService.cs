using GestorContactos.Shared;

namespace GestorContactos.Client.Services
{
    public interface IContactService
    {
        Task Savecontact( Contact contact );

        Task DeleteContact( int id );

        Task<IEnumerable<Contact>> GetAllContacts();

        Task<Contact> GetContactById( int id );
    }
}