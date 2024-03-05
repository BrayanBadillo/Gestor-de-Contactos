namespace GestorContactos.Shared
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirtsName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public string FullName
        {
            get
            {
                return FirtsName + " " + LastName;
            }
        }
    }
}