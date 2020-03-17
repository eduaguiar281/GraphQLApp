using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Web.GQL.Mutations.Inputs
{
    public class CategoriaInputType: InputObjectGraphType
    {
        public CategoriaInputType()
        {
            Name = "CategoriaInput";
            Field<IntGraphType>("id", description:"Id da Categoria");
            Field<NonNullGraphType<StringGraphType>>("descricao", description: "Descrição da Categoria");
        }
    }
}
