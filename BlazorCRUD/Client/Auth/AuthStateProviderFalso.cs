using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorCRUD.Client.Auth
{
    public class AuthStateProviderFalso : AuthenticationStateProvider
    {
        //Determina si el usuario esta autenticado o no 
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
              
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
        }
    }
}
