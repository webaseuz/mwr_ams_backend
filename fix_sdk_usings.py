import os

def add_using(path, after, new_using):
    with open(path, 'r', encoding='utf-8-sig') as f:
        c = f.read()
    if new_using in c:
        print(f'Already has {new_using}: {os.path.basename(path)}')
        return
    if after in c:
        c = c.replace(after, after + '\n' + new_using, 1)
        with open(path, 'w', encoding='utf-8', newline='\n') as f:
            f.write(c)
        print(f'Added {new_using} to {os.path.basename(path)}')
    else:
        print(f'After-pattern not found in {os.path.basename(path)}: {after!r}')

sdk_ifaces = r'D:/WEBASE/PROJECTS/MWR/mad_erp_backend/services/erp/erp-adm-service/src/libs/shared/Erp.Service.Adm.Sdk/Interfaces'

# IPersonApi.cs - needs Erp.Core.Sdk.Models
add_using(sdk_ifaces + '/Hl/IPersonApi.cs', 'using Erp.Core.Models;', 'using Erp.Core.Sdk.Models;')

# IAppApi.cs - needs Erp.Service.Adm.Job.Models
add_using(sdk_ifaces + '/Enum/IAppApi.cs', 'using Erp.Service.Adm.Models;', 'using Erp.Service.Adm.Job.Models;')

# IKinshipDegree.cs - needs Erp.Service.Adm.Job.Models
add_using(sdk_ifaces + '/Enum/IKinshipDegree.cs', 'using Erp.Service.Adm.Models;', 'using Erp.Service.Adm.Job.Models;')

# IReportApi.cs - needs Erp.Service.Adm.Job.Models
add_using(sdk_ifaces + '/IReportApi.cs', 'using Erp.Service.Adm.Models;', 'using Erp.Service.Adm.Job.Models;')

# IManualApi.cs - needs Erp.Service.Adm.Job.Models
add_using(sdk_ifaces + '/IManualApi.cs', 'using Erp.Service.Adm.Models;', 'using Erp.Service.Adm.Job.Models;')

print('Done')
