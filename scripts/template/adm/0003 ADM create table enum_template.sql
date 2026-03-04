CREATE TABLE adm.enum_template (
    id                      INT NOT NULL,
    order_code              VARCHAR(4),
    code                    VARCHAR(20) NOT NULL,
    
    short_name              VARCHAR(250) NOT NULL,
    full_name               VARCHAR(300) NOT NULL,

    state_id                INT NOT NULL,
    
    created_at              TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT NOW(),
    last_modified_at        TIMESTAMP WITHOUT TIME ZONE,
    
    CONSTRAINT pk_adm__enum_template 
        PRIMARY KEY (id),
        
    CONSTRAINT pk_adm__enum_template__state_id 
        FOREIGN KEY (state_id) 
        REFERENCES adm.enum_state (id)
);

INSERT INTO adm.sys_table (id, short_name, full_name, db_schema_name, db_table_name, table_type)
 VALUES (0, 'enum_template', 'enum_template', 'ADM', 'enum_template', 'ENUM');