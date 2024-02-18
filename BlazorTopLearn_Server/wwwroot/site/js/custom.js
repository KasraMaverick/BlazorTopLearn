window.ShowToastr = (type, message) => {
    if (type === 'success') {
        toastr.success(message, 'عملیات مورد نظر با موفقیت انجام شد');
    }
    if (type === 'error') {
        toastr.error(message, 'عملیات با شکست مواجه شد');
    }
}