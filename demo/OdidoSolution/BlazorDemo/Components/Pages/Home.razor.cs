using BlazorDemo.Repositories;
using EntityFrameworkDemo;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.Components.Pages;

public partial class Home
{
    [Inject] public IProductRepository ProductRepository { get; set; } = null!;

    public int Counter { get; set; }
    public List<ProductEntity>? Products { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await GetProducts();
    }

    public async Task GetProducts()
    {
        Products = (await ProductRepository.GetAll()).ToList();
    }

    public void Increment()
    {
        Counter += 5;
        // throw new NotImplementedException("go away");
    }
}
