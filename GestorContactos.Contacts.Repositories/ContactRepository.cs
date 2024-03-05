using Dapper;
using GestorContactos.Shared;
using System.Data;

namespace GestorContactos.Contacts.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDbConnection _dbConnection;

        public ContactRepository( IDbConnection dbConnection )
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> CreateContact( Contact contact )
        {
            try
            {
                var sql = @" INSERT INTO Contacts ([FirtsName], [LastName], [Phone], [Address])
                                    VALUES(@FirtsName, @LastName, @Phone, @Address)
                ";

                var result = await _dbConnection.ExecuteAsync(sql, new
                {
                    contact.FirtsName,
                    contact.LastName,
                    contact.Phone,
                    contact.Address
                });

                return result > 0;
            }
            catch ( Exception )
            {
                throw;
            }
        }

        public async Task DeleteContact( int id )
        {
            try
            {
                var sql = @" DELETE
                                    FROM Contacts
                                    WHERE [Id] = @Id";

                var result = await _dbConnection.ExecuteAsync(sql, new { id });
            }
            catch ( Exception )
            {
                throw;
            }
        }

        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            try
            {
                var sql = @"SELECT *
                                    FROM Contacts";

                var result = await _dbConnection.QueryAsync<Contact>(sql);
                return result;
            }
            catch ( Exception )
            {
                throw;
            }
        }

        public async Task<Contact> GetContactById( int id )
        {
            try
            {
                var sql = @"SELECT *
                                    FROM Contacts
                                    WHERE [Id] = @Id";

                var result = await _dbConnection.QueryFirstOrDefault(sql, new { id });
                return result;
            }
            catch ( Exception )
            {
                throw;
            }
        }

        public async Task<bool> UpdateContact( Contact contact )
        {
            try
            {
                var sql = @" UPDATE Contacts
                                    SET [FirtsName] = @FirtsName,
                                        [LastName] = @LastName,
                                        [Phone] = @Phone,
                                        [Address] = @Address
                                    WHERE [Id] = @Id
                ";

                var result = await _dbConnection.ExecuteAsync(sql, new
                {
                    contact.FirtsName,
                    contact.LastName,
                    contact.Phone,
                    contact.Address,
                    contact.Id
                });

                return result > 0;
            }
            catch ( Exception )
            {
                throw;
            }
        }
    }
}