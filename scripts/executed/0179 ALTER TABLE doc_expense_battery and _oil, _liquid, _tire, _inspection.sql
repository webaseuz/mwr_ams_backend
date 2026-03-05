ALTER TABLE public.doc_expense_battery
ADD COLUMN MILE_AGE NUMERIC(18,2);

ALTER TABLE public.doc_expense_oil
ADD COLUMN MILE_AGE NUMERIC(18,2);

ALTER TABLE public.doc_expense_liquid
ADD COLUMN MILE_AGE NUMERIC(18,2);

ALTER TABLE public.doc_expense_tire
ADD COLUMN MILE_AGE NUMERIC(18,2);

ALTER TABLE public.doc_expense_inspection
ADD COLUMN MILE_AGE NUMERIC(18,2);