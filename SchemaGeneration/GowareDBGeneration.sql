CREATE DATABASE  IF NOT EXISTS `hello` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;
USE `hello`;
-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: localhost    Database: hello
-- ------------------------------------------------------
-- Server version	5.6.33

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `category` (
  `id_category` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `fee` decimal(10,0) NOT NULL,
  PRIMARY KEY (`id_category`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (2,'Tool',5),(3,'Food',10),(4,'Electric',5),(5,'Luxury',80),(6,'Mechanism',30),(7,'Animal',50),(9,'Fluid',20),(10,'Paper',4),(16,'Office',10),(17,'Other',30);
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `client` (
  `id_client` int(11) NOT NULL AUTO_INCREMENT,
  `usertype` enum('personal','corporate') NOT NULL,
  `username` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL,
  `email` varchar(45) NOT NULL,
  `firstname` varchar(45) DEFAULT NULL,
  `middlename` varchar(45) DEFAULT NULL,
  `lastname` varchar(45) DEFAULT NULL,
  `sex` enum('M','F') DEFAULT NULL,
  `companyname` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_client`),
  UNIQUE KEY `username_UNIQUE` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `client`
--

LOCK TABLES `client` WRITE;
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
INSERT INTO `client` VALUES (1,'personal','orsonxu','xuxuhai','orson.xu@foxmail.com','Xuhai',NULL,'Xu','M',NULL),(2,'corporate','tsinghua','tsinghua','tsinghua@tsinghua.com',NULL,NULL,NULL,NULL,'Tsinghua University'),(4,'corporate','peking','peking','Peking',NULL,NULL,NULL,NULL,'Peking University'),(5,'personal','jackma','jackma','jackma@qq.com','Jack','','Ma','M',NULL),(6,'personal','lx14','luxiang','lx14@mails.tsinghua.edu.cn','Xiang','','Lu','M',NULL),(7,'corporate','huawei123','xuhai','hwhw@huawei.com',NULL,NULL,NULL,NULL,'HuaweiMobile');
/*!40000 ALTER TABLE `client` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `history_info`
--

DROP TABLE IF EXISTS `history_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `history_info` (
  `id_inventory` int(11) NOT NULL AUTO_INCREMENT,
  `id_client` int(11) NOT NULL,
  `id_warehouse` int(11) NOT NULL,
  `id_category` int(11) NOT NULL,
  `id_repository` int(11) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  `payment` decimal(10,0) NOT NULL,
  PRIMARY KEY (`id_inventory`),
  KEY `history_idk` (`id_inventory`,`id_client`,`id_warehouse`,`id_category`,`id_repository`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `history_info`
--

LOCK TABLES `history_info` WRITE;
/*!40000 ALTER TABLE `history_info` DISABLE KEYS */;
INSERT INTO `history_info` VALUES (1,1,1,1,1,'1 KG of gold',1),(2,1,1,1,1,'2 KG of silver',11),(3,1,1,1,1,'3 KG of gold',11),(4,1,1,9,1,'1 ton pure water',130),(5,1,2,7,1,'A tiger',50),(6,1,2,7,1,'A dozen of dogs',0),(7,1,2,7,1,'A dozen of little chicken',425),(8,1,2,7,1,'Two cats',0),(9,1,2,7,1,'A lion',0),(10,1,2,7,2,'A goose',0),(11,1,1,7,1,'A new tiger',120),(12,1,2,7,1,'A baby bear',0),(13,1,2,7,2,'A baby tiger',0),(14,2,1,2,1,'100 Computers',0),(15,2,1,9,1,'10 ton of water',0),(16,2,1,10,1,'4000 final exam papers',0),(17,2,1,6,1,'30 ton of high quality steel',0),(18,2,2,4,1,'5km POF',0),(19,6,2,5,1,'A OMEGA watch',0),(20,6,1,9,1,'Some high-end sport beverage',0),(21,1,1,4,1,'A iPhone 7 with grey sliver',0),(22,1,3,5,1,'123',80),(23,1,4,1,1,'123',10),(24,1,1,3,1,'A ton of Bread',0),(25,1,1,2,1,'good',5);
/*!40000 ALTER TABLE `history_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `history_status`
--

DROP TABLE IF EXISTS `history_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `history_status` (
  `id_inventory` int(11) NOT NULL,
  `status` enum('in','out','disposal') NOT NULL,
  `date` datetime NOT NULL,
  PRIMARY KEY (`id_inventory`,`status`),
  CONSTRAINT `historyStatus_historyInfo` FOREIGN KEY (`id_inventory`) REFERENCES `history_info` (`id_inventory`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `history_status`
--

LOCK TABLES `history_status` WRITE;
/*!40000 ALTER TABLE `history_status` DISABLE KEYS */;
INSERT INTO `history_status` VALUES (1,'in','2016-12-01 18:25:59'),(1,'out','2016-12-01 18:26:22'),(2,'in','2016-11-30 18:26:14'),(2,'out','2016-12-01 18:28:39'),(3,'in','2016-11-30 20:29:33'),(3,'out','2016-12-01 18:30:45'),(4,'in','2016-12-04 20:59:21'),(4,'out','2016-12-15 13:48:50'),(5,'in','2016-12-04 21:02:39'),(5,'out','2016-12-04 21:06:13'),(6,'in','2016-12-04 21:03:42'),(7,'in','2016-12-04 21:03:58'),(7,'out','2016-12-29 11:50:01'),(8,'in','2016-12-04 21:04:10'),(9,'in','2016-12-04 21:04:37'),(10,'in','2016-12-04 21:04:57'),(11,'in','2016-12-04 21:06:34'),(11,'out','2016-12-11 23:05:58'),(12,'in','2016-12-04 21:06:58'),(13,'in','2016-12-04 21:07:16'),(14,'in','2016-12-14 00:23:36'),(15,'in','2016-12-14 00:23:50'),(16,'in','2016-12-14 00:24:12'),(17,'in','2016-12-14 00:24:33'),(18,'in','2016-12-14 00:25:08'),(19,'in','2016-12-14 00:27:44'),(20,'in','2016-12-14 00:28:07'),(21,'in','2016-12-15 11:38:03'),(22,'in','2016-12-18 17:19:21'),(22,'out','2016-12-18 17:19:58'),(23,'in','2016-12-18 17:45:35'),(23,'out','2016-12-18 17:46:14'),(24,'in','2016-12-26 00:51:30'),(25,'in','2016-12-31 09:59:06'),(25,'out','2016-12-31 09:59:13');
/*!40000 ALTER TABLE `history_status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inventory`
--

DROP TABLE IF EXISTS `inventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `inventory` (
  `id_inventory` int(11) NOT NULL,
  `id_client` int(11) NOT NULL,
  `id_warehouse` int(11) NOT NULL,
  `id_category` int(11) NOT NULL,
  `id_repository` int(11) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  `date_in` datetime NOT NULL,
  PRIMARY KEY (`id_inventory`),
  KEY `inventory_fk_222_idx` (`id_warehouse`,`id_category`,`id_repository`),
  KEY `inventory_fk_333_idx` (`id_client`),
  CONSTRAINT `inventory_client` FOREIGN KEY (`id_client`) REFERENCES `client` (`id_client`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `inventory_historyInfo` FOREIGN KEY (`id_inventory`) REFERENCES `history_info` (`id_inventory`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `inventory_repository` FOREIGN KEY (`id_warehouse`, `id_category`, `id_repository`) REFERENCES `repository` (`id_warehouse`, `id_category`, `id_repository`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory`
--

LOCK TABLES `inventory` WRITE;
/*!40000 ALTER TABLE `inventory` DISABLE KEYS */;
INSERT INTO `inventory` VALUES (6,1,2,7,1,'A dozen of dogs','2016-12-04 21:03:42'),(8,1,2,7,1,'Two cats','2016-12-04 21:04:10'),(9,1,2,7,1,'A lion','2016-12-04 21:04:37'),(10,1,2,7,2,'A goose','2016-12-04 21:04:57'),(12,1,2,7,1,'A baby bear','2016-12-04 21:06:58'),(13,1,2,7,2,'A baby tiger','2016-12-04 21:07:16'),(14,2,1,2,1,'100 Computers','2016-12-14 00:23:36'),(15,2,1,9,1,'10 ton of water','2016-12-14 00:23:50'),(16,2,1,10,1,'4000 final exam papers','2016-12-14 00:24:12'),(17,2,1,6,1,'30 ton of high quality steel','2016-12-14 00:24:33'),(18,2,2,4,1,'5km POF','2016-12-14 00:25:08'),(19,6,2,5,1,'A OMEGA watch','2016-12-14 00:27:44'),(20,6,1,9,1,'Some high-end sport beverage','2016-12-14 00:28:07'),(21,1,1,4,1,'A iPhone 7 with grey sliver','2016-12-15 11:38:03'),(24,1,1,3,1,'A ton of Bread','2016-12-26 00:51:30');
/*!40000 ALTER TABLE `inventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `manage_key`
--

DROP TABLE IF EXISTS `manage_key`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `manage_key` (
  `id_key` int(11) NOT NULL,
  `key` varchar(45) NOT NULL,
  PRIMARY KEY (`id_key`),
  UNIQUE KEY `key_UNIQUE` (`key`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `manage_key`
--

LOCK TABLES `manage_key` WRITE;
/*!40000 ALTER TABLE `manage_key` DISABLE KEYS */;
INSERT INTO `manage_key` VALUES (1,'ABCDEFG'),(2,'QWERTY');
/*!40000 ALTER TABLE `manage_key` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `manager`
--

DROP TABLE IF EXISTS `manager`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `manager` (
  `id_manager` int(11) NOT NULL AUTO_INCREMENT,
  `id_key` int(11) NOT NULL,
  `username` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  `firstname` varchar(45) NOT NULL,
  `middlename` varchar(45) DEFAULT NULL,
  `lastname` varchar(45) NOT NULL,
  `sex` enum('M','F') NOT NULL,
  PRIMARY KEY (`id_manager`),
  UNIQUE KEY `username_UNIQUE` (`username`),
  KEY `manager_fk_1_idx` (`id_key`),
  CONSTRAINT `manager_managerKey` FOREIGN KEY (`id_key`) REFERENCES `manage_key` (`id_key`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `manager`
--

LOCK TABLES `manager` WRITE;
/*!40000 ALTER TABLE `manager` DISABLE KEYS */;
INSERT INTO `manager` VALUES (1,1,'admin','admin','admin@admin.com','Hui',NULL,'Cao','M'),(2,2,'admin2','admin2','admin2@admin.com','Xuhai','','Xu','M'),(3,2,'admin003','admin','admin003@go.com','Michael','','Smith','M');
/*!40000 ALTER TABLE `manager` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `repository`
--

DROP TABLE IF EXISTS `repository`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `repository` (
  `id_warehouse` int(11) NOT NULL,
  `id_category` int(11) NOT NULL,
  `id_repository` int(11) NOT NULL,
  PRIMARY KEY (`id_warehouse`,`id_category`,`id_repository`),
  KEY `repository_fk_1_idx` (`id_category`),
  CONSTRAINT `repository_category` FOREIGN KEY (`id_category`) REFERENCES `category` (`id_category`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `repository_warehouse` FOREIGN KEY (`id_warehouse`) REFERENCES `warehouse` (`id_warehouse`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `repository`
--

LOCK TABLES `repository` WRITE;
/*!40000 ALTER TABLE `repository` DISABLE KEYS */;
INSERT INTO `repository` VALUES (1,2,1),(2,2,1),(1,3,1),(2,3,1),(1,4,1),(2,4,1),(1,5,1),(2,5,1),(1,6,1),(1,7,1),(2,7,1),(2,7,2),(1,9,1),(1,10,1);
/*!40000 ALTER TABLE `repository` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `warehouse`
--

DROP TABLE IF EXISTS `warehouse`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `warehouse` (
  `id_warehouse` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `fee` decimal(10,0) NOT NULL,
  `street` varchar(45) NOT NULL,
  `city` varchar(45) NOT NULL,
  `country` varchar(45) NOT NULL,
  `tel` varchar(45) NOT NULL,
  PRIMARY KEY (`id_warehouse`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `warehouse`
--

LOCK TABLES `warehouse` WRITE;
/*!40000 ALTER TABLE `warehouse` DISABLE KEYS */;
INSERT INTO `warehouse` VALUES (1,'TsinghuaWH',12,'Zhongguancun NO1','Beijing','China','010-88888888'),(2,'PekingWH',15,'Yiheyuan NO5','Beijing','China','010-66666666'),(3,'RenmingWH',20,'RenmingRoad','Beijing','China','010-12312312');
/*!40000 ALTER TABLE `warehouse` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-12-31 11:57:36
