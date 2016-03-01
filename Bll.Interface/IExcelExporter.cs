using System.Collections.Generic;
using Dal.Interface;

namespace Bll.Interface
{
    public interface IExcelExporter
    {
        void Export(List<PartyModel> exportItems, string serverPath);
    }
}
