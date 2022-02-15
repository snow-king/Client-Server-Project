# Класс для получение информации из базы данных
### :arrow_right_hook: [**Вернуться**](https://github.com/Sekfiser/Client-Server-Project/wiki/Документация-классов-методов)
```C#
public class DBSelectsFuncs
```
Конструктор
```C#
 public DBSelectsFuncs(MySqlConnection gettedConnection)
```
Метод вывести все занятия по id профессора
```C#
public String getLessonsByProffesor(int professorId) 
```
Метод вывести всё что есть в главной таблице
```C#
public String getAll()
```
