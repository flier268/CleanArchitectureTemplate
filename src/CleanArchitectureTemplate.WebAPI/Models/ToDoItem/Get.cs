using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Core.Exceptions;
using CleanArchitectureTemplate.Core.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace CleanArchitectureTemplate.WebAPI.Models.ToDoItem
{
    /// <summary>
    ///     Get related query, validators, and handlers
    /// </summary>
    public class Get
    {
        /// <summary>
        ///     Model to Get an entity
        /// </summary>
        public class GetQuery : IRequest<QueryResponse>
        {
            /// <summary>
            ///     Id
            /// </summary>
            public string Id { get; set; }

        }

        /// <summary>
        ///     Query Response
        /// </summary>
        public class QueryResponse
        {
            /// <summary>
            ///     Resource
            /// </summary>
            public ToDoItemModel Resource { get; set; }
        }

        /// <summary>
        ///     Register Validation 
        /// </summary>
        public class GetToDoItemQueryValidator : AbstractValidator<GetQuery>
        {
            /// <summary>
            ///     Validator ctor
            /// </summary>
            public GetToDoItemQueryValidator()
            {
                RuleFor(x => x.Id)
                    .NotEmpty();
            }

        }


        /// <summary>
        ///     Handler
        /// </summary>
        public class QueryHandler : IRequestHandler<GetQuery, QueryResponse>
        {
            private readonly IToDoItemRepository _repo;
            private readonly IMapper _mapper;

            /// <summary>
            ///     Ctor
            /// </summary>
            /// <param name="repo"></param>
            /// <param name="mapper"></param>
            public QueryHandler(IToDoItemRepository repo,
                                  IMapper mapper)
            {
                this._repo = repo ?? throw new ArgumentNullException(nameof(repo));
                this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            /// <summary>
            ///     Handle
            /// </summary>
            /// <param name="query"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<QueryResponse> Handle(GetQuery query, CancellationToken cancellationToken)
            {
                QueryResponse response = new QueryResponse();

                Core.Entities.ToDoItem entity = await _repo.GetItemAsync(query.Id);
                if (entity == null)
                {
                    throw new EntityNotFoundException(nameof(ToDoItem), query.Id);
                }

                response.Resource = _mapper.Map<ToDoItemModel>(entity);

                return response;
            }
        }
    }
}
