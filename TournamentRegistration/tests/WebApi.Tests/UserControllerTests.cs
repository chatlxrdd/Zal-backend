using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Xunit;
using WebApi;
using Core.Entities;
using FluentAssertions;

public class UserControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public UserControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetUsers_ReturnsUsers()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/api/user");

        // Assert
        response.EnsureSuccessStatusCode();
        var users = await response.Content.ReadAsAsync<IEnumerable<User>>();
        users.Should().NotBeNull();
    }

    [Fact]
    public async Task PostUser_AddsUser()
    {
        // Arrange
        var client = _factory.CreateClient();
        var user = new User { Username = "testuser", Password = "password", Role = "User" };

        // Act
        var response = await client.PostAsJsonAsync("/api/user", user);

        // Assert
        response.EnsureSuccessStatusCode();
        var createdUser = await response.Content.ReadAsAsync<User>();
        createdUser.Username.Should().Be(user.Username);
    }
}
