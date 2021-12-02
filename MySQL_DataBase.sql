-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Jun 18, 2020 at 07:42 AM
-- Server version: 5.6.47-cll-lve
-- PHP Version: 7.2.7

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
(122, '', 'The form referred to itself during construction from a default instance, which led to infinite recursion.  Within the Forms constructor refer to the form using Me.\r\n--------- Stack trace ---------\r\n----------4/28/2020 6:10:28 PM----------\r\n----------OS version:1.0.0.14----------\r\n    Error Line:am)\r\n\r\n-------------------------------\r\n--------- Cause ---------\r\n1- ConstructionSiteLogistics.My.MyProject+MyForms Create__Instance__\r\n2- ConstructionSiteLogistics.team_frm tableSettingsBtn_Click\r\n3- System.Windows.Forms.Control OnClick\r\n4- System.Windows.Forms.Control WmMouseUp\r\n5- System.Windows.Forms.Control WndProc\r\n6- System.Windows.Forms.Control+ControlNativeWindow OnMessage\r\n7- System.Windows.Forms.Control+ControlNativeWindow WndProc\r\n8- System.Windows.Forms.NativeWindow Callback\r\n', '2020-04-28', '18:12:20');

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
(1, 1, 1, 1, 1, '00:00:00', '00:00:00', '2020-05-05', '', '00:00:00', '', '00:00:00', '', '', '', '', '', '2020-05-05 11:16:18');

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
(1, 'site manager', '0', 'm@m.pt', 1, 1, 'engineer', '123456789', '', '0000001aaaaa');

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
(1, 1, 1, 1, '1970-01-01', 1);

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
(1, 1, 1, '123456789', '0000001aaaaa', 'Test Worker', '123456789', '123456789', '', '1970-01-01', 40, '0', '', '', '1970-01-01', NULL, NULL, NULL, NULL, '', '1970-01-01', '', '', '', NULL, NULL, '', '', '', '1970-01-01', '1970-01-01', '', '1970-01-01', '1970-01-01', '', '1970-01-01', '1970-01-01', '', '1970-01-01', '1970-01-01', '', '1970-01-01', '', '1970-01-01', '', '', '', '', NULL, NULL, NULL, '', '', '', '', 1, '1970-01-01', '1970-01-01', 1, 1, '', '');

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
(1, 'frm', 'Foreman', '');

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
  MODIFY `cod_task` int(11) NOT NULL AUTO_INCREMENT;

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
  MODIFY `cod_report` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=123;

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
  MODIFY `cod_photo` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `record`
--
ALTER TABLE `record`
  MODIFY `cod_record` bigint(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

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
  MODIFY `cod_chef_equipe` int(11) NOT NULL AUTO_INCREMENT;

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
  MODIFY `cod_delivery` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `site_hardware`
--
ALTER TABLE `site_hardware`
  MODIFY `cod_hardware` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `site_history`
--
ALTER TABLE `site_history`
  MODIFY `cod_history` bigint(20) NOT NULL AUTO_INCREMENT;

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
  MODIFY `cod_project` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `site_qtd_jour`
--
ALTER TABLE `site_qtd_jour`
  MODIFY `cod_qtd` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `site_regie`
--
ALTER TABLE `site_regie`
  MODIFY `cod_regie` int(11) NOT NULL AUTO_INCREMENT;

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
  MODIFY `cod_team` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

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
  MODIFY `cod_worker` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `worker_ausencia`
--
ALTER TABLE `worker_ausencia`
  MODIFY `cod_ausencia` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `worker_categories`
--
ALTER TABLE `worker_categories`
  MODIFY `cod_category` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

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
