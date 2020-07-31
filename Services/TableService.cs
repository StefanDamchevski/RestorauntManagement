using RestorauntManagement.Helper;
using RestorauntManagement.Models;
using RestorauntManagement.Repositories.Interfaces;
using RestorauntManagement.Services.Intefaces;
using RestorauntManagement.ViewModels.ActionMessage;
using RestorauntManagement.ViewModels.Product;
using RestorauntManagement.ViewModels.Table;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestorauntManagement.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository tableRepository;
        private readonly IProductService productService;

        public TableService(ITableRepository tableRepository, IProductService productService)
        {
            this.tableRepository = tableRepository;
            this.productService = productService;
        }

        public ActionMessage Add(string tableName)
        {
            ActionMessage response = new ActionMessage();

            Table table = tableRepository.GetByName(tableName);

            if (table == null)
            {
                Table newTable = new Table();
                newTable.TableName = tableName;
                newTable.IsAvailable = true;

                tableRepository.Add(newTable);


                response.Message = "Table succesfuly created";
            }
            else
            {
                response.Error = $"Table {tableName} already exists";
            }

            return response;
        }

        public void AddProductsToTable(int tableId, List<AddToTableProductModel> products)
        {
            List<Product> dbProducts = productService.GetAllIds(products.Select(x => x.Id).ToList());
            Table table = tableRepository.GetById(tableId);
            Receipt receipt = table.Receipts.FirstOrDefault(x => !x.DateClosed.HasValue);

            List<Product> updatedProducts = new List<Product>();

            foreach (var product in products)
            {
                Product current = dbProducts.FirstOrDefault(x => x.Id.Equals(product.Id));
                current.Quantity -= product.Quantity;

                receipt.ProductRecepits.Add(new ProductRecepit() 
                {
                    ProductId = product.Id,
                    ReceiptId = receipt.Id,
                    Quantity = product.Quantity,
                    Price = current.Price,
                });

                updatedProducts.Add(current);
            }

            productService.UpdateRange(updatedProducts);
            tableRepository.Update(table);

        }

        public void Close(int tableId)
        {
            Table table = tableRepository.GetById(tableId);

            if(table != null)
            {
                table.IsAvailable = true;

                Receipt tableRecept = table.Receipts.FirstOrDefault(x => !x.DateClosed.HasValue);
                tableRecept.DateClosed = DateTime.Now;

                tableRepository.Update(table);
            }
        }

        public List<TableOverviewModel> GetAll()
        {
            return tableRepository.GetAll().Select(x => x.ToTableOverviewModel()).ToList();
        }

        public Table GetById(int tableId)
        {
            Table table = tableRepository.GetById(tableId);
            return table;
        }

        public void Reserve(int tableId, string name)
        {
            Table table = tableRepository.GetById(tableId);

            if(table != null)
            {
                table.IsAvailable = false;
                table.ServedBy = name;

                Receipt receipt = new Receipt();
                receipt.TableId = table.Id;
                receipt.DateCreated = DateTime.Now;

                table.Receipts.Add(receipt);

                tableRepository.Update(table);
            }
        }
    }
}
