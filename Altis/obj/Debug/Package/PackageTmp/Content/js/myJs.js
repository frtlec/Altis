var currentDate;
var response;
var holidays = null;

$(document).ready(function () {
    GetEtkinlikler();

    //Ay ları değiştirince'de tetiklenecek
    $(document).on('click', '.ui-datepicker-next,.ui-datepicker-prev', function () {
        MousemoveHoverBind();
        
    });

});



//Etkinlikleri getirdik
function GetEtkinlikler() {
    var jqxhr = $.get("/Blog/jsonEtkinlikler", function (data) {
        holidays = data;
        console.log(data);
    })
        .done(function () {

            DatepickerBind();
            MousemoveHoverBind();

        })
        .fail(function () {
            alert("error");
        })
        .always(function () {
            //alert("finished");
        });
}

//Etkinlik Detayı
function EtkinlikDetay(date, element) {
    var jqxhr = $.get("/Blog/jsonEtkinlikDetay/" + date, function (data) {
        response = data;
        console.log(data);
    })
        .done(function () {
            $('<p class="tooltip"></p>')
                .html(response)
                .appendTo('body')
                .fadeIn('slow');
           
            // alert("second success");
        })
        .fail(function () {
            // alert("error");
        })
        .always(function () {
            //alert("finished");
        });
}

function DatepickerBind() {
    $("#from").datepicker({
        beforeShowDay: function (date) {

            var datestring = jQuery.datepicker.formatDate('yy-mm-dd', date);
            if (holidays.indexOf(datestring) === -1) {
                return [true, '', ''];
            }
            else {
                //etkinlik tarihleri dizimizle uyuşuyorsa etkinlik adında class ekledik element e
                return [true, "etkinlik", datestring];
            }

        }

    }).change(function (e) {
        setTimeout(function () {
            MousemoveHoverBind();
        });
    });
}

function MousemoveHoverBind() {

    // Tooltip only Text
    $('.etkinlik > a').hover(function () {
        //üzerine geldiğinde tarihi post ettik
        currentDate = $(this).parent().attr("title");
        EtkinlikDetay(currentDate, this);

        //maouse ilse üzerne gelince title attribute ünü remo ettik
        $(this).parent().removeAttr('title');

    }, function () {
        //Mouse üzerinden gidince title attribute ünü tekrar ekledik
        $(this).parent().attr('title', currentDate);
        $('.tooltip').remove();
    }).mousemove(function (e) {
        //tooltip in mouse un yanında çıkmasını sağladık
        var mousex = e.pageX + 20; //Get X coordinates
        console.log(mousex);
        var mousey = e.pageY + 10; //Get Y coordinates
        $('.tooltip').css({ top: mousey, left: mousex })
    });
}