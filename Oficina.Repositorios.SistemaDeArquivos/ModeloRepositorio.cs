using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Oficina.Repositorios.SistemaDeArquivos
{
    public class ModeloRepositorio
    {
        //field tem a convenção de começar com _
        XDocument _arquivoXml = XDocument.Load(ConfigurationManager.AppSettings["caminhoArquivoModelo"]);

      public List<Modelo> SelecionarPorMarca(int marcaId)
      {
            var modelos = new List<Modelo>();

            foreach (var modelo in _arquivoXml.Descendants("modelo"))
            {
                if (modelo.Element("marcaId").Value == marcaId.ToString())
                {
                    Modelo carroModelo = new Modelo();

                    carroModelo.Id = Convert.ToInt32(modelo.Element("id").Value);
                    carroModelo.Nome = modelo.Element("nome").Value;

                    MarcaRepositorio marca = new MarcaRepositorio();
                    //carroModelo.Marca = marca.Selecionar(Convert.ToInt32(modelo.Element("marcaId").Value));
                    // carroModelo = new MarcaRepositorio().Selecionar(marcaId);
                    carroModelo.Marca = marca.Selecionar(marcaId);
                   

                    modelos.Add(carroModelo);
                }
            }

            return modelos;
      }


        public Modelo Selecionar(int marcaId)
        {
            Modelo modelo = null;

            foreach (var marcas in _arquivoXml.Descendants("marcaId"))
            {
                if (marcas.Element("marcaId").Value == marcaId.ToString())
                {
                    modelo = new Modelo();

                    modelo.Id = Convert.ToInt32(marcas.Element("id").Value);
                    modelo.Nome = marcas.Element("nome").Value;
                    marcaId = Convert.ToInt32(marcas.Element("marcaId").Value);
                    modelo.Marca = new MarcaRepositorio().Selecionar(marcaId);
                    break;
                }
            }

            return modelo;
        }




    }
}
