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

            // Questo codice dovrebbe essere interamente sostituito con la funzione GetRegioneAsync -- INIZIO
            FormattableString queryCom = $"SELECT * FROM comuni WHERE codiceCatastale={regioneRow["codiceCapoluogo"]}";
            DataSet dataSetCom = await db.QueryAsync(queryCom);
            var comuneTable = dataSetCom.Tables[0];
            if (comuneTable.Rows.Count != 1)
            {
                throw new InvalidOperationException($"Mi aspettavo che venisse restituita solo una riga della tabella {regioneRow["codiceCapoluogo"]}");
            }
            var comuneRow = comuneTable.Rows[0];
            // Questo codice dovrebbe essere interamente sostituito con la funzione GetRegioneAsync -- FINE
            var comuneViewModel = ComuneViewModel.FromDataRow(comuneRow);
            regioneViewModel.codiceCapoluogo = (ComuneViewModel) comuneViewModel;

            return regioneViewModel;
        }

        public async Task<List<RegioneViewModel>> GetRegioniAsync()
        {
            // seleziona tutte le regioni in ordine alfabetico
            FormattableString query = $"SELECT * FROM regioni ORDER BY nomeRegione;";
            DataSet dataSet = await db.QueryAsync(query);
            var dataTable = dataSet.Tables[0];
            var regioneList = new List<RegioneViewModel>();
            foreach(DataRow regioneRow in dataTable.Rows)
            {
                RegioneViewModel regione = RegioneViewModel.FromDataRow(regioneRow);
                // Per ogni regione seleziona il suo capoluogo
                // Questo codice dovrebbe essere interamente sostituito con la funzione GetRegioneAsync -- INIZIO
                FormattableString queryCom = $"SELECT * FROM comuni WHERE codiceCatastale={regioneRow["codiceCapoluogo"]}";
                DataSet dataSetCom = await db.QueryAsync(queryCom);
                var comuneTable = dataSetCom.Tables[0];
                if (comuneTable.Rows.Count != 1)
                {
                    throw new InvalidOperationException($"Mi aspettavo che venisse restituita solo una riga della tabella {regioneRow["codiceCapoluogo"]}");
                }
                var comuneRow = comuneTable.Rows[0];
                // Questo codice dovrebbe essere interamente sostituito con la funzione GetRegioneAsync -- FINE
                var comuneViewModel = ComuneViewModel.FromDataRow(comuneRow);
                regione.codiceCapoluogo = (ComuneViewModel) comuneViewModel;
                


                // Per ogni regione conta il numero dei suoi comuni
                // Questo codice dovrebbe essere interamente sostituito con la funzione GetRegioneAsync -- INIZIO
                FormattableString queryCom2 = $"SELECT COUNT(*) FROM comuni WHERE codiceRegione={regioneRow["codiceRegione"]}";
                DataSet dataSetCom2 = await db.QueryAsync(queryCom2);
                var comuneTable2 = dataSetCom2.Tables[0];
                if (comuneTable2.Rows.Count != 1)
                {
                    throw new InvalidOperationException($"Mi aspettavo che venisse restituita solo una riga della tabella {regioneRow["codiceCapoluogo"]}");
                }
                regione.numComuni = (int)(long) comuneTable2.Rows[0][0];
                // Questo codice dovrebbe essere interamente sostituito con la funzione GetRegioneAsync -- FINE
                
              


                // Per ogni regione conta il numero dei suoi abitanti totali
                // Questo codice dovrebbe essere interamente sostituito con la funzione GetRegioneAsync -- INIZIO
                FormattableString queryCom3 = $"SELECT SUM(abitanti) FROM comuni WHERE codiceRegione={regioneRow["codiceRegione"]}";
                DataSet dataSetCom3 = await db.QueryAsync(queryCom3);
                var comuneTable3 = dataSetCom3.Tables[0];
                if (comuneTable3.Rows.Count != 1)
                {
                    throw new InvalidOperationException($"Mi aspettavo che venisse restituita solo una riga della tabella {regioneRow["codiceCapoluogo"]}");
                }
                regione.abitanti = (int)(decimal) comuneTable3.Rows[0][0];
                // Questo codice dovrebbe essere interamente sostituito con la funzione GetRegioneAsync -- FINE




                
                regioneList.Add(regione);





            }
            return regioneList;
        } 
    }
}