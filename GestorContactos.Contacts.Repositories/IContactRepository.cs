using GestorContactos.Shared;

namespace GestorContactos.Contacts.Repositories
{
    public interface IContactRepository
    {
        Task<bool> CreateContact( Contact contact );

        Task<Contact> GetContactById( int id );

        Task<IEnumerable<Contact>> GetAllContacts();

        Task<bool> UpdateContact( Contact contact );

        Task DeleteContact( int id );
    }
}