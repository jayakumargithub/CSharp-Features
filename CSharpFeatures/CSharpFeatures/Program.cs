using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFeatures
{
    class Program
    {
        static void Main(string[] args)
        {

            //Added test line
            //Implicit convertion
            Customer customer = new Customer();
            CustomerDTO customerDTO = new CustomerDTO();
            customer = customerDTO;

            Address address = new Address();
            AddressDTO addressDTO = new AddressDTO();
            address = addressDTO;

        }
    }


    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaxID { get; set; }
        public Status Active { get; set; }
        public ICollection<Address> Addresses { get; set; }

        public static implicit operator Customer(CustomerDTO v)
        {
            Customer customer = new Customer
            {
                Active = v.active, 
                Id = v.id,
                Name = v.name,
                TaxID = v.taxid
            };
            v.addresses.ToList().ForEach(e => customer.Addresses.ToList().Add(e));
            return customer;
        }
    }

    public class Address
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public int CustomerId { get; set; } 

        public static implicit operator Address(AddressDTO aDto)
        {

            Address address = new Address()
            {
                Id = aDto.id,
                Address1 = aDto.address1,
                City = aDto.city,
                CustomerId = aDto.Customerid, 
           
            };
            return address;
        }

       // public static implicit operator CustomerDTO(Customer entityObject)
        //{
        //    CustomerDTO returnObject = new CustomerDTO()
        //    {
        //        taxid = entityObject.TaxID,
        //        name = entityObject.Name,
        //        id = entityObject.Id,
        //        active = (Status)Enum.Parse(typeof(Status), entityObject.Active)
        //    };

        //    Do this longhand for visibility
        //    Without the implicit operator for AddressDTO we could not use the ().Add(e) without an implicit cast error
        //   entityObject.Addresses.ToList().ForEach(e => returnObject.addresses.ToList().Add(e));


        //    return returnObject;
        //}
}

    public class CustomerDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string taxid { get; set; }
        public Status active { get; set; }
        public IEnumerable<AddressDTO> addresses { get; set; }

        /*
            Error	CS0266	Cannot implicitly convert type 'System.Collections.Generic.ICollection<CSharpFeatures.Address>' to 'System.Collections.Generic.IEnumerable<CSharpFeatures.Address.AddressDTO>'. An explicit conversion exists (are you missing a cast?)	CSharpFeatures	C:\CSharp Features Projects\CSharpFeatures\CSharpFeatures\Program.cs	54	Active
        */

        
    }

    public enum Status
    {
        Inactive, //=0
        Active //=1
    }

    public class AddressDTO
    {
        public int id { get; set; }
        public string address1 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public int Customerid { get; set; } 

        public static implicit operator AddressDTO(Address entityAddress)
        {
            return new AddressDTO
            {
                id = entityAddress.Id,
                address1 = entityAddress.Address1,
                city = entityAddress.City,
                state = entityAddress.State,
                zip = entityAddress.Zip,
                Customerid = entityAddress.CustomerId
            };
        }
    }
}

