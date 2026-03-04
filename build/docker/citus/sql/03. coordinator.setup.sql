create extension citus;
SELECT citus_add_node('worker', 5432);
SELECT citus_is_coordinator();