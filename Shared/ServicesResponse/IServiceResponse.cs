using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ServicesResponse
{
    public interface IServiceResponse
    {
        string[] Errors { get; }
        bool HasError { get; }
    }
}
