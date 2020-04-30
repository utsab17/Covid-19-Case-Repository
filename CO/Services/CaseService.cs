using CO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CO.Services
{
    public class CaseService : ICaseService
    {

        private readonly Dictionary<string, Case> _caseList;

        public CaseService()
        {
            _caseList = new Dictionary<string, Case>();
        }
        public Case AddCase(Case c)
        {
            _caseList.Add(c.Name, c);
            return c;
            
        }

        public Dictionary<string, Case> GetCases()
        {
            return _caseList;
        }
    }
}
