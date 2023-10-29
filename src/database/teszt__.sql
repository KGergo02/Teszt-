-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: localhost
-- Létrehozás ideje: 2023. Okt 29. 17:05
-- Kiszolgáló verziója: 10.4.25-MariaDB
-- PHP verzió: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `teszt++`
--
CREATE DATABASE IF NOT EXISTS `teszt++` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `teszt++`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `courses`
--

CREATE TABLE `courses` (
  `name` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `user_limit` int(11) NOT NULL,
  `tests` blob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `courses`
--

INSERT INTO `courses` (`name`, `user_limit`, `tests`) VALUES
('Játékok', 10, '');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `questions`
--

CREATE TABLE `questions` (
  `name` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `questions` blob NOT NULL,
  `answers` blob NOT NULL,
  `questionType` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `testName` varchar(100) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `tests`
--

CREATE TABLE `tests` (
  `name` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `submit_limit` int(11) NOT NULL,
  `date` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `startTime` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `endTime` varchar(100) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `tests`
--

INSERT INTO `tests` (`name`, `submit_limit`, `date`, `startTime`, `endTime`) VALUES
('CS2', 2, '2023. 10. 30.', '10:00', '12:00'),
('League of Legends', 1, '2023. 10. 31.', '01:00', '02:00');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users`
--

CREATE TABLE `users` (
  `name` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `password` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `email` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `admin` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`name`, `password`, `email`, `admin`) VALUES
('ASD', '/rA2D/Mil+M=', 'asd@asd.com', 1),
('KGergo02', 'UQH6OyTUF0PU8A/9fJOrkg==', 'kassa.gergo2002@gmail.com', 1),
('Teszt', '/rA2D/Mil+M=', 'teszt@teszt.com', 0);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `courses`
--
ALTER TABLE `courses`
  ADD PRIMARY KEY (`name`);

--
-- A tábla indexei `questions`
--
ALTER TABLE `questions`
  ADD PRIMARY KEY (`name`),
  ADD UNIQUE KEY `testName` (`testName`);

--
-- A tábla indexei `tests`
--
ALTER TABLE `tests`
  ADD PRIMARY KEY (`name`);

--
-- A tábla indexei `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`name`);

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `questions`
--
ALTER TABLE `questions`
  ADD CONSTRAINT `questions_ibfk_1` FOREIGN KEY (`testName`) REFERENCES `tests` (`name`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
