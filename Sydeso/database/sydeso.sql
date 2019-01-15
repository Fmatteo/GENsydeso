-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 15, 2019 at 02:25 PM
-- Server version: 10.1.36-MariaDB
-- PHP Version: 7.2.11

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
  `Total` double NOT NULL,
  `Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_order_details`
--

CREATE TABLE `restaurant_order_details` (
  `ID` int(11) NOT NULL,
  `Order_ID` int(11) NOT NULL,
  `Product_Name` text NOT NULL,
  `Qty` int(11) NOT NULL,
  `Price` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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
(1, 'Coke', 200, 20, 35, 'Beverages', ''),
(2, 'Sprite', 200, 20, 35, 'Beverages', ''),
(3, 'Royal', 200, 20, 35, 'Beverages', ''),
(4, '7-UP', 200, 20, 35, 'Beverages', ''),
(5, 'Emperador Light', 200, 20, 150, 'Beverages', ''),
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
  `Account_ID` int(11) NOT NULL,
  `Cash_Tendered` double NOT NULL,
  `Discount` double NOT NULL,
  `Amount` double NOT NULL,
  `Cash_Change` double NOT NULL,
  `Payment_Mode` text NOT NULL,
  `Date` date NOT NULL,
  `Time` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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
(2, 'Table 2', '10 seats', 'VACANT');

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
  `Vat` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `system_config`
--

INSERT INTO `system_config` (`ID`, `Company_Name`, `Company_Address`, `Company_Phone`, `Business_Type`, `Company_Logo`, `Vat`) VALUES
(1, 'Sydeso Company', 'Company Address', '1234', 'Restaurant', 0x89504e470d0a1a0a0000000d494844520000006400000064080600000070e29554000000017352474200aece1ce90000000467414d410000b18f0bfc6105000000097048597300000ec300000ec301c76fa8640000070349444154785eed9d6b88156518c7d54ad3d28ccaa49b8258064a8a494a425fba1065e007c12cb2c882a4ec02055690a861054564456656481f0243a33e5884410985864a5086a89498855492959aa66bbf67deff9edd39e7ecd999739933ee3c3ff8f3cefb3eb777f6d9dd397b2eb3fd1cc7711cc7711cc7711cc7711cc7711cc7711cc7711cc7711cc7711ca7507474749c87ae3a79f2e4e43ea271e8749ddea9039b9e4e2336a2131cf72938a73fd0520e87e874f30d9b9d8b8e87edf75d38c74d68a84e3b9fb0c1f1e8a8f6dce7e15cdfd6a9e71336b85a7b2d049cef0974a94e3f7fb0b97dda6b61e09cefd1e9e70ffb8ed13e8bc4229d7efed0060b05df84cb74faf9437b2c14de909ce10dc919de909ce10dc919de909ce10dc919e50d613e81e5596945dc0c7435c7672855e390ac705469c83299ea82f8bfd01b1c5ea694f51352168b6637a413f21c46f395b63e94ab50b4aa219d906f05c340a54f4748512c5add10839cef339ca612c909e1c5228b8618e47d5d2592a3d8429155430c72cf55996428ae5064dc9043e84a95ea1dc5158a2c1b6290ff3b86646fb00821c522eb8618d458a572b5917fa148db10ecc7d1e768255a91501b145e82b53b55b267e45b28f8c2246e08b65de81ab926869841688bd24430ff9b619c5caa135c8b055f98440d61ddfef21e2fb7d4103b86347f866c01d6be4583e55289fc0a055f90a40d592997ba218d3d111983bc6fca5c897c0a458a863c22978620cfab4a5982b53932c791bd50a468c803726908f254bb9ed833c457c8a50bd90b055f884c1b6290abdaf5641b1a2497806c85c21aa0d38fb0b94c31586f5a430c5256bb9e2c9539a0f542d1ae8618e48c5d4f981f41a364f6861836972906eb4d6f0869cf24ef8e5021c07cb5ccde1023cb8618e4bd552522981f45174446ad150a6b4074f2c2e632c560bd250d31c8bd496522983f1619342f14291af2b05c9a0eb9ef559908e69b2383e6852245431afe4bbd27487f0ef93b42a5a8d67f68b037046c2e530cd6ed11d004b9351d72ffa45211ccc77a43c0e63255806d37c364b93615726f0c5502cca77943a056430cecc7d03af43cd3e79a25f2ed65ecce746f08d85ca676e30d31bc216dc61b9233bc2139c31b9233bc2139c31b9233bc2139c31b9233bc2139c31b9233bc2139a3900de124ed0597cfd0334cef675c805e41f674765b610fa91b82cf7eb40a3d8aee430bd15a74482ecda0350d6193f681c7aa9fd966bd3ff699e8c7c8b90d503b7143b01d40f339ac7aab59d6cfc5fe226ac64d449bdb1036653ca4bdd604f7f3f18dbd409315d44dd410d677a3b172ab097eb7a0467f5a9ade90c5da5f2208b1efae5d213a3ba8d96b43583b882adf7b5b03fc672bbc5ea65b92a6dc22963c3f30a4be83347137850cd941cd252a1fc1bc5a43c2db725242dc474a510f132dc1764d1a823cf3b4a7d410bb4d6932817ab1db5f308f3584b9bd33bde70fd5d480b8694a930ae2ec6373c32cc112ad35047946684fa9217c51c8920dec35f6ab887979433e902935840f20fed7902939c4acef4c309cc9cf61b93e883f1025ab13e2e72855cba1d65a952dc15a79439e95a92e884ff560057f7b2be924854709a6a0df644f0db17b95aa2e88bf4da95a0a75b6a3f01eda6eb056de902765aa0be2d72b55afe06bcd98add02eb08dc6b0061d0baec921e65f86fe4a951ae2e7854cad81fcf6e1cdd7381cae9231b09537e46599ea82f8d8a7a5aa818ff1059aa2b0eae06b0f45af65bcbe96f089bdeb0eea7e3319b9de518e08e6cb19aad64d2b724d65ac7917057c1ec7a704f34d32a586707b8b68e9912bc776b1be99c3ee7bba0e5dac90e640c2b7ac6027cc5f922915849e4decef214b8989326702f5ed367d25981b97cb9c0ae2cadf44fd954cad854233543382f91186d1322786b8c5214380b9fde40d903913ac1e75f7441b10cc2b2efebd41d8902a7916cadc5aa86527617f0c96606ebf3b13ff171bfc6f44b1e78098277aeaa5d950f7416da1046b0b64ee15dced39ba352132c0dceedc50f5bad51228383394ee82b5cde812b9f4083e77a0c30a8b60be93a12dff9688baf651b3f26f30e3690e6bfec4e23314ad0b515db0f6945cb283baef86f25db011fbce58c438466e11ac0d64ed06f449e4d80dd6ece23755ae6d81fa9350c55349ac6d65b0dbc29e25d708d646b2662f2bfc12397683b5af19d2dfe2af51283c187d1ab65109b67d680bfa1efda3e518ac5b336e57cab6c23eec5ebc559fdfb375b4037d83f6a0aaff7b85753bd78abf7732833dd8c5cc5e03490d7107196629552e604ff653bc3fec301dc47dc93052a9da0b9bb90b957fe6a12af8191f7398fa915916b0b711e83d94e88527fcec85ac2738ccfed7542dd8d04074379bfb10d9b524066b3bd172d4f5dc4d8e619f63d00b682b2a7d26d0606abfc236207b59779842f20b7bb687c617a209682c8a5d144f35d8bf5d2f47715e13192f626cf27f10edd7ef7fb486d69b087da11f0000000049454e44ae426082, 12);

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
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurant_order_details`
--
ALTER TABLE `restaurant_order_details`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurant_products`
--
ALTER TABLE `restaurant_products`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `restaurant_sales`
--
ALTER TABLE `restaurant_sales`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurant_sales_details`
--
ALTER TABLE `restaurant_sales_details`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

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
