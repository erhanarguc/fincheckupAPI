
DevExpress.localization.locale("tr");
var threshold = 100;

$('h3').each(function () {
    var $self = $(this),
        fs = parseInt($self.css('font-size'));

    while ($self.height() > threshold) {
        $self.css({ 'font-size': fs-- });
    }
    $self.height(threshold);
});

toastr.options = {
    "closeButton": true,
    "debug": false,
    "newestOnTop": true,
    "progressBar": true,
    "maxOpened": 1,
    "positionClass": "toast-top-left",
    "preventDuplicates": true,
    "preventOpenDuplicates": true,
    "onclick": null,
    "showDuration": "3000",
    "hideDuration": "1000",
    "timeOut": "10000",
    "allowHtml": true,
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}

var tyear = $("#txtmyear").val();
var mcompid = $("#txtmcomp").val();
function getLoadPanelInstance() {
    return $("#loadPanel").dxLoadPanel("instance");
}
function loadPanel_shown(e) {
    setTimeout(function () {
        e.component.hide();
    }, 7000);
}
var misready = "nok";
var chkReadyState = setInterval(function () {
    if (document.readyState == "complete") {

        clearInterval(chkReadyState);

        misready = "ok";
    }
}, 100);

function getselectYearInstance() {
    return $("#slctYear").dxSelectBox("instance");
}
 
function selectYear_Initialized() {
    getselectYearInstance().option("value", parseInt($("#txtmyear").val()));
    var chkco = parseInt($("#txtyearcount").val());

    if (chkco < 2) {
        getselectYearInstance().option("readOnly", true);
    }


}
 

function selectYear_valueChanged(data) {
    var slctval = data.selectedItem.MYear;
    var turl = '/admin/dashboard?handler=GraphYear&nyear=' + slctval;

    if (misready == "ok" && tyear.toString() != slctval.toString()) {
        getLoadPanelInstance().show();
        $.ajax({
            type: "GET",
            url: turl,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response == "ok") {
                    location.reload();
                }
            },
            failure: function (response) {
                alert(response);
            }
        });
    }

}

 
function onAppointmentFormOpening(e) {
    const form = e.form;
    var recurrenceEditor = form.getEditor("recurrenceRule");
    console.log(form._rootLayoutManager);
    console.log(form._rootLayoutManager._items[0].items[2].items[1]);

    $('.dx-appointment-form-switch').each(function () {
        $(this).css("display", "none");
    });
}


function onItemDelete(data) {

    var pageIndex = data.ID;
    $.ajax({
        url: "/JsonService/Main/GetHtml",
        method: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(pageIndex),
        success: function (dataz) {

            if (dataz == "nok") {
                swal.close();
                Swal.fire(
                    'Hata!',
                    'Bülten Yüklenemedi Bir Sorun Oluştu!',
                    'error'
                )
            }
            else {
                var bodyText = dataz.Description;
                var titlea = dataz.Title;
                var titleb = dataz.SubTitle;
                var titlek = dataz.Kapsam;
                var titlet = dataz.DuzenleyenKurum;
                var titlez = dataz.YururlulukTarih;

                $("#txtitle").text(titlea);
                $("#txtitle1").val(titleb);
                $("#txtitle2").val(titlek);
                $("#txtitle3").val(titlet);
                $("#txtitle4").val(titlez);
                $("#textBlock").prop('innerHTML', bodyText);
                $("#largeModal").modal('show');
            }


        }
    });


}