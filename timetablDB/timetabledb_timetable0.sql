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
  `id_schedule` int NOT NULL AUTO_INCREMENT,
  `id_lesson_time` int NOT NULL,
  `id_week_parity` int NOT NULL,
  `id_weekday` int NOT NULL,
  `id_classroom` int NOT NULL,
  `id_study_groups` int NOT NULL,
  `id_professors` int NOT NULL,
  `id_lesson` int NOT NULL,
  `id_lesson_type` int NOT NULL,
  PRIMARY KEY (`id_schedule`),
  UNIQUE KEY `idschedule_UNIQUE` (`id_schedule`),
  KEY `fk_schedule_time_lesson_idx` (`id_lesson_time`),
  KEY `fk_schedule_week_chet1_idx` (`id_week_parity`),
  KEY `fk_schedule_day_week1_idx` (`id_weekday`),
  KEY `fk_schedule_classroom1_idx` (`id_classroom`),
  KEY `fk_schedule_study_groups1_idx` (`id_study_groups`),
  KEY `fk_schedule_professors1_idx` (`id_professors`),
  KEY `fk_timetable_lesson1_idx` (`id_lesson`),
  KEY `fk_timetable_lesson_type1_idx` (`id_lesson_type`),
  CONSTRAINT `fk_schedule_classroom` FOREIGN KEY (`id_classroom`) REFERENCES `classroom` (`id_classroom`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_schedule_lesson_tme` FOREIGN KEY (`id_lesson_time`) REFERENCES `lesson_time` (`id_lesson_time`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_schedule_professors` FOREIGN KEY (`id_professors`) REFERENCES `professors` (`id_professors`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_schedule_study_groups` FOREIGN KEY (`id_study_groups`) REFERENCES `study_groups` (`id_study_groups`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_schedule_week_day` FOREIGN KEY (`id_weekday`) REFERENCES `week_day` (`id_dayweek`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_schedule_week_parity` FOREIGN KEY (`id_week_parity`) REFERENCES `week_parity` (`id_week_parity`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_timetable_lesson1` FOREIGN KEY (`id_lesson`) REFERENCES `discipline` (`id_discipline`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_timetable_lesson_type` FOREIGN KEY (`id_lesson_type`) REFERENCES `lesson_type` (`id_type_lesson`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=73 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `timetable`
--

LOCK TABLES `timetable` WRITE;
/*!40000 ALTER TABLE `timetable` DISABLE KEYS */;
INSERT INTO `timetable` VALUES (1,2,1,1,14,1,2,2,2),(2,3,1,1,10,1,1,1,2),(3,3,1,2,13,1,6,6,1),(4,4,1,2,13,1,2,2,1),(5,1,1,3,9,1,6,6,2),(6,2,1,3,10,1,1,1,2),(7,3,1,3,7,1,4,4,2),(8,3,1,4,12,1,4,4,1),(9,4,1,4,6,1,5,5,1),(10,1,1,5,12,1,1,1,1),(11,2,1,5,13,1,3,3,1),(12,4,1,6,2,1,7,5,2),(13,5,1,6,2,1,5,3,2),(14,2,2,1,6,1,1,1,1),(15,3,2,1,13,1,2,2,1),(16,2,2,2,5,1,3,3,1),(17,3,2,2,12,1,4,4,1),(18,5,2,3,2,1,4,4,2),(19,6,2,3,2,1,5,5,2),(20,4,2,4,4,1,6,6,2),(21,5,2,4,1,1,7,3,2),(22,4,2,5,11,1,1,1,2),(23,5,2,5,11,1,2,2,2),(24,3,1,1,19,2,15,13,2),(25,4,1,1,18,2,11,10,2),(26,5,1,1,16,2,10,9,2),(27,1,1,2,18,2,10,9,2),(28,2,1,2,18,2,11,10,2),(29,3,1,2,19,2,15,13,2),(30,1,1,3,15,2,16,14,3),(31,2,1,3,15,2,14,15,3),(32,3,1,3,15,2,15,13,3),(33,4,1,3,15,2,17,11,1),(34,2,1,4,15,2,15,13,1),(35,3,1,4,15,2,14,15,1),(36,2,1,5,15,2,11,10,3),(37,3,1,5,15,2,11,10,1),(38,4,1,5,15,2,16,14,1),(39,1,2,2,15,2,8,7,3),(40,2,2,2,15,2,9,8,3),(41,3,2,2,15,2,10,9,3),(42,1,2,3,15,2,11,10,1),(43,2,2,3,15,2,10,9,1),(44,3,2,3,15,2,8,7,1),(45,3,2,4,16,2,12,11,2),(46,4,2,4,17,2,9,8,2),(47,2,2,5,15,2,9,8,1),(48,3,2,5,15,2,13,12,1),(49,4,2,5,15,2,14,12,3),(50,2,1,2,25,3,18,16,2),(51,3,1,2,26,3,21,18,2),(52,2,1,3,15,3,25,22,1),(53,3,1,3,15,3,22,19,1),(54,1,1,4,24,3,20,17,1),(55,2,1,4,24,3,20,17,3),(56,3,1,4,21,3,22,19,3),(57,1,1,5,28,3,19,7,3),(58,2,1,5,20,3,23,20,3),(59,1,1,6,15,3,25,22,3),(60,2,1,6,15,3,24,21,1),(61,3,1,6,15,3,24,21,3),(62,2,2,1,15,3,18,16,1),(63,3,2,1,15,3,19,7,1),(64,1,2,2,20,3,20,17,1),(65,2,2,2,21,3,20,17,3),(66,2,2,3,22,3,21,18,1),(67,3,2,3,23,3,22,19,3),(68,1,2,5,24,3,23,20,1),(69,2,2,5,20,3,23,20,3),(70,3,2,5,20,3,18,16,3),(71,2,2,6,15,3,24,21,1),(72,3,2,6,15,3,25,22,3);
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

-- Dump completed on 2022-02-26  1:45:23
