using Microsoft.AspNetCore.Mvc;

namespace Web.Controller;
public class FileController : ControllerBase {

  [HttpGet("file/{fileName}/download")]
  public IActionResult DownloadBackup(string fileName) {
        string pathToBackupFolder = Path.Combine(Directory.GetCurrentDirectory(), "Backups");
        string filePath = Path.Combine(pathToBackupFolder, fileName);

        if (!System.IO.File.Exists(filePath)) return NotFound("Sorry, the file does not exist.");

        // Generic MIME type for binary files
        string contentType = "application/octet-stream";
        return File(System.IO.File.ReadAllBytes(filePath), contentType, fileName);
    }
}
