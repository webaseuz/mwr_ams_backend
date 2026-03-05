INSERT INTO info_region_translate(owner_id,language_id,column_name,translate_text)
(SELECT (SELECT ID FROM info_region WHERE code=N'tash' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',E'Город Ташкент')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tash' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',E'Город Ташкент')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tash' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',E'Тошкент шаҳри')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tash' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',E'Тошкент шаҳри')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tash' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',E'Toshkent shahri')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tash' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',E'Toshkent shahri')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tash' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',E'Tashkent city')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tash' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',E'Tashkent city')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tashreg' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',E'Ташкентская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tashreg' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',E'Ташкентская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tashreg' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',E'Тошкент вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tashreg' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',E'Тошкент вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tashreg' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',E'Toshkent viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tashreg' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',E'Toshkent viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tashreg' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',E'Tashkent region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'tashreg' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',E'Tashkent region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'and' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',E'Андижанская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'and' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',E'Андижанская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'and' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',E'Андижон вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'and' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',E'Андижон вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'and' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',E'Andijon viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'and' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',E'Andijon viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'and' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',E'Andijon region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'and' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',E'Andijon region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'bukh' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',E'Бухарская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'bukh' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',E'Бухарская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'bukh' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',E'Бухоро вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'bukh' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',E'Бухоро вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'bukh' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',E'Buxoro viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'bukh' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',E'Buxoro viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'bukh' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',E'Bukhara region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'bukh' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',E'Bukhara region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'jiz' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',E'Джизакская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'jiz' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',E'Джизакская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'jiz' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',E'Жиззах вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'jiz' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',E'Жиззах вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'jiz' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',E'Jizzax viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'jiz' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',E'Jizzax viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'jiz' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',E'Jizzakh region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'jiz' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',E'Jizzakh region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kk' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',E'Республика Каракалпакстан')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kk' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',E'Республика Каракалпакстан')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kk' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',E'Қорақалпоғистон Республикаси')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kk' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',E'Қорақалпоғистон Республикаси')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kk' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',E'Qoraqolpog`iston Respublikasi')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kk' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',E'Qoraqolpog`iston Respublikasi')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kk' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',E'Republic of Karakalpakstan')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kk' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',E'Republic of Karakalpakstan')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kash' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',E'Кашкадарьинская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kash' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',E'Кашкадарьинская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kash' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',E'Қашкадарё вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kash' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',E'Қашкадарё вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kash' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',E'Qashqadaryo viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kash' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',E'Qashqadaryo viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kash' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',E'Qashqadaryo region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'kash' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',E'Qashqadaryo region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nav' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',E'Навоийская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nav' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',E'Навоийская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nav' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',E'Навоий вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nav' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',E'Навоий вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nav' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',E'Navoiy viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nav' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',E'Navoiy viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nav' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',E'Navoiy region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nav' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',E'Navoiy region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nam' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',E'Наманганская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nam' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',E'Наманганская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nam' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',E'Наманган вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nam' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',E'Наманган вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nam' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',E'Namangan viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nam' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',E'Namangan viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nam' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',E'Namangan region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'nam' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',E'Namangan region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sam' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',E'Самаркандская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sam' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',E'Самаркандская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sam' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',E'Самарқанд вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sam' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',E'Самарқанд вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sam' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',E'Samarqand viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sam' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',E'Samarqand viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sam' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',E'Samarkand region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sam' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',E'Samarkand region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sur' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',E'Сурхандарьинская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sur' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',E'Сурхандарьинская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sur' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',E'Сурхондарё вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sur' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',E'Сурхондарё вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sur' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',E'Surxandaryo viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sur' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',E'Surxandaryo viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sur' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',E'Surkhandarya region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sur' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',E'Surkhandarya region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sir' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',E'Сырдарьинская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sir' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',E'Сырдарьинская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sir' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',E'Сирдарё  вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sir' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',E'Сирдарё вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sir' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',E'Sirdaryo viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sir' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',E'Sirdaryo viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sir' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',E'Sirdaryo region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'sir' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',E'Sirdaryo region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'fer' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',E'Ферганская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'fer' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',E'Ферганская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'fer' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',E'Фарғона  вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'fer' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',E'Фарғона вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'fer' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',E'Farg`ona viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'fer' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',E'Farg`ona viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'fer' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',E'Fergana region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'fer' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',E'Fergana region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'khor' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'short_name',E'Хорезмская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'khor' limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1), N'full_name',E'Хорезмская')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'khor' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'short_name',E'Хоразм  вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'khor' limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1), N'full_name',E'Хоразм вилояти')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'khor' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'short_name',E'Xorazm viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'khor' limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1), N'full_name',E'Xorazm viloyati')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'khor' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'short_name',E'Khorezm region')
UNION ALL
(SELECT (SELECT ID FROM info_region WHERE code=N'khor' limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1), N'full_name',E'Khorezm region');