# Класс для добавления информации в базу данных
### :arrow_right_hook: [**Вернуться**](https://github.com/Sekfiser/Client-Server-Project/wiki/Документация-классов-методов)
```C#
    public class DBDataModifyFuncs
```

Конструктор 
```C#
  public DBDataModifyFuncs(MySqlConnection gettedConnection)
```

Метод для занесения данных в таблицу Timetable
```C#
public void timetableIns(int lesstimeid, int chetid,int dayid, int roomid,int groupid, int proffesorid, int lessonid,int lesstypeid)
```

Метод для заполнения данных в таблицу
```C#
//Модель данных десериализованной из YAML-строки
 public void timetableIns(Timetable data)
```

Метод заполнение таблицы с предметами
```C#
 public void disciplineIns(String inData)
```
Метод вставка в таблицу аудитории
```C#
  public void classroomIns(int classroom, String frame)
```
Метод вставка в таблицу дисциплины
```C#
   public void disciplineIns(String discipline_name)
```
Метод вставка в таблицу факультет
```C#
   public void facultyIns(String faculty_name)
```
Метод вставка в таблицу время занятия
```C#
   public void lesson_timeIns(int lesson_time, String lesson_start, String lesson_finish)
```
Метод вставка в таблицу вид занятия
```C#
   public void lesson_typeIns(String inData)
```
Метод вставка в таблицу профессор
```C#
   public void professorsIns(String name,String surname,String patronymic)
```
Метод вставка в таблицу специальность
```C#
   public void specialityIns(String speciality_name, String abbreviated_speciality)
```
Метод вставка в таблицу группа
```C#
    public void study_groupsIns(String group_name,int id_faculty,int id_speciality,int course,String education_form)
```
Метод вставка в таблицу дни недели
```C#
    public void week_dayIns(String inData)
```
Метод вставка в таблицу вид недели
```C#
   public void week_parityIns(String inData)
```










