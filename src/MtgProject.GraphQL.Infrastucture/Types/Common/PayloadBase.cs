using System;
using System.Collections.Generic;

namespace MtgProject.GraphQL.Infrastructure.Types.Common
{
    public class PayloadBase
    {
        public string? ClientMutationId { get; }
        public IReadOnlyList<UserError> Errors { get; }


        protected PayloadBase(string? clientMutationId)
        {
            Errors = Array.Empty<UserError>();
            ClientMutationId = clientMutationId;
        }

        protected PayloadBase(IReadOnlyList<UserError> errors, string? clientMutationId)
        {
            Errors = errors;
            ClientMutationId = clientMutationId;
        }
    }
}