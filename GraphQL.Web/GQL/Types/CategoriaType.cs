using GraphQL.Types;
using GraphQL.Web.Data;
using GraphQL.Web.Models;
using GraphQL.Web.GQL.Resolvers.Arguments;
using GraphQL.Web.GQL.Resolvers.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Web.GQL.Types
{
    public class CategoriaType : ObjectGraphType<Categoria>
    {
        public CategoriaType()
        {
            Field(f => f.Id, type: typeof(IdGraphType));
            Field(f => f.Descricao, type: typeof(StringGraphType)).Description("Descrição");
            Field<ListGraphType<ProdutoType>>("produtos",
                arguments: new ProdutoArguments(),
                resolve: context =>
                {
                    var qry = ProdutoFieldContext.Resolve(context);
                    return qry.Where(c => c.CategoriaId == context.Source.Id).ToList();
                });
        }
    }
}
