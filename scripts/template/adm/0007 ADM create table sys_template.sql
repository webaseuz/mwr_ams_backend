CREATE TABLE adm.sys_template (
    id BIGINT GENERATED ALWAYS AS IDENTITY,

    doc_table_id     INTEGER NOT NULL,
    doc_id           BIGINT NOT NULL,
    organization_id  INTEGER NOT NULL,
    doc_on           DATE NOT NULL,
    is_deleted       BOOLEAN,

    message          VARCHAR(500),

    created_at          TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_by          BIGINT,
    last_modified_at    TIMESTAMP WITHOUT TIME ZONE,
    last_modified_by    BIGINT,
    
    CONSTRAINT pk_adm__sys_template 
       PRIMARY KEY (id),

    CONSTRAINT fk_adm__sys_template__doc_table_id 
        FOREIGN KEY (doc_table_id) REFERENCES adm.sys_table(id),

    CONSTRAINT fk_adm__sys_template__organization_id 
        FOREIGN KEY (organization_id) REFERENCES adm.info_organization(id)
);

CREATE INDEX ix_adm__sys_template__doc_table_id__doc_id
    ON adm.sys_template(doc_table_id, doc_id);

INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type)
VALUES (0, 'sys_template', 'sys_template', 'ADM', 'sys_template', 'SYS');