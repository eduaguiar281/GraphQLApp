using GraphQL.Types;
using GraphQL.Web.Data;
using GraphQL.Web.GQL.Types;
using GraphQL.Web.Models;
using GraphQL.Web.GQL.Resolvers.Arguments;
using GraphQL.Web.GQL.Resolvers.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Web.GQL.Query
{
    public class MainQuery: ObjectGraphType
    {
        public MainQuery()
        {
            Field<ListGraphType<CategoriaType>>("categorias",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<IdGraphType>
                    {
                        Name = "id"
                    },
                    new QueryArgument<StringGraphType>
                    {
                        Name = "descricao"
                    }

                }),
                resolve: context =>
                {
                    var query = StaticDataBase.GetCategorias();
                    int? categoriaId = context.GetArgument<int?>("id");
                    if (categoriaId.HasValue)
                    {
                        if (categoriaId.Value <= 0)
                        {
                            context.Errors.Add(new ExecutionError("Id não deve ser menor ou igual a zero!"));
                            return new List<Categoria>();
                        }

                        return query.Where(w => w.Id == categoriaId);
                    }

                    string descricao = context.GetArgument<string>("descricao");
                    if (!string.IsNullOrEmpty(descricao))
                    {
                        return query.Where(w => w.Descricao == descricao);
                    }
                    return query.ToList();
                });

            Field<ListGraphType<ProdutoType>>("produtos",
                arguments: new ProdutoArguments(),
                resolve: context => ProdutoFieldContext.Resolve(context));
        }
    }
}
