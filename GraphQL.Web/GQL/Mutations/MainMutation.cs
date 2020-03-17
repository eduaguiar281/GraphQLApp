using GraphQL.Types;
using GraphQL.Web.Data;
using GraphQL.Web.GQL.Mutations.Inputs;
using GraphQL.Web.GQL.Types;
using GraphQL.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Web.GQL.Mutations
{
    public class MainMutation : ObjectGraphType
    {
        public MainMutation()
        {
            Field<CategoriaType>("createCategoria", 
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CategoriaInputType>> { Name = "categoria"}),
                resolve: context =>
                {
                    var categoria = context.GetArgument<Categoria>("categoria");
                    if (categoria == null)
                    {
                        context.Errors.Add(new ExecutionError("Categoria não foi informada!"));
                        return null;
                    }
                    StaticDataBase.AddCategoria(categoria);
                    return categoria;
                });
            Field<CategoriaType>("updateCategoria",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CategoriaInputType>> { Name = "categoria" }),
                resolve: context =>
                {
                    var categoria = context.GetArgument<Categoria>("categoria");
                    if (categoria == null)
                    {
                        context.Errors.Add(new ExecutionError("Categoria não foi informada!"));
                        return null;
                    }
                    var categoriaDb = StaticDataBase.GetQueryCategorias().Where(c => c.Id == categoria.Id).FirstOrDefault();
                    if (categoriaDb == null)
                    {
                        context.Errors.Add(new ExecutionError("Categoria não foi localizada!"));
                        return null;
                    }
                    categoriaDb.Descricao = categoria.Descricao;
                    //StaticDataBase.AddCategoria(categoria);
                    return categoriaDb;
                });
        }
    }
}
