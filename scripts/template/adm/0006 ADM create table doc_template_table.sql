CREATE TABLE adm.doc_template_table (
    id BIGINT GENERATED ALWAYS AS IDENTITY,

    owner_id            BIGINT NOT NULL,

    created_at          TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_by          BIGINT,
    last_modified_at    TIMESTAMP WITHOUT TIME ZONE,
    last_modified_by    BIGINT,

    CONSTRAINT pk_adm__doc_template_table 
        PRIMARY KEY(id),

    CONSTRAINT fk_adm__doc_template_table__owner_id 
        FOREIGN KEY (owner_id) REFERENCES adm.doc_template (id)
);

CREATE INDEX ix_adm__doc_template_table__owner_id
    ON adm.doc_template_table (owner_id);

INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type)
VALUES (0, 'doc_template_table', 'doc_template_table', 'ADM', 'doc_template_table', 'TABLE');