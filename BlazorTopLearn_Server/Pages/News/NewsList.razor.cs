using Blazor.Business.Repository.IRepository;
using Blazor.Model.NewsDtos;
using BlazorTopLearn_Server.Helpers;
using BlazorTopLearn_Server.Service.IService;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorTopLearn_Server.Pages.News
{
    public partial class NewsList
    {
        #region
        [Inject]
        public INewsRepository NewsRepository { get; set; }

        [Inject]
        public IJSRuntime JsRuntime { get;set; }

        [Inject]
        public IFileUploadService FileUploadService { get; set; }
        #endregion

        private IEnumerable<NewsDTO> News { get; set; } = new List<NewsDTO>();
        private int? DeleteNewsId { get; set; } = null;

        public bool IsProcessing { get; set; } = false;


        protected override async Task OnInitializedAsync()
        {
            News = await NewsRepository.GetAllNews();
        }

        private string ConfirmMessage = "Test Confirmation Message";

        private bool IsConfirmed { get; set; }


        private async Task HandleDelete(int newsId)
        {
            DeleteNewsId = newsId;
            await JsRuntime.InvokeVoidAsync("showConfirmationModal");
        }

        public async Task ConfirmDelete_Click(bool isConfirmed)
        {
            IsProcessing = true;
            if (isConfirmed && DeleteNewsId != null)
            {
                var news = await NewsRepository.GetNewsById(DeleteNewsId.Value);
                FileUploadService.DeleteFile(news.ImageUrl);
                await NewsRepository.RemoveNews(news);
                await JsRuntime.ToastrSuccess("خبر مورد نظر با موفقیت حذف شد");
                News = await NewsRepository.GetAllNews();
            }

            await JsRuntime.InvokeVoidAsync("hideConfirmationModal");
            IsProcessing = false;
        }



        // private async Task TestConfirmBox()
        // {
        //     IsConfirmed = await JsRuntime.InvokeAsync<bool>("confirm", ConfirmMessage);
        // }
        // private async Task TestSuccess()
        // {
        //     await JsRuntime.ToastrSuccess("این یک پیغام موفقیت می باشد");
        // }
        // private async Task TestError()
        // {
        //     await JsRuntime.ToastrError("این یک پیغام خطا می باشد");
        // }
        // private async Task SwalSuccess()
        // {
        //     await JsRuntime.SwalSuccess("عملیات موردنظر با موفقیت انجام شد");
        // }
        // private async Task SwalError()
        // {
        //     await JsRuntime.SwalError("عملیات موردنظر با شکست مواجه شد");
        // }
    }
}
