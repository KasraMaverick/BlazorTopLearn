using Blazor.Model.NewsDtos;
using BlazorTopLearn_Server.Helpers;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using BlazorTopLearn_Server.Service.IService;
using Blazor.Business.Repository.IRepository;

namespace BlazorTopLearn_Server.Pages.News
{
    public partial class UpsertNews
    {
        #region
        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        [Inject]
        public IFileUploadService FileUploadService { get; set; }

        [Inject]
        public INewsRepository NewsRepository { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        #endregion

        [Parameter]
        public int? Id { get; set; }

        public string Title { get; set; } = "افزودن";

        private NewsDTO NewsModel { get; set; } = new NewsDTO();

        protected override async Task OnInitializedAsync()
        {
            if (Id != null)
            {
                Title = "ویرایش";
                NewsModel = await NewsRepository.GetNewsById(Id.Value);
            }
            else
            {

            }
        }

        private async Task DeleteImage()
        {
            try
            {
                var result = FileUploadService.DeleteFile(NewsModel.ImageUrl);
                if (result)
                {
                    NewsModel.ImageUrl = "";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task HandleUpsertNews()
        {
            try
            {
                var duplicateNews = await NewsRepository.NewsExistsByTitle(NewsModel.Title, NewsModel.NewsId);
                if (duplicateNews != null)
                {
                    await JsRuntime.ToastrError("خبر مورد نظر تکراری می باشد");
                    return;

                }

                if (NewsModel.NewsId != 0)
                {
                    var editResult = await NewsRepository.UpdateNews(NewsModel.NewsId, NewsModel);
                    await JsRuntime.ToastrSuccess("خبر مورد نظر با موفقیت ویرایش شد");
                }
                else
                {
                    var createdResult = await NewsRepository.CreateNews(NewsModel);
                    await JsRuntime.ToastrSuccess("خبر مورد نظر با موفقیت ایجاد شد");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            NavigationManager.NavigateTo("news");

        }

        private async Task HandleImageUpload(InputFileChangeEventArgs e)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(e.File.Name);
                if (fileInfo.Extension.ToLower() == ".jpg" ||
                    fileInfo.Extension.ToLower() == ".png" ||
                    fileInfo.Extension.ToLower() == ".jpeg")
                {
                    NewsModel.ImageUrl = await FileUploadService.UploadFile(e.File);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
