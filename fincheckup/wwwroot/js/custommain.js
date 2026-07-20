$(".lblbilledittto").click(function () {

    var student = {
        "name": $("#txname").val(),
        "mailto": $("#txemail").val(),
        "phone": $("#txphone").val(),
        "education": $("#txlastname").val(),
        "title": "",
        "content": "Teklif Talebi"
    };

    if ($("#txname").val().trim() == "" || $("#txemail").val().trim() == "" || $("#txphone").val().trim() == "" || $("#txlastname").val().trim() == ""  ) {
        Swal.fire({
            type: 'error',
            title: 'Hata...',
            text: 'Lütfen Tüm alanları Doldurunuz',
            footer: 'Bekleniyor'
        });
    }
    else {
        var token = $('input[name="__RequestVerificationToken"]').val();

        $.ajax({
            type: "POST",
            url: "/JsonService/MainPost/SendEmailAskainfo",
            data: { __RequestVerificationToken: token, tmail: student, },
            contentType: "application/x-www-form-urlencoded; charset=utf-8",
            dataType: "json",
            success: function (response) {

                Swal.fire({
                    type: 'success',
                    title: 'Başarılı...',
                    text: 'Mesajınız İletilmiştir',
                    footer: 'Gönderildi'
                });
                $("#txname").val("");
                $("#txemail").val("");
                $("#txphone").val("");
                $("#txlastname").val("");

            },
            failure: function (response) {
                chkbool = "false";
                Swal.fire({
                    type: 'error',
                    title: 'Error...',
                    text: response.d,
                    footer: 'Please Fix Errors First'
                });
            }
        });
    }
  
});

 

function onMasterClick() {
    var womentxt = "MasterKobi  Rapor Paketi Talebi";
    if ($("#txwomen").prop('checked') == true) {
        womentxt = "Kadın Girişimçi MasterKobi  Rapor Paketi Talebi";
    }
    console.log(womentxt);
    var student = {
        "firmname": $("#txtfirmname").val(),
        "firmowner": $("#txtfirmowner").val(),
        "firmvkn": $("#txtfirmvkn").val(),
        "firmnace": $("#txtfirmnace").val(),
        "name": $("#txname").val(),
        "mailto": $("#txemail").val(),
        "phone": $("#txphone").val(),
        "education": $("#txlastname").val(),
        "title": "",
        "content": womentxt
    };

    if ($("#txname").val().trim() == "" || $("#txmastercode").val().trim() == "" || $("#txemail").val().trim() == "" || $("#txphone").val().trim() == "" || $("#txlastname").val().trim() == "") {
        Swal.fire({
            type: 'error',
            title: 'Hata...',
            text: 'Lütfen Tüm alanları Doldurunuz',
            footer: 'Bekleniyor'
        });

        
    }
    else {

        if ($("#txmastercode").val().trim().toLowerCase()!="master24") {
            Swal.fire({
                type: 'error',
                title: 'Hata...',
                text: 'MasterKobi Kampanya Kodu Hatalı',
                footer: 'Bekleniyor'
            });
        }
        else {
            getLoadPanelInstance().show();
            var token = $('input[name="__RequestVerificationToken"]').val();

            $.ajax({
                type: "POST",
                url: "/JsonService/MainPost/SendEmailAskainfomaster",
                data: { __RequestVerificationToken: token, tmail: student, },
                contentType: "application/x-www-form-urlencoded; charset=utf-8",
                dataType: "json",
                success: function (response) {

                    Swal.fire({
                        type: 'success',
                        title: 'Başarılı...',
                        text: 'Mesajınız İletilmiştir',
                        footer: 'Gönderildi'
                    });
                    $("#txname").val("");
                    $("#txemail").val("");
                    $("#txphone").val("");
                    $("#txlastname").val("");
                    $("#txtfirmowner").val("");
                    $("#txtfirmvkn").val("");
                    $("#txtfirmnace").val("");
                    $("#txtfirmname").val("");
                    getLoadPanelInstance().hide();
                },
                failure: function (response) {
                    getLoadPanelInstance().hide();
                    chkbool = "false";
                    Swal.fire({
                        type: 'error',
                        title: 'Error...',
                        text: response.d,
                        footer: 'Please Fix Errors First'
                    });
                }
            });
        }
     
    }

}
function onMasterpackClick() {
    var womentxt = "MasterKobi Düzenli Rapor Paketi Talebi";
    if ($("#txwomen").prop('checked') == true) {
        womentxt = "Kadın Girişimçi MasterKobiDüzenli Rapor Paketi Talebi";
    }
    var student = {
        "firmname": $("#txtfirmname").val(),
        "firmowner": $("#txtfirmowner").val(),
        "firmvkn": $("#txtfirmvkn").val(),
        "firmnace": $("#txtfirmnace").val(),
        "name": $("#txname").val(),
        "mailto": $("#txemail").val(),
        "phone": $("#txphone").val(),
        "education": $("#txlastname").val(),
        "title": "",
        "content": womentxt
    };

    if ($("#txname").val().trim() == "" || $("#txemail").val().trim() == "" || $("#txmastercode").val().trim() == "" || $("#txphone").val().trim() == "" || $("#txlastname").val().trim() == "") {
        Swal.fire({
            type: 'error',
            title: 'Hata...',
            text: 'Lütfen Tüm alanları Doldurunuz',
            footer: 'Bekleniyor'
        });
    }
    else {
        if ($("#txmastercode").val().trim().toLowerCase() != "master24") {
            Swal.fire({
                type: 'error',
                title: 'Hata...',
                text: 'MasterKobi Kampanya Kodu Hatalı',
                footer: 'Bekleniyor'
            });
        } else {
            getLoadPanelInstance().show();
            var token = $('input[name="__RequestVerificationToken"]').val();

            $.ajax({
                type: "POST",
                url: "/JsonService/MainPost/SendEmailAskainfomasterkobi",
                data: { __RequestVerificationToken: token, tmail: student, },
                contentType: "application/x-www-form-urlencoded; charset=utf-8",
                dataType: "json",
                success: function (response) {

                    Swal.fire({
                        type: 'success',
                        title: 'Başarılı...',
                        text: 'Mesajınız İletilmiştir',
                        footer: 'Gönderildi'
                    });
                    $("#txname").val("");
                    $("#txemail").val("");
                    $("#txphone").val("");
                    $("#txlastname").val("");
                    $("#txtfirmowner").val("");
                    $("#txtfirmvkn").val("");
                    $("#txtfirmnace").val("");
                    $("#txtfirmname").val("");
                    getLoadPanelInstance().hide();
                },
                failure: function (response) {
                    getLoadPanelInstance().hide();
                    chkbool = "false";
                    Swal.fire({
                        type: 'error',
                        title: 'Error...',
                        text: response.d,
                        footer: 'Please Fix Errors First'
                    });
                }
            });
        }


       
    }

}

 
$(document).ready(function () {

    if (isIe()) {
        $(".btnchk").hide();

        alert('Sistem Internet Explorer ile Kullanılamaz. Chrome/Mozilla/Opera/Edge üzerinden giriş yapınız!');
    }

});

$(".lblbilleditttozone").click(function () {

    var student = {
        "name": $("#txname").val() + " " + $("#txlastname").val(),
        "mailto": $("#txemail").val(),
        "phone": $("#txphone").val(),
        "education": "",
        "title": "",
        "content": $("#txmessage").val(),
        "content": $("#txmessage").val()
    };

    if ($("#txname").val().trim() == "" || $("#txemail").val().trim() == "" || $("#txphone").val().trim() == "" || $("#txlastname").val().trim() == "" || $("#txmessage").val().trim() == "") {
        Swal.fire({
            type: 'error',
            title: 'Hata...',
            text: 'Lütfen Tüm alanları Doldurunuz',
            footer: 'Bekleniyor'
        });
    }
    else {
        var token = $('input[name="__RequestVerificationToken"]').val();

        $.ajax({
            type: "POST",
            url: "/JsonService/MainPost/SendEmailAska",
            data: { __RequestVerificationToken: token, tmail: student, },
            contentType: "application/x-www-form-urlencoded; charset=utf-8",
            dataType: "json",
            success: function (response) {

                Swal.fire({
                    type: 'success',
                    title: 'Başarılı...',
                    text: 'Mesajınız İletilmiştir',
                    footer: 'Gönderildi'
                });
                $("#txname").val("");
                $("#txlastname").val("");
                $("#txemail").val("");
                $("#txphone").val("");
                $("#txmessage").val("");
            },
            failure: function (response) {
                chkbool = "false";
                Swal.fire({
                    type: 'error',
                    title: 'Error...',
                    text: response.d,
                    footer: 'Please Fix Errors First'
                });
            }
        });
    }


   
});


$("#frm").submit(function () {

    
    $(".btnchk").attr("disabled", true);

    if (grecaptcha.getResponse().length === 0) {
        $(".btnchk").removeAttr("disabled");
        Swal.fire({
            type: 'error',
            title: 'Error...',
            text: 'Bot Testi Hatası',
            footer: 'Hata'
        });
    }
    else {


        var vals = $(this).serialize();

        console.log(vals);
        Swal.fire({
            position: 'top-end',
            icon: 'success',
            title: 'Giriş İşlemleri Yapılıyor',
            showConfirmButton: false,
            timer: 1500
        })
        $.ajax({
            url: "/JsonService/Havvana/LoginProcess",
            method: "POST",
            data: vals,
            success: function (data) {
                if (data == "nok") {
                    $(".btnchk").removeAttr("disabled");
                    Swal.fire({
                        position: 'top-end',
                        icon: 'error',
                        title: 'Lütfen Girilen Bİlgileri Kontrol Ediniz',
                        showConfirmButton: false,
                        timer: 1500
                    })
                }
                else {
                    if (data=="1") {
                        location.href = "/Admin/firmpanel";
                    }
                    else {
                        location.href = "/Admin/qnb/index";
                    }
                }


            }
        });


    }




    return false;
});

function isIe() {
    console.log(window.navigator.userAgent);
    return window.navigator.userAgent.indexOf("MSIE ") > 0
        || window.navigator.userAgent.indexOf("Trident") > 0;

}
