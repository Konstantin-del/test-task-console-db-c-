hello!
Использовал c# .net console app, он не запускается отдельными файлами, поэтому 
сделал выбор действия через консоль.

DB - postgresql

Запрос, выборка сотрудников по фамилии которая начинается с f и полу, занимает 860+- миллисекунд.

Обычно для ускорения выборки можно добавить индекс для столбца по которому осуществляется поиск,
в этом случае поиск осуществляется не перебором каждой строки
а по присвоенному индексу через бинарное дерево, что обычно сокращает время поиска.
Однако в текущей ситуации практически каждое значение столбца FullName уникально и не группируется по индексу, 
Возможно, по этому от использования индекса время запроса не изменилось.
