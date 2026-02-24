using ServiceDesk.Domain;
using Bms.Core.Application;
using Bms.Core.Domain;

namespace ServiceDesk.Application.UseCases.ServiceTypes;

public class ServiceTypeTranslateCommand :
    TranslateCommand<ServiceTypeTranslateCommand, ServiceTypeTranslate, TranslateColumn>
{ }
