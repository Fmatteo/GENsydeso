-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 06, 2019 at 08:40 AM
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
-- Table structure for table `restaurant_accounts`
--

CREATE TABLE `restaurant_accounts` (
  `ID` int(11) NOT NULL,
  `Firstname` text NOT NULL,
  `Lastname` text NOT NULL,
  `Username` text NOT NULL,
  `Password` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_cancelation`
--

CREATE TABLE `restaurant_cancelation` (
  `ID` int(11) NOT NULL,
  `Order_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_category`
--

CREATE TABLE `restaurant_category` (
  `ID` int(11) NOT NULL,
  `Name` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_employees`
--

CREATE TABLE `restaurant_employees` (
  `ID` int(11) NOT NULL,
  `Firstname` text NOT NULL,
  `Lastname` text NOT NULL,
  `Username` text NOT NULL,
  `Password` text NOT NULL,
  `Image` blob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_food_items`
--

CREATE TABLE `restaurant_food_items` (
  `ID` int(11) NOT NULL,
  `Name` text NOT NULL,
  `Price` double NOT NULL,
  `Category_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_ingredients`
--

CREATE TABLE `restaurant_ingredients` (
  `Food_ID` int(11) NOT NULL,
  `Name` text NOT NULL,
  `Quantity` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_order`
--

CREATE TABLE `restaurant_order` (
  `ID` int(11) NOT NULL,
  `Table_Number` int(11) NOT NULL,
  `Customer_ID` int(11) NOT NULL,
  `Employee_ID` int(11) NOT NULL,
  `Status_ID` int(11) NOT NULL,
  `Order_Type_ID` int(11) NOT NULL,
  `Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_order_details`
--

CREATE TABLE `restaurant_order_details` (
  `Sub_Order_ID` int(11) NOT NULL,
  `Order_ID` int(11) NOT NULL,
  `Food_ID` int(11) NOT NULL,
  `Special` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_order_type`
--

CREATE TABLE `restaurant_order_type` (
  `ID` int(11) NOT NULL,
  `Name` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_status`
--

CREATE TABLE `restaurant_status` (
  `ID` int(11) NOT NULL,
  `Status` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_table`
--

CREATE TABLE `restaurant_table` (
  `ID` int(11) NOT NULL,
  `Name` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_table_booking`
--

CREATE TABLE `restaurant_table_booking` (
  `ID` int(11) NOT NULL,
  `Table_ID` int(11) NOT NULL,
  `Customer_ID` int(11) NOT NULL,
  `Status_ID` int(11) NOT NULL,
  `Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_time_in_out`
--

CREATE TABLE `restaurant_time_in_out` (
  `ID` int(11) NOT NULL,
  `Employee_ID` int(11) NOT NULL,
  `Timein` time NOT NULL,
  `Timeout` time NOT NULL,
  `Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `system_config`
--

CREATE TABLE `system_config` (
  `ID` int(11) NOT NULL,
  `Company_Name` text NOT NULL,
  `Business_Type` text NOT NULL,
  `Company_Logo` blob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `restaurant_accounts`
--
ALTER TABLE `restaurant_accounts`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `restaurant_cancelation`
--
ALTER TABLE `restaurant_cancelation`
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
-- Indexes for table `restaurant_employees`
--
ALTER TABLE `restaurant_employees`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `restaurant_food_items`
--
ALTER TABLE `restaurant_food_items`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `restaurant_ingredients`
--
ALTER TABLE `restaurant_ingredients`
  ADD PRIMARY KEY (`Food_ID`);

--
-- Indexes for table `restaurant_order`
--
ALTER TABLE `restaurant_order`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `restaurant_order_details`
--
ALTER TABLE `restaurant_order_details`
  ADD PRIMARY KEY (`Sub_Order_ID`);

--
-- Indexes for table `restaurant_order_type`
--
ALTER TABLE `restaurant_order_type`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `restaurant_status`
--
ALTER TABLE `restaurant_status`
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
-- Indexes for table `restaurant_time_in_out`
--
ALTER TABLE `restaurant_time_in_out`
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
-- AUTO_INCREMENT for table `restaurant_accounts`
--
ALTER TABLE `restaurant_accounts`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurant_cancelation`
--
ALTER TABLE `restaurant_cancelation`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurant_category`
--
ALTER TABLE `restaurant_category`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurant_customers`
--
ALTER TABLE `restaurant_customers`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurant_employees`
--
ALTER TABLE `restaurant_employees`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurant_food_items`
--
ALTER TABLE `restaurant_food_items`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurant_ingredients`
--
ALTER TABLE `restaurant_ingredients`
  MODIFY `Food_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurant_order`
--
ALTER TABLE `restaurant_order`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurant_order_details`
--
ALTER TABLE `restaurant_order_details`
  MODIFY `Sub_Order_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurant_order_type`
--
ALTER TABLE `restaurant_order_type`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurant_status`
--
ALTER TABLE `restaurant_status`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurant_table`
--
ALTER TABLE `restaurant_table`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurant_table_booking`
--
ALTER TABLE `restaurant_table_booking`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurant_time_in_out`
--
ALTER TABLE `restaurant_time_in_out`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `system_config`
--
ALTER TABLE `system_config`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
