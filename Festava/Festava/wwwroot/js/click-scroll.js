//jquery-click-scroll
//by syamsul'isul' Arifin

var sectionArray = [1, 2, 3, 4, 5, 6];

$(document).on('scroll', function () {
    $.each(sectionArray, function (index, value) {
        var offsetSection = $('#' + 'section_' + value).offset().top - 83;
        var docScroll = $(document).scrollTop();
        var docScroll1 = docScroll + 1;

        if (docScroll1 >= offsetSection) {
            $('.navbar-nav .nav-item .nav-link').removeClass('active');
            $('.navbar-nav .nav-item .nav-link:link').addClass('inactive');
            $('.navbar-nav .nav-item .nav-link').eq(index).addClass('active');
            $('.navbar-nav .nav-item .nav-link').eq(index).removeClass('inactive');
        }
    });
});

$.each(sectionArray, function (index, value) {
    $('.click-scroll').eq(index).on('click', function (e) {
        var offsetClick = $('#' + 'section_' + value).offset().top - 83;
        e.preventDefault(); // Prevent default anchor behavior
        $('html, body').animate({
            'scrollTop': offsetClick
        }, 300);
    });
});

$(function () {
    $('.navbar-nav .nav-item .nav-link:link').addClass('inactive');
    $('.navbar-nav .nav-item .nav-link').eq(0).addClass('active');
    $('.navbar-nav .nav-item .nav-link:link').eq(0).removeClass('inactive');
});

// Prevent default behavior for subscribe button
$('.form-control').on('click', function (e) {
    e.preventDefault(); // Prevent default anchor behavior
    // Your subscription logic here
});