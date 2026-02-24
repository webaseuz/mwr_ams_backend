using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bms.WEBASE.Models;
using MediatR;

namespace ServiceDesk.Application.UseCases.Info.ApplicationPurposes;

public class DeleteApplicationPurposeCommand : IRequest<SuccessResult<bool>>
{
    public int Id { get; set; }
}
