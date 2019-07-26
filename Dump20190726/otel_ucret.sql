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
-- Table structure for table `ucret`
--

DROP TABLE IF EXISTS `ucret`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `ucret` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `kisi_id` int(11) NOT NULL,
  `mekan_id` int(11) NOT NULL,
  `masa` int(11) NOT NULL,
  `urunler` varchar(256) NOT NULL,
  `ucret` decimal(13,2) DEFAULT NULL,
  `tarih` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `kisi_id` (`kisi_id`),
  KEY `mekan_id` (`mekan_id`),
  CONSTRAINT `ucret_ibfk_1` FOREIGN KEY (`kisi_id`) REFERENCES `kisi` (`id`),
  CONSTRAINT `ucret_ibfk_2` FOREIGN KEY (`mekan_id`) REFERENCES `mekan` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ucret`
--

LOCK TABLES `ucret` WRITE;
/*!40000 ALTER TABLE `ucret` DISABLE KEYS */;
INSERT INTO `ucret` VALUES (1,42,2,1,'ahududu, tost',10.00,'2019-04-13 20:04:03'),(2,42,2,5,'tost, cola',4090.00,'2019-04-13 20:12:03'),(3,45,2,1,'asf, afsd',90.00,'2019-04-14 22:47:45'),(4,49,2,10,'',0.00,'2019-04-26 19:00:46'),(5,48,2,100,'  ',0.00,'2019-04-26 19:18:41'),(6,53,2,100,'  ',0.00,'2019-04-26 19:40:32'),(7,51,2,1001,'System.Data.Entity.DynamicProxies.stok_ad_3CF95492D000369D32F2B643D6ADEF4B90BEB5C20E5579BBB9CC8A536F85EDF5 System.Data.Entity.DynamicProxies.stok_ad_3CF95492D000369D32F2B643D6ADEF4B90BEB5C20E5579BBB9CC8A536F85EDF5 ',0.00,'2019-04-26 19:57:30'),(8,51,2,100,'kola kola ',0.00,'2019-04-26 20:29:27'),(9,46,2,1001,'kola kola kola ',20.00,'2019-05-06 14:35:12'),(10,46,2,121,'kola kola kola ',45.00,'2019-05-06 14:36:58'),(11,46,2,45,'kola kola kola ',20.00,'2019-05-06 14:37:54');
/*!40000 ALTER TABLE `ucret` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-07-26  2:59:53
