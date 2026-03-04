import re, os

def read_write(path, old, new):
    with open(path, 'r', encoding='utf-8-sig') as f:
        c = f.read()
    if old in c:
        c = c.replace(old, new, 1)
        with open(path, 'w', encoding='utf-8', newline='\n') as f:
            f.write(c)
        print(f'Fixed: {os.path.basename(path)}')
    else:
        print(f'Pattern not found in: {os.path.basename(path)}')

base_domain = r'D:/WEBASE/PROJECTS/MWR/mad_erp_backend/libs/dotnet/Erp.Core.Service.Domain/Entities/Info'
base_models = r'D:/WEBASE/PROJECTS/MWR/mad_erp_backend/services/erp/erp-adm-service/src/libs/shared/Erp.Service.Adm.Models'

# 1. Add Owner nav prop to TransportModelLiquid
read_write(
    base_domain + '/TransportModelLiquid.cs',
    '    #region Relationships\n    [ForeignKey(nameof(LiquidTypeId))]\n    public virtual LiquidType LiquidType { get; set; }',
    '    #region Relationships\n    [ForeignKey(nameof(OwnerId))]\n    public virtual TransportModel Owner { get; set; } = null!;\n\n    [ForeignKey(nameof(LiquidTypeId))]\n    public virtual LiquidType LiquidType { get; set; }'
)

# 2. Add Owner nav prop to TransportModelFuel
read_write(
    base_domain + '/TransportModelFuel.cs',
    '    #region Relationships\n    [ForeignKey(nameof(FuelTypeId))]\n    public virtual FuelType FuelType { get; set; } = null!;',
    '    #region Relationships\n    [ForeignKey(nameof(OwnerId))]\n    public virtual TransportModel Owner { get; set; } = null!;\n\n    [ForeignKey(nameof(FuelTypeId))]\n    public virtual FuelType FuelType { get; set; } = null!;'
)

# 3. Add Owner nav prop to TransportModelOil
read_write(
    base_domain + '/TransportModelOil.cs',
    '    #region Relationships\n    [ForeignKey(nameof(OilTypeId))]\n    public virtual OilType OilType { get; set; } = null!;',
    '    #region Relationships\n    [ForeignKey(nameof(OwnerId))]\n    public virtual TransportModel Owner { get; set; } = null!;\n\n    [ForeignKey(nameof(OilTypeId))]\n    public virtual OilType OilType { get; set; } = null!;'
)

# 4. Fix PersonGetByIdQuery.cs - add using Erp.Core.Sdk.Models
read_write(
    base_models + '/Hl/Persons/Queries/PersonGetByIdQuery.cs',
    'using Erp.Core.Models;\nusing MediatR;',
    'using Erp.Core.Models;\nusing Erp.Core.Sdk.Models;\nusing MediatR;'
)

# 5. Fix PersonGetByPassportDataQuery.cs
read_write(
    base_models + '/Hl/Persons/Queries/PersonGetByPassportDataQuery.cs',
    'using MediatR;\nusing Erp.Core.Models;',
    'using MediatR;\nusing Erp.Core.Models;\nusing Erp.Core.Sdk.Models;'
)

# 6. Fix PersonGetByIdsQuery.cs
read_write(
    base_models + '/Hl/Persons/Queries/PersonGetByIdsQuery.cs',
    'using MediatR;\nusing Erp.Core.Models;',
    'using MediatR;\nusing Erp.Core.Models;\nusing Erp.Core.Sdk.Models;'
)

# 7. Fix UserAttachCommand.cs
read_write(
    base_models + '/Sys/Users/Commands/UserAttachCommand.cs',
    'using MediatR;\nusing Erp.Core.Models;',
    'using MediatR;\nusing Erp.Core.Models;\nusing Erp.Core.Sdk.Models;'
)

# 8. Fix UserCreateCommand.cs
read_write(
    base_models + '/Sys/Users/Commands/UserCreateCommand.cs',
    'using MediatR;\nusing WEBASE;\nusing Erp.Core.Models;',
    'using MediatR;\nusing WEBASE;\nusing Erp.Core.Models;\nusing Erp.Core.Sdk.Models;'
)

print('Done')
