$(function () {
    if (supports_html5_storage) {
        if (sessionStorage.Skin) {
            changeSkin();
        }

        if (sessionStorage.HoverMenus) {
            changeHoverMenus();
        }
    }

    $('.skin-chooser-toggle').click(function () {
        $('.skin-chooser-wrap').toggleClass('show');
    });

    $('.color-skin').on('click', function (e) {
        if (supports_html5_storage) {
            sessionStorage.Skin = $(this).attr('id');

            changeSkin();
        }
        else {
            alert('Your browser does not support HTML5 Session Storage');
        }
    });

    $('#hovermenus').change(function () {
        if (supports_html5_storage) {
            sessionStorage.HoverMenus = $(this).is(':checked');

            changeHoverMenus();

            location.reload();
        }
        else {
            alert('Your browser does not support HTML5 Session Storage');
        }
    });
});

function supports_html5_storage() {
    try {
        return 'localStorage' in window && window['localStorage'] !== null;
    }
    catch (e) {
        return false;
    }
}

function changeSkin() {
    $('body').removeClass (function (index, css) {
        return (css.match (/\bcolor-skin-\S+/g) || []).join(' ');
    });

    $('body').addClass(sessionStorage.Skin);

    $('.color-skin').removeClass('active');
    $('#' + sessionStorage.Skin).addClass('active');
}

function changeHoverMenus() {
    if (sessionStorage.HoverMenus == 'true') {
        var fileref = document.createElement('script')
        fileref.setAttribute("type", "text/javascript")
        fileref.setAttribute("src", "/Themes/PJS.ReTouch/scripts/hovermenus.js")
        document.getElementsByTagName("body")[0].appendChild(fileref)

        $('#hovermenus').prop('checked', true);
    }
    else {
        $("script[src='/Themes/PJS.ReTouch/scripts/hovermenus.js']").remove()

        $('#hovermenus').prop('checked', false);
    }
}