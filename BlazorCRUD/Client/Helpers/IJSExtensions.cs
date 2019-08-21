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
    }
}
