-- Устройства самообслуживания (id=1)
INSERT INTO enum_base_device_type_translate (owner_id, language_id, column_name, translate_text, is_deleted, created_at) VALUES
(1, 1, 'short_name', E'УС', false, now()),
(1, 2, 'short_name', E'ЎС', false, now()),
(1, 3, 'short_name', 'US', false, now()),
(1, 4, 'short_name', 'SS', false, now()),
(1, 5, 'short_name', E'ӨС', false, now()),

(1, 1, 'full_name', E'Устройства самообслуживания', false, now()),
(1, 2, 'full_name', E'Ўз-ўзини хизмат кўрсатиш қурилмалари', false, now()),
(1, 3, 'full_name', 'O‘z-o‘ziga xizmat ko‘rsatish qurilmalari', false, now()),
(1, 4, 'full_name', 'Self-service devices', false, now()),
(1, 5, 'full_name', E'Өз-өзіне қызмет көрсету құрылғылары', false, now());

-- Автомобили (id=2)
INSERT INTO enum_base_device_type_translate (owner_id, language_id, column_name, translate_text, is_deleted, created_at) VALUES
(2, 1, 'short_name', E'АВТ', false, now()),
(2, 2, 'short_name', E'АВТ', false, now()),
(2, 3, 'short_name', 'AVT', false, now()),
(2, 4, 'short_name', 'CAR', false, now()),
(2, 5, 'short_name', E'АВТ', false, now()),

(2, 1, 'full_name', E'Автомобили', false, now()),
(2, 2, 'full_name', E'Автомобиллар', false, now()),
(2, 3, 'full_name', 'Avtomobillar', false, now()),
(2, 4, 'full_name', 'Cars', false, now()),
(2, 5, 'full_name', E'Автомобильлер', false, now());

-- Кассовая техника (id=3)
INSERT INTO enum_base_device_type_translate (owner_id, language_id, column_name, translate_text, is_deleted, created_at) VALUES
(3, 1, 'short_name', E'КТ', false, now()),
(3, 2, 'short_name', E'КТ', false, now()),
(3, 3, 'short_name', 'KT', false, now()),
(3, 4, 'short_name', 'CR', false, now()),
(3, 5, 'short_name', E'КТ', false, now()),

(3, 1, 'full_name', E'Кассовая техника', false, now()),
(3, 2, 'full_name', E'Кассалик техника', false, now()),
(3, 3, 'full_name', 'Kassalik texnika', false, now()),
(3, 4, 'full_name', 'Cash register devices', false, now()),
(3, 5, 'full_name', E'Кассалық техника', false, now());
