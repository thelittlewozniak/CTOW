-- MySQL Script generated by MySQL Workbench
-- Sat Mar 10 02:12:52 2018
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `mydb` ;

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `adress`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `address` ;

CREATE TABLE IF NOT EXISTS `address` (
  `idaddress` INT NOT NULL,
  `address_street` VARCHAR(45) NULL,
  `address_number` VARCHAR(45) NULL,
  `address_cp` VARCHAR(45) NULL,
  `address_city` VARCHAR(45) NULL,
  `address_country` VARCHAR(45) NULL,
  PRIMARY KEY (`idaddress`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `device`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `device` ;

CREATE TABLE IF NOT EXISTS `device` (
  `guid` INT NOT NULL,
  `device_description` VARCHAR(45) NULL,
  `address_idadress` INT NOT NULL,
  PRIMARY KEY (`guid`),
  INDEX `fk_device_address_idx` (`address_idadress` ASC),
  CONSTRAINT `fk_device_address`
    FOREIGN KEY (`adress_idaddress`)
    REFERENCES `adress` (`idaddress`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `type_data`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `type_data` ;

CREATE TABLE IF NOT EXISTS `type_data` (
  `idtype_data` INT NOT NULL,
  `type_data_description` VARCHAR(45) NULL,
  PRIMARY KEY (`idtype_data`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `data`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `data` ;

CREATE TABLE IF NOT EXISTS `data` (
  `iddata` INT NOT NULL,
  `value_data` VARCHAR(45) NULL,
  `type_idtype` INT NOT NULL,
  `device_guid` INT NOT NULL,
  PRIMARY KEY (`iddata`),
  INDEX `fk_data_type1_idx` (`type_idtype` ASC),
  INDEX `fk_data_device1_idx` (`device_guid` ASC),
  CONSTRAINT `fk_data_type1`
    FOREIGN KEY (`type_idtype`)
    REFERENCES `type_data` (`idtype_data`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_data_device1`
    FOREIGN KEY (`device_guid`)
    REFERENCES `device` (`guid`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `type_user`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `type_user` ;

CREATE TABLE IF NOT EXISTS `type_user` (
  `idtype_user` INT NOT NULL,
  `type_user_description` VARCHAR(45) NULL,
  PRIMARY KEY (`idtype_user`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `user`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `user` ;

CREATE TABLE IF NOT EXISTS `user` (
  `iduser` INT NOT NULL,
  `user_email` VARCHAR(45) NULL,
  `user_password` VARCHAR(45) NULL,
  `type_user_idtype_user` INT NOT NULL,
  PRIMARY KEY (`iduser`),
  INDEX `fk_user_type_user1_idx` (`type_user_idtype_user` ASC),
  CONSTRAINT `fk_user_type_user1`
    FOREIGN KEY (`type_user_idtype_user`)
    REFERENCES `type_user` (`idtype_user`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `user_has_device`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `user_has_device` ;

CREATE TABLE IF NOT EXISTS `user_has_device` (
  `user_iduser` INT NOT NULL,
  `device_guid` INT NOT NULL,
  PRIMARY KEY (`user_iduser`, `device_guid`),
  INDEX `fk_user_has_device_device1_idx` (`device_guid` ASC),
  INDEX `fk_user_has_device_user1_idx` (`user_iduser` ASC),
  CONSTRAINT `fk_user_has_device_user1`
    FOREIGN KEY (`user_iduser`)
    REFERENCES `user` (`iduser`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_user_has_device_device1`
    FOREIGN KEY (`device_guid`)
    REFERENCES `device` (`guid`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
