using Microsoft.AspNetCore.Components.Forms;
using Models;
using System.Net.Http.Headers;

namespace UI.Pages.Products
{
    public partial class Create
    {
        Product Product { get; set; }

        public List<IBrowserFile> LoadedFiles { get; set; }

        private List<File> files = new();
        private List<UploadResult> uploadResults = new();
        private int maxAllowedFiles = 3;
        private bool shouldRender;
        public Create()
        {
            Product = new();

            LoadedFiles = new();
        }

        protected async Task SaveChangesAsync()
        {
            await _productServices.CreateAsync(Product);
        }

        private async Task OnInputFileChange(InputFileChangeEventArgs e)
        {
            shouldRender = false;
            long maxFileSize = 1024 * 15;
            var upload = false;

            using var content = new MultipartFormDataContent();

            foreach (var file in e.GetMultipleFiles(maxAllowedFiles))
            {
                if (uploadResults.SingleOrDefault(
                    f => f.FileName == file.Name) is null)
                {
                    try
                    {
                        var fileContent =
                            new StreamContent(file.OpenReadStream(maxFileSize));

                        fileContent.Headers.ContentType =
                            new MediaTypeHeaderValue(file.ContentType);

                        files.Add(new() { Name = file.Name });

                        Product.Content.Add(
                            content: fileContent,
                            name: "\"files\"",
                            fileName: file.Name);

                        upload = true;

                        Product.ImagePath = e.File.Name;

                        await _productServices.CreateAsync(Product);

                        await _productServices.UploadImage(Product.Content);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            shouldRender = true;
        }

        private class File
        {
            public string? Name { get; set; }
        }

    }
}

public class UploadResult
{
    public bool Uploaded { get; set; }
    public string? FileName { get; set; }
    public string? StoredFileName { get; set; }
    public int ErrorCode { get; set; }
}