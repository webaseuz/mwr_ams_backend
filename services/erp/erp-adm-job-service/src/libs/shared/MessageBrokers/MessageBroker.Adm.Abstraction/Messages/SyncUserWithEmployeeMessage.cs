using WEBASE.MessageBroker.Abstraction;

namespace Erp.Service.Adm.MessageBroker.QueueMessages;

public class SyncUserWithEmployeeMessage : IWbQueueMessage
{
    public List<UserEmployeeDto> UserEmployees { get; set; } = new();

    public class UserEmployeeDto
    {
        public string PhoneNumber { get; set; }
        public int PersonId { get; set; }

        public List<UserEmployeeAssignmentDto> Assignments { get; set; } = new();

        public class UserEmployeeAssignmentDto
        {
            public int PositionId { get; set; }
            public int OrganizationId { get; set; }
            public int OrganizationTypeId { get; set; }
            public int? InstitutionTypeId { get; set; }
        }
    }
}
