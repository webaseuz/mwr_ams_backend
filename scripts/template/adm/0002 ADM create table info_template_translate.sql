CREATE TABLE adm.info_template_translate (
    id                      INTEGER GENERATED ALWAYS AS IDENTITY NOT NULL,
    
    owner_id                INTEGER                                  NOT NULL,
    language_id             INTEGER                                  NOT NULL,
    column_name             VARCHAR(100)                             NOT NULL,
    translate_text          VARCHAR(500)                             NOT NULL,
    
    created_at              TIMESTAMP WITHOUT TIME ZONE              NOT NULL DEFAULT NOW(),
    created_by              BIGINT,
    last_modified_at        TIMESTAMP WITHOUT TIME ZONE,
    last_modified_by        BIGINT,
    
    CONSTRAINT pk_adm__info_template__translate 
        PRIMARY KEY (id),
        
    CONSTRAINT uc_adm_info__template_translate__lang 
        UNIQUE (owner_id, language_id, column_name),
        
    CONSTRAINT fk_adm__info_template_translate__owner_id 
        FOREIGN KEY (owner_id) 
        REFERENCES adm.info_template (id),
        
    CONSTRAINT fk_adm__info_template_translate__language_id 
        FOREIGN KEY (language_id) 
        REFERENCES adm.enum_language (id)
);


INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type)
 VALUES (0, 'info_template_translate', 'info_template_translate', 'ADM', 'info_template_translate', 'TRANSLATE');