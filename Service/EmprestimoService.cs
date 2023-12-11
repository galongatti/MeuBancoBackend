using MeuBancoBackend.DTO;
using MeuBancoBackend.Extension;
using MeuBancoBackend.Model;
using MeuBancoBackend.Repository;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MeuBancoBackend.Service
{
    public class EmprestimoService : IEmprestimoService
    {
        private IEmprestimoRepository _emprestimoRepository;
        private IOptions<ServicosMensagerias> _options;
        private readonly string _clientProvidedName = "Emprestimo Sender App";


        public EmprestimoService(IEmprestimoRepository emprestimoRepository, IOptions<ServicosMensagerias> options)
        {
            _emprestimoRepository = emprestimoRepository;
            _options = options;
        }

        public Emprestimo CadastrarEmprestimo(NovoEmprestimoDTO novoEmprestimo)
        {

            Emprestimo emprestimo = new()
            {
                DataSolicitacao = DateTime.Now,
                IdPessoa = novoEmprestimo.IdPessoa,
                ValorAprovado = null,
                ValorSolicitado = novoEmprestimo.ValorSolicitado
            };

            emprestimo = _emprestimoRepository.CadastrarEmprestimo(emprestimo);

            AnalisarEmprestimo(emprestimo);

            return emprestimo;
        }

        private void AnalisarEmprestimo(Emprestimo emprestimo)
        {

            EnviarParaAnaliseSERASA(emprestimo);
            EnviarParaAnaliseCadastro(emprestimo);

        }

        private void EnviarParaAnaliseCadastro(Emprestimo emprestimo)
        {
            ConnectionFactory factory = new();
            factory.Uri = new Uri(_options.Value.ServicoEmprestimo);
            factory.ClientProvidedName = "Emprestimo Sender App";
            IConnection cnn = factory.CreateConnection();
            IModel channel = cnn.CreateModel();

            string exchangeName = "CadastroExchange";
            string routingKey = "Cadastro-routing-key";
            string queueName = "CadastroQueue";

            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            channel.QueueDeclare(queueName, false, false, false, null);
            channel.QueueBind(queueName, exchangeName, routingKey, null);

            string json = JsonSerializer.Serialize(emprestimo);

            byte[] messageBodyBytes = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchangeName, routingKey, null, messageBodyBytes);

            channel.Close();
            cnn.Close();
        }

        private void EnviarParaAnaliseSERASA(Emprestimo emprestimo)
        {
            ConnectionFactory factory = new();
            factory.Uri = new Uri(_options.Value.ServicoEmprestimo);
            factory.ClientProvidedName = "Emprestimo Sender App";
            IConnection cnn = factory.CreateConnection();
            IModel channel = cnn.CreateModel();

            string exchangeName = "SERASAExchange";
            string routingKey = "Serasa-routing-key";
            string queueName = "SerasaQueue";

            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            channel.QueueDeclare(queueName, false, false, false, null);
            channel.QueueBind(queueName, exchangeName, routingKey, null);

            string json = JsonSerializer.Serialize(emprestimo);

            byte[] messageBodyBytes = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchangeName, routingKey, null, messageBodyBytes);

            channel.Close();
            cnn.Close();
        }
    }
}