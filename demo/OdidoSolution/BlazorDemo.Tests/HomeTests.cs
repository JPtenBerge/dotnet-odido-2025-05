using BlazorDemo.Components.Pages;
using BlazorDemo.Repositories;
using EntityFrameworkDemo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BlazorDemo.Tests;

//class FakeProductRepository : IProductRepository
//{
//    public bool HasGetAllBeenCalled { get; set; } = false;
//    public Task<IEnumerable<ProductEntity>> GetAll()
//    {
//        HasGetAllBeenCalled = true;
//        return Task.FromResult(new List<ProductEntity>
//        {
//            new() { Description = "test product 1", Price = 12d }
//        }.AsEnumerable());
//    }
//}

// mock framework:  Moq
// FakeItEasy  NSubstitute



[TestClass]
public sealed class HomeTests
{
    Home _sut;

    [TestInitialize] // runs before every test
    public void Init()
    {
        _sut = new Home(); // system under test
    }

    // Method_State_ExpectedBehavior

    [TestMethod]
    public async Task OnInitialized_CallsRepositoryAndStoresProducts()
    {
        // Arrange (setup/init)
        var mockProductRepo = new Mock<IProductRepository>();
        mockProductRepo.Setup(x => x.GetAll()).ReturnsAsync(new List<ProductEntity>
        {
            new() { Description = "test product 1", Price = 12d },
            new() { Description = "test product 2", Price = 34d },
        });
        _sut.ProductRepository = mockProductRepo.Object;

        // Act
        await _sut.GetProducts();

        // Assert
        mockProductRepo.Verify(x => x.GetAll());
        Assert.AreEqual(2, _sut.Products!.Count);
    }

    [TestMethod]
    public void Increment_FromZero_IncrementsTo5()
    {
        //ArrangeWithCertainBits();

        //Assert.AreEqual(4, 4);
        //Assert.AreNotEqual("hi", "bye");

        _sut.Increment();
        Assert.AreEqual(5, _sut.Counter);
    }

    [TestMethod]
    public void Increment_NonFiveValueCounter_IncrementsWithoutRounding()
    {
        _sut.Counter = 16;
        _sut.Increment();
        Assert.AreEqual(21, _sut.Counter);
    }
}
