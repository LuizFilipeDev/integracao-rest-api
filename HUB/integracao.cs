using Newtonsoft.Json;
using ProjetoIntegracao.Models;
using System.Net;
using System.IO;
using System;
using System.Text;
using System.Collections.Generic;

namespace ProjetoIntegracao.HUB
{
    public class integracao
    {
        //Alterar endpoints antes de utilizar a aplicação.
        //Alterar ENDPOINT de acordo com o endpoint gerado no site: "https://crudcrud.com". 

        private const string ENDPOINT = "67fb4910a67f414d9603fa8fbc9c3b43"; 
        public static Cliente.Retorno GetCliente(string identificador)
        {
            Cliente.Retorno cliente = new Cliente.Retorno();

            HttpWebRequest requisicao = WebRequest.Create($"https://crudcrud.com/api/{ENDPOINT}/Clientes/{identificador}") as HttpWebRequest;

            requisicao.Method = "GET";
            requisicao.ContentType = "application/json";

            try
            {
                HttpWebResponse resposta = requisicao.GetResponse() as HttpWebResponse;

                using (Stream respostaStream = resposta.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respostaStream);

                    cliente = JsonConvert.DeserializeObject<Cliente.Retorno>(reader.ReadToEnd());
                }

                resposta.Close();
            }
            catch (WebException e)
            {

                throw e;
            }
            return cliente;
        }
        public static string PostCliente(Cliente.Envio Cliente){

            Models.Cliente.Retorno clienteRetorno = new Cliente.Retorno();
            string cliente = JsonConvert.SerializeObject(Cliente);
            byte[] byteArray = Encoding.UTF8.GetBytes(cliente);
            string servidorCliente = string.Empty;

            HttpWebRequest requisicao = WebRequest.Create($"https://crudcrud.com/api/{ENDPOINT}/Clientes") as HttpWebRequest;

            requisicao.Method = "POST";

            requisicao.ContentType = "application/json";

            requisicao.ContentLength = byteArray.Length;

            try
            {
                using (Stream requisicaoStream = requisicao.GetRequestStream())
                {

                    requisicaoStream.Write(byteArray, 0, byteArray.Length);
                }

                HttpWebResponse resposta = requisicao.GetResponse() as HttpWebResponse;

                using (Stream respostaStream = resposta.GetResponseStream())
                {

                    StreamReader reader = new StreamReader(respostaStream);
                    servidorCliente = reader.ReadToEnd();
                }
                clienteRetorno = JsonConvert.DeserializeObject<Models.Cliente.Retorno>(servidorCliente);
                clienteRetorno = Models.Cliente.Inserir(clienteRetorno);

                resposta.Close();
            }
            catch (WebException e)
            {

                throw e;
            }

            return clienteRetorno._id.ToString();
        }
        public static void PutCliente(Cliente.Envio Cliente, string identificador){

            string cliente = JsonConvert.SerializeObject(Cliente);
            byte[] byteArray = Encoding.UTF8.GetBytes(cliente);
            Models.Cliente.Retorno servidorCliente = new Cliente.Retorno();

            HttpWebRequest requisicao = WebRequest.Create($"https://crudcrud.com/api/{ENDPOINT}/Clientes/{identificador}") as HttpWebRequest;

            requisicao.Method = "PUT";
            requisicao.ContentType = "application/json";
            requisicao.ContentLength = byteArray.Length;

            try
            {
                using (Stream requisicaoStream = requisicao.GetRequestStream())
                {
                    requisicaoStream.Write(byteArray, 0, byteArray.Length);
                }

                servidorCliente = integracao.GetCliente(identificador);

                Models.Cliente.Atualizar(servidorCliente, identificador);
            }
            catch (WebException e)
            {

                throw e;
            }
        }
        public static string DeleteCliente(string identificador){

            HttpWebRequest requisicao = WebRequest.Create($"https://crudcrud.com/api/{ENDPOINT}/Clientes/{identificador}") as HttpWebRequest;

            requisicao.Method = "DELETE";

            try
            {
                HttpWebResponse resposta = requisicao.GetResponse() as HttpWebResponse;

                using (Stream respostaStream = resposta.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(respostaStream);

                    string respostaDoServidor = sr.ReadToEnd();
                }
                resposta.Close();

                Models.Cliente.Deletar(identificador);
            }
            catch (WebException e)
            {

                throw e;
            }

            return "delete";
        }
    }
}