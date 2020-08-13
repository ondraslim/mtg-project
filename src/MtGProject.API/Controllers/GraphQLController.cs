using GraphQL.Types;
using GraphQL.Utilities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Threading.Tasks;

namespace GraphQL.API.Controllers
{
    [Route("[controller]")]
    public class GraphQLController : Controller
    {
        private readonly ISchema schema;
        private readonly IDocumentExecuter documentExecutor;


        public GraphQLController(ISchema schema, IDocumentExecuter documentExecutor)
        {
            this.schema = schema;
            this.documentExecutor = documentExecutor;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var inputs = query.Variables?.ToInputs();
            var executionOptions = new ExecutionOptions
            {
                Schema = schema,
                Query = query.Query,
                Inputs = inputs
            };

            var result = await documentExecutor.ExecuteAsync(executionOptions);
            if (result.Errors.Any())
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}