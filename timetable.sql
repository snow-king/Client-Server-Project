-- MySQL Script generated by MySQL Workbench
-- Sun Feb  6 22:16:40 2022
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema timetabledb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema timetabledb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `timetabledb` DEFAULT CHARACTER SET utf8 ;
USE `timetabledb` ;

-- -----------------------------------------------------
-- Table `timetabledb`.`classroom`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `timetabledb`.`classroom` (
  `id_classroom` INT NOT NULL AUTO_INCREMENT,
  `frame` VARCHAR(100) NOT NULL,
  `classroom_number` INT NULL,
  PRIMARY KEY (`id_classroom`),
  UNIQUE INDEX `idclassroom_UNIQUE` (`id_classroom` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 13
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `timetabledb`.`discipline`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `timetabledb`.`discipline` (
  `id_discipline` INT NOT NULL AUTO_INCREMENT,
  `discipline_name` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`id_discipline`),
  UNIQUE INDEX `idlesson_UNIQUE` (`id_discipline` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `timetabledb`.`lesson_time`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `timetabledb`.`lesson_time` (
  `id_lesson_time` INT NOT NULL AUTO_INCREMENT,
  `lesson_number` INT NOT NULL,
  `lesson_start` VARCHAR(45) NULL,
  `lesson_finish` VARCHAR(45) NULL,
  PRIMARY KEY (`id_lesson_time`),
  UNIQUE INDEX `idlesson_time_UNIQUE` (`id_lesson_time` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 10
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `timetabledb`.`lesson_type`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `timetabledb`.`lesson_type` (
  `id_lesson_type` INT NOT NULL AUTO_INCREMENT,
  `lesson_type` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_lesson_type`),
  UNIQUE INDEX `idtype_lesson_UNIQUE` (`id_lesson_type` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `timetabledb`.`professors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `timetabledb`.`professors` (
  `id_professors` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(100) NOT NULL,
  `surname` VARCHAR(45) NULL,
  `patronymic` VARCHAR(45) NULL,
  PRIMARY KEY (`id_professors`),
  UNIQUE INDEX `idprofessors_UNIQUE` (`id_professors` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 8
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `timetabledb`.`faculty`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `timetabledb`.`faculty` (
  `id_faculty` INT NOT NULL,
  `faculty_name` VARCHAR(45) NULL,
  PRIMARY KEY (`id_faculty`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `timetabledb`.`speciality`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `timetabledb`.`speciality` (
  `id_speciality` INT NOT NULL,
  `speciality_name` VARCHAR(45) NULL,
  `abbreviated_speciality` VARCHAR(45) NULL,
  PRIMARY KEY (`id_speciality`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `timetabledb`.`study_groups`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `timetabledb`.`study_groups` (
  `id_study_groups` INT NOT NULL AUTO_INCREMENT,
  `group_name` VARCHAR(10) NOT NULL,
  `id_faculty` INT NULL,
  `id_speciality` INT NULL,
  `course` INT NULL,
  `education_form` VARCHAR(45) NULL,
  PRIMARY KEY (`id_study_groups`),
  UNIQUE INDEX `idstudy_groups_UNIQUE` (`id_study_groups` ASC) VISIBLE,
  INDEX `faculty_idx` (`id_faculty` ASC) VISIBLE,
  INDEX `speciality_idx` (`id_speciality` ASC) VISIBLE,
  CONSTRAINT `faculty`
    FOREIGN KEY (`id_faculty`)
    REFERENCES `timetabledb`.`faculty` (`id_faculty`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `speciality`
    FOREIGN KEY (`id_speciality`)
    REFERENCES `timetabledb`.`speciality` (`id_speciality`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `timetabledb`.`week_day`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `timetabledb`.`week_day` (
  `id_week_day` INT NOT NULL AUTO_INCREMENT,
  `weekday` VARCHAR(15) NOT NULL,
  PRIMARY KEY (`id_week_day`),
  UNIQUE INDEX `iddayweek_UNIQUE` (`id_week_day` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `timetabledb`.`week_parity`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `timetabledb`.`week_parity` (
  `id_week_parity` INT NOT NULL AUTO_INCREMENT,
  `week_parity` VARCHAR(15) NOT NULL,
  PRIMARY KEY (`id_week_parity`),
  UNIQUE INDEX `idweek_chet_UNIQUE` (`id_week_parity` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `timetabledb`.`timetable`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `timetabledb`.`timetable` (
  `id_schedule` INT NOT NULL AUTO_INCREMENT,
  `id_lesson_time` INT NOT NULL,
  `id_week_parity` INT NOT NULL,
  `id_week_day` INT NOT NULL,
  `id_classroom` INT NOT NULL,
  `id_study_groups` INT NOT NULL,
  `id_professors` INT NOT NULL,
  `id_discipline` INT NOT NULL,
  `id_lesson_type` INT NOT NULL,
  PRIMARY KEY (`id_schedule`),
  UNIQUE INDEX `idschedule_UNIQUE` (`id_schedule` ASC) VISIBLE,
  INDEX `fk_schedule_time_lesson_idx` (`id_lesson_time` ASC) VISIBLE,
  INDEX `fk_schedule_week_chet1_idx` (`id_week_parity` ASC) VISIBLE,
  INDEX `fk_schedule_day_week1_idx` (`id_week_day` ASC) VISIBLE,
  INDEX `fk_schedule_classroom1_idx` (`id_classroom` ASC) VISIBLE,
  INDEX `fk_schedule_study_groups1_idx` (`id_study_groups` ASC) VISIBLE,
  INDEX `fk_schedule_professors1_idx` (`id_professors` ASC) VISIBLE,
  INDEX `fk_timetable_lesson1_idx` (`id_discipline` ASC) VISIBLE,
  INDEX `fk_timetable_lesson_type1_idx` (`id_lesson_type` ASC) VISIBLE,
  CONSTRAINT `fk_schedule_classroom`
    FOREIGN KEY (`id_classroom`)
    REFERENCES `timetabledb`.`classroom` (`id_classroom`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_schedule_lesson_tme`
    FOREIGN KEY (`id_lesson_time`)
    REFERENCES `timetabledb`.`lesson_time` (`id_lesson_time`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_schedule_professors`
    FOREIGN KEY (`id_professors`)
    REFERENCES `timetabledb`.`professors` (`id_professors`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_schedule_study_groups`
    FOREIGN KEY (`id_study_groups`)
    REFERENCES `timetabledb`.`study_groups` (`id_study_groups`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_schedule_week_day`
    FOREIGN KEY (`id_week_day`)
    REFERENCES `timetabledb`.`week_day` (`id_week_day`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_schedule_week_parity`
    FOREIGN KEY (`id_week_parity`)
    REFERENCES `timetabledb`.`week_parity` (`id_week_parity`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_timetable_lesson1`
    FOREIGN KEY (`id_discipline`)
    REFERENCES `timetabledb`.`discipline` (`id_discipline`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_timetable_lesson_type`
    FOREIGN KEY (`id_lesson_type`)
    REFERENCES `timetabledb`.`lesson_type` (`id_lesson_type`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8mb3;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;