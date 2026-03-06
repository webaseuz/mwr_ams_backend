-- ============================================================
-- 0203 ADM create table enum_app.sql
-- ============================================================


-- ============================================================
-- adm.enum_app
-- ============================================================
CREATE TABLE adm.enum_app (
    id              INT                         NOT NULL,
    order_code      VARCHAR(4),
    code            VARCHAR(20)                 NOT NULL,

    short_name      VARCHAR(250)                NOT NULL,
    full_name       VARCHAR(250)                NOT NULL,

    state_id        INT                         NOT NULL,

    created_at      TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT NOW(),
    last_modified_at TIMESTAMP WITHOUT TIME ZONE,

    CONSTRAINT pk_adm__enum_app
        PRIMARY KEY (id),

    CONSTRAINT fk_adm__enum_app__state_id
        FOREIGN KEY (state_id)
        REFERENCES adm.enum_state (id)
);

INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type)
VALUES (141, 'enum_app', 'enum_app', 'ADM', 'enum_app', 'ENUM');


-- ============================================================
-- Insert apps (id matches AppIdConst)
-- ============================================================
INSERT INTO adm.enum_app (id, order_code, code, short_name, full_name, state_id)
VALUES
    (1, '01', 'ADM',      'ADM',      'ADM',      1),
    (2, '02', 'FIN',      'FIN',      'FIN',      1),
    (3, '03', 'AUTOPARK', 'AUTOPARK', 'AUTOPARK', 1),
    (4, '04', 'INV',      'INV',      'INV',      1),
    (5, '05', 'QR',       'QR',       'QR',       1);


-- ============================================================
-- Foreign keys: sys_permission.app_id / source_app_id → enum_app
-- ============================================================
ALTER TABLE adm.sys_permission
    ADD CONSTRAINT fk_adm__sys_permission__app_id
        FOREIGN KEY (app_id) REFERENCES adm.enum_app (id);

ALTER TABLE adm.sys_permission
    ADD CONSTRAINT fk_adm__sys_permission__source_app_id
        FOREIGN KEY (source_app_id) REFERENCES adm.enum_app (id);


-- ============================================================
-- Foreign keys: sys_permission_sub_group.app_id / source_app_id → enum_app
-- ============================================================
ALTER TABLE adm.sys_permission_sub_group
    ADD CONSTRAINT fk_adm__sys_permission_sub_group__app_id
        FOREIGN KEY (app_id) REFERENCES adm.enum_app (id);

ALTER TABLE adm.sys_permission_sub_group
    ADD CONSTRAINT fk_adm__sys_permission_sub_group__source_app_id
        FOREIGN KEY (source_app_id) REFERENCES adm.enum_app (id);
