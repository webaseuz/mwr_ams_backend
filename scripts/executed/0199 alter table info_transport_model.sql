alter table info_transport_model
add column consumption_per_100km numeric(10,2) not null default 0;

alter table info_transport_model
alter column consumption_per_100km drop default;

alter table info_transport_model
add column consumption_per_hour numeric(10,2) not null default 0;

alter table info_transport_model
alter column consumption_per_hour drop default;