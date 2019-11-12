using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursoOnline.Domain.Test
{
    public class MeuPrimeiroTeste
    {
        [Fact(DisplayName = "Testar")]
        public void Testar()
        {
            //Organizãção
            var var01 = 1;
            var var02 = 2;

            //Ação
            var01 = var02;

            //Assert
            Assert.Equal(var01, var02);
        }
    }
}
