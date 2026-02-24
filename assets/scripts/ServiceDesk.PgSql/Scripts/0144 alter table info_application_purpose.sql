alter table info_application_purpose
add column device_type_id integer not null default 1;


alter table info_application_purpose
add CONSTRAINT fk_info_application_purpose_device_type
FOREIGN KEY (device_type_id) REFERENCES info_device_type(id);


alter table info_application_purpose
alter column device_type_id drop default;