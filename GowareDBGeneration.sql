-- MySQL Script generated by MySQL Workbench
-- 12/18/16 18:24:30
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema gowaredb
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `gowaredb` ;

-- -----------------------------------------------------
-- Schema gowaredb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `gowaredb` DEFAULT CHARACTER SET utf8mb4 ;
USE `gowaredb` ;

-- -----------------------------------------------------
-- Table `gowaredb`.`category`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gowaredb`.`category` ;

CREATE TABLE IF NOT EXISTS `gowaredb`.`category` (
  `id_category` INT(11) NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `fee` DECIMAL(10,0) NOT NULL,
  PRIMARY KEY (`id_category`))
ENGINE = InnoDB
AUTO_INCREMENT = 17
DEFAULT CHARACTER SET = utf8mb4;

CREATE UNIQUE INDEX `name_UNIQUE` ON `gowaredb`.`category` (`name` ASC);


-- -----------------------------------------------------
-- Table `gowaredb`.`client`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gowaredb`.`client` ;

CREATE TABLE IF NOT EXISTS `gowaredb`.`client` (
  `id_client` INT(11) NOT NULL AUTO_INCREMENT,
  `usertype` ENUM('personal', 'corporate') NOT NULL,
  `username` VARCHAR(20) NOT NULL,
  `password` VARCHAR(20) NOT NULL,
  `email` VARCHAR(45) NOT NULL,
  `firstname` VARCHAR(45) NULL DEFAULT NULL,
  `middlename` VARCHAR(45) NULL DEFAULT NULL,
  `lastname` VARCHAR(45) NULL DEFAULT NULL,
  `sex` ENUM('M', 'F') NULL DEFAULT NULL,
  `companyname` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`id_client`))
ENGINE = InnoDB
AUTO_INCREMENT = 8
DEFAULT CHARACTER SET = utf8mb4;

CREATE UNIQUE INDEX `username_UNIQUE` ON `gowaredb`.`client` (`username` ASC);


-- -----------------------------------------------------
-- Table `gowaredb`.`history_info`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gowaredb`.`history_info` ;

CREATE TABLE IF NOT EXISTS `gowaredb`.`history_info` (
  `id_inventory` INT(11) NOT NULL AUTO_INCREMENT,
  `id_client` INT(11) NOT NULL,
  `id_warehouse` INT(11) NOT NULL,
  `id_category` INT(11) NOT NULL,
  `id_repository` INT(11) NOT NULL,
  `description` VARCHAR(200) NULL DEFAULT NULL,
  `payment` DECIMAL(10,0) NOT NULL,
  PRIMARY KEY (`id_inventory`))
ENGINE = InnoDB
AUTO_INCREMENT = 24
DEFAULT CHARACTER SET = utf8mb4;

CREATE INDEX `history_idk` ON `gowaredb`.`history_info` (`id_inventory` ASC, `id_client` ASC, `id_warehouse` ASC, `id_category` ASC, `id_repository` ASC);


-- -----------------------------------------------------
-- Table `gowaredb`.`history_status`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gowaredb`.`history_status` ;

CREATE TABLE IF NOT EXISTS `gowaredb`.`history_status` (
  `id_inventory` INT(11) NOT NULL,
  `status` ENUM('in', 'out', 'disposal') NOT NULL,
  `date` DATETIME NOT NULL,
  PRIMARY KEY (`id_inventory`, `status`),
  CONSTRAINT `history_status_fk_1`
    FOREIGN KEY (`id_inventory`)
    REFERENCES `gowaredb`.`history_info` (`id_inventory`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;


-- -----------------------------------------------------
-- Table `gowaredb`.`warehouse`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gowaredb`.`warehouse` ;

CREATE TABLE IF NOT EXISTS `gowaredb`.`warehouse` (
  `id_warehouse` INT(11) NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `fee` DECIMAL(10,0) NOT NULL,
  `street` VARCHAR(45) NOT NULL,
  `city` VARCHAR(45) NOT NULL,
  `country` VARCHAR(45) NOT NULL,
  `tel` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_warehouse`))
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = utf8mb4;

CREATE UNIQUE INDEX `name_UNIQUE` ON `gowaredb`.`warehouse` (`name` ASC);


-- -----------------------------------------------------
-- Table `gowaredb`.`repository`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gowaredb`.`repository` ;

CREATE TABLE IF NOT EXISTS `gowaredb`.`repository` (
  `id_warehouse` INT(11) NOT NULL,
  `id_category` INT(11) NOT NULL,
  `id_repository` INT(11) NOT NULL,
  PRIMARY KEY (`id_warehouse`, `id_category`, `id_repository`),
  CONSTRAINT `repository_fk_1`
    FOREIGN KEY (`id_category`)
    REFERENCES `gowaredb`.`category` (`id_category`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `repository_fk_2`
    FOREIGN KEY (`id_warehouse`)
    REFERENCES `gowaredb`.`warehouse` (`id_warehouse`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;

CREATE INDEX `repository_fk_1_idx` ON `gowaredb`.`repository` (`id_category` ASC);


-- -----------------------------------------------------
-- Table `gowaredb`.`inventory`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gowaredb`.`inventory` ;

CREATE TABLE IF NOT EXISTS `gowaredb`.`inventory` (
  `id_inventory` INT(11) NOT NULL,
  `id_client` INT(11) NOT NULL,
  `id_warehouse` INT(11) NOT NULL,
  `id_category` INT(11) NOT NULL,
  `id_repository` INT(11) NOT NULL,
  `description` VARCHAR(200) NULL DEFAULT NULL,
  `date_in` DATETIME NOT NULL,
  PRIMARY KEY (`id_inventory`),
  CONSTRAINT `inventory_fk_111`
    FOREIGN KEY (`id_inventory` , `id_client`)
    REFERENCES `gowaredb`.`history_info` (`id_inventory` , `id_client`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `inventory_fk_222`
    FOREIGN KEY (`id_warehouse` , `id_category` , `id_repository`)
    REFERENCES `gowaredb`.`repository` (`id_warehouse` , `id_category` , `id_repository`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `inventory_fk_333`
    FOREIGN KEY (`id_client`)
    REFERENCES `gowaredb`.`client` (`id_client`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;

CREATE INDEX `inventory_fk_111_idx` ON `gowaredb`.`inventory` (`id_inventory` ASC, `id_client` ASC);

CREATE INDEX `inventory_fk_222_idx` ON `gowaredb`.`inventory` (`id_warehouse` ASC, `id_category` ASC, `id_repository` ASC);

CREATE INDEX `inventory_fk_333_idx` ON `gowaredb`.`inventory` (`id_client` ASC);


-- -----------------------------------------------------
-- Table `gowaredb`.`manage_key`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gowaredb`.`manage_key` ;

CREATE TABLE IF NOT EXISTS `gowaredb`.`manage_key` (
  `id_key` INT(11) NOT NULL,
  `key` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_key`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;

CREATE UNIQUE INDEX `key_UNIQUE` ON `gowaredb`.`manage_key` (`key` ASC);


-- -----------------------------------------------------
-- Table `gowaredb`.`manager`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `gowaredb`.`manager` ;

CREATE TABLE IF NOT EXISTS `gowaredb`.`manager` (
  `id_manager` INT(11) NOT NULL AUTO_INCREMENT,
  `id_key` INT(11) NOT NULL,
  `username` VARCHAR(45) NOT NULL,
  `password` VARCHAR(45) NOT NULL,
  `email` VARCHAR(45) NOT NULL,
  `firstname` VARCHAR(45) NOT NULL,
  `middlename` VARCHAR(45) NULL DEFAULT NULL,
  `lastname` VARCHAR(45) NOT NULL,
  `sex` ENUM('M', 'F') NOT NULL,
  PRIMARY KEY (`id_manager`),
  CONSTRAINT `manager_fk_1`
    FOREIGN KEY (`id_key`)
    REFERENCES `gowaredb`.`manage_key` (`id_key`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8mb4;

CREATE UNIQUE INDEX `username_UNIQUE` ON `gowaredb`.`manager` (`username` ASC);

CREATE INDEX `manager_fk_1_idx` ON `gowaredb`.`manager` (`id_key` ASC);

USE `gowaredb`;

DELIMITER $$

USE `gowaredb`$$
DROP TRIGGER IF EXISTS `gowaredb`.`history_info_AFTER_DELETE` $$
USE `gowaredb`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `gowaredb`.`history_info_AFTER_DELETE`
AFTER DELETE ON `gowaredb`.`history_info`
FOR EACH ROW
BEGIN
 DELETE FROM `gowaredb`.`history_status` WHERE `id_inventory` = old.id_inventory;
 DELETE FROM `gowaredb`.`inventory` WHERE `id_inventory` = old.id_inventory;

END$$


USE `gowaredb`$$
DROP TRIGGER IF EXISTS `gowaredb`.`history_info_AFTER_INSERT` $$
USE `gowaredb`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `gowaredb`.`history_info_AFTER_INSERT`
AFTER INSERT ON `gowaredb`.`history_info`
FOR EACH ROW
BEGIN
  
  SET @tmp = (SELECT now());
  INSERT INTO `history_status`
  (`id_inventory`, `status`, `date`)
  VALUES (new.id_inventory, 'in', @tmp); 

  INSERT INTO `inventory` 
  (`id_inventory`, `id_client`, `id_warehouse`, `id_repository`, `id_category`, `description`, `date_in`) 
  VALUES (new.id_inventory, new.id_client, new.id_warehouse, new.id_repository, new.id_category, new.description, @tmp);

END$$


USE `gowaredb`$$
DROP TRIGGER IF EXISTS `gowaredb`.`history_info_AFTER_UPDATE` $$
USE `gowaredb`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `gowaredb`.`history_info_AFTER_UPDATE`
AFTER UPDATE ON `gowaredb`.`history_info`
FOR EACH ROW
BEGIN

  SET @tmp = (SELECT now());
  
  INSERT INTO `history_status`
  (`id_inventory`, `status`, `date`)
  VALUES (new.id_inventory, 'out', @tmp); 
  
  DELETE FROM `gowaredb`.`inventory`
  WHERE `id_inventory`= new.id_inventory;
  
END$$


DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;