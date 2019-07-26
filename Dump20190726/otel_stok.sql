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
-- Table structure for table `stok`
--

DROP TABLE IF EXISTS `stok`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `stok` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `stok_grup_id` int(11) NOT NULL,
  `stok_ad_id` int(11) NOT NULL,
  `stok_birim_id` int(11) NOT NULL,
  `fiyat` decimal(13,2) NOT NULL,
  `miktar` decimal(13,2) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `stok_grup_id` (`stok_grup_id`),
  KEY `stok_ad_id` (`stok_ad_id`),
  KEY `stok_birim_id` (`stok_birim_id`),
  CONSTRAINT `stok_ibfk_1` FOREIGN KEY (`stok_grup_id`) REFERENCES `stok_grup` (`id`),
  CONSTRAINT `stok_ibfk_2` FOREIGN KEY (`stok_ad_id`) REFERENCES `stok_ad` (`id`),
  CONSTRAINT `stok_ibfk_3` FOREIGN KEY (`stok_birim_id`) REFERENCES `stok_birim` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stok`
--

LOCK TABLES `stok` WRITE;
/*!40000 ALTER TABLE `stok` DISABLE KEYS */;
INSERT INTO `stok` VALUES (1,1,1,1,5.00,1998.00),(2,1,1,1,0.00,0.00),(3,2,2,2,0.00,0.00),(6,1,1,1,1.00,99.00),(7,1,1,1,50.00,491.00),(10,3,1,2,1000.00,5000.00),(11,1,1,1,10000.00,25.00),(12,1,1,1,10000.00,555.00),(13,1,1,1,555.00,234.00),(14,1,1,2,100.00,0.00),(15,1,1,1,777.00,12.00),(16,1,1,1,555.00,123.00),(17,1,1,1,1.00,1.00),(18,1,1,1,1.00,9001.00),(22,1,2,1,1000.00,100.00);
/*!40000 ALTER TABLE `stok` ENABLE KEYS */;
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
