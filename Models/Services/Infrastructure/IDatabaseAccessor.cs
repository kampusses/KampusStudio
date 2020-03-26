using System;
using System.Data;
using System.Threading.Tasks;

namespace KampusStudio.Models.Services.Infrastructure
{
    public interface IDatabaseAccessor
    {
        Task<DataSet> QueryAsync(FormattableString query); 
    }
}