CREATE DATABASE  IF NOT EXISTS `sitiowebinmobiliaria` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `sitiowebinmobiliaria`;
-- MySQL dump 10.13  Distrib 8.0.18, for Win64 (x86_64)
--
-- Host: localhost    Database: sitiowebinmobiliaria
-- ------------------------------------------------------
-- Server version	8.0.18

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
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cliente` (
  `id_cliente` smallint(6) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(32) NOT NULL,
  `apellido` varchar(32) NOT NULL,
  `email` varchar(32) NOT NULL,
  `telefono` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_cliente`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` VALUES (1,'coso','comue','cliente',1234),(2,'coso','cosito','ironman',24565),(3,'carlos','juarez','pichicho',123456),(4,'Tatiana','Sanagua','Tati@hotmail.com',155343434),(5,'juan','penalba','juan@hotmail.com',4330390);
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cliente_propiedad`
--

DROP TABLE IF EXISTS `cliente_propiedad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cliente_propiedad` (
  `id_cliente` smallint(6) NOT NULL,
  `id_propiedad` smallint(6) NOT NULL,
  PRIMARY KEY (`id_cliente`,`id_propiedad`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente_propiedad`
--

LOCK TABLES `cliente_propiedad` WRITE;
/*!40000 ALTER TABLE `cliente_propiedad` DISABLE KEYS */;
/*!40000 ALTER TABLE `cliente_propiedad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cliente_terreno`
--

DROP TABLE IF EXISTS `cliente_terreno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cliente_terreno` (
  `id_cliente` smallint(6) NOT NULL,
  `id_terreno` smallint(6) NOT NULL,
  PRIMARY KEY (`id_cliente`,`id_terreno`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente_terreno`
--

LOCK TABLES `cliente_terreno` WRITE;
/*!40000 ALTER TABLE `cliente_terreno` DISABLE KEYS */;
/*!40000 ALTER TABLE `cliente_terreno` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `duenio`
--

DROP TABLE IF EXISTS `duenio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `duenio` (
  `id_duenio` smallint(6) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(32) NOT NULL,
  `email` varchar(32) NOT NULL,
  `telefono` int(11) DEFAULT NULL,
  `direccion` varchar(32) DEFAULT NULL,
  `horariodisp` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`id_duenio`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `duenio`
--

LOCK TABLES `duenio` WRITE;
/*!40000 ALTER TABLE `duenio` DISABLE KEYS */;
INSERT INTO `duenio` VALUES (1,'juan penalba','juan',123345,NULL,'123'),(2,'juan','superman',234,'kriptonita','all day'),(3,'Maria Sanchez','maria@gmail.com',15423423,NULL,'16-21');
/*!40000 ALTER TABLE `duenio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inmobiliaria`
--

DROP TABLE IF EXISTS `inmobiliaria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `inmobiliaria` (
  `id_inmobiliaria` smallint(6) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(32) NOT NULL,
  `email` varchar(32) NOT NULL,
  `telefono` int(11) DEFAULT NULL,
  `direccion` varchar(32) DEFAULT NULL,
  `sitioweb` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`id_inmobiliaria`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inmobiliaria`
--

LOCK TABLES `inmobiliaria` WRITE;
/*!40000 ALTER TABLE `inmobiliaria` DISABLE KEYS */;
INSERT INTO `inmobiliaria` VALUES (1,'juan loko','coso',2345,'SALTA123','web.com'),(2,'Castillo Inmuebles','castillo@hotmail.com',421654,'Las Heras 1345','castillo.com'),(3,'ops','inmobiliaria@OPS',4556768,'calle sin nombre 123','OPS.COM');
/*!40000 ALTER TABLE `inmobiliaria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `logueo`
--

DROP TABLE IF EXISTS `logueo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `logueo` (
  `id_logueo` smallint(6) NOT NULL AUTO_INCREMENT,
  `id_cliente` smallint(6) DEFAULT NULL,
  `id_duenio` smallint(6) DEFAULT NULL,
  `id_inmobiliaria` smallint(6) DEFAULT NULL,
  `email` varchar(32) NOT NULL,
  `pass` varchar(32) NOT NULL,
  PRIMARY KEY (`id_logueo`),
  KEY `id_clientel` (`id_cliente`),
  KEY `id_dueniol` (`id_duenio`),
  KEY `id_inmobiliarial` (`id_inmobiliaria`),
  CONSTRAINT `id_clientel` FOREIGN KEY (`id_cliente`) REFERENCES `cliente` (`id_cliente`),
  CONSTRAINT `id_dueniol` FOREIGN KEY (`id_duenio`) REFERENCES `duenio` (`id_duenio`),
  CONSTRAINT `id_inmobiliarial` FOREIGN KEY (`id_inmobiliaria`) REFERENCES `inmobiliaria` (`id_inmobiliaria`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `logueo`
--

LOCK TABLES `logueo` WRITE;
/*!40000 ALTER TABLE `logueo` DISABLE KEYS */;
INSERT INTO `logueo` VALUES (1,NULL,1,NULL,'juan','123'),(2,NULL,2,NULL,'superman','123'),(3,1,NULL,NULL,'cliente','123'),(4,NULL,NULL,1,'coso','123'),(5,2,NULL,NULL,'ironman','123'),(6,3,NULL,NULL,'pichicho','123'),(7,4,NULL,NULL,'Tati@hotmail.com','98765'),(8,NULL,3,NULL,'maria@gmail.com','98765'),(9,NULL,NULL,2,'castillo@hotmail.com','234'),(10,5,NULL,NULL,'juan@hotmail.com','123'),(11,NULL,NULL,3,'inmobiliaria@OPS','123');
/*!40000 ALTER TABLE `logueo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `propiedad`
--

DROP TABLE IF EXISTS `propiedad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `propiedad` (
  `id_propiedad` smallint(6) NOT NULL AUTO_INCREMENT,
  `id_duenio` smallint(6) DEFAULT NULL,
  `id_inmobiliaria` smallint(6) DEFAULT NULL,
  `nombre` varchar(32) DEFAULT NULL,
  `superficie` int(11) DEFAULT NULL,
  `direccion` varchar(32) DEFAULT NULL,
  `estado` varchar(11) DEFAULT NULL,
  `precio` double DEFAULT NULL,
  `condicion` tinyint(1) DEFAULT NULL,
  `fechahabitable` varchar(15) DEFAULT NULL,
  `cantbanios` int(11) DEFAULT NULL,
  `canthabitaciones` int(11) DEFAULT NULL,
  `cantcocheras` int(11) DEFAULT NULL,
  `cantsuites` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_propiedad`),
  UNIQUE KEY `nombre` (`nombre`),
  UNIQUE KEY `direccion` (`direccion`),
  KEY `id_dueniop` (`id_duenio`),
  KEY `id_inmobiliariap` (`id_inmobiliaria`),
  CONSTRAINT `id_dueniop` FOREIGN KEY (`id_duenio`) REFERENCES `duenio` (`id_duenio`),
  CONSTRAINT `id_inmobiliariap` FOREIGN KEY (`id_inmobiliaria`) REFERENCES `inmobiliaria` (`id_inmobiliaria`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `propiedad`
--

LOCK TABLES `propiedad` WRITE;
/*!40000 ALTER TABLE `propiedad` DISABLE KEYS */;
INSERT INTO `propiedad` VALUES (1,1,NULL,'propiedad',2000,'calle 4232','0',300000,0,'2012-01-01',1,1,0,0),(2,1,NULL,'nuevaa',300,'calle salta234','1',2000,0,'2020-01-01',1,2,0,0),(3,1,NULL,'propiedad 32',10000,'calle 541','0',100000,1,'2019-12-03',1,1,0,0),(4,NULL,2,'Casa Castillo',300,'Rivadavia 245','1',500000,1,'2012-02-12',1,2,1,0);
/*!40000 ALTER TABLE `propiedad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `terreno`
--

DROP TABLE IF EXISTS `terreno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `terreno` (
  `id_terreno` smallint(6) NOT NULL AUTO_INCREMENT,
  `id_duenio` smallint(6) DEFAULT NULL,
  `id_inmobiliaria` smallint(6) DEFAULT NULL,
  `nombre` varchar(32) DEFAULT NULL,
  `superficie` int(11) DEFAULT NULL,
  `direccion` varchar(32) DEFAULT NULL,
  `estado` varchar(11) DEFAULT NULL,
  `precio` double DEFAULT NULL,
  PRIMARY KEY (`id_terreno`),
  UNIQUE KEY `direccion` (`direccion`),
  KEY `id_duenio` (`id_duenio`),
  KEY `id_inmobiliaria` (`id_inmobiliaria`),
  CONSTRAINT `id_duenio` FOREIGN KEY (`id_duenio`) REFERENCES `duenio` (`id_duenio`),
  CONSTRAINT `id_inmobiliaria` FOREIGN KEY (`id_inmobiliaria`) REFERENCES `inmobiliaria` (`id_inmobiliaria`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `terreno`
--

LOCK TABLES `terreno` WRITE;
/*!40000 ALTER TABLE `terreno` DISABLE KEYS */;
INSERT INTO `terreno` VALUES (1,1,NULL,'terreno1',200,'calle1234','1',40000),(6,1,NULL,'terrenito',20000,'calle buenavida 583','1',2000000),(7,1,NULL,'terrenazo',300000,'calle supercalle 560','1',3000000),(9,3,NULL,'Casa Campo',200000,'Ruta N 9 km 32','1',300000),(10,NULL,3,'terreno ops ',3000,'corriente 45','1',2000000);
/*!40000 ALTER TABLE `terreno` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-12-04 18:03:44
