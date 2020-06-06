using Alura.ListaLeitura.Modelos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Lista = Alura.ListaLeitura.Modelos.ListaLeitura;

namespace Alura.ListaLeitura.HttpClients
{
    public class LivroApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _accessor;

        public LivroApiClient(HttpClient httpClient, IHttpContextAccessor accessor)
        {
            // BaseAddress definido em Startup
            _httpClient = httpClient;
            _accessor = accessor; // Permite o acesso ao contexto http da aplicação .net core / Para utilizalo é preciso adicionar sua configuração em Startup
            AddBearerToken();
        }

        private void AddBearerToken()
        {
            // Recuperando o token dos cookies do usuario
            var token = _accessor.HttpContext.User.Claims.First(c => c.Type == "Token").Value;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //_httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }

        public async Task<LivroApi> GetLivroAsync(int id)
        {
            // Consumindo API
            HttpResponseMessage response = await _httpClient.GetAsync($"livros/{id}");

            // Caso o response não retorne um status de sucesso EnsureSuccessStatusCode(); dispara uma Exception
            response.EnsureSuccessStatusCode();

            // Convertendo Resposta da API em Objeto desejado
            var livro = await response.Content.ReadAsAsync<LivroApi>();

            return livro;
        }

        public async Task<byte[]> GetCapaLivroAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"livros/{id}/capa");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsByteArrayAsync();
        }

        public async Task DeleteLivroAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"livros/{id}");
            response.EnsureSuccessStatusCode();

        }

        public async Task<Lista> GetListaLeituraAsync(TipoListaLeitura tipo)
        {
            var response = await _httpClient.GetAsync($"listasleitura/{tipo}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<Lista>();
        }

        public async Task PostLivroAsync(LivroUpload model)
        {
            HttpContent content = CreateMultipartFormDataContent(model);
            var response = await _httpClient.PostAsync("livros", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task PutLivroAsync(LivroUpload model)
        {
            HttpContent content = CreateMultipartFormDataContent(model);
            var response = await _httpClient.PutAsync("livros", content);
            response.EnsureSuccessStatusCode();
        }

        private HttpContent CreateMultipartFormDataContent(LivroUpload model)
        {
            // Criando conteudo do request para api (Passando pelo Form e não Body)

            var content = new MultipartFormDataContent();

            content.Add(new StringContent(model.Titulo), EnvolveComAspasDuplas("titulo"));
            content.Add(new StringContent(model.Subtitulo), EnvolveComAspasDuplas("subtitulo"));
            content.Add(new StringContent(model.Resumo), EnvolveComAspasDuplas("resumo"));
            content.Add(new StringContent(model.Autor), EnvolveComAspasDuplas("autor"));
            content.Add(new StringContent(model.Lista.ParaString()), EnvolveComAspasDuplas("lista"));

            if (model.Id > 0)
            {
                content.Add(new StringContent(model.Id.ToString()), EnvolveComAspasDuplas("id"));
            }

            if(model.Capa != null)
            {
                var imagemContent = new ByteArrayContent(model.Capa.ConvertToBytes());
                imagemContent.Headers.Add("content-type", "image/png");
                content.Add(
                    imagemContent, // Imagem em Byte
                    EnvolveComAspasDuplas("capa"), // Nome da chave
                    EnvolveComAspasDuplas(model.Capa.FileName)); // Nome do arquivo
            }

            return content;
        }

        private string EnvolveComAspasDuplas(string valor)
        {
            return $"\"{valor}\"";
        }
    }
}
