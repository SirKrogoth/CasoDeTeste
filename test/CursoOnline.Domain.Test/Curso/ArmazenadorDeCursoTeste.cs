using Moq;
using Xunit;

namespace CursoOnline.Domain.Test.Curso
{
    public class ArmazenadorDeCursoTeste
    {
        [Fact]
        public void DeveAdicionarCurso()
        {
            var cursoDto = new CursoDto
            {
                Nome = "Curso A",
                Descricao = "Descrição",
                CargaHoraria = 80,
                PublicoAlvoID = 1,
                Valor = 850.00
            };

            var cursoRepositorioMock = new Mock<ICursoRepositorio>();

            var armazenadorDeCurso = new ArmazenadorDeCurso(cursoRepositorioMock.Object);

            armazenadorDeCurso.Armazenar(cursoDto);

            cursoRepositorioMock.Verify(r => r.Adicionar(It.IsAny<Domain.Curso>()));
        }
    }

    public interface ICursoRepositorio
    {
        void Adicionar(Domain.Curso curso);
    }

    internal class ArmazenadorDeCurso
    {
        private readonly ICursoRepositorio _cursoRepositorio;
        public ArmazenadorDeCurso(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }

        public void Armazenar(CursoDto cursoDto)
        {
            var curso = new Domain.Curso(cursoDto.Nome, cursoDto.Descricao, cursoDto.CargaHoraria, PublicoAlvo.Empregado, cursoDto.Valor);

            _cursoRepositorio.Adicionar(curso); 
        }
    }

    public class CursoDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int CargaHoraria { get; set; }
        public int PublicoAlvoID { get; set; }
        public double Valor
        { get; set; }
    }
}
