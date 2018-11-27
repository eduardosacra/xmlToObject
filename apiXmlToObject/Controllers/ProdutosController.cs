using apiXmlToObject.Models;
using apiXmlToObject.Util;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace apiXmlToObject.Controllers
{
    public class ProdutosController : ApiController
    {
        [HttpGet]
        public async System.Threading.Tasks.Task<IHttpActionResult> ListarBooks(int id = 0)
        {
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
                            var teste = XMLSerializationUtility.Deserialize<Book>(Encoding.UTF8, conteudo, typeof(Book));
                            return Ok(teste);
                        }
                        else
                        {
                            return Json("Erro");
                        }
                    }

                }
            }

        }

    }
}
