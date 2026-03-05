alter table enum_transport_type
rename to info_transport_type;


alter table enum_transport_type_translate
rename to info_transport_type_translate;


CREATE SEQUENCE info_transport_type_id_seq
START 3;

ALTER TABLE info_transport_type
ALTER COLUMN id SET DEFAULT nextval('info_transport_type_id_seq');

