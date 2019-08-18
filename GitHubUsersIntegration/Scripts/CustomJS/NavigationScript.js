// Sets the active property on the selected nav bar item.
$(document).ready(function () {
    $('.navbar-nav ').find('a[href="' + location.pathname + '"]')
        .closest('a').addClass('active');
});