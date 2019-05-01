-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Apr 24, 2019 at 07:20 PM
-- Server version: 5.6.41
-- PHP Version: 5.6.38

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `payknife_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `brand`
--

CREATE TABLE `brand` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `is_available` tinyint(1) NOT NULL,
  `sort_order` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `brand`
--

INSERT INTO `brand` (`id`, `name`, `is_available`, `sort_order`) VALUES
(16, 'Asus', 1, 1),
(17, 'Lenovo', 1, 2),
(18, 'Acer', 1, 3),
(19, 'HP', 1, 4),
(20, 'Dell', 1, 6),
(21, 'Apple', 1, 7),
(31, 'Samsung', 1, 8);

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `is_available` tinyint(1) NOT NULL,
  `sort_order` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`id`, `name`, `is_available`, `sort_order`) VALUES
(21, 'Laptop', 1, 1),
(22, 'Computer', 1, 2),
(23, 'Monitor', 1, 3),
(24, 'Tablet', 1, 4),
(27, 'Headphone', 1, 5);

-- --------------------------------------------------------

--
-- Table structure for table `comment`
--

CREATE TABLE `comment` (
  `id` int(11) NOT NULL,
  `subject` varchar(250) NOT NULL,
  `text` text NOT NULL,
  `date` date NOT NULL,
  `user_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `comment`
--

INSERT INTO `comment` (`id`, `subject`, `text`, `date`, `user_id`, `product_id`) VALUES
(19, 'Like it', '+++', '2019-04-24', 10, 21),
(20, '!!', 'Cool', '2019-04-24', 10, 34),
(21, '-', 'Do not like it much', '2019-04-24', 6, 28),
(22, 'omg', 'It\'s me John Doe', '2019-04-24', 1, 28);

-- --------------------------------------------------------

--
-- Table structure for table `message`
--

CREATE TABLE `message` (
  `id` int(11) NOT NULL,
  `text` text NOT NULL,
  `date` date NOT NULL,
  `user_email` varchar(40) NOT NULL,
  `subject_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `message`
--

INSERT INTO `message` (`id`, `text`, `date`, `user_email`, `subject_id`) VALUES
(179, 'Hello world', '2019-04-12', 'sad@asd.asd', 33),
(199, 'I am a guest. Can you make fonts bigger?\n', '2019-04-24', 'guest@email.com', 33);

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

CREATE TABLE `orders` (
  `id` int(11) NOT NULL,
  `status` int(11) NOT NULL,
  `user_email` varchar(150) NOT NULL,
  `user_address` text NOT NULL,
  `user_message` text NOT NULL,
  `date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `orders`
--

INSERT INTO `orders` (`id`, `status`, `user_email`, `user_address`, `user_message`, `date`) VALUES
(61, 1, 'orleon.nilkford@gmail.com', 'New York', 'Faster pls', '2019-04-24'),
(62, 0, 'guest@mail.com', 'Berlin', '', '2019-04-24'),
(63, 3, 'admin@admin.admin', 'Admin', 'Admin is calling', '2019-04-24'),
(64, 0, 'john.doe@my.mail', 'Lorem ipsum', '', '2019-04-24'),
(65, 0, 'john.doe@my.mail', 'Lorem Ipsum', 'Oh yeah', '2019-04-24');

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE `product` (
  `id` int(11) NOT NULL,
  `name` varchar(150) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `is_available` tinyint(1) NOT NULL,
  `description` text NOT NULL,
  `is_new` tinyint(1) NOT NULL,
  `is_comments_available` tinyint(1) NOT NULL,
  `category_id` int(11) DEFAULT NULL,
  `brand_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`id`, `name`, `price`, `is_available`, `description`, `is_new`, `is_comments_available`, `category_id`, `brand_id`) VALUES
(20, 'Acer x254', '1500.00', 1, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras accumsan mi a quam viverra luctus. Suspendisse ut vulputate nisi, nec fermentum libero. Morbi sollicitudin, orci sit amet congue cursus, nibh nunc lobortis orci, et hendrerit arcu nunc a lorem. Curabitur dignissim risus non diam ornare mattis ac vitae elit. Suspendisse euismod gravida diam et varius. Sed quis commodo magna. Nunc a ex nec erat feugiat dapibus. Donec id nulla et dolor efficitur convallis. Maecenas vel sem neque. Vivamus volutpat quam ac urna condimentum, vitae posuere neque scelerisque. Aenean et lacinia dolor.', 0, 1, 21, 18),
(21, 'Asus X55', '2500.00', 1, 'Ut vulputate lacus eget risus porttitor laoreet. Fusce a facilisis dui, sit amet accumsan lectus. Donec suscipit enim sed tellus tincidunt ullamcorper. Proin a gravida odio. Donec porta metus id diam malesuada, eget semper nisi porttitor. Fusce felis ex, tempor non efficitur bibendum, tempor et ex. Nulla aliquet, felis non hendrerit viverra, sapien ex venenatis est, nec vestibulum turpis sapien non mi.', 0, 1, 21, 16),
(22, 'HP 80', '1000.00', 1, 'Aliquam sit amet nibh est. Cras id augue nec est porttitor egestas ac eu tortor. Etiam imperdiet ullamcorper fermentum. Cras mattis ipsum orci, eget pretium risus iaculis aliquam. Sed vestibulum porta elit, nec molestie urna sollicitudin vel. Aenean ut odio ligula. Donec at eros urna. Etiam in congue magna, pulvinar faucibus massa. Interdum et malesuada fames ac ante ipsum primis in faucibus. Fusce purus augue, porta a eros sed, rutrum egestas neque. Nunc et nulla in nisl bibendum interdum. Etiam consequat diam quis ex egestas, a luctus velit gravida. Donec elementum egestas tempor. Sed hendrerit leo lobortis ex varius placerat. Maecenas sodales nisi a lacus aliquet sollicitudin. Sed condimentum lorem quis est feugiat, sit amet volutpat mauris iaculis.', 1, 1, 21, 19),
(23, 'Asus white33', '800.00', 1, 'Ut quis accumsan sapien. Vestibulum pretium eu arcu vel laoreet. Praesent molestie in odio eget gravida. Sed auctor, ex ut cursus consequat, lectus velit semper urna, nec scelerisque metus dui in dui. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur scelerisque est facilisis quam fringilla commodo. Vivamus vulputate, ante ut rhoncus ultricies, odio urna condimentum dolor, et ultrices sem lectus sit amet tellus. Curabitur pulvinar ornare nulla vitae finibus. In arcu sem, faucibus pellentesque egestas eu, facilisis sed risus. Sed lorem ligula, commodo non tellus id, gravida posuere quam. Proin hendrerit fermentum lorem et egestas. Suspendisse vulputate lacus in elementum sodales. Aliquam maximus enim sit amet lectus fermentum tempor. Pellentesque blandit ex eu tempus aliquet. Donec convallis turpis at mauris imperdiet, ac dapibus tellus viverra. Maecenas sed tincidunt nulla.', 0, 1, 21, 16),
(24, 'Acer Y2Y', '1500.00', 1, 'Etiam ullamcorper nunc nulla, ac semper dui porttitor a. Vivamus viverra facilisis eros, sed congue tortor sagittis ac. Integer id justo egestas, eleifend magna a, sagittis lectus. Donec cursus varius lacus, vitae accumsan velit eleifend vitae. Nulla nec purus vitae sem fringilla hendrerit. In commodo ante varius, congue metus non, condimentum augue. Phasellus tellus lorem, porttitor non bibendum id, gravida at urna. Nullam quis purus lorem. Duis pretium ipsum turpis, id commodo ante consectetur eu. Vestibulum auctor est id cursus cursus. Phasellus sit amet cursus nisi.', 1, 1, 21, 18),
(25, 'Acer X586', '1856.00', 1, 'Pellentesque vulputate aliquet ex eu egestas. In a quam posuere, pulvinar orci eget, blandit lectus. Phasellus eget lacinia dui. Suspendisse suscipit sit amet ligula eu aliquam. Nullam consequat lacus quis enim ornare cursus. Fusce suscipit mollis nulla, a tristique nibh cursus eu. Curabitur sem metus, cursus consequat sem finibus, facilisis dignissim nulla. Curabitur ut risus faucibus, dictum mauris ut, feugiat magna.', 1, 1, 21, 18),
(26, 'Lenovo Origami', '3000.00', 1, 'Morbi laoreet arcu vel accumsan scelerisque. Proin a risus et odio tincidunt scelerisque vel ac dolor. Morbi nec iaculis lectus. Aliquam sit amet fringilla arcu. Donec cursus sapien eu ante hendrerit lobortis. Ut malesuada hendrerit ipsum, nec finibus nisi porta vitae. In ac massa ac eros tincidunt gravida et fermentum orci. Duis luctus nisi sit amet aliquet maximus. Curabitur odio sem, rutrum et eleifend ut, convallis sit amet nibh. Donec feugiat libero nec libero commodo vehicula.', 1, 1, 21, 17),
(27, 'Asus Expadus', '2500.00', 1, '', 0, 1, 21, 16),
(28, 'Samsung', '1800.00', 1, 'Suspendisse fringilla lacus et risus mattis mattis. In non nibh eget velit volutpat imperdiet ac sed augue. Aenean at accumsan sapien. Sed porta mattis ante sed pulvinar. Mauris porttitor nisl felis, vitae tristique ex faucibus a. Morbi lorem elit, volutpat sed eros pharetra, ornare commodo neque. Phasellus sed posuere enim. Donec sodales nisl eget maximus ultricies. Donec sed mollis tellus, vitae consequat risus.', 0, 1, 24, 31),
(29, 'Producto Invento', '500.00', 1, 'Maecenas purus mi, consequat convallis venenatis non, vulputate eget eros. Cras tellus odio, finibus vitae mauris et, auctor fermentum mauris. Nulla odio lorem, finibus in venenatis vel, malesuada luctus massa. Cras tempus neque tempus, tincidunt elit in, tristique erat. Nullam lacinia purus malesuada urna facilisis, non ornare lectus fringilla. Proin tortor libero, imperdiet ac pretium non, congue at ex. Etiam fringilla ultricies lacinia. Aenean mattis arcu leo, non pulvinar eros congue at.', 1, 0, 24, 20),
(30, 'SD52', '500.00', 1, '', 1, 1, 23, 20),
(31, 'SystemBlockusX9000', '9999.00', 1, 'Quisque nec lacinia dolor, tincidunt sagittis felis. Praesent sed auctor enim, in cursus nisi. Morbi varius nisi id euismod pulvinar. Fusce non lacinia ipsum, nec commodo lacus. Donec pellentesque dui ut rhoncus fringilla. Proin eget dolor quis leo vulputate elementum. Cras rhoncus vestibulum felis, congue elementum arcu varius ornare. Mauris volutpat nec dui vitae feugiat. Aliquam finibus lorem pretium, sagittis metus id, semper elit. Duis fringilla quam quis accumsan posuere. Maecenas feugiat lectus lorem, sit amet dapibus lorem scelerisque eu. In at nulla arcu. Mauris est sapien, malesuada nec pellentesque ac, condimentum sit amet erat.\n\nIn hac habitasse platea dictumst. Phasellus eget vehicula metus. Nullam porta eu ligula quis ornare. Morbi ultrices arcu vel purus convallis, in auctor justo viverra. Duis vel viverra libero, non malesuada est. Sed et dignissim ante, eget tempus sapien. Morbi pharetra viverra ipsum, a eleifend urna commodo at. Nulla in metus id magna dapibus pellentesque. Fusce nec turpis consequat, venenatis lorem sit amet, posuere libero. Donec sed tortor sed massa rutrum fermentum sed sed risus. Fusce vitae justo posuere, convallis urna aliquam, volutpat enim. Fusce feugiat nisi ante, vel rutrum ex imperdiet quis. Integer ac leo dictum leo placerat interdum nec nec sapien.', 0, 0, 22, 19),
(32, 'HP 865', '856.00', 1, '', 0, 1, 21, 19),
(33, 'Apple Moestro', '6800.00', 1, 'Interdum et malesuada fames ac ante ipsum primis in faucibus. Proin ac eleifend magna, nec bibendum velit. Suspendisse volutpat tempus nibh, vel euismod ante luctus ut. In faucibus, sapien ut lobortis placerat, nunc tellus elementum ex, in luctus felis ante eget velit. Sed eget dictum nunc, at placerat ex. Proin sagittis mollis nulla ut laoreet. Suspendisse malesuada sollicitudin sem sit amet egestas. In ut ipsum nulla. Nullam sed mi quam. Cras malesuada justo rhoncus, aliquam leo nec, pellentesque ligula. Phasellus eget tristique dui.', 1, 1, 21, 21),
(34, 'Compilus', '8844.00', 1, '', 1, 1, 22, 17),
(35, 'Asus 565', '500.00', 1, '', 0, 0, 21, 16),
(36, 'Asus 87', '800.00', 1, '', 0, 0, 21, 16),
(37, 'Asus AS', '800.00', 0, '', 0, 0, 21, 16),
(38, 'Asus OX5', '8556.00', 1, '', 0, 0, 21, 16),
(39, 'Asus OI8', '805.00', 1, '', 0, 0, 21, 16);

-- --------------------------------------------------------

--
-- Table structure for table `product_order`
--

CREATE TABLE `product_order` (
  `order_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `product_count` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `product_order`
--

INSERT INTO `product_order` (`order_id`, `product_id`, `product_count`) VALUES
(61, 21, 1),
(61, 23, 1),
(61, 27, 1),
(61, 34, 2),
(62, 28, 1),
(63, 28, 1),
(64, 20, 1),
(64, 25, 1),
(64, 39, 1),
(65, 28, 1);

-- --------------------------------------------------------

--
-- Table structure for table `rating`
--

CREATE TABLE `rating` (
  `user_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `rate_mark` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `rating`
--

INSERT INTO `rating` (`user_id`, `product_id`, `rate_mark`) VALUES
(1, 20, 4),
(1, 28, 4),
(1, 39, 3),
(6, 28, 3),
(10, 21, 4),
(10, 34, 5);

-- --------------------------------------------------------

--
-- Table structure for table `subject`
--

CREATE TABLE `subject` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `subject`
--

INSERT INTO `subject` (`id`, `name`) VALUES
(37, 'Error'),
(34, 'Question'),
(35, 'Respond'),
(33, 'Suggestion'),
(36, 'Typos');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `nickname` varchar(25) NOT NULL,
  `email` varchar(40) NOT NULL,
  `password` varchar(50) NOT NULL,
  `role` tinyint(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`id`, `nickname`, `email`, `password`, `role`) VALUES
(1, 'John Doe', 'john.doe@my.mail', '1111', 1),
(6, 'Name', 'admin@admin.admin', '1111', 2),
(8, 'glk', 'asd@asd.asdj', '1111', 0),
(10, 'gl', 'orleon.nilkford@gmail.com', '1111', 2),
(12, 'new usero', 'asd@asd.asd', '1111', 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `brand`
--
ALTER TABLE `brand`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `name` (`name`);

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `name` (`name`);

--
-- Indexes for table `comment`
--
ALTER TABLE `comment`
  ADD PRIMARY KEY (`id`),
  ADD KEY `user_id` (`user_id`),
  ADD KEY `product_id` (`product_id`);

--
-- Indexes for table `message`
--
ALTER TABLE `message`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `product_order`
--
ALTER TABLE `product_order`
  ADD PRIMARY KEY (`order_id`,`product_id`);

--
-- Indexes for table `rating`
--
ALTER TABLE `rating`
  ADD PRIMARY KEY (`user_id`,`product_id`),
  ADD KEY `product_constraint` (`product_id`);

--
-- Indexes for table `subject`
--
ALTER TABLE `subject`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unique_subject_name` (`name`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `email` (`email`),
  ADD UNIQUE KEY `nickname` (`nickname`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `brand`
--
ALTER TABLE `brand`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `category`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT for table `comment`
--
ALTER TABLE `comment`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT for table `message`
--
ALTER TABLE `message`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=200;

--
-- AUTO_INCREMENT for table `orders`
--
ALTER TABLE `orders`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=66;

--
-- AUTO_INCREMENT for table `product`
--
ALTER TABLE `product`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=40;

--
-- AUTO_INCREMENT for table `subject`
--
ALTER TABLE `subject`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=38;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `comment`
--
ALTER TABLE `comment`
  ADD CONSTRAINT `comment_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `comment_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `product` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `rating`
--
ALTER TABLE `rating`
  ADD CONSTRAINT `product_constraint` FOREIGN KEY (`product_id`) REFERENCES `product` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `user_constraint` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
