namespace BlazorBrowserConsoleUi.Core.Utils;

public static class TestData
{
    public static IEnumerable<Person> GetPeople()
    {
        return new[]
        {
            new Person
            {
                Id = Guid.NewGuid(),
                Firstname = "John",
                Lastname = "Doe",
                Email = "john@doe.com",
                Phone = "1234567890",
            },
            new Person
            {
                Id = Guid.NewGuid(),
                Firstname = "Jane",
                Lastname = "Doe",
                Email = "jane@doe.com",
                Phone = "0987654321",
            }
        };
    }
}