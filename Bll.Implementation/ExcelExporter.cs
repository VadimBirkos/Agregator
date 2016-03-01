using System;
using System.Collections.Generic;
using Bll.Interface;
using Dal.Interface;
using Microsoft.Office.Interop.Excel;

namespace Bll.Implementation
{
    public class ExcelExporter : IExcelExporter
    {
        public void Export(List<PartyModel> exportItems, string serverPath)
        {
            _Application excelApp = null;
            try
            {
                excelApp = new Application();
                var workBook = excelApp.Workbooks.Add();
                var worksheets = excelApp.Sheets.Add() as Worksheet;
                if (worksheets != null)
                {
                    worksheets.Name = "Sample";
                    for (var i = 0; i < exportItems.Count; i++)
                    {
                        var menuItem = exportItems[i];
                        worksheets.Cells[i + 1, 1] = menuItem.Name;
                        worksheets.Cells[i + 1, 2] = menuItem.Email;
                        worksheets.Cells[i + 1, 3] = menuItem.Site;
                    }
                    worksheets.Columns.ColumnWidth = 50;
                }
                excelApp.DisplayAlerts = false;
                workBook.SaveAs(serverPath + "\\exportData" + DateTime.Now.ToShortDateString().Replace(".", ""));
            }
            finally
            {
                excelApp?.Quit();
            }
        }
    }
}
