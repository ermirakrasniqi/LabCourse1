using System;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities.Queries;

public class GetActivityList
{
    //Query: is going to contain any query parameters as properties
    public class Query : IRequest<List<Activity>> { }

    //Interface, pe marrim qet query qe e kena kriju nalt edhe listen e aktiviteteve
    /*Handler: to actually handle and return the request wich matches
    the response that we specify up
    */
    public class Handler(AppDbContext context) : IRequestHandler<Query, List<Activity>>
    {
        public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await context.Activities.ToListAsync(cancellationToken);
        }
    }
}
