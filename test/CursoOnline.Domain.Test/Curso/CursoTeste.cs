using Bogus;
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
        private string _descricao;
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
            //Bogus: ele serve para gerar palavras, numeros e qualaquer outra coisa de forma aleartória.
            var faker = new Faker();

            _nome = faker.Random.Word();
            _descricao = faker.Lorem.Paragraph();
            _cargaHoraria = faker.Random.Double(20,60);
            _publicoAlvo = PublicoAlvo.Empregado;
            _valor = faker.Random.Double(100,1000);
        }

        [Fact]
        public void DeveCriarCurso()
        {            
            var cursoEsperado = new
            {
                Nome = _nome,
                Descricao = _descricao,
                CargaHoraria = _cargaHoraria,
                PublicoAlvo = _publicoAlvo,
                Valor = _valor
            };

            var curso = new Domain.Curso(cursoEsperado.Nome,
                                  cursoEsperado.Descricao,
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
                CursoBuilder.Novo().ComNome(nomeInvalido).Build())
                .ComMensagem("Nome inválido");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void CursoNaoDeveTerCargaHorariaMenorQue(double cargaInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.Novo().ComCargaHoraria(cargaInvalido).Build())
                .ComMensagem("Carga Horária inválida");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void CursoNaoDeveTerValorMenorQue1(double valorInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
                CursoBuilder.Novo().ComValor(valorInvalido).Build())
                .ComMensagem("Valor inválido");
        }
    }
}
