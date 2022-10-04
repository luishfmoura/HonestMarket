var globalSearch = $('#globalSearch');
function createDataTable(div, columns, data) {
    let id = $(div).attr('id') + "_table";

    div.html('<table id="' + id + '"></table>');

    let table = document.getElementById(id);

    $(table).addClass('table-hover');
    var oTable = $(table).DataTable({
        data: data,
        columns: columns,
        scrollX: false,
        scrollY: "100%",
        scrollCollapse: true,
        destroy: true,
        processing: false,
        searching: true,
        paging: true,
        ordering: true,
        responsive: true,
        autoWidth: false,
        info: true,
        bUseRendered: false,
        bFilter: false,
        language: {
            search: "",
            searchPlaceholder: "Pesquisar",
            lengthMenu: "",
            zeroRecords: "Nenhum registro encontrado",
            info: "Página _PAGE_ de _PAGES_",
            infoEmpty: " ",
            infoFiltered: "(_TOTAL_ de _MAX_ registros)",
            decimal: ',',
            thousands: '.'
        },
        columnDefs: [
            {
                className: "dt-center",
                targets: "_all"
            }
        ]
    });

    globalSearch.keyup(() => {
        oTable.search(globalSearch.val()).draw();
    });

    loading(false);
}

function showAlert(message, type, url, title) {
    loading(false);

    switch (type.toUpperCase()) {
        case "INFO":
            type = "info";
            title = title == null ? "Atenção" : title;
            break;
        case "ALERT":
            type = "warning";
            title = title == null ? "Atenção" : title;
            break;
        case "ERROR":
            type = "error";
            title = title == null ? "Erro" : title;
            break;
        case "SUCCESS":
            type = "success";
            title = title == null ? "Sucesso" : title;
            break;
        default:
            type = "info";
            title = title == null ? "Atenção" : title;
    }

    swal({
        title: title,
        text: message,
        type: type
    }).then(function () {
        if (url) {
            window.location = url;
        }
    });
}

function loading(state = true) {
    let b = $('.loading');
    if (state && b.hasClass('d-none')) {
        b.removeClass('d-none');
    }
    else {
        b.addClass('d-none');
    }
}