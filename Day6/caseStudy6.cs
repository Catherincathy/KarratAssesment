using Xunit;
using System;

public class User

{

    public string Name { get; set; }

    public int Age { get; set; }

    public string Country { get; set; }

}

public class UserDirectory

{

    private Dictionary<string, User> _users = new Dictionary<string, User>();

    public void AddUser(User user)

    { _users[user.Name] = user; }

    public List<User> GetEligibleUsers()

    {
        return _users.Values

                     .Where(u => u.Age > 59)

                     .ToList();
    }
}


public class UserDirectoryTests
{
    [Fact]
    public void AddUser_ShouldAddUserToDirectory()
    {
        var directory = new UserDirectory();
        var user = new User { Name = "Alice", Age = 65, Country = "USA" };

        directory.AddUser(user);

        var eligibleUsers = directory.GetEligibleUsers();
        Assert.Contains(user, eligibleUsers);
    }

    [Fact]
    public void GetEligibleUsers_ShouldReturnUsersWithAgeGreaterThan59()
    {
        var directory = new UserDirectory();
        var user1 = new User { Name = "Bob", Age = 60, Country = "UK" };
        var user2 = new User { Name = "Charlie", Age = 59, Country = "Canada" };
        var user3 = new User { Name = "Diana", Age = 70, Country = "Australia" };

        directory.AddUser(user1);
        directory.AddUser(user2);
        directory.AddUser(user3);

        var eligibleUsers = directory.GetEligibleUsers();

        Assert.Contains(user1, eligibleUsers);
        Assert.Contains(user3, eligibleUsers);
        Assert.DoesNotContain(user2, eligibleUsers);
        Assert.Equal(2, eligibleUsers.Count);
    }

    [Fact]
    public void AddUser_WithSameName_ShouldUpdateUser()
    {
        var directory = new UserDirectory();
        var user1 = new User { Name = "Eve", Age = 58, Country = "France" };
        var user2 = new User { Name = "Eve", Age = 65, Country = "France" };

        directory.AddUser(user1);
        directory.AddUser(user2);

        var eligibleUsers = directory.GetEligibleUsers();

        Assert.Contains(user2, eligibleUsers);
        Assert.DoesNotContain(user1, eligibleUsers);
        Assert.Single(eligibleUsers);
    }
}