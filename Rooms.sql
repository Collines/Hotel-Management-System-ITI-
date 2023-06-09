using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections.Generic;

----------------------------------------------------------
--Host:                         DESKTOP - VREBPAN\MSSQLSERVER17
-- Server version:               Microsoft SQL Server 2022 (RTM-GDR) (KB5021522) - 16.0.1050.5
-- Server OS:                    Windows 10 Pro 10.0 <X64> (Build 22621: )
--HeidiSQL Version: 12.1.0.6537
----------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES  */
;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */
;
/*!40103 SET TIME_ZONE='+00:00' */
;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */
;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */
;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */
;

--Dumping data for table FRONTEND.Rooms: -1 rows
/*!40000 ALTER TABLE "Rooms" DISABLE KEYS */;
INSERT INTO "Rooms" ("RoomNumber", "RoomFloor", "RoomType", "IsReserved") VALUES
    ('A111', 1, 0, b'0'),
	('A112', 1, 0, b'1'),
	('A113', 1, 0, b'1'),
	('A114', 1, 0, b'0'),
	('A211', 2, 0, b'0'),
	('A212', 2, 0, b'0'),
	('A213', 2, 0, b'0'),
	('A214', 2, 0, b'0'),
	('A311', 3, 0, b'0'),
	('A312', 3, 0, b'0'),
	('A313', 3, 0, b'0'),
	('A314', 3, 0, b'0'),
	('A411', 4, 0, b'0'),
	('A412', 4, 0, b'0'),
	('A413', 4, 0, b'0'),
	('A414', 4, 0, b'0'),
	('A511', 5, 0, b'0'),
	('A512', 5, 0, b'0'),
	('A513', 5, 0, b'0'),
	('A514', 5, 0, b'0'),
	('A611', 8, 0, b'0'),
	('A612', 6, 0, b'0'),
	('A613', 6, 0, b'0'),
	('A614', 6, 0, b'0'),
	('A711', 7, 0, b'0'),
	('A712', 7, 0, b'0'),
	('A713', 7, 0, b'0'),
	('A714', 7, 0, b'0'),
	('A811', 8, 0, b'0'),
	('A812', 8, 0, b'0'),
	('A813', 8, 0, b'0'),
	('A814', 8, 0, b'0'),
	('A911', 9, 0, b'0'),
	('A912', 9, 0, b'0'),
	('A913', 9, 0, b'0'),
	('A914', 9, 0, b'0'),
	('A1011', 10, 0, b'0'),
	('A1012', 10, 0, b'0'),
	('A1013', 10, 0, b'0'),
	('A1014', 10, 0, b'0'),
	('A1111', 11, 0, b'0'),
	('A1112', 11, 0, b'0'),
	('A1113', 11, 0, b'0'),
	('A1114', 11, 0, b'0'),
	('A1211', 12, 0, b'0'),
	('A1212', 12, 0, b'0'),
	('A1213', 12, 0, b'0'),
	('A1214', 12, 0, b'0'),
	('A1311', 13, 0, b'0'),
	('A1312', 13, 0, b'0'),
	('A1313', 13, 0, b'0'),
	('A1314', 13, 0, b'0'),
	('A1411', 14, 0, b'0'),
	('A1412', 14, 0, b'0'),
	('A1413', 14, 0, b'0'),
	('A1414', 14, 0, b'0'),
	('A1511', 15, 0, b'0'),
	('A1512', 15, 0, b'0'),
	('A1513', 15, 0, b'0'),
	('A1514', 15, 0, b'0'),
	('B121', 1, 1, b'0'),
	('B122', 1, 1, b'0'),
	('B123', 1, 1, b'1'),
	('B124', 1, 1, b'0'),
	('B221', 10, 3, b'0'),
	('B222', 2, 1, b'0'),
	('B223', 2, 1, b'0'),
	('B224', 2, 1, b'0'),
	('B321', 3, 1, b'0'),
	('B322', 3, 1, b'0'),
	('B323', 3, 1, b'0'),
	('B324', 3, 1, b'0'),
	('B421', 4, 1, b'0'),
	('B422', 4, 1, b'0'),
	('B423', 4, 1, b'0'),
	('B424', 4, 1, b'0'),
	('B521', 5, 1, b'0'),
	('B522', 5, 1, b'0'),
	('B523', 5, 1, b'0'),
	('B524', 5, 1, b'0'),
	('B621', 6, 1, b'0'),
	('B622', 6, 1, b'0'),
	('B623', 6, 1, b'0'),
	('B624', 6, 1, b'0'),
	('B721', 7, 1, b'0'),
	('B722', 7, 1, b'0'),
	('B723', 7, 1, b'0'),
	('B724', 7, 1, b'0'),
	('B821', 8, 1, b'0'),
	('B822', 8, 1, b'0'),
	('B823', 8, 1, b'0'),
	('B824', 8, 1, b'0'),
	('B921', 9, 1, b'0'),
	('B922', 9, 1, b'0'),
	('B923', 9, 1, b'0'),
	('B924', 9, 1, b'0'),
	('B1021', 10, 1, b'0'),
	('B1022', 10, 1, b'0'),
	('B1023', 10, 1, b'0'),
	('B1024', 10, 1, b'0'),
	('B1121', 11, 1, b'0'),
	('B1122', 11, 1, b'0'),
	('B1123', 11, 1, b'0'),
	('B1124', 11, 1, b'0'),
	('B1221', 12, 1, b'0'),
	('B1222', 12, 1, b'0'),
	('B1223', 12, 1, b'0'),
	('B1224', 12, 1, b'0'),
	('B1321', 13, 1, b'0'),
	('B1322', 13, 1, b'0'),
	('B1323', 13, 1, b'0'),
	('B1324', 13, 1, b'0'),
	('B1421', 14, 1, b'0'),
	('B1422', 14, 1, b'0'),
	('B1423', 14, 1, b'0'),
	('B1424', 14, 1, b'0'),
	('B1521', 15, 1, b'0'),
	('B1522', 15, 1, b'0'),
	('B1523', 15, 1, b'0'),
	('B1524', 15, 1, b'0'),
	('C131', 1, 2, b'0'),
	('C132', 1, 2, b'0'),
	('C133', 1, 2, b'0'),
	('C134', 1, 2, b'0'),
	('C231', 2, 2, b'0'),
	('C232', 2, 2, b'0'),
	('C233', 2, 2, b'0'),
	('C234', 2, 2, b'0'),
	('C331', 3, 2, b'0'),
	('C332', 3, 2, b'0'),
	('C333', 3, 2, b'0'),
	('C334', 3, 2, b'0'),
	('C431', 4, 2, b'0'),
	('C432', 4, 2, b'0'),
	('C433', 4, 2, b'0'),
	('C434', 4, 2, b'0'),
	('C531', 5, 2, b'0'),
	('C532', 5, 2, b'0'),
	('C533', 5, 2, b'0'),
	('C534', 5, 2, b'0'),
	('C631', 6, 2, b'0'),
	('C632', 6, 2, b'0'),
	('C633', 6, 2, b'0'),
	('C634', 6, 2, b'0'),
	('C731', 7, 2, b'0'),
	('C732', 7, 2, b'0'),
	('C733', 7, 2, b'0'),
	('C734', 7, 2, b'0'),
	('C831', 8, 2, b'0'),
	('C832', 8, 2, b'0'),
	('C833', 8, 2, b'0'),
	('C834', 8, 2, b'0'),
	('C931', 9, 2, b'0'),
	('C932', 9, 2, b'0'),
	('C933', 9, 2, b'0'),
	('C934', 9, 2, b'0'),
	('C1031', 10, 2, b'0'),
	('C1032', 10, 2, b'0'),
	('C1033', 10, 2, b'0'),
	('C1034', 10, 2, b'0'),
	('C1131', 11, 2, b'0'),
	('C1132', 11, 2, b'0'),
	('C1133', 11, 2, b'0'),
	('C1134', 11, 2, b'0'),
	('C1231', 12, 2, b'0'),
	('C1232', 12, 2, b'0'),
	('C1233', 12, 2, b'0'),
	('C1234', 12, 2, b'0'),
	('C1331', 13, 2, b'0'),
	('C1332', 13, 2, b'0'),
	('C1333', 13, 2, b'0'),
	('C1334', 13, 2, b'0'),
	('C1431', 14, 2, b'0'),
	('C1432', 14, 2, b'0'),
	('C1433', 14, 2, b'0'),
	('C1434', 14, 2, b'0'),
	('C1531', 15, 2, b'0'),
	('C1532', 15, 2, b'0'),
	('C1533', 15, 2, b'0'),
	('C1534', 15, 2, b'0'),
	('D141', 1, 3, b'0'),
	('D142', 1, 3, b'0'),
	('D143', 1, 3, b'0'),
	('D144', 1, 3, b'0'),
	('D241', 2, 3, b'0'),
	('D242', 2, 3, b'0'),
	('D243', 2, 3, b'0'),
	('D244', 2, 3, b'0'),
	('D341', 3, 3, b'0'),
	('D342', 3, 3, b'0'),
	('D343', 3, 3, b'0'),
	('D344', 3, 3, b'0'),
	('D441', 4, 3, b'0'),
	('D442', 4, 3, b'0'),
	('D443', 4, 3, b'0'),
	('D444', 4, 3, b'0'),
	('D541', 5, 3, b'0'),
	('D542', 5, 3, b'0'),
	('D543', 5, 3, b'0'),
	('D544', 5, 3, b'0'),
	('D641', 6, 3, b'0'),
	('D642', 6, 3, b'0'),
	('D643', 6, 3, b'0'),
	('D644', 6, 3, b'0'),
	('D741', 7, 3, b'0'),
	('D742', 7, 3, b'0'),
	('D743', 7, 3, b'0'),
	('D744', 7, 3, b'0'),
	('D841', 8, 3, b'0'),
	('D842', 8, 3, b'0'),
	('D843', 8, 3, b'0'),
	('D844', 8, 3, b'0'),
	('D941', 9, 3, b'0'),
	('D942', 9, 3, b'0'),
	('D943', 9, 3, b'0'),
	('D944', 9, 3, b'0'),
	('D1041', 10, 3, b'1'),
	('D1042', 10, 3, b'0'),
	('D1043', 10, 3, b'0'),
	('D1044', 10, 3, b'0'),
	('D1141', 11, 3, b'0'),
	('D1142', 11, 3, b'0'),
	('D1143', 11, 3, b'0'),
	('D1144', 11, 3, b'0'),
	('D1241', 12, 3, b'0'),
	('D1242', 12, 3, b'0'),
	('D1243', 12, 3, b'0'),
	('D1244', 12, 3, b'0'),
	('D1341', 13, 3, b'0'),
	('D1342', 13, 3, b'0'),
	('D1343', 13, 3, b'0'),
	('D1344', 13, 3, b'0'),
	('D1441', 14, 3, b'0'),
	('D1442', 14, 3, b'0'),
	('D1443', 14, 3, b'0'),
	('D1444', 14, 3, b'0'),
	('D1541', 15, 3, b'0'),
	('D1542', 15, 3, b'0'),
	('D1543', 15, 3, b'0'),
	('D1544', 15, 3, b'0');
/*!40000 ALTER TABLE "Rooms" ENABLE KEYS */
;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */
;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */
;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */
;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */
;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */
;
