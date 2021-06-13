# Тестовое задание Junior .NET Core 66бит
### Web-приложения «Каталог футболистов 3.0».
### Приложение состоит из двух страниц с переключателем между ними.
1. Первая страница предоставляет пользователю функционал добавления футболистов и
содержит следующие поля:
    * Имя
    * Фамилия
    * Пол
    * Дата рождения
    * Название команды (позволяет выбрать одну из уже добавленных ранее
      команд, а если такой команды еще не было добавлено, то, добавить её непосредственно
      здесь (не переходя на другую страницу))
    * Страна (список стран фиксированный и не подлежит изменению пользователями
      системы: Россия, США, Италия)
2. Вторая страница отображает актуальный список добавленных в систему
футболистов. Возле каждого футболиста присутствует кнопка редактирования,
обеспечивающая возможность изменить данные по выбранному футболисту.
3. Внедрен SignalR для отображения данных из пункта 2 в режиме реального времени
### Стек технологий: C#, ASP NET Core 5, PostgreSQL. 
