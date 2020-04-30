using CO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CO.Services
{
    public interface ICaseService
    {
        Case AddCase(Case c);

        Dictionary<string, Case> GetCases();
    }
}
