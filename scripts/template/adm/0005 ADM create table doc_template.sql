CREATE TABLE adm.doc_template (
    id BIGINT GENERATED ALWAYS AS IDENTITY,

    doc_number          VARCHAR(30) NOT NULL,
    doc_on              DATE NOT NULL,
    details             VARCHAR(600),

    message             VARCHAR(600),
    table_id            INTEGER NOT NULL,
    status_id           INTEGER NOT NULL,
    organization_id     INTEGER NOT NULL,

    created_at          TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_by          BIGINT,
    last_modified_at    TIMESTAMP WITHOUT TIME ZONE,
    last_modified_by    BIGINT,

    CONSTRAINT pk_adm__doc_template 
        PRIMARY KEY(id),

    CONSTRAINT ux_adm__doc_template__organization_id__doc_number 
        UNIQUE (organization_id, doc_number),

    CONSTRAINT fk_adm__doc_template__table_id 
        FOREIGN KEY (table_id) REFERENCES adm.sys_table (id),

    CONSTRAINT fk_adm__doc_template__status_id 
        FOREIGN KEY (status_id) REFERENCES adm.enum_status (id),

    CONSTRAINT fk_adm__doc_template__organization_id 
        FOREIGN KEY (organization_id) REFERENCES adm.info_organization (id)
);

CREATE INDEX ix_adm__doc_template__organization_id__status_id__doc_on
    ON adm.doc_template (organization_id, status_id, doc_on);

INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type)
VALUES (0, 'doc_template', 'doc_template', 'ADM', 'doc_template', 'DOC');

INSERT INTO adm.sys_number_template (date_at, document_name, template_pattern)
VALUES (CURRENT_TIMESTAMP, 'ADM_DOC_TEMPLATE', '{organizationid:0000}-{financeyear}-{nextnumber:0000}');