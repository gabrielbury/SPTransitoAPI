using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SPTransitoAPI
{
    public class TransitoController : ApiController
    {
        // GET api/<controller>
        public async Task<Transito> Get()
        {
            Transito _transito = new Transito();

            using (HttpClient http = new HttpClient())
            {
                //Faz a chamada à página
                var response = await http.GetByteArrayAsync("http://cetsp1.cetsp.com.br/monitransmapa/agora/");
                //Converte os bytes do response em string UTF-8
                String source = Encoding.GetEncoding("utf-8").GetString(response, 0, response.Length - 1);
                //Formata a string obtida em código HTML
                source = WebUtility.HtmlDecode(source);
                //Carrega o código HTML em um documento para extração dos dados pertinentes
                HtmlDocument documentoHTML = new HtmlDocument();
                documentoHTML.LoadHtml(source);

                //Recupera os dados do HTML
                _transito.Norte = documentoHTML.DocumentNode.Descendants()
                    .Where(n => n.Id == "NorteLentidao")
                    .Single().InnerText;

                _transito.Sul = documentoHTML.DocumentNode.Descendants()
                    .Where(n => n.Id == "SulLentidao")
                    .Single().InnerText;

                _transito.Leste = documentoHTML.DocumentNode.Descendants()
                    .Where(n => n.Id == "LesteLentidao")
                    .Single().InnerText;

                _transito.Oeste = documentoHTML.DocumentNode.Descendants()
                    .Where(n => n.Id == "OesteLentidao")
                    .Single().InnerText;

                _transito.Centro = documentoHTML.DocumentNode.Descendants()
                    .Where(n => n.Id == "CentroLentidao")
                    .Single().InnerText;

                _transito.Total = documentoHTML.DocumentNode.Descendants()
                    .Where(n => n.Id == "lentidao")
                    .Single().InnerText + " km (" +
                    documentoHTML.DocumentNode.Descendants()
                        .Where(n => n.Id == "percentualLentidao")
                        .Single().InnerText + "%)";
                
                return _transito;
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}