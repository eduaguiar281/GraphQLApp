using GraphQL.Types;
using GraphQL.Web.Data;
using GraphQL.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Web.GQL.Resolvers.Context
{
    public class ProdutoFieldContext
    {
        public static IQueryable<Produto> Resolve<TSourceContext>(ResolveFieldContext<TSourceContext> context)
        {
            var query = StaticDataBase.GetQueryProdutos();
            int? produtoId = context.GetArgument<int?>("id");
            if (produtoId.HasValue)
            {
                if (produtoId.Value <= 0)
                {
                    context.Errors.Add(new ExecutionError("Id não deve ser menor ou igual a zero!"));
                    return null;
                }
                return query.Where(w => w.Id == produtoId);
            }

            string descricao = context.GetArgument<string>("descricao");
            if (!string.IsNullOrEmpty(descricao))
            {
                return query.Where(w => w.Descricao == descricao);
            }

            string codigoBarras = context.GetArgument<string>("codigoBarras");
            if (!string.IsNullOrEmpty(codigoBarras))
            {
                return query.Where(w => w.CodigoBarras == codigoBarras);
            }

            bool? controlaValidade = context.GetArgument<bool?>("controlaValidade");
            if (controlaValidade.HasValue)
            {
                return query.Where(w => w.ControlaValidade == controlaValidade);
            }

            DateTime? validadeGt = context.GetArgument<DateTime?>("validade_gt");
            if (validadeGt.HasValue)
            {
                return query.Where(w => w.DataValidade >= validadeGt);
            }

            DateTime? validadeLt = context.GetArgument<DateTime?>("validade_lt");
            if (validadeLt.HasValue)
            {
                return query.Where(w => w.DataValidade <= validadeLt);
            }

            DateTime? validadeEq = context.GetArgument<DateTime?>("validade_eq");
            if (validadeEq.HasValue)
            {
                return query.Where(w => w.DataValidade == validadeLt);
            }

            int? estoqueGt = context.GetArgument<int?>("estoque_gt");
            if (estoqueGt.HasValue)
            {
                return query.Where(w => w.Estoque >= estoqueGt);
            }

            int? estoqueLt = context.GetArgument<int?>("estoque_lt");
            if (estoqueLt.HasValue)
            {
                return query.Where(w => w.Estoque <= estoqueLt);
            }

            int? estoqueEq = context.GetArgument<int?>("estoque_eq");
            if (estoqueEq.HasValue)
            {
                return query.Where(w => w.Estoque == estoqueEq);
            }

            return query;
        }
    }
}
