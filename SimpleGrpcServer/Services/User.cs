namespace SimpleGrpcServer.Services
{
    public class User
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Name { get; internal set; }
    }
}