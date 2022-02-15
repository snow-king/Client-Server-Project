# Класс для добавления информации в базу данных
```C#
    public class DBDataModifyFuncs
```

Конструктор 
```C#
  public DBDataModifyFuncs(MySqlConnection gettedConnection)
```

Метод заполнение главной таблицы
```C#
public void timetableIns(int lesstimeid, int chetid,int dayid, int roomid,int groupid, int proffesorid, int lessonid,int lesstypeid)
```

Метод заполнение таблицы с аудиториями
```C#
public void classroomIns(String inData)
```
Метод заполнение таблицы с предметами
```C#
 public void disciplineIns(String inData)
```
Метод заполнение таблицы с занятиями

```C#
public void lesson_timeIns(int inData)
```
Метод заполнение таблицы с видами занятий
```C#
public void lesson_typeIns(String inData)
```
Метод заполнение таблицы с преподавателями

```C#
 public void professorsIns(String inData)
```

Метод заполнение таблицы с учебными группами
```C#
public void study_groupsIns(String inData)
```

Метод заполнение таблицы с днями недель
```C#
 public void week_dayIns(String inData)
```
Метод заполнение таблицы с очередью недели
```C#
public void week_parityIns(String inData)
```



