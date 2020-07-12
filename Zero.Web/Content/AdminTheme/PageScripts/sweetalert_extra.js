var SweetAlert = function () {

    // Sweet Alerts
    var _componentSweetAlert = function () {
        if (typeof swal === 'undefined') {
            console.warn('Warning - sweet_alert.min.js is not loaded.');
            return;
        }

        // Defaults
        var swalInit = swal.mixin({
            buttonsStyling: false,
            confirmButtonClass: 'btn btn-primary',
            cancelButtonClass: 'btn btn-light'
        });

        $('#swal-delete').on('click', function () {
            swalInit({
                title: 'Silmek istediğinize emin misiniz?',
                text: "Silinen veriler geri alınamaz!",
                type: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Evet, Sil!',
                cancelButtonText: 'Hayır!',
                confirmButtonClass: 'btn btn-danger',
                cancelButtonClass: 'btn btn-default',
                buttonsStyling: false
            }).then(function (result) {
                if (result.value) {
                    $.ajax({
                        method: "POST",
                        url: $("#swal-delete").data("delete-action"),
                        dataType: "json",
                        success: function (data) {
                            if (data === "OK") {
                                swalInit({
                                    title: 'Silme işlemi başarılı!',
                                    type: 'success',
                                    showCloseButton: true
                                });
                                setTimeout(function () { document.location.href = $("#swal-delete").data("redirect-url"); }, 3000);
                            } else {
                                swalInit({
                                    title: 'Silme işlemi başarısız!',
                                    type: 'error',
                                    showCloseButton: true
                                });
                            }
                        }
                    });
                }
            });
        });
    };

    return {
        initComponents: function () {
            _componentSweetAlert();
        }
    };
}();

// Initialize module
// ------------------------------

document.addEventListener('DOMContentLoaded', function () {
    SweetAlert.initComponents();
});