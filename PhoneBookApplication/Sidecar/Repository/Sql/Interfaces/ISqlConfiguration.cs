using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApplication.Sidecar.Repository.Sql.Interfaces
{
    public interface ISqlConfiguration
    {
        string ConnectionString { get; set; }
    }
}
