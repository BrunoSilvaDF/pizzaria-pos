namespace Pedidos.API.HttpClients
{
    public class PizzaApiHttpClient
    {
        // 1. Criar um Cliente Http
        public sealed class Client(HttpClient httpClient)
        {
            // apague !!!!!!
            //private static readonly string BaseUrl = "http://pizza-service";

            public async Task<Estoque?> GetEstoque(int pizzaId)
            {
                return await httpClient.GetFromJsonAsync<Estoque>($"/estoque/pizza/{pizzaId}");
            }

            public async Task UpdateEstoque(int pizzaId, int quantidade)
            {
                var response = await httpClient.PutAsync($"/estoque/pizza/{pizzaId}/{quantidade}", null);
                // garante que vai dar pau se der pau
                response.EnsureSuccessStatusCode();
            }
        }

        // 2. Criar uma classe de retorno
        public class Estoque
        {
            public int Id { get; set; }
            public int PizzaId { get; set; }
            public int Quantidade { get; set; }
        }
    }
}
