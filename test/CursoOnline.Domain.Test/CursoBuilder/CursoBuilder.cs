﻿using CursoOnline.Domain.Test.Curso;
using System;
using System.Collections.Generic;
using System.Text;
using CursoOnline.Domain.Test;
using CursoOnline.Domain;

namespace CursoOnline.Domain.Test.Curso
{
    public class CursoBuilder
    {
        private string _nome = "João Rafael";
        private double _cargaHoraria = 80;
        private PublicoAlvo _publicoAlvo = PublicoAlvo.Empregado;
        private double _valor = 950;
        private string _descricao = "descricao legal";

        public static CursoBuilder Novo()
        {
            return new CursoBuilder();
        }

        public CursoBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public CursoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public CursoBuilder ComCargaHoraria(double cargaHoraria)
        {
            _cargaHoraria = cargaHoraria;
            return this;
        }

        public CursoBuilder ComValor(double valor)
        {
            _valor = valor;
            return this;
        }

        public CursoBuilder ComPublicoAlvo(PublicoAlvo publicoAlvo)
        {
            _publicoAlvo = publicoAlvo;
            return this;
        }

        public Domain.Curso Build()
        {
            return new Domain.Curso(_nome, _descricao, _cargaHoraria, _publicoAlvo, _valor);
        }
    }
}
