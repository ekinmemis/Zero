/* ------------------------------------------------------------------------------
 *
 *  # Date and time pickers
 *  
 * ---------------------------------------------------------------------------- */


// Setup module
// ------------------------------

var DateTimePickers = function () {

    //
    // Setup module components
    //

    // Daterange picker
    var _componentDaterange = function () {
        if (!$().daterangepicker) {
            console.warn('Warning - daterangepicker.js is not loaded.');
            return;
        }
        // Single picker
        $('.datepicker').daterangepicker({
            singleDatePicker: true,
            showDropdowns: true,
            locale: {
                applyLabel: 'Tamam',
                cancelLabel: 'İptal',
                startLabel: 'Başlangıç',
                endLabel: 'Bitiş',
                //customRangeLabel: 'Выбрать дату',
                daysOfWeek: ['Pzr', 'Pts', 'Sl', 'Çrş', 'Per', 'Cum', 'Cts'],
                monthNames: ['Ocak', 'Şubat', 'Mart', 'Nisan', 'Mayıs', 'Haziran', 'Temmuz', 'Ağustos', 'Eylül', 'Ekim', 'Kasım', 'Aralık'],
                firstDay: 1,
                format: 'DD/MM/YYYY'
            }
        });
    };
    //
    // Return objects assigned to module
    //
    return {
        init: function () {
            _componentDaterange();
        }
    };
}();


// Initialize module
// ------------------------------

document.addEventListener('DOMContentLoaded', function () {
    DateTimePickers.init();
});
