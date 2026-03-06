-- ============================================================
-- 0201 alter table set schema adm autopark insert sys_table.sql
-- Barcha public tablalarni adm va autopark schemalariga ko'chirish
-- va adm.sys_table ga ro'yxatdan o'tkazish
-- ============================================================


-- ============================================================
-- ADM SCHEMA
-- ============================================================

-- ENUM (adm)
ALTER TABLE public.enum_state                           SET SCHEMA adm;
ALTER TABLE public.enum_state_translate                 SET SCHEMA adm;
ALTER TABLE public.enum_status                          SET SCHEMA adm;
ALTER TABLE public.enum_status_translate                SET SCHEMA adm;
ALTER TABLE public.enum_language                        SET SCHEMA adm;
ALTER TABLE public.enum_gender                          SET SCHEMA adm;
ALTER TABLE public.enum_gender_translate                SET SCHEMA adm;
ALTER TABLE public.enum_document_type                   SET SCHEMA adm;
ALTER TABLE public.enum_document_type_translate         SET SCHEMA adm;
ALTER TABLE public.enum_plastic_card_type               SET SCHEMA adm;
ALTER TABLE public.enum_plastic_card_type_translate     SET SCHEMA adm;
ALTER TABLE public.enum_notification_template           SET SCHEMA adm;
ALTER TABLE public.enum_notification_template_translate SET SCHEMA adm;

-- INFO (adm) - umumiy ma'lumotlar
ALTER TABLE public.info_bank                        SET SCHEMA adm;
ALTER TABLE public.info_bank_translate              SET SCHEMA adm;
ALTER TABLE public.info_citizenship                 SET SCHEMA adm;
ALTER TABLE public.info_citizenship_translate       SET SCHEMA adm;
ALTER TABLE public.info_contractor                  SET SCHEMA adm;
ALTER TABLE public.info_country                     SET SCHEMA adm;
ALTER TABLE public.info_country_translate           SET SCHEMA adm;
ALTER TABLE public.info_currency                    SET SCHEMA adm;
ALTER TABLE public.info_currency_translate          SET SCHEMA adm;
ALTER TABLE public.info_district                    SET SCHEMA adm;
ALTER TABLE public.info_district_translate          SET SCHEMA adm;
ALTER TABLE public.info_nationality                 SET SCHEMA adm;
ALTER TABLE public.info_nationality_translate       SET SCHEMA adm;
ALTER TABLE public.info_organization                SET SCHEMA adm;
ALTER TABLE public.info_organization_translate      SET SCHEMA adm;
ALTER TABLE public.info_region                      SET SCHEMA adm;
ALTER TABLE public.info_region_translate            SET SCHEMA adm;
ALTER TABLE public.info_mobile_app_version          SET SCHEMA adm;

-- SYS (adm)
ALTER TABLE public.sys_number                           SET SCHEMA adm;
ALTER TABLE public.sys_permission                       SET SCHEMA adm;
ALTER TABLE public.sys_permission_translate             SET SCHEMA adm;
ALTER TABLE public.sys_permission_group                 SET SCHEMA adm;
ALTER TABLE public.sys_permission_group_translate       SET SCHEMA adm;
ALTER TABLE public.sys_permission_sub_group             SET SCHEMA adm;
ALTER TABLE public.sys_permission_sub_group_translate   SET SCHEMA adm;
ALTER TABLE public.sys_role                             SET SCHEMA adm;
ALTER TABLE public.sys_role_translate                   SET SCHEMA adm;
ALTER TABLE public.sys_role_permission                  SET SCHEMA adm;
ALTER TABLE public.sys_user                             SET SCHEMA adm;
ALTER TABLE public.sys_user_log                         SET SCHEMA adm;
ALTER TABLE public.sys_user_refresh_token               SET SCHEMA adm;
ALTER TABLE public.sys_user_role                        SET SCHEMA adm;
ALTER TABLE public.sys_user_token                       SET SCHEMA adm;

-- HL (adm) - tashkilot tuzilmasi, shaxslar
ALTER TABLE public.hl_branch                    SET SCHEMA adm;
ALTER TABLE public.hl_department                SET SCHEMA adm;
ALTER TABLE public.hl_department_translate      SET SCHEMA adm;
ALTER TABLE public.hl_person                    SET SCHEMA adm;
ALTER TABLE public.hl_position                  SET SCHEMA adm;
ALTER TABLE public.hl_position_translate        SET SCHEMA adm;
ALTER TABLE public.hl_notification              SET SCHEMA adm;
ALTER TABLE public.hl_present_notification      SET SCHEMA adm;
ALTER TABLE public.hl_number_template           SET SCHEMA adm;

-- DOC (adm)
ALTER TABLE public.doc_notification_template_setting                    SET SCHEMA adm;
ALTER TABLE public.doc_notification_template_setting_restricted_user    SET SCHEMA adm;
ALTER TABLE public.doc_notification_template_setting_role               SET SCHEMA adm;
ALTER TABLE public.doc_notification_template_setting_user               SET SCHEMA adm;


-- ============================================================
-- AUTOPARK SCHEMA
-- ============================================================

-- ENUM (autopark)
ALTER TABLE public.enum_expense_type                SET SCHEMA autopark;
ALTER TABLE public.enum_expense_type_translate      SET SCHEMA autopark;
ALTER TABLE public.enum_transmission_box_type           SET SCHEMA autopark;
ALTER TABLE public.enum_transmission_box_type_translate SET SCHEMA autopark;
ALTER TABLE public.enum_inspection_type                 SET SCHEMA autopark;
ALTER TABLE public.enum_inspection_type_translate       SET SCHEMA autopark;
-- (0197 scriptda rename qilingan: enum_transport_type -> info_transport_type)
ALTER TABLE public.info_transport_type              SET SCHEMA autopark;
ALTER TABLE public.info_transport_type_translate    SET SCHEMA autopark;

-- INFO (autopark) - transport ma'lumotlari
ALTER TABLE public.info_battery_type                SET SCHEMA autopark;
ALTER TABLE public.info_battery_type_translate      SET SCHEMA autopark;
ALTER TABLE public.info_fuel_type                   SET SCHEMA autopark;
ALTER TABLE public.info_fuel_type_translate         SET SCHEMA autopark;
ALTER TABLE public.info_insurance_type              SET SCHEMA autopark;
ALTER TABLE public.info_insurance_type_translate    SET SCHEMA autopark;
ALTER TABLE public.info_liquid_type                 SET SCHEMA autopark;
ALTER TABLE public.info_liquid_type_translate       SET SCHEMA autopark;
ALTER TABLE public.info_oil_model                   SET SCHEMA autopark;
ALTER TABLE public.info_oil_model_translate         SET SCHEMA autopark;
ALTER TABLE public.info_oil_type                    SET SCHEMA autopark;
ALTER TABLE public.info_oil_type_translate          SET SCHEMA autopark;
ALTER TABLE public.info_tire_model                  SET SCHEMA autopark;
ALTER TABLE public.info_tire_model_translate        SET SCHEMA autopark;
ALTER TABLE public.info_tire_size                   SET SCHEMA autopark;
ALTER TABLE public.info_transport_brand             SET SCHEMA autopark;
ALTER TABLE public.info_transport_brand_translate   SET SCHEMA autopark;
ALTER TABLE public.info_transport_color             SET SCHEMA autopark;
ALTER TABLE public.info_transport_color_translate   SET SCHEMA autopark;
ALTER TABLE public.info_transport_model             SET SCHEMA autopark;
ALTER TABLE public.info_transport_model_fuel        SET SCHEMA autopark;
ALTER TABLE public.info_transport_model_liquid      SET SCHEMA autopark;
ALTER TABLE public.info_transport_model_oil         SET SCHEMA autopark;
ALTER TABLE public.info_transport_model_translate   SET SCHEMA autopark;
ALTER TABLE public.info_transport_use_type          SET SCHEMA autopark;
ALTER TABLE public.info_transport_use_type_translate SET SCHEMA autopark;

-- HL (autopark) - haydovchi, transport
ALTER TABLE public.hl_driver                    SET SCHEMA autopark;
ALTER TABLE public.hl_driver_document           SET SCHEMA autopark;
ALTER TABLE public.hl_fuel_card                 SET SCHEMA autopark;
ALTER TABLE public.hl_transport                 SET SCHEMA autopark;
ALTER TABLE public.hl_transport_file            SET SCHEMA autopark;
ALTER TABLE public.hl_transport_model_file      SET SCHEMA autopark;
ALTER TABLE public.hl_tracking_info             SET SCHEMA autopark;
ALTER TABLE public.hl_present_tracking_info     SET SCHEMA autopark;

-- DOC (autopark) - yoqilg'i, xarajat, sozlama
ALTER TABLE public.doc_refuel                   SET SCHEMA autopark;
ALTER TABLE public.doc_refuel_file              SET SCHEMA autopark;
ALTER TABLE public.doc_refuel_history           SET SCHEMA autopark;

ALTER TABLE public.doc_expense                  SET SCHEMA autopark;
ALTER TABLE public.doc_expense_file             SET SCHEMA autopark;
ALTER TABLE public.doc_expense_history          SET SCHEMA autopark;
ALTER TABLE public.doc_expense_battery          SET SCHEMA autopark;
ALTER TABLE public.doc_expense_battery_file     SET SCHEMA autopark;
ALTER TABLE public.doc_expense_inspection       SET SCHEMA autopark;
ALTER TABLE public.doc_expense_inspection_file  SET SCHEMA autopark;
ALTER TABLE public.doc_expense_insurance        SET SCHEMA autopark;
ALTER TABLE public.doc_expense_insurance_file   SET SCHEMA autopark;
ALTER TABLE public.doc_expense_liquid           SET SCHEMA autopark;
ALTER TABLE public.doc_expense_liquid_file      SET SCHEMA autopark;
ALTER TABLE public.doc_expense_oil              SET SCHEMA autopark;
ALTER TABLE public.doc_expense_oil_file         SET SCHEMA autopark;
ALTER TABLE public.doc_expense_tire             SET SCHEMA autopark;
ALTER TABLE public.doc_expense_tire_file        SET SCHEMA autopark;

ALTER TABLE public.doc_transport_setting            SET SCHEMA autopark;
ALTER TABLE public.doc_transport_setting_file       SET SCHEMA autopark;
ALTER TABLE public.doc_transport_setting_history    SET SCHEMA autopark;
ALTER TABLE public.doc_transport_setting_battery    SET SCHEMA autopark;
ALTER TABLE public.doc_transport_setting_fuel       SET SCHEMA autopark;
ALTER TABLE public.doc_transport_setting_inspection SET SCHEMA autopark;
ALTER TABLE public.doc_transport_setting_insurance  SET SCHEMA autopark;
ALTER TABLE public.doc_transport_setting_liquid     SET SCHEMA autopark;
ALTER TABLE public.doc_transport_setting_oil        SET SCHEMA autopark;
ALTER TABLE public.doc_transport_setting_tire       SET SCHEMA autopark;

-- ACC (autopark)
ALTER TABLE public.acc_driver_penalty SET SCHEMA autopark;

-- QR: allaqachon qr schemada (scriptda QR. prefiks bilan yaratilgan) - o'zgartirish kerak emas


-- ============================================================
-- adm.sys_table ga barcha tablalarni ro'yxatdan o'tkazish
-- ============================================================

-- ADM / ENUM
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (1, 'enum_state',                           'enum_state',                           'ADM', 'enum_state',                           'ENUM');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (2, 'enum_state_translate',                 'enum_state_translate',                 'ADM', 'enum_state_translate',                 'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (3, 'enum_status',                          'enum_status',                          'ADM', 'enum_status',                          'ENUM');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (4, 'enum_status_translate',                'enum_status_translate',                'ADM', 'enum_status_translate',                'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (5, 'enum_language',                        'enum_language',                        'ADM', 'enum_language',                        'ENUM');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (6, 'enum_gender',                          'enum_gender',                          'ADM', 'enum_gender',                          'ENUM');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (7, 'enum_gender_translate',                'enum_gender_translate',                'ADM', 'enum_gender_translate',                'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (8, 'enum_inspection_type',                 'enum_inspection_type',                 'ADM', 'enum_inspection_type',                 'ENUM');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (9, 'enum_inspection_type_translate',       'enum_inspection_type_translate',       'ADM', 'enum_inspection_type_translate',       'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (10, 'enum_document_type',                   'enum_document_type',                   'ADM', 'enum_document_type',                   'ENUM');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (11, 'enum_document_type_translate',         'enum_document_type_translate',         'ADM', 'enum_document_type_translate',         'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (12, 'enum_plastic_card_type',               'enum_plastic_card_type',               'ADM', 'enum_plastic_card_type',               'ENUM');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (13, 'enum_plastic_card_type_translate',     'enum_plastic_card_type_translate',     'ADM', 'enum_plastic_card_type_translate',     'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (14, 'enum_transmission_box_type',           'enum_transmission_box_type',           'ADM', 'enum_transmission_box_type',           'ENUM');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (15, 'enum_transmission_box_type_translate', 'enum_transmission_box_type_translate', 'ADM', 'enum_transmission_box_type_translate', 'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (16, 'enum_notification_template',           'enum_notification_template',           'ADM', 'enum_notification_template',           'ENUM');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (17, 'enum_notification_template_translate', 'enum_notification_template_translate', 'ADM', 'enum_notification_template_translate', 'TRANSLATE');

-- ADM / INFO
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (18, 'info_bank',                    'info_bank',                    'ADM', 'info_bank',                    'INFO');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (19, 'info_bank_translate',          'info_bank_translate',          'ADM', 'info_bank_translate',          'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (20, 'info_citizenship',             'info_citizenship',             'ADM', 'info_citizenship',             'INFO');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (21, 'info_citizenship_translate',   'info_citizenship_translate',   'ADM', 'info_citizenship_translate',   'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (22, 'info_contractor',              'info_contractor',              'ADM', 'info_contractor',              'INFO');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (23, 'info_country',                 'info_country',                 'ADM', 'info_country',                 'INFO');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (24, 'info_country_translate',       'info_country_translate',       'ADM', 'info_country_translate',       'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (25, 'info_currency',                'info_currency',                'ADM', 'info_currency',                'INFO');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (26, 'info_currency_translate',      'info_currency_translate',      'ADM', 'info_currency_translate',      'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (27, 'info_district',                'info_district',                'ADM', 'info_district',                'INFO');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (28, 'info_district_translate',      'info_district_translate',      'ADM', 'info_district_translate',      'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (29, 'info_nationality',             'info_nationality',             'ADM', 'info_nationality',             'INFO');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (30, 'info_nationality_translate',   'info_nationality_translate',   'ADM', 'info_nationality_translate',   'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (31, 'info_organization',            'info_organization',            'ADM', 'info_organization',            'INFO');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (32, 'info_organization_translate',  'info_organization_translate',  'ADM', 'info_organization_translate',  'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (33, 'info_region',                  'info_region',                  'ADM', 'info_region',                  'INFO');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (34, 'info_region_translate',        'info_region_translate',        'ADM', 'info_region_translate',        'TRANSLATE');

-- ADM / SYS
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (35, 'sys_number',                           'sys_number',                           'ADM', 'sys_number',                           'SYS');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (36, 'sys_permission',                       'sys_permission',                       'ADM', 'sys_permission',                       'SYS');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (37, 'sys_permission_translate',             'sys_permission_translate',             'ADM', 'sys_permission_translate',             'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (38, 'sys_permission_group',                 'sys_permission_group',                 'ADM', 'sys_permission_group',                 'SYS');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (39, 'sys_permission_group_translate',       'sys_permission_group_translate',       'ADM', 'sys_permission_group_translate',       'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (40, 'sys_permission_sub_group',             'sys_permission_sub_group',             'ADM', 'sys_permission_sub_group',             'SYS');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (41, 'sys_permission_sub_group_translate',   'sys_permission_sub_group_translate',   'ADM', 'sys_permission_sub_group_translate',   'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (42, 'sys_role',                             'sys_role',                             'ADM', 'sys_role',                             'SYS');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (43, 'sys_role_translate',                   'sys_role_translate',                   'ADM', 'sys_role_translate',                   'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (44, 'sys_role_permission',                  'sys_role_permission',                  'ADM', 'sys_role_permission',                  'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (45, 'sys_user',                             'sys_user',                             'ADM', 'sys_user',                             'SYS');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (46, 'sys_user_log',                         'sys_user_log',                         'ADM', 'sys_user_log',                         'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (47, 'sys_user_refresh_token',               'sys_user_refresh_token',               'ADM', 'sys_user_refresh_token',               'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (48, 'sys_user_role',                        'sys_user_role',                        'ADM', 'sys_user_role',                        'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (49, 'sys_user_token',                       'sys_user_token',                       'ADM', 'sys_user_token',                       'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (50, 'sys_table',                            'sys_table',                            'ADM', 'sys_table',                            'SYS');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (51, 'sys_table_translate',                  'sys_table_translate',                  'ADM', 'sys_table_translate',                  'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (52, 'sys_row_change_log',                   'sys_row_change_log',                   'ADM', 'sys_row_change_log',                   'SYS');

-- ADM / HL
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (53, 'hl_branch',                    'hl_branch',                    'ADM', 'hl_branch',                    'HL');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (54, 'hl_department',                'hl_department',                'ADM', 'hl_department',                'HL');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (55, 'hl_department_translate',      'hl_department_translate',      'ADM', 'hl_department_translate',      'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (56, 'hl_person',                    'hl_person',                    'ADM', 'hl_person',                    'HL');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (57, 'hl_position',                  'hl_position',                  'ADM', 'hl_position',                  'HL');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (58, 'hl_position_translate',        'hl_position_translate',        'ADM', 'hl_position_translate',        'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (59, 'hl_notification',              'hl_notification',              'ADM', 'hl_notification',              'HL');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (60, 'hl_present_notification',      'hl_present_notification',      'ADM', 'hl_present_notification',      'HL');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (61, 'hl_number_template',           'hl_number_template',           'ADM', 'hl_number_template',           'SYS');

-- ADM / DOC
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (62, 'doc_notification_template_setting',                   'doc_notification_template_setting',                   'ADM', 'doc_notification_template_setting',                   'DOC');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (63, 'doc_notification_template_setting_restricted_user',   'doc_notification_template_setting_restricted_user',   'ADM', 'doc_notification_template_setting_restricted_user',   'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (64, 'doc_notification_template_setting_role',              'doc_notification_template_setting_role',              'ADM', 'doc_notification_template_setting_role',              'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (65, 'doc_notification_template_setting_user',              'doc_notification_template_setting_user',              'ADM', 'doc_notification_template_setting_user',              'TABLE');


-- AUTOPARK / ENUM
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (66, 'enum_expense_type',                'enum_expense_type',                'AUTOPARK', 'enum_expense_type',                'ENUM');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (67, 'enum_expense_type_translate',      'enum_expense_type_translate',      'AUTOPARK', 'enum_expense_type_translate',      'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (68, 'info_transport_type',              'info_transport_type',              'AUTOPARK', 'info_transport_type',              'INFO');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (69, 'info_transport_type_translate',    'info_transport_type_translate',    'AUTOPARK', 'info_transport_type_translate',    'TRANSLATE');

-- AUTOPARK / INFO
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (70, 'info_battery_type',               'info_battery_type',               'AUTOPARK', 'info_battery_type',               'INFO');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (71, 'info_battery_type_translate',     'info_battery_type_translate',     'AUTOPARK', 'info_battery_type_translate',     'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (72, 'info_fuel_type',                  'info_fuel_type',                  'AUTOPARK', 'info_fuel_type',                  'INFO');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (73, 'info_fuel_type_translate',        'info_fuel_type_translate',        'AUTOPARK', 'info_fuel_type_translate',        'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (74, 'info_insurance_type',             'info_insurance_type',             'AUTOPARK', 'info_insurance_type',             'INFO');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (75, 'info_insurance_type_translate',   'info_insurance_type_translate',   'AUTOPARK', 'info_insurance_type_translate',   'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (76, 'info_liquid_type',                'info_liquid_type',                'AUTOPARK', 'info_liquid_type',                'INFO');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (77, 'info_liquid_type_translate',      'info_liquid_type_translate',      'AUTOPARK', 'info_liquid_type_translate',      'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (78, 'info_oil_model',                  'info_oil_model',                  'AUTOPARK', 'info_oil_model',                  'INFO');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (79, 'info_oil_model_translate',        'info_oil_model_translate',        'AUTOPARK', 'info_oil_model_translate',        'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (80, 'info_oil_type',                   'info_oil_type',                   'AUTOPARK', 'info_oil_type',                   'INFO');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (81, 'info_oil_type_translate',         'info_oil_type_translate',         'AUTOPARK', 'info_oil_type_translate',         'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (82, 'info_tire_model',                 'info_tire_model',                 'AUTOPARK', 'info_tire_model',                 'INFO');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (83, 'info_tire_model_translate',       'info_tire_model_translate',       'AUTOPARK', 'info_tire_model_translate',       'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (84, 'info_tire_size',                  'info_tire_size',                  'AUTOPARK', 'info_tire_size',                  'INFO');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (85, 'info_transport_brand',            'info_transport_brand',            'AUTOPARK', 'info_transport_brand',            'INFO');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (86, 'info_transport_brand_translate',  'info_transport_brand_translate',  'AUTOPARK', 'info_transport_brand_translate',  'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (87, 'info_transport_color',            'info_transport_color',            'AUTOPARK', 'info_transport_color',            'INFO');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (88, 'info_transport_color_translate',  'info_transport_color_translate',  'AUTOPARK', 'info_transport_color_translate',  'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (89, 'info_transport_model',            'info_transport_model',            'AUTOPARK', 'info_transport_model',            'INFO');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (90, 'info_transport_model_fuel',       'info_transport_model_fuel',       'AUTOPARK', 'info_transport_model_fuel',       'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (91, 'info_transport_model_liquid',     'info_transport_model_liquid',     'AUTOPARK', 'info_transport_model_liquid',     'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (92, 'info_transport_model_oil',        'info_transport_model_oil',        'AUTOPARK', 'info_transport_model_oil',        'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (93, 'info_transport_model_translate',  'info_transport_model_translate',  'AUTOPARK', 'info_transport_model_translate',  'TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (94, 'info_transport_use_type',         'info_transport_use_type',         'AUTOPARK', 'info_transport_use_type',         'INFO');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (95, 'info_transport_use_type_translate','info_transport_use_type_translate','AUTOPARK', 'info_transport_use_type_translate','TRANSLATE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (96, 'info_mobile_app_version',         'info_mobile_app_version',         'AUTOPARK', 'info_mobile_app_version',         'INFO');

-- AUTOPARK / HL
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (97, 'hl_driver',                   'hl_driver',                   'AUTOPARK', 'hl_driver',                   'HL');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (98, 'hl_driver_document',          'hl_driver_document',          'AUTOPARK', 'hl_driver_document',          'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (99, 'hl_fuel_card',                'hl_fuel_card',                'AUTOPARK', 'hl_fuel_card',                'HL');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (100, 'hl_transport',                'hl_transport',                'AUTOPARK', 'hl_transport',                'HL');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (101, 'hl_transport_file',           'hl_transport_file',           'AUTOPARK', 'hl_transport_file',           'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (102, 'hl_transport_model_file',     'hl_transport_model_file',     'AUTOPARK', 'hl_transport_model_file',     'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (103, 'hl_tracking_info',            'hl_tracking_info',            'AUTOPARK', 'hl_tracking_info',            'HL');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (104, 'hl_present_tracking_info',    'hl_present_tracking_info',    'AUTOPARK', 'hl_present_tracking_info',    'HL');

-- AUTOPARK / DOC
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (105, 'doc_refuel',                  'doc_refuel',                  'AUTOPARK', 'doc_refuel',                  'DOC');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (106, 'doc_refuel_file',             'doc_refuel_file',             'AUTOPARK', 'doc_refuel_file',             'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (107, 'doc_refuel_history',          'doc_refuel_history',          'AUTOPARK', 'doc_refuel_history',          'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (108, 'doc_expense',                 'doc_expense',                 'AUTOPARK', 'doc_expense',                 'DOC');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (109, 'doc_expense_file',            'doc_expense_file',            'AUTOPARK', 'doc_expense_file',            'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (110, 'doc_expense_history',         'doc_expense_history',         'AUTOPARK', 'doc_expense_history',         'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (111, 'doc_expense_battery',         'doc_expense_battery',         'AUTOPARK', 'doc_expense_battery',         'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (112, 'doc_expense_battery_file',    'doc_expense_battery_file',    'AUTOPARK', 'doc_expense_battery_file',    'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (113, 'doc_expense_inspection',      'doc_expense_inspection',      'AUTOPARK', 'doc_expense_inspection',      'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (114, 'doc_expense_inspection_file', 'doc_expense_inspection_file', 'AUTOPARK', 'doc_expense_inspection_file', 'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (115, 'doc_expense_insurance',       'doc_expense_insurance',       'AUTOPARK', 'doc_expense_insurance',       'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (116, 'doc_expense_insurance_file',  'doc_expense_insurance_file',  'AUTOPARK', 'doc_expense_insurance_file',  'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (117, 'doc_expense_liquid',          'doc_expense_liquid',          'AUTOPARK', 'doc_expense_liquid',          'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (118, 'doc_expense_liquid_file',     'doc_expense_liquid_file',     'AUTOPARK', 'doc_expense_liquid_file',     'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (119, 'doc_expense_oil',             'doc_expense_oil',             'AUTOPARK', 'doc_expense_oil',             'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (120, 'doc_expense_oil_file',        'doc_expense_oil_file',        'AUTOPARK', 'doc_expense_oil_file',        'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (121, 'doc_expense_tire',            'doc_expense_tire',            'AUTOPARK', 'doc_expense_tire',            'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (122, 'doc_expense_tire_file',       'doc_expense_tire_file',       'AUTOPARK', 'doc_expense_tire_file',       'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (123, 'doc_transport_setting',               'doc_transport_setting',               'AUTOPARK', 'doc_transport_setting',               'DOC');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (124, 'doc_transport_setting_file',          'doc_transport_setting_file',          'AUTOPARK', 'doc_transport_setting_file',          'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (125, 'doc_transport_setting_history',       'doc_transport_setting_history',       'AUTOPARK', 'doc_transport_setting_history',       'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (126, 'doc_transport_setting_battery',       'doc_transport_setting_battery',       'AUTOPARK', 'doc_transport_setting_battery',       'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (127, 'doc_transport_setting_fuel',          'doc_transport_setting_fuel',          'AUTOPARK', 'doc_transport_setting_fuel',          'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (128, 'doc_transport_setting_inspection',    'doc_transport_setting_inspection',    'AUTOPARK', 'doc_transport_setting_inspection',    'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (129, 'doc_transport_setting_insurance',     'doc_transport_setting_insurance',     'AUTOPARK', 'doc_transport_setting_insurance',     'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (130, 'doc_transport_setting_liquid',        'doc_transport_setting_liquid',        'AUTOPARK', 'doc_transport_setting_liquid',        'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (131, 'doc_transport_setting_oil',           'doc_transport_setting_oil',           'AUTOPARK', 'doc_transport_setting_oil',           'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (132, 'doc_transport_setting_tire',          'doc_transport_setting_tire',          'AUTOPARK', 'doc_transport_setting_tire',          'TABLE');

-- AUTOPARK / ACC
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (133, 'acc_driver_penalty', 'acc_driver_penalty', 'AUTOPARK', 'acc_driver_penalty', 'DOC');

-- QR (ma'lumot uchun, qr schema o'zgartirilmaydi)
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (134, 'doc_machine_readable_code_setting',         'doc_machine_readable_code_setting',         'QR', 'doc_machine_readable_code_setting',         'DOC');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (135, 'doc_machine_readable_code_setting_history',  'doc_machine_readable_code_setting_history',  'QR', 'doc_machine_readable_code_setting_history',  'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (136, 'doc_machine_readable_code_setting_table',    'doc_machine_readable_code_setting_table',    'QR', 'doc_machine_readable_code_setting_table',    'TABLE');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (137, 'enum_code_form_type',                        'enum_code_form_type',                        'QR', 'enum_code_form_type',                        'ENUM');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (138, 'enum_qr_code_state',                         'enum_qr_code_state',                         'QR', 'enum_qr_code_state',                         'ENUM');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (139, 'enum_qr_code_type',                          'enum_qr_code_type',                          'QR', 'enum_qr_code_type',                          'ENUM');
INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type) VALUES (140, 'sys_qr_code_registry',                       'sys_qr_code_registry',                       'QR', 'sys_qr_code_registry',                       'SYS');
