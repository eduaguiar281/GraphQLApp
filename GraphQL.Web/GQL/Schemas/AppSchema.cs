using GraphQL.Types;
using GraphQL.Web.GQL.Mutations;
using GraphQL.Web.GQL.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Web.GQL.Schemas
{
    public class AppSchema : Schema
    {
        public AppSchema(IDependencyResolver resolver)
            :base(resolver)
        {
            Query = resolver.Resolve<MainQuery>();
            Mutation = resolver.Resolve<MainMutation>();
        }
    }
}
