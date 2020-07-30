using RestorauntManagement.Models;
using System.Collections.Generic;

namespace RestorauntManagement.Repositories.Interfaces
{
    public interface ITableRepository
    {
        Table GetByName(string tableName);
        List<Table> GetAll();
        void Add(Table newTable);
        Table GetById(int tableId);
        void Update(Table table);
    }
}
