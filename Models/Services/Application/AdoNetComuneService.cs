using System;
using System.Collections.Generic;
using System.Data;
using KampusStudio.Models.Services.Infrastructure;
using KampusStudio.Models.ViewModels;

namespace KampusStudio.Models.Services.Application
{
    public class AdoNetComuneService : IComuneService
    {
        private readonly IDatabaseAccessor db;
        public AdoNetComuneService(IDatabaseAccessor db)
        {
            this.db = db;
        }
        public ComuneViewModel GetComune(string id)
        {
            FormattableString query = $"SELECT * FROM comuni WHERE codiceCatastale={id}";
            DataSet dataSet = db.Query(query);
            var comuneTable = dataSet.Tables[0];
            if (comuneTable.Rows.Count != 1)
            {
                throw new InvalidOperationException($"Mi aspettavo che venisse restituita solo una riga della tabella {id}");
            }
            var comuneRow = comuneTable.Rows[0];
            var comuneViewModel = ComuneViewModel.FromDataRow(comuneRow);
            return comuneViewModel;
        }

        public List<ComuneViewModel> GetComuni()
        {
            FormattableString query = $"SELECT * FROM comuni ORDER BY nomeComune LIMIT 20;";
            DataSet dataSet = db.Query(query);
            var dataTable = dataSet.Tables[0];
            var comuneList = new List<ComuneViewModel>();
            foreach(DataRow comuneRow in dataTable.Rows)
            {
                ComuneViewModel comune = ComuneViewModel.FromDataRow(comuneRow);
                comuneList.Add(comune);
            }
            return comuneList;
        } 
    }
}