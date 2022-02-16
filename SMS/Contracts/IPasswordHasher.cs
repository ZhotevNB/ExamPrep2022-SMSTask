namespace SMS.Contracts
{
    public interface IPasswordHasher
    {
        public string HashPassword(string password);
    }
}
