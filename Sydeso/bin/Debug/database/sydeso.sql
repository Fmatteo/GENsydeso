-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 16, 2019 at 03:41 PM
-- Server version: 10.1.37-MariaDB
-- PHP Version: 7.3.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sydeso`
--
CREATE DATABASE IF NOT EXISTS `sydeso` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `sydeso`;

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_accounts_privileges`
--

CREATE TABLE `restaurant_accounts_privileges` (
  `ID` int(11) NOT NULL,
  `Account_ID` int(11) NOT NULL,
  `Dashboard` tinyint(4) NOT NULL,
  `Products` tinyint(4) NOT NULL,
  `Order_POS` tinyint(4) NOT NULL,
  `Sales_Expenses` tinyint(4) NOT NULL,
  `Tables` tinyint(4) NOT NULL,
  `Employees` tinyint(4) NOT NULL,
  `Customers` tinyint(4) NOT NULL,
  `Accounts` tinyint(4) NOT NULL,
  `History` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `restaurant_accounts_privileges`
--

INSERT INTO `restaurant_accounts_privileges` (`ID`, `Account_ID`, `Dashboard`, `Products`, `Order_POS`, `Sales_Expenses`, `Tables`, `Employees`, `Customers`, `Accounts`, `History`) VALUES
(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_category`
--

CREATE TABLE `restaurant_category` (
  `ID` int(11) NOT NULL,
  `Name` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `restaurant_category`
--

INSERT INTO `restaurant_category` (`ID`, `Name`) VALUES
(1, 'Beverages'),
(2, 'Dish');

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_customers`
--

CREATE TABLE `restaurant_customers` (
  `ID` int(11) NOT NULL,
  `Name` text NOT NULL,
  `Birthdate` date NOT NULL,
  `Phone_Number` text NOT NULL,
  `Email_Address` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `restaurant_customers`
--

INSERT INTO `restaurant_customers` (`ID`, `Name`, `Birthdate`, `Phone_Number`, `Email_Address`) VALUES
(1, 'John Armon Manaloto', '1999-06-27', '09090909', 'johnarmon@gmail.com');

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_customers_record`
--

CREATE TABLE `restaurant_customers_record` (
  `ID` int(11) NOT NULL,
  `Customer_ID` int(11) NOT NULL,
  `Sales_ID` int(11) NOT NULL,
  `Amount` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `restaurant_customers_record`
--

INSERT INTO `restaurant_customers_record` (`ID`, `Customer_ID`, `Sales_ID`, `Amount`) VALUES
(2, 1, 14, 50.4);

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_employee`
--

CREATE TABLE `restaurant_employee` (
  `ID` int(11) NOT NULL,
  `Firstname` text NOT NULL,
  `Lastname` text NOT NULL,
  `Username` text NOT NULL,
  `Password` text NOT NULL,
  `Image` blob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `restaurant_employee`
--

INSERT INTO `restaurant_employee` (`ID`, `Firstname`, `Lastname`, `Username`, `Password`, `Image`) VALUES
(1, 'Jhumar', 'Rosales', '@jhumar', '240475D4DDBC65C77AB469240D388F07BB7E861B840F17707BD68959A8CAC1D80CBBD8ECF4C8A40E3E6EAF1F43CCF545E0A7237C6DCA0CB8678E34DA389C643E', '');

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_employee_time_in_out`
--

CREATE TABLE `restaurant_employee_time_in_out` (
  `ID` int(11) NOT NULL,
  `Employee_ID` int(11) NOT NULL,
  `Timein` text NOT NULL,
  `Timeout` text NOT NULL,
  `Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `restaurant_employee_time_in_out`
--

INSERT INTO `restaurant_employee_time_in_out` (`ID`, `Employee_ID`, `Timein`, `Timeout`, `Date`) VALUES
(2, 1, '09:51:31 PM', '', '2019-01-14');

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_expenses`
--

CREATE TABLE `restaurant_expenses` (
  `ID` int(11) NOT NULL,
  `Name` text NOT NULL,
  `Description` text NOT NULL,
  `Amount` double NOT NULL,
  `Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_logs`
--

CREATE TABLE `restaurant_logs` (
  `ID` int(11) NOT NULL,
  `Detail` text NOT NULL,
  `Date` date NOT NULL,
  `Time` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_order`
--

CREATE TABLE `restaurant_order` (
  `ID` int(11) NOT NULL,
  `Table_ID` int(11) NOT NULL,
  `Customer_ID` int(11) NOT NULL,
  `Customer_Name` text NOT NULL,
  `Account_ID` int(11) NOT NULL,
  `Discount` double NOT NULL,
  `Discount_Perc` double NOT NULL,
  `Amount` double NOT NULL,
  `Vat` double NOT NULL,
  `Vat_Perc` double NOT NULL,
  `Vat_Exempt` double NOT NULL,
  `Order_Type` text NOT NULL,
  `Date` date NOT NULL,
  `Time` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `restaurant_order`
--

INSERT INTO `restaurant_order` (`ID`, `Table_ID`, `Customer_ID`, `Customer_Name`, `Account_ID`, `Discount`, `Discount_Perc`, `Amount`, `Vat`, `Vat_Perc`, `Vat_Exempt`, `Order_Type`, `Date`, `Time`) VALUES
(1, 0, 0, 'WALK-IN', 1, 0, 0, 341.6, 36.6, 12, 305, 'DINE IN', '2019-01-16', '01:15:01 PM'),
(2, 0, 0, 'WALK-IN', 1, 0, 0, 302.4, 32.4, 12, 270, 'DINE IN', '2019-01-16', '09:06:31 AM'),
(4, 2, 0, 'WALK-IN', 1, 0, 0, 341.6, 36.6, 12, 305, 'DINE IN', '2019-01-16', '11:13:24 AM');

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_order_details`
--

CREATE TABLE `restaurant_order_details` (
  `ID` int(11) NOT NULL,
  `Order_ID` int(11) NOT NULL,
  `Prod_ID` int(11) NOT NULL,
  `Qty` int(11) NOT NULL,
  `Price` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `restaurant_order_details`
--

INSERT INTO `restaurant_order_details` (`ID`, `Order_ID`, `Prod_ID`, `Qty`, `Price`) VALUES
(1, 4, 4, 1, 35),
(2, 4, 7, 1, 10),
(3, 4, 1, 1, 35),
(4, 4, 8, 1, 40),
(5, 4, 5, 1, 150),
(6, 4, 3, 1, 35);

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_products`
--

CREATE TABLE `restaurant_products` (
  `ID` int(11) NOT NULL,
  `Name` text NOT NULL,
  `Qty` int(11) DEFAULT NULL,
  `Reorder` int(11) DEFAULT NULL,
  `Price` double NOT NULL,
  `Category` text NOT NULL,
  `Image` blob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `restaurant_products`
--

INSERT INTO `restaurant_products` (`ID`, `Name`, `Qty`, `Reorder`, `Price`, `Category`, `Image`) VALUES
(1, 'Coke', 185, 20, 35, 'Beverages', ''),
(2, 'Sprite', 196, 20, 35, 'Beverages', ''),
(3, 'Royal', 191, 20, 35, 'Beverages', ''),
(4, '7-UP', 183, 20, 35, 'Beverages', ''),
(5, 'Emperador Light', 188, 20, 150, 'Beverages', ''),
(6, 'Sarsyadong Tilapia', NULL, NULL, 45, 'Dish', ''),
(7, 'Kaning Bahaw', NULL, NULL, 10, 'Dish', ''),
(8, 'Menudo', NULL, NULL, 40, 'Dish', '');

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_sales`
--

CREATE TABLE `restaurant_sales` (
  `ID` int(11) NOT NULL,
  `Customer_ID` int(11) NOT NULL,
  `Customer_Name` text NOT NULL,
  `Account_ID` int(11) NOT NULL,
  `Cash_Tendered` double NOT NULL,
  `Discount` double NOT NULL,
  `Discount_Perc` double NOT NULL,
  `Amount` double NOT NULL,
  `Cash_Change` double NOT NULL,
  `Vat` double NOT NULL,
  `Vat_Perc` double NOT NULL,
  `Vat_Exempt` double NOT NULL,
  `Order_Type` text NOT NULL,
  `Date` date NOT NULL,
  `Time` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `restaurant_sales`
--

INSERT INTO `restaurant_sales` (`ID`, `Customer_ID`, `Customer_Name`, `Account_ID`, `Cash_Tendered`, `Discount`, `Discount_Perc`, `Amount`, `Cash_Change`, `Vat`, `Vat_Perc`, `Vat_Exempt`, `Order_Type`, `Date`, `Time`) VALUES
(1, 0, 'WALK-IN', 1, 100, 0, 0, 72.8, 27.2, 0, 0, 0, '', '2019-01-15', '11:50:16 PM'),
(2, 0, 'WALK-IN', 1, 150, 0, 0, 112, 38, 0, 0, 0, '', '2019-01-15', '11:58:18 PM'),
(3, 0, 'WALK-IN', 1, 150, 0, 0, 112, 38, 0, 0, 0, '', '2019-01-15', '11:59:38 PM'),
(4, 0, 'WALK-IN', 1, 500, 0, 0, 414.4, 85.6, 0, 0, 0, '', '2019-01-15', '11:59:57 PM'),
(5, 0, 'WALK-IN', 1, 100, 0, 0, 72.8, 27.2, 0, 0, 0, '', '2019-01-16', '12:12:39 AM'),
(6, 1, 'John Armon Manaloto', 1, 500, 0, 0, 431.2, 68.8, 0, 0, 0, '', '2019-01-16', '02:17:06 AM'),
(7, 0, 'WALK-IN', 1, 500, 0, 0, 431.2, 68.8, 0, 0, 0, '', '2019-01-16', '02:20:53 AM'),
(8, 0, 'WALK-IN', 1, 1000, 0, 0, 431.2, 568.8, 0, 0, 0, '', '2019-01-16', '02:24:00 AM'),
(9, 0, 'WALK-IN', 1, 500, 61, 20, 280.6, 219.4, 36.6, 12, 305, '', '2019-01-16', '11:04:52 AM'),
(10, 0, 'WALK-IN', 1, 500, 0, 0, 431.2, 68.8, 46.2, 12, 385, '', '2019-01-16', '11:09:23 AM'),
(11, 0, 'WALK-IN', 1, 500, 0, 0, 341.6, 158.4, 36.6, 12, 305, 'DINE IN', '2019-01-16', '09:07:25 AM'),
(12, 0, 'WALK-IN', 1, 200, 0, 0, 134.4, 65.6, 14.4, 12, 120, 'DINE IN', '2019-01-16', '11:27:36 AM'),
(13, 0, 'WALK-IN', 1, 200, 0, 0, 134.4, 65.6, 14.4, 12, 120, 'DINE IN', '2019-01-16', '11:32:24 AM'),
(14, 1, 'John Armon Manaloto', 1, 60, 0, 0, 50.4, 9.6, 5.4, 12, 45, 'DINE IN', '2019-01-16', '11:33:29 AM'),
(15, 0, 'WALK-IN', 1, 200, 0, 0, 134.4, 65.6, 14.4, 12, 120, 'DINE IN', '2019-01-16', '11:39:31 AM');

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_sales_details`
--

CREATE TABLE `restaurant_sales_details` (
  `ID` int(11) NOT NULL,
  `Sales_ID` int(11) NOT NULL,
  `Prod_ID` int(11) NOT NULL,
  `Qty` int(11) NOT NULL,
  `Price` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `restaurant_sales_details`
--

INSERT INTO `restaurant_sales_details` (`ID`, `Sales_ID`, `Prod_ID`, `Qty`, `Price`) VALUES
(1, 1, 4, 1, 35),
(2, 1, 7, 3, 10),
(3, 2, 4, 2, 35),
(4, 3, 4, 2, 35),
(5, 3, 7, 3, 10),
(6, 4, 1, 2, 35),
(7, 4, 5, 2, 150),
(8, 5, 4, 1, 35),
(9, 5, 7, 3, 10),
(10, 6, 4, 1, 35),
(11, 6, 7, 1, 10),
(12, 6, 1, 1, 35),
(13, 6, 8, 1, 40),
(14, 6, 5, 1, 150),
(15, 6, 3, 1, 35),
(16, 6, 6, 1, 45),
(17, 6, 2, 1, 35),
(18, 7, 4, 1, 35),
(19, 7, 7, 1, 10),
(20, 7, 1, 1, 35),
(21, 7, 8, 1, 40),
(22, 7, 5, 1, 150),
(23, 7, 3, 1, 35),
(24, 7, 6, 1, 45),
(25, 7, 2, 1, 35),
(26, 8, 4, 1, 35),
(27, 8, 7, 1, 10),
(28, 8, 1, 1, 35),
(29, 8, 8, 1, 40),
(30, 8, 5, 1, 150),
(31, 8, 3, 1, 35),
(32, 8, 6, 1, 45),
(33, 8, 2, 1, 35),
(34, 9, 4, 1, 35),
(35, 9, 7, 1, 10),
(36, 9, 1, 1, 35),
(37, 9, 8, 1, 40),
(38, 9, 5, 1, 150),
(39, 9, 3, 1, 35),
(40, 10, 4, 1, 35),
(41, 10, 7, 1, 10),
(42, 10, 1, 1, 35),
(43, 10, 8, 1, 40),
(44, 10, 5, 1, 150),
(45, 10, 3, 1, 35),
(46, 10, 2, 1, 35),
(47, 10, 6, 1, 45),
(48, 1, 4, 1, 35),
(49, 1, 7, 1, 10),
(50, 1, 1, 1, 35),
(51, 1, 8, 1, 40),
(52, 1, 5, 1, 150),
(53, 1, 3, 1, 35),
(54, 2, 4, 1, 35),
(55, 2, 7, 1, 10),
(56, 2, 1, 1, 35),
(57, 2, 8, 1, 40),
(58, 2, 5, 1, 150),
(59, 11, 4, 1, 35),
(60, 11, 7, 1, 10),
(61, 11, 1, 1, 35),
(62, 11, 8, 1, 40),
(63, 11, 5, 1, 150),
(64, 11, 3, 1, 35),
(65, 3, 4, 1, 35),
(66, 3, 7, 1, 10),
(67, 3, 1, 1, 35),
(68, 3, 8, 1, 40),
(69, 3, 5, 1, 150),
(70, 3, 3, 1, 35),
(71, 12, 4, 1, 35),
(72, 12, 7, 1, 10),
(73, 12, 1, 1, 35),
(74, 12, 8, 1, 40),
(75, 13, 4, 1, 35),
(76, 13, 7, 1, 10),
(77, 13, 1, 1, 35),
(78, 13, 8, 1, 40),
(79, 14, 4, 1, 35),
(80, 14, 7, 1, 10),
(81, 15, 4, 1, 35),
(82, 15, 7, 1, 10),
(83, 15, 1, 1, 35),
(84, 15, 8, 1, 40);

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_stock_out`
--

CREATE TABLE `restaurant_stock_out` (
  `ID` int(11) NOT NULL,
  `Name` text NOT NULL,
  `Qty` int(11) NOT NULL,
  `Price` double NOT NULL,
  `Total` double NOT NULL,
  `Remark` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_table`
--

CREATE TABLE `restaurant_table` (
  `ID` int(11) NOT NULL,
  `Name` text NOT NULL,
  `Description` text NOT NULL,
  `Status` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `restaurant_table`
--

INSERT INTO `restaurant_table` (`ID`, `Name`, `Description`, `Status`) VALUES
(1, 'Table 1', '4 seats', 'RESERVED'),
(2, 'Table 2', '10 seats', 'OCCUPIED');

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_table_booking`
--

CREATE TABLE `restaurant_table_booking` (
  `ID` int(11) NOT NULL,
  `Table_ID` int(11) NOT NULL,
  `Customer_ID` int(11) NOT NULL,
  `Customer_Name` text NOT NULL,
  `Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `restaurant_table_booking`
--

INSERT INTO `restaurant_table_booking` (`ID`, `Table_ID`, `Customer_ID`, `Customer_Name`, `Date`) VALUES
(9, 1, 1, 'John Armon Manaloto', '2019-01-14');

-- --------------------------------------------------------

--
-- Table structure for table `system_accounts`
--

CREATE TABLE `system_accounts` (
  `ID` int(11) NOT NULL,
  `Firstname` text NOT NULL,
  `Lastname` text NOT NULL,
  `Username` text NOT NULL,
  `Password` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `system_accounts`
--

INSERT INTO `system_accounts` (`ID`, `Firstname`, `Lastname`, `Username`, `Password`) VALUES
(1, 'Joshua Ming', 'Ricohermoso', 'admin', 'B6E57406C7E4E8B5C58D5901A87AFB7CE461D77F0A88019EBA88AB92885DD739544A531DE7B38A36FB94ADB7E8007604759D39BBF6DBA22F1677B65A76EF04EE');

-- --------------------------------------------------------

--
-- Table structure for table `system_config`
--

CREATE TABLE `system_config` (
  `ID` int(11) NOT NULL,
  `Company_Name` text NOT NULL,
  `Company_Address` text NOT NULL,
  `Company_Phone` text NOT NULL,
  `Business_Type` text NOT NULL,
  `Company_Logo` blob,
  `Vat` double NOT NULL,
  `TIN` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `system_config`
--

INSERT INTO `system_config` (`ID`, `Company_Name`, `Company_Address`, `Company_Phone`, `Business_Type`, `Company_Logo`, `Vat`, `TIN`) VALUES
(1, 'System Development Solution', 'Company Address', '1234', 'Restaurant', 0x89504e470d0a1a0a0000000d49484452000001f4000001f40806000000cbd6df8a000000017352474200aece1ce90000000467414d410000b18f0bfc6105000000097048597300000ec300000ec301c76fa8640000001974455874536f6674776172650041646f626520496d616765526561647971c9653c0000434549444154785eeddd09bcbdd77ceff14b48243113631a73a5e6484da5a870830e284589a1861a6b8e99ab6645b56aa8e1e61a4ae3c618d59a87724d575122940822e6791e23f7fb959cebe4e47bce59cfb4f7b3d6f3f9bd5eefd78b5ffefbb7f7d9fb596bedfd3ceb59ebbf9d7cf2c90000a07231090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea129300b67521b9b93c565e2d1f942fcb8f6573fc50be2ac7c85be405f260f163af28fb4aaadf02ff6dfe1bfdb73e44fcb7fb3df07be1f7c4efcde6f07be7f7d0efa5df53bfb77eacdfeb541f401093004ee36079aa7c5cc68ccfc89172b85c4fce21e9f9e7ccafd9afdd7f83ff16ff4d6386df73bff7fe0cd2f30338554c0238796ff94bf998ac328e15ffa2bd935c5ace20e9f5ad835f8b5f935f9b5fa35feb2ac39f853f137f36e9f5018b1693c082ed29f795afc81ce29b72b4f8d4f535652f49af7b0a67113fa79fdbafc1af650ee1cfc69f913fabf4ba81458a4960a10e95e365cef15379bf3c4b6e2f9795334afa7bba700dd7724dd7f673f8b9e61cfeacfc99a5bf07589c980416e6bcf252a9353cc9ec2372943c5eee20379083e4a25b38e7ffe67fe37febc7f8b15b27aad514feecfc19a6cf16588c980416c413ba3cf39aa83bfc19fab34c9f31b00831092c804f313f524e12a28df067e9cf748c4b104075621268dc3ef22a21da0c7fb6fe8cd3670f342b268186ed27ef15a2edf067eccf3a1d034093621268d4fe32f6c2271bf113f9ba7cfe54bec5eb97429c36fc9ef8bdd9789ffc9ef9bd9b22fc59fb334fc702d09c98041a74801c2763c477e4157237b9aa9c4bd2739a7f255e5d366695bf52c67a1d730eff8dfe5b3766ddfb3dd8e917b3df43bf977e4ffddefa3d1e23fc3afcd9a7e7049a12934063dca19f2843c3a7716f235e70253d4f17e7961bca23e45fe4db526bf8b5fb6ff0dfe2bfc97f5bfa9bbbf07b7c5b19e3f2883f7b0675342f26818678838fa1bf88bde4a807aa547f2c5e56f532e2a54d5f2c535d1a1823fcdafc1afd5afd9aa75e9ed6effdd025787d0cb0d90b9a16934023ce23433654f14a690f933349aa3fb5f3c94de529f21ef991ac3afc9c7e6ebf869b885f537aad53f367e0cf62c8ea753e167c4ca4fa40f5621268806f5b1a72bad6bf422f2fa9f6baec21078a4f453f5dde2e5f92b1c2b55cd3b5fd1c7e2e3f677a2deb72051972f6c2c704b7b4a149310954ce83d01ba46fbc4ece26a9f61c79f7317ff9f02fe8078ab71b7d89f8ef78a7781033ff6fe7fcdffc6ffc6ffd183fb6a61dccfcd9f8efe81b3e36e6f64505182c2681ca3d4ffac63385ce7efefc19f9b3ea1b3e46525da05a310954ec70e91bbe469b6a62befc99f50d1f2ba92650a598042a750be91bde5f3bd5c4fcf9b3eb1b3e66524da03a310954e86af263e913f7935413f5f067d8277cccf8d8493581aac42450998b899710ed130f975413f5f167d9277cecf8184a35816ac4245011df57fc29e913cf905413f5f267da277c0c8db1c21db036310954c2cb837ad1933e71a44cbdc21956cf9fa93fdb3ee163698c657d81b58849a002eeb88f923ee1fbb1f7945417f5f367ebcfb84ff898e28b1eaa149340059e267dc2a75677da1d0d6df067dcf7528c8fad541398b5980466ee41d2273cf9e9e2926aa23dfeacfb4e96f431966a02b31593c08cdd45fa846f4fba86a49a68973ff3beb733fa584b3581598a4960a6bc61c849d227584064b9fa2e38e463cdc75caa09cc4e4c0233346430e7f429fa5ea661504735621298192fedf92be913cf925413cbe363a14ff8d8636960cc5e4c0233e11db59e227dc35b6cb2731a36f85818b2edaa8f458e27cc564c0233e055bbde287de383b28fa4da582e1f133e36fa868f495694c32cc524b066d79313a46f1c27e797541bf0b1e163a46ff8d8f4319a6a036b1393c09a783190e7c89038512e22a93eb0c1c7888f9521e16395458a301b3109acd899e46ef20d19127efcef487a0e602b1f2b631c733e767d0ca7e7005626268115f19ad9b796be4b746e0e77ac9797f43cc0767ccc0c1dd41d3e867d2cb30e3cd626268189f9d7cc61f2091923be260ce6e8cbc78e8fa131c2c7b48f6d7eb163e5621298c8d9e5fe72bc8c159f11d667c7503e867c2c8d153ec67dacfb984fcf078c2e2681915d42fe5e7e2063866f3fda4fd273025df9581a724b5b0a1ff33ef6dd06d27302a389496004be9678881c2d7d5779db295e2a7b4b7a6ea02f1f533eb6c60eb701b705b709aeb3631231090c7056b9a71c2b53c42fe43e929e1b188b8f311f6b5384db86db88db4a7a6ea09798047ab894f8d4e2f764aa38460e96f4fcc0d87cacf9989b2adc56dc66dc76d2f3039dc424d0c1b565aad3ea1be15f4a4f90bd24bd06602a3ee67cec4df56bddb1713ade6d29bd06a0484c02bbf035c09bcad8138852bc59582c06ebe663d0c7e2d4e136e5b6c57576741693c036dcc9dc4aa63c0db911bece781349af0358171f9353cd0fd91c6e636e6b0cec2816934070a87c44a60e6f9a710739a3a4d701ac9b8f4d1fa3433678290db739b7bdf43a80d3884960134fd879934c1dfed5c30a5ba8c9c68a87abf8c5ee36c8e439ec282601398b7832d0cf64ca78abfc91706a11b5f2b1eb63d8c7f294e1b6e836e9b6995e07162e26b17807c994bf3a7e2ccf97cb4a7a7ea0563ea67d6cfb189f2adc36dd46d3f363c162128be55f1a0f959fcb147182b8fe79243d3fd00a1fe33ed67dcc4f116ea3aecf992dfc7f318945f2aa55af9529e21d7273e1fa3896c6c7bc8f7db78129c26d9615e7f06b3189c5b9b08c3d83fd47e2538f6c6b0a9cc26dc16dc26d63cc70db751b4ecf890589492c8ab78d1cf3f69b2fcbc3e5dc929e0f583ab70db711b795b1c26d986d84172e26b118fbcb67658c70877217d953d27301382db715b799b1be50bb2dbb4da7e7c202c42416e11c32c64cf6cfc91d85ebe3403f6e3b6e436e4b43c36dda6d3b3d0f1a179368de1e32745dea6f8bb798e41739300eb725b729b7ad21e1b6ed369e9e030d8b4934ef7132248e90fd24d506308cdb96dbd890701b4fb5d1b09844d3ae2e27499f3851ae2fa92e8071b9adb9cdf509b771b7f554178d8a4934ebccd277a7b4d7cb3925d505300db739b7bd3ee1b6ee369feaa241318966dd57fac41385ddcf80f570db731bec136ef3a9261a149368d2bef215e91a5e5e32d503b05a6e8b5dc36dde6d3fd5436362124dead3193c4a522d00ebe136d935f852be103189e6ec25df902ef17249b500ac97db669770db771f906aa1213189e6dc4abac4f1b28fa45a00d6cb6dd36db44bb80f48b5d090984473de2a5de210497500cc83db6897701f90eaa0213189a61c20bf92d278a3a43a00e6e5dfa434dc07b82f4875d088984453ee2d5d82c528803ab8ad7609f705a90e1a1193684a9735dbdf27a9068079729b2d0df705a9061a11936886ef3ffd999486b7724c7500cc93db6c69b82fe09ef486c5249a713d298d5f084bbb0275719b75db2d0df709a90e1a10936846974528de21a906807973db2d0d168b6a584ca2195d66c11e2ea906807973db2d0df709a9061a1093684697b5dbaf21a906807973db2d0df709a9061a109368c279a4347e2a7b4aaa0360dedc76dd864bc37d43aa83cac5249a705d298d0f49aa01a00e6ec3a5e1be21d540e562124db8ab94c611926a00a883db7069b86f483550b99844139e22a5717f493580553aab5c5e6e24b7174ff6f271fc77f24279d1a99e2b4f967bcaa1b29fa47a4be2365c1a7e4f530d542e26d184a3a4346e26a90630850bc80de401e25f961f90aedbfb6e8d4fcadf88bf10a4e76c9ddb7069b86f483550b9984413dc4996c69525d500863a8b5c471e22af942fcad4f136f95d49afa7556ec3a5e1be21d540e562124de872cb1ab35e3116cfb8f66a648f95774a97d9d7638677177bba2ce5ee8d2e77b570eb5aa36212d53bb3946e99fa434935805217937bc9d1e2e3694ef176d947d2eb6e4de97befbec17d44aa818ac524aa7721298d6324d500b6730639581e271f97b987f7f8df43d2dfd212b7e5d2b8b0a41aa8584ca27aee6c4bc39d5daa016c7515f169ec13a4b67884a4bfa9256ecba5e13e22d540c56212d5bba194c64b25d500ec32f204f9acd41c3f96d67f95ba2d9786fb885403158b4954ef0e521abed527d5c0729d4b7c8ff707a5a5f02582f4f7b6c26db934dc47a41aa8584ca27a0f96d2f0bf4d35b02cbe2e7e88bc427e262dc67192fef656d0ee172e2651bda74a69dc4e520d2cc379e581e2c16ed5f135f15ede5e05eee1e25f8d3e15ecb5c6edc672777992bc5ac6b887bde5d3ee6ecba5e13e22d540c56212d57b99948697ce4c35d0b683e4c5b2aa5fe31ebc5f271eb8af2fe793f4ba76e355e6ee2c9e00f64be91abe473ed56d81db7269b88f483550b19844f5de2aa571254935d09e33c92de4dd32757c53bc32dc3de44049af6728dffffe72e9122d9f91725b2e0df711a9062a1693a89ed7b52e8df34baa81767861957bcbe764caf88478d3946bca2aeffb3e4c7e2125714749355ae0b65c1aee23520d542c2651bd6f4b49f894e51925d540fd7c7dfc31e25fcb53851796f169f44b4a7a0dab721f29893f94f4f816b82d975e86701f916aa0623189aa79338cd2604de7365d50bc45e654cbb07e419e2873dad9cc8359c919882b4a7a7c2bbaece1e0be22d540a5621255f375c5d2f890a41aa8930772ef1dfe13193b7c4afb35e299e7733dabf302d9293c01702f498f6d85db7469b8af483550a99844d5ae2da5f1af926aa02e3eb5fe0c996220f7ad623ea5eed9e5e9b9e7c40bc7ec14ef93f4b896b84d9786fb8a5403958a4954cd937e4ae379926aa00ee794bf96294eadfb97de9f8b67c6a7e79ea3e7cb4ef148498f6b89db7469b43c417091621255f324a8d27898a41a98379f367e907c4bc60c6fabf95aa9f597db4765a7f0baf4e9712d719b2e0df715a9062a1593a8da91521ab7925403f3e4e5596f2d63df7ee681dcc74dcd03de2564a7f0bdf7e971ad719b2e0d7fe6a9062a1593a8dac7a4347e57520dcc8fefedfe808c192d0ce41b9e253bc52d253dae356ed3a5e1be22d540a56212d5da537e2e25e1cefcac92ea603e2e24ff2463c7aba49553d017919d26041e2b4b596fc16dda6dbb24dc57b8cf487550a19844b5ae2aa571bca41a980777b40f911fc898e15ff9d792f49cb5f297939d6229bfce37b86d9786fb8c5403158a4954ebafa434bc5146aa81f5f336a69f9231c3d7dd7dfdddd7e1d373d6ca7fd34ef12e69ed6fde8ddb7669b8cf483550a19844b5bcc56469f8dee25403ebb39fbc44c68cef8b67c4b7b8a08a4fb57f47b60b2f867339498f6d99db7669b8cf483550a1984495ce2ceebc4bc35b58a63a583dff82bc938c7d1bda51d2eafedf7bcb7fc84eb184fbce13b7edd2709fe1be23d54165621255ead2884f92b349aa83d53a40de2c63c667a5e57deefd0568b7db33bd2a5c4d8be28cc96ddb6dbc34f872df889844955e24a5f11e4935b03a1e94ee2a5dceaaec165eabdccb9fb6bee9c6d364a7f0990e9f8e4f8f5d0ab7f1d270df916aa0323189eaf856952eb3a11f2da90e56e3b7e46d3266f817e981929eaf250f959dc2bf4c6f20e9b14be2365e1aee3bb885b5013189eadc5bba040bcaac8f67657f57c68a1fcbfd6409f759df53760bef8b9e1ebb345d169871b80f49755091984455dc917f5a4ae33859da6d3c73700e197b8198f7cba5243d5f6bee25bbc5df4a7aec12b98dbbad9786fb90a52cbed3ac98445576bb0f776bfc0f4975309d6bc81764acf0ed583ea5ba94495fbb9d6677bc4c18904ecb6dbd4bb82f49755089984435dc817959cb2e713149b5303eff4af23de01e80c70acf60bf8aa4e76b8ddfbf27cb6ef1cfb287a41a4be6b6de2596b4446e936212d5384cbac41b24d5c1f8ce2daf9731c3bf429772bba197be3d42768b570aeb916fcf6dbe4bb84f49755081984415bcb046d7d3b8ccfe5d8d8364cc53ec3f923b487aae1679bec15b64b7f080cf2ff39db9cd77091fb7ee5b522dcc5c4ca20adeb8a34b7c5c980c37bddb88679e8f155ed3fdb2929eab45179592cb484f178ee7ddf93d72dbef12ee5b522dcc5c4c62f62e285d77e162c2cbb4fc4bd183cc98e1d5d096747ff0d5e56bb253f83e73cf784f8f47d675e2acfb16f731a916662c26317b5d6f7f62b2cbb47c8af84d3256fc521e28e9b95a7567f14a773b8557d5bbb1a4c7637b7d26cfba8f49b53063318959f35ed65de3cf24d5c2705e62f418192bbe217f20e9b95ae4096dcf91dde29372194935b03bf7015da3b57df39b1793982d9fd6fda874092f3ec2b5c6691c2c5f95b1c2bb872d690df20b48c99ae3af1236131ac67d80fb822ee1be864987158949cc56c96a595b836fd9d3b8918c39f9eda5b2a4d9c5d795ddbe0cf914bc97b5e50be938fa9cdd63be42456212b3743ef98e7409ef879d6a61983f979fcb18e1495ef797f43c2df2f55cef53bedbf69e3ec57e254935d09ffb842ee13ec77d4faa85998949cc52c9221b9bc3bf1ebdab57aa85febc89c5af648cf89ef8977e7a9e16796028d9fbfdd9b2afa41a18c67d42d7334bee7b522dcc4c4c6276bc1678d77884a45ae8af644df1d2f89c2ce9fef24365b753ec7e4f963421705ddc37740df741a916662426312bde80e33fa54b7c46f692540ffd8c39987b22d87e929ea7353e0e9f263b85cf78f857397b72af863f13f7115dc27dd0523603aa564c6256bcbf73d7e05edd718d3998bf4496b2f6f8e564b7bb32fcdfbda04c7a3ca6e33ea26bb0d7fcccc52466c3bfe2be2b5de26849b5d0cf8365ac7894a4e7688d27be3d407e2adb855723f364407ef5ad8ffb8a2ee1be68296796aa1493988de74a97f889b03dea78bc7ad918e1ed53ff42d273b4e652f26ed92e7c7add93ac7c0f7a7a3c56c77d85fb8c2ee13e29d5c20cc42466e1f2e22540bbc4a325d542773793dd6ead2a09ff12bda1a4e768cd2565a719d4ff2e5796f458ac87fb8c2ee13ec97d53aa85358b49cc42d7bdb43dc9e52c926aa19b6bcb4ea78b4bc3b3ba9734809d57d22d7d5e47fca6921e83f5ea3341ce7d53aa85358b49acddef4bd758caafc0a9f957e6b764681c274bbcfcb179e112df86e67ddcd91868dedc77740df751a916d62826b17625eb5b6f8ed748aa836ece29de7f7c6878ffe9a54e1ef22fbec3c4fbc22f65367f0bdc877409f751a90ed62826b1565ee3ba4b78bdeb8b4baa8572de84a26415b3dde203e22f06e93980b9721fb2dbf6b55bc37d55aa85358949acd53ba44b3c45521d74f364191a6f17760543adbab601f755a90ed62426b13657952ef14d39bba45a28e7f5d48786efe9dd47527da006ee4bdca77409f759a916d62026b136de42b34b2c6997aea9ec2f5d3bb1ade1c19cebc56881fb942ee13e2bd5c11ac424d6c23b5175b9867582b05efb309e7dfd4e19120ce66889fb14f72da5e13e8bed55672226b1165d9718655de5e1ee2743e2adc2608ed674dd3fc27d57aa83158b49acc587a534bc60c9de92eaa08c9728edba2ff4e6f00438ae99a345ee5b76dbea7673b8ef4a75b0623189953b50bac46324d5419933889721ed1bef170673b4cc7d4c97701f96ea608562122bf708290d6ff47141497550c68b9ef48dff12769c42ebdcc7b8af290df761a90e562826b1725d2666bd5a520d94d957be247de2cb7251497581d6b8af290df761a906562826b152de50a5cb4620b7905407659e207de27b724549358116b9af290df7616c0eb566318995eab2d4eb8f84c970fdf93462d7fd9f1dde46f58f24d5045ae5bec67d4e69b014ec9ac52456eabe521aff2aa906cafcadf489874baa07b4ce7d4e69b82f4b35b022318995fa47298d0749aa81dd79afee1f4ad7788578567caa09b4ce7d4e69b82f4b35b022318995ea3221ee3a926a60778f97ae718c78125daa072c81fb9cd26062dc9ac52456eaf3521adc2ed58f5773fb9a74095f6bbf9ca47ac052b8cf290df765a906562426b152a5ab95fd40d2e3b1bb5b4ad760695de014ee7b4ac27d597a3c562426b152a571a2a4c763776f932ee17d9eb96e0e9cc27d4f69a4c7634562122b551ac74b7a3c767621f99594c6cf85652c81df70df531ae9f1589198c44a9506bfd0fbb9977489bf915407582a7ea1572226b1525c439fd66ba534be2be7945407582aaea1572226b152cc729fd6b7a5341e27a906b054cc72af484c62a5b80f7d3a0748697867a90b48aa032c15f7a1572426b152ac14379d3f90d27883a41aad3887b873beb33c529e267f27cf97e78a97c57db4dc5dfe442e2bbe7f3fd5c272b0525c4562122bc55aeed3e972fff93d25d5a8954f95feb978c0fea4f4895fca7fca73c4efe559253d17dac55aee158949ac14bbad4de78e521a579754a316fbc8a1e25fde1f9529e267e249863710eed36f1fbbad552626b152ec873e9d9b49695c54528db9f2807a903c58bc704e9763688cf8981c22e9b5a10dec875e9998c4ca759918f76a4935707a074b69d4b0988cbf74f8acc3cbe4eb3287f867f1f5f9f47a5137f735a5c184b8198849acdc23a4343c1bfb8292eae0b4f692d2fbfc6f2fa9c63a79d6bdaf83bf508e93b986afd1ef2fe96f409ddcc7b8af290df761a90e562826b172fe75d8251e23a90e4eaff457c67fc81e926aacca25e530f124b44fc898e1096e9f96f7c82be545a77a81f80bc351e2fff625e913ae7d2e497f17eae33ea64bb05cf20cc424d6e2c3521a5f1526c795e932e9d003e9aa06754f62bbb63c443cd16c8a53e8aee941fbcfe4ec925e47e23303be7e7aa4786dfbd2f8df92eaa12eee5bdcc79486fbae54072b1693580b4f6eea126cef59ee55521aff2e63cf78f7e9e8ebcb03e5a5f271f12fe6b1c3a748df253efde9f9036794f47abaf05983d7496930d3b97eee5bba84fbae54072b1693588bf3896f0b2a8d13c4d788532d9cd6b9c5a784bbc4a7e499e24968d7132fb4727ef15aef9b5d58fcdf7e4f3cabfeafe4a9f20af12f971fca5471927c48bca1cc0d65aafbc43da3fe5952121efc530dd4c17d8afb96d2709fe5be2bd5c28ac524d6c6bfdebac4fd25d5c1e9f957f2315273f8d6a077cb93e58f6495b3cbcf24250bd4b883e77250bddca77409f759a90ed62026b13657952ef14de9726d74e9ce265e39ad96f02f254feaf3294d9f0158f752acbe645012d790f478cc9bfb12f7295dc27d56aa85358849ac55977bd21dfeb596ea607b57115f579fe23a76dff88278f0f6f56f9f3e9fe3ce7a9e075012bed52e3d1ef3e6bea44bbc43521dac494c62adbaccca76f814e7c525d5c2cebc50cbc3e5bdf22b993afc1cde62d21bc1f83abbafcffbcb85cf1ca4d73737a503baffaef478cc97fb902e73781c4c809c9998c4daf97ee02ef11a497550cef7507b8df287ca3f8967bbfb57736927e7056c4e146f66f266f1ed624f947bc88de4d252fb24c6bf9492b88da4c763bedc877409f751a90ed62826b176bf2f5dc3a769532d0ce735aa3d93d7bfe837f30c77cf745fca36a32f9792f05d01e9f19827f71d5dc37d54aa85358a49ccc2eba54b7c46b88d0d53f14238df9792f0c234a906e6c75f56dd777409f74da916d62c26310b9797ae93b61e2da91630d4eda4243e2be9f19827f7195dc27d92fba6540b6b1693988de74a97f8895c4c522d6088d2bb2fde2e9e14675e71ec7e5bf83abcffdb4d85c99cebe5bec27d4697709f946a61066212b3e15b97be2b5de26849b5803ebcebd62d658af0ea7d4b997f3047ee2bba84fba239de4e8953c52466a5ebbaca8e1b4baa056cc793fefe507c1ffc4be483f23d993ae6b86ded12b88fe81aec1f3173318959f1929bbe15aa4b30410e3bf1daf69ed9ecc1db8bd97459bb7bec7892a4d788e9b86fe83a11ce7d90fba2540f331193981d2fa5d935dc59a75a581ecf3abf95788315eff4b68a45744ac27bd0fbf6bff49a311df70d5d83e57c2b109398a523a44b78a193df92540b6df39adc9e74f63cf92f993afc05c1a7eb37eecf3f4036ef48e72f14ce7b57ba2b9d8a1dbad6c37d82fb862ee1be27d5c2ccc42466c91de077a44b1c25a916dae2ed4d3d483e4c3c1bddfba2f709af8ce7ed4fbd1deb9dc4cbd49604339febe13ea14bb8cfe1cb57256212b3752fe91ad792540b75db43bc22db3f489f6be05f14efd97eb8788d765f57df5cff1652125f1276fcab83fb82aee13e27d5c20cc52466cb9df847a54bbc5ffc0b2ed5435d3c99e98fc5ebc47f5bbac427c4bfa46f2b1791547f8307680fd425c192c375701fe0bea04bb8af719f93ea61866212b3d6e75bf69f49aa85f973877a88bc50ba0ce2df12ff02f7a973af399f6a6fe71fa5247c76203d1ef3e33ea06b7076af323189d9f36e605de25839a3a45a98a72bc8dfc997a5343c01ce7b5a5f4dfa7edefef25012fef5e675c0530dcc8b8f05f7015dc27d4caa85198b49cc9e57effa8174895b4baa85f938af78f18e0f4b69f8fee047c918eb6bfb3a7ac9a9762f3873094935303f6efb5dc27d8bfb98540b331693a8c243a44bf8fe63aea5cf8f3f93ebca9152baf7ba27b479aff50325d5eceb55b25bf816b53f91f478cc8f8f2fb7fd2ee1be25d5c2ccc524aab0b7f836a32e710349b5b07ae7126f56527a9ff80fc593e17c4a7c8acb27f7959260c1a2bab8cd7709f729ee5b522dcc5c4ca21a8749977883a43a581d2faee249673f9292f02975ef50b6afa47a63f02a603f97dde2e5c2599ebab8cd7709f729a90e2a1093a8469fc92e6cafba1ebed7fbcd52121e5cff595631cb787ff98aec16ef167646ab8bdb7a9760f26ce5621255e93ae1e57f48aa83f179330bafa1ee35cb4be2abe2096ee797546f6cfb48c904bc4fcad68567307f6eeb5d8289b3958b4954c5dfa8bdaf74691c279c369d967fc9de5d3e2b2571bcdc435679edd2f7b7bf46760b4fc0f3aff85403f3e536eeb65e1aee43f8755eb9984475ee2d5de27725d5c1705ec0a3740d745f1fbf8dac635bcae7c86ef10d197b263d56c36dbc4bb80f49755091984475ce2a5dee4b7fb4a43ae8ef72f27629890fc88d655d674a7c5a7fb7f0a61c63dcdb8ef5701b2f0df71dee43521d5424265125dfd2541aef915403ddf9d7b507c8921dcebc9ebab7355de7258f07c86ee18563bcda5c7a3ceae0365e1aee3b520d5426265125cfa22e8d93e46c92eaa0dc25e57db25bf85afaed64ddd7287d9d7eb76030af9fdbb6db7869b8ef48755099984495ce2cdf97d2a0110fe353e61efc760adf0ee641740eb77b950ce6defc85c1bc7e5dbedcbbcf70df91eaa03231896abd5a4ae3e1926a60770f929d7e017979d4bf97b9ec13ee15e9760b4f80e39a791bdcb64bc37d46aa810ac524aaf557521aaf935403dbf3b56fef80b653f816b4df97f4f875f86bd92d4e105f3e488f477ddcb64bc37d46aa810ac524aa7555290d0f3ca906b6f76cd929bce5e45c660bfb3ef367c96ee1d5c1b8cfbc2d6edba5e13e23d540856212d5f2b5da9235b91d3e2dccad2ae576ba0dc8efb91792498f5b07af0057b2688c9773f52631a906eae436edb65d123e6e59ceb7213189aa7d4c4a830566cadc5cb68befca75243d6e1d2e20becf7db778a59c45520dd4abcb8232ee2b520d542a265135efab5d1a5e673cd5c06f5c54b6bb7bc0b3d8e73491ec20f1f5f0dde249c2f2bf6d729b2e0df715a9062a1593a8da63a4341e26a9067ee32d92e29b7219498f59076facb1db96ac3ec57a07498f471bdca64bc37d45aa814ac524aa7647298de749aa8153dc4452fc54ae2ee931abe695ea9e21bb85cf2678dff35403ed709b2e0df715a9062a1593a8dab5a534fe55520d9c62bbad45ef25e9dfafda0152b2529dafa95f58520db4c56dba34dc57a41aa8544ca26a1793d2f890a41a38f9e46b4a8a3749faf7ab7633f1ca6ebb857755db4b520db4c76dba34dc57a41aa8544ca26a9eb95c1a3e0d9b6ae09495de525c41d2bf5f9573ca8b65b7f8a1786bd65403ed729b2e0dee72684c4ca27a25bfdc1cbf94756f1832571f91adb1ee5dea0e919259ec7eed97965403ed725b769b2e09f711a9062a1693a8de27a534ce2fa9c6d279e2dbd658d7ac60af095fb2ea9bc34bd3728a7d99dc964bc37d44aa818ac524aaf756298d2b49aab164fb4a8a3b4bfaf753f27dc55f92dde28b72034935b00c6ecba5e13e22d540c56212d57b9994c6a1926a2c5d5a3e73953bd4fdb66c770ffcd67889f8da7aaa83e5705b2e0df711a9062a1693a8de53a5346e27a9c6d27d4eb6c63b24fddb319d479e263f93ddc2d7d36f24a90e96c76db934dc47a41aa8584ca27a0f96d2f0bf4d3596ee7f498aa9d66df7a61a8f14af0dbf5b78e29367e1b3b90e36a3dd2f5c4ca27a5edeb334fe46528da5f39ee6297cad7acced46cf260f90d2db8d3cd3fe8a926a61d9dc964b8325801b1493a8de0da5345e2aa906b6bf86fd79b99ca4c794f297029ff62cf945eef073fabe723655c176dc964bc37d44aa818ac524aa77b094c61b25d5c0c9275f44bc094b0adfd6f610e9b29ff41ee28ef428f98594c477e470611110ecc66db934dc47a41aa8584ca27a1792d23846520d9ce26af23dd92e8e97bf94ed06dc73899769f5a6195f97d2f02f77dff7ceec7594725b2e0dd6f66f504ca27a679674db550a2f119a6ae0377c7faf4f79ef141e805f2fcf160fdefedf9f91ae71a2f817f93924bd16603b6ecb25e1bec17d44aa818ac5249ad0654d67df2a956ae0373cc0be504abf28758d77ca9f4b9753f8c006b7e1d2600f8746c5249ae02d334be3ca926ae0f4fc6bfd3532c6c0fe69799cb0ee3a86721b2e0df70da9062a17936882275e9586aff1a61ad8de45e5b1f229298d1f8967cefb1e6096dcc598dc864bc37d43aa81cac5249af014298dfb4baa8132bf25b7162f0cf35c79d1a9fe413c13deebb11f28ec6c87a9b80d9786fb865403958b4934e1ae521a4748aa01a00e6ec3a5e1be21d540e562124db8ae94c68724d5005007b7e1d270df906aa0723189267499f5ea4552985d0dd4c96d37eddfbf5d70574ba36212cde872ebda3524d500306f6ebba5c12d6b0d8b4934e3dfa434bc9849aa0160dedc764bc37d42aa8106c4249af128298d55ecf50d607c6ebba5e13e21d540036212cdb89e9486370b61dd70a02e6eb3a51bfd38dc27a43a68404ca219fbcacfa434ee22a90e8079729b2d0df705ee13521d342026d194374b69bc4f520d00f3e4365b1aee0b520d342226d1947b4b97b8baa43a00e6c56db54bb82f4875d0889844530e902e1b89300b16a84397bb58dc07b82f4875d088984473de2a5de210497500cc83db6897701f90eaa0213189e67873902e71bcec23a91680f572db741bed12ee03522d342426d19cbde41bd2255e2ea91680f572dbec126efbee03522d342426d1a4874ad760110a605eba2c16b5116efba9161a13936892ef3fedb2b6fb46d01900f3d0e74bb9db3cf79e2f444ca259f7953ef14439a3a49a00a6e5b6e736d827dce6534d342826d1ac33cb31d2275e2f2c0d0bac96db9cdb5e9f705b779b4f75d1a09844d3bc18c549d2274e94eb4baa0b605c6e6b6e737dc26d9c45a2162626d1bcc7c9903842ce2ba9368061f613b7b121e1369e6aa3613189e6ed215dd6784ff16db98fec29e9390074e3b6e436e5b63524dcb6ddc6d373a06131894538871c2b43e37372073993a4e701b033b79d3b8adbd2d0709b76db4ecf83c6c52416637ff9ac8c11c789b772e4173b50c66dc56dc66d678c705b769b4ecf850588492ccac565ac0ec5f16579b89c5bd2f3014be7b6e136e2b63256b80dbb2da7e7c342c42416e7c2f21119337e24cf97cb4b7a4e6069dc16dc26dc36c60cb75db7e1f49c589098c4229d555e2b53c43be44f85ebec581a1ff33717b78129c26dd66d373d37162626b15867102f2ff97399224e10d73f8fa4e7075ae163dcc7ba8ff929c26dd4f5dd66d3f3638162128b77908c31037ebbf8b1f8d4e365253d3f502b1fd33eb67d8c4f156e9b6ea3e9f9b1603109c859e409f2339932de227f24fcd240ad7cecfa187eab4c196e8b6e936e9be97560e16212d8e4523274119a92f0af8ec384ebeca8858f551fb3539ecdda883789db627a1dc0afc524101c2a63cf844fe1db6fbc500dbbbb61ae7c6cfa181df376cfedc26dce6d2fbd0ee0346212d8864f2dde4afaeed8d625fcabe726925e07b02e3e2657f18bdc6dcc6d8d4b51281693c02edcc9dc543e2853874ff7ff8ea4d701ac8a8fc1555c7a729b72db62204767310974706d395a7e2553c52fc49381f692f41a80a9f898f3b1e76370aa70db711b725b4aaf01281293400f9eb0f3f7f23d992a7c1af26049cf0f8ccdc7da949797dc56dc6698ec8651c424308057adbaa74c759dd1bf94bcc5647a6e602c3ec6a6fa55eeb6e136c20a6f18554c0223f035c04364aad3f12f95bd253d37d0978f291f5b63c7c66975b709ae8f631231098cec12e2538b3f9031c31388f693f49c40573e96c69ee8e963dec7bedb407a4e603431094ce4ec727f395ec68acf08db4662281f433e96c60a1fe33ed67dcca7e703461793c0c43656d8fa848c115f13b669455f3e767c0c8d113ea659f1106b1193c08af85ae2ade5533234be210ceae8cac78c8f9da1e163d8c732d7c7b1363109ac987fcddc4d8676ac7e3c8bd0a0948f95318e391fbbfc22c7dac524b026e792e7c89038512e22a93eb0c1c7888f9521e163d5c76caa0fac5c4c026b763d3941fa8637cd38bfa4da808f8d211babf8d8f4319a6a036b1393c00c9c5bde287dc3b71fed23a93696cbc7c4905bd37c4cfad84cb581b58a496026f690a748df789db846aa8de5f1b1e063a26ff858e478c26cc5243033f795beabcd3d4b524d2c8f8f853ee163cfc760aa09cc464c0233745b3949fac48324d5c472f818e8133ee67ceca59ac0acc42430534306f55b48aa89f6f9b3ef130ce6a84a4c02337617e9133f966b48aa8976f933f767df277caca59ac02cc52430737d4f9f7e5d58f77d39fc59fb33ef135ca641756212a8c0d3a44f78894e1603699f3fe3be4b0afbd84a3581598b49a0025e33fb28e913ef943d25d545fdfcd9fa33ee133ea6588f1d558a49a0126791f7489f3852e8b8dbe3cfd49f6d9ff0b1e4632ad505662f26818a9c47fa9e5a7d86a49aa8973fd33ee163c8c752aa0954212681ca5c4cfa4e7e7ab8a49aa88f3fcb3ee163c7c750aa09542326810a5d4dfade9e743f4935510f7f867dc2c78c8f9d5413a84a4c0295eabb808883a53debe5cfae6fb0e0109a119340c50e97bef1304935315ffeccfa868f955413a8524c02957b9ef48d670a3b6acd9f3f237f567dc3c748aa0b542b2681cab9b37f83f40d6fb1793649b5e7686fb99cdc441e284f959788ff0edf8ffdde53f97f3be7ffe67fe37febc7f8b1ae916acf913f9b21dba0fad8e04b1b9a13934003f6110f627de333720549b5d7c583d081e20d439e2e6f971365ac702dd7746d3f879f6b6e039f3f137f367dc3c7848f8d541ba85a4c028df07dc51f97bef153f135da3349aa3fb5f3897f413f45bce8c98f64d5e1e7f473fb35f8b5f835a5d73a357f06fe2cfc99f40d1f0bdc6b8e66c524d0900bc97132243e263794547f2c5ee1ec32f297f26219f22b74eaf06bf36bf46bf56b9e7ac53dbff7fe0c86848f011f0ba93ed08498041a73808c716adaa76b6f23632c0f7a6ef140f508f917f996d41adf16ff0dfe5bfc37f96f4b7f73177e8ffd5e0fb96cb211feec7d0ca4e7019a11934083dca10ffda5be11df9157c8dde4aab2d3ee6dfbc9d5e50ef27879a58cf53ae61cfe1bfdb7fa6ff6dfeef7c0ef457a8fccefa1df4bbfa77e6ffd1e8f117e1d0ce6588498041ab5bf4c752afb27e225443f7faa6fca2f85386df83df17bb3f13ef93df37b3745f8b3f6679e8e05a039310934ccbf12c7388d4bcc3bfc19ef744600684e4c028df36d4baf12a2cdf067cbad69589c980416e08cf24839498836c29fa53f537fb6e933079a1693c0825c4fbe2a44dde1cfd09f65fa8c814588496061ce2b2f955ae387f211394a366695df400e928b6ee19cffdbc6ac7b3fc68f758d5ac39f9d3fc3f4d9028b1193c0421d2ac7cb9cc32ba5bd5f9e25b797cbca18a7985dc3b55cd3b5fd1c4356655b45f8b3f26796fe1e6071621258b03dc5fb6b7f45e610bec5eb6879885c53c658d4a6949fcbcfe9e7f66bf06b9943f8b3f167e4cf2abd6e60916212c0af771ff3d2a643971ced1ac7ca0be44e7269997a59d52efc5afc9afcdafc1afd5a5719fe2cfc99d4b4331cb0323109e0340e166f373a64a397145ef8e448395c3ca1eb1c929e7fcefc9afddafd37f86f197be11ebfe77eeffd19a4e70770aa9804b02d6ff0717379acbc463e285f961fcbe6f02433cfbc3e46de22fe45eb53d77eec15655f49f55be0bfcd7fa3ff56ffcdfedbfd1ef8bdf07bb275029edf3bbf877e2f5f2d7e6ffd583653013a8849000050979804000075894900005097980400007589490000509798040000758949000050979804000075894900005097980400007589490000509798040000758949000050979804000075894900005097980400007589490000509798040000758949000050979804000075894900005097980400007589490000509798040000758949000050979804000075894900005097980400007589490000509798040000758949000050979804000075894914d9477e5bae22d73dd5efcb95e47c921eb36a17958dd756ea0049b5d6e10ce2f7d4afebbca7e686f2dfb7f56feee2eae2cfd8efed05c4af313d4fed86be4f53f93d49af7795766afbe797f498a538935c596e278f9797c9d1f24ef9bff27679adbc501e2a37958b4baa858e6212a77376f91379aaf8c0fc86ec163f92f7c9dfca8d642f49b5a7e4e7ef1a5f968b48aab76aee1036e20592fe4d17979792cfae4bfc4c3e2d6f96e7c93de46071c7965e430da6789fc68c274b7add53a8b5edaf92bfc4fc9578e0fe81f48913e47fcacda5f5f76b3231895fdb43fcedf1f5e24e7b687c4f9e2dbf23e9f9c67655e91b9f947349aabb2af794cdf11319fa9afe4e56157ebdef9687cb6524bd9eb95ae5fbd4274e92f4bac7527bdb5f059f99fa43799dfc42c68c6fc933a5a5f76b256272e1fccbea2fe40b3245fc4afe59a6fe15ec6fb9ff2e7dc383d1babe29fb5bba3bedcde16fefe9df76b1ce81cabfe29f289794f4dae664ce03ba8f8bdb4a7add43b5d2f6a7e481dc5f763e22a5e101ffc3f22ef99c1385e1f7eb48a9ed0bf1dac4e4821d24ff21bb853b677f8374c7720d39507c4df552724df1f5239f6efb906c173f96fbc994d760fd8bf658e91b47c9aaaf115f5b7e2a9be3df648c53d84306aa5b883fef478b7fb97d5bfac65be45049af710e86bc4fd712b785a95c50d26b1eaab5b63f05ffad5d7e24f897f60365eb99b5cbc9ff96d2f8a5f83ddd5736d7c11631b9507795dd4eaff9ba9827bfa4c76fc7938b1e255f9114ff22be4e971e3b063fbfaf8bf70d37a454770abe76ebd3939bc39dec580d79c840e54e7b732d77c6be56fe74f9a2f489f7cb7f97cd75e760ccf7a906adb6fdb1f81284bfc876b9fcf036d9edcb97bf247f5f4ae3f37288a45a90985c201facbbc54364c837eabde5c192268d7c4cf693f4b83178f66d9786b335fc6b22d51d933bbf1365731c2f63ce1a9e6aa0f2d903ff62fb4fe9136f14ffc24bb5d76149037aeb6d7f28bfb6b74a97f099bd3d25d5dbea6ab2f54bfc4ee14b2e8f94dace6eac444c2eccd6c95729c6fc95eaeb67ef91ade1c1e01c921e3306ff12fcb9f40937227f9b4e75c7706ed97a69e09b726949ffbeafa907aa33ca5de4ebd2357c99c103877f0da5daabb494017d1d6dffffc8d698baedf7e51f025dcf3ef997f99925d5dbcef5c5a7d5bb846f7df3ed83a9de62c5e482fcaeec7620f93695b3487a7c5ffef6fa62d91a6e0c5376e87790bee159dbbe3e9aea0ee146b9b593f335c629ee375ed540e52f28af913ee16b9417925477559630a097b6fdb12786aeabed77f507d2e597b3c3b79e9d5352bddd1c2e5de3bd32c72f426b13930be153363b4d5cd98831ee7f4efcfccf95ad717f49ff7e2c8f90bee1492e9e1893eaf6e10eccb7bd6c0e9f0df85349ff7ea8550e54fe7c1f205b67eb97c457c513ac52dd55687d405f6adb2fe5b902fe52dd253c23dd0beca47a257c76cb77d6748d0fc8d924d55c9c985c082f1651120f93f4f831b8616f1dd03ccb3bfddb31790194bee1db4ebc425aaadb95578bda1af796f46fc7b08e81eacfa4cfa50e9f82bfa5a49a536b7d405f72dbdf8d67a077fd65ee7891a47a5d78526c9f2fc0be6ba4eb69fe26c5e442bc4a4ac2834e7afc587c8aea95e26b424f38353735ff32f6ad577dc333cfcf2aa976a9bf96adf11449ff762ceb1aa8fe58fa74547ecc54f75cefa4f5017dc96d7f279e00e799e45de38732d6ed843e2bd2277cc623d55b94985c000f685e9eb1247cb0fe96a43a35f3b56b9faeea1b43ee0dbfbb6c8d978b7fb5a47f3f96750e5477963ee141fdd6926a4ea5e5019db69fb9edbd41fac4d324d5ecc3c74fd709721bb1ae335ab311930be0d9d35dc293b64a6fc3a889bf911f277da3cfea6d3793adbf56bd61c32adedf750f54cf923ee153f6ab3c1ddbf280deb5edfb8e9416dbfe565e8bbd4ff8def4b117fbf927e913df91a57c018b627201ae275dc31b0fb4789b8497221db211c76324d54d3c4b7eeb641bdf87bbaa99aaeb1ea87cb744df7bd5fd19adaab36a7940a7ed9fde2564ebea8ca5e1336ba9e610ee27fa8637494a3517212617c0f764f7097f5b6f717b442feed07556ebe6b893a4ba9b5d56fc0d7a73782199fd25fdfb29cc61a0f2ed529e11dc277c9bce2a6e6d6a7940a7ed9fded6c9795d62c8ccf69d7883a8be711349359b17930b7005e91b5e68e13a92ead6acefc42d87375fb8a1a4bae6417beb2a709e49eb59ade9df4f652e03d53f4adff0ee6da9e6985a1ed069fba7e53d05fa8697949e6ade4bc90a7edbc567650997494e272617c0b738f43dc5e4f0c0f72469ed5689bb49dff0b2965796ad35bd31c3276473f89ab017aed8fa6fa7369781ea7ce2857afa848fdba9776c6b7940a7ed9f96d7a8ef1bff20a9e618fc657f4878c5c654b76931b910436edbda08dfbe9506b19af9f699bee14d283677e85ec33a2d737b1bd9fc9cab32a7816ac86bf14e55a9e6585a1ed08db67f0a4fb41c125eb235d51d4b9f5be836e253e2c56a52dd66c5e4427873fe3162636bbf56562bf229b49748dff0b52f2f7dea6bbdaf76624b78938af4bcab30a781caf5fa5e4b7778bbcf54770cad0fe863b6fd6748ad6d7fc8171b9fe5187b49ecadd2c2535dc2971153dd66c5e44278e04a1b25f40d5f5f9b72039355f2f527cf16ed1b5ec23135c6294fd19598db40d57517abcde199d7a9e61886bc4f7eacef7c988abf100ebd3e4adb3fe5b24fdffbbd1def9454774c87c990f0a23da96eb36272413cf3ba749189d2f0e61a2d9c86f7ad641f95b1c2bfd65731437b27731bd06f277dc3d772a7ba8d6dc8fbb48a18e3cbccd2dbbe97581e124f9654774cde527848789ecaa2366f89c985f1f5dcb1c3a7528f90b1d63c5f17effae51d9486867f0dcde13edeb90de8e791be771638fc8b35d51d6aee03baef9048afbbab29dbfed88bad8c2dcd6de912dea320d51d93af81a73de4bb847fe5a7da4d8ac905baaf4c115e3af271d2774bc139b88c6cbd7fbc4bfc979c5752ed559bdb806e4366191f2fa9e65043de27df9ee8c94c53f9b478dd84f4bafb5862dbf73e0c434eb73ba6bed362c3d02f1e636c1a538d985ca8bbcad0837cbbf8a63c503ceb3b3df7dcf9ba65dff07daea9e63acc71401f725781e3b725d51d628eefd39496d6f6bd66c490f0ba137df771e8ea7fc990f097c054b74931b9608788f7fc9e2a3c79c6f747aeaa318ce57ed237a65a49aa8f390e543e753924ee23a9ee104b1bd06d496d7fe897c8cf48aa3b8547c9d0f0a5c354bb3931b9705ed5ec5d3265f81ec99bcb54ab2c8d8d017dba81eae232248e92547788250ee8b694b6ff1a1912ab5c2f7dc8c4d18db881a4dacd8949fc7a328667817e5fa68cf7cb3525bd863961409f6ea0f2ccff21a77bbd0a5faa3bc45207745b42dbffb80c89293664d9ced0cb038e7b49aadd9c98c4ffe7db82c658556ab7f0ca5f73ee0819d0a7fd7cbe207dc3d733c75e8674c903fa8696dbfe90a56f1d3e3e52dd297833a3a1f1f7926a372726713a5e71c8a7caa60cef76f60059f7bdda0903fab49dae77511b120748aadb1703fa6fb4d6f6bdaaddd098ea76c9c4c7d3d078b1a4dacd8949449ecce2533743f60e2f890f896f154baf615d18d0a71da8de2e4362ec5deb18d04faba5b6effbe387c62325d59ec21803fa6b25d56e4e4c62475e79e8afc5f7994e15fec6fe17929e7f1d18d0a71da8dce10c896b49aadb17037ae6b6ef5fa735b7fda1abaf39dc1fa4da53f0e24b43e36d926a37272651c48ba578f9c3291bf7d3640e33e119d0e73da08f3db98a017d6735b77d06f486c5243a99ba717ba5a3755f5767409f76a07a870c89cb49aadb17037a991adb3ea7dc1b1693e865a3718fbde183e399929e735518d0a71da87c0bd390187b931606f46e6a6afb4c8a6b584c62107f037e9e8cbd94a457994acfb70a0ce8d30e545f95bec16d6bf3514bdbff990c091f1fa9ee14b86dad8398c4287c1a74e8ed489bc35b01fafa577aaea931a04f3750ed2543e26392ea0ec1803e8cb7669d73db5fdac2325e2828d56e4e4c62345e75ea1e32d635b67f93f43c5363409f6ea0f2fed943e26592ea0ec1803edc9cdb3e4bbf362a2631ba03e5581923ae22e939a6c4803edd40e59dbe86c4dd25d51d82017d3c9796b9b5fd27ca90a86d7396b1e798cc564c62126717df3e31345e22a9fe9418d0a71ba88e9021314567c5803eaeb9b5fd9ab64ff54cff21c1f6a998cc9ee2d35543e2bb32f624a8dd30a04f37509d287de33f25d51c8a017d7c736afb6795a113f72e29a9f6d8de2343c25f0852dd26c52426b5af0c9d94725549b5a7c2803ecd4075451912f79754772806f469cca9edff1f1912dec73fd51d93e721fc4086c4ed25d56e524c6272bea63e64c7235f774d75a7c2803ecd40f524e91b5e22f45c92ea0ec5803e9db9b4fdfbca90f07df7a9ee98fc5e0d09df9ee7e57a53ed26c52456e2f1d237bc967caa391506f4f1072aaf00f625e91b2f9054770c0ce8d39a43dbbf809c247de39d92ea8ec9bfae87c4ab25d56d564c6225ce2d7d579672879b6a4e85017dfc81eaa6d2377c5ff2d85ba66ec6803eadb9b4fd7f95bee15fbffb48aa3b96a113e26e26a96eb362122b73a4f4892748aa371506f4f107aa21cbbd3e5552cdb130a04f6f0e6dff7a3224febba4ba63f982f40ddf5ae76bf0a96eb362122b7327e9135eb022d59b0a03fab803d5f5a56f7899d8734aaa3b1606f4e9798bd43e3176dbffbfd237fe5152cd315c4986c4dd24d56d5a4c6265faae53ecc7a57a5361401f6fa0f2fdbb43663affa9a4ba6362409fde5cdafe8da56f7c59a6fa15fc38e91b9f93bd25d56d5a4c6265dcf9758d6fcbaab75365401f6fa0ba8ff48d2927c26dc6803ebd39b5fd21d7d2a738edee7de08f93be710b49759b179358994b48d770679b6a4d89017d9c81eab7a5ef64a8ff9055fdea60409fde9cdabe8fcbbe3bb0bd4a52cd21fe40fac6db25d55c8498c4caf8db6d97f0928bee0852ad2931a00f1fa8bc5258dfeb955e4d6e7f4975a7c0803ebdb9b5fd07499ff0eb1afb8e8ba3a44f7c5f2e2ea9e622c42456e6e9d225fcef539da931a00f1ba87c0ad1eb70f7896f88b7e24d75a7c2803ebdb9b57d1fa36f923ef11c4935fbf06636bf923e7198a49a8b11930df3fac31f3dd514bb5475e10d1bbe29a5f169399ba45a5363401f36503d5afa8407f3cb4baa39a5160774dafeeebcd84c9fbd05bc2ec2c524d5eccadb01f789ff29a9dea2c464c39e2f9bc35bf3f99b69fab753ebd2697a99cf7574ec1b18d0fb0f547d67eb7a97285fdb4c35a7d6e2804edb2fe3fdf9bf275de39592ea757175e9135eb5ce97b452cd4589c9867902c7d678ad4cb526f676bc825169b8417b018854675518d0bb0f54de15ebd9d227fe5dce27a9ee2ab438a0d3f6cbf939fddc5dc3ab1fa67a25dc5e7cf6a46b7c4016b55efb4e62b261fe16e746bc35be22abd83dc8fe444a3767f037e54325d5592506f46e03d585e4ddd2357cedd0abc0ad6aafe9edb438a0d3f6bbf1a0fe43e912be44746149f576e3cd5eba0683f91631d938dfc7e94e33c51be520498f1bcaa7f70e97d20d113e2b9795546bd518d0cb062a7fc6be3eeb7dabbbc6f1e2db7552dd556b714037da7e375ec4c68bc774890f8bb7894df5b6736be91a6f90aecfd3bc985c885bc9761defbfc82132d635b62bc8bba4343cc1e3ac926aad0303face03958f139f6efc88740d4f28f2fadc536f74d145ab03fa06da7e394f94f335ea2ee14b46a5bf9c7dd6e2e7521a3e8bf51859dc3aed256272417c7ac85bec6d17fed5e453415795ae2b34f980f39addae5f7a1bc6c7642ebfd2366340cf03d545e46172ac740ddfbffb5cb9a06cadbb6ead0fe846db2fe74b408f952e03ef27c45f66523df317a6078bdb41699c203794540f12930be46fe4bbfdbaf2352d9f967323bf83f8313e60dd81996f8bf1e0e553aedef6cf9b6894860704d79c6259c73130a09f7cf21f9eea9ee25f519f923ef11d7986ac6381a05243dea76bc9469b98c2d85f80c668fbfe2c5b6dfb9bf932c07ba534fc05c01bb878e6fc460daf76e8fd083e24a5e12f45cf9475ddb65b8d985c307ffb7bb3ac227e29af933f96b99f3e62401f16be76ead3907791399d5adfcebadea792f07b795b49af7b08da7e99be97973c6bfe4bd2e517b907726f337b1949af055bc4247efd6bdbf7a9fa34d898e183dad7e8ee2aebbc2da92b06f4eef12d71a77d67a9e9b3b6390fe80e0feae9758f81b65fc603bbbf90bc5efc0565ccf02634cf1206f28e6212a7e15b90bca4e03f886f4572475d129e74e3b5bb7d0aee01e24513d67d3b525f5e47bccfee47de28614ebf48bd40876fad19337c1b924f9b7ac72a1f23b7172f5f39d6a4aa7598e27d1a337cea3bbdeeb1d1f6cb78e2dc7dc583fb0fa44f7c518e905bca5e929e07bb8849eccad781dc697b137eff02b5eb9cfafffd0dbfc5bd78fdab62e36f2d35c7d3cbde4822bdd652d7107fcebe76ea8e2c3d470b86be4f53f93d49af775596d8f6bbf0023107cbedc4776f7829d7a3c533e53f28fe92eff5005e289e50ead3f77edf522d7414930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02e31090000ea12930000a02627ffb7ff07ebdabb1d1d3c428a0000000049454e44ae426082, 12, '');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `restaurant_accounts_privileges`
--
ALTER TABLE `restaurant_accounts_privileges`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `restaurant_category`
--
ALTER TABLE `restaurant_category`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `restaurant_customers`
--
ALTER TABLE `restaurant_customers`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `restaurant_customers_record`
--
ALTER TABLE `restaurant_customers_record`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `restaurant_employee`
--
ALTER TABLE `restaurant_employee`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `restaurant_employee_time_in_out`
--
ALTER TABLE `restaurant_employee_time_in_out`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `restaurant_expenses`
--
ALTER TABLE `restaurant_expenses`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `restaurant_logs`
--
ALTER TABLE `restaurant_logs`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `restaurant_order`
--
ALTER TABLE `restaurant_order`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `restaurant_order_details`
--
ALTER TABLE `restaurant_order_details`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `restaurant_products`
--
ALTER TABLE `restaurant_products`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `restaurant_sales`
--
ALTER TABLE `restaurant_sales`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `restaurant_sales_details`
--
ALTER TABLE `restaurant_sales_details`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `restaurant_stock_out`
--
ALTER TABLE `restaurant_stock_out`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `restaurant_table`
--
ALTER TABLE `restaurant_table`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `restaurant_table_booking`
--
ALTER TABLE `restaurant_table_booking`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `system_accounts`
--
ALTER TABLE `system_accounts`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `system_config`
--
ALTER TABLE `system_config`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `restaurant_accounts_privileges`
--
ALTER TABLE `restaurant_accounts_privileges`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `restaurant_category`
--
ALTER TABLE `restaurant_category`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `restaurant_customers`
--
ALTER TABLE `restaurant_customers`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `restaurant_customers_record`
--
ALTER TABLE `restaurant_customers_record`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `restaurant_employee`
--
ALTER TABLE `restaurant_employee`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `restaurant_employee_time_in_out`
--
ALTER TABLE `restaurant_employee_time_in_out`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `restaurant_expenses`
--
ALTER TABLE `restaurant_expenses`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurant_logs`
--
ALTER TABLE `restaurant_logs`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurant_order`
--
ALTER TABLE `restaurant_order`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `restaurant_order_details`
--
ALTER TABLE `restaurant_order_details`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `restaurant_products`
--
ALTER TABLE `restaurant_products`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `restaurant_sales`
--
ALTER TABLE `restaurant_sales`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `restaurant_sales_details`
--
ALTER TABLE `restaurant_sales_details`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=85;

--
-- AUTO_INCREMENT for table `restaurant_stock_out`
--
ALTER TABLE `restaurant_stock_out`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurant_table`
--
ALTER TABLE `restaurant_table`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `restaurant_table_booking`
--
ALTER TABLE `restaurant_table_booking`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `system_accounts`
--
ALTER TABLE `system_accounts`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `system_config`
--
ALTER TABLE `system_config`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
