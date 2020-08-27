using System.Collections.Generic;
using System.Threading.Tasks;
using LimeHome.BackEnd.Demo.Models;

namespace LimeHome.BackEnd.Demo.DataAccess
{
    public interface IHereApi
    {
        Task<IEnumerable<Property>> GetProperties(double latitude, double longitude);
    }
}
