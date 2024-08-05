using Aspose.Words;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandlerandAuthetication.Controllers
{
    public class DownloadController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DownloadController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GenerateWordDocumnet([FromBody] Dictionary<string, string> rowData)
        {
            try
            {
                // 抓取範本
                var fileName = rowData.GetValueOrDefault("FileName");
                var printTemplete = $"{fileName}.docx";

                // 輸出檔名
                var outTemplete = $"{fileName}_{DateTime.Now:yyyyMMddHHmmss}.pdf";

                // 讀取現有的Word檔案
                var templatePath = Path.Combine(_webHostEnvironment.ContentRootPath, "App_Data", printTemplete);
                Document doc = new Document(templatePath);

                // 取代WORD中的位置
                foreach (var placeValue in rowData)
                {
                    var placehilder = $"{{{placeValue.Key}}}";
                    doc.Range.Replace(placehilder, placeValue.Value);
                }

                // 儲存生成的文件
                var outputPath = Path.Combine(_webHostEnvironment.ContentRootPath, "App_Data", outTemplete);
                doc.Save(outputPath, Aspose.Words.SaveFormat.Pdf);

                // 返回生成的文件路徑給前端
                return Json(new { FileName = outTemplete });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IActionResult DownloadFile(string fileName)
        {
            // 設定檔案路徑
            var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "App_Data", fileName);

            // 返回文件給前端進行下載
            return PhysicalFile(filePath, "application/octet-stream", fileName);
        }
    }
}
