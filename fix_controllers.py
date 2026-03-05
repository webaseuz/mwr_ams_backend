"""
WebApi Controllers migration script.
- namespace AutoPark.WebApi.Controllers → Erp.Service.Adm.WebApi
- MediatorController → BaseController
- [Authorize(nameof(PermissionCode.X))] → [Authorize(AdmPermissionCode.X)]
- old Command/Query names → new names
"""
import os, re, glob

BASE = "d:/WEBASE/PROJECTS/MWR/mwr_ams_backend/services/erp/erp-adm-service/src"
MODELS_DIR = f"{BASE}/libs/shared/Erp.Service.Adm.Models"
CONTROLLERS_DIR = f"{BASE}/Erp.Service.Adm.WebApi/Controllers"

# ── 1. Collect all valid NEW names from Models project ──────────────────────
models_names = set()
for root, dirs, files in os.walk(MODELS_DIR):
    for f in files:
        if f.endswith('.cs'):
            models_names.add(f[:-3])

# ── 2. Explicit manual overrides (edge cases) ───────────────────────────────
MANUAL = {
    # Paged list queries that changed from BriefPageResult to GetList
    'GetDriverBriefPagedResultQuery':         'DriverGetListQuery',
    'GetTransportBriefPagedResultQuery':      'TransportGetListQuery',
    'GetRoleBriefPagedResultQuery':           'RoleGetListQuery',
    'GetUserBriefPagedResultQuery':           'UserGetListQuery',
    'GetBankBriefPagedResultQuery':           'BankGetListQuery',
    'GetBatteryTypeBriefPagedResultQuery':    'BatteryTypeGetListQuery',
    'GetBranchBriefPagedResultQuery':         'BranchGetListQuery',
    'GetCitizenshipBriefPagedResultQuery':    'CitizenshipGetListQuery',
    'GetContractorBriefPagedResultQuery':     'ContractorGetListQuery',
    'GetCountryBriefPagedResultQuery':        'CountryGetListQuery',
    'GetCurrencyBriefPagedResultQuery':       'CurrencyGetListQuery',
    'GetDepartmentBriefPagedResultQuery':     'DepartmentGetListQuery',
    'GetDistrictBriefPagedResultQuery':       'DistrictGetListQuery',
    'GetFuelCardBriefPagedResultQuery':       'FuelCardGetListQuery',
    'GetFuelTypeBriefPagedResultQuery':       'FuelTypeGetListQuery',
    'GetInsuranceTypeBriefPagedResultQuery':  'InsuranceTypeGetListQuery',
    'GetLiquidTypeBriefPagedResultQuery':     'LiquidTypeGetListQuery',
    'GetMobileAppVersionBriefPagedResultQuery': 'MobileAppVersionGetListQuery',
    'GetNationalityBriefPagedResultQuery':    'NationalityGetListQuery',
    'GetOilModelBriefPagedResultQuery':       'OilModelGetListQuery',
    'GetOilTypeBriefPagedResultQuery':        'OilTypeGetListQuery',
    'GetOrganizationBriefPagedResultQuery':   'OrganizationGetListQuery',
    'GetPersonBriefPagedResultQuery':         'PersonGetListQuery',
    'GetPositionBriefPagedResultQuery':       'PositionGetListQuery',
    'GetRegionBriefPagedResultQuery':         'RegionGetListQuery',
    'GetTireModelBriefPagedResultQuery':      'TireModelGetListQuery',
    'GetTireSizeBriefPagedResultQuery':       'TireSizeGetListQuery',
    'GetTransportBrandBriefPagedResultQuery': 'TransportBrandGetListQuery',
    'GetTransportColorBriefPagedResultQuery': 'TransportColorGetListQuery',
    'GetTransportModelBriefPagedResultQuery': 'TransportModelGetListQuery',
    'GetTransportTypeBriefPagedResultQuery':  'TransportTypeGetListQuery',
    'GetTransportUseTypeBriefPagedResultQuery':'TransportUseTypeGetListQuery',
    'GetNotificationBriefPagedResultQuery':   'NotificationGetListQuery',
    'GetPresentNotificationBriefPagedResultQuery': 'PresentNotificationGetListQuery',
    'GetPresentTrackingInfoBriefPagedResultQuery': 'PresentTrackingInfoGetListQuery',
    'GetTrackingInfoBriefPagedResultQuery':   'TrackingInfoGetListQuery',
    'GetFuelCardBriefPageResultQuery':        'FuelCardGetListQuery',

    # Get{Entity}Query → {Entity}GetListQuery (single-entity "get all" queries)
    'GetDriverQuery':       'DriverGetListQuery',
    'GetTransportQuery':    'TransportGetListQuery',
    'GetBankQuery':         'BankGetListQuery',
    'GetRoleQuery':         'RoleGetListQuery',
    'GetUserQuery':         'UserGetListQuery',
    'GetBranchQuery':       'BranchGetListQuery',
    'GetPersonQuery':       'PersonGetListQuery',

    # Driver document file commands (old had "File" in name, new doesn't)
    'UploadDriverDocumentFileCommand':   'DriverDocumentUploadCommand',
    'DownloadDriverDocumentFileCommand': 'DriverDocumentDownloadCommand',

    # Excel query renamed
    'GetExcelForInsertQuery': 'DriverGetExcelTemplateQuery',

    # Transport file
    'UploadTransportFileCommand':   'TransportFileUploadCommand',
    'DownloadTransportFileCommand': 'TransportFileDownloadCommand',

    # Mobile app version
    'UploadMobileAppVersionFileCommand':   'MobileAppVersionFileUploadCommand',
    'DownloadMobileAppVersionFileCommand': 'MobileAppVersionFileDownloadCommand',
}

# ── 3. Auto-transform function ───────────────────────────────────────────────
VERBS_FRONT_COMMAND = ['Create', 'Update', 'Delete', 'Accept', 'Cancel', 'Send',
                        'Revoke', 'Approve', 'Import', 'Reject', 'Complete', 'Attach']

def find_new_name(old_name):
    # Already correct?
    if old_name in models_names:
        return old_name

    # Manual override?
    if old_name in MANUAL:
        mapped = MANUAL[old_name]
        return mapped  # Return even if not in models_names (edge case)

    # Upload/Download → move verb to before "Command"
    for verb in ['Upload', 'Download']:
        if old_name.startswith(verb) and old_name.endswith('Command'):
            rest = old_name[len(verb):-7]   # strip verb prefix + "Command"
            new_name = rest + verb + 'Command'
            if new_name in models_names:
                return new_name

    # Get...Query → {Entity}Get...Query
    if old_name.startswith('Get') and old_name.endswith('Query'):
        rest = old_name[3:-5]  # strip 'Get' and 'Query'
        rest = rest.replace('PagedResult', 'PageResult')
        # Try split at each uppercase boundary
        for i in range(1, len(rest)):
            if rest[i].isupper():
                entity = rest[:i]
                suffix = rest[i:]
                new_name = entity + 'Get' + suffix + 'Query'
                if new_name in models_names:
                    return new_name
        # Try whole rest as entity + GetQuery
        new_name = rest + 'GetQuery'
        if new_name in models_names:
            return new_name

    # {Verb}{Entity}Command → {Entity}{Verb}Command
    for verb in VERBS_FRONT_COMMAND:
        if old_name.startswith(verb) and old_name.endswith('Command'):
            rest = old_name[len(verb):-7]  # strip verb + "Command"
            new_name = rest + verb + 'Command'
            if new_name in models_names:
                return new_name

    return None  # unmappable

# ── 4. Process controllers ───────────────────────────────────────────────────
ctrl_files = glob.glob(f"{CONTROLLERS_DIR}/**/*.cs", recursive=True)
ctrl_files += glob.glob(f"{CONTROLLERS_DIR}/*.cs")

unmapped = {}
changed = []

# Regex to find all Command/Query identifiers (class names)
CQ_PATTERN = re.compile(r'\b([A-Z][A-Za-z0-9]+(?:Command|Query))\b')

for ctrl_path in sorted(ctrl_files):
    with open(ctrl_path, 'r', encoding='utf-8-sig') as f:
        content = f.read()

    # Skip already-migrated files
    if 'AutoPark' not in content and 'Bms.' not in content:
        continue

    new_content = content

    # ── Remove old using statements
    new_content = re.sub(r'^using AutoPark\.[^\n]*\n', '', new_content, flags=re.MULTILINE)
    new_content = re.sub(r'^using Bms\.[^\n]*\n', '', new_content, flags=re.MULTILINE)
    new_content = re.sub(r'^using Microsoft\.AspNetCore\.Mvc;\n', '', new_content, flags=re.MULTILINE)

    # ── Fix namespace
    new_content = new_content.replace(
        'namespace AutoPark.WebApi.Controllers;',
        'namespace Erp.Service.Adm.WebApi;')

    # ── Fix base class
    new_content = new_content.replace(': MediatorController', ': BaseController')

    # ── Fix [Authorize(nameof(PermissionCode.X))] → [Authorize(AdmPermissionCode.X)]
    new_content = re.sub(
        r'\[Authorize\(nameof\(PermissionCode\.(\w+)\)\)\]',
        r'[Authorize(AdmPermissionCode.\1)]',
        new_content)

    # ── Fix Command/Query class names
    file_unmapped = []

    def replace_cq(m):
        old = m.group(1)
        new = find_new_name(old)
        if new and new != old:
            return new
        if new is None:
            # Only report if it looks like a project-specific model class
            skip = {'IActionResult', 'CancellationToken', 'IFormFile',
                    'IRequest', 'IRequestHandler'}
            if old not in skip and old not in models_names:
                file_unmapped.append(old)
        return old

    new_content = CQ_PATTERN.sub(replace_cq, new_content)

    fname = os.path.basename(ctrl_path)
    if file_unmapped:
        unmapped[fname] = list(dict.fromkeys(file_unmapped))  # deduplicate

    if new_content != content:
        with open(ctrl_path, 'w', encoding='utf-8') as f:
            f.write(new_content)
        changed.append(fname)

# ── 5. Report ────────────────────────────────────────────────────────────────
print(f"Updated {len(changed)} files:")
for f in changed:
    print(f"  {f}")

if unmapped:
    print(f"\nUnmapped names (need manual fix):")
    for fname, names in unmapped.items():
        print(f"  {fname}:")
        for n in names:
            print(f"    - {n}")
else:
    print("\nNo unmapped names!")
