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
Метод вывести все занятия по ФИО профессора по дням недели и типу недели
```C#
// Возвращает ФИО профессора, назавание дисциплины, аудитория, начало/конец занятия, вид занятия, группу, день недели, тип недели(числитель знаминетель),учебный корпус
public String getLessonsByProffesorNSRDate(String proffesorName, String professorSurname, String professorPatronymic,String weekday,String parity)
```
Метод вывода занятий по группе
```C#
// Возвращает ФИО профессора, назавание дисциплины, аудитория, начало/конец занятия, вид занятия, группу, день недели, тип недели(числитель знаминетель),учебный корпус
public String getLessonsByGroup(String groupName)public String getLessonsByGroup(String groupName)
```
Метод вывода занятий группы в конкретный день
```C#
// Возвращает ФИО профессора, назавание дисциплины, аудитория, начало/конец занятия, вид занятия, группу, день недели, тип недели(числитель знаминетель),учебный корпус
 public String getLessonsByGroupDate(String groupName, String weekday, String parity)
```
Метод вывода занятий в аудитории
```C#
// Возвращает ФИО профессора, назавание дисциплины, аудитория, начало/конец занятия, вид занятия, группу, день недели, тип недели(числитель знаминетель),учебный корпус
public String getLessonsByClassrom(String classroom, String frame)
```
Метод вывода занятий в аудитории в выбраный день
```C#
// Возвращает ФИО профессора, назавание дисциплины, аудитория, начало/конец занятия, вид занятия, группу, день недели, тип недели(числитель знаминетель),учебный корпус
public String getLessonsByClassromDate(String classroom, String frame, String weekday, String parity)
```


Метод вывести всё что есть в главной таблице
```C#
//возвращает все айдишники
public String getAll()
```
