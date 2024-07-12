public class UserRepository : Repository<User>
{
    public UserRepository(string connectionString) : base(connectionString) { }

    protected override string GetTableName() => "Users";

    protected override string GetColumnNames() => "UserId, UserName, PasswordHash, Email, CreatedDate";

    protected override string GetParameterNames() => "@UserId, @UserName, @PasswordHash, @Email, @CreatedDate";

    protected override string GetUpdateColumnNames() => "UserName = @UserName, PasswordHash = @PasswordHash, Email = @Email";

    protected override User MapToEntity(IDataReader reader)
    {
        return new User
        {
            UserId = (int)reader["UserId"],
            UserName = (string)reader["UserName"],
            PasswordHash = (string)reader["PasswordHash"],
            Email = (string)reader["Email"],
            CreatedDate = (DateTime)reader["CreatedDate"]
        };
    }
}