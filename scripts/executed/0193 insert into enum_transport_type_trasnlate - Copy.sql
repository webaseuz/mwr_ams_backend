-- Легковой автомобиль (id=1)
INSERT INTO enum_transport_type_translate (owner_id, language_id, column_name, translate_text, is_deleted, created_at)
VALUES 
(1, 1, 'short_name', E'Легковой автомобиль', false, now()),
(1, 2, 'short_name', 'Yengil avtomobil', false, now()),
(1, 3, 'short_name', 'Yengil avtomobil', false, now()),
(1, 4, 'short_name', 'Passenger car', false, now()),
(1, 5, 'short_name', E'Жеңил автокөлік', false, now()),

(1, 1, 'full_name', E'Легковой автомобиль', false, now()),
(1, 2, 'full_name', 'Yengil avtomobil', false, now()),
(1, 3, 'full_name', 'Yengil avtomobil', false, now()),
(1, 4, 'full_name', 'Passenger car', false, now()),
(1, 5, 'full_name', E'Жеңил автокөлік', false, now());

-- Грузовик (id=2)
INSERT INTO enum_transport_type_translate (owner_id, language_id, column_name, translate_text, is_deleted, created_at)
VALUES 
(2, 1, 'short_name', E'Грузовик', false, now()),
(2, 2, 'short_name', 'Yuk mashinasi', false, now()),
(2, 3, 'short_name', 'Yuk mashinasi', false, now()),
(2, 4, 'short_name', 'Truck', false, now()),
(2, 5, 'short_name', E'Жүк көлігі', false, now()),

(2, 1, 'full_name', E'Грузовик', false, now()),
(2, 2, 'full_name', 'Yuk mashinasi', false, now()),
(2, 3, 'full_name', 'Yuk mashinasi', false, now()),
(2, 4, 'full_name', 'Truck', false, now()),
(2, 5, 'full_name', E'Жүк көлігі', false, now());
