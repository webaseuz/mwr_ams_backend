INSERT INTO enum_gender_translate(owner_id,language_id,column_name,translate_text)
(SELECT (SELECT ID FROM enum_state WHERE ID=1 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'short_name',E'Мужчина')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=1 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'full_name',E'Мужчина')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=1 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'short_name',E'Эркак')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=1 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'full_name',E'Эркак')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=1 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'short_name',E'Erkak')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=1 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'full_name',E'Erkak')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=1 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'short_name',E'Male')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=1 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'full_name',E'Male')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=2 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'short_name',E'Женщина')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=2 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'full_name',E'Женщина')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=2 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'short_name',E'Аёл')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=2 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'full_name',E'Аёл')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=2 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'short_name',E'Ayol')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=2 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'full_name',E'Ayol')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=2 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'short_name',E'Female')UNION ALL
(SELECT (SELECT ID FROM enum_state WHERE ID=2 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'full_name',E'Female');