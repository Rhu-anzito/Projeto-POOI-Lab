using Data;
using Model;

namespace TesteIntegrado
{
    [TestClass]
    public class ProdutoRepositoryTests
    {
        private ProdutoRepository _repo;

        private readonly string _connection =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=POOI_Lab;Integrated Security=True;";

        [TestInitialize]
        public void Setup()
        {
            _repo = new ProdutoRepository(_connection);
        }

        [TestMethod]
        public void Deve_Salvar_Produto()
        {
            var produto = new Produto
            {
                Nome = "Produto Teste",
                Preco = 10
            };

            var resultado = _repo.Salvar(produto);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Deve_Listar_Produtos()
        {
            var lista = _repo.Listar();

            Assert.IsNotNull(lista);
        }

        [TestMethod]
        public void Deve_Atualizar_Produto()
        {
            var produto = new Produto
            {
                Nome = "Produto Update",
                Preco = 20
            };

            _repo.Salvar(produto);

            var ultimo = _repo.Listar().Last();

            ultimo.Nome = "Produto Atualizado";

            var resultado = _repo.Atualizar(ultimo);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Deve_Excluir_Produto()
        {
            var produto = new Produto
            {
                Nome = "Produto Delete",
                Preco = 5
            };

            _repo.Salvar(produto);

            var ultimo = _repo.Listar().Last();

            var resultado = _repo.Excluir(ultimo.Id);

            Assert.IsTrue(resultado);
        }
    }
}