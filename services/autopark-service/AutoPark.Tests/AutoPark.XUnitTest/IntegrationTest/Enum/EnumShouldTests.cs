using Bms.WEBASE.Models;
using FluentAssertions;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace AutoPark.XUnitTests;

[ExcludeFromCodeCoverage]
public class EnumShouldTests : AuthenticatedTestBase
{
    public EnumShouldTests(CustomWebApiFactory factorygGetToken)
        : base(factorygGetToken)
    {
    }

    [Fact]
    public async Task GenderSelectListAsync_ShouldReturnOk()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/Manual/GenderSelectList");

        // Act
        var response = await ClientRealDb.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();

        // Assert
        var result = response.EnsureSuccessStatusCode();

        if (result.IsSuccessStatusCode)
        {
            json.Should().NotBeNull();
            var selectList = JsonConvert.DeserializeObject<List<SelectListItem<int>>>(json);
            selectList.Should().NotBeNull();
            selectList.Should().HaveCountGreaterThan(0);
        }
        else
            Assert.True(false);
    }

    [Fact]
    public async Task CodeFromTypeSelectListAsync_ShouldReturnOk()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/Manual/CodeFromTypeSelectList");
        // Act
        var response = await ClientRealDb.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        // Assert
        // Assert
        var result = response.EnsureSuccessStatusCode();

        if (result.IsSuccessStatusCode)
        {
            json.Should().NotBeNull();
            var selectList = JsonConvert.DeserializeObject<List<SelectListItem<int>>>(json);
            selectList.Should().NotBeNull();
            selectList.Should().HaveCountGreaterThan(0);
        }
        else
            Assert.True(false);
    }

    [Fact]
    public async Task DocumentTypeSelectListAsync_ShouldReturnOk()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/Manual/DocumentTypeSelectList");
        // Act
        var response = await ClientRealDb.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();

        // Assert
        var result = response.EnsureSuccessStatusCode();

        if (result.IsSuccessStatusCode)
        {
            json.Should().NotBeNull();
            var selectList = JsonConvert.DeserializeObject<List<SelectListItem<int>>>(json);
            selectList.Should().NotBeNull();
            selectList.Should().HaveCountGreaterThan(0);
        }
        else
            Assert.True(false);
    }

    [Fact]
    public async Task LanguageSelectListAsync_ShouldReturnOk()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/Manual/LanguageSelectList");
        // Act
        var response = await ClientRealDb.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        // Assert
        var result = response.EnsureSuccessStatusCode();

        if (result.IsSuccessStatusCode)
        {
            json.Should().NotBeNull();
            var selectList = JsonConvert.DeserializeObject<List<SelectListItem<int>>>(json);
            selectList.Should().NotBeNull();
            selectList.Should().HaveCountGreaterThan(0);
        }
        else
            Assert.True(false);
    }

    [Fact]
    public async Task OilTypeSelectListAsync_ShouldReturnOk()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/Manual/OilTypeSelectList");
        // Act
        var response = await ClientRealDb.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        // Assert
        var result = response.EnsureSuccessStatusCode();

        if (result.IsSuccessStatusCode)
        {
            json.Should().NotBeNull();
            var selectList = JsonConvert.DeserializeObject<List<SelectListItem<int>>>(json);
            selectList.Should().NotBeNull();
            selectList.Should().HaveCountGreaterThan(0);
        }
        else
            Assert.True(false);
    }

    [Fact]
    public async Task BatteryTypeSelectListAsync_ShouldReturnOk()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/Manual/BatteryTypeSelectList");
        // Act
        var response = await ClientRealDb.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        // Assert
        var result = response.EnsureSuccessStatusCode();

        if (result.IsSuccessStatusCode)
        {
            json.Should().NotBeNull();
            var selectList = JsonConvert.DeserializeObject<List<SelectListItem<int>>>(json);
            selectList.Should().NotBeNull();
            selectList.Should().HaveCountGreaterThan(0);
        }
        else
            Assert.True(false);
    }

    [Fact]
    public async Task FuelTypeSelectListAsync_ShouldReturnOk()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/Manual/FuelTypeSelectList");
        // Act
        var response = await ClientRealDb.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        // Assert
        var result = response.EnsureSuccessStatusCode();

        if (result.IsSuccessStatusCode)
        {
            json.Should().NotBeNull();
            var selectList = JsonConvert.DeserializeObject<List<SelectListItem<int>>>(json);
            selectList.Should().NotBeNull();
            selectList.Should().HaveCountGreaterThan(0);
        }
        else
            Assert.True(false);
    }

    [Fact]
    public async Task TransportBrandSelectListAsync_ShouldReturnOk()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/Manual/TransportBrandSelectList");
        // Act
        var response = await ClientRealDb.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        // Assert
        var result = response.EnsureSuccessStatusCode();

        if (result.IsSuccessStatusCode)
        {
            json.Should().NotBeNull();
            var selectList = JsonConvert.DeserializeObject<List<SelectListItem<int>>>(json);
            selectList.Should().NotBeNull();
            selectList.Should().HaveCountGreaterThan(0);
        }
        else
            Assert.True(false);
    }

    [Fact]
    public async Task TransportColorSelectListAsync_ShouldReturnOk()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/Manual/TransportColorSelectList");
        // Act
        var response = await ClientRealDb.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        // Assert
        var result = response.EnsureSuccessStatusCode();

        if (result.IsSuccessStatusCode)
        {
            json.Should().NotBeNull();
            var selectList = JsonConvert.DeserializeObject<List<SelectListItem<int>>>(json);
            selectList.Should().NotBeNull();
            selectList.Should().HaveCountGreaterThan(0);
        }
        else
            Assert.True(false);
    }

    [Fact]
    public async Task TransportModelSelectListAsync_ShouldReturnOk()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/Manual/TransportModelSelectList");
        // Act
        var response = await ClientRealDb.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        // Assert
        var result = response.EnsureSuccessStatusCode();

        if (result.IsSuccessStatusCode)
        {
            json.Should().NotBeNull();
            var selectList = JsonConvert.DeserializeObject<List<SelectListItem<int>>>(json);
            selectList.Should().NotBeNull();
            selectList.Should().HaveCountGreaterThan(0);
        }
        else
            Assert.True(false);
    }

    [Fact]
    public async Task TransportUseTypeSelectListAsync_ShouldReturnOk()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/Manual/TransportUseTypeSelectList");
        // Act
        var response = await ClientRealDb.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        // Assert
        var result = response.EnsureSuccessStatusCode();

        if (result.IsSuccessStatusCode)
        {
            json.Should().NotBeNull();
            var selectList = JsonConvert.DeserializeObject<List<SelectListItem<int>>>(json);
            selectList.Should().NotBeNull();
            selectList.Should().HaveCountGreaterThan(0);
        }
        else
            Assert.True(false);
    }

    [Fact]
    public async Task DepartmentSelectListAsync_ShouldReturnOk()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/Manual/DepartmentSelectList");
        // Act
        var response = await ClientRealDb.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        // Assert
        var result = response.EnsureSuccessStatusCode();

        if (result.IsSuccessStatusCode)
        {
            json.Should().NotBeNull();
            var selectList = JsonConvert.DeserializeObject<List<SelectListItem<int>>>(json);
            selectList.Should().NotBeNull();
            selectList.Should().HaveCountGreaterThan(0);
        }
        else
            Assert.True(false);
    }

    [Fact]
    public async Task PositionSelectListAsync_ShouldReturnOk()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/Manual/PositionSelectList");
        // Act
        var response = await ClientRealDb.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        // Assert
        var result = response.EnsureSuccessStatusCode();

        if (result.IsSuccessStatusCode)
        {
            json.Should().NotBeNull();
            var selectList = JsonConvert.DeserializeObject<List<SelectListItem<int>>>(json);
            selectList.Should().NotBeNull();
            selectList.Should().HaveCountGreaterThan(0);
        }
        else
            Assert.True(false);
    }

    [Fact]
    public async Task BankSelectListAsync_ShouldReturnOk()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/Manual/BankSelectList");
        // Act
        var response = await ClientRealDb.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        // Assert
        var result = response.EnsureSuccessStatusCode();

        if (result.IsSuccessStatusCode)
        {
            json.Should().NotBeNull();
            var selectList = JsonConvert.DeserializeObject<List<SelectListItem<int>>>(json);
            selectList.Should().NotBeNull();
            selectList.Should().HaveCountGreaterThan(0);
        }
        else
            Assert.True(false);
    }

    [Fact]
    public async Task PersonSelectListAsync_ShouldReturnOk()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/Manual/PersonSelectList");
        // Act
        var response = await ClientRealDb.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        // Assert
        var result = response.EnsureSuccessStatusCode();

        if (result.IsSuccessStatusCode)
        {
            json.Should().NotBeNull();
            var selectList = JsonConvert.DeserializeObject<List<SelectListItem<int>>>(json);
            selectList.Should().NotBeNull();
            selectList.Should().HaveCountGreaterThan(0);
        }
        else
            Assert.True(false);
    }

    [Fact]
    public async Task DriverSelectListAsync_ShouldReturnOk()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/Manual/DriverSelectList");
        // Act
        var response = await ClientRealDb.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        // Assert
        var result = response.EnsureSuccessStatusCode();

        if (result.IsSuccessStatusCode)
        {
            json.Should().NotBeNull();
            var selectList = JsonConvert.DeserializeObject<List<SelectListItem<int>>>(json);
            selectList.Should().NotBeNull();
            selectList.Should().HaveCountGreaterThan(0);
        }
        else
            Assert.True(false);
    }

    [Fact]
    public async Task TransportSelectListAsync_ShouldReturnOk()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/Manual/TransportSelectList");
        // Act
        var response = await ClientRealDb.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        // Assert
        var result = response.EnsureSuccessStatusCode();

        if (result.IsSuccessStatusCode)
        {
            json.Should().NotBeNull();
            var selectList = JsonConvert.DeserializeObject<List<SelectListItem<int>>>(json);
            selectList.Should().NotBeNull();
            selectList.Should().HaveCountGreaterThan(0);
        }
        else
            Assert.True(false);
    }

    [Fact]
    public async Task ContractorSelectListAsync_ShouldReturnOk()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/Manual/ContractorSelectList");
        // Act
        var response = await ClientRealDb.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        // Assert
        var result = response.EnsureSuccessStatusCode();

        if (result.IsSuccessStatusCode)
        {
            json.Should().NotBeNull();
            var selectList = JsonConvert.DeserializeObject<List<SelectListItem<int>>>(json);
            selectList.Should().NotBeNull();
            selectList.Should().HaveCountGreaterThan(0);
        }
        else
            Assert.True(false);
    }

    [Fact]
    public async Task ExpenseSelectListAsync_ShouldReturnOk()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/Manual/ExpenseSelectList");
        // Act
        var response = await ClientRealDb.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        // Assert
        var result = response.EnsureSuccessStatusCode();

        if (result.IsSuccessStatusCode)
        {
            json.Should().NotBeNull();
            var selectList = JsonConvert.DeserializeObject<List<SelectListItem<int>>>(json);
            selectList.Should().NotBeNull();
            selectList.Should().HaveCountGreaterThan(0);
        }
        else
            Assert.True(false);
    }
}
