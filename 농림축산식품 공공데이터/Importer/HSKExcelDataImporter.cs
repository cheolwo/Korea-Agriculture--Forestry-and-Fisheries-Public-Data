using OfficeOpenXml;
using 농림축산식품_공공데이터.Model;

namespace 농림축산식품_공공데이터.Importer
{
    internal class HSKExcelDataImporter
    {
        private readonly 농축수DbContext _context;

        public HSKExcelDataImporter(농축수DbContext context)
        {
            _context = context;
        }

        public void ImportDataFromExcel(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            using (var package = new ExcelPackage(fileInfo))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    var HSK = new HSK
                    {
                        부류코드 = worksheet.Cells[row, 1].Text,
                        부류명 = worksheet.Cells[row, 2].Text,
                        품목코드 = worksheet.Cells[row, 3].Text,
                        품목명 = worksheet.Cells[row, 4].Text,
                        HSK류코드 = worksheet.Cells[row, 5].Text,
                        HSK류명 = worksheet.Cells[row, 6].Text,
                        HSK호코드 = worksheet.Cells[row, 7].Text,
                        HSK호명 = worksheet.Cells[row, 8].Text,
                        HSK소호코드 = worksheet.Cells[row, 9].Text,
                        HSK소호명 = worksheet.Cells[row, 10].Text,
                        HSK품목코드 = worksheet.Cells[row, 11].Text,
                        HSK품목명 = worksheet.Cells[row, 12].Text,
                        UpdateDate = worksheet.Cells[row, 13].Text
                    };

                    _context.Set<HSK>().Add(HSK);
                }

                _context.SaveChanges();
            }
        }
    }
}
