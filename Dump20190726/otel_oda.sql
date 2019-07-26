-- MySQL dump 10.13  Distrib 8.0.15, for Win64 (x86_64)
--
-- Host: localhost    Database: otel
-- ------------------------------------------------------
-- Server version	8.0.15

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `oda`
--

DROP TABLE IF EXISTS `oda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `oda` (
  `id` int(11) NOT NULL DEFAULT '0',
  `kisi_id` int(11) DEFAULT NULL,
  `giris_tarihi` datetime DEFAULT NULL,
  `cikis_tarihi` datetime DEFAULT NULL,
  `ucret` decimal(13,2) DEFAULT '0.00',
  PRIMARY KEY (`id`),
  UNIQUE KEY `kisi_id` (`kisi_id`),
  CONSTRAINT `oda_ibfk_1` FOREIGN KEY (`kisi_id`) REFERENCES `kisi` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `oda`
--

LOCK TABLES `oda` WRITE;
/*!40000 ALTER TABLE `oda` DISABLE KEYS */;
INSERT INTO `oda` VALUES (0,NULL,'2010-08-18 00:00:00',NULL,100.00),(1,55,'2019-05-06 17:44:54','2019-05-11 23:59:00',0.00),(100,NULL,NULL,NULL,100.00),(500,46,'2019-04-22 04:37:17','1997-04-04 23:59:00',185.00),(1000,NULL,'2019-04-23 18:21:18','2019-05-09 23:59:00',100.00),(1001,NULL,NULL,NULL,100.00),(1002,NULL,NULL,NULL,100.00),(1003,NULL,NULL,NULL,100.00);
/*!40000 ALTER TABLE `oda` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-07-26  2:59:54