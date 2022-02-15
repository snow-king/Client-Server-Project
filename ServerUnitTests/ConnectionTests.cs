using NUnit.Framework;
using Server;

namespace ServerUnitTests
{
    public class Tests
    {
        
        /// <summary>
        /// Проверка создания подключения 
        /// </summary>
        [Test]
        public void Connection_Create_Does_Not_Throw()
        {
            Assert.DoesNotThrow(() => new SQLConnector());
        }
        /// <summary>
        /// Проверка обработки исключений и их возникновений в классе выборки информации
        /// </summary>
        [Test]
        public void Select_Requests_Does_Not_Throw()
        {
            var Connector = new SQLConnector();
            var SelectsFunc = new DBSelectsFuncs(Connector.Connection);
            Assert.DoesNotThrow(() => { 
                SelectsFunc.getAll();
                SelectsFunc.getLessonsByProffesor(1);
            }
            );
        }
        /// <summary>
        /// Проверка обработки исключений и их возникновений в классе вставки инфомрации
        /// </summary>
        [Test]
        public void Insert_Requests_Does_Not_Throw() 
        {
            var Connector = new SQLConnector();
            var DataModifyFuncs = new DBDataModifyFuncs(Connector.Connection);
            Assert.DoesNotThrow(() => { 
                DataModifyFuncs.timetableIns(2, 2, 2, 2, 1, 2, 2, 2);
                DataModifyFuncs.classroomIns(206, "Е");
                DataModifyFuncs.lesson_timeIns(8,"15:30","17:00");
                DataModifyFuncs.specialityIns("Информационные сисетмы", "ИС");
                DataModifyFuncs.study_groupsIns("ИС 1-18-1",1,1,4,"очное");
                DataModifyFuncs.disciplineIns("Что-то");
                DataModifyFuncs.facultyIns("Кто-то");
                DataModifyFuncs.lesson_typeIns("Какой-то");
                DataModifyFuncs.week_dayIns("Новый день");
                DataModifyFuncs.week_parityIns("Произведение");
            }
            );
        }
    }
}
