using CursoOnline.Domain.Test._util;
using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursoOnline.Domain.Test.Curso
{
    public class CursoTeste
    {
        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = "João",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Empregado,
                Valor = (double)950
            };

            var curso = new Curso(cursoEsperado.Nome,
                                  cursoEsperado.CargaHoraria,
                                  cursoEsperado.PublicoAlvo,
                                  cursoEsperado.Valor);

            //Vai montar todos os asserts necessarios para execução do projetos
            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerUmNomeInvalido(string nomeInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "Informática Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)950
            };

            Assert.Throws<ArgumentException>(() =>
                new Curso(nomeInvalido, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).ComMensagem("Nome Inválido");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void CursoNaoDeveTerCargaHorariaMenorQue(double cargaInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "Informática Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)950
            };

            var mensage = Assert.Throws<ArgumentException>(() =>
                new Curso(cursoEsperado.Nome, cargaInvalido, cursoEsperado.PublicoAlvo, cursoEsperado.Valor))
                .Message;

            Assert.Equal("Carga Horária inválida", mensage); ;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void CursoNaoDeveTerValorMenorQue1(double valorInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "Informática Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)950
            };

            Assert.Throws<ArgumentException>(() =>
                new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, valorInvalido));
        }
    }

    public enum PublicoAlvo
    {
        Estudante,
        Universitario,
        Empregado,
        Empresa
    }

    public class Curso
    {
        private PublicoAlvo publicoAlvo;

        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }

        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome Inválido");

            if(cargaHoraria < 1)
                throw new ArgumentException("Carga Horária inválida");

            if(valor < 1)
                throw new ArgumentException("Valor Inválido");

            this.Nome = nome;
            this.CargaHoraria = cargaHoraria;
            this.PublicoAlvo = publicoAlvo;
            this.Valor = valor;
        }
    }
}
