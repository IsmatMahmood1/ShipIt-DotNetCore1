//[HttpGet("{warehouseId}")]
//public InboundOrderResponse Get([FromRoute] int warehouseId)
//{
//    Log.Info("orderIn for warehouseId: " + warehouseId);

//    var operationsManager = new Employee(_employeeRepository.GetOperationsManager(warehouseId));

//    Log.Debug(String.Format("Found operations manager: {0}", operationsManager));

//    var allStock = _stockRepository.GetStockByWarehouseId(warehouseId);

//    var orderlinesByCompany = new Dictionary<string, List<InboundOrderLine>>();
//    var companiesWithOrder = new List<Company>();//

//    foreach (var stock in allStock)
//    {

//        Product product = new Product(_productRepository.GetProductById(stock.ProductId));
//        if (stock.held < product.LowerThreshold && !product.Discontinued)
//        {
//            if (companiesWithOrder.Where(x => x.Gcp == product.Gcp) == null)
//            {
//                Company company = new Company(_companyRepository.GetCompany(product.Gcp));
//                companiesWithOrder.Add(company);//
//            }

//            var orderQuantity = Math.Max(product.LowerThreshold * 3 - stock.held, product.MinimumOrderQuantity);

//            if (!orderlinesByCompany.ContainsKey(product.Gcp))
//            {
//                orderlinesByCompany.Add(product.Gcp, new List<InboundOrderLine>());
//            }

//            orderlinesByCompany[product.Gcp].Add(
//                new InboundOrderLine()
//                {
//                    gtin = product.Gtin,
//                    name = product.Name,
//                    quantity = orderQuantity
//                });
//        }
//    }

//    Log.Debug(String.Format("Constructed order lines: {0}", orderlinesByCompany));

//    var orderSegments = orderlinesByCompany.Select(ol => new OrderSegment()
//    {
//        OrderLines = ol.Value,
//        Company = companiesWithOrder.Single(x => x.Gcp == ol.Key)
//    });

//    Log.Info("Constructed inbound order");

//    return new InboundOrderResponse()
//    {
//        OperationsManager = operationsManager,
//        WarehouseId = warehouseId,
//        OrderSegments = orderSegments
//    };
//}