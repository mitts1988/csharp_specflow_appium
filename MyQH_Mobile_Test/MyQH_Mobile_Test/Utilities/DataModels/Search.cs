
namespace MyQH_Mobile_Test.Utilities.DataModels
{
    class Search {}

    public class CareFinderResponse
    {
        public string? DisplayName { get; set; }
        public string? Telephone { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string? DisplayDistance { get; set; }
        public string? Type { get; set; }
        public new string ToString => DisplayName + " " + Telephone + " " + AddressLine1 + " " +
                AddressLine2 + " " + City + " " + State + " " + Zip + " " + DisplayDistance + " " + Type;

    }

    public class CareFinderRequest
    {
        public string? Name { get; set; }
        public string? FacilityTypeId { get; set; }
        public string? FacilityTypeName { get; set; }
        public string? Zip { get; set; }
        public int Distance { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public Sorts[]? Sorts { get; set; }
        public string? Filters { get; set; }
        public bool InitialSearch { get; set; }
    }
    public class Sorts
    {
        public string? SortProperty { get; set; }
        public string? SortDirection { get; set; }
    }

    public class FacilityType
    {
        public string name { get; set; }
        public string hcbbKey { get; set; }
    }
}
