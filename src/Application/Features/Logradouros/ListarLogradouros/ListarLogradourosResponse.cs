namespace Application.Features.Logradouros.ListarLogradouros
{
    public class ListarLogradourosResponse
    {
        public string ClienteEmail { get; set; }

        public string Endereco { get; set; }

        public ListarLogradourosResponse(string clienteEmail, string endereco)
        {
            ClienteEmail = clienteEmail;

            Endereco = endereco;
        }
    }
}
