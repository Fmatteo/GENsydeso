-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 09, 2019 at 07:13 PM
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
(1, 'DEO'),
(2, 'LOTION');

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

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_employee_time_in_out`
--

CREATE TABLE `restaurant_employee_time_in_out` (
  `ID` int(11) NOT NULL,
  `Employee_ID` int(11) NOT NULL,
  `Timein` time NOT NULL,
  `Timeout` time NOT NULL,
  `Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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
(1, 'REXONA', 12, 10, 10, '', 0x89504e470d0a1a0a0000000d49484452000000300000003008060000005702f9870000000473424954080808087c0864880000000970485973000002f7000002f7012d148d380000001974455874536f667477617265007777772e696e6b73636170652e6f72679bee3c1a000003e3494441546881ed585d681c55183ddfdd99a411251b8d485ad03eacc943baeccf6c6a45ad18451469412a6d1faa50a520f8a025a050fc79101f149ffc0745db17050bada0f445b4514b1036b33bac29284d44a1457d90c650eb6693b9c787ba713299a4b3cddd0471cedbfdf6dcef9c6fbe7b673e164890204182040912ac1fa41d49abf97c5a2bb51fe4bd00ae07300d91931479bfe4babf98d4325e805b2cee00f90180eb227ebe40f260c9f3de33a567b4804aa1b093c03100a99578249f2879de5b26348d15303638786d6747c724809e18f48622b7143cefcc6a75d56a1334d169db8f219e7900e8d0c09326748d150091e1b6f29781c9026e6871479f0959630508f9472b7c02e74de89aeb00f04d9bf99130568056ea0880467c65f5ae095d6305945c770a22cfc522936f965cf794095d9347084ea5f20a81e701e8e53804de9949a79f32a5d99659a89ccb15542a35b26816224f6ae0b521cf1b6d87668204ff57b4e51203c0b8e3f451a92e00b01b8d5921a773b5da9f515c02522916b3006c00986b34ce6e9b98f82d8e8e9102c61da757697d8f06ee04b04d800c80ab97f814d9e5542ac7c3fbbd5c6ed0576ae25f263f733c6f471c6d6b15a66d21f780dc07adef2660adf834445e8d320f007e2ab505e4c29a22fd673299ce9b2727672fe7a3e50efcd3ee03200f01b829e6b67396ef0f348f50a550d84b916ccaf73f9c57ea6901f661e947f51cc983a2d4ef00766d989d7d66f0f4e90be1c42d75a096cdf6542ceb30c89dadec83c8db4df3b56cb6670e781d64afafd4a1159ee02611f9b8d999ba6d9f07f06c98147b9418779cab1a96f52580d6cc03d4a9d447cdc59c6dbf00a0b7c51c80c848359fdf1c0ec79f85b41e1120dfb230f0fd50b9fce3c28adc1ac19906b9dfb7ac3eedfb59905177c5f623f4631720c07d71b921fc145ccc74770f0b7062717279dcf1bcc35bcbe55f876ab58999747a3744aa418a26ef2f79de27e1e4b10b20d0dd9aef05736783cbbb4647eb2483314d914f439c792117c53ab49e8c4a6f749c8e84d64b5e1422520f7a505aa7c31c928bfe189bb3ed7a9803ac4501221b834bb7581c26f0503046e045065ee95e2ed70fe0914569b47ef9d4c0c035e1f457fc216b010e0111e0d2fb907c03c0c610e7d14a3edf5f1139ae814d3e79002261b30f6fe8eafa02c09160b06db3d072708bc507411ebb82addf4d653285dd478ffac1e09a1700006ea1f015805b017c0be0f6157cfc8c4b9ddbacc907863cef4498d0fe3b10012ab5d7b7ac1b9d6a753b95da0e602c44a9837ce9af8b17b353994c466b7d4b9479609d3a10865b2cde01f2eb4068cca9566f8bb3772d2ef16561cdcfff309f4a95d13c11229fafafa30409fe3bf81b1b5c562b721e10610000000049454e44ae426082);

-- --------------------------------------------------------

--
-- Table structure for table `restaurant_products_damage`
--

CREATE TABLE `restaurant_products_damage` (
  `ID` int(11) NOT NULL,
  `Prod_ID` int(11) NOT NULL,
  `Qty` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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
  `OR_Number` text NOT NULL,
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
-- Table structure for table `restaurant_status`
--

CREATE TABLE `restaurant_status` (
  `ID` int(11) NOT NULL,
  `Status` text NOT NULL
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
  `Company_Logo` blob
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `system_config`
--

INSERT INTO `system_config` (`ID`, `Company_Name`, `Company_Address`, `Company_Phone`, `Business_Type`, `Company_Logo`) VALUES
(1, 'Sydeso Company', 'Company Address', '1234', 'Restaurant', 0x89504e470d0a1a0a0000000d49484452000000300000003008060000005702f9870000000473424954080808087c0864880000000970485973000002f7000002f7012d148d380000001974455874536f667477617265007777772e696e6b73636170652e6f72679bee3c1a0000020b494441546881ed97bb6e13411846bf3f8a4b43818494e409c012696873238f9234901b2f90f4b948790110019e834491d252200751902a1215690c6de443614f246ff6323b59ef58688fe4c2bbe3d9f3f9dfcf5a4b0d0d0d0dff1dc063e03d70337cbd031ec5f6f2029802ceb9cf193015dbaf10602b45deb119db2f176006e8e504e80133b13d33014e72e41d1f627ba6022c017d8f007d6029b6ef08400be87ac83bbac0746cef3b80ed12f28eadd8de92bc8a9bc564141af81820ef38892dbf8c5f71b388576806c5bd7c80bca30bb4620478936795b23e8fd775cbcf027f2a0cd00366eb0cf0b940a86c00804f75c9af78c88404e803cbe396f72e6e4000867b972a74d9e7f34d499d929f294347d2c65876c6a3b8154c80e135bc0b5d66020792da25d687d296b45fe98e7816b7a2093856aa926f01df2304f02ab4cf2db42de97940f0dc401e7424153e725b81c49ca41faae7de4fe3afa46766f62b6b41d1040e154f5ec36b1fe42dc89c00f04ad297aa8d025935b3d3b413a90118fc5ffd2ae945e815cd6c64efc01e38be497a6966b7c91359b7d05b3d407e0ccc4bda493b716f025515b7e2094819854e9bc091e216378bb6063f2a2324bfa50549e7c9e313049216cdecc21d484e604f932b2f0ddc769307ee006e243da9d32880df66f6d4bd494ee0ba669910461c93018e6b140925df115807ae029e1ec7cd4f60ada62fa9a1a1a1c1937fbf5fcc7efb00248e0000000049454e44ae426082);

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
  ADD PRIMARY KEY (`Sub_Order_ID`);

--
-- Indexes for table `restaurant_order_type`
--
ALTER TABLE `restaurant_order_type`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `restaurant_products`
--
ALTER TABLE `restaurant_products`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `restaurant_products_damage`
--
ALTER TABLE `restaurant_products_damage`
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
-- Indexes for table `restaurant_status`
--
ALTER TABLE `restaurant_status`
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
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `restaurant_customers`
--
ALTER TABLE `restaurant_customers`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurant_employee`
--
ALTER TABLE `restaurant_employee`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurant_employee_time_in_out`
--
ALTER TABLE `restaurant_employee_time_in_out`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

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
  MODIFY `Sub_Order_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurant_order_type`
--
ALTER TABLE `restaurant_order_type`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurant_products`
--
ALTER TABLE `restaurant_products`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `restaurant_products_damage`
--
ALTER TABLE `restaurant_products_damage`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

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
-- AUTO_INCREMENT for table `restaurant_status`
--
ALTER TABLE `restaurant_status`
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
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `restaurant_table_booking`
--
ALTER TABLE `restaurant_table_booking`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

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
