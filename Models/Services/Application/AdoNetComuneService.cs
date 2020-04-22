using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using kampus.Models.ValueTypes;
using KampusStudio.Models.InputModels;
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
        public async Task<ComuneViewModel> GetComuneAsync(string id)
        {
            FormattableString query = $"SELECT * FROM comuni WHERE codiceCatastale={id}";
            DataSet dataSet = await db.QueryAsync(query);
            var comuneTable = dataSet.Tables[0];
            if (comuneTable.Rows.Count != 1)
            {
                throw new InvalidOperationException($"Mi aspettavo che venisse restituita solo una riga della tabella {id}");
            }
            var comuneRow = comuneTable.Rows[0];
            var comuneViewModel = ComuneViewModel.FromDataRow(comuneRow);

            FormattableString queryReg = $"SELECT * FROM regioni WHERE codiceRegione={comuneRow["regione"]}";
            DataSet dataSetReg = await db.QueryAsync(queryReg);
            var regioneTable = dataSetReg.Tables[0];
            if (regioneTable.Rows.Count != 1)
            {
                throw new InvalidOperationException($"Mi aspettavo che venisse restituita solo una riga della tabella {comuneRow["regione"]}");
            }
            var regioneRow = regioneTable.Rows[0];
            var regioneViewModel = RegioneViewModel.FromDataRow(regioneRow);
            comuneViewModel.regione = (RegioneViewModel) regioneViewModel;


            FormattableString queryPro = $"SELECT * FROM province WHERE codiceProvincia={comuneRow["provincia"]}";
            DataSet dataSetPro = await db.QueryAsync(queryPro);
            var provinciaTable = dataSetPro.Tables[0];
            if (provinciaTable.Rows.Count != 1)
            {
                throw new InvalidOperationException($"Mi aspettavo che venisse restituita solo una riga della tabella {comuneRow["provincia"]}");
            }
            var provinciaRow = provinciaTable.Rows[0];
            var provinciaViewModel = ProvinciaViewModel.FromDataRow(provinciaRow);
            comuneViewModel.provincia = (ProvinciaViewModel) provinciaViewModel;

            return comuneViewModel;
        }

        public async Task<ListViewModel<ComuneViewModel>> GetComuniAsync(ComuneElencoInputModel model)
        {
            string direction = model.Ascending ? "ASC" : "DESC";
            FormattableString query = $@"SELECT * FROM comuni WHERE nomeComune LIKE {"%" + model.Search + "%"} AND cap LIKE {"%" + model.Cap + "%"} AND prefisso LIKE {"%" + model.Prefisso + "%"} ORDER BY {(Sql) model.OrderBy} {(Sql) direction} LIMIT {model.Limit} OFFSET {model.Offset}; 
            SELECT COUNT(*) FROM comuni WHERE nomeComune LIKE {"%" + model.Search + "%"} AND cap LIKE {"%" + model.Cap + "%"} AND prefisso LIKE {"%" + model.Prefisso + "%"}";
            DataSet dataSet = await db.QueryAsync(query);
            var dataTable = dataSet.Tables[0];
            var comuneList = new List<ComuneViewModel>();
            foreach(DataRow comuneRow in dataTable.Rows)
            {
                ComuneViewModel comune = ComuneViewModel.FromDataRow(comuneRow);
                // Questo codice dovrebbe essere interamente sostituito con la funzione GetRegioneAsync -- INIZIO
                FormattableString queryReg = $"SELECT * FROM regioni WHERE codiceRegione={comuneRow["regione"]}";
                DataSet dataSetReg = await db.QueryAsync(queryReg);
                var regioneTable = dataSetReg.Tables[0];
                if (regioneTable.Rows.Count != 1)
                {
                    throw new InvalidOperationException($"Mi aspettavo che venisse restituita solo una riga della tabella {comuneRow["regione"]}");
                }
                var regioneRow = regioneTable.Rows[0];
                // Questo codice dovrebbe essere interamente sostituito con la funzione GetRegioneAsync -- FINE
                var regioneViewModel = RegioneViewModel.FromDataRow(regioneRow);
                comune.regione = (RegioneViewModel) regioneViewModel;

                // Questo codice dovrebbe essere interamente sostituito con la funzione GetProvinciaAsync -- INIZIO
                FormattableString queryPro = $"SELECT * FROM province WHERE codiceProvincia={comuneRow["provincia"]}";
                DataSet dataSetPro = await db.QueryAsync(queryPro);
                var provinciaTable = dataSetPro.Tables[0];
                if (provinciaTable.Rows.Count != 1)
                {
                    throw new InvalidOperationException($"Mi aspettavo che venisse restituita solo una riga della tabella {comuneRow["provincia"]}");
                }
                var provinciaRow = provinciaTable.Rows[0];
                // Questo codice dovrebbe essere interamente sostituito con la funzione GetProvinciaAsync -- FINE
                var provinciaViewModel = ProvinciaViewModel.FromDataRow(provinciaRow);
                comune.provincia = (ProvinciaViewModel) provinciaViewModel;

                comuneList.Add(comune);
            }
            ListViewModel<ComuneViewModel> result = new ListViewModel<ComuneViewModel>
            {
                Results = comuneList,
                TotalCount = Convert.ToInt32(dataSet.Tables[1].Rows[0][0])
            };
            return result;
        } 
    }
}