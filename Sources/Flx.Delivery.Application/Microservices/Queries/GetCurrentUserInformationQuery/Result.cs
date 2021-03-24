namespace Flx.Delivery.Application.Microservices.Queries.GetCurrentUserInformationQuery
{
    public sealed class Result
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
