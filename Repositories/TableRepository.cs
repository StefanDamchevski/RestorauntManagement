using Microsoft.EntityFrameworkCore;
using RestorauntManagement.Models;
using RestorauntManagement.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RestorauntManagement.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly RestorauntManagementDbContext context;

        public TableRepository(RestorauntManagementDbContext context)
        {
            this.context = context;
        }

        public void Add(Table newTable)
        {
            context.Tables.Add(newTable);
            context.SaveChanges();
        }

        public List<Table> GetAll()
        {
            return context.Tables.ToList();
        }

        public Table GetById(int tableId)
        {
            return context.Tables
                .Include(x => x.Receipts)
                    .ThenInclude(x => x.ProductRecepits)
                        .ThenInclude(x => x.Product)
                .FirstOrDefault(x => x.Id.Equals(tableId));
        }

        public Table GetByName(string tableName)
        {
            return context.Tables.FirstOrDefault(x => x.TableName.Equals(tableName));
        }

        public void Update(Table table)
        {
            context.Tables.Update(table);
            context.SaveChanges();
        }
    }
}
