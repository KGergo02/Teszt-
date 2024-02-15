-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: localhost
-- Létrehozás ideje: 2024. Feb 15. 18:28
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
(12, 'Hétfő', 1, 26),
(13, 'A', 1, 27),
(14, 'B', 0, 27),
(15, 'C', 0, 27),
(16, 'D', 1, 27),
(17, '2', 1, 28),
(18, '1', 0, 28),
(19, '0', 0, 28),
(20, 'A', 0, 29),
(21, 'B', 1, 29),
(22, 'C', 0, 29),
(23, 'A', 1, 30),
(24, 'B', 0, 30),
(25, 'A', 0, 31),
(26, 'B', 0, 31),
(27, 'C', 1, 31),
(28, 'A', 0, 32),
(29, 'Teszt', 1, 32),
(30, 'B', 0, 32),
(31, 'ASFD', 0, 33),
(32, 'ASD', 1, 33),
(33, 'ABS', 0, 33),
(34, 'ASDF', 1, 34),
(35, 'ASED', 0, 34),
(36, 'ASB', 0, 34),
(37, 'PPP', 1, 35),
(38, 'ppp', 0, 35),
(39, 'aaa', 0, 35),
(40, 'for', 1, 36),
(41, 'D', 1, 37),
(42, 'A', 0, 37),
(43, 'B', 0, 37);

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
(1, 'Kurzus1', 10),
(2, 'Programozás I.', 200),
(3, 'Adatbázisok', 100),
(4, 'Filler', 10);

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
(26, 'Milyen nap van ma?', 'Szöveges válasz', 5, 9),
(27, 'A és D', 'Jelölődoboz', 2, 9),
(28, '1+1?', 'Rádiógomb', 5, 9),
(29, 'B', 'Jelölődoboz', 10, 9),
(30, 'A', 'Jelölődoboz', 10, 9),
(31, 'C', 'Jelölődoboz', 10, 9),
(32, 'Teszt', 'Jelölődoboz', 20, 9),
(33, 'ASD', 'Jelölődoboz', 30, 9),
(34, 'ASDF', 'Jelölődoboz', 5, 9),
(35, 'PPP', 'Rádiógomb', 10, 9),
(36, 'Code', 'Szöveges válasz', 30, 9),
(37, 'D', 'Jelölődoboz', 5, 9);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `results`
--

CREATE TABLE `results` (
  `id` int(11) NOT NULL,
  `username` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `value` int(11) NOT NULL,
  `testid` int(11) NOT NULL,
  `date` varchar(100) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `results`
--

INSERT INTO `results` (`id`, `username`, `value`, `testid`, `date`) VALUES
(9, 'ASD', 10, 9, '2024. 02. 15. 18:21:01'),
(10, 'Próba', 35, 9, '2024. 02. 15. 18:22:11'),
(11, 'Próba', 0, 12, '2024. 02. 15. 18:28:26');

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
(1, 'League Of Legends', 1, '2023. 12. 16.', '10:00', '12:00', 1),
(2, 'Teszt1', 1, '2024. 01. 04.', '12:00', '13:00', NULL),
(3, 'Teszt2', 1, '2024. 01. 05.', '12:00', '12:05', NULL),
(5, 'Correct', 1, '2024. 01. 03.', '16:00', '16:02', 1),
(9, 'Mindig indítható', 100, '2024. 02. 15.', '00:00', '24:00', 3),
(12, 'Nem indítható', 1, '2024. 02. 15.', '10:00', '20:00', 4);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `name` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `password` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `email` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `admin` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`id`, `name`, `password`, `email`, `admin`) VALUES
(1, 'KGergo02', 'jJYWPRZl0WA=', 'kassa.gergo2002@gmail.com', 1),
(2, 'ASD', '/rA2D/Mil+M=', 'asd@asd.com', 1),
(5, 'Próba', '/rA2D/Mil+M=', 'teszt@test.com', 0);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `user_courses`
--

CREATE TABLE `user_courses` (
  `id` int(11) NOT NULL,
  `user_name` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `course_name` varchar(100) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `user_courses`
--

INSERT INTO `user_courses` (`id`, `user_name`, `course_name`) VALUES
(1, 'ASD', 'Kurzus1'),
(2, 'ASD', 'Adatbázisok'),
(3, 'ASD', 'Filler'),
(6, 'Próba', 'Adatbázisok'),
(7, 'Próba', 'Filler');

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
  ADD PRIMARY KEY (`id`),
  ADD KEY `name` (`name`);

--
-- A tábla indexei `questions`
--
ALTER TABLE `questions`
  ADD PRIMARY KEY (`id`),
  ADD KEY `testId` (`testId`);

--
-- A tábla indexei `results`
--
ALTER TABLE `results`
  ADD PRIMARY KEY (`id`),
  ADD KEY `username` (`username`),
  ADD KEY `testid` (`testid`);

--
-- A tábla indexei `tests`
--
ALTER TABLE `tests`
  ADD PRIMARY KEY (`id`),
  ADD KEY `CourseId` (`CourseId`);

--
-- A tábla indexei `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD KEY `name` (`name`);

--
-- A tábla indexei `user_courses`
--
ALTER TABLE `user_courses`
  ADD PRIMARY KEY (`id`),
  ADD KEY `CourseName` (`course_name`),
  ADD KEY `UserName` (`user_name`) USING BTREE;

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `answers`
--
ALTER TABLE `answers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=44;

--
-- AUTO_INCREMENT a táblához `courses`
--
ALTER TABLE `courses`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT a táblához `questions`
--
ALTER TABLE `questions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=38;

--
-- AUTO_INCREMENT a táblához `results`
--
ALTER TABLE `results`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT a táblához `tests`
--
ALTER TABLE `tests`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT a táblához `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT a táblához `user_courses`
--
ALTER TABLE `user_courses`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

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
-- Megkötések a táblához `results`
--
ALTER TABLE `results`
  ADD CONSTRAINT `TesztId` FOREIGN KEY (`testid`) REFERENCES `tests` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_Username` FOREIGN KEY (`username`) REFERENCES `users` (`name`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `tests`
--
ALTER TABLE `tests`
  ADD CONSTRAINT `Course` FOREIGN KEY (`CourseId`) REFERENCES `courses` (`id`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Megkötések a táblához `user_courses`
--
ALTER TABLE `user_courses`
  ADD CONSTRAINT `CourseName` FOREIGN KEY (`course_name`) REFERENCES `courses` (`name`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `UserName` FOREIGN KEY (`user_name`) REFERENCES `users` (`name`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
