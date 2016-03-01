using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Office.Interop.Excel;
using MenuItem = CommonInterface.MenuItem;

namespace Testing
{
    internal class Program 
    {
        private static void DisplayInExcel(List<MenuItem> list)
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
                    for (var i = 0; i < list.Count; i++)
                    {
                        var menuItem = list[i];
                        worksheets.Cells[i + 1, 1] = menuItem.Name;
                        worksheets.Cells[i + 1, 2] = menuItem.VsemenuUrl;
                    }
                }
                excelApp.DisplayAlerts = false;
                const string folderPath = @"D:\12312312";
                workBook.SaveAs(folderPath);
            }
            finally
            {
                excelApp?.Quit();
            }
        }

        private static void Main(string[] args)
        {
            var list = new List<MenuItem>()
            {
                new MenuItem("Relax", "relax.by"),
                new MenuItem("onliner", "Onliner.by"),
                new MenuItem("Виктория", "victoria.by")
            };
            DisplayInExcel(list);

        }
    }
}
