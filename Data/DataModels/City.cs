namespace netpaypro.Data.DataModels
{
    public class City : BaseClass
    {
        public string CityName { get; set; }

        public Country Country { get; set; }

        public int CountryId { get; set; }

    }
}
