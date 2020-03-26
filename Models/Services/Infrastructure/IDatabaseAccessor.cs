using System;
using System.Data;

namespace KampusStudio.Models.Services.Infrastructure
{
    public interface IDatabaseAccessor
    {
        DataSet Query(FormattableString query); 
    }
}