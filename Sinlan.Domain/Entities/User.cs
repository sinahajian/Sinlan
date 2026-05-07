namespace Sinlan.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHashed { get; private set; }
    //public List<UserWord> UserWords { get; set; } = new List<UserWord>();
    public void SetPassword(string HashedPassword)
    {
        PasswordHashed = HashedPassword;
    }

}
