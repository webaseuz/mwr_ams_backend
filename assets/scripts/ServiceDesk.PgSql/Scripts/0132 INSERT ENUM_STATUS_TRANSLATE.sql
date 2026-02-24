INSERT INTO enum_status_translate(owner_id,language_id,column_name,translate_text)
(SELECT (SELECT ID FROM enum_status WHERE ID=1 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'short_name',E'Соз')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=1 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'full_name',E'Создан')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=1 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'short_name',E'Яратилди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=1 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'full_name',E'Яратилган')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=1 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'short_name',E'Yaratildi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=1 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'full_name',E'Yaratilgan')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=1 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'short_name',E'Created')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=1 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'full_name',E'Created')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE ID=2 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'short_name',E'Изм')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=2 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'full_name',E'Изменен')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=2 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'short_name',E'Ўзгартирилди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=2 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'full_name',E'Ўзгартирилган')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=2 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'short_name',E'O‘zgartirildi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=2 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'full_name',E'O‘zgartirilgan')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=2 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'short_name',E'Modified')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=2 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'full_name',E'Modified')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE ID=3 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'short_name',E'Принятие')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=3 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'full_name',E'Принятие')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=3 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'short_name',E'Қабул қилинди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=3 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'full_name',E'Қабул қилинган')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=3 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'short_name',E'Qabul qilindi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=3 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'full_name',E'Qabul qilingan')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=3 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'short_name',E'Accepted')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=3 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'full_name',E'Accepted')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE ID=4 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'short_name',E'Отк')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=4 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'full_name',E'Отказан')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=4 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'short_name',E'Бекор қилинди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=4 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'full_name',E'Бекор қилинган')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=4 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'short_name',E'Bekor qilindi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=4 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'full_name',E'Bekor qilingan')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=4 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'short_name',E'Canceled')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=4 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'full_name',E'Canceled')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE ID=5 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'short_name',E'Удалено')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=5 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'full_name',E'Удалено')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=5 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'short_name',E'Ўчирилди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=5 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'full_name',E'Ўчириб ташланган')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=5 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'short_name',E'O‘chirildi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=5 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'full_name',E'O‘chirib tashlangan')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=5 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'short_name',E'Deleted')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=5 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'full_name',E'Deleted')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE ID=6 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'short_name',E'Отз')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=6 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'full_name',E'Отозван')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=6 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'short_name',E'Бекор қилинди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=6 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'full_name',E'Бекор қилинган')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=6 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'short_name',E'Bekor qilindi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=6 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'full_name',E'Bekor qilingan')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=6 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'short_name',E'Revoked')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=6 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'full_name',E'Revoked')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE ID=7 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'short_name',E'Отп')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=7 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'full_name',E'Отправлен')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=7 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'short_name',E'Юборилди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=7 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'full_name',E'Юборилган')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=7 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'short_name',E'Yuborildi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=7 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'full_name',E'Yuborilgan')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=7 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'short_name',E'Sent')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=7 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'full_name',E'Sent')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE ID=8 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'short_name',E'Пров')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=8 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'full_name',E'Проведено')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=8 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'short_name',E'Қабул қилинди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=8 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'full_name',E'Қабул қилинган')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=8 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'short_name',E'Qabul qilindi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=8 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'full_name',E'Qabul qilingan')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=8 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'short_name',E'Held')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=8 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'full_name',E'Held')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE ID=9 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'short_name',E'В проц')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=9 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'full_name',E'В процессе')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=9 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'short_name',E'Жараёнда')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=9 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'full_name',E'Жараёнда')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=9 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'short_name',E'Jarayonda')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=9 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'full_name',E'Jarayonda')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=9 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'short_name',E'In process')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=9 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'full_name',E'In process')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE ID=10 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'short_name',E'Зав')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=10 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'full_name',E'Завершено')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=10 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'short_name',E'Тугатилди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=10 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'full_name',E'Тугатилган')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=10 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'short_name',E'Tugatildi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=10 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'full_name',E'Tugatilgan')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=10 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'short_name',E'Finished')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=10 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'full_name',E'Finished')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE ID=11 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'short_name',E'Зав исп')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=11 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'full_name',E'Завершено исполнителем')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=11 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'short_name',E'Тугатилди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=11 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'full_name',E'Ижрочи томонидан якунланган')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=11 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'short_name',E'Tugatildi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=11 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'full_name',E'Ijrochi tomonidan yakunlangan')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=11 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'short_name',E'Finished by executor')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=11 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'full_name',E'Finished by executor')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE ID=12 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'short_name',E'Отправили на доработки')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=12 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'full_name',E'Отправили на доработки')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=12 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'short_name',E'Такомиллаштириш учун қайтарилган')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=12 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'full_name',E'Такомиллаштириш учун қайтарилган')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=12 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'short_name',E'Takomillashtirish uchun qaytarilgan')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=12 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'full_name',E'Takomillashtirish uchun qaytarilgan')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=12 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'short_name',E'Sent for rework')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=12 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'full_name',E'Sent for rework')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE ID=13 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'short_name',E'Отм исп')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=13 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'full_name',E'Отменено исполнителем')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=13 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'short_name',E'Бекор қилинди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=13 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'full_name',E'Ижрочи томонидан бекор қилинган')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=13 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'short_name',E'Bekor qilindi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=13 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'full_name',E'Ijrochi tomonidan bekor qilingan')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=13 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'short_name',E'Canceled by executor')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=13 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'full_name',E'Canceled by executor')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE ID=14 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'short_name',E'Ожи запчаст')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=14 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'full_name',E'Ожидание запчастей')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=14 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'short_name',E'Қисмлар кутилмоқда')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=14 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'full_name',E'Эҳтиёт қисмлар кутилмоқда')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=14 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'short_name',E'Qismlar kutilyapti')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=14 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'full_name',E'Ehtiyot qismlar kutilyapti')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=14 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'short_name',E'Wait spares')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=14 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'full_name',E'Wait spares')UNION ALL

(SELECT (SELECT ID FROM enum_status WHERE ID=15 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'short_name',E'Зав без исп')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=15 limit 1), (SELECT ID FROM enum_language WHERE code='ru' limit 1),E'full_name',E'Завершено без исполнения')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=15 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'short_name',E'Амалга оширилмади')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=15 limit 1), (SELECT ID FROM enum_language WHERE code='uz-cyrl' limit 1),E'full_name',E'Амалга оширилмасдан якунланди')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=15 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'short_name',E'Amalga oshirilmadi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=15 limit 1), (SELECT ID FROM enum_language WHERE code='uz-latn' limit 1),E'full_name',E'Amalga oshirilmasdan yakunlandi')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=15 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'short_name',E'Closed without execution')UNION ALL
(SELECT (SELECT ID FROM enum_status WHERE ID=15 limit 1), (SELECT ID FROM enum_language WHERE code='en' limit 1),E'full_name',E'Closed without execution')
;