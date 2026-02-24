-- FUNCTION: public.get_spare_turnover_report_json(integer, integer, integer, integer, character varying, text, text)

-- DROP FUNCTION IF EXISTS public.get_spare_turnover_report_json(integer, integer, integer, integer, character varying, text, text);

CREATE OR REPLACE FUNCTION public.get_spare_turnover_report_json(
	p_branch_id integer DEFAULT NULL::integer,
	p_device_type_id integer DEFAULT NULL::integer,
	p_page_size integer DEFAULT 10,
	p_page_index integer DEFAULT 1,
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
    actual_sort_by text := COALESCE(p_sort_by, 'device_spare_type_name');
    actual_order_by text := COALESCE(p_order_by, 'asc');
    result jsonb;
BEGIN
    -- Sort ustunlarini tekshirish
    IF lower(actual_sort_by) NOT IN (
        'income_quantity', 'income_date', 'expense_quantity', 'expense_date',
        'device_spare_type_name', 'nomenclature', 'quantity'
    ) THEN
        RAISE EXCEPTION 'Invalid sort column: %', actual_sort_by;
    END IF;

    IF lower(actual_order_by) NOT IN ('asc', 'desc') THEN
        RAISE EXCEPTION 'Invalid sort order: %', actual_order_by;
    END IF;

    sort_sql := format('ORDER BY %I %s', actual_sort_by, upper(actual_order_by));

    EXECUTE format($f$
        WITH inc AS (
            SELECT
			sub.device_spare_type_id,
			sub.quantity as income_quantity,
			sub.doc_date as income_date
			FROM (
			    SELECT
					s.device_spare_type_id,
            		s.quantity,
            		s.doc_date,
			        ROW_NUMBER() OVER (
			            PARTITION BY s.device_spare_type_id
			            ORDER BY s.created_at DESC
			        ) AS rn
			    FROM acc_spare_turnover s
			    WHERE s.is_deleted = false
			      AND s.is_debit = true
			) sub
			WHERE sub.rn = 1
        ), exp AS (
            SELECT
			sub.device_spare_type_id,
			sub.quantity as expense_quantity,
			sub.doc_date as expense_date
			from(
					SELECT
						s.device_spare_type_id,
						s.quantity,
            			s.doc_date,
				        ROW_NUMBER() OVER (
				            PARTITION BY s.device_spare_type_id
				            ORDER BY s.created_at DESC
				        ) AS rn
				    FROM acc_spare_turnover s
				    WHERE s.is_deleted = false
				      AND s.is_debit = FALSE
				)
			sub
			WHERE sub.rn = 1
			)
        , data AS (
            SELECT
                inc.income_quantity,
                inc.income_date,
                exp.expense_quantity,
                exp.expense_date,
				dst.id as device_spare_type_id,
                CAST(dst.short_name AS text) AS device_spare_type_name,
                CAST(dst.nomenclature AS text) AS nomenclature,
                pst.quantity,
				br.id as branch_id,
				CAST(br.short_name AS text) AS branch_name
            FROM info_device_spare_type dst
            LEFT JOIN inc ON inc.device_spare_type_id = dst.id
            LEFT JOIN exp ON exp.device_spare_type_id = dst.id
            LEFT JOIN acc_present_spare_turnover pst ON pst.device_spare_type_id = dst.id
			LEFT JOIN hl_branch br ON br.id = pst.branch_id
            WHERE pst.is_deleted = false
              AND dst.is_deleted = false
              AND ($1 IS NULL OR pst.branch_id = $1)
              AND dst.device_type_id = $2
              AND ($3 IS NULL OR dst.short_name ILIKE '%%' || $3 || '%%'
			  				   OR dst.nomenclature ILIKE '%%' || $3 || '%%')
        )
        SELECT jsonb_build_object(
            'page_index', $5,
            'page_size', $4,
            'total', (SELECT COUNT(*) FROM data),
            'items', (SELECT jsonb_agg(to_jsonb(d)) FROM (
                SELECT * FROM data %s LIMIT $4 OFFSET $4 * ($5 - 1)
            ) d)
        )
    $f$, sort_sql)
    INTO result
    USING p_branch_id, p_device_type_id, p_search, p_page_size, p_page_index;

    RETURN result;
END;
$BODY$;

ALTER FUNCTION public.get_spare_turnover_report_json(integer, integer, integer, integer, character varying, text, text)
    OWNER TO postgres;
