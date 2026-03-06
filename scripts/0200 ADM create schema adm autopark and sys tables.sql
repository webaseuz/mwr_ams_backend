-- ============================================================
-- 0200 ADM create schema adm autopark and sys tables.sql
-- ============================================================

CREATE SCHEMA IF NOT EXISTS adm;
CREATE SCHEMA IF NOT EXISTS autopark;

-- ============================================================
-- adm.sys_table
-- ============================================================
CREATE TABLE adm.sys_table (
    id                  INTEGER NOT NULL,

    short_name          VARCHAR(250)                NOT NULL,
    full_name           VARCHAR(250)                NOT NULL,
    db_schema_name      VARCHAR(50)                 NOT NULL,
    db_table_name       VARCHAR(250)                NOT NULL,
    table_type          VARCHAR(20)                 NOT NULL,

    created_at          TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_by          BIGINT,
    last_modified_at    TIMESTAMP WITHOUT TIME ZONE,
    last_modified_by    BIGINT,

    CONSTRAINT pk_adm__sys_table PRIMARY KEY (id)
);

-- ============================================================
-- adm.sys_table_translate
-- ============================================================
CREATE TABLE adm.sys_table_translate (
    id              INTEGER GENERATED ALWAYS AS IDENTITY NOT NULL,

    owner_id        INTEGER         NOT NULL,
    language_id     INTEGER         NOT NULL,
    column_name     VARCHAR(100)    NOT NULL,
    translate_text  VARCHAR(500)    NOT NULL,

    created_at          TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_by          BIGINT,
    last_modified_at    TIMESTAMP WITHOUT TIME ZONE,
    last_modified_by    BIGINT,

    CONSTRAINT pk_adm__sys_table_translate PRIMARY KEY (id),

    CONSTRAINT uc_adm__sys_table_translate__lang
        UNIQUE (owner_id, language_id, column_name),

    CONSTRAINT fk_adm__sys_table_translate__owner_id
        FOREIGN KEY (owner_id) REFERENCES adm.sys_table (id),

    CONSTRAINT fk_adm__sys_table_translate__language_id
        FOREIGN KEY (language_id) REFERENCES adm.enum_language (id)
);

-- ============================================================
-- adm.sys_row_change_log
-- ============================================================
CREATE TABLE adm.sys_row_change_log (
    id                  BIGINT GENERATED ALWAYS AS IDENTITY NOT NULL,

    date_at             TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    user_id             BIGINT                      NOT NULL,
    user_info           TEXT                        NOT NULL,
    table_id            INTEGER                     NOT NULL,
    row_id              BIGINT                      NOT NULL,
    ip_address          VARCHAR(50),
    user_agent          VARCHAR(250),
    message             VARCHAR(500),
    organization_id     INTEGER,
    request_trace_id    VARCHAR(50),

    CONSTRAINT pk_adm__sys_row_change_log PRIMARY KEY (id),

    CONSTRAINT fk_adm__sys_row_change_log__table_id
        FOREIGN KEY (table_id) REFERENCES adm.sys_table (id),

    CONSTRAINT fk_adm__sys_row_change_log__organization_id
        FOREIGN KEY (organization_id) REFERENCES adm.info_organization (id)
);

CREATE INDEX ix_adm__sys_row_change_log__table_row
    ON adm.sys_row_change_log (table_id, row_id);
