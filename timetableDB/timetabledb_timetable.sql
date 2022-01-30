-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: localhost    Database: timetabledb
-- ------------------------------------------------------
-- Server version	8.0.28

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `timetable`
--

DROP TABLE IF EXISTS `timetable`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `timetable` (
  `idschedule` int NOT NULL AUTO_INCREMENT,
  `idlesson_time` int NOT NULL,
  `idweek_parity` int NOT NULL,
  `idweekday` int NOT NULL,
  `idclassroom` int NOT NULL,
  `idstudy_groups` int NOT NULL,
  `idprofessors` int NOT NULL,
  `idlesson` int NOT NULL,
  `idlesson_type` int NOT NULL,
  PRIMARY KEY (`idschedule`),
  UNIQUE KEY `idschedule_UNIQUE` (`idschedule`),
  KEY `fk_schedule_time_lesson_idx` (`idlesson_time`),
  KEY `fk_schedule_week_chet1_idx` (`idweek_parity`),
  KEY `fk_schedule_day_week1_idx` (`idweekday`),
  KEY `fk_schedule_classroom1_idx` (`idclassroom`),
  KEY `fk_schedule_study_groups1_idx` (`idstudy_groups`),
  KEY `fk_schedule_professors1_idx` (`idprofessors`),
  KEY `fk_timetable_lesson1_idx` (`idlesson`),
  KEY `fk_timetable_lesson_type1_idx` (`idlesson_type`),
  CONSTRAINT `fk_schedule_classroom` FOREIGN KEY (`idclassroom`) REFERENCES `classroom` (`idclassroom`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_schedule_lesson_tme` FOREIGN KEY (`idlesson_time`) REFERENCES `lesson_time` (`idlesson_time`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_schedule_professors` FOREIGN KEY (`idprofessors`) REFERENCES `professors` (`idprofessors`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_schedule_study_groups` FOREIGN KEY (`idstudy_groups`) REFERENCES `study_groups` (`idstudy_groups`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_schedule_week_day` FOREIGN KEY (`idweekday`) REFERENCES `week_day` (`iddayweek`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_schedule_week_parity` FOREIGN KEY (`idweek_parity`) REFERENCES `week_parity` (`idweek_parity`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_timetable_lesson1` FOREIGN KEY (`idlesson`) REFERENCES `discipline` (`iddiscipline`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_timetable_lesson_type` FOREIGN KEY (`idlesson_type`) REFERENCES `lesson_type` (`idtype_lesson`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `timetable`
--

LOCK TABLES `timetable` WRITE;
/*!40000 ALTER TABLE `timetable` DISABLE KEYS */;
INSERT INTO `timetable` VALUES (1,2,2,1,1,1,1,1,1),(2,3,2,1,2,1,2,2,1),(3,2,2,2,3,1,3,3,1),(4,3,2,2,4,1,4,4,1),(5,5,2,3,7,1,4,4,2),(6,6,2,3,7,1,5,5,2);
/*!40000 ALTER TABLE `timetable` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-01-30 17:19:32
