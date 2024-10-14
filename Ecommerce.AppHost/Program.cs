using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var productApi = builder.AddProject<Ecommerce_ProductService>("apiservice-product");
var orderApi = builder.AddProject<Ecommerce_OrderService>("apiservice-order");

builder.AddProject<Ecommerce_Web>("webfrontend").WithReference(productApi).WithReference(orderApi);

builder.Build().Run();
