using GraphQL.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Web.Data
{
    public class StaticDataBase
    {

        private static List<Categoria> _categorias;
        private static List<Produto> _produtos;

        private static IEnumerable<Categoria> GetSingletonCategoria()
        {
            if (_categorias == null)
            {
                _categorias =  new List<Categoria>()
                {
                    new Categoria { Id = 1, Descricao = "Eletrônicos", Produtos = new List<Produto>() },
                    new Categoria { Id = 2, Descricao = "Móveis", Produtos = new List<Produto>() },
                    new Categoria { Id = 3, Descricao = "Eletrodomésticos", Produtos = new List<Produto>() },
                    new Categoria { Id = 4, Descricao = "Bebidas", Produtos = new List<Produto>() }
                };
            }
            return _categorias;
        }

        public static IEnumerable<Categoria> GetCategorias()
        {
            return GetSingletonCategoria();
        }

        public static IQueryable<Categoria> GetQueryCategorias()
        {
            return GetCategorias().AsQueryable();
        }

        public static IEnumerable<Produto> GetProdutos()
        {
            return GetSingletonProdutos();
        }

        public static IQueryable<Produto> GetQueryProdutos()
        {
            return GetProdutos().AsQueryable();
        }

        public static Categoria AddCategoria(Categoria categoria)
        {
            GetCategorias();
            int lastId = _categorias.Max(c => c.Id);
            lastId++;
            categoria.Id = lastId;
            _categorias.Add(categoria);
            return categoria;
        }

        private static IEnumerable<Produto> GetSingletonProdutos()
        {
            GetSingletonCategoria();
            if (_produtos == null)
            {
                _produtos = new List<Produto>()
                {
                    new Produto 
                    { 
                        Id = 1, 
                        Descricao = "IPhone 11", 
                        CodigoBarras = "7891213030969", 
                        Preco = 4399, 
                        ControlaValidade = false, 
                        DataValidade = null, 
                        Estoque = 100,
                        Categoria = _categorias.Where(c=> c.Descricao == "Eletrônicos").FirstOrDefault(),
                        CategoriaId = _categorias.Where(c=> c.Descricao == "Eletrônicos").FirstOrDefault().Id 
                    },
                    new Produto
                    {
                        Id = 2,
                        Descricao = "PlayStation 4",
                        CodigoBarras = "7891213030968",
                        Preco = (decimal)1740.40,
                        ControlaValidade = false,
                        DataValidade = null,
                        Estoque = 5,
                        Categoria = _categorias.Where(c=> c.Descricao == "Eletrônicos").FirstOrDefault(),
                        CategoriaId = _categorias.Where(c=> c.Descricao == "Eletrônicos").FirstOrDefault().Id
                    },

                    new Produto
                    {
                        Id = 3,
                        Descricao = "Guarda Roupas 8 Portas",
                        CodigoBarras = "7891213030967",
                        Preco = (decimal)740.40,
                        ControlaValidade = false,
                        DataValidade = null,
                        Estoque = 10,
                        Categoria = _categorias.Where(c=> c.Descricao == "Móveis").FirstOrDefault(),
                        CategoriaId = _categorias.Where(c=> c.Descricao == "Móveis").FirstOrDefault().Id
                    },


                    new Produto
                    {
                        Id = 4,
                        Descricao = "Fritadeira Sem Óleo Air Frier",
                        CodigoBarras = "7891213030966",
                        Preco = 1240,
                        ControlaValidade = false,
                        DataValidade = null,
                        Estoque = 10,
                        Categoria = _categorias.Where(c=> c.Descricao == "Eletrodomésticos").FirstOrDefault(),
                        CategoriaId = _categorias.Where(c=> c.Descricao == "Eletrodomésticos").FirstOrDefault().Id
                    },
                    new Produto
                    {
                        Id = 5,
                        Descricao = "Máquina de Lavar Electrolux",
                        CodigoBarras = "7891213030965",
                        Preco = (decimal)1225.50,
                        ControlaValidade = false,
                        DataValidade = null,
                        Estoque = 10,
                        Categoria = _categorias.Where(c=> c.Descricao == "Eletrodomésticos").FirstOrDefault(),
                        CategoriaId = _categorias.Where(c=> c.Descricao == "Eletrodomésticos").FirstOrDefault().Id
                    },

                    new Produto
                    {
                        Id = 6,
                        Descricao = "Coca-Cola 2L",
                        CodigoBarras = "7891213030964",
                        Preco = (decimal)5.35,
                        ControlaValidade = true,
                        DataValidade = DateTime.Now.AddDays(452),
                        Estoque = 1000,
                        Categoria = _categorias.Where(c=> c.Descricao == "Bebidas").FirstOrDefault(),
                        CategoriaId = _categorias.Where(c=> c.Descricao == "Bebidas").FirstOrDefault().Id
                    },
                    new Produto
                    {
                        Id = 7,
                        Descricao = "Cerveja Quilmes 1L",
                        CodigoBarras = "7891213030963",
                        Preco = (decimal)7.52,
                        ControlaValidade = true,
                        DataValidade = DateTime.Now.AddDays(31),
                        Estoque = 510,
                        Categoria = _categorias.Where(c=> c.Descricao == "Bebidas").FirstOrDefault(),
                        CategoriaId = _categorias.Where(c=> c.Descricao == "Bebidas").FirstOrDefault().Id
                    },
                    new Produto
                    {
                        Id = 8,
                        Descricao = "Whisky Jhonny Walker 750ml",
                        CodigoBarras = "7891213030962",
                        Preco = (decimal)75.50,
                        ControlaValidade = true,
                        DataValidade = DateTime.Now.AddDays(2452),
                        Estoque = 10,
                        Categoria = _categorias.Where(c=> c.Descricao == "Bebidas").FirstOrDefault(),
                        CategoriaId = _categorias.Where(c=> c.Descricao == "Bebidas").FirstOrDefault().Id
                    },
                };

            }
            return _produtos;
        }

    }
}
