using AutoPark.Application.UseCases.Persons;
using Bms.WEBASE.Models;
using MediatR;

namespace AutoPark.Application.UseCases.Drivers
{
    public class CreateDriverCommand :
         IRequest<IHaveId<int>>
    {
        public int BranchId { get; set; }
        public int OrganizationId { get; set; }
        public List<CreateDriverDocumentCommand> Documents { get; set; } = new();
        public CreatePersonCommand Person { get; set; } = null!;
    }
}
