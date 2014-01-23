$(document).ready(function () {
    // jQuery UItoTop
    $().UItoTop({ easingType: 'easeOutQuart' });

    // Breadcrumb
    $('.breadcrumb > .active > a').contents().unwrap();
    $('.breadcrumb').addClass('hidden-xs');

    //PAGINATION
    $('#pagination ul').removeClass('pager').addClass('pagination');
});
