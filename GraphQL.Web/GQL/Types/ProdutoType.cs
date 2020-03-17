using GraphQL.Types;
using GraphQL.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Web.GQL.Types
{
    public class ProdutoType: ObjectGraphType<Produto>
    {
        public ProdutoType()
        {
            Field(x => x.Id, type: typeof (IdGraphType));
            Field(x => x.Descricao).Description("Descrição do Produto");
            Field(x => x.CodigoBarras).Description("Código de Barras");
            Field(x => x.Preco, type: typeof(DecimalGraphType)).Description("Preço");
            Field(x => x.ControlaValidade, type: typeof(BooleanGraphType)).Description("ControlaValidade");
            Field(x => x.DataValidade, type: typeof(DateTimeGraphType)).Description("Data da Validade");
            Field(x => x.Estoque, type: typeof(IntGraphType)).Description("Estoque");
            Field(x => x.CategoriaId).Description("Estoque");

        }

    }
}
