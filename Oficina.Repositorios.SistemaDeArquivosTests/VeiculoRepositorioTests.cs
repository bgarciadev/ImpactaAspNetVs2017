﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oficina.Dominio;
using Oficina.Repositorios.SistemaDeArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Repositorios.SistemaDeArquivos.Tests
{
    [TestClass()]
    public class VeiculoRepositorioTests
    {
        [TestMethod()]
        public void InserirTest()
        {
            //var repositorio = new VeiculoRepositorio("caminhoArquivo");
            var veiculo = new Veiculo();

            veiculo.Cambio = Cambio.Manual;
            veiculo.Combustivel = Combustivel.Flex;
            veiculo.Cor = new CorRepositorio().Selecionar(1);
            //veiculo.Id = 1;
            veiculo.Modelo = new ModeloRepositorio().Selecionar(1);
            veiculo.Observacao = "Observação";
            veiculo.Placa = "ABC1234";

            new VeiculoRepositorio().Inserir(veiculo);
        }
    }
}