using Bms.Core.Application;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Persons;

public class GetPersonBriefPagedResultQuery :
    SortFilterPageOptions,
    IRequest<PagedResultWithActionControls<PersonPriefDto>>
{ }
