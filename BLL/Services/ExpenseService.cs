using AutoMapper;
using BLL.DTOs;
using CsvHelper;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace BLL.Services
{
    public class ExpenseService
    {
        private static readonly IMapper mapper;

        static ExpenseService()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Expense, ExpenseDTO>();
            });
            mapper = cfg.CreateMapper();
        }

        public static ExpenseDTO Create(ExpenseDTO expenseDto)
        {
            var expense = mapper.Map<Expense>(expenseDto);
            var createdExpense = DataAccessFactory.ExpenseData().Create(expense);
            return mapper.Map<ExpenseDTO>(createdExpense);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.ExpenseData().Delete(id);
        }

        public static List<ExpenseDTO> Get()
        {
            var data = DataAccessFactory.ExpenseData().Read();
            return mapper.Map<List<ExpenseDTO>>(data);
        }

        public static ExpenseDTO Get(int id)
        {
            var data = DataAccessFactory.ExpenseData().Read(id);
            return mapper.Map<ExpenseDTO>(data);
        }

        public static ExpenseDTO Update(ExpenseDTO expenseDto)
        {
            var expense = mapper.Map<Expense>(expenseDto);
            var updatedExpense = DataAccessFactory.ExpenseData().Update(expense);
            return mapper.Map<ExpenseDTO>(updatedExpense);
        }

        public static List<ExpenseDTO> GetByCategory(string category)
        {
            var data = DataAccessFactory.ExpenseData().ReadByCategory(category);
            return mapper.Map<List<ExpenseDTO>>(data);
        }

        public static List<ExpenseDTO> GetByDate(DateTime date)
        {
            var data = DataAccessFactory.ExpenseData().ReadByDate(date);
            return mapper.Map<List<ExpenseDTO>>(data);
        }

        public static List<ExpenseDTO> GetRecurring()
        {
            var data = DataAccessFactory.ExpenseData().ReadRecurring();
            return mapper.Map<List<ExpenseDTO>>(data);
        }


        public static byte[] ExportToCSV()
        {
            var data = DataAccessFactory.ExpenseData().Read();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Expense, ExpenseDTO>();
            });
            var mapper = new Mapper(config);
            var expenses = mapper.Map<List<ExpenseDTO>>(data);

            using (var memoryStream = new MemoryStream())
            using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
            using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords(expenses);
                streamWriter.Flush();
                return memoryStream.ToArray();
            }
        }
    }
}
