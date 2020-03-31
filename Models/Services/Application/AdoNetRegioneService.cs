using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KampusStudio.Models.Services.Infrastructure;
using KampusStudio.Models.ViewModels;

namespace KampusStudio.Models.Services.Application
{
    public class AdoNetRegioneService :IRegioneService
    {
        private readonly IDatabaseAccessor db;
        public AdoNetRegioneService(IDatabaseAccessor db)
        {
            this.db = db;
        }
        public async Task<RegioneViewModel> GetRegioneAsync(int id)
        {
            FormattableString query = $"SELECT * FROM regioni WHERE codiceRegione={id}";
            DataSet dataSet = await db.QueryAsync(query);
            var regioneTable = dataSet.Tables[0];
            if (regioneTable.Rows.Count != 1)
            {
                throw new InvalidOperationException($"Mi aspettavo che venisse restituita solo una riga della tabella {id}");
            }
            var regioneRow = regioneTable.Rows[0];
            var regioneViewModel = RegioneViewModel.FromDataRow(regioneRow);
            return regioneViewModel;
        }

        public async Task<List<RegioneViewModel>> GetRegioniAsync()
        {
            FormattableString query = $"SELECT * FROM regioni ORDER BY nomeRegione;";
            DataSet dataSet = await db.QueryAsync(query);
            var dataTable = dataSet.Tables[0];
            var regioneList = new List<RegioneViewModel>();
            foreach(DataRow regioneRow in dataTable.Rows)
            {
                RegioneViewModel regione = RegioneViewModel.FromDataRow(regioneRow);
                regioneList.Add(regione);
            }
            return regioneList;
        } 
    }
}