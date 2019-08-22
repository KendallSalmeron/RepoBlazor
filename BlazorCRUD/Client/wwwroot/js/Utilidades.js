function saveAsFile(filename, byteBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + byteBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

function CustomConfirm(titulo, mensaje, tipo) {
    return new Promise((resolve) => {
        swal.fire({
            title: titulo,
            text: mensaje,
            type: tipo,
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Confirmar'
        }).then((result) => {
            if (result.vale) {
                resolve(true);
            } else {
                resolve(false);
            }
        });

    });
}