# Класс для получение информации из базы данных
### :arrow_right_hook: [**Вернуться**](https://github.com/Sekfiser/Client-Server-Project/wiki/Документация-классов-методов)
```C#
public class DBSelectsFuncs
```
Конструктор
```C#
// На вход идет потключение к базе данных
 public DBSelectsFuncs(MySqlConnection gettedConnection)
     {
            connection = gettedConnection;
     }
```
Метод вывести все занятия по ФИО профессора
```C#
// Возвращает ФИО профессора, назавание дисциплины, аудитория, начало/конец занятия, вид занятия, группу, день недели, тип недели(числитель знаминетель),учебный корпус
 public String getLessonsByProffesorNSR(String proffesorName, String professorSurname, String professorPatronymic) 
```
Метод вывести всё что есть в главной таблице
```C#
public String getAll()
```
