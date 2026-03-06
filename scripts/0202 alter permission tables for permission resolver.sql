-- ============================================================
-- 0202 alter permission tables for permission resolver.sql
-- ============================================================
-- Changes:
--   1. Translate tables: remove is_deleted, add UNIQUE, remove ON DELETE CASCADE,
--      add/rename last_modified_at (required by BaseTranslateEntity)
--   2. sys_permission: add app_id, is_shared, source_app_id
--   3. sys_permission_sub_group: add app_id, order_code, is_shared, source_app_id
-- ============================================================


-- ============================================================
-- sys_permission_group_translate
-- ============================================================
ALTER TABLE adm.sys_permission_group_translate
    DROP COLUMN is_deleted;

ALTER TABLE adm.sys_permission_group_translate
    ADD COLUMN last_modified_at TIMESTAMP WITHOUT TIME ZONE;

-- Drop FK_OWNER_ID (ON DELETE CASCADE), recreate without CASCADE
ALTER TABLE adm.sys_permission_group_translate
    DROP CONSTRAINT fk_owner_id;
ALTER TABLE adm.sys_permission_group_translate
    ADD CONSTRAINT fk_adm__sys_permission_group_translate__owner_id
        FOREIGN KEY (owner_id) REFERENCES adm.sys_permission_group (id);

-- Rename FK_LANGUAGE_ID to new convention
ALTER TABLE adm.sys_permission_group_translate
    DROP CONSTRAINT fk_language_id;
ALTER TABLE adm.sys_permission_group_translate
    ADD CONSTRAINT fk_adm__sys_permission_group_translate__language_id
        FOREIGN KEY (language_id) REFERENCES adm.enum_language (id);

ALTER TABLE adm.sys_permission_group_translate
    ADD CONSTRAINT uc_adm__sys_permission_group_translate__lang
        UNIQUE (owner_id, language_id, column_name);


-- ============================================================
-- sys_permission_sub_group_translate
-- ============================================================
ALTER TABLE adm.sys_permission_sub_group_translate
    DROP COLUMN is_deleted;

-- Rename modified_at -> last_modified_at (BaseTranslateEntity maps to last_modified_at)
ALTER TABLE adm.sys_permission_sub_group_translate
    RENAME COLUMN modified_at TO last_modified_at;

-- Drop FK_OWNER_ID (ON DELETE CASCADE), recreate without CASCADE
ALTER TABLE adm.sys_permission_sub_group_translate
    DROP CONSTRAINT fk_owner_id;
ALTER TABLE adm.sys_permission_sub_group_translate
    ADD CONSTRAINT fk_adm__sys_permission_sub_group_translate__owner_id
        FOREIGN KEY (owner_id) REFERENCES adm.sys_permission_sub_group (id);

-- Rename FK_LANGUAGE_ID to new convention
ALTER TABLE adm.sys_permission_sub_group_translate
    DROP CONSTRAINT fk_language_id;
ALTER TABLE adm.sys_permission_sub_group_translate
    ADD CONSTRAINT fk_adm__sys_permission_sub_group_translate__language_id
        FOREIGN KEY (language_id) REFERENCES adm.enum_language (id);

ALTER TABLE adm.sys_permission_sub_group_translate
    ADD CONSTRAINT uc_adm__sys_permission_sub_group_translate__lang
        UNIQUE (owner_id, language_id, column_name);


-- ============================================================
-- sys_permission_translate
-- ============================================================
ALTER TABLE adm.sys_permission_translate
    DROP COLUMN is_deleted;

-- Rename modified_at -> last_modified_at
ALTER TABLE adm.sys_permission_translate
    RENAME COLUMN modified_at TO last_modified_at;

-- Drop FK_OWNER_ID (ON DELETE CASCADE), recreate without CASCADE
ALTER TABLE adm.sys_permission_translate
    DROP CONSTRAINT fk_owner_id;
ALTER TABLE adm.sys_permission_translate
    ADD CONSTRAINT fk_adm__sys_permission_translate__owner_id
        FOREIGN KEY (owner_id) REFERENCES adm.sys_permission (id);

-- Rename FK_LANGUAGE_ID to new convention
ALTER TABLE adm.sys_permission_translate
    DROP CONSTRAINT fk_language_id;
ALTER TABLE adm.sys_permission_translate
    ADD CONSTRAINT fk_adm__sys_permission_translate__language_id
        FOREIGN KEY (language_id) REFERENCES adm.enum_language (id);

ALTER TABLE adm.sys_permission_translate
    ADD CONSTRAINT uc_adm__sys_permission_translate__lang
        UNIQUE (owner_id, language_id, column_name);


-- ============================================================
-- sys_permission - add columns for PermissionResolver
--   app_id       : used in ResolvePermissionsAsync (filter by app)
--   is_shared    : used in UserAuthModelSelect (cross-app permissions)
--   source_app_id: used in UserAuthModelSelect (shared from which app)
-- ============================================================
ALTER TABLE adm.sys_permission
    ADD COLUMN app_id        INTEGER;
ALTER TABLE adm.sys_permission
    ADD COLUMN is_shared     BOOLEAN NOT NULL DEFAULT FALSE;
ALTER TABLE adm.sys_permission
    ADD COLUMN source_app_id INTEGER;

-- Set existing rows to ADM app_id = 1
UPDATE adm.sys_permission SET app_id = 1 WHERE app_id IS NULL;

ALTER TABLE adm.sys_permission
    ALTER COLUMN app_id SET NOT NULL;


-- ============================================================
-- sys_permission_sub_group - add columns for PermissionResolver
--   app_id       : used in ResolvePermissionsAsync (filter by app)
--   order_code   : used in ResolveSharedPermissionsAsync
--   is_shared    : used in ResolveSharedPermissionsAsync
--   source_app_id: used in ResolveSharedPermissionsAsync
-- ============================================================
ALTER TABLE adm.sys_permission_sub_group
    ADD COLUMN app_id        INTEGER;
ALTER TABLE adm.sys_permission_sub_group
    ADD COLUMN order_code    VARCHAR(50);
ALTER TABLE adm.sys_permission_sub_group
    ADD COLUMN is_shared     BOOLEAN NOT NULL DEFAULT FALSE;
ALTER TABLE adm.sys_permission_sub_group
    ADD COLUMN source_app_id INTEGER;

-- Set existing rows to ADM app_id = 1
UPDATE adm.sys_permission_sub_group SET app_id = 1 WHERE app_id IS NULL;

ALTER TABLE adm.sys_permission_sub_group
    ALTER COLUMN app_id SET NOT NULL;
