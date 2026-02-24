-- FUNCTION: public.get_turnovers(integer, integer, boolean, integer, integer, date, date, character varying, text, text)

-- DROP FUNCTION IF EXISTS public.get_turnovers(integer, integer, boolean, integer, integer, date, date, character varying, text, text);

CREATE OR REPLACE FUNCTION public.get_turnovers(
	p_branch_id integer,
	p_device_spare_type_id integer,
	p_is_debit boolean,
	p_page_size integer,
	p_page integer,
	p_from_date date DEFAULT NULL::date,
	p_to_date date DEFAULT NULL::date,
	p_search character varying DEFAULT NULL::character varying,
	p_sort_by text DEFAULT NULL::text,
	p_order_by text DEFAULT NULL::text)
    RETURNS jsonb
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
DECLARE
    sort_sql text;
    actual_sort_by text := COALESCE(p_sort_by, 'created_at');
    actual_order_by text := COALESCE(p_order_by, 'desc');
	result jsonb;
BEGIN
    IF lower(actual_sort_by) NOT IN (
         'created_at', 'branch_name', 'device_spare_type_name', 'nomenclature', 'quantity', 'is_debit'
    ) THEN
        RAISE EXCEPTION 'Invalid sort column: %', actual_sort_by;
    END IF;

    IF lower(actual_order_by) NOT IN ('asc', 'desc') THEN
        RAISE EXCEPTION 'Invalid sort order: %', actual_order_by;
    END IF;

    sort_sql := format('ORDER BY %I %s', actual_sort_by, upper(actual_order_by));

	EXECUTE format($f$
         WITH data AS (
            SELECT
                ast.created_at,
				ast.is_debit,
                dst.short_name as device_spare_type_name,
                dst.nomenclature,
				CAST(br.short_name AS text) AS branch_name,
				ast.quantity
            FROM acc_spare_turnover ast
			LEFT JOIN hl_branch br ON br.id = ast.branch_id
			LEFT JOIN  info_device_spare_type dst ON dst.id = ast.device_spare_type_id
            WHERE ast.is_deleted = false
				AND ast.branch_id = $1
				AND ast.device_spare_type_id = $2
				AND ast.is_debit = $6
				AND ($3 IS NULL OR dst.short_name ILIKE '%%' || $3 || '%%'
			  				   OR dst.nomenclature ILIKE '%%' || $3 || '%%')
				AND ($7 IS NULL OR ast.created_at >= $7)
				AND ($8 IS NULL OR ast.created_at <= $8)
        )
        SELECT jsonb_build_object(
            'page', $5,
            'page_size', $4,
            'total', (SELECT COUNT(*) FROM data),
            'items', (SELECT jsonb_agg(to_jsonb(d)) FROM (
                SELECT * FROM data %s LIMIT $4 OFFSET $4 * ($5 - 1)
            ) d)
        )
    $f$, sort_sql)
    INTO result
USING p_branch_id,                 
      p_device_spare_type_id,
      p_search,
      p_page_size,
      p_page,
      p_is_debit,
      p_from_date,	
      p_to_date;

    RETURN result;
	
END;
$BODY$;

ALTER FUNCTION public.get_turnovers(integer, integer, boolean, integer, integer, date, date, character varying, text, text)
    OWNER TO postgres;
