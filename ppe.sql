-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : jeu. 22 avr. 2021 à 08:20
-- Version du serveur :  5.7.31
-- Version de PHP : 7.3.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `ppe`
--

-- --------------------------------------------------------

--
-- Structure de la table `log_connexion`
--

DROP TABLE IF EXISTS `log_connexion`;
CREATE TABLE IF NOT EXISTS `log_connexion` (
  `id_log` int(11) NOT NULL AUTO_INCREMENT,
  `fk_user` int(11) NOT NULL,
  `date_connexion` datetime DEFAULT NULL,
  PRIMARY KEY (`id_log`)
) ENGINE=MyISAM AUTO_INCREMENT=163 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `log_connexion`
--

INSERT INTO `log_connexion` (`id_log`, `fk_user`, `date_connexion`) VALUES
(83, 1, '2021-04-16 10:12:34'),
(82, 1, '2021-04-16 09:51:20'),
(81, 1, '2021-04-16 09:49:07'),
(80, 1, '2021-04-16 09:47:14'),
(79, 1, '2021-04-09 16:34:01'),
(78, 1, '2021-04-09 12:50:31'),
(77, 1, '2021-04-09 12:13:45'),
(76, 1, '2021-04-09 11:59:03'),
(75, 1, '2021-04-09 11:37:48'),
(74, 1, '2021-04-09 11:30:34'),
(73, 1, '2021-04-09 11:27:47'),
(72, 1, '2021-04-05 23:54:15'),
(71, 1, '2021-04-05 13:32:05'),
(70, 1, '2021-04-05 13:27:48'),
(69, 1, '2021-04-05 13:25:20'),
(68, 1, '2021-04-05 13:25:08'),
(67, 1, '2021-04-05 12:59:14'),
(66, 1, '2021-04-05 12:55:43'),
(65, 1, '2021-04-05 12:53:20'),
(64, 1, '2021-04-05 12:51:25'),
(63, 1, '2021-04-05 12:49:58'),
(62, 1, '2021-04-05 12:47:31'),
(61, 1, '2021-04-05 12:46:37'),
(60, 1, '2021-04-05 11:48:13'),
(59, 1, '2021-04-05 11:35:26'),
(41, 1, '2021-04-02 13:24:45'),
(42, 1, '2021-04-02 13:25:45'),
(43, 1, '2021-04-02 13:28:59'),
(44, 1, '2021-04-02 13:50:06'),
(45, 1, '2021-04-02 14:17:09'),
(46, 1, '2021-04-02 16:51:37'),
(47, 1, '2021-04-02 16:55:10'),
(48, 1, '2021-04-02 16:56:50'),
(49, 1, '2021-04-02 17:02:31'),
(50, 1, '2021-04-02 17:26:34'),
(51, 1, '2021-04-05 09:57:49'),
(52, 1, '2021-04-05 10:03:12'),
(53, 1, '2021-04-05 10:04:50'),
(54, 1, '2021-04-05 10:06:07'),
(55, 1, '2021-04-05 10:09:25'),
(56, 1, '2021-04-05 10:10:51'),
(57, 1, '2021-04-05 10:11:34'),
(58, 1, '2021-04-05 10:13:32'),
(84, 1, '2021-04-16 10:16:00'),
(85, 1, '2021-04-16 10:41:12'),
(86, 1, '2021-04-16 10:54:38'),
(87, 1, '2021-04-16 10:55:17'),
(88, 1, '2021-04-17 23:30:11'),
(89, 1, '2021-04-17 23:35:35'),
(90, 1, '2021-04-17 23:43:42'),
(91, 1, '2021-04-17 23:50:28'),
(92, 1, '2021-04-17 23:53:00'),
(93, 1, '2021-04-17 23:58:56'),
(94, 1, '2021-04-18 00:03:04'),
(95, 1, '2021-04-18 00:03:48'),
(96, 1, '2021-04-18 00:05:07'),
(97, 1, '2021-04-18 00:06:55'),
(98, 1, '2021-04-18 00:07:31'),
(99, 1, '2021-04-18 00:11:48'),
(100, 1, '2021-04-18 00:13:47'),
(101, 1, '2021-04-18 00:18:02'),
(102, 1, '2021-04-18 00:18:38'),
(103, 1, '2021-04-18 00:20:25'),
(104, 1, '2021-04-18 00:31:52'),
(105, 1, '2021-04-18 00:32:33'),
(106, 1, '2021-04-18 00:36:37'),
(107, 1, '2021-04-18 00:42:09'),
(108, 1, '2021-04-18 00:47:57'),
(109, 1, '2021-04-18 00:48:50'),
(110, 1, '2021-04-18 01:03:13'),
(111, 1, '2021-04-18 01:04:41'),
(112, 1, '2021-04-18 01:08:48'),
(113, 1, '2021-04-18 01:12:14'),
(114, 1, '2021-04-18 01:14:45'),
(115, 1, '2021-04-18 01:22:52'),
(116, 1, '2021-04-18 01:44:04'),
(117, 1, '2021-04-18 02:31:37'),
(118, 1, '2021-04-18 02:31:59'),
(119, 1, '2021-04-18 03:12:16'),
(120, 1, '2021-04-18 03:14:09'),
(121, 1, '2021-04-18 03:21:25'),
(122, 1, '2021-04-18 03:25:51'),
(123, 1, '2021-04-18 03:40:36'),
(124, 1, '2021-04-18 03:45:57'),
(125, 1, '2021-04-18 03:49:54'),
(126, 1, '2021-04-18 03:55:56'),
(127, 1, '2021-04-18 04:18:05'),
(128, 1, '2021-04-18 04:19:43'),
(129, 1, '2021-04-18 04:22:48'),
(130, 1, '2021-04-18 04:25:48'),
(131, 1, '2021-04-18 04:26:18'),
(132, 1, '2021-04-18 04:29:43'),
(133, 1, '2021-04-18 04:30:18'),
(134, 1, '2021-04-18 04:30:47'),
(135, 1, '2021-04-18 04:33:28'),
(136, 1, '2021-04-18 04:37:48'),
(137, 1, '2021-04-18 04:41:31'),
(138, 1, '2021-04-18 04:44:42'),
(139, 1, '2021-04-18 04:46:37'),
(140, 1, '2021-04-18 04:47:48'),
(141, 1, '2021-04-18 04:49:23'),
(142, 1, '2021-04-18 04:51:04'),
(143, 1, '2021-04-18 04:52:18'),
(144, 1, '2021-04-18 04:54:44'),
(145, 1, '2021-04-18 04:59:06'),
(146, 1, '2021-04-18 05:00:34'),
(147, 1, '2021-04-18 05:01:46'),
(148, 1, '2021-04-18 05:03:32'),
(149, 1, '2021-04-18 05:05:34'),
(150, 1, '2021-04-18 05:06:19'),
(151, 1, '2021-04-18 11:22:27'),
(152, 1, '2021-04-18 11:26:51'),
(153, 1, '2021-04-18 11:32:47'),
(154, 1, '2021-04-18 11:35:23'),
(155, 1, '2021-04-18 11:38:45'),
(156, 1, '2021-04-18 11:40:25'),
(157, 1, '2021-04-18 11:42:04'),
(158, 1, '2021-04-18 11:44:47'),
(159, 1, '2021-04-18 11:45:28'),
(160, 1, '2021-04-18 11:47:11'),
(161, 1, '2021-04-18 11:48:20'),
(162, 1, '2021-04-18 11:49:11');

-- --------------------------------------------------------

--
-- Structure de la table `log_echec_connexion`
--

DROP TABLE IF EXISTS `log_echec_connexion`;
CREATE TABLE IF NOT EXISTS `log_echec_connexion` (
  `id_log_echec` int(11) NOT NULL AUTO_INCREMENT,
  `login` varchar(120) NOT NULL,
  `heure_tentative` datetime NOT NULL,
  PRIMARY KEY (`id_log_echec`)
) ENGINE=MyISAM AUTO_INCREMENT=81 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `log_echec_connexion`
--

INSERT INTO `log_echec_connexion` (`id_log_echec`, `login`, `heure_tentative`) VALUES
(1, 'Nathan', '2021-02-28 22:14:09'),
(2, 'Nathan', '2021-02-28 22:18:47'),
(3, 'Nathan', '2021-02-28 22:19:21'),
(14, 'a', '2021-04-16 10:32:48'),
(13, 'a', '2021-04-16 10:18:55'),
(12, 'a', '2021-04-16 10:17:07'),
(11, 'a', '2021-04-09 12:49:54'),
(10, 'abc', '2021-04-09 11:59:32'),
(9, 'aa', '2021-04-05 11:51:02'),
(15, 'a', '2021-04-16 10:33:06'),
(16, 'a', '2021-04-16 10:37:28'),
(17, 'a', '2021-04-16 10:37:49'),
(18, 'a', '2021-04-16 10:37:53'),
(19, 'a', '2021-04-16 10:37:56'),
(20, 'aa', '2021-04-16 10:38:01'),
(21, 'aa', '2021-04-16 10:38:05'),
(22, 'a', '2021-04-16 10:38:53'),
(23, 'a', '2021-04-16 10:38:58'),
(24, 'A', '2021-04-16 10:39:23'),
(25, 'A', '2021-04-16 10:39:27'),
(26, 'a', '2021-04-16 10:40:33'),
(27, 'a', '2021-04-16 10:40:36'),
(28, 'a', '2021-04-16 10:40:39'),
(29, 'a', '2021-04-16 10:40:43'),
(30, 'a', '2021-04-16 10:40:45'),
(31, 'Jvalade', '2021-04-16 10:54:12'),
(32, 'Jvalade', '2021-04-16 10:54:16'),
(33, 'Jvalade', '2021-04-16 10:54:18'),
(34, 'Jvalade', '2021-04-16 10:54:22'),
(35, 'Jvalade', '2021-04-16 10:54:25'),
(36, 'a', '2021-04-18 01:49:04'),
(37, 'a', '2021-04-18 01:49:33'),
(38, 'a', '2021-04-18 01:52:55'),
(39, 'a', '2021-04-18 01:53:02'),
(40, 'a', '2021-04-18 01:53:23'),
(41, 'A', '2021-04-18 02:03:57'),
(42, 'a', '2021-04-18 02:06:17'),
(43, 'a', '2021-04-18 02:06:36'),
(44, 'a', '2021-04-18 02:06:39'),
(45, 'a', '2021-04-18 02:07:16'),
(46, 'a', '2021-04-18 02:07:30'),
(47, 'a', '2021-04-18 02:13:18'),
(48, 'A', '2021-04-18 02:13:45'),
(49, 'a', '2021-04-18 02:14:13'),
(50, 'a', '2021-04-18 02:14:16'),
(51, 'a', '2021-04-18 02:14:17'),
(52, 'a', '2021-04-18 02:14:19'),
(53, 'a', '2021-04-18 02:14:21'),
(54, 'a', '2021-04-18 02:14:46'),
(55, 'Aa', '2021-04-18 02:15:10'),
(56, 'a', '2021-04-18 02:15:27'),
(57, 'a', '2021-04-18 02:15:29'),
(58, 'a', '2021-04-18 02:15:30'),
(59, 'a', '2021-04-18 02:15:32'),
(60, 'a', '2021-04-18 02:15:33'),
(61, 'a', '2021-04-18 02:20:03'),
(62, 'a', '2021-04-18 02:20:08'),
(63, 'a', '2021-04-18 02:20:12'),
(64, 'a', '2021-04-18 02:20:15'),
(65, 'a', '2021-04-18 02:20:18'),
(66, 'a', '2021-04-18 02:21:40'),
(67, 'a', '2021-04-18 02:21:43'),
(68, 'a', '2021-04-18 02:21:45'),
(69, 'a', '2021-04-18 02:21:48'),
(70, 'a', '2021-04-18 02:21:51'),
(71, 'a', '2021-04-18 02:22:32'),
(72, 'a', '2021-04-18 02:22:33'),
(73, 'a', '2021-04-18 02:22:35'),
(74, 'a', '2021-04-18 02:22:36'),
(75, 'a', '2021-04-18 02:22:38'),
(76, 'a', '2021-04-18 02:25:16'),
(77, 'a', '2021-04-18 02:25:18'),
(78, 'a', '2021-04-18 02:25:19'),
(79, 'a', '2021-04-18 02:25:21'),
(80, 'a', '2021-04-18 02:25:26');

-- --------------------------------------------------------

--
-- Structure de la table `participant`
--

DROP TABLE IF EXISTS `participant`;
CREATE TABLE IF NOT EXISTS `participant` (
  `id_participant` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(255) NOT NULL,
  `prenom` varchar(255) NOT NULL,
  `departement` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  PRIMARY KEY (`id_participant`),
  UNIQUE KEY `email` (`email`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `participant`
--

INSERT INTO `participant` (`id_participant`, `nom`, `prenom`, `departement`, `email`) VALUES
(1, 'test', 'test', '77', 'test@gmail.com'),
(2, 'partouche', 'nathan', '75', 'nathan@gmail.com');

-- --------------------------------------------------------

--
-- Structure de la table `remarque`
--

DROP TABLE IF EXISTS `remarque`;
CREATE TABLE IF NOT EXISTS `remarque` (
  `id_remarque` int(11) NOT NULL AUTO_INCREMENT,
  `fk_user` int(11) NOT NULL,
  `commentaire` varchar(255) NOT NULL,
  `date_redaction` varchar(255) NOT NULL,
  `fk_type` int(11) NOT NULL,
  PRIMARY KEY (`id_remarque`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `remarque`
--

INSERT INTO `remarque` (`id_remarque`, `fk_user`, `commentaire`, `date_redaction`, `fk_type`) VALUES
(6, 1, 'Avoir un blablabla merci', '2021-04-05 13:34:02', 2),
(5, 1, 'Beug sur la page.....', '2021-04-05 13:33:07', 1);

-- --------------------------------------------------------

--
-- Structure de la table `salons`
--

DROP TABLE IF EXISTS `salons`;
CREATE TABLE IF NOT EXISTS `salons` (
  `id_salon` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(255) NOT NULL,
  `date_salon` varchar(255) NOT NULL,
  `lieu` varchar(255) NOT NULL,
  PRIMARY KEY (`id_salon`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `type`
--

DROP TABLE IF EXISTS `type`;
CREATE TABLE IF NOT EXISTS `type` (
  `id_type` int(11) NOT NULL AUTO_INCREMENT,
  `libelle` varchar(120) NOT NULL,
  PRIMARY KEY (`id_type`),
  UNIQUE KEY `libelle` (`libelle`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `type`
--

INSERT INTO `type` (`id_type`, `libelle`) VALUES
(1, 'Administrateur'),
(2, 'Opérateur de salon');

-- --------------------------------------------------------

--
-- Structure de la table `type_aide`
--

DROP TABLE IF EXISTS `type_aide`;
CREATE TABLE IF NOT EXISTS `type_aide` (
  `id_aide` int(11) NOT NULL AUTO_INCREMENT,
  `libelle` varchar(255) NOT NULL,
  PRIMARY KEY (`id_aide`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `type_aide`
--

INSERT INTO `type_aide` (`id_aide`, `libelle`) VALUES
(1, 'Dysfonctionnement'),
(2, 'Souhait d\'évolution');

-- --------------------------------------------------------

--
-- Structure de la table `user`
--

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(255) NOT NULL,
  `prenom` varchar(255) NOT NULL,
  `login` varchar(120) NOT NULL,
  `mdp` varchar(120) NOT NULL,
  `type` varchar(120) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=24 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `user`
--

INSERT INTO `user` (`id`, `nom`, `prenom`, `login`, `mdp`, `type`) VALUES
(1, 'Nathan', 'Partouche', 'Nathan', '00D70C561892A94980BEFD12A400E26AEB4B8599', '1'),
(2, 'User', 'User', 'User', '00D70C561892A94980BEFD12A400E26AEB4B8599', '2'),
(3, 'Invite', 'Invite', 'Invite', '00D70C561892A94980BEFD12A400E26AEB4B8599', '3'),
(22, 'Correcteur', 'Correcteur', 'Correcteur', '7B4D45627C1A52D3DD802E8345EE497BC5B45E86', '1'),
(23, 'test', 'test', 'test', 'A94A8FE5CCB19BA61C4C0873D391E987982FBBD3', '1');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
