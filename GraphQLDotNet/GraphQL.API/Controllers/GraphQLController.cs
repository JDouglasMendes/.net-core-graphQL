﻿using GraphQL.API.GraphQL.Queries;
using GraphQL.API.GraphQL.Schemas;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GraphQL.API.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly EmpresaSchema _schema;

        public GraphQLController(EmpresaSchema schema)
        {
            _schema = schema;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}