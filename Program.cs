using System.IO;

var path = "/Users/usuario1/Downloads/";
var files = Directory.GetFiles(path);

string GetCategory(string file)
{
    var extensionFile = Path.GetExtension(file).ToLower();
    return extensionFile switch
    {
        ".html" or ".css" => "Codes",
        ".pdf" or ".docx" => "Docs",
        ".jpg" or ".png" => "Images",
        ".jpeg" or ".gif" => "Images",
        ".xls" or ".xlsx" => "Excels",
        ".pkj" or ".dmg" or ".exe" => "Installers",
        _ => "Others"
    };
}
    
foreach (var file in files)
{
    var category = GetCategory(file);
    var targetDir = Path.Combine(path, category);
    Directory.CreateDirectory(targetDir);

    var targetPath = Path.Combine(targetDir, Path.GetFileName(file));
    File.Move(file, targetPath, overwrite:true);
}