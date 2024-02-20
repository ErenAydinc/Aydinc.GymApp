using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Application.Services.TempDataService;
public class TempDataManager : ITempDataService
{
    //private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory
    public string GetTempData(string key)
    {
        throw new NotImplementedException();
    }
}
