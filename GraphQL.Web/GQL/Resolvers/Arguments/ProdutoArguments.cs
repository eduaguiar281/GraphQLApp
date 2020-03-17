using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Web.GQL.Resolvers.Arguments
{
    public class ProdutoArguments : QueryArguments
    {
        public ProdutoArguments()
        {
            Add(new QueryArgument<IdGraphType>
            {
                Name = "id"
            });
            Add(new QueryArgument<StringGraphType>
            {
                Name = "descricao"
            });
            Add(new QueryArgument<StringGraphType>
            {
                Name = "codigoBarras"
            });
            Add(new QueryArgument<BooleanGraphType>
            {
                Name = "controlaValidade"
            });
            Add(new QueryArgument<DateGraphType>
            {
                Name = "validade_gt"
            });
            Add(new QueryArgument<DateGraphType>
            {
                Name = "validade_lt"
            });
            Add(new QueryArgument<DateGraphType>
            {
                Name = "validade_eq"
            });
            Add(new QueryArgument<IntGraphType>
            {
                Name = "estoque_gt"
            });
            Add(new QueryArgument<IntGraphType>
            {
                Name = "estoque_lt"
            });
            Add(new QueryArgument<IntGraphType>
            {
                Name = "estoque_eq"
            });
        }
    }
}
