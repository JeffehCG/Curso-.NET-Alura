using Alura.ListaLeitura.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.HttpClients
{
    public class AuthApiClient
    {
        private readonly HttpClient _httpClient;

        public AuthApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginResult> PostLoginAsync(LoginModel model)
        {
            // Enviando model no Body como Json
            var response = await _httpClient.PostAsJsonAsync("login", model);
            return new LoginResult
            {
                Succeeded = response.IsSuccessStatusCode,
                Token = await response.Content.ReadAsStringAsync()
            };
        }
    }
}
