using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;


namespace ProjetoIntegracao.Models
{
    public class Cliente
    {
        public struct Retorno
        {
            public string _id { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
            public int Telefone { get; set; }
        }
        public struct Envio{
            public string Nome { get; set; }
            public string Email { get; set; }
            public int Telefone { get; set; }
        }

        //Alterar caminho para o "Banco de Dados" em txt da sua máquina, localizado na pasta "bd".
        private const string DIRETORIO_BD = @"{Diretório do projeto}\bd\clientes.txt";

        public static Cliente.Retorno Inserir(Cliente.Retorno Retorno)
        {

            string clienteString = string.Empty;
            string currentCliente = string.Empty;
            List<Cliente.Retorno> listaClientes = new List<Cliente.Retorno>();
            Cliente.Retorno cliente = new Cliente.Retorno();

            try
            {
                clienteString = JsonConvert.SerializeObject(Retorno);

                currentCliente = File.ReadAllText(DIRETORIO_BD);

                listaClientes = JsonConvert.DeserializeObject<List<Cliente.Retorno>>(currentCliente);

                if (listaClientes == null)
                {
                    currentCliente += "[";
                    string clientesAtualizados = currentCliente + clienteString + "]";

                    File.WriteAllText(DIRETORIO_BD, clientesAtualizados);
                }
                else
                {
                    string formatarJsonCol = currentCliente.Replace("]", "");
                    string clientesAtualizados = formatarJsonCol + "," + clienteString + "]";

                    File.WriteAllText(DIRETORIO_BD, clientesAtualizados);
                }
                cliente = JsonConvert.DeserializeObject<Cliente.Retorno>(clienteString);
            }
            catch (Exception e)
            {
                throw e;
            }

            return cliente;
        }
        public static Cliente.Retorno Selecionar(string identificador){

            string clientesString = string.Empty;
            Cliente.Retorno cliente = new Cliente.Retorno();
            List<Cliente.Retorno> listaClientes = new List<Cliente.Retorno>();

            try
            {
                clientesString = File.ReadAllText(DIRETORIO_BD);

                listaClientes = JsonConvert.DeserializeObject<List<Cliente.Retorno>>(clientesString);

                if (listaClientes != null)
                {
                    foreach (Cliente.Retorno item in listaClientes)
                    {
                        if (item._id == identificador)
                        {
                            cliente = item;
                            return cliente;
                        }
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }

            return cliente;
        }
        public static List<Cliente.Retorno> SelecionarTodos(){

            string clientesString = string.Empty;
            List<Cliente.Retorno> listaClientes = new List<Cliente.Retorno>();

            clientesString = File.ReadAllText(DIRETORIO_BD);

            listaClientes = JsonConvert.DeserializeObject<List<Cliente.Retorno>>(clientesString);

            return listaClientes;
        }
        public static void Atualizar(Cliente.Retorno Cliente, string identificador){

            string clientesJson = string.Empty;
            string listaClientesString = string.Empty;
            List<Cliente.Retorno> listaClientes = new List<Cliente.Retorno>();

            try
            {
                clientesJson = File.ReadAllText(DIRETORIO_BD);

                listaClientes = JsonConvert.DeserializeObject<List<Cliente.Retorno>>(clientesJson);

                listaClientes.RemoveAll(x => x._id == Cliente._id);

                listaClientes.Add(Cliente);

                listaClientesString = JsonConvert.SerializeObject(listaClientes);

                File.WriteAllText(DIRETORIO_BD, listaClientesString);
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public static void Deletar(string identificador)
        {
            string clientesJson = string.Empty;
            string listaClientesString = string.Empty;
            List<Cliente.Retorno> listaClientes = new List<Cliente.Retorno>();


            try
            {
                clientesJson = File.ReadAllText(DIRETORIO_BD);

                listaClientes = JsonConvert.DeserializeObject<List<Cliente.Retorno>>(clientesJson);

                listaClientes.RemoveAll(x => x._id == identificador);

                listaClientesString = JsonConvert.SerializeObject(listaClientes);

                if (listaClientes.Count == 0)
                {
                    File.WriteAllText(DIRETORIO_BD, "");
                }
                else
                {
                    File.WriteAllText(DIRETORIO_BD, listaClientesString);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
