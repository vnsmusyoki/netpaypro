namespace netpaypro.Data.DataModels
{
    public class Country : BaseClass
    {
        public string CountryName { get; set; }

        public string CountryCode { get; set; }


        public ICollection<City> Cities { get; set; }
    }
}
