-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: localhost
-- Létrehozás ideje: 2024. Feb 25. 18:46
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
(73, 'Szombat', 1, 54),
(74, 'Igen', 1, 55),
(75, '3', 0, 56),
(76, 'Free', 1, 56),
(77, 'Three', 0, 56),
(94, 'A', 1, 60),
(95, 'B', 1, 60),
(96, 'C', 1, 60),
(97, 'D', 0, 60),
(98, 'Csütörtök', 1, 61),
(99, 'TeSzt', 1, 62),
(100, 'Teszt', 1, 62),
(101, 'Asd', 0, 62),
(102, 'AsD', 0, 62),
(103, 'ASD', 1, 63),
(104, '1', 0, 63),
(105, '2', 0, 63),
(106, '231', 1, 64),
(107, '321', 0, 64),
(108, '123', 0, 64),
(109, 'A', 1, 65),
(110, 'B', 0, 65),
(111, 'C', 0, 65);

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
(4, 'Filler', 1);

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
(54, 'Milyen nap van ma?', 'Rövid választ igénylő feladat', 10, 24),
(55, 'El tudtad indítani?', 'Rövid választ igénylő feladat', 10, 25),
(56, 'Free', 'Rádiógomb', 10, 26),
(60, 'ABC első három betűje', 'Jelölődoboz', 10, 24),
(61, 'Milyen nap van ma?', 'Rövid választ igénylő feladat', 10, 28),
(62, 'Teszt', 'Jelölődoboz', 10, 28),
(63, 'ASD', 'Rádiógomb', 10, 29),
(64, '231', 'Rádiógomb', 20, 29),
(65, 'A', 'Rádiógomb', 10, 24);

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
(96, 'ASD', 30, 24, '2024. 02. 23. 16:08:18'),
(97, 'ASD', 20, 28, '2024. 02. 23. 16:08:28'),
(98, 'ASD', 0, 28, '2024. 02. 23. 16:08:33'),
(102, 'ASD', 30, 29, '2024. 02. 23. 18:38:09');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `tests`
--

CREATE TABLE `tests` (
  `id` int(11) NOT NULL,
  `name` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `submit_limit` int(11) NOT NULL,
  `best_submitted_result_counts` tinyint(1) NOT NULL,
  `startDate` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `startTime` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `endDate` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `endTime` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `CourseId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `tests`
--

INSERT INTO `tests` (`id`, `name`, `submit_limit`, `best_submitted_result_counts`, `startDate`, `startTime`, `endDate`, `endTime`, `CourseId`) VALUES
(24, 'Mindig indítható', 100, 0, '2024. 02. 17.', '00:00', '9999. 01. 01.', '23:59', 3),
(25, 'Határidő lejárt', 100, 1, '2024. 02. 17.', '10:00', '2024. 02. 18.', '15:13', 2),
(26, 'Nem indítható', 1, 0, '2024. 02. 16.', '00:00', '2024. 02. 16.', '23:59', 2),
(28, 'Mai nap', 2, 1, '2024. 02. 22.', '18:00', '2024. 02. 23.', '18:13', 3),
(29, 'ASD', 2, 1, '2024. 02. 23.', '00:00', '2024. 02. 23.', '23:59', 2);

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
(2, 'ASD', '/rA2D/Mil+M=', 'asd@asd.com', 1);

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
(2, 'ASD', 'Adatbázisok'),
(16, 'ASD', 'Programozás I.');

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=112;

--
-- AUTO_INCREMENT a táblához `courses`
--
ALTER TABLE `courses`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT a táblához `questions`
--
ALTER TABLE `questions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=66;

--
-- AUTO_INCREMENT a táblához `results`
--
ALTER TABLE `results`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=103;

--
-- AUTO_INCREMENT a táblához `tests`
--
ALTER TABLE `tests`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;

--
-- AUTO_INCREMENT a táblához `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT a táblához `user_courses`
--
ALTER TABLE `user_courses`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

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
  ADD CONSTRAINT `TesztId` FOREIGN KEY (`testid`) REFERENCES `tests` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Username` FOREIGN KEY (`username`) REFERENCES `users` (`name`) ON DELETE NO ACTION ON UPDATE CASCADE;

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
