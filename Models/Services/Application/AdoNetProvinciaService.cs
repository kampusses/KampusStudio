using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KampusStudio.Models.Services.Infrastructure;
using KampusStudio.Models.ViewModels;

namespace KampusStudio.Models.Services.Application
{
    public class AdoNetProvinciaService :IProvinciaService
    {
        private readonly IDatabaseAccessor db;
        public AdoNetProvinciaService(IDatabaseAccessor db)
        {
            this.db = db;
        }
        public async Task<ProvinciaViewModel> GetProvinciaAsync(int id)
        {
            FormattableString query = $"SELECT * FROM province WHERE codiceProvincia={id}";
            DataSet dataSet = await db.QueryAsync(query);
            var provinciaTable = dataSet.Tables[0];
            if (provinciaTable.Rows.Count != 1)
            {
                throw new InvalidOperationException($"Mi aspettavo che venisse restituita solo una riga della tabella {id}");
            }
            var provinciaRow = provinciaTable.Rows[0];
            var provinciaViewModel = ProvinciaViewModel.FromDataRow(provinciaRow);
            return provinciaViewModel;
        }

        public async Task<List<ProvinciaViewModel>> GetProvinceAsync()
        {
            FormattableString query = $"SELECT * FROM province ORDER BY nomeProvincia;";
            DataSet dataSet = await db.QueryAsync(query);
            var dataTable = dataSet.Tables[0];
            var provinciaList = new List<ProvinciaViewModel>();
            foreach(DataRow provinciaRow in dataTable.Rows)
            {
                ProvinciaViewModel provincia = ProvinciaViewModel.FromDataRow(provinciaRow);
                provinciaList.Add(provincia);
            }
            return provinciaList;
        }
    }
}