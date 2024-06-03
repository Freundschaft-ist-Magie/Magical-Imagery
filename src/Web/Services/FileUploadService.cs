namespace Web.Services;
public class FileUploadService(IWebHostEnvironment environment) {
  private readonly IWebHostEnvironment _environment = environment;

  public async Task<string> UploadFileAsync(Stream stream, string fileName) {
    string uploadPath = Path.Combine(_environment.WebRootPath, "Images");
    if (!Directory.Exists(uploadPath)) {
      Directory.CreateDirectory(uploadPath);
    }

    string filePath = Path.Combine(uploadPath, fileName);
    using (FileStream fileStream = new(filePath, FileMode.Create)) {
      await stream.CopyToAsync(fileStream);
    }

    return $"/Images/{fileName}";
  }

  public bool DeleteFile(string completePath) {
    if (File.Exists(completePath)) {
      File.Delete(completePath);
      return true;
    }

    return false;
  }
}