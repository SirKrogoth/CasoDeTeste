using CursoOnline.Domain.Test._util;
using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace CursoOnline.Domain.Test.Curso
{
    public class CursoTeste
    {
        public ITestOutputHelper _outputHelper;
        private string _nome;
        private double _cargaHoraria;
        private PublicoAlvo _publicoAlvo;
        private double _valor;

        //public CursoTeste(ITestOutputHelper outputHelper)
        //{
        //    //O método Construtor de uma classe de teste, executa sempre que a cada método de teste.
        //    _outputHelper = outputHelper;
        //    _outputHelper.WriteLine("Construtor sendo executado.");
        //}

        public CursoTeste()
        {
            _nome = "João";
            _cargaHoraria = 80;
            _publicoAlvo = PublicoAlvo.Empregado;
            _valor = 950;
        }

        [Fact]
        public void DeveCriarCurso()
        {            
            var cursoEsperado = new
            {
                Nome = _nome,
                CargaHoraria = _cargaHoraria,
                PublicoAlvo = _publicoAlvo,
                Valor = _valor
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
            Assert.Throws<ArgumentException>(() =>
                new Curso(nomeInvalido, _cargaHoraria, _publicoAlvo, _valor)).ComMensagem("Nome Inválido");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void CursoNaoDeveTerCargaHorariaMenorQue(double cargaInvalido)
        {
            var mensage = Assert.Throws<ArgumentException>(() =>
                new Curso(_nome, cargaInvalido, _publicoAlvo, _valor))
                .Message;

            Assert.Equal("Carga Horária inválida", mensage); ;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void CursoNaoDeveTerValorMenorQue1(double valorInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
                new Curso(_nome, _cargaHoraria, _publicoAlvo, valorInvalido));
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
