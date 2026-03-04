using MediatR;
using WbImzo.Models;

namespace Erp.Core;

public class WebImzoCallbackCommand : WbImzoSignInformDto, IRequest<WbImzoSignInformResponseDto>
{
}
