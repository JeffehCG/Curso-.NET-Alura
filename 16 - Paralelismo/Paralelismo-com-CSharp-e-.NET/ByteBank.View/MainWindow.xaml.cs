using ByteBank.Core.Model;
using ByteBank.Core.Repository;
using ByteBank.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ByteBank.View
{
    public partial class MainWindow : Window
    {
        private readonly ContaClienteRepository r_Repositorio;
        private readonly ContaClienteService r_Servico;

        public MainWindow()
        {
            InitializeComponent();

            r_Repositorio = new ContaClienteRepository();
            r_Servico = new ContaClienteService();
        }

        private void BtnProcessar_Click(object sender, RoutedEventArgs e)
        {
            BtnProcessar.IsEnabled = false;

            var contas = r_Repositorio.GetContaClientes();

            var resultado = new List<string>();

            AtualizarView(new List<string>(), TimeSpan.Zero);

            var inicio = DateTime.Now;

            // Utilizando Tasks
            // O .NET utiliza a classe TaskScheduler, que define quando e aonde a Task sera executada, divinindo as mesmas pelos nucleos (E otimizando o processamento)
            var contasTarefas = contas.Select(conta =>
            {
                // Criando uma tarefa para cada conta
                return Task.Factory.StartNew(() => // Factory utiliza o TaskScheduler Default
                {
                    var resultadoProcessamento = r_Servico.ConsolidarMovimentacao(conta);
                    resultado.Add(resultadoProcessamento);
                });
            }).ToArray(); // Utilizando o ToArray para executar as Tasks (O link só cria as instancias quando necessrio, ou seja, quando a variavel for iniciada)

            // Travando a aplicação até que todas as tarefas estiverem finalizadas
            //Task.WaitAll(contasTarefas);

            // Pegando o contexto atual (A Thread principal)
            var contextThread = TaskScheduler.FromCurrentSynchronizationContext(); // Como no java script : that = this; kkkk

            // Um encadeamento de tarefas (Um só sera executada quando a anterior for concluida)
            Task.WhenAll(contasTarefas)
                .ContinueWith(task => // So sera executado quando as task de contasTarefas forem concluidas
                {
                    var fim = DateTime.Now;
                    AtualizarView(resultado, fim - inicio);

                }, contextThread) // Passando o contexto principal como parametro para task a ser executa (Para não dar erro de contexto diferente)
                .ContinueWith(task =>
                {
                    BtnProcessar.IsEnabled = true;
                }, contextThread);
        }

        private void AtualizarView(List<String> result, TimeSpan elapsedTime)
        {
            var tempoDecorrido = $"{ elapsedTime.Seconds }.{ elapsedTime.Milliseconds} segundos!";
            var mensagem = $"Processamento de {result.Count} clientes em {tempoDecorrido}";

            LstResultados.ItemsSource = result;
            TxtTempo.Text = mensagem;
        }

        #region Aula 1 - Utilizando Threads
        private void UtilizandoThreads()
        {
            var contas = r_Repositorio.GetContaClientes();

            var quantidadeContasPorThread = contas.Count() / 4;
            var contas_parte1 = contas.Take(quantidadeContasPorThread);
            var contas_parte2 = contas.Skip(quantidadeContasPorThread).Take(quantidadeContasPorThread);
            var contas_parte3 = contas.Skip(quantidadeContasPorThread * 2).Take(quantidadeContasPorThread);
            var contas_parte4 = contas.Skip(quantidadeContasPorThread * 3);


            var resultado = new List<string>();

            AtualizarView(new List<string>(), TimeSpan.Zero);

            var inicio = DateTime.Now;

            // Uma Thread representa uma linha de processamento,
            Thread thread_parte1 = new Thread(() =>
            {
                foreach (var conta in contas_parte1)
                {
                    var resultadoProcessamento = r_Servico.ConsolidarMovimentacao(conta);
                    resultado.Add(resultadoProcessamento);
                }
            });

            Thread thread_parte2 = new Thread(() =>
            {
                foreach (var conta in contas_parte2)
                {
                    var resultadoProcessamento = r_Servico.ConsolidarMovimentacao(conta);
                    resultado.Add(resultadoProcessamento);
                }
            });

            Thread thread_parte3 = new Thread(() =>
            {
                foreach (var conta in contas_parte3)
                {
                    var resultadoProcessamento = r_Servico.ConsolidarMovimentacao(conta);
                    resultado.Add(resultadoProcessamento);
                }
            });

            Thread thread_parte4 = new Thread(() =>
            {
                foreach (var conta in contas_parte4)
                {
                    var resultadoProcessamento = r_Servico.ConsolidarMovimentacao(conta);
                    resultado.Add(resultadoProcessamento);
                }
            });

            // Inicializando o processamento da Thread
            thread_parte1.Start();
            thread_parte2.Start();
            thread_parte3.Start();
            thread_parte4.Start();

            // Sair do While apenas quandos as duas threads forem finalizadas
            while (thread_parte1.IsAlive || thread_parte2.IsAlive || thread_parte3.IsAlive || thread_parte4.IsAlive)
            {
                Thread.Sleep(250); // Fazendo que o while espera 250 milisegundos para continuar o processamento sempre
            }

            var fim = DateTime.Now;

            AtualizarView(resultado, fim - inicio);
        }
        #endregion

        #region Aula 2 - Utilizando Tasks e entendo contexto (Thread principal)
        private void UtilizandoTasks()
        {
            BtnProcessar.IsEnabled = false;

            var contas = r_Repositorio.GetContaClientes();

            var resultado = new List<string>();

            AtualizarView(new List<string>(), TimeSpan.Zero);

            var inicio = DateTime.Now;

            // Utilizando Tasks
            // O .NET utiliza a classe TaskScheduler, que define quando e aonde a Task sera executada, divinindo as mesmas pelos nucleos (E otimizando o processamento)
            var contasTarefas = contas.Select(conta =>
            {
                // Criando uma tarefa para cada conta
                return Task.Factory.StartNew(() => // Factory utiliza o TaskScheduler Default
                {
                    var resultadoProcessamento = r_Servico.ConsolidarMovimentacao(conta);
                    resultado.Add(resultadoProcessamento);
                });
            }).ToArray(); // Utilizando o ToArray para executar as Tasks (O link só cria as instancias quando necessrio, ou seja, quando a variavel for utilizada)

            // Travando a aplicação até que todas as tarefas estiverem finalizadas
            //Task.WaitAll(contasTarefas);

            // Pegando o contexto atual (A Thread principal)
            var contextThread = TaskScheduler.FromCurrentSynchronizationContext(); // Como no javascript : that = this; kkkk

            // Um encadeamento de tarefas (Um só sera executada quando a anterior for concluida)
            Task.WhenAll(contasTarefas)
                .ContinueWith(task => // So sera executado quando as tasks de contasTarefas forem concluidas
                {
                    var fim = DateTime.Now;
                    AtualizarView(resultado, fim - inicio);

                }, contextThread) // Passando o contexto principal como parametro para task a ser executa (Para não dar erro de contexto diferente)
                .ContinueWith(task =>
                {
                    BtnProcessar.IsEnabled = true;
                }, contextThread);
        }
        #endregion
    }
}
