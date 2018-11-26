using apiXmlToObject.Models;
using apiXmlToObject.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace apiXmlToObject.Controllers
{
    public class ProdutosController : ApiController
    {

        [HttpGet]
        public async System.Threading.Tasks.Task<string> Listar(int id = 0)
        {
            //string endereco = "http://fakerestapi.azurewebsites.net/api/books/";
            //if (id > 0)
            //{
            //    endereco = "http://fakerestapi.azurewebsites.net/api/books/" + id;
            //}

            string endereco = "http://fakerestapi.azurewebsites.net/api/books/" + (id > 0 ? id.ToString() : "");
            string conteudo = "";

            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, endereco))
                {
                    request.Headers.Add("accept", "application/xml");

                    using (var response = await client.SendAsync(request))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            conteudo = response.Content.ReadAsStringAsync().Result;
                            var book = new Book();
                            var teste = XMLSerializationUtility.DeserializeObject<Book>(Encoding.UTF8, conteudo, book.GetType());
                            return teste.ToString();
                        }
                        else
                        {
                            return "erro";
                        }
                    }

                }
            }

        }

        [HttpGet]
        public IHttpActionResult Livros(int id = 0)
        {
            string Endereco = "http://fakerestapi.azurewebsites.net/api/Books/" + (id > 0 ? id.ToString() : "");
            string conteudo;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Endereco);
                request.Method = "GET";
                //request.Headers.Add("Accept", "application/xml");
                request.Headers.Set("Accept", "application/xml");

                WebResponse response = request.GetResponse();

                using (Stream responseStream = response.GetResponseStream())
                {

                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    conteudo = reader.ReadToEnd();
                    var teste = XMLSerializationUtility.DeserializeObject<Book>(Encoding.UTF8, conteudo, new Book().GetType());
                    return Ok(teste);
                }

            }
            catch (Exception error)
            {
                return Ok(error.Message);
            }

        }

        ////GET: api/Produtos
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Produtos/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Produtos
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Produtos/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Produtos/5
        //public void Delete(int id)
        //{
        //}
    }
}
