-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2022. Feb 23. 14:32
-- Kiszolgáló verziója: 10.4.22-MariaDB
-- PHP verzió: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `slot_machine`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `datas`
--

CREATE TABLE `datas` (
  `id` int(10) NOT NULL,
  `name` varchar(100) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `quantity` smallint(10) NOT NULL,
  `value` smallint(10) NOT NULL,
  `picture` varchar(1000) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `logo` varchar(2000) COLLATE utf8mb4_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `datas`
--

INSERT INTO `datas` (`id`, `name`, `quantity`, `value`, `picture`, `logo`) VALUES
(1, 'Teszt1', 9, 2000, 'https://www.w3schools.com/images/w3schools_green.jpg', ''),
(2, 'Teszt 2', 14, 1800, 'https://www.w3schools.com/images/w3schools_green.jpg', ''),
(3, 'Teszt 3', 25, 1500, 'https://www.w3schools.com/images/w3schools_green.jpg', ''),
(4, 'Teszt 4', 43, 1000, 'https://www.w3schools.com/images/w3schools_green.jpg', ''),
(5, 'Teszt 5', 60, 750, 'https://www.w3schools.com/images/w3schools_green.jpg', ''),
(6, 'Teszt 6', 66, 700, 'https://www.w3schools.com/images/w3schools_green.jpg', ''),
(7, 'Teszt7', 82, 500, 'https://www.w3schools.com/images/w3schools_green.jpg', ''),
(8, 'Teszt8', 109, 300, 'https://www.w3schools.com/images/w3schools_green.jpg', '');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `datas`
--
ALTER TABLE `datas`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `datas`
--
ALTER TABLE `datas`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
