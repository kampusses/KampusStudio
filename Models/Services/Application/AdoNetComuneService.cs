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
            throw new System.NotImplementedException();
        }

        public List<ComuneViewModel> GetComuni()
        {
            string query = "SELECT * FROM comuni";
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