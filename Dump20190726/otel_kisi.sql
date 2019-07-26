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
-- Table structure for table `kisi`
--

DROP TABLE IF EXISTS `kisi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `kisi` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tc_no` varchar(11) NOT NULL,
  `ad_soyad` varchar(50) NOT NULL,
  `kisi_durum_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `tc_no` (`tc_no`),
  KEY `kisi_durum_id` (`kisi_durum_id`),
  CONSTRAINT `kisi_ibfk_1` FOREIGN KEY (`kisi_durum_id`) REFERENCES `kisi_durum` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=57 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kisi`
--

LOCK TABLES `kisi` WRITE;
/*!40000 ALTER TABLE `kisi` DISABLE KEYS */;
INSERT INTO `kisi` VALUES (41,'35','taskin',2),(42,'45','taskin',1),(43,'4545','taskin kart2',2),(44,'454535','taskin kart2',2),(45,'3','taskin kart3',2),(46,'353535','taskin',1),(47,'454545','taskin',1),(48,'35353545','taskin',2),(49,'232523','taskin',2),(50,'234554','taskin',2),(51,'35353523','taskin',2),(52,'2324','taskin',2),(53,'242234','taskin',2),(54,'3434343434','taskin',3),(55,'9898','taskin',1),(56,'66567','taskin',2);
/*!40000 ALTER TABLE `kisi` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-07-26  2:59:51
