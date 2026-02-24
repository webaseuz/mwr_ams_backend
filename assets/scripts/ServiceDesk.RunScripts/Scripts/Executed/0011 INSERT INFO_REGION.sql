insert into info_region (code, soato, roaming_code, state_code, short_name, full_name, order_code, state_id, country_id)
(SELECT E'tash', E'1726', E'26', '01', E'Город Ташкент',E'Город Ташкент',E'01', 1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT E'tashreg', E'1727', E'27', '10', E'Ташкентская',E'Ташкентская',E'02',1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT E'and', E'1703', E'3', '60', E'Андижанская',E'Андижанская',E'03',1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT E'bukh', E'1706', E'6', '80', E'Бухарская',E'Бухарская',E'04',1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT E'jiz', E'1708', E'8', '25', E'Джизакская',E'Джизакская',E'05',1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT E'kk', E'1735', E'35', '95', E'Республика Каракалпакстан',E'Республика Каракалпакстан',E'06',1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT E'kash', E'1710', E'10', '70', E'Кашкадарьинская',E'Кашкадарьинская',E'07',1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT E'nav', E'1712', E'12', '85', E'Навоийская',E'Навоийская',E'08',1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT E'nam', E'1714', E'14', '50', E'Наманганская',E'Наманганская',E'09',1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT E'sam', E'1718', E'18', '30', E'Самаркандская',E'Самаркандская',E'10',1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT E'sur', E'1722', E'22', '75', E'Сурхандарьинская',E'Сурхандарьинская',E'11',1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT E'sir', E'1724', E'24', '20', E'Сырдарьинская',E'Сырдарьинская',E'12',1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT E'fer', E'1730', E'30', '40', E'Ферганская',E'Ферганская',E'13',1, id FROM info_country where text_code = 'UZB' limit 1)
UNION ALL
(SELECT E'khor', E'1733', E'33', '90', E'Хорезмская',E'Хорезмская',E'14',1, id FROM info_country where text_code = 'UZB' limit 1);