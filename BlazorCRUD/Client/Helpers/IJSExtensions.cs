using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.Client.Helpers
{
    public static class IJSExtensions
    {
        public static Task GuadarComo(this Microsoft.JSInterop.IJSRuntime js, string nombreArchivo, byte[] archivo)
        {
            return js.InvokeAsync<object>("saveAsFile", 
                nombreArchivo,
                Convert.ToBase64String(archivo));
        }

        public static Task MostrarMensaje(this Microsoft.JSInterop.IJSRuntime js, string mensaje)
        {
            return js.InvokeAsync<object>("Swal.fire", mensaje);

        }
        public static Task MostrarMensaje(this Microsoft.JSInterop.IJSRuntime js, string titulo, string mensaje, TipoMensajeSweetAlert tipoMensajeSweetAlert)
        {
            return js.InvokeAsync<object>("Swal.fire", titulo, mensaje, tipoMensajeSweetAlert.ToString());

        }
        public async static Task<bool> Confirm(this Microsoft.JSInterop.IJSRuntime js, string titulo, string mensaje, TipoMensajeSweetAlert tipoMensajeSweetAlert)
        {
            return await js.InvokeAsync<bool>("CustomConfirm", titulo, mensaje, tipoMensajeSweetAlert.ToString());
        }

        public enum TipoMensajeSweetAlert
        { 
            question, warning, error, success, info
        }
    }
}
