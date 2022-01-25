using NUnit.Framework;
using Server;

namespace ServerUnitTests
{
    public class Tests
    {
        private SQLConnector Connector;

        /// <summary>
        /// Проверка создания подключения 
        /// </summary>
        [Test]
        public void Connection_Create_Does_Not_Throw()
        {
            Assert.DoesNotThrow(() => new SQLConnector());
        }
        /// <summary>
        /// Проверка исполнения запросов к табоице 
        /// </summary>
        [Test]
        public void Requests_Does_Not_Throw()
        {
            var Connector = new SQLConnector();
            Assert.DoesNotThrow(() => Connector.SelectTimeTable());
        }
    }
}
