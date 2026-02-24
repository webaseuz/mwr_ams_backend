
-- Kirim (Приход) uchun tarjimalar
INSERT INTO public.enum_movement_type_translate
(owner_id, language_id, column_name, translate_text, is_deleted, created_at)
VALUES
(1, 1, 'short_name', 'Приход', false, NOW()),      -- Ruscha
(1, 2, 'short_name', 'Кирим', false, NOW()),       -- O'zbekcha (kirill)
(1, 3, 'short_name', 'Kirim', false, NOW()),       -- O'zbekcha (lotin)
(1, 4, 'short_name', 'Income', false, NOW()),      -- Inglizcha
(1, 5, 'short_name', 'Кирис', false, NOW()),       -- Qoraqalpoqcha

(1, 1, 'full_name', 'Приход', false, NOW()),
(1, 2, 'full_name', 'Кирим', false, NOW()),
(1, 3, 'full_name', 'Kirim', false, NOW()),
(1, 4, 'full_name', 'Income', false, NOW()),
(1, 5, 'full_name', 'Кирис', false, NOW());

-- Chiqim (Расход) uchun tarjimalar
INSERT INTO public.enum_movement_type_translate
(owner_id, language_id, column_name, translate_text, is_deleted, created_at)
VALUES
(2, 1, 'short_name', 'Расход', false, NOW()),
(2, 2, 'short_name', 'Чиқим', false, NOW()),
(2, 3, 'short_name', 'Chiqim', false, NOW()),
(2, 4, 'short_name', 'Expense', false, NOW()),
(2, 5, 'short_name', 'Шыгим', false, NOW()),

(2, 1, 'full_name', 'Расход', false, NOW()),
(2, 2, 'full_name', 'Чиқим', false, NOW()),
(2, 3, 'full_name', 'Chiqim', false, NOW()),
(2, 4, 'full_name', 'Expense', false, NOW()),
(2, 5, 'full_name', 'Шыгим', false, NOW());

-- Ko'chirish (Перемещения) uchun tarjimalar
INSERT INTO public.enum_movement_type_translate
(owner_id, language_id, column_name, translate_text, is_deleted, created_at)
VALUES
(3, 1, 'short_name', 'Перемещения', false, NOW()),
(3, 2, 'short_name', 'Кўчириш', false, NOW()),
(3, 3, 'short_name', 'Ko‘chirish', false, NOW()),
(3, 4, 'short_name', 'Transfer', false, NOW()),
(3, 5, 'short_name', 'Көшиу', false, NOW()),

(3, 1, 'full_name', 'Перемещения', false, NOW()),
(3, 2, 'full_name', 'Кўчириш', false, NOW()),
(3, 3, 'full_name', 'Ko‘chirish', false, NOW()),
(3, 4, 'full_name', 'Transfer', false, NOW()),
(3, 5, 'full_name', 'Көшиу', false, NOW());
