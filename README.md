Пользователи(/user)

Запросы:

получение списка с пагинацией GET ("/page/{pageNumber:int}");

получение одного пользователя GET ("{userId:int}");

редактирование данных, кроме статуса PUT ("{userId:int}/update");

поставить задачу исполнителю PUT ("{userId:int}/set/task/{taskId:int}").

Задачи(/task)

Запросы:
получение списка задач пользователя-создателя с пагинацией GET ("setter/{userId:int}/page/{pageNumber:int}");

получение списка задач пользователя-исполнителя с пагинацией GET ("performer/{userId:int}/page/{pageNumber:int}");

получение одной задачи GET ("{taskId:int}");

редактирование данных, кроме статуса и создателя PUT ("{taskId:int}/update");

изменение статуса задачи PUT ("{taskId:int}/update/status/{taskStatus}");

смена постановщика PUT ("{userId:int}/set/setter/{taskId:int}").
