using RestorauntManagement.Helper;
using RestorauntManagement.Models;
using RestorauntManagement.Repositories.Interfaces;
using RestorauntManagement.Services.Intefaces;
using RestorauntManagement.ViewModels.ActionMessage;
using RestorauntManagement.ViewModels.Table;
using System.Collections.Generic;
using System.Linq;

namespace RestorauntManagement.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository tableRepository;

        public TableService(ITableRepository tableRepository)
        {
            this.tableRepository = tableRepository;
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

        public List<TableOverviewModel> GetAll()
        {
            return tableRepository.GetAll().Select(x => x.ToTableOverviewModel()).ToList();
        }

        public Table GetById(int tableId)
        {
            Table table = tableRepository.GetById(tableId);
            return table;
        }

        public void Reserve(int tableId)
        {
            Table table = tableRepository.GetById(tableId);

            if(table != null)
            {
                table.IsAvailable = false;

                tableRepository.Update(table);
            }
        }
    }
}
