-- phpMyAdmin SQL Dump
-- version 4.9.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Dec 11, 2021 at 01:14 PM
-- Server version: 5.6.51-cll-lve
-- PHP Version: 7.3.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `shared_csaml`
--

-- --------------------------------------------------------

--
-- Table structure for table `bordereau`
--

CREATE TABLE `bordereau` (
  `cod_site` int(11) DEFAULT NULL,
  `cod_section` int(11) DEFAULT NULL,
  `cod_task` int(11) NOT NULL,
  `previous_task` int(11) NOT NULL DEFAULT '0',
  `contractor_ref` text NOT NULL,
  `descricao` text NOT NULL,
  `pu` float DEFAULT NULL,
  `qtd` float DEFAULT NULL,
  `units` tinytext NOT NULL,
  `translations` text NOT NULL,
  `enabled` tinyint(1) DEFAULT NULL,
  `avenant` varchar(1) NOT NULL DEFAULT 'n'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `bordereau`
--

INSERT INTO `bordereau` (`cod_site`, `cod_section`, `cod_task`, `previous_task`, `contractor_ref`, `descricao`, `pu`, `qtd`, `units`, `translations`, `enabled`, `avenant`) VALUES
(1, 1, 1, 0, '6.3.8.1', 'Betonblokvol 29x19x19', 35, 822684, 'm2', '{\"pt\":\"Bloco de betão completo 29x19x19\",\"fr\":\"Bloc de béton plein 29x19x19\",\"nl\":\"Betonblokvol 29x19x19\",\"en\":\"Concrete block full 29x19x19\"}', 1, 'n'),
(1, 1, 2, 0, '6.3.8.1', 'Voegwerk achter de hand', 3, 1645370, 'm2', '{\"pt\":\"Articulação atrás da mão\",\"fr\":\"Jointure derrière la main\",\"nl\":\"Voegwerk achter de hand\",\"en\":\"Jointing behind the hand\"}', 1, 'n'),
(1, 1, 3, 0, '6.3.8.1', 'Lev + pla DPC folie', 0, 52.4, 'm2', '{\"pt\":\"Folha DPC Lev + pla\",\"fr\":\"Feuille DPC Lev + pla\",\"nl\":\"Lev + pla DPC folie\",\"en\":\"Lev + pla DPC foil\"}', 0, 'n'),
(1, 1, 4, 0, '', 'Betonblok vol 29x19x19', 35, 14105, 'm2', '{\"pt\":\"Bloco de betão completo 29x19x19\",\"fr\":\"Bloc de béton plein 29x19x19\",\"nl\":\"Betonblok vol 29x19x19\",\"en\":\"Concrete block full 29x19x19\"}', 1, 'n'),
(1, 1, 5, 0, '', 'Voegwerk achter de hand', 3, 28211, 'm2', '{\"pt\":\"Articulação atrás da mão\",\"fr\":\"Jointure derrière la main\",\"nl\":\"Voegwerk achter de hand\",\"en\":\"Jointing behind the hand\"}', 1, 'n'),
(1, 1, 6, 0, '', 'Lev + pla DPC folie', 0, 0.898, 'm2', '{\"pt\":\"Folha DPC Lev + pla\",\"fr\":\"Feuille DPC Lev + pla\",\"nl\":\"Lev + pla DPC folie\",\"en\":\"Lev + pla DPC foil\"}', 0, 'n'),
(1, 1, 7, 0, '6.3.8.2', 'Betonblokvol 29x9x19', 35, 26889, 'm2', '{\"pt\":\"Bloco de betão completo 29x9x19\",\"fr\":\"Bloc de béton plein 29x9x19\",\"nl\":\"Betonblokvol 29x9x19\",\"en\":\"Concrete block full 29x9x19\"}', 1, 'n'),
(1, 1, 8, 0, '6.3.8.2', 'Lev + pla DPC folie', 3, 1613, 'm2', '{\"pt\":\"Folha DPC Lev + pla\",\"fr\":\"Feuille DPC Lev + pla\",\"nl\":\"Lev + pla DPC folie\",\"en\":\"Lev + pla DPC foil\"}', 1, 'n'),
(1, 1, 9, 0, '6.3.8.3', 'Gevelmetselwerk klassiek 19x9x6.5', 35, 33.8, 'm2', '{\"pt\":\"Fachada em alvenaria clássica 19x9x6.5\",\"fr\":\"Maçonnerie de façade classique 19x9x6,5\",\"nl\":\"Gevelmetselwerk klassiek 19x9x6.5\",\"en\":\"Façade masonry classic 19x9x6.5\"}', 1, 'n'),
(1, 1, 10, 0, '6.3.8.3', 'gevel: voegwerk', 0, 33.8, 'm2', '{\"pt\":\"fachada: junção\",\"fr\":\"façade: jointoiement\",\"nl\":\"gevel: voegwerk\",\"en\":\"facade: jointing\"}', 0, 'n'),
(1, 1, 11, 0, '', 'Lev + pla dorpel', 32, 12.6, 'm', '{\"pt\":\"Lev + pla peitoril\",\"fr\":\"Lev + pla sill\",\"nl\":\"Lev + pla dorpel\",\"en\":\"Lev + pla sill\"}', 1, 'n'),
(1, 1, 12, 0, 'B', 'STABILITE', 0, 0, '', '{\"pt\":\"ESTABILIDADE\",\"fr\":\"STABILITE\",\"nl\":\"STABILITE\",\"en\":\"STABILITE\"}', 2, 'n'),
(1, 1, 13, 0, '22.11.1a', 'Beton balk', 30, 4.83, 'm3', '{\"pt\":\"Viga em betão\",\"fr\":\"Poutre en béton\",\"nl\":\"Beton balk\",\"en\":\"Concrete beam\"}', 1, 'n'),
(1, 1, 14, 0, '22.14.1a', 'Beton kolom', 30, 39.42, 'm3', '{\"pt\":\"Coluna de betão\",\"fr\":\"Colonne en béton\",\"nl\":\"Beton kolom\",\"en\":\"Concrete column\"}', 1, 'n'),
(1, 1, 15, 0, '22.14.1a', 'Beton kolom', 30, 22.08, 'm3', '{\"pt\":\"Coluna de betão\",\"fr\":\"Colonne en béton\",\"nl\":\"Beton kolom\",\"en\":\"Concrete column\"}', 1, 'n'),
(1, 1, 16, 0, '', 'Bekisting kolom', 39, 455.31, 'm2', '{\"pt\":\"Coluna de cofragem\",\"fr\":\"Colonne de coffrage\",\"nl\":\"Bekisting kolom\",\"en\":\"Formwork column\"}', 1, 'n'),
(1, 1, 17, 0, '22.14.1b', 'Beton kolom', 30, 14.17, 'm3', '{\"pt\":\"Coluna de betão\",\"fr\":\"Colonne en béton\",\"nl\":\"Beton kolom\",\"en\":\"Concrete column\"}', 1, 'n'),
(1, 1, 18, 0, '22.14.1b', 'Beton kolom', 30, 7.39, 'm3', '{\"pt\":\"Coluna de betão\",\"fr\":\"Colonne en béton\",\"nl\":\"Beton kolom\",\"en\":\"Concrete column\"}', 1, 'n'),
(1, 1, 19, 0, '', 'Bekisting kolom', 39, 103.5, 'm2', '{\"pt\":\"Coluna de cofragem\",\"fr\":\"Colonne de coffrage\",\"nl\":\"Bekisting kolom\",\"en\":\"Formwork column\"}', 1, 'n'),
(1, 1, 20, 0, '22.14.1c', 'Beton kolom', 30, 7.62, 'm3', '{\"pt\":\"Coluna de betão\",\"fr\":\"Colonne en béton\",\"nl\":\"Beton kolom\",\"en\":\"Concrete column\"}', 1, 'n'),
(1, 1, 21, 0, '22.14.1c', 'Beton kolom', 39, 11.25, 'm3', '{\"pt\":\"Coluna de betão\",\"fr\":\"Colonne en béton\",\"nl\":\"Beton kolom\",\"en\":\"Concrete column\"}', 1, 'n'),
(1, 1, 22, 0, '', 'Bekisting kolom', 30, 33.9, 'm2', '{\"pt\":\"Coluna de cofragem\",\"fr\":\"Colonne de coffrage\",\"nl\":\"Bekisting kolom\",\"en\":\"Formwork column\"}', 1, 'n'),
(1, 1, 23, 0, '', 'Bekisting kolom', 39, 82.62, 'm2', '{\"pt\":\"Coluna de cofragem\",\"fr\":\"Colonne de coffrage\",\"nl\":\"Bekisting kolom\",\"en\":\"Formwork column\"}', 1, 'n'),
(1, 1, 24, 0, '22.15.1a', 'Beton plaat', 30, 98.02, 'm3', '{\"pt\":\"Laje de betão\",\"fr\":\"Dalle en béton\",\"nl\":\"Beton plaat\",\"en\":\"Concrete slab\"}', 1, 'n'),
(1, 1, 25, 0, '', 'Bekisting plaat', 39, 477.8, 'm2', '{\"pt\":\"Placa de cofragem\",\"fr\":\"Plaque de coffrage\",\"nl\":\"Bekisting plaat\",\"en\":\"Formwork plate\"}', 1, 'n'),
(1, 1, 26, 0, '22.51.1a', 'Wapening staven', 0.35, 23409, 'kg', '{\"pt\":\"Barras de vergalhões\",\"fr\":\"Barres d\'armature\",\"nl\":\"Wapening staven\",\"en\":\"Rebar bars\"}', 1, 'n'),
(1, 1, 27, 0, '22.51.2a', 'Wapening netten', 0.35, 8787, 'kg', '{\"pt\":\"Redes de reforço\",\"fr\":\"Filets de renfort\",\"nl\":\"Wapening netten\",\"en\":\"Reinforcement nets\"}', 1, 'n'),
(1, 1, 28, 0, 'PARTIE 2', 'PARTIE ARRIERE', 0, 0, '', '{\"pt\":\"PARTE TRASEIRA\",\"fr\":\"PARTIE ARRIERE\",\"nl\":\"PARTIE ARRIERE\",\"en\":\"PARTIE ARRIERE\"}', 2, 'n'),
(1, 1, 29, 0, '22.1.', 'Beton balk', 30, 4.9, 'm3', '{\"pt\":\"Viga em betão\",\"fr\":\"Poutre en béton\",\"nl\":\"Beton balk\",\"en\":\"Concrete beam\"}', 1, 'n'),
(1, 1, 30, 0, '', 'Bekisting balk', 39, 54.76, 'm2', '{\"pt\":\"Feixe de cofragem\",\"fr\":\"Poutre de coffrage\",\"nl\":\"Bekisting balk\",\"en\":\"Formwork beam\"}', 1, 'n'),
(1, 1, 31, 0, '22.2.', 'Beton plaat', 30, 2.4, 'm3', '{\"pt\":\"Laje de betão\",\"fr\":\"Dalle en béton\",\"nl\":\"Beton plaat\",\"en\":\"Concrete slab\"}', 1, 'n'),
(1, 1, 32, 0, '', 'Bekisting plaat', 39, 12, 'm2', '{\"pt\":\"Placa de cofragem\",\"fr\":\"Plaque de coffrage\",\"nl\":\"Bekisting plaat\",\"en\":\"Formwork plate\"}', 1, 'n'),
(1, 1, 33, 0, '', 'Beton plaat', 30, 68.21, 'm3', '{\"pt\":\"Laje de betão\",\"fr\":\"Dalle en béton\",\"nl\":\"Beton plaat\",\"en\":\"Concrete slab\"}', 1, 'n'),
(1, 1, 34, 0, '22.4', 'Beton trap', 30, 6.31, 'm3', '{\"pt\":\"Escadas em betão\",\"fr\":\"Escaliers en béton\",\"nl\":\"Beton trap\",\"en\":\"Concrete stairs\"}', 1, 'n'),
(1, 1, 35, 0, '', 'Bekisting balk', 100, 46.9, 'm2', '{\"pt\":\"Feixe de cofragem\",\"fr\":\"Poutre de coffrage\",\"nl\":\"Bekisting balk\",\"en\":\"Formwork beam\"}', 1, 'n'),
(1, 1, 36, 0, '', 'New task', NULL, NULL, 'ml', '', 1, 's');

-- --------------------------------------------------------

--
-- Table structure for table `bordereau_task_plan`
--

CREATE TABLE `bordereau_task_plan` (
  `cod_task_plan` int(11) NOT NULL,
  `cod_task` int(11) NOT NULL,
  `cod_site` int(11) NOT NULL,
  `cod_section` int(11) NOT NULL,
  `cod_worker` int(11) NOT NULL,
  `start` time NOT NULL,
  `end` time NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `cod_category` int(11) NOT NULL,
  `reference` tinytext NOT NULL,
  `name` text NOT NULL,
  `namefr` tinytext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`cod_category`, `reference`, `name`, `namefr`) VALUES
(1, 'frm', 'foreman', '');

-- --------------------------------------------------------

--
-- Table structure for table `crash_report`
--

CREATE TABLE `crash_report` (
  `cod_report` int(11) NOT NULL,
  `cod_nfc` text NOT NULL,
  `report` text NOT NULL,
  `date` date NOT NULL DEFAULT '1970-01-01',
  `time` time NOT NULL DEFAULT '00:00:00'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `crash_report`
--

INSERT INTO `crash_report` (`cod_report`, `cod_nfc`, `report`, `date`, `time`) VALUES
(1, '', 'test', '2020-03-03', '16:36:49'),
(2, '', 'After parsing a value an unexpected character was encountered: w. Path message, line 1, position 107.\r\n--------- Stack trace ---------\r\n----------03/03/2020 16:54:28----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParsePostValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.Serialization.JsonSerializerInternalReader PopulateDictionary\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader CreateObject\r\n5- Newtonsoft.Json.Serialization.JsonSerializerInternalReader CreateValueInternal\r\n6- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n7- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- Newtonsoft.Json.JsonConvert DeserializeObject\r\n10- Newtonsoft.Json.JsonConvert DeserializeObject\r\n11- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-03-03', '16:55:08'),
(3, '', 'Lindex se trouve en dehors des limites du tableau.\r\n--------- Stack trace ---------\r\n----------04-03-20 09:17:22----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- ConstructionSiteLogistics.multiday_frm checkMotifEnabled\r\n2- ConstructionSiteLogistics.multiday_frm Button1_Click\r\n3- System.Windows.Forms.Control OnClick\r\n4- System.Windows.Forms.Button OnClick\r\n5- System.Windows.Forms.Button OnMouseUp\r\n6- System.Windows.Forms.Control WmMouseUp\r\n7- System.Windows.Forms.Control WndProc\r\n8- System.Windows.Forms.ButtonBase WndProc\r\n9- System.Windows.Forms.Button WndProc\r\n10- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n11- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n12- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-04', '09:18:05'),
(4, '', 'La rÃ©fÃ©rence dobjet nest pas dÃ©finie Ã  une instance dun objet.\r\n--------- Stack trace ---------\r\n----------03-03-20 17:20:51----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- ConstructionSiteLogistics.report_frm relatorio_resumo\r\n2- ConstructionSiteLogistics.report_frm load_grid\r\n3- ConstructionSiteLogistics.report_frm LoadReport_Click\r\n4- System.Windows.Forms.Control OnClick\r\n5- System.Windows.Forms.Control WmMouseUp\r\n6- System.Windows.Forms.Control WndProc\r\n7- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n8- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n9- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-04', '09:28:49'),
(5, '', 'La chaÃ®ne na pas Ã©tÃ© reconnue en tant que DateTime valide.\r\n--------- Stack trace ---------\r\n----------04-03-20 18:18:56----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.DateTimeParse ParseExact\r\n2- System.DateTime ParseExact\r\n3- ConstructionSiteLogistics.logday_frm logday_frm_Load\r\n4- System.Windows.Forms.Form OnLoad\r\n5- System.Windows.Forms.Form SetVisibleCore\r\n6- System.Windows.Forms.Control set_Visible\r\n7- System.Windows.Forms.Application+ThreadContext RunMessageLoopInner\r\n8- System.Windows.Forms.Application+ThreadContext RunMessageLoop\r\n9- System.Windows.Forms.Application RunDialog\r\n10- System.Windows.Forms.Form ShowDialog\r\n11- System.Windows.Forms.Form ShowDialog\r\n12- ConstructionSiteLogistics.logger_frm datatable_CellMouseDoubleClick\r\n13- System.Windows.Forms.DataGridView OnCellMouseDoubleClick\r\n14- System.Windows.Forms.DataGridView OnMouseDoubleClick\r\n15- System.Windows.Forms.Control WmMouseUp\r\n16- System.Windows.Forms.Control WndProc\r\n17- System.Windows.Forms.DataGridView WndProc\r\n18- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n19- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n20- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-04', '18:19:36'),
(6, '', 'La chaÃ®ne na pas Ã©tÃ© reconnue en tant que DateTime valide.\r\n--------- Stack trace ---------\r\n----------04-03-20 18:21:04----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.DateTimeParse ParseExact\r\n2- System.DateTime ParseExact\r\n3- ConstructionSiteLogistics.logday_frm logday_frm_Load\r\n4- System.Windows.Forms.Form OnLoad\r\n5- System.Windows.Forms.Form OnCreateControl\r\n6- System.Windows.Forms.Control CreateControl\r\n7- System.Windows.Forms.Control CreateControl\r\n8- System.Windows.Forms.Control WmShowWindow\r\n9- System.Windows.Forms.Control WndProc\r\n10- System.Windows.Forms.ScrollableControl WndProc\r\n11- System.Windows.Forms.Form WmShowWindow\r\n12- System.Windows.Forms.Form WndProc\r\n13- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n14- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n15- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-04', '18:21:46'),
(7, '', 'Lindex Ã©tait hors limites. Il ne doit pas Ãªtre nÃ©gatif et doit Ãªtre infÃ©rieur Ã  la taille de la collection.\r\nNom du paramÃ¨treÂ : index\r\n--------- Stack trace ---------\r\n----------05-03-20 14:50:21----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:s()\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.ThrowHelper ThrowArgumentOutOfRangeException\r\n2- System.Collections.Generic.List`1[T] get_Item\r\n3- ConstructionSiteLogistics.SiteLivraisonEdit SiteLivraisonEdit_shown\r\n4- System.Windows.Forms.Form OnShown\r\n5- System.Windows.Forms.Form CallShownEvent\r\n6- System.Windows.Forms.Control InvokeMarshaledCallbackDo\r\n7- System.Windows.Forms.Control InvokeMarshaledCallbackHelper\r\n8- System.Threading.ExecutionContext RunInternal\r\n9- System.Threading.ExecutionContext Run\r\n10- System.Threading.ExecutionContext Run\r\n11- System.Windows.Forms.Control InvokeMarshaledCallback\r\n12- System.Windows.Forms.Control InvokeMarshaledCallbacks\r\n', '2020-03-05', '14:51:11'),
(8, '', 'Lindex Ã©tait hors limites. Il ne doit pas Ãªtre nÃ©gatif et doit Ãªtre infÃ©rieur Ã  la taille de la collection.\r\nNom du paramÃ¨treÂ : index\r\n--------- Stack trace ---------\r\n----------05-03-20 14:52:06----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:s()\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.ThrowHelper ThrowArgumentOutOfRangeException\r\n2- System.Collections.Generic.List`1[T] get_Item\r\n3- ConstructionSiteLogistics.SiteLivraisonEdit SiteLivraisonEdit_shown\r\n4- System.Windows.Forms.Form OnShown\r\n5- System.Windows.Forms.Form CallShownEvent\r\n6- System.Windows.Forms.Control InvokeMarshaledCallbackDo\r\n7- System.Windows.Forms.Control InvokeMarshaledCallbackHelper\r\n8- System.Threading.ExecutionContext RunInternal\r\n9- System.Threading.ExecutionContext Run\r\n10- System.Threading.ExecutionContext Run\r\n11- System.Windows.Forms.Control InvokeMarshaledCallback\r\n12- System.Windows.Forms.Control InvokeMarshaledCallbacks\r\n', '2020-03-05', '14:52:43'),
(9, '', 'InvalidArgument=La valeur 0 nest pas valide pour SelectedIndex.\r\nNom du paramÃ¨treÂ : SelectedIndex\r\n--------- Stack trace ---------\r\n----------04-03-20 09:29:25----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Windows.Forms.ComboBox set_SelectedIndex\r\n2- ConstructionSiteLogistics.report_frm CheckBox_obra_CheckedChanged\r\n3- System.Windows.Forms.CheckBox OnCheckedChanged\r\n4- System.Windows.Forms.CheckBox set_CheckState\r\n5- System.Windows.Forms.CheckBox OnClick\r\n6- System.Windows.Forms.CheckBox OnMouseUp\r\n7- System.Windows.Forms.Control WmMouseUp\r\n8- System.Windows.Forms.Control WndProc\r\n9- System.Windows.Forms.ButtonBase WndProc\r\n10- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n11- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n12- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-06', '11:59:26'),
(10, '', 'Unexpected character encountered while parsing value: E. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06-03-20 12:08:24----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-03-06', '12:10:17'),
(11, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: E. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06-03-20 12:08:53----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-03-06', '12:10:17'),
(12, '', 'O servidor remoto devolveu um erro: (404) NÃ£o encontrado.\r\n--------- Stack trace ---------\r\n----------06/03/2020 12:03:08----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:nt)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Net.HttpWebRequest GetResponse\r\n2- ConstructionSiteLogistics.DownloadForm bwSites_DoWork\r\n3- System.ComponentModel.BackgroundWorker OnDoWork\r\n4- System.ComponentModel.BackgroundWorker WorkerThreadStart\r\n', '2020-03-06', '13:04:02'),
(13, '', 'A referÃªncia de objecto nÃ£o foi definida como uma instÃ¢ncia de um objecto.\r\n--------- Stack trace ---------\r\n----------06/03/2020 12:05:12----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:rg)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- ConstructionSiteLogistics.DownloadForm bwSites_RunWorkerCompleted\r\n2- System.ComponentModel.BackgroundWorker OnRunWorkerCompleted\r\n3- System.ComponentModel.BackgroundWorker AsyncOperationCompleted\r\n', '2020-03-06', '15:23:48'),
(14, '', '\r\n\r\n\r\nO sistema nÃ£o conseguiu localizar o ficheiro especificado\r\n--------- Stack trace ---------\r\n----------06/03/2020 12:05:17----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Diagnostics.Process StartWithShellExecuteEx\r\n2- System.Diagnostics.Process Start\r\n3- System.Diagnostics.Process Start\r\n4- ConstructionSiteLogistics.workers_frm ccimg_Click\r\n5- System.Windows.Forms.Control OnClick\r\n6- System.Windows.Forms.Control WmMouseUp\r\n7- System.Windows.Forms.Control WndProc\r\n8- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n9- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n10- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-06', '15:23:48'),
(15, '', '\r\n\r\n\r\nA referÃªncia de objecto nÃ£o foi definida como uma instÃ¢ncia de um objecto.\r\n--------- Stack trace ---------\r\n----------06/03/2020 12:05:19----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:rg)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- ConstructionSiteLogistics.DownloadForm bwSites_RunWorkerCompleted\r\n2- System.ComponentModel.BackgroundWorker OnRunWorkerCompleted\r\n3- System.ComponentModel.BackgroundWorker AsyncOperationCompleted\r\n', '2020-03-06', '15:23:49'),
(16, '', '\r\n\r\n\r\nO sistema nÃ£o conseguiu localizar o ficheiro especificado\r\n--------- Stack trace ---------\r\n----------06/03/2020 12:05:21----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Diagnostics.Process StartWithShellExecuteEx\r\n2- System.Diagnostics.Process Start\r\n3- System.Diagnostics.Process Start\r\n4- ConstructionSiteLogistics.workers_frm ccimg_Click\r\n5- System.Windows.Forms.Control OnClick\r\n6- System.Windows.Forms.Control WmMouseUp\r\n7- System.Windows.Forms.Control WndProc\r\n8- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n9- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n10- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-06', '15:23:49'),
(17, '', '\r\n\r\n\r\nO sistema nÃ£o conseguiu localizar o ficheiro especificado\r\n--------- Stack trace ---------\r\n----------06/03/2020 12:05:23----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Diagnostics.Process StartWithShellExecuteEx\r\n2- System.Diagnostics.Process Start\r\n3- System.Diagnostics.Process Start\r\n4- ConstructionSiteLogistics.workers_frm actImg_Click\r\n5- System.Windows.Forms.Control OnClick\r\n6- System.Windows.Forms.Control WmMouseUp\r\n7- System.Windows.Forms.Control WndProc\r\n8- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n9- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n10- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-06', '15:23:49'),
(18, '', '\r\n\r\n\r\nO sistema nÃ£o conseguiu localizar o ficheiro especificado\r\n--------- Stack trace ---------\r\n----------06/03/2020 12:05:30----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Diagnostics.Process StartWithShellExecuteEx\r\n2- System.Diagnostics.Process Start\r\n3- System.Diagnostics.Process Start\r\n4- ConstructionSiteLogistics.workers_frm actImg_Click\r\n5- System.Windows.Forms.Control OnClick\r\n6- System.Windows.Forms.Control WmMouseUp\r\n7- System.Windows.Forms.Control WndProc\r\n8- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n9- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n10- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-06', '15:23:49'),
(19, '', '\r\n\r\n\r\nO servidor remoto devolveu um erro: (404) NÃ£o encontrado.\r\n--------- Stack trace ---------\r\n----------06/03/2020 12:05:41----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:nt)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Net.HttpWebRequest GetResponse\r\n2- ConstructionSiteLogistics.DownloadForm bwSites_DoWork\r\n3- System.ComponentModel.BackgroundWorker OnDoWork\r\n4- System.ComponentModel.BackgroundWorker WorkerThreadStart\r\n', '2020-03-06', '15:23:49'),
(20, '', '\r\n\r\n\r\nO sistema nÃ£o conseguiu localizar o ficheiro especificado\r\n--------- Stack trace ---------\r\n----------06/03/2020 12:05:47----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Diagnostics.Process StartWithShellExecuteEx\r\n2- System.Diagnostics.Process Start\r\n3- System.Diagnostics.Process Start\r\n4- ConstructionSiteLogistics.workers_frm ccimg_Click\r\n5- System.Windows.Forms.Control OnClick\r\n6- System.Windows.Forms.Control WmMouseUp\r\n7- System.Windows.Forms.Control WndProc\r\n8- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n9- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n10- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-06', '15:23:49'),
(21, '', '\r\n\r\n\r\nO servidor remoto devolveu um erro: (404) NÃ£o encontrado.\r\n--------- Stack trace ---------\r\n----------06/03/2020 12:06:36----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:nt)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Net.HttpWebRequest GetResponse\r\n2- ConstructionSiteLogistics.DownloadForm bwSites_DoWork\r\n3- System.ComponentModel.BackgroundWorker OnDoWork\r\n4- System.ComponentModel.BackgroundWorker WorkerThreadStart\r\n', '2020-03-06', '15:23:49'),
(22, '', '\r\n\r\n\r\nO sistema nÃ£o conseguiu localizar o ficheiro especificado\r\n--------- Stack trace ---------\r\n----------06/03/2020 12:06:48----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Diagnostics.Process StartWithShellExecuteEx\r\n2- System.Diagnostics.Process Start\r\n3- System.Diagnostics.Process Start\r\n4- ConstructionSiteLogistics.workers_frm ccimg_Click\r\n5- System.Windows.Forms.Control OnClick\r\n6- System.Windows.Forms.Control WmMouseUp\r\n7- System.Windows.Forms.Control WndProc\r\n8- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n9- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n10- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-06', '15:23:50'),
(23, '', '\r\n\r\n\r\nO servidor remoto devolveu um erro: (404) NÃ£o encontrado.\r\n--------- Stack trace ---------\r\n----------06/03/2020 12:09:43----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:nt)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Net.HttpWebRequest GetResponse\r\n2- ConstructionSiteLogistics.DownloadForm bwSites_DoWork\r\n3- System.ComponentModel.BackgroundWorker OnDoWork\r\n4- System.ComponentModel.BackgroundWorker WorkerThreadStart\r\n', '2020-03-06', '15:23:50'),
(24, '', '\r\n\r\n\r\nO sistema nÃ£o conseguiu localizar o ficheiro especificado\r\n--------- Stack trace ---------\r\n----------06/03/2020 12:09:45----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Diagnostics.Process StartWithShellExecuteEx\r\n2- System.Diagnostics.Process Start\r\n3- System.Diagnostics.Process Start\r\n4- ConstructionSiteLogistics.workers_frm ccimg_Click\r\n5- System.Windows.Forms.Control OnClick\r\n6- System.Windows.Forms.Control WmMouseUp\r\n7- System.Windows.Forms.Control WndProc\r\n8- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n9- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n10- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-06', '15:23:50'),
(25, '', 'O servidor remoto devolveu um erro: (404) NÃ£o encontrado.\r\n--------- Stack trace ---------\r\n----------06/03/2020 14:34:25----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:nt)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Net.HttpWebRequest GetResponse\r\n2- ConstructionSiteLogistics.DownloadForm bwSites_DoWork\r\n3- System.ComponentModel.BackgroundWorker OnDoWork\r\n4- System.ComponentModel.BackgroundWorker WorkerThreadStart\r\n', '2020-03-06', '15:53:00'),
(26, '', '\r\n\r\n\r\nO sistema nÃ£o conseguiu localizar o ficheiro especificado\r\n--------- Stack trace ---------\r\n----------06/03/2020 14:34:38----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Diagnostics.Process StartWithShellExecuteEx\r\n2- System.Diagnostics.Process Start\r\n3- System.Diagnostics.Process Start\r\n4- ConstructionSiteLogistics.workers_frm ccimg_Click\r\n5- System.Windows.Forms.Control OnClick\r\n6- System.Windows.Forms.Control WmMouseUp\r\n7- System.Windows.Forms.Control WndProc\r\n8- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n9- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n10- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-06', '15:53:00'),
(27, '', 'Lindex Ã©tait hors limites. Il ne doit pas Ãªtre nÃ©gatif et doit Ãªtre infÃ©rieur Ã  la taille de la collection.\r\nNom du paramÃ¨treÂ : index\r\n--------- Stack trace ---------\r\n----------06-03-20 15:44:59----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:s()\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.ThrowHelper ThrowArgumentOutOfRangeException\r\n2- ConstructionSiteLogistics.SiteLivraisonEdit SiteLivraisonEdit_shown\r\n3- System.Windows.Forms.Form OnShown\r\n4- System.Windows.Forms.Form CallShownEvent\r\n5- System.Windows.Forms.Control InvokeMarshaledCallbackDo\r\n6- System.Windows.Forms.Control InvokeMarshaledCallbackHelper\r\n7- System.Threading.ExecutionContext RunInternal\r\n8- System.Threading.ExecutionContext Run\r\n9- System.Threading.ExecutionContext Run\r\n10- System.Windows.Forms.Control InvokeMarshaledCallback\r\n11- System.Windows.Forms.Control InvokeMarshaledCallbacks\r\n', '2020-03-06', '16:45:02'),
(28, '', 'Lindex Ã©tait hors limites. Il ne doit pas Ãªtre nÃ©gatif et doit Ãªtre infÃ©rieur Ã  la taille de la collection.\r\nNom du paramÃ¨treÂ : index\r\n--------- Stack trace ---------\r\n----------06-03-20 17:56:34----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:s()\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.ThrowHelper ThrowArgumentOutOfRangeException\r\n2- ConstructionSiteLogistics.SiteLivraisonEdit SiteLivraisonEdit_shown\r\n3- System.Windows.Forms.Form OnShown\r\n4- System.Windows.Forms.Form CallShownEvent\r\n5- System.Windows.Forms.Control InvokeMarshaledCallbackDo\r\n6- System.Windows.Forms.Control InvokeMarshaledCallbackHelper\r\n7- System.Threading.ExecutionContext RunInternal\r\n8- System.Threading.ExecutionContext Run\r\n9- System.Threading.ExecutionContext Run\r\n10- System.Windows.Forms.Control InvokeMarshaledCallback\r\n11- System.Windows.Forms.Control InvokeMarshaledCallbacks\r\n', '2020-03-06', '17:57:20'),
(29, '', 'Lindex Ã©tait hors limites. Il ne doit pas Ãªtre nÃ©gatif et doit Ãªtre infÃ©rieur Ã  la taille de la collection.\r\nNom du paramÃ¨treÂ : index\r\n--------- Stack trace ---------\r\n----------06-03-20 17:58:19----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:s()\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.ThrowHelper ThrowArgumentOutOfRangeException\r\n2- ConstructionSiteLogistics.SiteLivraisonEdit SiteLivraisonEdit_shown\r\n3- System.Windows.Forms.Form OnShown\r\n4- System.Windows.Forms.Form CallShownEvent\r\n5- System.Windows.Forms.Control InvokeMarshaledCallbackDo\r\n6- System.Windows.Forms.Control InvokeMarshaledCallbackHelper\r\n7- System.Threading.ExecutionContext RunInternal\r\n8- System.Threading.ExecutionContext Run\r\n9- System.Threading.ExecutionContext Run\r\n10- System.Windows.Forms.Control InvokeMarshaledCallback\r\n11- System.Windows.Forms.Control InvokeMarshaledCallbacks\r\n', '2020-03-06', '18:02:34'),
(30, '', 'Lindex Ã©tait hors limites. Il ne doit pas Ãªtre nÃ©gatif et doit Ãªtre infÃ©rieur Ã  la taille de la collection.\r\nNom du paramÃ¨treÂ : index\r\n--------- Stack trace ---------\r\n----------06-03-20 18:03:12----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:s()\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.ThrowHelper ThrowArgumentOutOfRangeException\r\n2- ConstructionSiteLogistics.SiteLivraisonEdit SiteLivraisonEdit_shown\r\n3- System.Windows.Forms.Form OnShown\r\n4- System.Windows.Forms.Form CallShownEvent\r\n5- System.Windows.Forms.Control InvokeMarshaledCallbackDo\r\n6- System.Windows.Forms.Control InvokeMarshaledCallbackHelper\r\n7- System.Threading.ExecutionContext RunInternal\r\n8- System.Threading.ExecutionContext Run\r\n9- System.Threading.ExecutionContext Run\r\n10- System.Windows.Forms.Control InvokeMarshaledCallback\r\n11- System.Windows.Forms.Control InvokeMarshaledCallbacks\r\n', '2020-03-06', '18:05:43'),
(31, '', 'Lindex Ã©tait hors limites. Il ne doit pas Ãªtre nÃ©gatif et doit Ãªtre infÃ©rieur Ã  la taille de la collection.\r\nNom du paramÃ¨treÂ : index\r\n--------- Stack trace ---------\r\n----------06-03-20 18:06:18----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:s()\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.ThrowHelper ThrowArgumentOutOfRangeException\r\n2- ConstructionSiteLogistics.SiteLivraisonEdit SiteLivraisonEdit_shown\r\n3- System.Windows.Forms.Form OnShown\r\n4- System.Windows.Forms.Form CallShownEvent\r\n5- System.Windows.Forms.Control InvokeMarshaledCallbackDo\r\n6- System.Windows.Forms.Control InvokeMarshaledCallbackHelper\r\n7- System.Threading.ExecutionContext RunInternal\r\n8- System.Threading.ExecutionContext Run\r\n9- System.Threading.ExecutionContext Run\r\n10- System.Windows.Forms.Control InvokeMarshaledCallback\r\n11- System.Windows.Forms.Control InvokeMarshaledCallbacks\r\n', '2020-03-06', '18:25:48'),
(32, '', 'La clÃ© donnÃ©e Ã©tait absente du dictionnaire.\r\n--------- Stack trace ---------\r\n----------07-03-20 11:31:49----------\r\n----------OS version:1.0.0.1----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Collections.Generic.Dictionary`2[TKey,TValue] get_Item\r\n2- ConstructionSiteLogistics.workersClothes_frm del_ausencia_LinkClicked\r\n3- System.Windows.Forms.LinkLabel OnLinkClicked\r\n4- System.Windows.Forms.LinkLabel OnMouseUp\r\n5- System.Windows.Forms.Control WmMouseUp\r\n6- System.Windows.Forms.Control WndProc\r\n7- System.Windows.Forms.Label WndProc\r\n8- System.Windows.Forms.LinkLabel WndProc\r\n9- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n10- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n11- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-07', '11:32:21'),
(33, '', 'The operation was canceled.\r\n--------- Stack trace ---------\r\n----------09-03-20 12:17:54----------\r\n----------OS version:1.0.0.3----------\r\n    Error Line:184\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Threading.CancellationToken ThrowOperationCanceledException\r\n2- System.Threading.CancellationToken ThrowIfCancellationRequested\r\n3- ConstructionSiteLogistics.attendance_records_verification_frm doDuiplicatesSearch\r\n', '2020-03-09', '12:34:10'),
(34, '', 'Lindex Ã©tait hors limites. Il ne doit pas Ãªtre nÃ©gatif et doit Ãªtre infÃ©rieur Ã  la taille de la collection.\r\nNom du paramÃ¨treÂ : index\r\n--------- Stack trace ---------\r\n----------10-03-20 11:29:48----------\r\n----------OS version:1.0.0.4----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.ThrowHelper ThrowArgumentOutOfRangeException\r\n2- System.Collections.Generic.List`1[T] get_Item\r\n3- ConstructionSiteLogistics.logger_frm datatable_CellMouseClick\r\n4- System.Windows.Forms.DataGridView OnCellMouseClick\r\n5- System.Windows.Forms.DataGridView OnMouseClick\r\n6- System.Windows.Forms.Control WmMouseUp\r\n7- System.Windows.Forms.Control WndProc\r\n8- System.Windows.Forms.DataGridView WndProc\r\n9- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n10- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n11- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-10', '11:30:21'),
(35, '', 'MemÃ³ria esgotada.\r\n--------- Stack trace ---------\r\n----------09/03/2020 10:50:17----------\r\n----------OS version:1.0.0.3----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Drawing.Image FromFile\r\n2- ConstructionSiteLogistics.MainMdiForm formTimeOut_tick\r\n3- System.Windows.Forms.Timer OnTick\r\n4- System.Windows.Forms.Timer+TimerNativeWindow WndProc\r\n5- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-10', '13:21:08'),
(36, '', 'Lindex Ã©tait hors limites. Il ne doit pas Ãªtre nÃ©gatif et doit Ãªtre infÃ©rieur Ã  la taille de la collection.\r\nNom du paramÃ¨treÂ : index\r\n--------- Stack trace ---------\r\n----------10-03-20 17:40:49----------\r\n----------OS version:1.0.0.7----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.ThrowHelper ThrowArgumentOutOfRangeException\r\n2- System.Collections.Generic.List`1[T] get_Item\r\n3- ConstructionSiteLogistics.logger_frm datatable_CellMouseClick\r\n4- System.Windows.Forms.DataGridView OnCellMouseClick\r\n5- System.Windows.Forms.DataGridView OnMouseClick\r\n6- System.Windows.Forms.Control WmMouseUp\r\n7- System.Windows.Forms.Control WndProc\r\n8- System.Windows.Forms.DataGridView WndProc\r\n9- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n10- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n11- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-10', '17:49:02'),
(37, '', 'Object reference not set to an instance of an object.\r\n--------- Stack trace ---------\r\n----------3/13/2020 8:25:57 AM----------\r\n----------OS version:1.0.0.10----------\r\n    Error Line:894\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- ConstructionSiteLogistics.logger_frm bwLoadData_DoWork\r\n', '2020-03-13', '09:06:05'),
(38, '', 'Lindex Ã©tait hors limites. Il ne doit pas Ãªtre nÃ©gatif et doit Ãªtre infÃ©rieur Ã  la taille de la collection.\r\nNom du paramÃ¨treÂ : index\r\n--------- Stack trace ---------\r\n----------17-03-20 10:38:08----------\r\n----------OS version:1.0.0.5----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.ThrowHelper ThrowArgumentOutOfRangeException\r\n2- System.Collections.Generic.List`1[T] get_Item\r\n3- ConstructionSiteLogistics.report_frm relatorio_detalhado\r\n4- ConstructionSiteLogistics.report_frm load_grid\r\n5- ConstructionSiteLogistics.report_frm LoadReport_Click\r\n6- System.Windows.Forms.Control OnClick\r\n7- System.Windows.Forms.Control WmMouseUp\r\n8- System.Windows.Forms.Control WndProc\r\n9- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n10- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n11- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-17', '10:39:29'),
(39, '', 'Error parsing comment. Expected: *, got h. Path message, line 5, position 67.\r\n--------- Stack trace ---------\r\n----------16-03-20 13:11:12----------\r\n----------OS version:1.0.0.11----------\r\n    Error Line: 49\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseComment\r\n2- Newtonsoft.Json.JsonTextReader ParsePostValue\r\n3- Newtonsoft.Json.JsonTextReader Read\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader PopulateDictionary\r\n5- Newtonsoft.Json.Serialization.JsonSerializerInternalReader CreateObject\r\n6- Newtonsoft.Json.Serialization.JsonSerializerInternalReader CreateValueInternal\r\n7- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n8- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n9- Newtonsoft.Json.JsonConvert DeserializeObject\r\n10- Newtonsoft.Json.JsonConvert DeserializeObject\r\n11- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-03-17', '10:47:46'),
(40, '', 'Index was out of range. Must be non-negative and less than the size of the collection.\r\nParameter name: index\r\n--------- Stack trace ---------\r\n----------17-03-20 10:50:35----------\r\n----------OS version:1.0.0.11----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.ThrowHelper ThrowArgumentOutOfRangeException\r\n2- System.Collections.Generic.List`1[T] get_Item\r\n3- ConstructionSiteLogistics.report_frm relatorio_detalhado\r\n4- ConstructionSiteLogistics.report_frm load_grid\r\n5- ConstructionSiteLogistics.report_frm LoadReport_Click\r\n6- System.Windows.Forms.Control OnClick\r\n7- System.Windows.Forms.Control WmMouseUp\r\n8- System.Windows.Forms.Control WndProc\r\n9- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n10- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n11- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-17', '10:51:04'),
(41, '', 'After parsing a value an unexpected character was encountered: a. Path message, line 1, position 71.\r\n--------- Stack trace ---------\r\n----------16-03-20 09:17:34----------\r\n----------OS version:1.0.0.10----------\r\n    Error Line:se)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParsePostValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.Serialization.JsonSerializerInternalReader PopulateDictionary\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader CreateObject\r\n5- Newtonsoft.Json.Serialization.JsonSerializerInternalReader CreateValueInternal\r\n6- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n7- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- Newtonsoft.Json.JsonConvert DeserializeObject\r\n10- Newtonsoft.Json.JsonConvert DeserializeObject\r\n11- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-03-17', '15:52:47'),
(42, '', 'Object reference not set to an instance of an object.\r\n--------- Stack trace ---------\r\n----------18-03-20 15:47:16----------\r\n----------OS version:1.0.0.11----------\r\n    Error Line:938\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- ConstructionSiteLogistics.logger_frm bwLoadData_DoWork\r\n', '2020-03-18', '15:58:29'),
(43, '', '\r\n\r\n\r\nObject reference not set to an instance of an object.\r\n--------- Stack trace ---------\r\n----------18-03-20 15:48:48----------\r\n----------OS version:1.0.0.11----------\r\n    Error Line:938\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- ConstructionSiteLogistics.logger_frm bwLoadData_DoWork\r\n', '2020-03-18', '15:58:31'),
(44, '', '\r\n\r\n\r\nObject reference not set to an instance of an object.\r\n--------- Stack trace ---------\r\n----------18-03-20 15:49:18----------\r\n----------OS version:1.0.0.11----------\r\n    Error Line:938\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- ConstructionSiteLogistics.logger_frm bwLoadData_DoWork\r\n', '2020-03-18', '15:58:31'),
(45, '', 'Object reference not set to an instance of an object.\r\n--------- Stack trace ---------\r\n----------19-03-20 07:16:08----------\r\n----------OS version:1.0.0.11----------\r\n    Error Line:949\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- ConstructionSiteLogistics.logger_frm bwLoadData_DoWork\r\n', '2020-03-19', '07:26:26'),
(46, '', '\r\n\r\n\r\nObject reference not set to an instance of an object.\r\n--------- Stack trace ---------\r\n----------19-03-20 07:17:20----------\r\n----------OS version:1.0.0.11----------\r\n    Error Line: e)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- ConstructionSiteLogistics.logger_frm bwLoadData_DoWork\r\n', '2020-03-19', '07:26:28'),
(47, '', 'Lindex Ã©tait hors limites. Il ne doit pas Ãªtre nÃ©gatif et doit Ãªtre infÃ©rieur Ã  la taille de la collection.\r\nNom du paramÃ¨treÂ : index\r\n--------- Stack trace ---------\r\n----------17-03-20 10:41:35----------\r\n----------OS version:1.0.0.11----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.ThrowHelper ThrowArgumentOutOfRangeException\r\n2- System.Collections.Generic.List`1[T] get_Item\r\n3- ConstructionSiteLogistics.report_frm relatorio_detalhado\r\n4- ConstructionSiteLogistics.report_frm load_grid\r\n5- ConstructionSiteLogistics.report_frm LoadReport_Click\r\n6- System.Windows.Forms.Control OnClick\r\n7- System.Windows.Forms.Control WmMouseUp\r\n8- System.Windows.Forms.Control WndProc\r\n9- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n10- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n11- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-19', '10:27:02'),
(48, '', 'Le formulaire sest autorÃ©fÃ©rencÃ© au cours de la construction Ã  partir dune instance par dÃ©faut, ce qui a entraÃ®nÃ© une rÃ©currence infinie. Dans le constructeur du formulaire, faites rÃ©fÃ©rence au formulaire en utilisant Me.\r\n--------- Stack trace ---------\r\n----------19-03-20 11:54:07----------\r\n----------OS version:1.0.0.10----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- ConstructionSiteLogistics.My.MyProject+MyForms Create__Instance__\r\n2- ConstructionSiteLogistics.My.MyProject+MyForms get_tableSearchOptions_frm\r\n3- ConstructionSiteLogistics.logger_frm tableSettingsBtn_Click\r\n4- System.Windows.Forms.Control OnClick\r\n5- System.Windows.Forms.Control WmMouseUp\r\n6- System.Windows.Forms.Control WndProc\r\n7- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n8- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n9- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-19', '11:55:40'),
(49, '', 'Index was out of range. Must be non-negative and less than the size of the collection.\r\nParameter name: index\r\n--------- Stack trace ---------\r\n----------19-03-20 12:13:44----------\r\n----------OS version:1.0.0.12----------\r\n    Error Line:833\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.ThrowHelper ThrowArgumentOutOfRangeException\r\n2- System.Collections.Generic.List`1[T] get_Item\r\n3- ConstructionSiteLogistics.logger_frm bwLoadData_DoWork\r\n', '2020-03-19', '12:17:59'),
(50, '', '\r\n\r\n\r\nIndex was out of range. Must be non-negative and less than the size of the collection.\r\nParameter name: index\r\n--------- Stack trace ---------\r\n----------19-03-20 12:15:59----------\r\n----------OS version:1.0.0.12----------\r\n    Error Line:833\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.ThrowHelper ThrowArgumentOutOfRangeException\r\n2- System.Collections.Generic.List`1[T] get_Item\r\n3- ConstructionSiteLogistics.logger_frm bwLoadData_DoWork\r\n', '2020-03-19', '12:18:01'),
(51, '', 'Index was out of range. Must be non-negative and less than the size of the collection.\r\nParameter name: index\r\n--------- Stack trace ---------\r\n----------19-03-20 12:19:05----------\r\n----------OS version:1.0.0.12----------\r\n    Error Line:834\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.ThrowHelper ThrowArgumentOutOfRangeException\r\n2- System.Collections.Generic.List`1[T] get_Item\r\n3- ConstructionSiteLogistics.logger_frm bwLoadData_DoWork\r\n', '2020-03-19', '12:39:55'),
(52, '', 'C:UsersJose AzevedoDocumentsSite LogisticsConstruction Site LogisticsimagesdupesChecked.png\r\n--------- Stack trace ---------\r\n----------19-03-20 12:05:13----------\r\n----------OS version:1.0.0.12----------\r\n    Error Line:rg)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Drawing.Image FromFile\r\n2- System.Drawing.Image FromFile\r\n3- ConstructionSiteLogistics.logger_frm bwLoadData_RunWorkerCompleted\r\n4- System.ComponentModel.BackgroundWorker OnRunWorkerCompleted\r\n5- System.ComponentModel.BackgroundWorker AsyncOperationCompleted\r\n', '2020-03-19', '13:08:11'),
(53, '', 'E:DiskContentsSoftwareCodeConstruction Site Logistics OfficeConstruction Site Logistics OfficeinReleaseimagesdupesChecked.png\r\n--------- Stack trace ---------\r\n----------19-03-20 13:16:38----------\r\n----------OS version:1.0.0.13----------\r\n    Error Line:rg)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Drawing.Image FromFile\r\n2- System.Drawing.Image FromFile\r\n3- ConstructionSiteLogistics.logger_frm bwLoadData_RunWorkerCompleted\r\n4- System.ComponentModel.BackgroundWorker OnRunWorkerCompleted\r\n5- System.ComponentModel.BackgroundWorker AsyncOperationCompleted\r\n', '2020-03-19', '13:17:58'),
(54, '', 'E:DiskContentsSoftwareCodeConstruction Site Logistics OfficeConstruction Site Logistics OfficeinReleaseimagesdupesChecked.png\r\n--------- Stack trace ---------\r\n----------19-03-20 13:18:42----------\r\n----------OS version:1.0.0.13----------\r\n    Error Line:rg)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Drawing.Image FromFile\r\n2- System.Drawing.Image FromFile\r\n3- ConstructionSiteLogistics.logger_frm bwLoadData_RunWorkerCompleted\r\n4- System.ComponentModel.BackgroundWorker OnRunWorkerCompleted\r\n5- System.ComponentModel.BackgroundWorker AsyncOperationCompleted\r\n', '2020-03-19', '13:19:41'),
(55, '', 'C:UsersJose AzevedoDocumentsSite LogisticsConstruction Site LogisticsimagesdupesChecked.png\r\n--------- Stack trace ---------\r\n----------19-03-20 13:10:30----------\r\n----------OS version:1.0.0.13----------\r\n    Error Line:rg)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Drawing.Image FromFile\r\n2- System.Drawing.Image FromFile\r\n3- ConstructionSiteLogistics.logger_frm bwLoadData_RunWorkerCompleted\r\n4- System.ComponentModel.BackgroundWorker OnRunWorkerCompleted\r\n5- System.ComponentModel.BackgroundWorker AsyncOperationCompleted\r\n', '2020-03-19', '13:24:40'),
(56, '', 'InvalidArgument=La valeur 83 nest pas valide pour SelectedIndex.\r\nNom du paramÃ¨treÂ : SelectedIndex\r\n--------- Stack trace ---------\r\n----------19-03-20 11:11:11----------\r\n----------OS version:1.0.0.12----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Windows.Forms.ListBox set_SelectedIndex\r\n2- ConstructionSiteLogistics.workers_frm doSearch\r\n3- ConstructionSiteLogistics.workers_frm PictureBox1_Click\r\n4- System.Windows.Forms.Control OnClick\r\n5- System.Windows.Forms.Control WmMouseUp\r\n6- System.Windows.Forms.Control WndProc\r\n7- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n8- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n9- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-19', '15:06:49'),
(57, '', '\r\n\r\n\r\nInvalidArgument=La valeur 83 nest pas valide pour SelectedIndex.\r\nNom du paramÃ¨treÂ : SelectedIndex\r\n--------- Stack trace ---------\r\n----------19-03-20 11:11:13----------\r\n----------OS version:1.0.0.12----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Windows.Forms.ListBox set_SelectedIndex\r\n2- ConstructionSiteLogistics.workers_frm doSearch\r\n3- ConstructionSiteLogistics.workers_frm PictureBox1_Click\r\n4- System.Windows.Forms.Control OnClick\r\n5- System.Windows.Forms.Control WmMouseUp\r\n6- System.Windows.Forms.Control WndProc\r\n7- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n8- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n9- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-19', '15:06:51'),
(58, '', '\r\n\r\n\r\nInvalidArgument=La valeur 83 nest pas valide pour SelectedIndex.\r\nNom du paramÃ¨treÂ : SelectedIndex\r\n--------- Stack trace ---------\r\n----------19-03-20 11:11:14----------\r\n----------OS version:1.0.0.12----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Windows.Forms.ListBox set_SelectedIndex\r\n2- ConstructionSiteLogistics.workers_frm doSearch\r\n3- ConstructionSiteLogistics.workers_frm PictureBox1_Click\r\n4- System.Windows.Forms.Control OnClick\r\n5- System.Windows.Forms.Control WmMouseUp\r\n6- System.Windows.Forms.Control WndProc\r\n7- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n8- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n9- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-19', '15:06:51'),
(59, '', '\r\n\r\n\r\nInvalidArgument=La valeur 83 nest pas valide pour SelectedIndex.\r\nNom du paramÃ¨treÂ : SelectedIndex\r\n--------- Stack trace ---------\r\n----------19-03-20 11:11:17----------\r\n----------OS version:1.0.0.12----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Windows.Forms.ListBox set_SelectedIndex\r\n2- ConstructionSiteLogistics.workers_frm doSearch\r\n3- ConstructionSiteLogistics.workers_frm PictureBox1_Click\r\n4- System.Windows.Forms.Control OnClick\r\n5- System.Windows.Forms.Control WmMouseUp\r\n6- System.Windows.Forms.Control WndProc\r\n7- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n8- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n9- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-19', '15:06:51'),
(60, '', '\r\n\r\n\r\nInvalidArgument=La valeur 83 nest pas valide pour SelectedIndex.\r\nNom du paramÃ¨treÂ : SelectedIndex\r\n--------- Stack trace ---------\r\n----------19-03-20 11:11:18----------\r\n----------OS version:1.0.0.12----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Windows.Forms.ListBox set_SelectedIndex\r\n2- ConstructionSiteLogistics.workers_frm doSearch\r\n3- ConstructionSiteLogistics.workers_frm PictureBox1_Click\r\n4- System.Windows.Forms.Control OnClick\r\n5- System.Windows.Forms.Control WmMouseUp\r\n6- System.Windows.Forms.Control WndProc\r\n7- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n8- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n9- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-19', '15:06:51'),
(61, '', '\r\n\r\n\r\nInvalidArgument=La valeur 83 nest pas valide pour SelectedIndex.\r\nNom du paramÃ¨treÂ : SelectedIndex\r\n--------- Stack trace ---------\r\n----------19-03-20 11:11:18----------\r\n----------OS version:1.0.0.12----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Windows.Forms.ListBox set_SelectedIndex\r\n2- ConstructionSiteLogistics.workers_frm doSearch\r\n3- ConstructionSiteLogistics.workers_frm PictureBox1_Click\r\n4- System.Windows.Forms.Control OnClick\r\n5- System.Windows.Forms.Control WmMouseUp\r\n6- System.Windows.Forms.Control WndProc\r\n7- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n8- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n9- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-19', '15:06:51'),
(62, '', '\r\n\r\n\r\nInvalidArgument=La valeur 83 nest pas valide pour SelectedIndex.\r\nNom du paramÃ¨treÂ : SelectedIndex\r\n--------- Stack trace ---------\r\n----------19-03-20 11:11:21----------\r\n----------OS version:1.0.0.12----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Windows.Forms.ListBox set_SelectedIndex\r\n2- ConstructionSiteLogistics.workers_frm doSearch\r\n3- ConstructionSiteLogistics.workers_frm PictureBox1_Click\r\n4- System.Windows.Forms.Control OnClick\r\n5- System.Windows.Forms.Control WmMouseUp\r\n6- System.Windows.Forms.Control WndProc\r\n7- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n8- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n9- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-19', '15:06:52'),
(63, '', '\r\n\r\n\r\nInvalidArgument=La valeur 83 nest pas valide pour SelectedIndex.\r\nNom du paramÃ¨treÂ : SelectedIndex\r\n--------- Stack trace ---------\r\n----------19-03-20 11:11:22----------\r\n----------OS version:1.0.0.12----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Windows.Forms.ListBox set_SelectedIndex\r\n2- ConstructionSiteLogistics.workers_frm doSearch\r\n3- ConstructionSiteLogistics.workers_frm PictureBox1_Click\r\n4- System.Windows.Forms.Control OnClick\r\n5- System.Windows.Forms.Control WmMouseUp\r\n6- System.Windows.Forms.Control WndProc\r\n7- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n8- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n9- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-19', '15:06:52'),
(64, '', '\r\n\r\n\r\nInvalidArgument=La valeur 83 nest pas valide pour SelectedIndex.\r\nNom du paramÃ¨treÂ : SelectedIndex\r\n--------- Stack trace ---------\r\n----------19-03-20 11:11:22----------\r\n----------OS version:1.0.0.12----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Windows.Forms.ListBox set_SelectedIndex\r\n2- ConstructionSiteLogistics.workers_frm doSearch\r\n3- ConstructionSiteLogistics.workers_frm PictureBox1_Click\r\n4- System.Windows.Forms.Control OnClick\r\n5- System.Windows.Forms.Control WmMouseUp\r\n6- System.Windows.Forms.Control WndProc\r\n7- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n8- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n9- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-19', '15:06:52');
INSERT INTO `crash_report` (`cod_report`, `cod_nfc`, `report`, `date`, `time`) VALUES
(65, '', '\r\n\r\n\r\nInvalidArgument=La valeur 83 nest pas valide pour SelectedIndex.\r\nNom du paramÃ¨treÂ : SelectedIndex\r\n--------- Stack trace ---------\r\n----------19-03-20 11:11:23----------\r\n----------OS version:1.0.0.12----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Windows.Forms.ListBox set_SelectedIndex\r\n2- ConstructionSiteLogistics.workers_frm doSearch\r\n3- ConstructionSiteLogistics.workers_frm PictureBox1_Click\r\n4- System.Windows.Forms.Control OnClick\r\n5- System.Windows.Forms.Control WmMouseUp\r\n6- System.Windows.Forms.Control WndProc\r\n7- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n8- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n9- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-19', '15:06:52'),
(66, '', '\r\n\r\n\r\nInvalidArgument=La valeur 83 nest pas valide pour SelectedIndex.\r\nNom du paramÃ¨treÂ : SelectedIndex\r\n--------- Stack trace ---------\r\n----------19-03-20 11:11:27----------\r\n----------OS version:1.0.0.12----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Windows.Forms.ListBox set_SelectedIndex\r\n2- ConstructionSiteLogistics.workers_frm doSearch\r\n3- ConstructionSiteLogistics.workers_frm PictureBox1_Click\r\n4- System.Windows.Forms.Control OnClick\r\n5- System.Windows.Forms.Control WmMouseUp\r\n6- System.Windows.Forms.Control WndProc\r\n7- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n8- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n9- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-19', '15:06:52'),
(67, '', '\r\n\r\n\r\nInvalidArgument=La valeur 83 nest pas valide pour SelectedIndex.\r\nNom du paramÃ¨treÂ : SelectedIndex\r\n--------- Stack trace ---------\r\n----------19-03-20 11:11:28----------\r\n----------OS version:1.0.0.12----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Windows.Forms.ListBox set_SelectedIndex\r\n2- ConstructionSiteLogistics.workers_frm doSearch\r\n3- ConstructionSiteLogistics.workers_frm PictureBox1_Click\r\n4- System.Windows.Forms.Control OnClick\r\n5- System.Windows.Forms.Control WmMouseUp\r\n6- System.Windows.Forms.Control WndProc\r\n7- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n8- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n9- System.Windows.Forms.NativeWindow Callback\r\n', '2020-03-19', '15:06:52'),
(68, '', 'Index was outside the bounds of the array.\r\n--------- Stack trace ---------\r\n----------22/03/2020 10:33:37----------\r\n----------OS version:1.0.0.13----------\r\n    Error Line:964\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- ConstructionSiteLogistics.logger_frm bwLoadData_DoWork\r\n', '2020-03-22', '10:39:41'),
(69, '', '\r\n\r\n\r\nIndex was outside the bounds of the array.\r\n--------- Stack trace ---------\r\n----------22/03/2020 10:34:57----------\r\n----------OS version:1.0.0.13----------\r\n    Error Line:964\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- ConstructionSiteLogistics.logger_frm bwLoadData_DoWork\r\n', '2020-03-22', '10:39:42'),
(70, '', '\r\n\r\n\r\nIndex was outside the bounds of the array.\r\n--------- Stack trace ---------\r\n----------22/03/2020 10:37:52----------\r\n----------OS version:1.0.0.13----------\r\n    Error Line:964\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- ConstructionSiteLogistics.logger_frm bwLoadData_DoWork\r\n', '2020-03-22', '10:39:42'),
(71, '', 'Index was outside the bounds of the array.\r\n--------- Stack trace ---------\r\n----------22/03/2020 10:40:18----------\r\n----------OS version:1.0.0.13----------\r\n    Error Line:962\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- ConstructionSiteLogistics.logger_frm bwLoadData_DoWork\r\n', '2020-03-22', '10:42:42'),
(72, '', 'Object reference not set to an instance of an object.\r\n--------- Stack trace ---------\r\n----------22/03/2020 11:01:51----------\r\n----------OS version:1.0.0.13----------\r\n    Error Line:961\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- ConstructionSiteLogistics.logger_frm bwLoadData_DoWork\r\n', '2020-03-22', '11:06:12'),
(73, '', 'Error reading JArray from JsonReader. Current JsonReader item is not an array: StartObject. Path , line 1, position 1.\r\n--------- Stack trace ---------\r\n----------22/03/2020 12:03:30----------\r\n----------OS version:1.0.0.13----------\r\n    Error Line:923\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.Linq.JArray Load\r\n2- Newtonsoft.Json.Linq.JArray Parse\r\n3- Newtonsoft.Json.Linq.JArray Parse\r\n4- ConstructionSiteLogistics.logger_frm bwLoadData_DoWork\r\n', '2020-03-22', '12:07:47'),
(74, '', 'After parsing a value an unexpected character was encountered: a. Path message, line 1, position 77.\r\n--------- Stack trace ---------\r\n----------19-03-20 16:06:16----------\r\n----------OS version:1.0.0.13----------\r\n    Error Line:se)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParsePostValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.Serialization.JsonSerializerInternalReader PopulateDictionary\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader CreateObject\r\n5- Newtonsoft.Json.Serialization.JsonSerializerInternalReader CreateValueInternal\r\n6- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n7- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- Newtonsoft.Json.JsonConvert DeserializeObject\r\n10- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-03-23', '14:42:32'),
(75, '', '\r\n\r\n\r\nAfter parsing a value an unexpected character was encountered: a. Path message, line 1, position 77.\r\n--------- Stack trace ---------\r\n----------19-03-20 16:06:27----------\r\n----------OS version:1.0.0.13----------\r\n    Error Line:se)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParsePostValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.Serialization.JsonSerializerInternalReader PopulateDictionary\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader CreateObject\r\n5- Newtonsoft.Json.Serialization.JsonSerializerInternalReader CreateValueInternal\r\n6- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n7- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- Newtonsoft.Json.JsonConvert DeserializeObject\r\n10- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-03-23', '14:42:34'),
(76, '', '\r\n\r\n\r\nAfter parsing a value an unexpected character was encountered: e. Path message, line 1, position 125.\r\n--------- Stack trace ---------\r\n----------23-03-20 13:57:38----------\r\n----------OS version:1.0.0.13----------\r\n    Error Line:se)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParsePostValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.Serialization.JsonSerializerInternalReader PopulateDictionary\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader CreateObject\r\n5- Newtonsoft.Json.Serialization.JsonSerializerInternalReader CreateValueInternal\r\n6- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n7- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- Newtonsoft.Json.JsonConvert DeserializeObject\r\n10- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-03-23', '14:42:34'),
(77, '', 'The given key was not present in the dictionary.\r\n--------- Stack trace ---------\r\n----------27/03/2020 09:16:52----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line:204\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Microsoft.VisualBasic.CompilerServices.Symbols+Container InvokeMethod\r\n2- Microsoft.VisualBasic.CompilerServices.NewLateBinding ObjectLateGet\r\n3- Microsoft.VisualBasic.CompilerServices.NewLateBinding LateGet\r\n4- ConstructionSiteLogistics.meteo_frm loadMeteo\r\n', '2020-03-27', '09:30:35'),
(78, '', 'O Ã­ndice estava fora do intervalo. Tem de ser nÃ£o negativo e inferior ao tamanho da colecÃ§Ã£o.\r\nNome do parÃ¢metro: index\r\n--------- Stack trace ---------\r\n----------03/04/2020 16:40:29----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Collections.ArrayList get_Item\r\n2- System.Windows.Forms.DataGridViewRowCollection SharedRow\r\n3- System.Windows.Forms.DataGridViewRowCollection get_Item\r\n4- ConstructionSiteLogistics.frm_worker_list loadTable\r\n5- ConstructionSiteLogistics.frm_worker_list SearchBoxBtn_Click\r\n6- System.Windows.Forms.Control OnClick\r\n7- System.Windows.Forms.Control WmMouseUp\r\n8- System.Windows.Forms.Control WndProc\r\n9- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n10- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n11- System.Windows.Forms.NativeWindow Callback\r\n', '2020-04-03', '17:41:11'),
(79, '', 'Error parsing comment. Expected: *, got h. Path message, line 6, position 58.\r\n--------- Stack trace ---------\r\n----------06/04/2020 17:09:58----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseComment\r\n2- Newtonsoft.Json.JsonTextReader ParsePostValue\r\n3- Newtonsoft.Json.JsonTextReader Read\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader PopulateDictionary\r\n5- Newtonsoft.Json.Serialization.JsonSerializerInternalReader CreateObject\r\n6- Newtonsoft.Json.Serialization.JsonSerializerInternalReader CreateValueInternal\r\n7- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n8- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n9- Newtonsoft.Json.JsonConvert DeserializeObject\r\n10- Newtonsoft.Json.JsonConvert DeserializeObject\r\n11- Newtonsoft.Json.JsonConvert DeserializeObject\r\n12- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '19:10:14'),
(80, '', '\r\n\r\n\r\nError parsing comment. Expected: *, got h. Path message, line 6, position 58.\r\n--------- Stack trace ---------\r\n----------06/04/2020 17:10:39----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseComment\r\n2- Newtonsoft.Json.JsonTextReader ParsePostValue\r\n3- Newtonsoft.Json.JsonTextReader Read\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader PopulateDictionary\r\n5- Newtonsoft.Json.Serialization.JsonSerializerInternalReader CreateObject\r\n6- Newtonsoft.Json.Serialization.JsonSerializerInternalReader CreateValueInternal\r\n7- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n8- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n9- Newtonsoft.Json.JsonConvert DeserializeObject\r\n10- Newtonsoft.Json.JsonConvert DeserializeObject\r\n11- Newtonsoft.Json.JsonConvert DeserializeObject\r\n12- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '19:10:22'),
(81, '', '\r\n\r\n\r\nError parsing comment. Expected: *, got h. Path message, line 6, position 58.\r\n--------- Stack trace ---------\r\n----------06/04/2020 17:11:42----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseComment\r\n2- Newtonsoft.Json.JsonTextReader ParsePostValue\r\n3- Newtonsoft.Json.JsonTextReader Read\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader PopulateDictionary\r\n5- Newtonsoft.Json.Serialization.JsonSerializerInternalReader CreateObject\r\n6- Newtonsoft.Json.Serialization.JsonSerializerInternalReader CreateValueInternal\r\n7- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n8- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n9- Newtonsoft.Json.JsonConvert DeserializeObject\r\n10- Newtonsoft.Json.JsonConvert DeserializeObject\r\n11- Newtonsoft.Json.JsonConvert DeserializeObject\r\n12- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '19:10:22'),
(82, '', 'Unexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '19:52:27'),
(83, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '19:52:28'),
(84, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '19:52:28'),
(85, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '19:52:28'),
(86, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '19:52:28'),
(87, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '19:52:28'),
(88, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '19:52:31'),
(89, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '19:52:34'),
(90, '', 'Unexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '19:55:36'),
(91, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '19:55:38'),
(92, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '19:55:38'),
(93, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '19:55:38'),
(94, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '19:55:38'),
(95, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '19:55:38'),
(96, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '19:55:39'),
(97, '', 'Unexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '20:02:03'),
(98, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '20:02:04'),
(99, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '20:02:06'),
(100, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '20:02:06'),
(101, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '20:02:08'),
(102, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '20:02:08'),
(103, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '20:02:08'),
(104, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '20:02:09'),
(105, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '20:02:09'),
(106, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '20:02:09'),
(107, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '20:02:09'),
(108, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '20:02:09'),
(109, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: a. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 19:35:02----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '20:02:09'),
(110, '', 'Unexpected character encountered while parsing value: T. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 20:09:00----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '20:15:09'),
(111, '', 'Unexpected character encountered while parsing value: T. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 20:15:10----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '20:17:31'),
(112, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: T. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 20:15:10----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '20:17:33'),
(113, '', 'Unexpected character encountered while parsing value: T. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 20:17:37----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '20:30:28'),
(114, '', '\r\n\r\n\r\nUnexpected character encountered while parsing value: T. Path , line 0, position 0.\r\n--------- Stack trace ---------\r\n----------06/04/2020 20:17:40----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line: 52\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.JsonReader ReadForType\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n5- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n6- Newtonsoft.Json.JsonConvert DeserializeObject\r\n7- Newtonsoft.Json.JsonConvert DeserializeObject\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- ConstructionSiteLogistics.ManagementNetwork IsResponseOk\r\n', '2020-04-06', '20:30:28'),
(115, '', 'InvalidArgument=La valeur 60 nest pas valide pour index.\r\nNom du paramÃ¨treÂ : index\r\n--------- Stack trace ---------\r\n----------09-04-20 10:28:56----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Windows.Forms.ListBox+ObjectCollection get_Item\r\n2- ConstructionSiteLogistics.logger_frm ListBox1_MouseClick\r\n3- System.Windows.Forms.Control OnMouseClick\r\n4- System.Windows.Forms.ListBox WndProc\r\n5- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n6- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n7- System.Windows.Forms.NativeWindow Callback\r\n', '2020-04-09', '10:29:22'),
(116, '', 'The given paths format is not supported.\r\n--------- Stack trace ---------\r\n----------18-04-20 21:38:45----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- System.Security.Permissions.FileIOPermission EmulateFileIOPermissionChecks\r\n2- System.Security.Permissions.FileIOPermission QuickDemand\r\n3- System.IO.FileInfo Init\r\n4- System.IO.FileInfo .ctor\r\n5- ConstructionSiteLogistics.site_frm journalLoadButton_Click\r\n6- System.Windows.Forms.Control OnClick\r\n7- System.Windows.Forms.Control WmMouseUp\r\n8- System.Windows.Forms.Control WndProc\r\n9- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n10- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n11- System.Windows.Forms.NativeWindow Callback\r\n', '2020-04-18', '21:39:44'),
(117, '', '\r\n\r\n\r\nInput string 81.164.198.21 is not a valid number. Path , line 1, position 13.\r\n--------- Stack trace ---------\r\n----------25-04-20 19:53:31----------\r\n----------OS version:1.0.0.0----------\r\n    Error Line: 51\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseReadNumber\r\n2- Newtonsoft.Json.JsonTextReader ParseNumber\r\n3- Newtonsoft.Json.JsonTextReader ParseValue\r\n4- Newtonsoft.Json.JsonTextReader Read\r\n5- Newtonsoft.Json.JsonReader ReadForType\r\n6- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n7- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- Newtonsoft.Json.JsonConvert DeserializeObject\r\n10- Newtonsoft.Json.JsonConvert DeserializeObject\r\n11- ConstructionSiteLogistics.Libraries.Core.ManagementNetwork IsResponseOk\r\n', '2020-04-25', '21:32:03'),
(118, '', '\r\n\r\n\r\nInput string 81.164.198.21 is not a valid number. Path , line 1, position 13.\r\n--------- Stack trace ---------\r\n----------25-04-20 19:53:03----------\r\n----------OS version:1.0.0.0----------\r\n    Error Line: 51\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseReadNumber\r\n2- Newtonsoft.Json.JsonTextReader ParseNumber\r\n3- Newtonsoft.Json.JsonTextReader ParseValue\r\n4- Newtonsoft.Json.JsonTextReader Read\r\n5- Newtonsoft.Json.JsonReader ReadForType\r\n6- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n7- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- Newtonsoft.Json.JsonConvert DeserializeObject\r\n10- Newtonsoft.Json.JsonConvert DeserializeObject\r\n11- ConstructionSiteLogistics.Libraries.Core.ManagementNetwork IsResponseOk\r\n', '2020-04-25', '21:33:01'),
(119, '', 'After parsing a value an unexpected character was encountered: s. Path message, line 1, position 75.\r\n--------- Stack trace ---------\r\n----------25-04-20 19:49:44----------\r\n----------OS version:1.0.0.0----------\r\n    Error Line: 51\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParsePostValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.Serialization.JsonSerializerInternalReader PopulateDictionary\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader CreateObject\r\n5- Newtonsoft.Json.Serialization.JsonSerializerInternalReader CreateValueInternal\r\n6- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n7- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- Newtonsoft.Json.JsonConvert DeserializeObject\r\n10- Newtonsoft.Json.JsonConvert DeserializeObject\r\n11- ConstructionSiteLogistics.Libraries.Core.ManagementNetwork IsResponseOk\r\n', '2020-04-25', '21:36:42'),
(120, '', '\r\n\r\n\r\nInput string 81.164.198.21 is not a valid number. Path , line 1, position 13.\r\n--------- Stack trace ---------\r\n----------25-04-20 19:53:45----------\r\n----------OS version:1.0.0.0----------\r\n    Error Line: 51\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParseReadNumber\r\n2- Newtonsoft.Json.JsonTextReader ParseNumber\r\n3- Newtonsoft.Json.JsonTextReader ParseValue\r\n4- Newtonsoft.Json.JsonTextReader Read\r\n5- Newtonsoft.Json.JsonReader ReadForType\r\n6- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n7- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- Newtonsoft.Json.JsonConvert DeserializeObject\r\n10- Newtonsoft.Json.JsonConvert DeserializeObject\r\n11- ConstructionSiteLogistics.Libraries.Core.ManagementNetwork IsResponseOk\r\n', '2020-04-26', '07:44:28'),
(121, '', 'After parsing a value an unexpected character was encountered: s. Path message, line 1, position 75.\r\n--------- Stack trace ---------\r\n----------25-04-20 19:49:44----------\r\n----------OS version:1.0.0.0----------\r\n    Error Line: 51\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- Newtonsoft.Json.JsonTextReader ParsePostValue\r\n2- Newtonsoft.Json.JsonTextReader Read\r\n3- Newtonsoft.Json.Serialization.JsonSerializerInternalReader PopulateDictionary\r\n4- Newtonsoft.Json.Serialization.JsonSerializerInternalReader CreateObject\r\n5- Newtonsoft.Json.Serialization.JsonSerializerInternalReader CreateValueInternal\r\n6- Newtonsoft.Json.Serialization.JsonSerializerInternalReader Deserialize\r\n7- Newtonsoft.Json.JsonSerializer DeserializeInternal\r\n8- Newtonsoft.Json.JsonConvert DeserializeObject\r\n9- Newtonsoft.Json.JsonConvert DeserializeObject\r\n10- Newtonsoft.Json.JsonConvert DeserializeObject\r\n11- ConstructionSiteLogistics.Libraries.Core.ManagementNetwork IsResponseOk\r\n', '2020-04-26', '11:48:01'),
(122, '', 'The form referred to itself during construction from a default instance, which led to infinite recursion.  Within the Forms constructor refer to the form using Me.\r\n--------- Stack trace ---------\r\n----------4/28/2020 6:10:28 PM----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- ConstructionSiteLogistics.My.MyProject+MyForms Create__Instance__\r\n2- ConstructionSiteLogistics.team_frm tableSettingsBtn_Click\r\n3- System.Windows.Forms.Control OnClick\r\n4- System.Windows.Forms.Control WmMouseUp\r\n5- System.Windows.Forms.Control WndProc\r\n6- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n7- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n8- System.Windows.Forms.NativeWindow Callback\r\n', '2020-04-28', '18:12:20'),
(123, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------29486997035082--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:262)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:310)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4666)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4643)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4617)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4569)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-04', '16:17:23');
INSERT INTO `crash_report` (`cod_report`, `cod_nfc`, `report`, `date`, `time`) VALUES
(124, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------29883120137105--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:262)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:310)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4666)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4643)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4617)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4569)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-04', '16:23:59'),
(125, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------29914490373559--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:262)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:310)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4666)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4643)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4617)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4569)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-04', '16:24:30'),
(126, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------30001764442816--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:262)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:310)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4666)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4643)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4617)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4569)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-04', '16:25:57'),
(127, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------30186012728205--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:262)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:310)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4666)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4643)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4617)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4569)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-04', '16:29:13'),
(128, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------30366129513073--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:262)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:310)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4666)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4643)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4617)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4569)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-04', '16:32:02'),
(129, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------30379943084946--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:262)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:310)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4666)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4643)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4617)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4569)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-04', '16:32:16'),
(130, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------30437293957854--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:262)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:310)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4666)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4643)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4617)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4569)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-04', '16:33:14'),
(131, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------31355704970735--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:268)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:316)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4666)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4643)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4617)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4569)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-04', '16:48:32'),
(132, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------1322648655526--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:268)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:316)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4666)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4643)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4617)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4569)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-05', '09:56:11'),
(133, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@92454b7\n\n--------- Stack trace ---------\n\n----------1355687913854--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.MainActivity.unregisterNetworkChanges(MainActivity.java:210)\n    construction.site.logistics.foreman.MainActivity.onDestroy(MainActivity.java:231)\n    android.app.Activity.performDestroy(Activity.java:7615)\n    android.app.Instrumentation.callActivityOnDestroy(Instrumentation.java:1253)\n    android.app.ActivityThread.performDestroyActivity(ActivityThread.java:5136)\n    android.app.ActivityThread.handleDestroyActivity(ActivityThread.java:5168)\n    android.app.ActivityThread.handleRelaunchActivity(ActivityThread.java:5447)\n    android.app.ActivityThread.-wrap19(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2000)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@92454b7\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-05', '09:56:43'),
(134, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@2e1e7c5\n\n--------- Stack trace ---------\n\n----------1372284243018--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.MainActivity.unregisterNetworkChanges(MainActivity.java:210)\n    construction.site.logistics.foreman.MainActivity.onDestroy(MainActivity.java:231)\n    android.app.Activity.performDestroy(Activity.java:7615)\n    android.app.Instrumentation.callActivityOnDestroy(Instrumentation.java:1253)\n    android.app.ActivityThread.performDestroyActivity(ActivityThread.java:5136)\n    android.app.ActivityThread.handleDestroyActivity(ActivityThread.java:5168)\n    android.app.ActivityThread.handleRelaunchActivity(ActivityThread.java:5447)\n    android.app.ActivityThread.-wrap19(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2000)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@2e1e7c5\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-05', '09:57:00'),
(135, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@d07cd39\n\n--------- Stack trace ---------\n\n----------1385192725829--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.MainActivity.unregisterNetworkChanges(MainActivity.java:210)\n    construction.site.logistics.foreman.MainActivity.onDestroy(MainActivity.java:231)\n    android.app.Activity.performDestroy(Activity.java:7615)\n    android.app.Instrumentation.callActivityOnDestroy(Instrumentation.java:1253)\n    android.app.ActivityThread.performDestroyActivity(ActivityThread.java:5136)\n    android.app.ActivityThread.handleDestroyActivity(ActivityThread.java:5168)\n    android.app.ActivityThread.handleRelaunchActivity(ActivityThread.java:5447)\n    android.app.ActivityThread.-wrap19(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2000)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@d07cd39\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-05', '09:57:12'),
(136, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------1989459926257--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:268)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:316)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4666)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4643)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4617)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4569)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-05', '10:07:18'),
(137, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------2085068136139--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:268)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:316)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4666)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4643)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4617)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4569)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-05', '10:08:54'),
(138, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------2238772877261--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:268)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:316)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4666)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4643)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4617)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4569)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-05', '10:11:27'),
(139, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------44832881114511--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:268)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:316)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4666)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4643)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4617)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4569)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-07', '20:12:36'),
(140, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------45381702543074--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:268)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:316)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4666)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4643)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4617)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4569)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-07', '20:21:45'),
(141, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------45554961109193--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:268)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:316)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4666)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4643)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4617)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4569)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-07', '20:24:38'),
(142, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------45800879337801--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:268)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:316)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4666)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4643)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4617)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4569)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-07', '20:28:44'),
(143, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------49108966609172--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:268)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:316)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4666)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4643)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4617)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4569)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2006)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-22', '08:38:33'),
(144, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@7dda051\n\n--------- Stack trace ---------\n\n----------2320699079333--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.MainActivity.unregisterNetworkChanges(MainActivity.java:209)\n    construction.site.logistics.foreman.MainActivity.onDestroy(MainActivity.java:230)\n    android.app.Activity.performDestroy(Activity.java:7615)\n    android.app.Instrumentation.callActivityOnDestroy(Instrumentation.java:1253)\n    android.app.ActivityThread.performDestroyActivity(ActivityThread.java:5136)\n    android.app.ActivityThread.handleDestroyActivity(ActivityThread.java:5168)\n    android.app.ActivityThread.-wrap6(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2058)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@7dda051\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-22', '08:43:39'),
(145, '123456785', 'java.lang.IllegalStateException: View DecorView@d57f162[] has already been added to the window manager.\n\n--------- Stack trace ---------\n\n----------3936270870232--------------------OS version:26----------    android.view.WindowManagerGlobal.addView(WindowManagerGlobal.java:345)\n    android.view.WindowManagerImpl.addView(WindowManagerImpl.java:128)\n    android.app.Dialog.show(Dialog.java:454)\n    construction.site.logistics.foreman.abstraction.Functions$3.run(Functions.java:264)\n    android.os.Handler.handleCallback(Handler.java:808)\n    android.os.Handler.dispatchMessage(Handler.java:101)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nView DecorView@d57f162[] has already been added to the window manager.\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-22', '09:21:02'),
(146, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@3e21aa8\n\n--------- Stack trace ---------\n\n----------16605677845231--------------------OS version:21----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:763)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1724)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:517)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:271)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:319)\n    android.app.Activity.performPause(Activity.java:6086)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1294)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:3227)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:3200)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:3175)\n    android.app.ActivityThread.access$1000(ActivityThread.java:147)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:1299)\n    android.os.Handler.dispatchMessage(Handler.java:102)\n    android.os.Looper.loop(Looper.java:135)\n    android.app.ActivityThread.main(ActivityThread.java:5279)\n    java.lang.reflect.Method.invoke(Native Method)\n    java.lang.reflect.Method.invoke(Method.java:372)\n    com.android.internal.os.ZygoteInit$MethodAndArgsCaller.run(ZygoteInit.java:898)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:693)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@3e21aa8\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-22', '12:37:04'),
(147, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@36fb7d3c\n\n--------- Stack trace ---------\n\n----------16642826857874--------------------OS version:21----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:763)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1724)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:517)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:271)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:319)\n    android.app.Activity.performPause(Activity.java:6086)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1294)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:3227)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:3200)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:3175)\n    android.app.ActivityThread.access$1000(ActivityThread.java:147)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:1292)\n    android.os.Handler.dispatchMessage(Handler.java:102)\n    android.os.Looper.loop(Looper.java:135)\n    android.app.ActivityThread.main(ActivityThread.java:5279)\n    java.lang.reflect.Method.invoke(Native Method)\n    java.lang.reflect.Method.invoke(Method.java:372)\n    com.android.internal.os.ZygoteInit$MethodAndArgsCaller.run(ZygoteInit.java:898)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:693)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@36fb7d3c\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-22', '12:37:41'),
(148, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@21a4cac5\n\n--------- Stack trace ---------\n\n----------16814232971871--------------------OS version:21----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:763)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1724)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:517)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:271)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:319)\n    android.app.Activity.performPause(Activity.java:6086)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1294)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:3227)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:3200)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:3175)\n    android.app.ActivityThread.access$1000(ActivityThread.java:147)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:1299)\n    android.os.Handler.dispatchMessage(Handler.java:102)\n    android.os.Looper.loop(Looper.java:135)\n    android.app.ActivityThread.main(ActivityThread.java:5279)\n    java.lang.reflect.Method.invoke(Native Method)\n    java.lang.reflect.Method.invoke(Method.java:372)\n    com.android.internal.os.ZygoteInit$MethodAndArgsCaller.run(ZygoteInit.java:898)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:693)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@21a4cac5\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-22', '12:40:33'),
(149, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@1ca0b2d\n\n--------- Stack trace ---------\n\n----------3967170816580--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.MainActivity.unregisterNetworkChanges(MainActivity.java:211)\n    construction.site.logistics.foreman.MainActivity.onDestroy(MainActivity.java:232)\n    android.app.Activity.performDestroy(Activity.java:7615)\n    android.app.Instrumentation.callActivityOnDestroy(Instrumentation.java:1253)\n    android.app.ActivityThread.performDestroyActivity(ActivityThread.java:5136)\n    android.app.ActivityThread.handleDestroyActivity(ActivityThread.java:5168)\n    android.app.ActivityThread.handleRelaunchActivity(ActivityThread.java:5447)\n    android.app.ActivityThread.-wrap19(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2000)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@1ca0b2d\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-22', '13:49:47'),
(150, '123456785', 'java.lang.Exception: Message:IV buffer too short for given offset/length combination  >>>>Encrypt:358CAB3512CB3B9E  >>>>Dencrypt:null\n\n--------- Stack trace ---------\n\n----------4956390441950--------------------OS version:26----------    construction.site.logistics.foreman.Network.SendData$SendDataAsync.doInBackground(SendData.java:226)\n    construction.site.logistics.foreman.Network.SendData$SendDataAsync.doInBackground(SendData.java:116)\n    android.os.AsyncTask$2.call(AsyncTask.java:345)\n    java.util.concurrent.FutureTask.run(FutureTask.java:266)\n    java.util.concurrent.ThreadPoolExecutor.runWorker(ThreadPoolExecutor.java:1162)\n    java.util.concurrent.ThreadPoolExecutor$Worker.run(ThreadPoolExecutor.java:636)\n    java.lang.Thread.run(Thread.java:784)\n-------------------------------\n\n--------- Message ---------\n\nMessage:IV buffer too short for given offset/length combination  >>>>Encrypt:358CAB3512CB3B9E  >>>>Dencrypt:null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-22', '15:52:48'),
(151, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@8414b6f\n\n--------- Stack trace ---------\n\n----------7782752489956--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.MainActivity.unregisterNetworkChanges(MainActivity.java:212)\n    construction.site.logistics.foreman.MainActivity.onDestroy(MainActivity.java:233)\n    android.app.Activity.performDestroy(Activity.java:7615)\n    android.app.Instrumentation.callActivityOnDestroy(Instrumentation.java:1253)\n    android.app.ActivityThread.performDestroyActivity(ActivityThread.java:5136)\n    android.app.ActivityThread.handleDestroyActivity(ActivityThread.java:5168)\n    android.app.ActivityThread.handleRelaunchActivity(ActivityThread.java:5447)\n    android.app.ActivityThread.-wrap19(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2000)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@8414b6f\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-22', '16:35:55');
INSERT INTO `crash_report` (`cod_report`, `cod_nfc`, `report`, `date`, `time`) VALUES
(152, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@f7823cb\n\n--------- Stack trace ---------\n\n----------8389124337260--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.MainActivity.unregisterNetworkChanges(MainActivity.java:212)\n    construction.site.logistics.foreman.MainActivity.onDestroy(MainActivity.java:233)\n    android.app.Activity.performDestroy(Activity.java:7615)\n    android.app.Instrumentation.callActivityOnDestroy(Instrumentation.java:1253)\n    android.app.ActivityThread.performDestroyActivity(ActivityThread.java:5136)\n    android.app.ActivityThread.handleDestroyActivity(ActivityThread.java:5168)\n    android.app.ActivityThread.-wrap6(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2058)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7523)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@f7823cb\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-23', '14:20:59'),
(153, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@62c7bbf\n\n--------- Stack trace ---------\n\n----------55504682160629--------------------OS version:21----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:763)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1724)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:517)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:271)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:319)\n    android.app.Activity.performPause(Activity.java:6086)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1294)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:3227)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:3200)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:3175)\n    android.app.ActivityThread.access$1000(ActivityThread.java:147)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:1299)\n    android.os.Handler.dispatchMessage(Handler.java:102)\n    android.os.Looper.loop(Looper.java:135)\n    android.app.ActivityThread.main(ActivityThread.java:5279)\n    java.lang.reflect.Method.invoke(Native Method)\n    java.lang.reflect.Method.invoke(Method.java:372)\n    com.android.internal.os.ZygoteInit$MethodAndArgsCaller.run(ZygoteInit.java:898)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:693)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@62c7bbf\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-09-29', '23:42:13'),
(154, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------36078409895535--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:268)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:316)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4672)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4649)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4623)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4575)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7529)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-11-17', '19:55:39'),
(155, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------30009444242295--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:268)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:316)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4672)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4649)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4623)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4575)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7529)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-11-20', '15:40:35'),
(156, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@e57bde0\n\n--------- Stack trace ---------\n\n----------30020451001147--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.MainActivity.unregisterNetworkChanges(MainActivity.java:210)\n    construction.site.logistics.foreman.MainActivity.onDestroy(MainActivity.java:231)\n    android.app.Activity.performDestroy(Activity.java:7615)\n    android.app.Instrumentation.callActivityOnDestroy(Instrumentation.java:1253)\n    android.app.ActivityThread.performDestroyActivity(ActivityThread.java:5142)\n    android.app.ActivityThread.handleDestroyActivity(ActivityThread.java:5174)\n    android.app.ActivityThread.handleRelaunchActivity(ActivityThread.java:5453)\n    android.app.ActivityThread.-wrap19(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2000)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7529)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@e57bde0\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-11-20', '15:40:45'),
(157, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------30134735383421--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:268)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:316)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4672)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4649)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4623)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4575)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7529)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-11-20', '15:42:40'),
(158, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------14841679348255--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:268)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:316)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4672)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4649)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4623)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4575)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7529)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-11-26', '10:32:09'),
(159, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@7cd64c6\n\n--------- Stack trace ---------\n\n----------14854785922211--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.MainActivity.unregisterNetworkChanges(MainActivity.java:210)\n    construction.site.logistics.foreman.MainActivity.onDestroy(MainActivity.java:231)\n    android.app.Activity.performDestroy(Activity.java:7615)\n    android.app.Instrumentation.callActivityOnDestroy(Instrumentation.java:1253)\n    android.app.ActivityThread.performDestroyActivity(ActivityThread.java:5142)\n    android.app.ActivityThread.handleDestroyActivity(ActivityThread.java:5174)\n    android.app.ActivityThread.handleRelaunchActivity(ActivityThread.java:5453)\n    android.app.ActivityThread.-wrap19(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2000)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7529)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@7cd64c6\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-11-26', '10:32:21'),
(160, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------8035626609710--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:268)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:316)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4672)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4649)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4623)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4575)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7529)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-12-04', '12:35:27'),
(161, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------46171459677849--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:268)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:316)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4672)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4649)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4623)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4575)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7529)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-12-09', '20:52:23'),
(162, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------50491376776669--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:268)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:316)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4672)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4649)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4623)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4575)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7529)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-12-09', '22:04:21'),
(163, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------51569100518171--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:268)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:316)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4672)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4649)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4623)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4575)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7529)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-12-09', '22:22:21'),
(164, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------51776652454077--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:268)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:316)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4672)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4649)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4623)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4575)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7529)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-12-09', '22:25:48'),
(165, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------51868340102500--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:268)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:316)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4672)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4649)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4623)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4575)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7529)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-12-09', '22:27:20'),
(166, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------53060720718464--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:268)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:316)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4672)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4649)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4623)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4575)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7529)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-12-09', '22:47:11'),
(167, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------53516363140790--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:268)\n    construction.site.logistics.foreman.login.LoginActivity.onPause(LoginActivity.java:316)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4672)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4649)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4623)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4575)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7529)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-12-09', '22:54:46'),
(168, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------639980277149--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1181)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1456)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:658)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:658)\n    construction.site.logistics.foreman.mvp.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:268)\n    construction.site.logistics.foreman.mvp.login.LoginActivity.onPause(LoginActivity.java:316)\n    android.app.Activity.performPause(Activity.java:7391)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1414)\n    androidx.test.runner.MonitoringInstrumentation.callActivityOnPause(MonitoringInstrumentation.java:1)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4113)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4090)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4064)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4038)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:1717)\n    android.os.Handler.dispatchMessage(Handler.java:105)\n    androidx.test.espresso.base.Interrogator.a(Interrogator.java:11)\n    androidx.test.espresso.base.UiControllerImpl.n(UiControllerImpl.java:6)\n    androidx.test.espresso.base.UiControllerImpl.m(UiControllerImpl.java:1)\n    androidx.test.espresso.base.UiControllerImpl.a(UiControllerImpl.java:6)\n    androidx.test.espresso.action.MotionEvents.a(MotionEvents.java:15)\n    androidx.test.espresso.action.Tap.b(Unknown Source:9)\n    androidx.test.espresso.action.Tap$1.sendTap(Tap.java:1)\n    androidx.test.espresso.action.GeneralClickAction.perform(GeneralClickAction.java:4)\n    androidx.test.espresso.ViewInteraction$SingleExecutionViewAction.perform(ViewInteraction.java:4)\n    androidx.test.espresso.ViewInteraction.a(Unknown Source:137)\n    androidx.test.espresso.ViewInteraction$1.call(Unknown Source:4)\n    java.util.concurrent.FutureTask.run(FutureTask.java:266)\n    android.os.Handler.handleCallback(Handler.java:789)\n    android.os.Handler.dispatchMessage(Handler.java:98)\n    android.os.Looper.loop(Looper.java:164)\n    android.app.ActivityThread.main(ActivityThread.java:6938)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:327)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:1374)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-12-15', '18:15:53'),
(169, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: construction.site.logistics.foreman.mvp.Network.NetworkStateReceiver@91b3c79\n\n--------- Stack trace ---------\n\n----------644396919595--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1181)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1456)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:658)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:658)\n    construction.site.logistics.foreman.mvp.MainActivity.unregisterNetworkChanges(MainActivity.java:210)\n    construction.site.logistics.foreman.mvp.MainActivity.onDestroy(MainActivity.java:231)\n    android.app.Activity.performDestroy(Activity.java:7462)\n    android.app.Instrumentation.callActivityOnDestroy(Instrumentation.java:1255)\n    androidx.test.runner.MonitoringInstrumentation.callActivityOnDestroy(MonitoringInstrumentation.java:1)\n    android.app.ActivityThread.performDestroyActivity(ActivityThread.java:4590)\n    android.app.ActivityThread.handleDestroyActivity(ActivityThread.java:4621)\n    android.app.ActivityThread.handleRelaunchActivity(ActivityThread.java:4895)\n    android.app.ActivityThread.-wrap19(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:1702)\n    android.os.Handler.dispatchMessage(Handler.java:105)\n    androidx.test.espresso.base.Interrogator.a(Interrogator.java:11)\n    androidx.test.espresso.base.UiControllerImpl.n(UiControllerImpl.java:6)\n    androidx.test.espresso.base.UiControllerImpl.m(UiControllerImpl.java:1)\n    androidx.test.espresso.base.UiControllerImpl.e(UiControllerImpl.java:8)\n    androidx.test.espresso.action.Tap$1.sendTap(Tap.java:4)\n    androidx.test.espresso.action.GeneralClickAction.perform(GeneralClickAction.java:4)\n    androidx.test.espresso.ViewInteraction$SingleExecutionViewAction.perform(ViewInteraction.java:4)\n    androidx.test.espresso.ViewInteraction.a(Unknown Source:137)\n    androidx.test.espresso.ViewInteraction$1.call(Unknown Source:4)\n    java.util.concurrent.FutureTask.run(FutureTask.java:266)\n    android.os.Handler.handleCallback(Handler.java:789)\n    android.os.Handler.dispatchMessage(Handler.java:98)\n    android.os.Looper.loop(Looper.java:164)\n    android.app.ActivityThread.main(ActivityThread.java:6938)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:327)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:1374)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: construction.site.logistics.foreman.mvp.Network.NetworkStateReceiver@91b3c79\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-12-15', '18:15:57'),
(170, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: construction.site.logistics.foreman.mvp.Network.NetworkStateReceiver@e160bd1\n\n--------- Stack trace ---------\n\n----------647654710896--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1181)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1456)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:658)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:658)\n    construction.site.logistics.foreman.mvp.MainActivity.unregisterNetworkChanges(MainActivity.java:210)\n    construction.site.logistics.foreman.mvp.MainActivity.onDestroy(MainActivity.java:231)\n    android.app.Activity.performDestroy(Activity.java:7462)\n    android.app.Instrumentation.callActivityOnDestroy(Instrumentation.java:1255)\n    androidx.test.runner.MonitoringInstrumentation.callActivityOnDestroy(MonitoringInstrumentation.java:1)\n    android.app.ActivityThread.performDestroyActivity(ActivityThread.java:4590)\n    android.app.ActivityThread.handleDestroyActivity(ActivityThread.java:4621)\n    android.app.ActivityThread.handleRelaunchActivity(ActivityThread.java:4895)\n    android.app.ActivityThread.-wrap19(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:1702)\n    android.os.Handler.dispatchMessage(Handler.java:105)\n    androidx.test.espresso.base.Interrogator.a(Interrogator.java:11)\n    androidx.test.espresso.base.UiControllerImpl.n(UiControllerImpl.java:6)\n    androidx.test.espresso.base.UiControllerImpl.m(UiControllerImpl.java:1)\n    androidx.test.espresso.base.UiControllerImpl.e(UiControllerImpl.java:8)\n    androidx.test.espresso.action.Tap$1.sendTap(Tap.java:4)\n    androidx.test.espresso.action.GeneralClickAction.perform(GeneralClickAction.java:4)\n    androidx.test.espresso.ViewInteraction$SingleExecutionViewAction.perform(ViewInteraction.java:4)\n    androidx.test.espresso.ViewInteraction.a(Unknown Source:137)\n    androidx.test.espresso.ViewInteraction$1.call(Unknown Source:4)\n    java.util.concurrent.FutureTask.run(FutureTask.java:266)\n    android.os.Handler.handleCallback(Handler.java:789)\n    android.os.Handler.dispatchMessage(Handler.java:98)\n    android.os.Looper.loop(Looper.java:164)\n    android.app.ActivityThread.main(ActivityThread.java:6938)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:327)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:1374)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: construction.site.logistics.foreman.mvp.Network.NetworkStateReceiver@e160bd1\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-12-15', '18:16:00'),
(171, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: construction.site.logistics.foreman.mvp.Network.NetworkStateReceiver@8890cfc\n\n--------- Stack trace ---------\n\n----------662378513859--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1181)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1456)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:658)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:658)\n    construction.site.logistics.foreman.mvp.MainActivity.unregisterNetworkChanges(MainActivity.java:210)\n    construction.site.logistics.foreman.mvp.MainActivity.onDestroy(MainActivity.java:231)\n    android.app.Activity.performDestroy(Activity.java:7462)\n    android.app.Instrumentation.callActivityOnDestroy(Instrumentation.java:1255)\n    androidx.test.runner.MonitoringInstrumentation.callActivityOnDestroy(MonitoringInstrumentation.java:1)\n    android.app.ActivityThread.performDestroyActivity(ActivityThread.java:4590)\n    android.app.ActivityThread.handleDestroyActivity(ActivityThread.java:4621)\n    android.app.ActivityThread.handleRelaunchActivity(ActivityThread.java:4895)\n    android.app.ActivityThread.-wrap19(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:1702)\n    android.os.Handler.dispatchMessage(Handler.java:105)\n    androidx.test.espresso.base.Interrogator.a(Interrogator.java:11)\n    androidx.test.espresso.base.UiControllerImpl.n(UiControllerImpl.java:6)\n    androidx.test.espresso.base.UiControllerImpl.m(UiControllerImpl.java:1)\n    androidx.test.espresso.base.UiControllerImpl.e(UiControllerImpl.java:8)\n    androidx.test.espresso.action.Tap$1.sendTap(Tap.java:4)\n    androidx.test.espresso.action.GeneralClickAction.perform(GeneralClickAction.java:4)\n    androidx.test.espresso.ViewInteraction$SingleExecutionViewAction.perform(ViewInteraction.java:4)\n    androidx.test.espresso.ViewInteraction.a(Unknown Source:137)\n    androidx.test.espresso.ViewInteraction$1.call(Unknown Source:4)\n    java.util.concurrent.FutureTask.run(FutureTask.java:266)\n    android.os.Handler.handleCallback(Handler.java:789)\n    android.os.Handler.dispatchMessage(Handler.java:98)\n    android.os.Looper.loop(Looper.java:164)\n    android.app.ActivityThread.main(ActivityThread.java:6938)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:327)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:1374)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: construction.site.logistics.foreman.mvp.Network.NetworkStateReceiver@8890cfc\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-12-15', '18:16:15'),
(172, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: construction.site.logistics.foreman.mvp.Network.NetworkStateReceiver@3fe55b0\n\n--------- Stack trace ---------\n\n----------669937422502--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1181)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1456)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:658)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:658)\n    construction.site.logistics.foreman.mvp.MainActivity.unregisterNetworkChanges(MainActivity.java:210)\n    construction.site.logistics.foreman.mvp.MainActivity.onDestroy(MainActivity.java:231)\n    android.app.Activity.performDestroy(Activity.java:7462)\n    android.app.Instrumentation.callActivityOnDestroy(Instrumentation.java:1255)\n    androidx.test.runner.MonitoringInstrumentation.callActivityOnDestroy(MonitoringInstrumentation.java:1)\n    android.app.ActivityThread.performDestroyActivity(ActivityThread.java:4590)\n    android.app.ActivityThread.handleDestroyActivity(ActivityThread.java:4621)\n    android.app.ActivityThread.handleRelaunchActivity(ActivityThread.java:4895)\n    android.app.ActivityThread.-wrap19(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:1702)\n    android.os.Handler.dispatchMessage(Handler.java:105)\n    androidx.test.espresso.base.Interrogator.a(Interrogator.java:11)\n    androidx.test.espresso.base.UiControllerImpl.n(UiControllerImpl.java:6)\n    androidx.test.espresso.base.UiControllerImpl.m(UiControllerImpl.java:1)\n    androidx.test.espresso.base.UiControllerImpl.e(UiControllerImpl.java:8)\n    androidx.test.espresso.action.Tap$1.sendTap(Tap.java:4)\n    androidx.test.espresso.action.GeneralClickAction.perform(GeneralClickAction.java:4)\n    androidx.test.espresso.ViewInteraction$SingleExecutionViewAction.perform(ViewInteraction.java:4)\n    androidx.test.espresso.ViewInteraction.a(Unknown Source:137)\n    androidx.test.espresso.ViewInteraction$1.call(Unknown Source:4)\n    java.util.concurrent.FutureTask.run(FutureTask.java:266)\n    android.os.Handler.handleCallback(Handler.java:789)\n    android.os.Handler.dispatchMessage(Handler.java:98)\n    android.os.Looper.loop(Looper.java:164)\n    android.app.ActivityThread.main(ActivityThread.java:6938)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:327)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:1374)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: construction.site.logistics.foreman.mvp.Network.NetworkStateReceiver@3fe55b0\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-12-15', '18:16:23'),
(173, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: construction.site.logistics.foreman.mvp.Network.NetworkStateReceiver@35e560a\n\n--------- Stack trace ---------\n\n----------679036708123--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1181)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1456)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:658)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:658)\n    construction.site.logistics.foreman.mvp.MainActivity.unregisterNetworkChanges(MainActivity.java:210)\n    construction.site.logistics.foreman.mvp.MainActivity.onDestroy(MainActivity.java:231)\n    android.app.Activity.performDestroy(Activity.java:7462)\n    android.app.Instrumentation.callActivityOnDestroy(Instrumentation.java:1255)\n    androidx.test.runner.MonitoringInstrumentation.callActivityOnDestroy(MonitoringInstrumentation.java:1)\n    android.app.ActivityThread.performDestroyActivity(ActivityThread.java:4590)\n    android.app.ActivityThread.handleDestroyActivity(ActivityThread.java:4621)\n    android.app.ActivityThread.handleRelaunchActivity(ActivityThread.java:4895)\n    android.app.ActivityThread.-wrap19(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:1702)\n    android.os.Handler.dispatchMessage(Handler.java:105)\n    androidx.test.espresso.base.Interrogator.a(Interrogator.java:11)\n    androidx.test.espresso.base.UiControllerImpl.n(UiControllerImpl.java:6)\n    androidx.test.espresso.base.UiControllerImpl.m(UiControllerImpl.java:1)\n    androidx.test.espresso.base.UiControllerImpl.e(UiControllerImpl.java:8)\n    androidx.test.espresso.action.Tap$1.sendTap(Tap.java:4)\n    androidx.test.espresso.action.GeneralClickAction.perform(GeneralClickAction.java:4)\n    androidx.test.espresso.ViewInteraction$SingleExecutionViewAction.perform(ViewInteraction.java:4)\n    androidx.test.espresso.ViewInteraction.a(Unknown Source:137)\n    androidx.test.espresso.ViewInteraction$1.call(Unknown Source:4)\n    java.util.concurrent.FutureTask.run(FutureTask.java:266)\n    android.os.Handler.handleCallback(Handler.java:789)\n    android.os.Handler.dispatchMessage(Handler.java:98)\n    android.os.Looper.loop(Looper.java:164)\n    android.app.ActivityThread.main(ActivityThread.java:6938)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:327)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:1374)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: construction.site.logistics.foreman.mvp.Network.NetworkStateReceiver@35e560a\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-12-15', '18:16:32'),
(174, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: construction.site.logistics.foreman.mvp.Network.NetworkStateReceiver@44909ec\n\n--------- Stack trace ---------\n\n----------680614343175--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1181)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1456)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:658)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:658)\n    construction.site.logistics.foreman.mvp.MainActivity.unregisterNetworkChanges(MainActivity.java:210)\n    construction.site.logistics.foreman.mvp.MainActivity.onDestroy(MainActivity.java:231)\n    android.app.Activity.performDestroy(Activity.java:7462)\n    android.app.Instrumentation.callActivityOnDestroy(Instrumentation.java:1255)\n    androidx.test.runner.MonitoringInstrumentation.callActivityOnDestroy(MonitoringInstrumentation.java:1)\n    android.app.ActivityThread.performDestroyActivity(ActivityThread.java:4590)\n    android.app.ActivityThread.handleDestroyActivity(ActivityThread.java:4621)\n    android.app.ActivityThread.handleRelaunchActivity(ActivityThread.java:4895)\n    android.app.ActivityThread.-wrap19(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:1702)\n    android.os.Handler.dispatchMessage(Handler.java:105)\n    androidx.test.espresso.base.Interrogator.a(Interrogator.java:11)\n    androidx.test.espresso.base.UiControllerImpl.n(UiControllerImpl.java:6)\n    androidx.test.espresso.base.UiControllerImpl.m(UiControllerImpl.java:1)\n    androidx.test.espresso.base.UiControllerImpl.e(UiControllerImpl.java:8)\n    androidx.test.espresso.action.Tap$1.sendTap(Tap.java:4)\n    androidx.test.espresso.action.GeneralClickAction.perform(GeneralClickAction.java:4)\n    androidx.test.espresso.ViewInteraction$SingleExecutionViewAction.perform(ViewInteraction.java:4)\n    androidx.test.espresso.ViewInteraction.a(Unknown Source:137)\n    androidx.test.espresso.ViewInteraction$1.call(Unknown Source:4)\n    java.util.concurrent.FutureTask.run(FutureTask.java:266)\n    android.os.Handler.handleCallback(Handler.java:789)\n    android.os.Handler.dispatchMessage(Handler.java:98)\n    android.os.Looper.loop(Looper.java:164)\n    android.app.ActivityThread.main(ActivityThread.java:6938)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:327)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:1374)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: construction.site.logistics.foreman.mvp.Network.NetworkStateReceiver@44909ec\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-12-15', '18:16:33');
INSERT INTO `crash_report` (`cod_report`, `cod_nfc`, `report`, `date`, `time`) VALUES
(175, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: construction.site.logistics.foreman.mvp.Network.NetworkStateReceiver@8d5d770\n\n--------- Stack trace ---------\n\n----------682024432028--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1181)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1456)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:658)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:658)\n    construction.site.logistics.foreman.mvp.MainActivity.unregisterNetworkChanges(MainActivity.java:210)\n    construction.site.logistics.foreman.mvp.MainActivity.onDestroy(MainActivity.java:231)\n    android.app.Activity.performDestroy(Activity.java:7462)\n    android.app.Instrumentation.callActivityOnDestroy(Instrumentation.java:1255)\n    androidx.test.runner.MonitoringInstrumentation.callActivityOnDestroy(MonitoringInstrumentation.java:1)\n    android.app.ActivityThread.performDestroyActivity(ActivityThread.java:4590)\n    android.app.ActivityThread.handleDestroyActivity(ActivityThread.java:4621)\n    android.app.ActivityThread.handleRelaunchActivity(ActivityThread.java:4895)\n    android.app.ActivityThread.-wrap19(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:1702)\n    android.os.Handler.dispatchMessage(Handler.java:105)\n    androidx.test.espresso.base.Interrogator.a(Interrogator.java:11)\n    androidx.test.espresso.base.UiControllerImpl.n(UiControllerImpl.java:6)\n    androidx.test.espresso.base.UiControllerImpl.m(UiControllerImpl.java:1)\n    androidx.test.espresso.base.UiControllerImpl.e(UiControllerImpl.java:8)\n    androidx.test.espresso.action.Tap$1.sendTap(Tap.java:4)\n    androidx.test.espresso.action.GeneralClickAction.perform(GeneralClickAction.java:4)\n    androidx.test.espresso.ViewInteraction$SingleExecutionViewAction.perform(ViewInteraction.java:4)\n    androidx.test.espresso.ViewInteraction.a(Unknown Source:137)\n    androidx.test.espresso.ViewInteraction$1.call(Unknown Source:4)\n    java.util.concurrent.FutureTask.run(FutureTask.java:266)\n    android.os.Handler.handleCallback(Handler.java:789)\n    android.os.Handler.dispatchMessage(Handler.java:98)\n    android.os.Looper.loop(Looper.java:164)\n    android.app.ActivityThread.main(ActivityThread.java:6938)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:327)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:1374)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: construction.site.logistics.foreman.mvp.Network.NetworkStateReceiver@8d5d770\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-12-15', '18:16:35'),
(176, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: construction.site.logistics.foreman.mvp.Network.NetworkStateReceiver@afbf552\n\n--------- Stack trace ---------\n\n----------687036909162--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1181)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1456)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:658)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:658)\n    construction.site.logistics.foreman.mvp.MainActivity.unregisterNetworkChanges(MainActivity.java:210)\n    construction.site.logistics.foreman.mvp.MainActivity.onDestroy(MainActivity.java:231)\n    android.app.Activity.performDestroy(Activity.java:7462)\n    android.app.Instrumentation.callActivityOnDestroy(Instrumentation.java:1255)\n    androidx.test.runner.MonitoringInstrumentation.callActivityOnDestroy(MonitoringInstrumentation.java:1)\n    android.app.ActivityThread.performDestroyActivity(ActivityThread.java:4590)\n    android.app.ActivityThread.handleDestroyActivity(ActivityThread.java:4621)\n    android.app.ActivityThread.handleRelaunchActivity(ActivityThread.java:4895)\n    android.app.ActivityThread.-wrap19(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:1702)\n    android.os.Handler.dispatchMessage(Handler.java:105)\n    androidx.test.espresso.base.Interrogator.a(Interrogator.java:11)\n    androidx.test.espresso.base.UiControllerImpl.n(UiControllerImpl.java:6)\n    androidx.test.espresso.base.UiControllerImpl.m(UiControllerImpl.java:1)\n    androidx.test.espresso.base.UiControllerImpl.e(UiControllerImpl.java:8)\n    androidx.test.espresso.action.Tap$1.sendTap(Tap.java:4)\n    androidx.test.espresso.action.GeneralClickAction.perform(GeneralClickAction.java:4)\n    androidx.test.espresso.ViewInteraction$SingleExecutionViewAction.perform(ViewInteraction.java:4)\n    androidx.test.espresso.ViewInteraction.a(Unknown Source:137)\n    androidx.test.espresso.ViewInteraction$1.call(Unknown Source:4)\n    java.util.concurrent.FutureTask.run(FutureTask.java:266)\n    android.os.Handler.handleCallback(Handler.java:789)\n    android.os.Handler.dispatchMessage(Handler.java:98)\n    android.os.Looper.loop(Looper.java:164)\n    android.app.ActivityThread.main(ActivityThread.java:6938)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:327)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:1374)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: construction.site.logistics.foreman.mvp.Network.NetworkStateReceiver@afbf552\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-12-15', '18:16:40'),
(177, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------10861774657195--------------------OS version:26----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1292)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1629)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:639)\n    construction.site.logistics.foreman.mvp.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:268)\n    construction.site.logistics.foreman.mvp.login.LoginActivity.onPause(LoginActivity.java:316)\n    android.app.Activity.performPause(Activity.java:7542)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1420)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:4672)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4649)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:4623)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:4575)\n    android.app.ActivityThread.-wrap16(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2015)\n    android.os.Handler.dispatchMessage(Handler.java:108)\n    android.os.Looper.loop(Looper.java:166)\n    android.app.ActivityThread.main(ActivityThread.java:7529)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.Zygote$MethodAndArgsCaller.run(Zygote.java:245)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:921)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2020-12-17', '14:18:19'),
(178, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: null\n\n--------- Stack trace ---------\n\n----------52197277345--------------------OS version:27----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1193)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1449)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:645)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:645)\n    construction.site.logistics.foreman.mvp.login.LoginActivity.unregisterNetworkChanges(LoginActivity.java:268)\n    construction.site.logistics.foreman.mvp.login.LoginActivity.onPause(LoginActivity.java:316)\n    android.app.Activity.performPause(Activity.java:7153)\n    android.app.Instrumentation.callActivityOnPause(Instrumentation.java:1408)\n    android.app.ActivityThread.performPauseActivityIfNeeded(ActivityThread.java:3901)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:3878)\n    android.app.ActivityThread.performPauseActivity(ActivityThread.java:3852)\n    android.app.ActivityThread.handlePauseActivity(ActivityThread.java:3826)\n    android.app.ActivityThread.-wrap15(Unknown Source:0)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:1601)\n    android.os.Handler.dispatchMessage(Handler.java:106)\n    android.os.Looper.loop(Looper.java:164)\n    android.app.ActivityThread.main(ActivityThread.java:6494)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.RuntimeInit$MethodAndArgsCaller.run(RuntimeInit.java:438)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:807)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: null\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2021-03-04', '12:49:35'),
(179, '123456785', 'java.io.IOException: Cleartext HTTP traffic to api.openweathermap.org not permitted\n\n--------- Stack trace ---------\n\n----------37983008137332--------------------OS version:29----------    com.android.okhttp.HttpHandler$CleartextURLFilter.checkURLPermitted(HttpHandler.java:124)\n    com.android.okhttp.internal.huc.HttpURLConnectionImpl.execute(HttpURLConnectionImpl.java:480)\n    com.android.okhttp.internal.huc.HttpURLConnectionImpl.connect(HttpURLConnectionImpl.java:135)\n    construction.site.logistics.foreman.Network.HttpRequestHandler.sendGetRequest(HttpRequestHandler.java:241)\n    construction.site.logistics.foreman.abstraction.Weather$GetWeatherAsyncTask.doInBackground(Weather.java:102)\n    construction.site.logistics.foreman.abstraction.Weather$GetWeatherAsyncTask.doInBackground(Weather.java:37)\n    android.os.AsyncTask$3.call(AsyncTask.java:378)\n    java.util.concurrent.FutureTask.run(FutureTask.java:266)\n    android.os.AsyncTask$SerialExecutor$1.run(AsyncTask.java:289)\n    java.util.concurrent.ThreadPoolExecutor.runWorker(ThreadPoolExecutor.java:1167)\n    java.util.concurrent.ThreadPoolExecutor$Worker.run(ThreadPoolExecutor.java:641)\n    java.lang.Thread.run(Thread.java:919)\n-------------------------------\n\n--------- Message ---------\n\nCleartext HTTP traffic to api.openweathermap.org not permitted\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2021-11-30', '21:11:30'),
(180, '123456785', 'android.view.WindowManager$BadTokenException: Unable to add window -- token android.os.BinderProxy@1978b6e is not valid; is your activity running?\n\n--------- Stack trace ---------\n\n----------38087743822500--------------------OS version:29----------    android.view.ViewRootImpl.setView(ViewRootImpl.java:1126)\n    android.view.WindowManagerGlobal.addView(WindowManagerGlobal.java:450)\n    android.view.WindowManagerImpl.addView(WindowManagerImpl.java:95)\n    android.app.Dialog.show(Dialog.java:473)\n    android.app.ProgressDialog.show(ProgressDialog.java:226)\n    android.app.ProgressDialog.show(ProgressDialog.java:183)\n    android.app.ProgressDialog.show(ProgressDialog.java:168)\n    construction.site.logistics.foreman.abstraction.Functions$3.run(Functions.java:259)\n    android.os.Handler.handleCallback(Handler.java:883)\n    android.os.Handler.dispatchMessage(Handler.java:100)\n    android.os.Looper.loop(Looper.java:237)\n    android.app.ActivityThread.main(ActivityThread.java:8107)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.RuntimeInit$MethodAndArgsCaller.run(RuntimeInit.java:496)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:1100)\n-------------------------------\n\n--------- Message ---------\n\nUnable to add window -- token android.os.BinderProxy@1978b6e is not valid; is your activity running?\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2021-11-30', '21:12:12'),
(181, '123456785', 'android.view.WindowManager$BadTokenException: Unable to add window -- token android.os.BinderProxy@1978b6e is not valid; is your activity running?\n\n--------- Stack trace ---------\n\n----------38126761401027--------------------OS version:29----------    android.view.ViewRootImpl.setView(ViewRootImpl.java:1126)\n    android.view.WindowManagerGlobal.addView(WindowManagerGlobal.java:450)\n    android.view.WindowManagerImpl.addView(WindowManagerImpl.java:95)\n    android.app.Dialog.show(Dialog.java:473)\n    construction.site.logistics.foreman.abstraction.Functions$3.run(Functions.java:264)\n    android.os.Handler.handleCallback(Handler.java:883)\n    android.os.Handler.dispatchMessage(Handler.java:100)\n    android.os.Looper.loop(Looper.java:237)\n    android.app.ActivityThread.main(ActivityThread.java:8107)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.RuntimeInit$MethodAndArgsCaller.run(RuntimeInit.java:496)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:1100)\n-------------------------------\n\n--------- Message ---------\n\nUnable to add window -- token android.os.BinderProxy@1978b6e is not valid; is your activity running?\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2021-11-30', '21:12:38'),
(182, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@af4cde0\n\n--------- Stack trace ---------\n\n----------38215420251879--------------------OS version:29----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1499)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1605)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:678)\n    construction.site.logistics.foreman.MainActivity.unregisterNetworkChanges(MainActivity.java:212)\n    construction.site.logistics.foreman.MainActivity.onDestroy(MainActivity.java:233)\n    android.app.Activity.performDestroy(Activity.java:8219)\n    android.app.Instrumentation.callActivityOnDestroy(Instrumentation.java:1342)\n    android.app.ActivityThread.performDestroyActivity(ActivityThread.java:5405)\n    android.app.ActivityThread.handleDestroyActivity(ActivityThread.java:5454)\n    android.app.ActivityThread.handleRelaunchActivityInner(ActivityThread.java:5739)\n    android.app.ActivityThread.handleRelaunchActivity(ActivityThread.java:5671)\n    android.app.servertransaction.ActivityRelaunchItem.execute(ActivityRelaunchItem.java:69)\n    android.app.servertransaction.TransactionExecutor.executeCallbacks(TransactionExecutor.java:135)\n    android.app.servertransaction.TransactionExecutor.execute(TransactionExecutor.java:95)\n    android.app.ClientTransactionHandler.executeTransaction(ClientTransactionHandler.java:62)\n    android.app.ActivityThread.handleRelaunchActivityLocally(ActivityThread.java:5722)\n    android.app.ActivityThread.access$3700(ActivityThread.java:273)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2271)\n    android.os.Handler.dispatchMessage(Handler.java:107)\n    android.os.Looper.loop(Looper.java:237)\n    android.app.ActivityThread.main(ActivityThread.java:8107)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.RuntimeInit$MethodAndArgsCaller.run(RuntimeInit.java:496)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:1100)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@af4cde0\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2021-11-30', '21:13:42'),
(183, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@7706698\n\n--------- Stack trace ---------\n\n----------38853561323562--------------------OS version:29----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1499)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1605)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:678)\n    construction.site.logistics.foreman.MainActivity.unregisterNetworkChanges(MainActivity.java:212)\n    construction.site.logistics.foreman.MainActivity.onDestroy(MainActivity.java:233)\n    android.app.Activity.performDestroy(Activity.java:8219)\n    android.app.Instrumentation.callActivityOnDestroy(Instrumentation.java:1342)\n    android.app.ActivityThread.performDestroyActivity(ActivityThread.java:5405)\n    android.app.ActivityThread.handleDestroyActivity(ActivityThread.java:5454)\n    android.app.servertransaction.DestroyActivityItem.execute(DestroyActivityItem.java:44)\n    android.app.servertransaction.TransactionExecutor.executeLifecycleState(TransactionExecutor.java:176)\n    android.app.servertransaction.TransactionExecutor.execute(TransactionExecutor.java:97)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:2261)\n    android.os.Handler.dispatchMessage(Handler.java:107)\n    android.os.Looper.loop(Looper.java:237)\n    android.app.ActivityThread.main(ActivityThread.java:8107)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.RuntimeInit$MethodAndArgsCaller.run(RuntimeInit.java:496)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:1100)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@7706698\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2021-11-30', '22:03:12'),
(184, '123456785', 'java.lang.IllegalArgumentException: Receiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@10c1b36\n\n--------- Stack trace ---------\n\n----------90858806058151--------------------OS version:28----------    android.app.LoadedApk.forgetReceiverDispatcher(LoadedApk.java:1262)\n    android.app.ContextImpl.unregisterReceiver(ContextImpl.java:1504)\n    android.content.ContextWrapper.unregisterReceiver(ContextWrapper.java:659)\n    construction.site.logistics.foreman.MainActivity.unregisterNetworkChanges(MainActivity.java:212)\n    construction.site.logistics.foreman.MainActivity.onDestroy(MainActivity.java:233)\n    android.app.Activity.performDestroy(Activity.java:7395)\n    android.app.Instrumentation.callActivityOnDestroy(Instrumentation.java:1307)\n    android.app.ActivityThread.performDestroyActivity(ActivityThread.java:4465)\n    android.app.ActivityThread.handleDestroyActivity(ActivityThread.java:4498)\n    android.app.ActivityThread.handleRelaunchActivityInner(ActivityThread.java:4782)\n    android.app.ActivityThread.handleRelaunchActivity(ActivityThread.java:4715)\n    android.app.servertransaction.ActivityRelaunchItem.execute(ActivityRelaunchItem.java:69)\n    android.app.servertransaction.TransactionExecutor.executeCallbacks(TransactionExecutor.java:108)\n    android.app.servertransaction.TransactionExecutor.execute(TransactionExecutor.java:68)\n    android.app.ClientTransactionHandler.executeTransaction(ClientTransactionHandler.java:55)\n    android.app.ActivityThread.handleRelaunchActivityLocally(ActivityThread.java:4765)\n    android.app.ActivityThread.access$3200(ActivityThread.java:200)\n    android.app.ActivityThread$H.handleMessage(ActivityThread.java:1828)\n    android.os.Handler.dispatchMessage(Handler.java:106)\n    android.os.Looper.loop(Looper.java:193)\n    android.app.ActivityThread.main(ActivityThread.java:6762)\n    java.lang.reflect.Method.invoke(Native Method)\n    com.android.internal.os.RuntimeInit$MethodAndArgsCaller.run(RuntimeInit.java:493)\n    com.android.internal.os.ZygoteInit.main(ZygoteInit.java:858)\n-------------------------------\n\n--------- Message ---------\n\nReceiver not registered: construction.site.logistics.foreman.Network.NetworkStateReceiver@10c1b36\n\n-------------------------------\n\n--------- Cause ---------\n\n-------------------------------\n\n', '2021-12-01', '01:25:36');

-- --------------------------------------------------------

--
-- Table structure for table `daily_meal`
--

CREATE TABLE `daily_meal` (
  `cod_meal` int(11) NOT NULL,
  `description` text NOT NULL,
  `date` date NOT NULL,
  `meal_place` tinyint(4) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `daily_meal_choice`
--

CREATE TABLE `daily_meal_choice` (
  `cod_worker` int(11) NOT NULL,
  `cod_meal` int(11) NOT NULL,
  `date` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `devices_pc`
--

CREATE TABLE `devices_pc` (
  `cod_pc` int(11) NOT NULL,
  `cod_user` int(11) DEFAULT NULL,
  `pc_id` longtext NOT NULL,
  `sw_version` text NOT NULL,
  `date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `latitude` text NOT NULL,
  `longitude` text NOT NULL,
  `enabled` tinyint(4) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `entreprise`
--

CREATE TABLE `entreprise` (
  `cod_entreprise` bigint(20) NOT NULL,
  `name` text NOT NULL,
  `contact` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `entreprise`
--

INSERT INTO `entreprise` (`cod_entreprise`, `name`, `contact`) VALUES
(1, 'company', '123456789');

-- --------------------------------------------------------

--
-- Table structure for table `holidays`
--

CREATE TABLE `holidays` (
  `date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `photos`
--

CREATE TABLE `photos` (
  `cod_photo` int(11) NOT NULL,
  `file` text NOT NULL,
  `cod_table` int(11) DEFAULT NULL,
  `db_table` text NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `photos`
--

INSERT INTO `photos` (`cod_photo`, `file`, `cod_table`, `db_table`) VALUES
(1, 'delivery.jpg', 1, 'site_delivery');

-- --------------------------------------------------------

--
-- Table structure for table `record`
--

CREATE TABLE `record` (
  `cod_record` bigint(11) NOT NULL,
  `cod_worker` int(11) DEFAULT NULL,
  `cod_category` int(11) DEFAULT NULL,
  `cod_site` int(11) DEFAULT NULL,
  `cod_section` int(11) DEFAULT NULL,
  `checkin` time DEFAULT '00:00:00',
  `checkout` time DEFAULT '00:00:00',
  `date` date DEFAULT NULL,
  `status` text NOT NULL,
  `absense` time DEFAULT '00:00:00',
  `notas` text NOT NULL,
  `category_works_duration` time NOT NULL DEFAULT '00:00:00',
  `validation_reason` text NOT NULL,
  `type` tinytext NOT NULL,
  `media_format` text NOT NULL,
  `history` text NOT NULL,
  `tasks` text NOT NULL,
  `timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `record`
--

INSERT INTO `record` (`cod_record`, `cod_worker`, `cod_category`, `cod_site`, `cod_section`, `checkin`, `checkout`, `date`, `status`, `absense`, `notas`, `category_works_duration`, `validation_reason`, `type`, `media_format`, `history`, `tasks`, `timestamp`) VALUES
(1, 1, 1, 1, 1, '08:00:00', '17:00:00', '2020-05-05', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-05-05 11:16:18'),
(2, 1, NULL, 1, 1, '08:00:00', '17:00:00', '2020-06-25', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-06-25 13:49:00'),
(3, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-06-26', 'P', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-06-25 13:49:00'),
(4, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-06-29', 'A', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-06-25 13:49:00'),
(5, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-06-30', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-06-25 13:49:00'),
(6, 1, 1, 1, 1, '08:00:00', '17:00:00', '2020-09-02', 'EP', NULL, '', '00:00:00', '', '', '', '', 'T', '2020-09-02 12:18:03'),
(7, 1, 1, 1, 1, '08:00:00', '17:00:00', '2020-09-03', 'EP', NULL, '', '00:00:00', '', '', '', '', 'T', '2020-09-02 12:18:03'),
(8, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-04', 'EP', NULL, '', '00:00:00', '', '', '', '', 'T', '2020-09-02 12:18:03'),
(9, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-07', 'EP', NULL, '', '00:00:00', '', '', '', '', 'T', '2020-09-02 12:18:03'),
(10, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-08', 'EP', NULL, '', '00:00:00', '', '', '', '', 'T', '2020-09-02 12:18:03'),
(11, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-09', 'A', NULL, '', '00:00:00', '', '', '', '', 'T', '2020-09-02 12:18:03'),
(12, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-10', 'A', NULL, '', '00:00:00', '', '', '', '', 'T', '2020-09-02 12:18:03'),
(13, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-11', 'EP', NULL, '', '00:00:00', '', '', '', '', 'T', '2020-09-02 12:18:03'),
(14, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-14', 'EP', NULL, '', '00:00:00', '', '', '', '', 'T', '2020-09-02 12:18:03'),
(15, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-15', 'P', NULL, '', '00:00:00', '', '', '', '', 'T', '2020-09-02 12:18:03'),
(16, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-16', 'P', NULL, '', '00:00:00', '', '', '', '', 'T', '2020-09-02 12:18:03'),
(17, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-17', 'EP', NULL, '', '00:00:00', '', '', '', '', 'T', '2020-09-02 12:18:03'),
(18, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-18', 'EP', NULL, '', '00:00:00', '', '', '', '', 'T', '2020-09-02 12:18:03'),
(19, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-21', 'P', NULL, '', '00:00:00', '', '', '', '', 'T', '2020-09-02 12:18:03'),
(20, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-22', 'EP', NULL, '', '00:00:00', '', '', '', '', 'T', '2020-09-02 12:18:03'),
(21, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-23', 'EP', NULL, '', '00:00:00', '', '', '', '', 'T', '2020-09-02 12:18:03'),
(22, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-24', 'EP', NULL, '', '00:00:00', '', '', '', '', 'T', '2020-09-02 12:18:03'),
(23, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-25', 'EP', NULL, '', '00:00:00', '', '', '', '', 'T', '2020-09-02 12:18:03'),
(24, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-28', 'EP', NULL, '', '00:00:00', '', '', '', '', 'T', '2020-09-02 12:18:03'),
(25, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-29', 'EP', NULL, '', '00:00:00', '', '', '', '', 'T', '2020-09-02 12:18:03'),
(26, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-30', 'EP', NULL, '', '00:00:00', '', '', '', '', 'T', '2020-09-02 12:18:03'),
(27, 3, 3, 1, 1, '00:00:00', '00:00:00', '2020-09-02', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:17'),
(28, 3, 3, 1, 1, '00:00:00', '00:00:00', '2020-09-03', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:17'),
(29, 3, 3, 1, 1, '00:00:00', '00:00:00', '2020-09-04', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:17'),
(30, 3, 3, 1, 1, '00:00:00', '00:00:00', '2020-09-07', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:17'),
(31, 3, 3, 1, 1, '00:00:00', '00:00:00', '2020-09-08', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:17'),
(32, 3, 3, 1, 1, '00:00:00', '00:00:00', '2020-09-09', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:17'),
(33, 3, 3, 1, 1, '00:00:00', '00:00:00', '2020-09-10', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:17'),
(34, 3, 3, 1, 1, '00:00:00', '00:00:00', '2020-09-11', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:17'),
(35, 3, 3, 1, 1, '00:00:00', '00:00:00', '2020-09-14', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:17'),
(36, 3, 3, 1, 1, '00:00:00', '00:00:00', '2020-09-15', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:17'),
(37, 3, 3, 1, 1, '00:00:00', '00:00:00', '2020-09-16', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:17'),
(38, 3, 3, 1, 1, '00:00:00', '00:00:00', '2020-09-17', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:17'),
(39, 3, 3, 1, 1, '00:00:00', '00:00:00', '2020-09-18', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:17'),
(40, 3, 3, 1, 1, '00:00:00', '00:00:00', '2020-09-21', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:17'),
(41, 3, 3, 1, 1, '00:00:00', '00:00:00', '2020-09-22', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:17'),
(42, 3, 3, 1, 1, '00:00:00', '00:00:00', '2020-09-23', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:17'),
(43, 3, 3, 1, 1, '00:00:00', '00:00:00', '2020-09-24', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:17'),
(44, 3, 3, 1, 1, '08:00:00', '15:00:00', '2020-09-25', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:17'),
(45, 3, 3, 1, 1, '09:00:00', '16:00:00', '2020-09-28', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:17'),
(46, 3, 3, 1, 1, '08:00:00', '20:00:00', '2020-09-29', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:17'),
(47, 3, 3, 1, 1, '06:00:00', '12:00:00', '2020-09-30', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:17'),
(48, 2, 4, 1, 1, '00:00:00', '00:00:00', '2020-09-02', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:27'),
(49, 2, 4, 1, 1, '00:00:00', '00:00:00', '2020-09-03', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:27'),
(50, 2, 4, 1, 1, '00:00:00', '00:00:00', '2020-09-04', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:27'),
(51, 2, 4, 1, 1, '00:00:00', '00:00:00', '2020-09-07', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:27'),
(52, 2, 4, 1, 1, '00:00:00', '00:00:00', '2020-09-08', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:27'),
(53, 2, 4, 1, 1, '00:00:00', '00:00:00', '2020-09-09', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:27'),
(54, 2, 4, 1, 1, '00:00:00', '00:00:00', '2020-09-10', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:27'),
(55, 2, 4, 1, 1, '00:00:00', '00:00:00', '2020-09-11', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:27'),
(56, 2, 4, 1, 1, '00:00:00', '00:00:00', '2020-09-14', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:27'),
(57, 2, 4, 1, 1, '00:00:00', '00:00:00', '2020-09-15', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:27'),
(58, 2, 4, 1, 1, '00:00:00', '00:00:00', '2020-09-16', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:27'),
(59, 2, 4, 1, 1, '08:00:00', '12:00:00', '2020-09-17', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:27'),
(60, 2, 4, 1, 1, '08:00:00', '12:00:00', '2020-09-18', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:27'),
(61, 2, 4, 1, 1, '00:00:00', '00:00:00', '2020-09-21', 'P', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:27'),
(62, 2, 4, 1, 1, '13:31:00', '16:28:00', '2020-09-22', 'P', '00:00:00', '', '00:00:00', '', '-EXTRA-EXTRA-EXTRA-EXTRA-EXTRA-EXTRA-EXTRA-EXTRA-EXTRA-EXTRA-EXTRA-EXTRA-EXTRA-EXTRA', '-NFC card-NFC card-NFC card-NFC card-NFC card-NFC card-NFC card-NFC card-NFC card-NFC card-NFC card-NFC card-NFC card-NFC card', '', '', '2020-09-02 12:47:27'),
(63, 2, 4, 1, 1, '14:34:00', '00:00:00', '2020-09-23', 'EP', '00:00:00', '', '00:00:00', '', '-EXTRA', '-NFC card', '', '', '2020-09-02 12:47:27'),
(64, 2, 4, 1, 1, '00:00:00', '00:00:00', '2020-09-24', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:27'),
(65, 2, 4, 1, 1, '00:00:00', '00:00:00', '2020-09-25', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:27'),
(66, 2, 4, 1, 1, '00:00:00', '00:00:00', '2020-09-28', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:27'),
(67, 2, 4, 1, 1, '00:00:00', '00:00:00', '2020-09-29', 'M', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:27'),
(68, 2, 4, 1, 1, '00:00:00', '00:00:00', '2020-09-30', 'M', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:27'),
(69, 4, 2, 1, 1, '00:00:00', '00:00:00', '2020-09-02', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:32'),
(70, 4, 2, 1, 1, '00:00:00', '00:00:00', '2020-09-03', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:32'),
(71, 4, 2, 1, 1, '00:00:00', '00:00:00', '2020-09-04', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:32'),
(72, 4, 2, 1, 1, '00:00:00', '00:00:00', '2020-09-07', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:32'),
(73, 4, 2, 1, 1, '00:00:00', '00:00:00', '2020-09-08', 'P', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:32'),
(74, 4, 2, 1, 1, '00:00:00', '00:00:00', '2020-09-09', 'P', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:32'),
(75, 4, 2, 1, 1, '00:00:00', '00:00:00', '2020-09-10', 'P', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:32'),
(76, 4, 2, 1, 1, '00:00:00', '00:00:00', '2020-09-11', 'P', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:32'),
(77, 4, 2, 1, 1, '00:00:00', '00:00:00', '2020-09-14', 'P', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:32'),
(78, 4, 2, 1, 1, '00:00:00', '00:00:00', '2020-09-15', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:32'),
(79, 4, 2, 1, 1, '00:00:00', '00:00:00', '2020-09-16', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:32'),
(80, 4, 2, 1, 1, '00:00:00', '00:00:00', '2020-09-17', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:32'),
(81, 4, 2, 1, 1, '00:00:00', '00:00:00', '2020-09-18', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:32'),
(82, 4, 2, 1, 1, '00:00:00', '00:00:00', '2020-09-21', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:32'),
(83, 4, 2, 1, 1, '00:00:00', '00:00:00', '2020-09-22', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:32'),
(84, 4, 2, 1, 1, '00:00:00', '00:00:00', '2020-09-23', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:32'),
(85, 4, 2, 1, 1, '00:00:00', '00:00:00', '2020-09-24', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:32'),
(86, 4, 2, 1, 1, '00:00:00', '00:00:00', '2020-09-25', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:32'),
(87, 4, 2, 1, 1, '00:00:00', '00:00:00', '2020-09-28', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:32'),
(88, 4, 2, 1, 1, '00:00:00', '00:00:00', '2020-09-29', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:32'),
(89, 4, 2, 1, 1, '00:00:00', '00:00:00', '2020-09-30', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-02 12:47:32'),
(90, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-01', 'EP', NULL, '', '00:00:00', '', '', '', '', 'T', '2020-09-05 07:47:24'),
(91, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-05', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-05 07:51:06'),
(92, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-06', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-05 07:51:06'),
(93, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-12', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-05 07:51:38'),
(94, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-13', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-05 07:51:38'),
(95, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-19', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-05 07:51:55'),
(96, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-20', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-05 07:51:55'),
(97, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-26', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-05 07:52:12'),
(98, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-09-27', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-09-05 07:52:12'),
(99, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-11-17', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:10'),
(100, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-11-18', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:10'),
(101, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-11-19', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:10'),
(102, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-11-20', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:10'),
(103, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-11-23', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:10'),
(104, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-11-24', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:10'),
(105, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-11-25', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:10'),
(106, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-11-26', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:10'),
(107, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-11-27', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:10'),
(108, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-11-30', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:10'),
(109, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-12-01', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:28'),
(110, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-12-02', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:28'),
(111, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-12-03', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:28'),
(112, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-12-04', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:28'),
(113, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-12-07', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:28'),
(114, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-12-08', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:28'),
(115, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-12-09', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:28'),
(116, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-12-10', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:28'),
(117, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-12-11', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:28'),
(118, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-12-14', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:28'),
(119, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-12-15', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:28'),
(120, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-12-16', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:28'),
(121, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-12-17', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:28'),
(122, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-12-18', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:28'),
(123, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-12-21', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:28'),
(124, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-12-22', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:28'),
(125, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-12-23', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:28'),
(126, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-12-24', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:28'),
(127, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-12-25', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:28'),
(128, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-12-28', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:28'),
(129, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-12-29', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:28'),
(130, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-12-30', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:28'),
(131, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2020-12-31', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:28'),
(132, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-01-01', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:38'),
(133, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-01-04', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:38'),
(134, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-01-05', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:38'),
(135, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-01-06', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:38'),
(136, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-01-07', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:38'),
(137, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-01-08', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:38'),
(138, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-01-11', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:38'),
(139, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-01-12', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:38'),
(140, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-01-13', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:38'),
(141, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-01-14', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:38'),
(142, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-01-15', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:38'),
(143, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-01-18', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:38'),
(144, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-01-19', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:38'),
(145, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-01-20', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:38'),
(146, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-01-21', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:38'),
(147, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-01-22', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:38'),
(148, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-01-25', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:38'),
(149, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-01-26', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:38'),
(150, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-01-27', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:38'),
(151, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-01-28', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:38'),
(152, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-01-29', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:38'),
(153, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-02-01', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:53'),
(154, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-02-02', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:53'),
(155, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-02-03', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:53'),
(156, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-02-04', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:53'),
(157, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-02-05', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:53'),
(158, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-02-08', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:53'),
(159, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-02-09', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:53'),
(160, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-02-10', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:53'),
(161, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-02-11', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:53'),
(162, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-02-12', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:53'),
(163, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-02-15', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:53'),
(164, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-02-16', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:53'),
(165, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-02-17', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:53'),
(166, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-02-18', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:53'),
(167, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-02-19', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:53'),
(168, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-02-22', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:53'),
(169, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-02-23', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:53'),
(170, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-02-24', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:53'),
(171, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-02-25', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:53'),
(172, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-02-26', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:53:53'),
(173, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-03-01', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:07'),
(174, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-03-02', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:07'),
(175, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-03-03', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:07'),
(176, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-03-04', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:07'),
(177, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-03-05', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:07'),
(178, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-03-08', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:07'),
(179, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-03-09', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:07'),
(180, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-03-10', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:07'),
(181, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-03-11', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:07'),
(182, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-03-12', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:07'),
(183, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-03-15', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:07'),
(184, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-03-16', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:07'),
(185, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-03-17', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:07'),
(186, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-03-18', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:07'),
(187, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-03-19', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:07'),
(188, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-03-22', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:07'),
(189, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-03-23', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:07'),
(190, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-03-24', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:07'),
(191, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-03-25', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:07'),
(192, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-03-26', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:07'),
(193, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-03-29', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:07'),
(194, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-03-30', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:07'),
(195, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-03-31', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:07'),
(196, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-04-01', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:21'),
(197, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-04-02', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:21'),
(198, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-04-05', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:21'),
(199, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-04-06', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:21'),
(200, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-04-07', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:21'),
(201, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-04-08', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:21'),
(202, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-04-09', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:21'),
(203, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-04-12', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:21'),
(204, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-04-13', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:21'),
(205, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-04-14', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:21'),
(206, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-04-15', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:21'),
(207, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-04-16', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:21'),
(208, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-04-19', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:21'),
(209, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-04-20', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:21'),
(210, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-04-21', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:21'),
(211, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-04-22', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:21'),
(212, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-04-23', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:21'),
(213, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-04-26', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:21'),
(214, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-04-27', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:21'),
(215, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-04-28', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:21'),
(216, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-04-29', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:21'),
(217, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-04-30', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:21'),
(218, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-05-03', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:29'),
(219, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-05-04', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:29'),
(220, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-05-05', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:29'),
(221, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-05-06', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:29'),
(222, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-05-07', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:29'),
(223, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-05-10', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:29'),
(224, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-05-11', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:29'),
(225, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-05-12', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:29'),
(226, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-05-13', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:29'),
(227, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-05-14', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:29'),
(228, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-05-17', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:29'),
(229, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-05-18', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:29'),
(230, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-05-19', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:29'),
(231, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-05-20', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:29'),
(232, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-05-21', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:29'),
(233, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-05-24', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:29'),
(234, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-05-25', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:29'),
(235, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-05-26', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:29'),
(236, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-05-27', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:29'),
(237, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-05-28', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:29'),
(238, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-05-31', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:29'),
(239, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-06-01', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:38'),
(240, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-06-02', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:38'),
(241, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-06-03', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:38'),
(242, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-06-04', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:38'),
(243, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-06-07', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:38'),
(244, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-06-08', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:38'),
(245, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-06-09', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:38'),
(246, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-06-10', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:38'),
(247, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-06-11', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:38'),
(248, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-06-14', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:38'),
(249, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-06-15', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:38'),
(250, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-06-16', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:38'),
(251, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-06-17', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:38'),
(252, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-06-18', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:38'),
(253, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-06-21', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:38'),
(254, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-06-22', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:38'),
(255, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-06-23', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:38'),
(256, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-06-24', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:38'),
(257, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-06-25', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:38'),
(258, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-06-28', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:38'),
(259, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-06-29', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:38'),
(260, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-06-30', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:38'),
(261, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-07-01', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:49'),
(262, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-07-02', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:49'),
(263, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-07-05', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:49'),
(264, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-07-06', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:49'),
(265, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-07-07', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:49'),
(266, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-07-08', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:49'),
(267, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-07-09', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:49'),
(268, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-07-12', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:49'),
(269, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-07-13', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:49'),
(270, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-07-14', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:49'),
(271, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-07-15', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:49'),
(272, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-07-16', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:49'),
(273, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-07-19', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:49'),
(274, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-07-20', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:49'),
(275, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-07-21', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:49'),
(276, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-07-22', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:49'),
(277, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-07-23', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:49'),
(278, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-07-26', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:49'),
(279, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-07-27', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:49'),
(280, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-07-28', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:49'),
(281, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-07-29', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:49'),
(282, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-07-30', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:54:49'),
(283, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-08-02', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:01'),
(284, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-08-03', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:01'),
(285, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-08-04', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:01'),
(286, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-08-05', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:01'),
(287, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-08-06', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:01'),
(288, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-08-09', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:01'),
(289, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-08-10', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:01'),
(290, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-08-11', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:01'),
(291, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-08-12', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:01'),
(292, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-08-13', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:01'),
(293, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-08-16', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:01'),
(294, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-08-17', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:01'),
(295, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-08-18', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:01'),
(296, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-08-19', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:01'),
(297, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-08-20', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:01'),
(298, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-08-23', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:01'),
(299, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-08-24', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:01'),
(300, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-08-25', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:01'),
(301, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-08-26', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:01'),
(302, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-08-27', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:01'),
(303, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-08-30', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:01'),
(304, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-08-31', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:01'),
(305, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-09-01', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:09'),
(306, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-09-02', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:09'),
(307, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-09-03', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:09'),
(308, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-09-06', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:09'),
(309, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-09-07', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:09'),
(310, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-09-08', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:09'),
(311, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-09-09', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:09'),
(312, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-09-10', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:09'),
(313, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-09-13', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:09'),
(314, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-09-14', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:09'),
(315, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-09-15', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:09'),
(316, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-09-16', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:09'),
(317, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-09-17', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:09'),
(318, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-09-20', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:09'),
(319, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-09-21', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:09'),
(320, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-09-22', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:09'),
(321, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-09-23', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:09'),
(322, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-09-24', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:09'),
(323, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-09-27', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:09'),
(324, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-09-28', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:09'),
(325, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-09-29', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:09'),
(326, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-09-30', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:09'),
(327, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-10-01', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:16'),
(328, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-10-04', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:16'),
(329, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-10-05', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:16'),
(330, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-10-06', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:16'),
(331, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-10-07', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:16'),
(332, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-10-08', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:16'),
(333, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-10-11', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:16'),
(334, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-10-12', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:16'),
(335, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-10-13', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:16'),
(336, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-10-14', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:16'),
(337, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-10-15', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:16'),
(338, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-10-18', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:16'),
(339, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-10-19', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:16'),
(340, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-10-20', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:16'),
(341, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-10-21', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:16'),
(342, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-10-22', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:16'),
(343, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-10-25', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:16'),
(344, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-10-26', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:16'),
(345, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-10-27', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:16'),
(346, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-10-28', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:16'),
(347, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-10-29', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:16'),
(348, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-11-01', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:24'),
(349, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-11-02', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:24'),
(350, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-11-03', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:24'),
(351, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-11-04', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:24'),
(352, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-11-05', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:24'),
(353, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-11-08', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:24'),
(354, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-11-09', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:24'),
(355, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-11-10', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:24'),
(356, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-11-11', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:24'),
(357, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-11-12', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:24'),
(358, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-11-15', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:24'),
(359, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-11-16', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:24'),
(360, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-11-17', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:24'),
(361, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-11-18', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:24'),
(362, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-11-19', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:24'),
(363, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-11-22', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:24'),
(364, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-11-23', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:24'),
(365, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-11-24', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:24'),
(366, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-11-25', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:24'),
(367, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-11-26', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:24'),
(368, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-11-29', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:24'),
(369, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-11-30', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:24'),
(370, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-12-01', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:32');
INSERT INTO `record` (`cod_record`, `cod_worker`, `cod_category`, `cod_site`, `cod_section`, `checkin`, `checkout`, `date`, `status`, `absense`, `notas`, `category_works_duration`, `validation_reason`, `type`, `media_format`, `history`, `tasks`, `timestamp`) VALUES
(371, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-12-02', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:32'),
(372, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-12-03', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:32'),
(373, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-12-06', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:32'),
(374, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-12-07', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:32'),
(375, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-12-08', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:32'),
(376, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-12-09', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:32'),
(377, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-12-10', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:32'),
(378, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-12-13', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:32'),
(379, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-12-14', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:32'),
(380, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-12-15', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:32'),
(381, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-12-16', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:32'),
(382, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-12-17', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:32'),
(383, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-12-20', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:32'),
(384, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-12-21', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:32'),
(385, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-12-22', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:32'),
(386, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-12-23', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:32'),
(387, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-12-24', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:32'),
(388, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-12-27', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:32'),
(389, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-12-28', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:32'),
(390, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-12-29', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:32'),
(391, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-12-30', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:32'),
(392, 1, NULL, 1, 1, '00:00:00', '00:00:00', '2021-12-31', 'EP', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-17 18:55:32'),
(393, 1, 1, 1, 1, '08:31:22', '16:31:22', '2020-11-26', '', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-11-26 09:31:57');

-- --------------------------------------------------------

--
-- Table structure for table `requests`
--

CREATE TABLE `requests` (
  `cod_request` int(11) NOT NULL,
  `field` text NOT NULL,
  `new_value` text NOT NULL,
  `db_table` text NOT NULL,
  `motif` mediumtext NOT NULL,
  `cod_worker` int(11) DEFAULT NULL,
  `date` date NOT NULL DEFAULT '1970-01-01'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `settings`
--

CREATE TABLE `settings` (
  `cod_setting` int(11) NOT NULL,
  `disable_checkin` int(11) NOT NULL DEFAULT '0',
  `disable_checkout` int(11) NOT NULL DEFAULT '0',
  `work_hours` time NOT NULL DEFAULT '08:00:00',
  `max_days_delay_validation` int(11) NOT NULL DEFAULT '1',
  `company_name` mediumtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `settings_apps_menu`
--

CREATE TABLE `settings_apps_menu` (
  `cod_menu` int(11) NOT NULL,
  `cod_sub_menu` int(11) DEFAULT NULL,
  `description` int(11) DEFAULT NULL COMMENT 'json translations',
  `enabled` int(11) NOT NULL DEFAULT '0',
  `type` int(11) NOT NULL DEFAULT '1' COMMENT '0: title, 1: task, 2:subtitle',
  `loading` int(11) DEFAULT NULL COMMENT 'what to load',
  `userId` int(11) DEFAULT NULL,
  `user_type` int(11) DEFAULT NULL,
  `app` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `site`
--

CREATE TABLE `site` (
  `cod_site` bigint(20) NOT NULL,
  `name` text NOT NULL,
  `address` text NOT NULL,
  `initials` text NOT NULL,
  `gps_lat` text NOT NULL,
  `gps_lon` text NOT NULL,
  `ref_contrato` tinytext NOT NULL,
  `cod_company` int(11) NOT NULL DEFAULT '0',
  `data_inicio` date NOT NULL DEFAULT '1970-01-01',
  `data_fim` date NOT NULL DEFAULT '1970-01-01',
  `distancia` float DEFAULT '0',
  `authentication_radius` float DEFAULT '1000',
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `project_languages` tinytext NOT NULL,
  `primary_lang` tinytext NOT NULL,
  `regie_hourly` double NOT NULL DEFAULT '0',
  `craneman_hourly` double NOT NULL DEFAULT '0',
  `machinist_hourly` double NOT NULL DEFAULT '0',
  `regie_after_hours` double NOT NULL DEFAULT '0',
  `machinist_after_hours` double NOT NULL DEFAULT '0',
  `craneman_after_hours` double NOT NULL DEFAULT '0',
  `regie_weekends` double NOT NULL DEFAULT '0',
  `machinist_weekends` double NOT NULL DEFAULT '0',
  `craneman_weekends` double NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `site`
--

INSERT INTO `site` (`cod_site`, `name`, `address`, `initials`, `gps_lat`, `gps_lon`, `ref_contrato`, `cod_company`, `data_inicio`, `data_fim`, `distancia`, `authentication_radius`, `active`, `project_languages`, `primary_lang`, `regie_hourly`, `craneman_hourly`, `machinist_hourly`, `regie_after_hours`, `machinist_after_hours`, `craneman_after_hours`, `regie_weekends`, `machinist_weekends`, `craneman_weekends`) VALUES
(1, 'Construction Site', 'address', 'TST', '0', '0', '0', 1, '1970-01-01', '2030-01-01', 0, 0, 1, '', 'en', 0, 0, 0, 0, 0, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `site_chef_equipe`
--

CREATE TABLE `site_chef_equipe` (
  `cod_chef_equipe` int(11) NOT NULL,
  `cod_worker` int(11) DEFAULT NULL,
  `cod_site` int(11) DEFAULT NULL,
  `cod_section` int(11) DEFAULT NULL,
  `date` date NOT NULL DEFAULT '1970-01-01'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `site_chef_equipe`
--

INSERT INTO `site_chef_equipe` (`cod_chef_equipe`, `cod_worker`, `cod_site`, `cod_section`, `date`) VALUES
(1, 1, 1, 1, '2020-06-25'),
(2, 1, 1, 1, '2020-06-26'),
(3, 1, 1, 1, '2020-06-29'),
(4, 1, 1, 1, '2020-06-30'),
(5, 1, 1, 1, '2020-09-02'),
(6, 1, 1, 1, '2020-09-03'),
(7, 1, 1, 1, '2020-09-04'),
(8, 1, 1, 1, '2020-09-07'),
(9, 1, 1, 1, '2020-09-08'),
(10, 1, 1, 1, '2020-09-09'),
(11, 1, 1, 1, '2020-09-10'),
(12, 1, 1, 1, '2020-09-11'),
(13, 1, 1, 1, '2020-09-14'),
(14, 1, 1, 1, '2020-09-15'),
(15, 1, 1, 1, '2020-09-16'),
(16, 1, 1, 1, '2020-09-17'),
(17, 1, 1, 1, '2020-09-18'),
(18, 1, 1, 1, '2020-09-21'),
(19, 1, 1, 1, '2020-09-22'),
(20, 1, 1, 1, '2020-09-23'),
(21, 1, 1, 1, '2020-09-24'),
(22, 1, 1, 1, '2020-09-25'),
(23, 1, 1, 1, '2020-09-28'),
(24, 1, 1, 1, '2020-09-29'),
(25, 1, 1, 1, '2020-09-30'),
(26, 3, 1, 1, '2020-09-02'),
(27, 3, 1, 1, '2020-09-03'),
(28, 3, 1, 1, '2020-09-04'),
(29, 3, 1, 1, '2020-09-07'),
(30, 3, 1, 1, '2020-09-08'),
(31, 3, 1, 1, '2020-09-09'),
(32, 3, 1, 1, '2020-09-10'),
(33, 3, 1, 1, '2020-09-11'),
(34, 3, 1, 1, '2020-09-14'),
(35, 3, 1, 1, '2020-09-15'),
(36, 3, 1, 1, '2020-09-16'),
(37, 3, 1, 1, '2020-09-17'),
(38, 3, 1, 1, '2020-09-18'),
(39, 3, 1, 1, '2020-09-21'),
(40, 3, 1, 1, '2020-09-22'),
(41, 3, 1, 1, '2020-09-23'),
(42, 3, 1, 1, '2020-09-24'),
(43, 3, 1, 1, '2020-09-25'),
(44, 3, 1, 1, '2020-09-28'),
(45, 3, 1, 1, '2020-09-29'),
(46, 3, 1, 1, '2020-09-30'),
(47, 2, 1, 1, '2020-09-02'),
(48, 2, 1, 1, '2020-09-03'),
(49, 2, 1, 1, '2020-09-04'),
(50, 2, 1, 1, '2020-09-07'),
(51, 2, 1, 1, '2020-09-08'),
(52, 2, 1, 1, '2020-09-09'),
(53, 2, 1, 1, '2020-09-10'),
(54, 2, 1, 1, '2020-09-11'),
(55, 2, 1, 1, '2020-09-14'),
(56, 2, 1, 1, '2020-09-15'),
(57, 2, 1, 1, '2020-09-16'),
(58, 2, 1, 1, '2020-09-17'),
(59, 2, 1, 1, '2020-09-18'),
(60, 2, 1, 1, '2020-09-21'),
(61, 2, 1, 1, '2020-09-22'),
(62, 2, 1, 1, '2020-09-23'),
(63, 2, 1, 1, '2020-09-24'),
(64, 2, 1, 1, '2020-09-25'),
(65, 2, 1, 1, '2020-09-28'),
(66, 2, 1, 1, '2020-09-29'),
(67, 2, 1, 1, '2020-09-30'),
(68, 4, 1, 1, '2020-09-02'),
(69, 4, 1, 1, '2020-09-03'),
(70, 4, 1, 1, '2020-09-04'),
(71, 4, 1, 1, '2020-09-07'),
(72, 4, 1, 1, '2020-09-08'),
(73, 4, 1, 1, '2020-09-09'),
(74, 4, 1, 1, '2020-09-10'),
(75, 4, 1, 1, '2020-09-11'),
(76, 4, 1, 1, '2020-09-14'),
(77, 4, 1, 1, '2020-09-15'),
(78, 4, 1, 1, '2020-09-16'),
(79, 4, 1, 1, '2020-09-17'),
(80, 4, 1, 1, '2020-09-18'),
(81, 4, 1, 1, '2020-09-21'),
(82, 4, 1, 1, '2020-09-22'),
(83, 4, 1, 1, '2020-09-23'),
(84, 4, 1, 1, '2020-09-24'),
(85, 4, 1, 1, '2020-09-25'),
(86, 4, 1, 1, '2020-09-28'),
(87, 4, 1, 1, '2020-09-29'),
(88, 4, 1, 1, '2020-09-30'),
(89, 1, 1, 1, '2020-09-01'),
(90, 1, 1, 1, '2020-09-02'),
(91, 1, 1, 1, '2020-09-03'),
(92, 1, 1, 1, '2020-09-04'),
(93, 1, 1, 1, '2020-09-07'),
(94, 1, 1, 1, '2020-09-08'),
(95, 1, 1, 1, '2020-09-09'),
(96, 1, 1, 1, '2020-09-10'),
(97, 1, 1, 1, '2020-09-11'),
(98, 1, 1, 1, '2020-09-14'),
(99, 1, 1, 1, '2020-09-15'),
(100, 1, 1, 1, '2020-09-16'),
(101, 1, 1, 1, '2020-09-17'),
(102, 1, 1, 1, '2020-09-18'),
(103, 1, 1, 1, '2020-09-21'),
(104, 1, 1, 1, '2020-09-22'),
(105, 1, 1, 1, '2020-09-23'),
(106, 1, 1, 1, '2020-09-24'),
(107, 1, 1, 1, '2020-09-25'),
(108, 1, 1, 1, '2020-09-28'),
(109, 1, 1, 1, '2020-09-29'),
(110, 1, 1, 1, '2020-09-30'),
(111, 1, 1, 1, '2020-09-05'),
(112, 1, 1, 1, '2020-09-06'),
(113, 1, 1, 1, '2020-09-12'),
(114, 1, 1, 1, '2020-09-13'),
(115, 1, 1, 1, '2020-09-19'),
(116, 1, 1, 1, '2020-09-20'),
(117, 1, 1, 1, '2020-09-26'),
(118, 1, 1, 1, '2020-09-27'),
(119, 1, 1, 1, '2020-11-17'),
(120, 1, 1, 1, '2020-11-18'),
(121, 1, 1, 1, '2020-11-19'),
(122, 1, 1, 1, '2020-11-20'),
(123, 1, 1, 1, '2020-11-23'),
(124, 1, 1, 1, '2020-11-24'),
(125, 1, 1, 1, '2020-11-25'),
(126, 1, 1, 1, '2020-11-26'),
(127, 1, 1, 1, '2020-11-27'),
(128, 1, 1, 1, '2020-11-30'),
(129, 1, 1, 1, '2020-12-01'),
(130, 1, 1, 1, '2020-12-02'),
(131, 1, 1, 1, '2020-12-03'),
(132, 1, 1, 1, '2020-12-04'),
(133, 1, 1, 1, '2020-12-07'),
(134, 1, 1, 1, '2020-12-08'),
(135, 1, 1, 1, '2020-12-09'),
(136, 1, 1, 1, '2020-12-10'),
(137, 1, 1, 1, '2020-12-11'),
(138, 1, 1, 1, '2020-12-14'),
(139, 1, 1, 1, '2020-12-15'),
(140, 1, 1, 1, '2020-12-16'),
(141, 1, 1, 1, '2020-12-17'),
(142, 1, 1, 1, '2020-12-18'),
(143, 1, 1, 1, '2020-12-21'),
(144, 1, 1, 1, '2020-12-22'),
(145, 1, 1, 1, '2020-12-23'),
(146, 1, 1, 1, '2020-12-24'),
(147, 1, 1, 1, '2020-12-25'),
(148, 1, 1, 1, '2020-12-28'),
(149, 1, 1, 1, '2020-12-29'),
(150, 1, 1, 1, '2020-12-30'),
(151, 1, 1, 1, '2020-12-31'),
(152, 1, 1, 1, '2021-01-01'),
(153, 1, 1, 1, '2021-01-04'),
(154, 1, 1, 1, '2021-01-05'),
(155, 1, 1, 1, '2021-01-06'),
(156, 1, 1, 1, '2021-01-07'),
(157, 1, 1, 1, '2021-01-08'),
(158, 1, 1, 1, '2021-01-11'),
(159, 1, 1, 1, '2021-01-12'),
(160, 1, 1, 1, '2021-01-13'),
(161, 1, 1, 1, '2021-01-14'),
(162, 1, 1, 1, '2021-01-15'),
(163, 1, 1, 1, '2021-01-18'),
(164, 1, 1, 1, '2021-01-19'),
(165, 1, 1, 1, '2021-01-20'),
(166, 1, 1, 1, '2021-01-21'),
(167, 1, 1, 1, '2021-01-22'),
(168, 1, 1, 1, '2021-01-25'),
(169, 1, 1, 1, '2021-01-26'),
(170, 1, 1, 1, '2021-01-27'),
(171, 1, 1, 1, '2021-01-28'),
(172, 1, 1, 1, '2021-01-29'),
(173, 1, 1, 1, '2021-02-01'),
(174, 1, 1, 1, '2021-02-02'),
(175, 1, 1, 1, '2021-02-03'),
(176, 1, 1, 1, '2021-02-04'),
(177, 1, 1, 1, '2021-02-05'),
(178, 1, 1, 1, '2021-02-08'),
(179, 1, 1, 1, '2021-02-09'),
(180, 1, 1, 1, '2021-02-10'),
(181, 1, 1, 1, '2021-02-11'),
(182, 1, 1, 1, '2021-02-12'),
(183, 1, 1, 1, '2021-02-15'),
(184, 1, 1, 1, '2021-02-16'),
(185, 1, 1, 1, '2021-02-17'),
(186, 1, 1, 1, '2021-02-18'),
(187, 1, 1, 1, '2021-02-19'),
(188, 1, 1, 1, '2021-02-22'),
(189, 1, 1, 1, '2021-02-23'),
(190, 1, 1, 1, '2021-02-24'),
(191, 1, 1, 1, '2021-02-25'),
(192, 1, 1, 1, '2021-02-26'),
(193, 1, 1, 1, '2021-03-01'),
(194, 1, 1, 1, '2021-03-02'),
(195, 1, 1, 1, '2021-03-03'),
(196, 1, 1, 1, '2021-03-04'),
(197, 1, 1, 1, '2021-03-05'),
(198, 1, 1, 1, '2021-03-08'),
(199, 1, 1, 1, '2021-03-09'),
(200, 1, 1, 1, '2021-03-10'),
(201, 1, 1, 1, '2021-03-11'),
(202, 1, 1, 1, '2021-03-12'),
(203, 1, 1, 1, '2021-03-15'),
(204, 1, 1, 1, '2021-03-16'),
(205, 1, 1, 1, '2021-03-17'),
(206, 1, 1, 1, '2021-03-18'),
(207, 1, 1, 1, '2021-03-19'),
(208, 1, 1, 1, '2021-03-22'),
(209, 1, 1, 1, '2021-03-23'),
(210, 1, 1, 1, '2021-03-24'),
(211, 1, 1, 1, '2021-03-25'),
(212, 1, 1, 1, '2021-03-26'),
(213, 1, 1, 1, '2021-03-29'),
(214, 1, 1, 1, '2021-03-30'),
(215, 1, 1, 1, '2021-03-31'),
(216, 1, 1, 1, '2021-04-01'),
(217, 1, 1, 1, '2021-04-02'),
(218, 1, 1, 1, '2021-04-05'),
(219, 1, 1, 1, '2021-04-06'),
(220, 1, 1, 1, '2021-04-07'),
(221, 1, 1, 1, '2021-04-08'),
(222, 1, 1, 1, '2021-04-09'),
(223, 1, 1, 1, '2021-04-12'),
(224, 1, 1, 1, '2021-04-13'),
(225, 1, 1, 1, '2021-04-14'),
(226, 1, 1, 1, '2021-04-15'),
(227, 1, 1, 1, '2021-04-16'),
(228, 1, 1, 1, '2021-04-19'),
(229, 1, 1, 1, '2021-04-20'),
(230, 1, 1, 1, '2021-04-21'),
(231, 1, 1, 1, '2021-04-22'),
(232, 1, 1, 1, '2021-04-23'),
(233, 1, 1, 1, '2021-04-26'),
(234, 1, 1, 1, '2021-04-27'),
(235, 1, 1, 1, '2021-04-28'),
(236, 1, 1, 1, '2021-04-29'),
(237, 1, 1, 1, '2021-04-30'),
(238, 1, 1, 1, '2021-05-03'),
(239, 1, 1, 1, '2021-05-04'),
(240, 1, 1, 1, '2021-05-05'),
(241, 1, 1, 1, '2021-05-06'),
(242, 1, 1, 1, '2021-05-07'),
(243, 1, 1, 1, '2021-05-10'),
(244, 1, 1, 1, '2021-05-11'),
(245, 1, 1, 1, '2021-05-12'),
(246, 1, 1, 1, '2021-05-13'),
(247, 1, 1, 1, '2021-05-14'),
(248, 1, 1, 1, '2021-05-17'),
(249, 1, 1, 1, '2021-05-18'),
(250, 1, 1, 1, '2021-05-19'),
(251, 1, 1, 1, '2021-05-20'),
(252, 1, 1, 1, '2021-05-21'),
(253, 1, 1, 1, '2021-05-24'),
(254, 1, 1, 1, '2021-05-25'),
(255, 1, 1, 1, '2021-05-26'),
(256, 1, 1, 1, '2021-05-27'),
(257, 1, 1, 1, '2021-05-28'),
(258, 1, 1, 1, '2021-05-31'),
(259, 1, 1, 1, '2021-06-01'),
(260, 1, 1, 1, '2021-06-02'),
(261, 1, 1, 1, '2021-06-03'),
(262, 1, 1, 1, '2021-06-04'),
(263, 1, 1, 1, '2021-06-07'),
(264, 1, 1, 1, '2021-06-08'),
(265, 1, 1, 1, '2021-06-09'),
(266, 1, 1, 1, '2021-06-10'),
(267, 1, 1, 1, '2021-06-11'),
(268, 1, 1, 1, '2021-06-14'),
(269, 1, 1, 1, '2021-06-15'),
(270, 1, 1, 1, '2021-06-16'),
(271, 1, 1, 1, '2021-06-17'),
(272, 1, 1, 1, '2021-06-18'),
(273, 1, 1, 1, '2021-06-21'),
(274, 1, 1, 1, '2021-06-22'),
(275, 1, 1, 1, '2021-06-23'),
(276, 1, 1, 1, '2021-06-24'),
(277, 1, 1, 1, '2021-06-25'),
(278, 1, 1, 1, '2021-06-28'),
(279, 1, 1, 1, '2021-06-29'),
(280, 1, 1, 1, '2021-06-30'),
(281, 1, 1, 1, '2021-07-01'),
(282, 1, 1, 1, '2021-07-02'),
(283, 1, 1, 1, '2021-07-05'),
(284, 1, 1, 1, '2021-07-06'),
(285, 1, 1, 1, '2021-07-07'),
(286, 1, 1, 1, '2021-07-08'),
(287, 1, 1, 1, '2021-07-09'),
(288, 1, 1, 1, '2021-07-12'),
(289, 1, 1, 1, '2021-07-13'),
(290, 1, 1, 1, '2021-07-14'),
(291, 1, 1, 1, '2021-07-15'),
(292, 1, 1, 1, '2021-07-16'),
(293, 1, 1, 1, '2021-07-19'),
(294, 1, 1, 1, '2021-07-20'),
(295, 1, 1, 1, '2021-07-21'),
(296, 1, 1, 1, '2021-07-22'),
(297, 1, 1, 1, '2021-07-23'),
(298, 1, 1, 1, '2021-07-26'),
(299, 1, 1, 1, '2021-07-27'),
(300, 1, 1, 1, '2021-07-28'),
(301, 1, 1, 1, '2021-07-29'),
(302, 1, 1, 1, '2021-07-30'),
(303, 1, 1, 1, '2021-08-02'),
(304, 1, 1, 1, '2021-08-03'),
(305, 1, 1, 1, '2021-08-04'),
(306, 1, 1, 1, '2021-08-05'),
(307, 1, 1, 1, '2021-08-06'),
(308, 1, 1, 1, '2021-08-09'),
(309, 1, 1, 1, '2021-08-10'),
(310, 1, 1, 1, '2021-08-11'),
(311, 1, 1, 1, '2021-08-12'),
(312, 1, 1, 1, '2021-08-13'),
(313, 1, 1, 1, '2021-08-16'),
(314, 1, 1, 1, '2021-08-17'),
(315, 1, 1, 1, '2021-08-18'),
(316, 1, 1, 1, '2021-08-19'),
(317, 1, 1, 1, '2021-08-20'),
(318, 1, 1, 1, '2021-08-23'),
(319, 1, 1, 1, '2021-08-24'),
(320, 1, 1, 1, '2021-08-25'),
(321, 1, 1, 1, '2021-08-26'),
(322, 1, 1, 1, '2021-08-27'),
(323, 1, 1, 1, '2021-08-30'),
(324, 1, 1, 1, '2021-08-31'),
(325, 1, 1, 1, '2021-09-01'),
(326, 1, 1, 1, '2021-09-02'),
(327, 1, 1, 1, '2021-09-03'),
(328, 1, 1, 1, '2021-09-06'),
(329, 1, 1, 1, '2021-09-07'),
(330, 1, 1, 1, '2021-09-08'),
(331, 1, 1, 1, '2021-09-09'),
(332, 1, 1, 1, '2021-09-10'),
(333, 1, 1, 1, '2021-09-13'),
(334, 1, 1, 1, '2021-09-14'),
(335, 1, 1, 1, '2021-09-15'),
(336, 1, 1, 1, '2021-09-16'),
(337, 1, 1, 1, '2021-09-17'),
(338, 1, 1, 1, '2021-09-20'),
(339, 1, 1, 1, '2021-09-21'),
(340, 1, 1, 1, '2021-09-22'),
(341, 1, 1, 1, '2021-09-23'),
(342, 1, 1, 1, '2021-09-24'),
(343, 1, 1, 1, '2021-09-27'),
(344, 1, 1, 1, '2021-09-28'),
(345, 1, 1, 1, '2021-09-29'),
(346, 1, 1, 1, '2021-09-30'),
(347, 1, 1, 1, '2021-10-01'),
(348, 1, 1, 1, '2021-10-04'),
(349, 1, 1, 1, '2021-10-05'),
(350, 1, 1, 1, '2021-10-06'),
(351, 1, 1, 1, '2021-10-07'),
(352, 1, 1, 1, '2021-10-08'),
(353, 1, 1, 1, '2021-10-11'),
(354, 1, 1, 1, '2021-10-12'),
(355, 1, 1, 1, '2021-10-13'),
(356, 1, 1, 1, '2021-10-14'),
(357, 1, 1, 1, '2021-10-15'),
(358, 1, 1, 1, '2021-10-18'),
(359, 1, 1, 1, '2021-10-19'),
(360, 1, 1, 1, '2021-10-20'),
(361, 1, 1, 1, '2021-10-21'),
(362, 1, 1, 1, '2021-10-22'),
(363, 1, 1, 1, '2021-10-25'),
(364, 1, 1, 1, '2021-10-26'),
(365, 1, 1, 1, '2021-10-27'),
(366, 1, 1, 1, '2021-10-28'),
(367, 1, 1, 1, '2021-10-29'),
(368, 1, 1, 1, '2021-11-01'),
(369, 1, 1, 1, '2021-11-02'),
(370, 1, 1, 1, '2021-11-03'),
(371, 1, 1, 1, '2021-11-04'),
(372, 1, 1, 1, '2021-11-05'),
(373, 1, 1, 1, '2021-11-08'),
(374, 1, 1, 1, '2021-11-09'),
(375, 1, 1, 1, '2021-11-10'),
(376, 1, 1, 1, '2021-11-11'),
(377, 1, 1, 1, '2021-11-12'),
(378, 1, 1, 1, '2021-11-15'),
(379, 1, 1, 1, '2021-11-16'),
(380, 1, 1, 1, '2021-11-17'),
(381, 1, 1, 1, '2021-11-18'),
(382, 1, 1, 1, '2021-11-19'),
(383, 1, 1, 1, '2021-11-22'),
(384, 1, 1, 1, '2021-11-23'),
(385, 1, 1, 1, '2021-11-24'),
(386, 1, 1, 1, '2021-11-25'),
(387, 1, 1, 1, '2021-11-26'),
(388, 1, 1, 1, '2021-11-29'),
(389, 1, 1, 1, '2021-11-30'),
(390, 1, 1, 1, '2021-12-01'),
(391, 1, 1, 1, '2021-12-02'),
(392, 1, 1, 1, '2021-12-03'),
(393, 1, 1, 1, '2021-12-06'),
(394, 1, 1, 1, '2021-12-07'),
(395, 1, 1, 1, '2021-12-08'),
(396, 1, 1, 1, '2021-12-09'),
(397, 1, 1, 1, '2021-12-10'),
(398, 1, 1, 1, '2021-12-13'),
(399, 1, 1, 1, '2021-12-14'),
(400, 1, 1, 1, '2021-12-15'),
(401, 1, 1, 1, '2021-12-16'),
(402, 1, 1, 1, '2021-12-17'),
(403, 1, 1, 1, '2021-12-20'),
(404, 1, 1, 1, '2021-12-21'),
(405, 1, 1, 1, '2021-12-22'),
(406, 1, 1, 1, '2021-12-23'),
(407, 1, 1, 1, '2021-12-24'),
(408, 1, 1, 1, '2021-12-27'),
(409, 1, 1, 1, '2021-12-28'),
(410, 1, 1, 1, '2021-12-29'),
(411, 1, 1, 1, '2021-12-30'),
(412, 1, 1, 1, '2021-12-31');

-- --------------------------------------------------------

--
-- Table structure for table `site_closure`
--

CREATE TABLE `site_closure` (
  `cod_closure` int(11) NOT NULL,
  `cod_site` int(11) DEFAULT NULL,
  `start` date NOT NULL DEFAULT '1970-01-01',
  `end` date NOT NULL DEFAULT '1970-01-01',
  `motivo` mediumtext NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `site_contractor`
--

CREATE TABLE `site_contractor` (
  `cod_company` int(11) NOT NULL,
  `nome` tinytext NOT NULL,
  `address` text NOT NULL,
  `tva` tinytext NOT NULL,
  `phone` tinytext NOT NULL,
  `email` tinytext NOT NULL,
  `logo` tinytext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `site_contractor`
--

INSERT INTO `site_contractor` (`cod_company`, `nome`, `address`, `tva`, `phone`, `email`, `logo`) VALUES
(1, 'Test Company', 'test address', '0', '0', 'm@m.pt', '');

-- --------------------------------------------------------

--
-- Table structure for table `site_daily_report`
--

CREATE TABLE `site_daily_report` (
  `cod_report` bigint(20) NOT NULL,
  `cod_site` int(11) DEFAULT NULL,
  `cod_section` int(11) DEFAULT NULL,
  `date` date NOT NULL DEFAULT '1970-01-01',
  `userId` mediumtext NOT NULL,
  `activities` mediumtext NOT NULL,
  `ocurrences` mediumtext NOT NULL,
  `file` text NOT NULL,
  `locked` int(11) NOT NULL DEFAULT '0',
  `type` tinyint(4) NOT NULL DEFAULT '0' COMMENT '0: draft, 1:merged, 2:final',
  `timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `site_delivery`
--

CREATE TABLE `site_delivery` (
  `cod_delivery` int(11) NOT NULL,
  `cod_site` int(11) DEFAULT NULL,
  `cod_section` int(11) DEFAULT NULL,
  `ref_doc` text NOT NULL,
  `doc_type` text NOT NULL,
  `material` mediumtext NOT NULL,
  `qtd` float DEFAULT NULL,
  `units` text NOT NULL,
  `notas` mediumtext NOT NULL,
  `date` date NOT NULL DEFAULT '1970-01-01',
  `log_time` time NOT NULL DEFAULT '00:00:00'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `site_delivery`
--

INSERT INTO `site_delivery` (`cod_delivery`, `cod_site`, `cod_section`, `ref_doc`, `doc_type`, `material`, `qtd`, `units`, `notas`, `date`, `log_time`) VALUES
(1, 1, 1, 'DOC REF NUM', '', 'Acier', 200, 'Kg', 'some notes', '2020-09-05', '00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `site_hardware`
--

CREATE TABLE `site_hardware` (
  `cod_hardware` int(11) NOT NULL,
  `cod_nfc` mediumtext NOT NULL,
  `cod_worker` int(11) DEFAULT NULL,
  `designation` mediumtext NOT NULL,
  `cod_site` int(11) DEFAULT NULL,
  `cod_section` int(11) DEFAULT NULL,
  `state` tinyint(4) NOT NULL DEFAULT '-1',
  `date` date DEFAULT NULL,
  `requested` tinyint(4) NOT NULL DEFAULT '0',
  `delivery_date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `site_history`
--

CREATE TABLE `site_history` (
  `cod_history` bigint(20) NOT NULL,
  `cod_site` int(11) DEFAULT NULL,
  `cod_section` int(11) DEFAULT NULL,
  `db_table` text NOT NULL,
  `cod_table` int(11) DEFAULT NULL,
  `type_event` text NOT NULL,
  `app` text NOT NULL,
  `username` longtext NOT NULL,
  `message` mediumtext NOT NULL,
  `date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `site_history`
--

INSERT INTO `site_history` (`cod_history`, `cod_site`, `cod_section`, `db_table`, `cod_table`, `type_event`, `app`, `username`, `message`, `date`) VALUES
(1, 1, 1, 'site_regie', 0, 'delay', 'Foreman', 'Alan Smith', 'late scheduling will cause a delay on planning. max delay expected: 1 days of work', '2020-09-22'),
(2, 1, 1, 'site_regie', 0, 'delay', 'Foreman', 'Alan Smith', 'late scheduling will cause a delay on planning. max delay expected: 1 days of work', '2020-09-22'),
(3, 1, 1, 'site_regie', 0, 'delay', 'Foreman', 'Alan Smith', 'late scheduling will cause a delay on planning. max delay expected: 1 days of work', '2020-09-22'),
(4, 1, 1, 'site_regie', 0, 'delay', 'Foreman', 'Alan Smith', 'late scheduling will cause a delay on planning. max delay expected: 1 days of work', '2020-09-22'),
(5, 1, 1, 'site_regie', 0, 'delay', 'Foreman', 'Alan Smith', 'late scheduling will cause a delay on planning. max delay expected: 1 days of work', '2020-09-23');

-- --------------------------------------------------------

--
-- Table structure for table `site_journal`
--

CREATE TABLE `site_journal` (
  `cod_journal` int(11) NOT NULL,
  `cod_site` int(11) DEFAULT NULL,
  `cod_section` tinyint(4) DEFAULT NULL,
  `date` date NOT NULL DEFAULT '1970-01-01',
  `time` time NOT NULL DEFAULT '00:00:00',
  `note` text NOT NULL,
  `cod_worker` int(11) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `site_manager`
--

CREATE TABLE `site_manager` (
  `cod_manager` int(11) NOT NULL,
  `name` text NOT NULL,
  `telef` text NOT NULL,
  `email` text NOT NULL,
  `cod_site` int(11) DEFAULT NULL,
  `cod_section` int(11) DEFAULT NULL,
  `job` tinytext NOT NULL,
  `cod_nfc` tinytext NOT NULL,
  `photo` tinytext NOT NULL,
  `auth_string` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `site_manager`
--

INSERT INTO `site_manager` (`cod_manager`, `name`, `telef`, `email`, `cod_site`, `cod_section`, `job`, `cod_nfc`, `photo`, `auth_string`) VALUES
(1, 'site manager', '0', 'm@m.pt', 1, 1, 'engineer', '1148090160012929', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `site_materials_diy`
--

CREATE TABLE `site_materials_diy` (
  `cod_diy` int(11) NOT NULL,
  `cod_site` int(11) DEFAULT NULL,
  `cod_section` int(11) DEFAULT NULL,
  `cod_nfc` longtext NOT NULL,
  `designation` mediumtext NOT NULL,
  `quantity` double DEFAULT NULL,
  `requested` tinyint(4) DEFAULT NULL,
  `requested_qty` double DEFAULT NULL,
  `delivery_date` date DEFAULT NULL,
  `date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `site_materials_reception`
--

CREATE TABLE `site_materials_reception` (
  `cod_materials_reception` int(11) NOT NULL,
  `cod_site` int(11) DEFAULT NULL,
  `cod_section` int(11) DEFAULT NULL,
  `data` date NOT NULL DEFAULT '1970-01-01',
  `start` time NOT NULL DEFAULT '00:00:00',
  `end` time NOT NULL DEFAULT '00:00:00',
  `qtd` double DEFAULT NULL,
  `units` tinytext NOT NULL,
  `material` tinytext NOT NULL,
  `notas` text NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `site_messages`
--

CREATE TABLE `site_messages` (
  `cod_message` int(11) NOT NULL,
  `cod_site` int(11) DEFAULT NULL,
  `cod_section` int(11) DEFAULT NULL,
  `readed` int(1) NOT NULL DEFAULT '0',
  `message` text NOT NULL,
  `sdate` date DEFAULT NULL,
  `edate` date DEFAULT NULL,
  `recurrence` tinyint(4) NOT NULL DEFAULT '0',
  `category_reference` text NOT NULL,
  `app_load_request_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `site_ocurrences`
--

CREATE TABLE `site_ocurrences` (
  `cod_ocurrence` int(11) NOT NULL,
  `cod_site` int(11) DEFAULT NULL,
  `cod_section` int(11) DEFAULT NULL,
  `description` text NOT NULL,
  `date` date NOT NULL DEFAULT '1970-01-01',
  `time` time NOT NULL DEFAULT '00:00:00'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `site_project`
--

CREATE TABLE `site_project` (
  `cod_project` int(11) NOT NULL,
  `cod_site` int(11) DEFAULT NULL,
  `cod_section` int(11) DEFAULT NULL,
  `date` date NOT NULL DEFAULT '1970-01-01',
  `time` time NOT NULL DEFAULT '00:00:00',
  `file` text NOT NULL,
  `description` mediumtext NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `site_project`
--

INSERT INTO `site_project` (`cod_project`, `cod_site`, `cod_section`, `date`, `time`, `file`, `description`) VALUES
(1, 1, 1, '2020-09-13', '00:00:00', 'drawing.pdf', 'Top view of the building floor plan');

-- --------------------------------------------------------

--
-- Table structure for table `site_qtd_jour`
--

CREATE TABLE `site_qtd_jour` (
  `cod_qtd` int(11) NOT NULL,
  `cod_site` int(11) DEFAULT NULL,
  `cod_section` int(11) DEFAULT NULL,
  `cod_task` int(11) DEFAULT NULL,
  `workers` text NOT NULL,
  `date` date NOT NULL DEFAULT '1970-01-01',
  `log_time` time NOT NULL DEFAULT '00:00:00',
  `qtd` text NOT NULL,
  `notas` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `site_qtd_jour`
--

INSERT INTO `site_qtd_jour` (`cod_qtd`, `cod_site`, `cod_section`, `cod_task`, `workers`, `date`, `log_time`, `qtd`, `notas`) VALUES
(1, 1, 1, 1, '1,2', '2020-09-03', '00:00:00', '20', 'some annotations about work'),
(2, 1, 1, 2, '3,4', '2020-09-04', '00:00:00', '30', 'some annotations about work');

-- --------------------------------------------------------

--
-- Table structure for table `site_regie`
--

CREATE TABLE `site_regie` (
  `cod_regie` int(11) NOT NULL,
  `cod_site` int(11) DEFAULT NULL,
  `cod_section` int(11) DEFAULT NULL,
  `date` date NOT NULL DEFAULT '1970-01-01',
  `start` time NOT NULL DEFAULT '00:00:00',
  `end` time NOT NULL DEFAULT '00:00:00',
  `workers` tinytext NOT NULL,
  `notas` text NOT NULL,
  `start_auth_string_manager` text NOT NULL,
  `end_auth_string_manager` text NOT NULL,
  `final_duration` time NOT NULL DEFAULT '00:00:00',
  `reason` text NOT NULL,
  `record_type` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `site_regie`
--

INSERT INTO `site_regie` (`cod_regie`, `cod_site`, `cod_section`, `date`, `start`, `end`, `workers`, `notas`, `start_auth_string_manager`, `end_auth_string_manager`, `final_duration`, `reason`, `record_type`) VALUES
(1, 1, 1, '2020-09-11', '10:28:07', '20:28:08', '1,2,3', 'Casting the first floor slab', '', '', '00:00:00', '', ''),
(2, 1, 1, '2020-09-10', '08:30:49', '17:30:49', '1,3,4', 'installing formworks for slab', '', '', '00:00:00', '', ''),
(3, 1, 1, '2020-09-08', '07:30:49', '14:30:49', '1,2,4', 'placement of steel reinforcement ', '', '', '00:00:00', '', ''),
(4, 1, 1, '2020-09-22', '14:46:25', '15:11:19', '2', 'Works_______________________________________\rWorks', '', '', '00:00:00', '', '-ForemanStart- -ForemanEnd-'),
(5, 1, 1, '2020-09-22', '14:49:07', '15:14:15', '2', '_______________________________________\rWorks complete', '', '', '00:00:00', '', '-ForemanStart- -ForemanEnd-'),
(6, 1, 1, '2020-09-22', '14:55:08', '00:00:00', '2', '', '', '', '00:00:00', '', '-ForemanStart- '),
(7, 1, 1, '2020-09-22', '16:20:40', '16:21:54', '2', '_______________________________________\r', '', '', '00:00:00', '', '-ForemanStart- -ForemanEnd-'),
(8, 1, 1, '2020-09-23', '14:42:59', '14:47:58', '2', '_______________________________________\r', '', '', '00:00:00', '', '-ForemanStart- -ForemanEnd-');

-- --------------------------------------------------------

--
-- Table structure for table `site_section`
--

CREATE TABLE `site_section` (
  `cod_section` int(11) NOT NULL,
  `cod_site` int(11) DEFAULT NULL,
  `description` mediumtext NOT NULL,
  `attendances_last_close` date DEFAULT NULL,
  `latitude` tinytext NOT NULL,
  `longitude` tinytext NOT NULL,
  `distance` float NOT NULL DEFAULT '0',
  `authentication_radius` float NOT NULL DEFAULT '1000'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `site_section`
--

INSERT INTO `site_section` (`cod_section`, `cod_site`, `description`, `attendances_last_close`, `latitude`, `longitude`, `distance`, `authentication_radius`) VALUES
(1, 1, 'site section', NULL, '0', '0', 0, 1000);

-- --------------------------------------------------------

--
-- Table structure for table `site_weather`
--

CREATE TABLE `site_weather` (
  `cod_site` int(11) DEFAULT NULL,
  `cod_section` int(11) DEFAULT NULL,
  `time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `weather` mediumtext NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `tablets`
--

CREATE TABLE `tablets` (
  `cod_tablet` tinyint(4) NOT NULL,
  `cod_worker` int(11) DEFAULT NULL,
  `tablet_id` text NOT NULL,
  `pin` int(11) DEFAULT NULL,
  `puk` text NOT NULL,
  `mobile` text NOT NULL,
  `name` text NOT NULL,
  `sw_version` text NOT NULL,
  `serial` text NOT NULL,
  `active` tinyint(1) DEFAULT NULL,
  `cod_site` int(11) DEFAULT NULL,
  `cod_section` int(11) DEFAULT NULL,
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `email` tinytext NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `tablets`
--

INSERT INTO `tablets` (`cod_tablet`, `cod_worker`, `tablet_id`, `pin`, `puk`, `mobile`, `name`, `sw_version`, `serial`, `active`, `cod_site`, `cod_section`, `date`, `email`) VALUES
(1, 1, '0', 0, '0', '0', 'tablet', '0', '0', 1, 1, 1, '2020-05-05 11:22:00', '');

-- --------------------------------------------------------

--
-- Table structure for table `teams`
--

CREATE TABLE `teams` (
  `cod_team` int(11) NOT NULL,
  `cod_site` bigint(20) DEFAULT NULL,
  `cod_section` int(11) DEFAULT NULL,
  `cod_worker` bigint(20) DEFAULT NULL,
  `date` date NOT NULL DEFAULT '1970-01-01',
  `cod_category` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `teams`
--

INSERT INTO `teams` (`cod_team`, `cod_site`, `cod_section`, `cod_worker`, `date`, `cod_category`) VALUES
(1, 1, 1, 1, '1970-01-01', 1),
(2, 1, 1, 1, '2020-06-01', 1),
(3, 1, 1, 1, '2020-09-01', 1),
(4, 1, 1, 3, '2020-09-01', 1),
(5, 1, 1, 2, '2020-09-01', 1),
(6, 1, 1, 4, '2020-09-01', 1),
(7, 1, 1, 1, '2020-11-01', 1),
(8, 1, 1, 1, '2020-12-01', 1),
(9, 1, 1, 1, '2021-01-01', 1),
(10, 1, 1, 1, '2021-02-01', 1),
(11, 1, 1, 1, '2021-03-01', 1),
(12, 1, 1, 1, '2021-04-01', 1),
(13, 1, 1, 1, '2021-05-01', 1),
(14, 1, 1, 1, '2021-06-01', 1),
(15, 1, 1, 1, '2021-07-01', 1),
(16, 1, 1, 1, '2021-08-01', 1),
(17, 1, 1, 1, '2021-09-01', 1),
(18, 1, 1, 1, '2021-10-01', 1),
(19, 1, 1, 1, '2021-11-01', 1),
(20, 1, 1, 1, '2021-12-01', 1);

-- --------------------------------------------------------

--
-- Table structure for table `transport_vehicle`
--

CREATE TABLE `transport_vehicle` (
  `cod_vehicle` int(11) NOT NULL,
  `designation` mediumtext NOT NULL,
  `initials` tinytext NOT NULL,
  `active` tinyint(4) DEFAULT NULL,
  `rental` tinyint(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `transport_vehicle`
--

INSERT INTO `transport_vehicle` (`cod_vehicle`, `designation`, `initials`, `active`, `rental`) VALUES
(1, 'car', 'car', 1, 0);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `cod_user` int(11) NOT NULL,
  `cod_type` int(11) DEFAULT NULL,
  `name` text NOT NULL,
  `cod_nfc` text NOT NULL,
  `card_auth_key` tinytext NOT NULL,
  `connection_types` mediumtext NOT NULL COMMENT 'possible values: office, site, contractor',
  `email` mediumtext NOT NULL,
  `photo` tinytext NOT NULL,
  `contact` tinytext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`cod_user`, `cod_type`, `name`, `cod_nfc`, `card_auth_key`, `connection_types`, `email`, `photo`, `contact`) VALUES
(1, NULL, 'demo', '123456789', '0000111aaaaa', 'office', 'dummy@dummy.be', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `users_type`
--

CREATE TABLE `users_type` (
  `cod_type` int(11) NOT NULL,
  `name` text NOT NULL,
  `enabled` tinyint(1) DEFAULT NULL,
  `reference` tinytext NOT NULL COMMENT 'static reference of user type'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `worker`
--

CREATE TABLE `worker` (
  `cod_worker` bigint(20) NOT NULL,
  `cod_category` bigint(20) NOT NULL,
  `cod_entreprise` bigint(20) NOT NULL,
  `cod_nfc` text NOT NULL,
  `card_auth_key` tinytext NOT NULL,
  `name` text NOT NULL,
  `contact` text NOT NULL,
  `contact112` text NOT NULL,
  `photo` text NOT NULL,
  `data_nascimento` date DEFAULT '1970-01-01',
  `idade` int(11) DEFAULT NULL,
  `estado_civil` tinytext NOT NULL,
  `nacionalidade` tinytext NOT NULL,
  `cc` text NOT NULL,
  `cc_validade` date DEFAULT '1970-01-01',
  `nif` double DEFAULT NULL,
  `niss` double DEFAULT NULL,
  `filhos` int(11) DEFAULT NULL,
  `filhos_encargo` int(11) DEFAULT NULL,
  `email` tinytext NOT NULL,
  `data_inicio_trabalho` date DEFAULT '1970-01-01',
  `morada` text NOT NULL,
  `prob_saude` text NOT NULL,
  `nib` tinytext NOT NULL,
  `peso` int(11) DEFAULT NULL,
  `altura` int(11) DEFAULT NULL,
  `calcas` tinytext NOT NULL,
  `pe` tinytext NOT NULL,
  `casaco` tinytext NOT NULL,
  `contrato_inicio` date DEFAULT '1970-01-01',
  `contrato_fim` date DEFAULT '1970-01-01',
  `contrato_file` tinytext NOT NULL,
  `destacamento_inicio` date DEFAULT '1970-01-01',
  `destacamento_fim` date DEFAULT '1970-01-01',
  `destacamento_file` tinytext NOT NULL,
  `act_inicio` date NOT NULL DEFAULT '1970-01-01',
  `act_fim` date DEFAULT '1970-01-01',
  `act_file` tinytext NOT NULL,
  `a1_inicio` date DEFAULT '1970-01-01',
  `a1_fim` date DEFAULT '1970-01-01',
  `a1_file` tinytext NOT NULL,
  `mutuelle_inicio` date DEFAULT '1970-01-01',
  `mutuelle_file` tinytext NOT NULL,
  `medico_inicio` date DEFAULT '1970-01-01',
  `medico_file` tinytext NOT NULL,
  `gruista_file` tinytext NOT NULL,
  `cc_file` text NOT NULL,
  `csaude_file` text NOT NULL,
  `refeicao` float DEFAULT NULL,
  `ajudascusto` float DEFAULT NULL,
  `salario` float DEFAULT NULL,
  `classificacao` tinytext NOT NULL,
  `localizacao` tinytext NOT NULL,
  `naturalidade` text NOT NULL,
  `concelho` text NOT NULL,
  `activo` tinyint(1) DEFAULT NULL,
  `activo_date` date DEFAULT '1970-01-01',
  `csaude_validade` date DEFAULT '1970-01-01',
  `cod_meal_place` tinyint(4) NOT NULL,
  `cod_lodging` smallint(6) NOT NULL DEFAULT '1',
  `notes` text NOT NULL,
  `room` tinytext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `worker`
--

INSERT INTO `worker` (`cod_worker`, `cod_category`, `cod_entreprise`, `cod_nfc`, `card_auth_key`, `name`, `contact`, `contact112`, `photo`, `data_nascimento`, `idade`, `estado_civil`, `nacionalidade`, `cc`, `cc_validade`, `nif`, `niss`, `filhos`, `filhos_encargo`, `email`, `data_inicio_trabalho`, `morada`, `prob_saude`, `nib`, `peso`, `altura`, `calcas`, `pe`, `casaco`, `contrato_inicio`, `contrato_fim`, `contrato_file`, `destacamento_inicio`, `destacamento_fim`, `destacamento_file`, `act_inicio`, `act_fim`, `act_file`, `a1_inicio`, `a1_fim`, `a1_file`, `mutuelle_inicio`, `mutuelle_file`, `medico_inicio`, `medico_file`, `gruista_file`, `cc_file`, `csaude_file`, `refeicao`, `ajudascusto`, `salario`, `classificacao`, `localizacao`, `naturalidade`, `concelho`, `activo`, `activo_date`, `csaude_validade`, `cod_meal_place`, `cod_lodging`, `notes`, `room`) VALUES
(1, 1, 1, '123456785', '0000001aaaaa', 'Alan Smith', '123456789', '123456789', 'worker1.jpg', '1970-01-01', 40, '0', '', '', '1970-01-01', NULL, NULL, NULL, NULL, '', '1970-01-01', '', '', '', NULL, NULL, '', '', '', '1970-01-01', '1970-01-01', '', '1970-01-01', '1970-01-01', '', '1970-01-01', '1970-01-01', '', '1970-01-01', '1970-01-01', '', '1970-01-01', '', '1970-01-01', '', '', '', '', NULL, NULL, NULL, '', '', '', '', 1, '1970-01-01', '1970-01-01', 1, 1, '', ''),
(2, 1, 1, '1148090160012929', '7440002syQF0', 'James Hornet', '123456789', '123456789', 'worker2.jpg', '1970-01-01', 50, '0', 'English', '123456789', '1970-01-01', 123456789, 123456789, 0, 0, 'mail@mail.com', '1970-01-01', 'address', '0', '123456789', 0, 0, '0', '0', '0', '1970-01-01', '1970-01-01', '', '1970-01-01', '1970-01-01', '', '1970-01-01', '1970-01-01', '', '1970-01-01', '1970-01-01', '', '1970-01-01', '', '1970-01-01', '', '', '', '', 1, 1, 620, 'Encarregado de segunda', 'Continente', 'London', 'London', 1, '1970-01-01', '1970-01-01', 1, 1, '', 's/reg.'),
(3, 1, 1, '123456787', '0000001aaaaa', 'Anthony Brown', '123456789', '123456789', 'worker3.jpg', '1970-01-01', 40, '0', '', '', '1970-01-01', NULL, NULL, NULL, NULL, '', '1970-01-01', '', '', '', NULL, NULL, '', '', '', '1970-01-01', '1970-01-01', '', '1970-01-01', '1970-01-01', '', '1970-01-01', '1970-01-01', '', '1970-01-01', '1970-01-01', '', '1970-01-01', '', '1970-01-01', '', '', '', '', NULL, NULL, NULL, '', '', '', '', 1, '1970-01-01', '1970-01-01', 1, 1, '', ''),
(4, 1, 1, '123456786', '0000001aaaaa', 'Michael Davies', '123456789', '123456789', 'worker4.jpg', '1970-01-01', 40, '0', '', '', '1970-01-01', NULL, NULL, NULL, NULL, '', '1970-01-01', '', '', '', NULL, NULL, '', '', '', '1970-01-01', '1970-01-01', '', '1970-01-01', '1970-01-01', '', '1970-01-01', '1970-01-01', '', '1970-01-01', '1970-01-01', '', '1970-01-01', '', '1970-01-01', '', '', '', '', NULL, NULL, NULL, '', '', '', '', 1, '1970-01-01', '1970-01-01', 1, 1, '', '');

-- --------------------------------------------------------

--
-- Table structure for table `worker_ausencia`
--

CREATE TABLE `worker_ausencia` (
  `cod_ausencia` int(11) NOT NULL,
  `cod_worker` int(11) DEFAULT NULL,
  `inicio` date NOT NULL DEFAULT '1970-01-01',
  `fim` date NOT NULL DEFAULT '1970-01-01',
  `tipo` mediumtext NOT NULL,
  `viagem` mediumtext NOT NULL,
  `motivo` mediumtext NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `worker_categories`
--

CREATE TABLE `worker_categories` (
  `cod_category` int(11) NOT NULL,
  `reference` tinytext NOT NULL,
  `designation` text NOT NULL,
  `translations` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `worker_categories`
--

INSERT INTO `worker_categories` (`cod_category`, `reference`, `designation`, `translations`) VALUES
(1, 'frm', 'Foreman', ''),
(2, 'stl', 'Steel works', ''),
(3, 'cpr', 'Wood works', ''),
(4, 'mcn', 'Macon', '');

-- --------------------------------------------------------

--
-- Table structure for table `worker_clothes`
--

CREATE TABLE `worker_clothes` (
  `cod_clothes` int(11) NOT NULL,
  `cod_worker` int(11) DEFAULT NULL,
  `data` date NOT NULL DEFAULT '1970-01-01',
  `clothes` tinytext NOT NULL,
  `note` text NOT NULL,
  `request_date` date DEFAULT NULL,
  `delivered` int(11) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `worker_limosa`
--

CREATE TABLE `worker_limosa` (
  `cod_limosa` int(11) NOT NULL,
  `cod_worker` int(11) DEFAULT NULL,
  `cod_site` int(11) DEFAULT NULL,
  `inicio` date NOT NULL DEFAULT '1970-01-01',
  `fim` date NOT NULL DEFAULT '1970-01-01',
  `file` tinytext NOT NULL,
  `qrcode` tinytext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `worker_lodging`
--

CREATE TABLE `worker_lodging` (
  `cod_lodging` int(11) NOT NULL,
  `name` tinytext NOT NULL,
  `enabled` tinyint(1) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `worker_lodging`
--

INSERT INTO `worker_lodging` (`cod_lodging`, `name`, `enabled`) VALUES
(1, 'hostel', 1);

-- --------------------------------------------------------

--
-- Table structure for table `worker_meal_place`
--

CREATE TABLE `worker_meal_place` (
  `cod_meal_place` int(11) NOT NULL,
  `name` tinytext NOT NULL,
  `enabled` tinyint(1) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `worker_meal_place`
--

INSERT INTO `worker_meal_place` (`cod_meal_place`, `name`, `enabled`) VALUES
(1, 'restaurant', 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bordereau`
--
ALTER TABLE `bordereau`
  ADD PRIMARY KEY (`cod_task`);

--
-- Indexes for table `bordereau_task_plan`
--
ALTER TABLE `bordereau_task_plan`
  ADD PRIMARY KEY (`cod_task_plan`);

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`cod_category`);

--
-- Indexes for table `crash_report`
--
ALTER TABLE `crash_report`
  ADD PRIMARY KEY (`cod_report`),
  ADD KEY `cod_report` (`cod_report`);

--
-- Indexes for table `daily_meal`
--
ALTER TABLE `daily_meal`
  ADD PRIMARY KEY (`cod_meal`);

--
-- Indexes for table `devices_pc`
--
ALTER TABLE `devices_pc`
  ADD PRIMARY KEY (`cod_pc`);

--
-- Indexes for table `entreprise`
--
ALTER TABLE `entreprise`
  ADD PRIMARY KEY (`cod_entreprise`);

--
-- Indexes for table `photos`
--
ALTER TABLE `photos`
  ADD PRIMARY KEY (`cod_photo`);

--
-- Indexes for table `record`
--
ALTER TABLE `record`
  ADD PRIMARY KEY (`cod_record`);

--
-- Indexes for table `requests`
--
ALTER TABLE `requests`
  ADD PRIMARY KEY (`cod_request`);

--
-- Indexes for table `settings`
--
ALTER TABLE `settings`
  ADD PRIMARY KEY (`cod_setting`);

--
-- Indexes for table `settings_apps_menu`
--
ALTER TABLE `settings_apps_menu`
  ADD PRIMARY KEY (`cod_menu`);

--
-- Indexes for table `site`
--
ALTER TABLE `site`
  ADD PRIMARY KEY (`cod_site`);

--
-- Indexes for table `site_chef_equipe`
--
ALTER TABLE `site_chef_equipe`
  ADD PRIMARY KEY (`cod_chef_equipe`);

--
-- Indexes for table `site_closure`
--
ALTER TABLE `site_closure`
  ADD KEY `cod_closure` (`cod_closure`);

--
-- Indexes for table `site_contractor`
--
ALTER TABLE `site_contractor`
  ADD PRIMARY KEY (`cod_company`);

--
-- Indexes for table `site_daily_report`
--
ALTER TABLE `site_daily_report`
  ADD PRIMARY KEY (`cod_report`);

--
-- Indexes for table `site_delivery`
--
ALTER TABLE `site_delivery`
  ADD PRIMARY KEY (`cod_delivery`);

--
-- Indexes for table `site_hardware`
--
ALTER TABLE `site_hardware`
  ADD PRIMARY KEY (`cod_hardware`);

--
-- Indexes for table `site_history`
--
ALTER TABLE `site_history`
  ADD PRIMARY KEY (`cod_history`);

--
-- Indexes for table `site_journal`
--
ALTER TABLE `site_journal`
  ADD PRIMARY KEY (`cod_journal`);

--
-- Indexes for table `site_manager`
--
ALTER TABLE `site_manager`
  ADD PRIMARY KEY (`cod_manager`);

--
-- Indexes for table `site_materials_diy`
--
ALTER TABLE `site_materials_diy`
  ADD PRIMARY KEY (`cod_diy`);

--
-- Indexes for table `site_materials_reception`
--
ALTER TABLE `site_materials_reception`
  ADD PRIMARY KEY (`cod_materials_reception`),
  ADD UNIQUE KEY `cod_materials_reception` (`cod_materials_reception`);

--
-- Indexes for table `site_messages`
--
ALTER TABLE `site_messages`
  ADD PRIMARY KEY (`cod_message`);

--
-- Indexes for table `site_ocurrences`
--
ALTER TABLE `site_ocurrences`
  ADD PRIMARY KEY (`cod_ocurrence`),
  ADD UNIQUE KEY `cod_ocurrence` (`cod_ocurrence`);

--
-- Indexes for table `site_project`
--
ALTER TABLE `site_project`
  ADD PRIMARY KEY (`cod_project`);

--
-- Indexes for table `site_qtd_jour`
--
ALTER TABLE `site_qtd_jour`
  ADD PRIMARY KEY (`cod_qtd`);

--
-- Indexes for table `site_regie`
--
ALTER TABLE `site_regie`
  ADD PRIMARY KEY (`cod_regie`);

--
-- Indexes for table `site_section`
--
ALTER TABLE `site_section`
  ADD PRIMARY KEY (`cod_section`);

--
-- Indexes for table `tablets`
--
ALTER TABLE `tablets`
  ADD PRIMARY KEY (`cod_tablet`);

--
-- Indexes for table `teams`
--
ALTER TABLE `teams`
  ADD PRIMARY KEY (`cod_team`);

--
-- Indexes for table `transport_vehicle`
--
ALTER TABLE `transport_vehicle`
  ADD PRIMARY KEY (`cod_vehicle`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`cod_user`);

--
-- Indexes for table `users_type`
--
ALTER TABLE `users_type`
  ADD PRIMARY KEY (`cod_type`);

--
-- Indexes for table `worker`
--
ALTER TABLE `worker`
  ADD PRIMARY KEY (`cod_worker`);

--
-- Indexes for table `worker_ausencia`
--
ALTER TABLE `worker_ausencia`
  ADD PRIMARY KEY (`cod_ausencia`);

--
-- Indexes for table `worker_categories`
--
ALTER TABLE `worker_categories`
  ADD PRIMARY KEY (`cod_category`);

--
-- Indexes for table `worker_clothes`
--
ALTER TABLE `worker_clothes`
  ADD PRIMARY KEY (`cod_clothes`);

--
-- Indexes for table `worker_limosa`
--
ALTER TABLE `worker_limosa`
  ADD PRIMARY KEY (`cod_limosa`);

--
-- Indexes for table `worker_lodging`
--
ALTER TABLE `worker_lodging`
  ADD PRIMARY KEY (`cod_lodging`);

--
-- Indexes for table `worker_meal_place`
--
ALTER TABLE `worker_meal_place`
  ADD PRIMARY KEY (`cod_meal_place`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bordereau`
--
ALTER TABLE `bordereau`
  MODIFY `cod_task` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT for table `bordereau_task_plan`
--
ALTER TABLE `bordereau_task_plan`
  MODIFY `cod_task_plan` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `cod_category` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `crash_report`
--
ALTER TABLE `crash_report`
  MODIFY `cod_report` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=185;

--
-- AUTO_INCREMENT for table `daily_meal`
--
ALTER TABLE `daily_meal`
  MODIFY `cod_meal` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `devices_pc`
--
ALTER TABLE `devices_pc`
  MODIFY `cod_pc` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `entreprise`
--
ALTER TABLE `entreprise`
  MODIFY `cod_entreprise` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `photos`
--
ALTER TABLE `photos`
  MODIFY `cod_photo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `record`
--
ALTER TABLE `record`
  MODIFY `cod_record` bigint(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=394;

--
-- AUTO_INCREMENT for table `requests`
--
ALTER TABLE `requests`
  MODIFY `cod_request` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `settings`
--
ALTER TABLE `settings`
  MODIFY `cod_setting` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `settings_apps_menu`
--
ALTER TABLE `settings_apps_menu`
  MODIFY `cod_menu` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `site`
--
ALTER TABLE `site`
  MODIFY `cod_site` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `site_chef_equipe`
--
ALTER TABLE `site_chef_equipe`
  MODIFY `cod_chef_equipe` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=413;

--
-- AUTO_INCREMENT for table `site_closure`
--
ALTER TABLE `site_closure`
  MODIFY `cod_closure` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `site_contractor`
--
ALTER TABLE `site_contractor`
  MODIFY `cod_company` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `site_daily_report`
--
ALTER TABLE `site_daily_report`
  MODIFY `cod_report` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `site_delivery`
--
ALTER TABLE `site_delivery`
  MODIFY `cod_delivery` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `site_hardware`
--
ALTER TABLE `site_hardware`
  MODIFY `cod_hardware` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `site_history`
--
ALTER TABLE `site_history`
  MODIFY `cod_history` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `site_journal`
--
ALTER TABLE `site_journal`
  MODIFY `cod_journal` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `site_manager`
--
ALTER TABLE `site_manager`
  MODIFY `cod_manager` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `site_materials_diy`
--
ALTER TABLE `site_materials_diy`
  MODIFY `cod_diy` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `site_materials_reception`
--
ALTER TABLE `site_materials_reception`
  MODIFY `cod_materials_reception` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `site_messages`
--
ALTER TABLE `site_messages`
  MODIFY `cod_message` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `site_ocurrences`
--
ALTER TABLE `site_ocurrences`
  MODIFY `cod_ocurrence` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `site_project`
--
ALTER TABLE `site_project`
  MODIFY `cod_project` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `site_qtd_jour`
--
ALTER TABLE `site_qtd_jour`
  MODIFY `cod_qtd` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `site_regie`
--
ALTER TABLE `site_regie`
  MODIFY `cod_regie` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `site_section`
--
ALTER TABLE `site_section`
  MODIFY `cod_section` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `tablets`
--
ALTER TABLE `tablets`
  MODIFY `cod_tablet` tinyint(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `teams`
--
ALTER TABLE `teams`
  MODIFY `cod_team` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `transport_vehicle`
--
ALTER TABLE `transport_vehicle`
  MODIFY `cod_vehicle` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `cod_user` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `users_type`
--
ALTER TABLE `users_type`
  MODIFY `cod_type` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `worker`
--
ALTER TABLE `worker`
  MODIFY `cod_worker` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `worker_ausencia`
--
ALTER TABLE `worker_ausencia`
  MODIFY `cod_ausencia` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `worker_categories`
--
ALTER TABLE `worker_categories`
  MODIFY `cod_category` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `worker_clothes`
--
ALTER TABLE `worker_clothes`
  MODIFY `cod_clothes` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `worker_limosa`
--
ALTER TABLE `worker_limosa`
  MODIFY `cod_limosa` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `worker_lodging`
--
ALTER TABLE `worker_lodging`
  MODIFY `cod_lodging` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `worker_meal_place`
--
ALTER TABLE `worker_meal_place`
  MODIFY `cod_meal_place` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
