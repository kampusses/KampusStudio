-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Creato il: Mar 24, 2020 alle 22:13
-- Versione del server: 5.7.17
-- Versione PHP: 5.6.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `kampus`
--

-- --------------------------------------------------------

--
-- Struttura della tabella `comuni`
--

CREATE TABLE `comuni` (
  `codiceCatastale` varchar(4) NOT NULL COMMENT 'Codice catastale',
  `nomeComune` varchar(30) NOT NULL COMMENT 'Nome comune',
  `regione` int(11) NOT NULL COMMENT 'Regione',
  `provincia` int(11) NOT NULL COMMENT 'Provincia',
  `ripartizioneGeografica` int(11) NOT NULL COMMENT 'Ripartizione geografica',
  `abitanti` int(11) NOT NULL COMMENT 'Numero abitanti',
  `prefisso` varchar(5) NOT NULL COMMENT 'Prefisso telefonico',
  `cap` varchar(5) NOT NULL COMMENT 'CAP'
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Elenco dei comuni italiani';

--
-- Dump dei dati per la tabella `comuni`
--

INSERT INTO `comuni` (`codiceCatastale`, `nomeComune`, `regione`, `provincia`, `ripartizioneGeografica`, `abitanti`, `prefisso`, `cap`) VALUES
('E946', 'MARGHERITA DI SAVOIA', 1, 2, 3, 11000, '0883', '76016');

--
-- Indici per le tabelle scaricate
--

--
-- Indici per le tabelle `comuni`
--
ALTER TABLE `comuni`
  ADD PRIMARY KEY (`codiceCatastale`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
