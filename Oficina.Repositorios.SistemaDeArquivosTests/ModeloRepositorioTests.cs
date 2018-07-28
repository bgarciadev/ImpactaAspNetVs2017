﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oficina.Repositorios.SistemaDeArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Repositorios.SistemaDeArquivos.Tests
{
    [TestClass()]
    public class ModeloRepositorioTests
    {
        ModeloRepositorio _repositorio = new ModeloRepositorio();

        [TestMethod()]
        public void SelecionarPorMarcaTest()
        {
            var modelos = _repositorio.SelecionarPorMarca(1);

            Assert.AreEqual(modelos[0].Id, 1);
            Assert.IsTrue(modelos[0].Nome == "Onix");
            Assert.AreEqual(modelos[0].Marca.Nome, "Chevrolet");
        }

        [TestMethod()]
        [DataRow(1)]
        [DataRow(2)]
        public void SelecionarPorIdTest(int modeloId)
        {
            var modelo = _repositorio.Selecionar(modeloId);
            if (modeloId > 0)
            {
                Assert.AreEqual(modelo.Id, modeloId);
                Assert.AreEqual(modelo.Nome,"Onix");
            }
            else
            {
                Assert.IsNull(modelo);

            }
        }
    }
}