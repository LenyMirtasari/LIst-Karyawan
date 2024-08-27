// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.



// Write your JavaScript code.

/*Halaman List Karyawan*/
$(document).ready(function () {
        $('#table_id').DataTable({
            'ajax': {
                'url': "/Karyawan/ListKaryawans",
                'dataSrc': ''
            },
            'columns': [
                
                {
                    "Data": "no",
                    "render": function (data, type, row, meta) {
                        return meta.row + meta.settings._iDisplayStart + 1;
                    }
                },
                {
                    "data": "nrp",
                },
                {
                    "data": "nama",
                },
                {
                    "data": "nO_TLP",
                  
                },
                {
                    "data": "email",
                   
                },
               
                {
                    "Data": "",
                    "render": function (data, type, row, meta) {
                        return `<input type="checkbox" name="id[]" value="${row['nrp']}">`
     }

},
],
columnDefs: [
{
    "targets": "_all",
    "defaultContent": "-"
}
]
});
});

$(function () {
    $('#save_value').click(function () {
        var val = [];
        $(':checkbox:checked').each(function (i) {
            val[i] = $(this).val();
            
            $.ajax({
                url: "/Karyawan/InsertKaryawan/",
                type: "POST",
                data: { nrp: val[i] }
            }).done((result) => {
                console.log(result)
                if (result == 200) {
                    Swal.fire(
                        'Good job!',
                        'Data Inserted!',
                        'success'
                    )
                    $('#table_karyawan').DataTable().ajax.reload();

                } else if (result == 400) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: ' Already Existed !'
                    })
                }

            }).fail((error) => {
                console.log(error)
                if (error == 400) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: ' !'
                    })
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: ' Failed !'
                    })
                }
            })
        });
    });
});

$(document).ready(function () {
    $('#table_karyawan').DataTable({
        'ajax': {
            'url': "/Karyawan/DataKaryawan",
            'dataSrc': ''
        },
        'columns': [

            {
                "Data": "no",
                "render": function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "data": "nrp",
            },
            {
                "data": "nama",
            },
            {
                "data": "nO_TLP",

            },
            {
                "data": "email",

            },
             
            {
                data: null,
                "render": function (data, type, row, meta) {
     
                    return `
                            <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#karyawanModal" onclick="ModalUpdate('${data.nrp}')" >
                              Update
                            </button>
                            <button type="button" class="btn btn-danger" onclick="Delete('${data.nrp}')">Delete</button>`
                }

            },
        ],
        columnDefs: [
            {
                "targets": "_all",
                "defaultContent": "-"
            }
        ]
    });
});

function Delete(nrp) {
    console.log( nrp)
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        console.log(result);
        if (result.isConfirmed == true) {
            $.ajax({
                url: "/Karyawan/DeleteData",
                type: "Delete",
                data: { nrp: nrp }
            }).then((result) => {
                console.log(result);
                if (result == 200) {
                    Swal.fire(
                        'Deleted!',
                        'Your data has been deleted.',
                        'success'
                    )
                    $('#table_karyawan').DataTable().ajax.reload();
                }
            })
        }
    })
}


function ModalUpdate(nrp) {
   
    $.ajax({

        type: "GET",
        url: 'Karyawan/DataUpdate/',
        contentType: "application/json; charset=utf-8",
        data: { nrp: nrp },
        dataType: "json",
        success: function (data) {
            console.log(data);
            $("#nrp1").val(data.nrp);
            $("#Nama1").val(data.nama);
            $("#NoTelp1").val(data.nO_TLP);
            $("#Email1").val(data.email);
        }
    })

    
}



$("#FormUpdate").validate({
    rules: {
        Nama: {
            required: true
        },
        NoTelp: {
            required: true
        },
        Email: {
            required: true,
        }
    },
    errorPlacement: function (error, element) {
        error.insertAfter(element);
    },
    highlight: function (element) {
        $(element).closest('.form-control').addClass('is-invalid');
    },
    unhighlight: function (element) {
        $(element).closest('.form-control').removeClass('is-invalid');
    }
});

function UpdateValidation(nrp) {
    var a = $("#FormUpdate").valid();
    console.log(a);
    if (a == true) {
        Update(nrp)
        console.log(a)
    } else {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Update Failed!',
            footer: 'All columns must be filled !'

        })
    }
}

function Update(nrp) {
    console.log('tesy');
    console.log(nrp);
    console.log($("#Nama1").val())
    var obj = {
        NRP : $("#nrp1").val(),
        NAMA : $("#Nama1").val(),
        NO_TLP : $("#NoTelp1").val(),
        EMAIL : $("#Email1").val()
    }
/*    var obj = new Object();
    obj.NRP = $("#nrp1").val();
    obj.NAMA = $("#Nama1").val();
    obj.NO_TELP = $("#NoTelp1").val();
    obj.EMAIL = $("#Email1").val();*/
    console.log(obj.NO_TLP);
    $.ajax({
        type: "PUT",
        url: "Karyawan/UpdateData",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(obj),
        dataType: "json",
    }).then((result) => {
        console.log(result);
        if (result == 200) {
            Swal.fire(
                'Good job!',
                'Data Updated!',
                'success'
            )
            $("#karyawanModal").modal("toggle"),
                $('#karyawanModal').modal('hide'),
                $('#table_karyawan').DataTable().ajax.reload();
        } else {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Update Failed!',
                footer: 'All columns must be filled !'
            })
        }

    })
}

  

 /*   $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "/Karyawan/DataKaryawan",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                //JSON.stringify(data);
                console.log(data);
                $("#DIV").html('');
                var DIV = '';
                $.each(data, function (i, item) {
                    console.log(item.nrp, i)
                    var rows = "<tr>" +
                        "<td id='RegdNo'>" + item.nrp + "</td>" +
                        "<td id='Name'>" + item.nama + "</td>" +
                        "<td id='Address'>" + item.nO_TLP + "</td>" +
                        "<td id='PhoneNo'>" + item.email + "</td>" +

                        "</tr>";
                    $('#table_id').append(rows);
                }); //End of foreach Loop   
                console.log(data);
            }, //End of AJAX Success function  

            failure: function (data) {
                alert(data.responseText);
            }, //End of AJAX failure function  
            error: function (data) {
                alert(data.responseText);
            } //End of AJAX error function  

        });
    })*/