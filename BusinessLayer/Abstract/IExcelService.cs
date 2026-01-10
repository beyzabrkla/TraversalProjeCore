using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IExcelService
    {
        byte[] ExcelList<T>(List<T> t) where T : class;
    }
}
