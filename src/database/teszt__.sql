-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: localhost
-- Létrehozás ideje: 2023. Dec 15. 20:30
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
-- Tábla szerkezet ehhez a táblához `answers`
--

CREATE TABLE `answers` (
  `id` int(11) NOT NULL,
  `value` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `correct` tinyint(1) NOT NULL,
  `questionId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `answers`
--

INSERT INTO `answers` (`id`, `value`, `correct`, `questionId`) VALUES
(1, 'A', 0, 1),
(2, 'B', 1, 1),
(3, 'C', 0, 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `courses`
--

CREATE TABLE `courses` (
  `id` int(11) NOT NULL,
  `name` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `user_limit` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `courses`
--

INSERT INTO `courses` (`id`, `name`, `user_limit`) VALUES
(1, 'Játékok', 10);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `questions`
--

CREATE TABLE `questions` (
  `id` int(11) NOT NULL,
  `name` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `questionType` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `value` int(11) NOT NULL,
  `testId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `questions`
--

INSERT INTO `questions` (`id`, `name`, `questionType`, `value`, `testId`) VALUES
(1, 'Q', 'Rádiógomb', 0, NULL);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `tests`
--

CREATE TABLE `tests` (
  `id` int(11) NOT NULL,
  `name` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `submit_limit` int(11) NOT NULL,
  `date` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `startTime` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `endTime` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `CourseId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `tests`
--

INSERT INTO `tests` (`id`, `name`, `submit_limit`, `date`, `startTime`, `endTime`, `CourseId`) VALUES
(1, 'League Of Legends', 2, '2023. 12. 15.', '10:00', '12:00', 1);

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
('KGergo02', 'UQH6OyTUF0PU8A/9fJOrkg==', 'kassa.gergo2002@gmail.com', 1);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `answers`
--
ALTER TABLE `answers`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Question` (`questionId`);

--
-- A tábla indexei `courses`
--
ALTER TABLE `courses`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `questions`
--
ALTER TABLE `questions`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Test` (`testId`);

--
-- A tábla indexei `tests`
--
ALTER TABLE `tests`
  ADD PRIMARY KEY (`id`),
  ADD KEY `CourseId` (`CourseId`) USING BTREE;

--
-- A tábla indexei `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`name`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `answers`
--
ALTER TABLE `answers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `courses`
--
ALTER TABLE `courses`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT a táblához `questions`
--
ALTER TABLE `questions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT a táblához `tests`
--
ALTER TABLE `tests`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `answers`
--
ALTER TABLE `answers`
  ADD CONSTRAINT `Question` FOREIGN KEY (`questionId`) REFERENCES `questions` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `questions`
--
ALTER TABLE `questions`
  ADD CONSTRAINT `Test` FOREIGN KEY (`testId`) REFERENCES `tests` (`id`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Megkötések a táblához `tests`
--
ALTER TABLE `tests`
  ADD CONSTRAINT `Course` FOREIGN KEY (`CourseId`) REFERENCES `courses` (`id`) ON DELETE SET NULL ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
