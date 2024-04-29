-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2022. Ápr 29. 14:48
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
-- Adatbázis: `travel_agency`
--
CREATE DATABASE IF NOT EXISTS `travel_agency` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci;
USE `travel_agency`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `journeys`
--

CREATE TABLE `journeys` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `vehicle` bigint(20) UNSIGNED NOT NULL,
  `country` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `description` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `departure` date NOT NULL,
  `capacity` int(11) DEFAULT 1,
  `pictureUrl` varchar(255) COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- A tábla adatainak kiíratása `journeys`
--

INSERT INTO `journeys` (`id`, `vehicle`, `country`, `description`, `departure`, `capacity`, `pictureUrl`) VALUES
(1, 3, 'Horvátország', 'A meseszép horvát tengerpart 177 kilométer hosszan nyúlik el, de ha a szigetek (1185, ebből 66 lakott) kerületét is figyelembe vesszük, összesen 5835 km, így igen nehéz kiválasztani, merre is induljunk el. A horvát Adria-part karsztos part, a világ legjob', '2022-04-27', 0, 'http://vizsga2022.cluster.jedlik.eu/picture/dubrovnik.jpg'),
(2, 2, 'Görögország', 'Görögország olyan gazdag kulturális örökséggel és természeti kincsekkel rendelkezik, hogy úgy érezzük, soha nem fogjuk tudni teljesen felfedezni, akárhányszor is látogatunk el ide. Végtére is, ez az egyik oka annak, hogy a világ top 20 turisztikai célpont', '2022-05-01', 54, 'http://vizsga2022.cluster.jedlik.eu/picture/greece.jpg'),
(3, 1, 'Egyesült Arab Emirátusok', 'Dubajnak gazdag története van, és az Egyesült Arab Emírségek kultúrája lenyűgöző, ha minden aranyat lekarcolsz. Nem számítottál erre? Haladjon a Dubai Creek szélén, a város eredeti szívében, ahol a Közel-Kelet szerte a kereskedők elcsalogatják áruikat. It', '2022-04-17', 114, 'http://vizsga2022.cluster.jedlik.eu/picture/dubai.jpg'),
(4, 2, 'Törökország', 'Az országot északról a Fekete-tenger, délről a Földközi-tenger, míg nyugatról az Égei-tenger határolja. Ezek együttesen 8000 kilométer hosszú tengerparti szakaszt kínálnak a természeti kincseknek, strandoknak, szálláshelyeknek, gasztronómiai létesítmények', '2022-04-20', 72, 'http://vizsga2022.cluster.jedlik.eu/picture/istanbul.jpg'),
(5, 1, 'Maldív szigetek', 'Képeslapra illő tengerpari villák, türkizkék tenger, vakítóan fehér homokos strandok, csodás naplementék írják le ezt a paradicsomi helyet. A Maldív-szigetek nagyon népszerű célpont a nászutasok körében, de a kalandot keresők is szívesen felfedezik a teng', '2022-04-13', 164, 'http://vizsga2022.cluster.jedlik.eu/picture/maldives.jpg'),
(6, 1, 'Egyiptom', 'Kaland a sivatag mélyén. Sivatagi szafarik, quadozás a Keleti Sivatagban, túrázás és lovaglás a Sinai-hegységben vagy táborozás a Fehér Sivatagban, mind-mind életre szóló élménnyel gazdagítanak. Fedezd fel a váratlant, és merülj egyiptomi tengereibe, mely', '2022-04-25', 138, 'http://vizsga2022.cluster.jedlik.eu/picture/egypt.jpg'),
(7, 4, 'Olaszország', 'Velence meghatározó szimbólumai, melyek ismertek világszerte: a Szent Márk tér és harangtornya a Campanile, valamint székesegyháza a Szent Márk-bazilika, a mellette található Dózsepalota, a Rialto-, és a Sóhajok hídja, templomai- a Santa Maria Gloriosa de', '2022-04-18', 86, 'http://vizsga2022.cluster.jedlik.eu/picture/venice.jpg');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `vehicles`
--

CREATE TABLE `vehicles` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `type` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- A tábla adatainak kiíratása `vehicles`
--

INSERT INTO `vehicles` (`id`, `type`) VALUES
(1, 'repülőgép'),
(2, 'busz'),
(3, 'autó'),
(4, 'vonat'),
(5, 'hajó ');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `journeys`
--
ALTER TABLE `journeys`
  ADD PRIMARY KEY (`id`),
  ADD KEY `journeys_vehicle_foreign` (`vehicle`);

--
-- A tábla indexei `vehicles`
--
ALTER TABLE `vehicles`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `journeys`
--
ALTER TABLE `journeys`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT a táblához `vehicles`
--
ALTER TABLE `vehicles`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `journeys`
--
ALTER TABLE `journeys`
  ADD CONSTRAINT `journeys_vehicle_foreign` FOREIGN KEY (`vehicle`) REFERENCES `vehicles` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
