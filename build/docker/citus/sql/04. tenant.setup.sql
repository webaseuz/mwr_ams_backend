-- user
CREATE USER tenant_1 WITH PASSWORD 'ten@pass';

-- role
ALTER ROLE tenant_1 
LOGIN		                 -- can login?
NOSUPERUSER		             -- is super user?
NOCREATEROLE	             -- can create roles?
NOCREATEDB		             -- can create databases? 
INHERIT                       -- can inherit rights from the parent roles? 
NOREPLICATION	             -- can initiate streaming replication and perform backups? 
NOBYPASSRLS		             -- can bypass row level security? 
;

-- access
GRANT pg_read_all_data TO tenant_1;
GRANT pg_write_all_data TO tenant_1;

-- role
INSERT INTO adm.dt_sys_role 
(order_code, short_name, full_name, is_admin, tenant_id)
VALUES
('01', 'Админ', 'Администратор', true, 1);