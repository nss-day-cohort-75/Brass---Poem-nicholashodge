
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
using System.Text;

List<ProductType> productTypes = new List<ProductType>(){
    new ProductType(){
        Title = "Brass Instrument",
        Id = 1
    },
    new ProductType(){
        Title = "Poem",
        Id = 2
    }
};
//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<Product> products = new List<Product>(){
    new Product(){
        Name = "Trumpet",
        Price = 299.99M,
        ProductTypeId = 1
    },
    new Product(){
        Name = "The Complete Collection of Edgar Allen Poe",
        Price = 49.99M,
        ProductTypeId = 2
    },
    new Product(){
        Name = "The Road Not Taken by Robert Frost",
        Price = 9.99M,
        ProductTypeId = 2
    },
    new Product(){
        Name = "Trombone",
        Price = 249.99M,
        ProductTypeId = 1
    },
    new Product(){
        Name = "French Horn",
        Price = 329.99M,
        ProductTypeId = 2
    },
    new Product(){
        Name = "Four Quartets by T.S. Eliot",
        Price = 12.99M,
        ProductTypeId = 2
    }
};
//put your greeting here
string greeting = @"Welcome to Brass & Poem, your one-stop shop for music and muses!";
Console.WriteLine(greeting);

//implement your loop here
string choice = null;
while(choice != "5"){
    DisplayMenu();
    choice = Console.ReadLine();
    switch(choice){
        case "1":
        DisplayAllProducts(products, productTypes);
        break;
        
        case "2":
        DeleteProduct(products, productTypes);
        break;

        case "3":
        AddProduct(products, productTypes);
        break;

        case "4":
        UpdateProduct(products, productTypes);
        break;

        case "5":
        break;

        default:
        Console.WriteLine("Please make a valid selection");
        break;
    }
}

void DisplayMenu()
{
    //
    Console.WriteLine(@"
1. Display all products
2. Delete a product
3. Add a new product
4. Update product properties
5. Exit");

}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    int count = 1;
    Console.WriteLine(@"
    ~~~~~~~~~~~~~~~~~~~~
    Products
    ~~~~~~~~~~~~~~~~~~~~");
    foreach(Product product in products){
        ProductType pt = productTypes.FirstOrDefault(productTyping => productTyping.Id == product.ProductTypeId);
        Console.WriteLine($"{count}. {product.Name} - ${product.Price} ({pt.Title})");
        count++;
    }

}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);
    Console.WriteLine("Enter the number of the product to delete");
    int chosenProduct = int.Parse(Console.ReadLine()) - 1;
    products.RemoveAt(chosenProduct);
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Product newProduct = new Product() {
        Name = null,
        Price = 0.00M,
        ProductTypeId = 0
    };
    Console.WriteLine("Enter Product Name:");
    newProduct.Name = Console.ReadLine();
    Console.WriteLine("Enter Product Price:");
    newProduct.Price = decimal.Parse(Console.ReadLine());
    foreach(ProductType productType in productTypes){
        Console.WriteLine($"{productType.Id}. {productType.Title}");
    }
    Console.WriteLine("Choose a product type");
    newProduct.ProductTypeId = int.Parse(Console.ReadLine());
    products.Add(newProduct);
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    //display and prompt input
    DisplayAllProducts(products, productTypes);
    Console.WriteLine("Enter the number of the product to edit");
    int chosenProduct = int.Parse(Console.ReadLine()) - 1;
    //enter name
    Console.WriteLine("Enter a new product name (leave blank to keep current name)");
    string newName = Console.ReadLine().Trim();
    products[chosenProduct].Name = string.IsNullOrEmpty(newName) ? products[chosenProduct].Name : newName;
    //enter price
    Console.WriteLine("Enter a new product price (leave blank to keep current price)");
    string newPrice = Console.ReadLine().Trim();
    products[chosenProduct].Price = string.IsNullOrEmpty(newPrice) ? products[chosenProduct].Price : decimal.Parse(newPrice);
    //select productType
    foreach(ProductType productType in productTypes){
        Console.WriteLine($"{productType.Id}. {productType.Title}");
    }
    Console.WriteLine("Choose a new product type (leave blank to keep current product type)");
    string newProductType = Console.ReadLine().Trim();
    products[chosenProduct].ProductTypeId = string.IsNullOrEmpty(newProductType) ? products[chosenProduct].ProductTypeId : int.Parse(newProductType);
}

// don't move or change this!
public partial class Program { }